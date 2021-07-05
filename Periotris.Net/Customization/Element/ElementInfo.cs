using System;
using System.Runtime.Serialization;

namespace Periotris.Net.Customization.Element
{
    /// <summary>
    ///     Represent an element with its detailed information and facts.
    /// </summary>
    [Serializable]
    [DataContract]
    public struct ElementInfo
    {
        [DataMember] public string Name { get; set; }

        [DataMember] public string Symbol { get; set; }

        [DataMember] public int Number { get; set; }

        [DataMember] public double AtomicMass { get; set; }

        [DataMember] public string ElectronConfigSemantic { get; set; }
    }
}