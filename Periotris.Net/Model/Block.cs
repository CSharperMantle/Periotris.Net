using Periotris.Net.Common;

namespace Periotris.Net.Model
{
    /// <summary>
    ///     Represent a single block in an <see cref="Tetrimino" />.
    /// </summary>
    public class Block
    {
        public Block(TetriminoKind filledBy, Position position)
            : this(filledBy, position, 0, 0)
        {
        }

        public Block(TetriminoKind filledBy, Position position, int atomicNumber)
            : this(filledBy, position, atomicNumber, 0)
        {
        }

        public Block(TetriminoKind filledBy, Position position, int atomicNumber, int identifier)
        {
            FilledBy = filledBy;
            Position = position;
            AtomicNumber = atomicNumber;
            Identifier = identifier;
        }

        public int Identifier { get; internal set; }

        public TetriminoKind FilledBy { get; internal set; }

        public Position Position { get; internal set; }


        /// <summary>
        ///     The atomic number of the element this block representing.
        /// </summary>
        /// <remarks>
        ///     As for grouping headers the number is negative of the grouping id.
        ///     i.e. group 1 header block has an AtomicNumber of -1.
        /// </remarks>
        public int AtomicNumber { get; internal set; }

        public override string ToString()
        {
            return $"<Block FilledBy:{FilledBy} Position:{Position}>";
        }
    }
}