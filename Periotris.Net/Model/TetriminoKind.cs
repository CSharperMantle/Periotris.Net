namespace Periotris.Net.Model
{
    /// <summary>
    ///     Kinds of Tetrimino.
    ///     <para>Legend:</para>
    ///     <para>+: Filled block  -: Unfilled block  ^,v,left_arrow,right_arrow: Way up  o: Center</para>
    /// </summary>
    public enum TetriminoKind
    {
        /// <summary>
        ///     <para>-+^-</para>
        ///     <para>-+--</para>
        ///     <para>-+--</para>
        ///     <para>-+--</para>
        /// </summary>
        Linear,

        /// <summary>
        ///     <para>--^-</para>
        ///     <para>----</para>
        ///     <para>-++-</para>
        ///     <para>-++-</para>
        /// </summary>
        Cubic,

        /// <summary>
        ///     <para>--^-</para>
        ///     <para>-+--</para>
        ///     <para>-+--</para>
        ///     <para>-++-</para>
        /// </summary>
        LShapedCis,

        /// <summary>
        ///     <para>--^-</para>
        ///     <para>--+-</para>
        ///     <para>--+-</para>
        ///     <para>-++-</para>
        /// </summary>
        LShapedTrans,

        /// <summary>
        ///     <para>--^-</para>
        ///     <para>----</para>
        ///     <para>++--</para>
        ///     <para>-++-</para>
        /// </summary>
        ZigZagCis,

        /// <summary>
        ///     <para>--^-</para>
        ///     <para>----</para>
        ///     <para>-++-</para>
        ///     <para>++--</para>
        /// </summary>
        ZigZagTrans,

        /// <summary>
        ///     <para>--^-</para>
        ///     <para>----</para>
        ///     <para>-+--</para>
        ///     <para>+++-</para>
        /// </summary>
        TeeShaped,

        AvailableToFill,

        UnavailableToFill
    }
}