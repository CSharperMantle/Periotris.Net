using Periotris.Net.Common;
using Periotris.Net.Model.Generation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Periotris.Net.Model
{
    /// <summary>
    ///     Represent a basic tetrimino with basic features.
    /// </summary>
    public class Tetrimino
    {
        protected Tetrimino(TetriminoKind kind, Position position, Position firstBlockPosition,
            Direction facingDirection)
        {
            Kind = kind;
            Position = position;
            FacingDirection = facingDirection;
            FirstBlockPosition = firstBlockPosition;
            Blocks = GeneratorHelper.CreateOffsetBlocks(kind, Position, facingDirection);
        }

        /// <summary>
        ///     <para>
        ///         <see cref="Position" /> of the 'first block'.
        ///     </para>
        ///     First block is the first filled block, upper-most and left-most.
        ///     For example, in a trans zig-zag Tetrimino, the upper vertical block is considered first block.
        ///     <para>- F +</para>
        ///     <para>+ + -</para>
        /// </summary>
        public Position FirstBlockPosition { get; }

        public Direction FacingDirection { get; internal set; }

        public TetriminoKind Kind { get; }

        public Position Position { get; internal set; }

        public IReadOnlyList<Block> Blocks { get; internal set; }

        /// <summary>
        ///     Move a <see cref="Tetrimino" /> towards a <see cref="MoveDirection" /> if permits.
        ///     The <see cref="Tetrimino" /> will not be changed if the operation fails.
        /// </summary>
        /// <param name="collisionChecker">
        ///     A <see cref="Func{Block, Boolean}" /> which returns true.
        ///     when the block will collide
        /// </param>
        /// <param name="direction">Direction to move</param>
        /// <returns>Whether the <see cref="TryMove(MoveDirection, Func{Block, bool})" /> step succeeds</returns>
        public bool TryMove(MoveDirection direction, Func<Block, bool> collisionChecker)
        {
            Position position = Position;
            if (direction == MoveDirection.Down)
            {
                int row = position.Y + 1;
                position = new Position(position.X, row);
            }
            else
            {
                int delta = direction == MoveDirection.Right ? 1 : -1;
                int column = position.X + delta;
                position = new Position(column, position.Y);
            }

            IReadOnlyList<Block> newBlocks = GeneratorHelper.CreateOffsetBlocks(Kind, position, FacingDirection);
            if (newBlocks.Any(collisionChecker))
            {
                return false;
            }

            GeneratorHelper.MapAtomicNumberForNewBlocks(Blocks, newBlocks);

            Position = position;
            Blocks = newBlocks;
            return true;
        }

        /// <summary>
        ///     Rotate a <see cref="Tetrimino" /> towards a <see cref="RotationDirection" /> if permits.
        ///     The <see cref="Tetrimino" /> will not be changed if the operation fails.
        /// </summary>
        /// <param name="collisionChecker">
        ///     A <see cref="Func{Block, Boolean}" /> which returns true when the block will
        ///     collide
        /// </param>
        /// <param name="rotationDirection">Direction to rotate</param>
        /// <returns>Whether the <see cref="TryRotate" /> step succeeds</returns>
        public bool TryRotate(RotationDirection rotationDirection, Func<Block, bool> collisionChecker)
        {
            int count = Enum.GetValues(typeof(Direction)).Length;
            int delta = rotationDirection == RotationDirection.Right ? 1 : -1;
            int direction = (int)FacingDirection + delta;
            if (direction < 0)
            {
                direction += count;
            }

            if (direction >= count)
            {
                direction %= count;
            }

            int[] adjustPattern = Kind == TetriminoKind.Linear
                ? new[] { 0, 1, -1, 2, -2 }
                : new[] { 0, 1, -1 };
            foreach (int adjust in adjustPattern)
            {
                Position newPos = new(Position.X + adjust, Position.Y);
                IReadOnlyList<Block> newBlocks = GeneratorHelper.CreateOffsetBlocks(Kind, newPos, (Direction)direction);

                if (!newBlocks.Any(collisionChecker))
                {
                    GeneratorHelper.MapAtomicNumberForNewBlocks(Blocks, newBlocks);

                    FacingDirection = (Direction)direction;
                    Position = newPos;
                    Blocks = newBlocks;
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return $"<Tetrimino Kind:{Kind} Position:{Position} FirstBlock:{FirstBlockPosition}>";
        }

        public static Tetrimino ByPosition(TetriminoKind kind, Position position, Direction facingDirection)
        {
            return new Tetrimino(kind,
                position,
                GeneratorHelper.GetFirstBlockPositionByPosition(position, kind, facingDirection),
                facingDirection);
        }

        public static Tetrimino ByFirstBlockPosition(TetriminoKind kind, Position firstBlockPosition,
            Direction facingDirection)
        {
            return new Tetrimino(kind,
                GeneratorHelper.GetPositionByFirstBlockPosition(firstBlockPosition, kind, facingDirection),
                firstBlockPosition,
                facingDirection);
        }
    }
}