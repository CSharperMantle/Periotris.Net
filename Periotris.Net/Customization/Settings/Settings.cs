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

using Periotris.Net.Common;
using System;
using System.Runtime.Serialization;

namespace Periotris.Net.Customization.Settings
{
    /// <summary>
    ///     Represent a set of game settings.
    /// </summary>
    [Serializable]
    [DataContract]
    public struct Settings
    {
        public static readonly Settings Default = new()
        {
            ColorMode = ColorMode.Default,
            AssistanceGridMode = AssistanceGridMode.Enabled,
            HistoryFilePath = PeriotrisConst.PeriotrisGameDataPath + PeriotrisConst.HistoryFileName,
            UseCustomMap = false,
            CustomMapPath = PeriotrisConst.DefaultMapJsonFileName
        };

        [DataMember] public AssistanceGridMode AssistanceGridMode { get; set; }
        [DataMember] public ColorMode ColorMode { get; set; }
        [DataMember] public string CustomMapPath { get; set; }
        [DataMember] public string HistoryFilePath { get; set; }
        [DataMember] public bool UseCustomMap { get; set; }
    }
}