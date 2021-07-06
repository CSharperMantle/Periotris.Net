/*
 * Periotris.Net
 * Copyright (C) 2020-present Rong "Mantle" Bao (CSharperMantle)
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see < https://github.com/CSharperMantle/Periotris.Net/blob/main/LICENSE >.
 */

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
        /// <summary>
        ///     Get the instance of <see cref="ElementInfoManager" />.
        /// </summary>
        public static ElementInfoManager Instance => instance.Value;

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
        /// Get the current data file path.
        /// </summary>
        /// <returns>The current data file path.</returns>
        public string GetDataFilePath()
        {
            return dataFilePath;
        }

        /// <summary>
        ///     Set the data file path. The method will purge the cache when necessary.
        /// </summary>
        /// <param name="value">The new value.</param>
        /// <param name="pathType">Kind of the path.</param>
        public void SetDataFilePath(string value, PathType pathType)
        {
            ReloadPeriodicTable(value, pathType);
            dataFilePath = value;
        }

        // ReSharper disable once InconsistentNaming
        private static readonly Lazy<ElementInfoManager> instance
            = new(() => new ElementInfoManager());

        private readonly Dictionary<int, ElementInfo> _cacheElementInfo
            = new();

        private JObject _periodicTableRoot;

        private string dataFilePath = string.Empty;

        private ElementInfoManager()
        {
            SetDataFilePath(PeriotrisConst.PeriodicTableJsonFileName, PathType.Resource);
        }

        /// <summary>
        ///     Reload the periodic table from a given path.
        /// </summary>
        /// <param name="pathOrUri">Path to periodic table in JSON format.</param>
        /// <param name="pathType">Kind of the path.</param>
        private void ReloadPeriodicTable(string pathOrUri, PathType pathType)
        {
            // Purge cache.
            _cacheElementInfo.Clear();

            using Stream stream = FileIO.OpenStreamByType(pathOrUri, pathType);
            using StreamReader reader = new(stream);
            string content = reader.ReadToEnd();
            _periodicTableRoot = JObject.Parse(content);
        }
    }
}