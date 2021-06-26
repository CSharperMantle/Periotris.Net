using Periotris.Common;
using System.Collections.Generic;

namespace Periotris.Net.Model.Generation
{
    internal class TetriminoNode : Tetrimino
    {
        public readonly HashSet<TetriminoNode> DependedBy = new();

        public readonly HashSet<TetriminoNode> Depending = new();

        public TetriminoNode(TetriminoKind kind, Position position, Position firstBlockPosition,
            Direction facingDirection)
            : base(kind, position, firstBlockPosition, facingDirection)
        {
        }

        public IReadOnlyList<MemoizedBlock> MemoizedBlocks { get; set; }
    }
}