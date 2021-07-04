using Newtonsoft.Json.Linq;
using Periotris.Net.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Periotris.Net.Customization.Element
{
    /// <summary>
    ///     Support a way to obtain <see cref="ElementInfo" /> from a pre-defined JSON file.
    /// </summary>
    public sealed class ElementInfoManager
    {
        // ReSharper disable once InconsistentNaming
        private static readonly Lazy<ElementInfoManager> instance
            = new(() => new ElementInfoManager());

        private readonly Dictionary<int, ElementInfo> _cacheElementInfo
            = new();

        private JObject _periodicTableRoot;

        private ElementInfoManager()
        {
            DataFilePath = PeriotrisConst.PeriodicTableJsonFileName;
        }

        /// <summary>
        ///     Get the instance of <see cref="ElementInfoManager" />.
        /// </summary>
        public static ElementInfoManager Instance => instance.Value;

        private string dataFilePath = string.Empty;

        public string DataFilePath
        {
            get => dataFilePath;
            set
            {
                ReloadPeriodicTable(value);
                dataFilePath = value;
            }
        }


        /// <summary>
        ///     Obtain a <see cref="ElementInfo" /> by atomic number.
        /// </summary>
        /// <param name="atomicNumber">The element to obtain.</param>
        /// <returns><see cref="ElementInfo" /> about the element.</returns>
        /// <remarks>
        ///     This method includes a cache mechanism.
        ///     If <see cref="atomicNumber" /> is non-positive then it will return
        ///     a new <see cref="ElementInfo" /> with only <see cref="ElementInfo.Number" />
        ///     and <see cref="ElementInfo.Symbol" /> set to their adjusted group
        ///     number.
        /// </remarks>
        public ElementInfo ByAtomicNumber(int atomicNumber)
        {
            if (_cacheElementInfo.ContainsKey(atomicNumber))
            {
                return _cacheElementInfo[atomicNumber];
            }

            ElementInfo elementInfo;

            if (atomicNumber <= 0)
            {
                elementInfo = new ElementInfo
                {
                    Number = -atomicNumber,
                    Symbol = (-atomicNumber).ToString()
                };
            }
            else
            {
                elementInfo = (from element in _periodicTableRoot["elements"]
                               where (int)element["number"] == atomicNumber
                               select new ElementInfo
                               {
                                   Name = (string)element["name"],
                                   Symbol = (string)element["symbol"],
                                   Number = atomicNumber,
                                   AtomicMass = (double)element["atomic_mass"],
                                   ElectronConfigSemantic = (string)element["electron_configuration_semantic"]
                               }).First();
            }

            _cacheElementInfo.Add(atomicNumber, elementInfo);

            return elementInfo;
        }

        /// <summary>
        ///     Reload the periodic table from a given path.
        /// </summary>
        /// <param name="pathOrUri">Path to periodic table in JSON format.</param>
        /// <param name="uriKind">Kind of the path.</param>
        private void ReloadPeriodicTable(string pathOrUri)
        {
            // Purge cache.
            _cacheElementInfo.Clear();

            using Stream stream = FileIO.OpenResourceStream(pathOrUri);
            using StreamReader reader = new(stream);
            string content = reader.ReadToEnd();
            _periodicTableRoot = JObject.Parse(content);
        }
    }
}