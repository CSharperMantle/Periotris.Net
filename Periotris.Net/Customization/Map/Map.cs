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
using Periotris.Net.Model;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace Periotris.Net.Customization.Map
{
    [Serializable]
    [DataContract]
    public struct Map
    {
        public static Map Default
        {
            get
            {
                using Stream mapStream = FileIO.OpenStreamByType(PeriotrisConst.DefaultMapJsonFileName, PathType.Resource);
                using StreamReader reader = new(mapStream);
                JsonSerializer serializer = new();
                object readObject = serializer.Deserialize(reader, typeof(Map));
                Map map = readObject != null
                    ? (Map)readObject
                    : throw new FileNotFoundException(null, PeriotrisConst.DefaultMapJsonFileName);
                return map;
            }
        }

        [DataMember] public Block[,] BlocksMap { get; set; }
        [DataMember] public int ColumnsCount { get; set; }
        [DataMember] public int RowsCount { get; set; }
        [DataMember] public int TotalAvailableBlocksCount { get; set; }
    }
}