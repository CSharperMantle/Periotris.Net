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

using System;
using System.Runtime.Serialization;
using System.Windows;

namespace Periotris.Net.Common
{
    [Serializable]
    [DataContract]
    public struct Position : IEquatable<Position>
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        [DataMember] public int X { get; set; }
        [DataMember] public int Y { get; set; }

        public static bool Equals(Position pos1, Position pos2)
        {
            return pos1.X == pos2.X && pos1.Y == pos2.Y;
        }

        public static bool operator !=(Position pos1, Position pos2)
        {
            return !(pos1 == pos2);
        }

        public static bool operator ==(Position pos1, Position pos2)
        {
            return Equals(pos1, pos2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Position))
            {
                return false;
            }

            Position value = (Position)obj;
            return Equals(this, value);
        }

        public bool Equals(Position pos)
        {
            return Equals(this, pos);
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public Point ToPoint()
        {
            return new Point(X, Y);
        }

        public override string ToString()
        {
            return $"<Position X:{X} Y:{Y}>";
        }
    }
}