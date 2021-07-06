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