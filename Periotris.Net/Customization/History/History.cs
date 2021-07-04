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
        private History()
        {
            PlayRecords = new List<TimeSpan>();
            FastestRecord = null;
        }

        [DataMember] public List<TimeSpan> PlayRecords { get; private set; }

        [DataMember] public TimeSpan? FastestRecord { get; private set; }

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

        public static void WriteToFile(History history)
        {
            JsonSerializer jsonSerializer = new();

            using FileStream outStream = FileIO.OpenDataFile(PeriotrisConst.HistoryFileName);
            using StreamWriter sw = new(outStream);
            using JsonTextWriter writer = new(sw);
            jsonSerializer.Serialize(writer, history);
        }

        public static History ReadFromFile()
        {
            if (!File.Exists(PeriotrisConst.HistoryFileName))
            {
                return new History();
            }

            JsonSerializer jsonSerializer = new();

            using FileStream inStream = FileIO.OpenDataFile(PeriotrisConst.HistoryFileName);
            using StreamReader sr = new(inStream);
            using JsonTextReader reader = new(sr);
            return jsonSerializer.Deserialize<History>(reader);
        }
    }
}