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
        [DataMember] public bool ShouldRenderGridAssistance { get; set; }

        [DataMember] public bool ShouldRenderColors { get; set; }

        [DataMember] public string HistoryFilePathFull { get; set; }

        public static readonly Settings Default = new()
        {
            ShouldRenderGridAssistance = true,
            ShouldRenderColors = true,
            HistoryFilePathFull = PeriotrisConst.PeriotrisGameDataPath + PeriotrisConst.HistoryFileName
        };
    }
}
