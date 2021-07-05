using System.Windows;

namespace Periotris.Net.Common
{
    /// <summary>
    ///     Enum for different file path types.
    /// </summary>
    /// A path is considered a <see cref="Resource"/> when it can be read via
    /// <see cref="Application.GetResourceStream(System.Uri)"/>, e.g.
    /// "pack://application:,,,/Assets/PeriodicTable.json".
    /// 
    /// It is considered an <see cref="External"/> when it is a physical
    /// absolute path, e.g. "D:\\foo\\bar\\grok.json".
    /// 
    /// It is considered <see cref="Data"/> when it is relative to
    /// <see cref="PeriotrisConst.PeriotrisGameDataPath"/>, e.g. "history.json".
    public enum PathType
    {
        Resource,
        External,
        Data
    }
}
