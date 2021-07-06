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
    public enum Direction
    {
        /// <summary>
        ///     <para>----</para>
        ///     <para>----</para>
        ///     <para>~-o+</para>
        ///     <para>-+++</para>
        /// </summary>
        Left,

        /// <summary>
        ///     <para>--^-</para>
        ///     <para>-+--</para>
        ///     <para>-+o-</para>
        ///     <para>-++-</para>
        /// </summary>
        Up,

        /// <summary>
        ///     <para>----</para>
        ///     <para>-+++</para>
        ///     <para>-+o-</para>
        ///     <para>----</para>
        /// </summary>
        Right,

        /// <summary>
        ///     <para>----</para>
        ///     <para>--++</para>
        ///     <para>--o+</para>
        ///     <para>--v+</para>
        /// </summary>
        Down
    }

    public enum MoveDirection
    {
        Left,
        Right,
        Down
    }

    public enum RotationDirection
    {
        Left,
        Right
    }
}