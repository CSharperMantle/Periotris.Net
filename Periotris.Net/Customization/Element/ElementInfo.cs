namespace Periotris.Net.Customization.Element
{
    /// <summary>
    ///     Represent an element with its detailed information and facts.
    /// </summary>
    public struct ElementInfo
    {
        public string Name { get; set; }

        public string Symbol { get; set; }

        public int Number { get; set; }

        public double AtomicMass { get; set; }

        public string ElectronConfigSemantic { get; set; }
    }
}