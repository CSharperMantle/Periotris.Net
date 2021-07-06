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
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Periotris.Net.Customization.History
{
    [Serializable]
    [DataContract]
    public class History
    {
        [DataMember] public TimeSpan? FastestRecord { get; private set; }

        [DataMember] public List<TimeSpan> PlayRecords { get; private set; }

        public static History ReadFromFile()
        {
            if (!File.Exists(PeriotrisConst.HistoryFileName))
            {
                return new History();
            }

            JsonSerializer jsonSerializer = new();

            using Stream inStream = FileIO.OpenStreamByType(PeriotrisConst.HistoryFileName, PathType.Data);
            using StreamReader sr = new(inStream);
            using JsonTextReader reader = new(sr);
            return jsonSerializer.Deserialize<History>(reader);
        }

        public static void WriteToFile(History history)
        {
            JsonSerializer jsonSerializer = new();

            using Stream outStream = FileIO.OpenStreamByType(PeriotrisConst.HistoryFileName, PathType.Data);
            using StreamWriter sw = new(outStream);
            using JsonTextWriter writer = new(sw);
            jsonSerializer.Serialize(writer, history);
        }

        /// <summary>
        ///     Add a new score to the record.
        /// </summary>
        /// <param name="newPlayTime">The new play time.</param>
        /// <returns>Whether the new score is the new record.</returns>
        public bool AddNewScore(TimeSpan newPlayTime)
        {
            PlayRecords.Add(newPlayTime);
            if (!FastestRecord.HasValue)
            {
                FastestRecord = newPlayTime;
                return true;
            }

            if (newPlayTime < FastestRecord)
            {
                FastestRecord = newPlayTime;
                return true;
            }

            return false;
        }

        private History()
        {
            PlayRecords = new List<TimeSpan>();
            FastestRecord = null;
        }
    }
}