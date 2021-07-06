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

namespace Periotris.Net.Customization.Element
{
    /// <summary>
    ///     Represent an element with its detailed information and facts.
    /// </summary>
    [Serializable]
    [DataContract]
    public struct ElementInfo
    {
        [DataMember] public double AtomicMass { get; set; }
        [DataMember] public string ElectronConfigSemantic { get; set; }
        [DataMember] public string Name { get; set; }

        [DataMember] public int Number { get; set; }
        [DataMember] public string Symbol { get; set; }
    }
}