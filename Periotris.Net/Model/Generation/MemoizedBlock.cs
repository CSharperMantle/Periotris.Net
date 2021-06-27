using Periotris.Net.Common;

namespace Periotris.Net.Model.Generation
{
    internal class MemoizedBlock : Block
    {
        public MemoizedBlock(TetriminoKind filledBy, Position position, TetriminoNode owner, int atomicNumber = 0,
            int identifier = 0)
            : base(filledBy, position, atomicNumber, identifier)
        {
            Owner = owner;
        }

        public TetriminoNode Owner { get; set; }
    }
}