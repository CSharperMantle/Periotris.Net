using System;

namespace Periotris.Net.Model
{
    /// <summary>
    ///     A subclass of <see cref="EventArgs" /> which is used when a <see cref="Block" /> changes, either in position or if
    ///     being shown.
    /// </summary>
    public class BlockChangedEventArgs : EventArgs
    {
        public BlockChangedEventArgs(Block blockUpdated, bool disappeared)
        {
            BlockUpdated = blockUpdated;
            Disappeared = disappeared;
        }

        public Block BlockUpdated { get; }
        public bool Disappeared { get; }
    }
}