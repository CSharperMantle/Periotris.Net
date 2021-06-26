using Periotris.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Periotris.Net.Model.Generation
{
    internal static class PatternGenerator
    {
        /// <summary>
        ///     Get a list of playable and encapsulated <see cref="Tetrimino" /> in the pattern of the
        ///     periodic table.
        /// </summary>
        public static IReadOnlyList<Tetrimino> GetPlayablePattern(Random rand)
        {
            int dim0Len = GeneratorHelper.PeriodicTableTemplate.GetLength(0);
            int dim1Len = GeneratorHelper.PeriodicTableTemplate.GetLength(1);
            Block[,] template = new Block[dim0Len, dim1Len];
            for (int i = 0; i < dim0Len; i++)
            {
                for (int j = 0; j < dim1Len; j++)
                {
                    template[i, j] = new Block(GeneratorHelper.PeriodicTableTemplate[i, j].FilledBy,
                    GeneratorHelper.PeriodicTableTemplate[i, j].Position,
                    GeneratorHelper.PeriodicTableTemplate[i, j].AtomicNumber
                );
                }
            }

            IReadOnlyList<Tetrimino> tetriminos = TetriminoSorter.Sort(
                GetPossibleTetriminoPattern(template, rand), dim1Len, dim0Len);
            Parallel.ForEach(tetriminos,
                tetrimino =>
                {
                    // Repositioning the tetriminos.
                    Position originalPosition = tetrimino.Position;
                    Position newPosition = GeneratorHelper.GetInitialPositionByKind(tetrimino.Kind);
                    int deltaX = newPosition.X - originalPosition.X;
                    int deltaY = newPosition.Y - originalPosition.Y;
                    List<Block> newBlocks = new(tetrimino.Blocks.Count);
                    newBlocks
                        .AddRange(
                            tetrimino.Blocks.Select(
                                block => new Block(block.FilledBy,
                                    new Position(block.Position.X + deltaX, block.Position.Y + deltaY),
                                    block.AtomicNumber,
                                    block.Identifier)
                            )
                        );
                    tetrimino.Blocks = newBlocks;
                    tetrimino.Position = newPosition;

                    // Randomly rotate the current Tetrimino.
                    int rotationCount = rand.Next(0, Enum.GetValues(typeof(Direction)).Length);
                    for (int i = 0; i < rotationCount; i++)
                    {
                        tetrimino.TryRotate(RotationDirection.Right, _ => false);
                    }
                });
            return tetriminos;
        }

        /// <summary>
        ///     Generate a <see cref="IReadOnlyList{T}" /> of <see cref="Tetrimino" />s that fills the given template.
        /// </summary>
        /// <param name="template">
        ///     <para>
        ///         A two-dimensional <see cref="Array" /> of <see cref="Block" />s.
        ///     </para>
        ///     <para>
        ///         This array should only contain blocks with <see cref="TetriminoKind.AvailableToFill" /> or
        ///         <see cref="TetriminoKind.UnavailableToFill" />.
        ///         The former one indicates that this block is fillable with <see cref="Tetrimino" /> while the latter one has the
        ///         opposite meaning.
        ///     </para>
        /// </param>
        /// <param name="rand">A random number generator</param>
        /// <returns>
        ///     When this method returns, contains a <see cref="IReadOnlyList{T}" /> of <see cref="Tetrimino" />s of settled
        ///     (placed) tetriminos, or
        ///     an empty one when fails to generate.
        /// </returns>
        private static IReadOnlyList<Tetrimino> GetPossibleTetriminoPattern(Block[,] template, Random rand)
        {
            // This is where we do our tracking jobs - to track which blocks are available to fill
            Block[,] workspace = template;
            // This is where we place our settled tetriminos - we use Stack because we may need to go back a few steps if a plan fails
            // The initial capacity is the estimated numbers of tetriminos
            Stack<Tetrimino> settledTetrimino = new(GeneratorHelper.TotalAvailableBlocks / 4);
            // This is where we place our information to generate randomized tetriminos
            Stack<Stack<KindDirectionsPair>> pendingTetriminoKinds = new();

            // These are cursors. Before each iteration
            bool rewindingRequired = false;

            /* Here in the main loop there are many things we need to do:
             * 0. All cursors are set to null when beginning this loop.
             * 
             * 1. Check if there are any more unplaced blocks, if so, we will record its coordinates.
             *    Otherwise we will just return the placed Stack as there are no more Tetriminos to 
             *    place.
             *    
             * 2. Generate a randomly-ordered list of TetriminoKind and iterate all over them. Check
             *    if there are any possible placeable Tetrimino configurations and push it to the stack.
             *    The cursors are set to null for a new iteration from Step 1. Do not forget to set its Blocks
             *    to its suitable FilledBy state in the workspace.
             *    
             * 3. If there are no possible placeable Tetriminos then we need to 'rewind' the stack.
             *    We pop back one Tetrimino and its corresponding stack of TetriminoKind, choose the
             *    next one and then go back to Step 2. Do not forget to erase any settled block state of
             *    the popped Tetrimino in the workspace.
             */
            while (true)
            {
                // Step 1.
                // First we need to find the position of the first block in the workspace
                int firstBlockRow;
                int firstBlockCol;
                (firstBlockCol, firstBlockRow) = GetFirstAvailableBlockCoordination(workspace);
                if (!(firstBlockCol >= 0 && firstBlockRow >= 0))
                {
                    // There are no more blocks to fill. Returning.
                    return settledTetrimino.ToArray();
                }

                // Step 2.
                // Now we find an empty block. Generate a new Tetrimino using randomized stack of TetriminoKind.
                Stack<KindDirectionsPair> currentTetriminoKindDirectionsPairStack;
                if (!rewindingRequired)
                {
                    // This could mean this is the first run or the last iteration has succeeded in placing a block.
                    currentTetriminoKindDirectionsPairStack = new Stack<KindDirectionsPair>(new[]
                    {
                        new KindDirectionsPair(TetriminoKind.Cubic, rand),
                        new KindDirectionsPair(TetriminoKind.Linear, rand),
                        new KindDirectionsPair(TetriminoKind.LShapedCis, rand),
                        new KindDirectionsPair(TetriminoKind.LShapedTrans, rand),
                        new KindDirectionsPair(TetriminoKind.TeeShaped, rand),
                        new KindDirectionsPair(TetriminoKind.ZigZagCis, rand),
                        new KindDirectionsPair(TetriminoKind.ZigZagTrans, rand)
                    }.OrderBy(x => rand.Next()));
                }
                else
                {
                    // In this case we need to rewind the stack for one.
                    if (settledTetrimino.Count == 0)
                    {
                        // No way out, return!
                        return settledTetrimino.ToArray();
                    }

                    currentTetriminoKindDirectionsPairStack = pendingTetriminoKinds.Pop();
                    // We still have chances...
                    Tetrimino lastTetrimino = settledTetrimino.Pop();
                    foreach (Block block in lastTetrimino.Blocks)
                    {
                        workspace[block.Position.Y, block.Position.X].FilledBy = TetriminoKind.AvailableToFill;
                    }
                }

                // Anyway, we need to obtain a new TetriminoKind and test over all
                // possible directions.
                bool solutionFound = false;
                while (currentTetriminoKindDirectionsPairStack.Count > 0)
                {
                    KindDirectionsPair currentPair = currentTetriminoKindDirectionsPairStack.Pop();
                    while (currentPair.PendingDirections.Count > 0)
                    {
                        Direction direction = currentPair.PendingDirections.Pop();
                        Tetrimino tetrimino = Tetrimino.ByFirstBlockPosition(currentPair.TetriminoKind,
                            new Position(firstBlockCol, firstBlockRow),
                            direction
                        );
                        if (!tetrimino.Blocks.Any(CheckBlockCollision))
                        {
                            // Now that we found a solution. Push these to the stack and go to the next iteration.
                            settledTetrimino.Push(tetrimino);
                            pendingTetriminoKinds.Push(currentTetriminoKindDirectionsPairStack);
                            foreach (Block block in tetrimino.Blocks)
                            {
                                block.AtomicNumber = workspace[block.Position.Y, block.Position.X].AtomicNumber;
                                workspace[block.Position.Y, block.Position.X].FilledBy = block.FilledBy;
                            }

                            currentTetriminoKindDirectionsPairStack = null;
                            solutionFound = true;
                            rewindingRequired = false;
                            break;
                        }

                        // Oops, collision found.
                        // We will continue to test over the rest possible combinations.
                    }

                    if (solutionFound)
                    {
                        break;
                    }
                }

                // Step 3.
                if (!solutionFound)
                {
                    // We have run out of options. We need to pop out the previous one.
                    rewindingRequired = true;
                }
            }

            // True if the block will collide.
            bool CheckBlockCollision(Block block)
            {
                int nRow = block.Position.Y;
                int nCol = block.Position.X;

                // Left, right or bottom border collision
                if (nCol < 0 || nCol >= workspace.GetLength(1) || nRow >= workspace.GetLength(0))
                {
                    return true;
                }
                // Block-block collision
                return workspace[nRow, nCol].FilledBy != TetriminoKind.AvailableToFill;
            }
        }

        /// <summary>
        ///     Get the coordination of the first <see cref="Block" /> with <see cref="TetriminoKind.AvailableToFill" />.s
        /// </summary>
        /// <param name="blocks">Two-dimentional array to search in</param>
        /// <returns>A pair of coordination X and Y. (-1, -1) if not found.</returns>
        private static (int X, int Y) GetFirstAvailableBlockCoordination(Block[,] blocks)
        {
            int firstBlockRow = -1;
            int firstBlockCol = -1;
            bool firstBlockFound = false;
            for (int nRow = blocks.GetLength(0) - 1; nRow >= 0; nRow--)
            {
                for (int nCol = blocks.GetLength(1) - 1; nCol >= 0; nCol--)
                {
                    if (blocks[nRow, nCol].FilledBy == TetriminoKind.AvailableToFill)
                    {
                        firstBlockRow = nRow;
                        firstBlockCol = nCol;
                        firstBlockFound = true;
                        break;
                    }
                }

                if (firstBlockFound)
                {
                    break;
                }
            }

            return (firstBlockCol, firstBlockRow);
        }

        private class KindDirectionsPair
        {
            private static readonly Direction[] AllDirections =
            {
                Direction.Left,
                Direction.Right,
                Direction.Up,
                Direction.Down
            };

            public KindDirectionsPair(TetriminoKind kind, Random rand)
            {
                TetriminoKind = kind;
                PendingDirections = new Stack<Direction>(AllDirections.OrderBy(x => rand.Next()));
            }

            public TetriminoKind TetriminoKind { get; }

            public Stack<Direction> PendingDirections { get; }
        }
    }
}
