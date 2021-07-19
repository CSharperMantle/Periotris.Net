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

using Newtonsoft.Json;
using Periotris.Net.Common;
using System;
using System.Runtime.Serialization;

namespace Periotris.Net.Model
{
    /// <summary>
    ///     Represent a single block in an <see cref="Tetrimino" />.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Block
    {
        public Block(TetriminoKind filledBy, Position position)
            : this(filledBy, position, 0, 0)
        {
        }

        public Block(TetriminoKind filledBy, Position position, int atomicNumber)
            : this(filledBy, position, atomicNumber, 0)
        {
        }

        [JsonConstructor]
        public Block(TetriminoKind filledBy, Position position, int atomicNumber, int identifier)
        {
            FilledBy = filledBy;
            Position = position;
            AtomicNumber = atomicNumber;
            Identifier = identifier;
        }

        /// <summary>
        ///     The atomic number of the element this block representing.
        /// </summary>
        /// <remarks>
        ///     As for grouping headers the number is negative of the grouping id.
        ///     i.e. group 1 header block has an AtomicNumber of -1.
        /// </remarks>
        [DataMember] public int AtomicNumber { get; internal set; }

        [DataMember] public TetriminoKind FilledBy { get; internal set; }
        [DataMember] public int Identifier { get; internal set; }
        [DataMember] public Position Position { get; internal set; }

        public override string ToString()
        {
            return $"<Block FilledBy:{FilledBy} Position:{Position}>";
        }
    }
}