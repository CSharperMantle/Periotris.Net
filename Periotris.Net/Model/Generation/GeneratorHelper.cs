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

using Periotris.Net.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Periotris.Net.Model.Generation
{
    internal static class GeneratorHelper
    {
        public static readonly int[,] CubicMaskDown =
                {
            {3, 4},
            {2, 1}
        };

        public static readonly int[,] CubicMaskLeft =
                {
            {2, 3},
            {1, 4}
        };

        public static readonly int[,] CubicMaskRight =
                {
            {4, 1},
            {3, 2}
        };

        public static readonly int[,] CubicMaskUp =
                {
            {1, 2},
            {4, 3}
        };

        public static readonly int[,] LCisDownMask =
                {
            {4, 3, 0},
            {0, 2, 0},
            {0, 1, 0}
        };

        public static readonly int[,] LCisLeftMask =
                {
            {0, 0, 4},
            {1, 2, 3},
            {0, 0, 0}
        };

        public static readonly int[,] LCisRightMask =
                {
            {0, 0, 0},
            {3, 2, 1},
            {4, 0, 0}
        };

        public static readonly int[,] LCisUpMask =
                {
            {0, 1, 0},
            {0, 2, 0},
            {0, 3, 4}
        };

        public static readonly int[,] LinearDownMask =
                {
            {0, 0, 4, 0},
            {0, 0, 3, 0},
            {0, 0, 2, 0},
            {0, 0, 1, 0}
        };

        /// <summary>
        ///     Mask for <see cref="TetriminoKind.Linear" /> and <see cref="Direction.Left" />.
        /// </summary>
        /// <remarks>
        ///     The 1, 2, 3, 4 numbers are called 'identifiers' which is used to identify the
        ///     blocks in the same <see cref="TetriminoKind" /> with different directions.
        ///     These are used to guarantee the consistence for <see cref="Block.AtomicNumber" />
        ///     in
        ///     <see cref="Tetrimino.TryMove" />
        ///     and
        ///     <see
        ///         cref="Tetrimino.TryRotate" />
        ///     .
        /// </remarks>
        public static readonly int[,] LinearLeftMask =
        {
            {0, 0, 0, 0},
            {0, 0, 0, 0},
            {1, 2, 3, 4},
            {0, 0, 0, 0}
        };

        public static readonly int[,] LinearRightMask =
                {
            {0, 0, 0, 0},
            {4, 3, 2, 1},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        };

        public static readonly int[,] LinearUpMask =
                {
            {0, 1, 0, 0},
            {0, 2, 0, 0},
            {0, 3, 0, 0},
            {0, 4, 0, 0}
        };

        public static readonly int[,] LTransDownMask =
                {
            {0, 3, 4},
            {0, 2, 0},
            {0, 1, 0}
        };

        public static readonly int[,] LTransLeftMask =
                {
            {0, 0, 0},
            {1, 2, 3},
            {0, 0, 4}
        };

        public static readonly int[,] LTransRightMask =
                {
            {4, 0, 0},
            {3, 2, 1},
            {0, 0, 0}
        };

        public static readonly int[,] LTransUpMask =
                {
            {0, 1, 0},
            {0, 2, 0},
            {4, 3, 0}
        };

        public static readonly int[,] TeeDownMask =
                {
            {0, 0, 0},
            {4, 3, 2},
            {0, 1, 0}
        };

        public static readonly int[,] TeeLeftMask =
                {
            {0, 4, 0},
            {1, 3, 0},
            {0, 2, 0}
        };

        public static readonly int[,] TeeRightMask =
                {
            {0, 2, 0},
            {0, 3, 1},
            {0, 4, 0}
        };

        public static readonly int[,] TeeUpMask =
                {
            {0, 1, 0},
            {2, 3, 4},
            {0, 0, 0}
        };

        public static readonly int[,] ZCisDownMask =
        {
            {0, 0, 0},
            {4, 3, 0},
            {0, 2, 1}
        };

        public static readonly int[,] ZCisLeftMask =
        {
            {0, 4, 0},
            {2, 3, 0},
            {1, 0, 0}
        };

        public static readonly int[,] ZCisRightMask =
        {
            {0, 0, 1},
            {0, 3, 2},
            {0, 4, 0}
        };

        public static readonly int[,] ZCisUpMask =
                                {
            {1, 2, 0},
            {0, 3, 4},
            {0, 0, 0}
        };

        public static readonly int[,] ZTransDownMask =
        {
            {0, 0, 0},
            {0, 2, 1},
            {4, 3, 0}
        };

        public static readonly int[,] ZTransLeftMask =
        {
            {4, 0, 0},
            {3, 2, 0},
            {0, 1, 0}
        };

        public static readonly int[,] ZTransRightMask =
        {
            {0, 1, 0},
            {0, 2, 3},
            {0, 0, 4}
        };

        public static readonly int[,] ZTransUpMask =
                                {
            {0, 3, 4},
            {1, 2, 0},
            {0, 0, 0}
        };

        public static int[,] CreateBlocksMask(TetriminoKind kind, Direction direction)
        {
            int[,] blockMask = kind switch
            {
                TetriminoKind.Linear => direction switch
                {
                    Direction.Left => LinearLeftMask,
                    Direction.Up => LinearUpMask,
                    Direction.Right => LinearRightMask,
                    Direction.Down => LinearDownMask,
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
                },
                TetriminoKind.Cubic => direction switch
                {
                    Direction.Up => CubicMaskUp,
                    Direction.Right => CubicMaskRight,
                    Direction.Down => CubicMaskDown,
                    Direction.Left => CubicMaskLeft,
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
                },
                TetriminoKind.LShapedCis => direction switch
                {
                    Direction.Up => LCisUpMask,
                    Direction.Right => LCisRightMask,
                    Direction.Down => LCisDownMask,
                    Direction.Left => LCisLeftMask,
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
                },
                TetriminoKind.LShapedTrans => direction switch
                {
                    Direction.Up => LTransUpMask,
                    Direction.Right => LTransRightMask,
                    Direction.Down => LTransDownMask,
                    Direction.Left => LTransLeftMask,
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
                },
                TetriminoKind.ZigZagCis => direction switch
                {
                    Direction.Up => ZCisUpMask,
                    Direction.Right => ZCisRightMask,
                    Direction.Down => ZCisDownMask,
                    Direction.Left => ZCisLeftMask,
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
                },
                TetriminoKind.ZigZagTrans => direction switch
                {
                    Direction.Up => ZTransUpMask,
                    Direction.Right => ZTransRightMask,
                    Direction.Down => ZTransDownMask,
                    Direction.Left => ZTransLeftMask,
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
                },
                TetriminoKind.TeeShaped => direction switch
                {
                    Direction.Up => TeeUpMask,
                    Direction.Right => TeeRightMask,
                    Direction.Down => TeeDownMask,
                    Direction.Left => TeeLeftMask,
                    _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null),
                },
                _ => throw new ArgumentException(null, nameof(kind)),
            };
            return blockMask;
        }

        /// <summary>
        ///     Get a list of <see cref="Block" />s well positioned according to the offset.
        /// </summary>
        /// <returns>A <see cref="IReadOnlyList{Block}" /> which contains properly offset blocks</returns>
        public static IReadOnlyList<Block> CreateOffsetBlocks(TetriminoKind kind, Position offset,
            Direction direction = Direction.Up)
        {
            int[,] mask = CreateBlocksMask(kind, direction);

            List<Block> offsetBlocks = new(4);
            for (int nRow = 0; nRow < mask.GetLength(0); nRow++)
            {
                for (int nCol = 0; nCol < mask.GetLength(1); nCol++)
                {
                    int identifier = mask[nRow, nCol];
                    if (identifier != 0)
                    {
                        offsetBlocks.Add(new Block(kind, new Position(nCol + offset.X, nRow + offset.Y), 0, identifier));
                    }
                }
            }

            return offsetBlocks;
        }

        public static Position GetFirstBlockPositionByPosition(Position position, TetriminoKind kind,
            Direction facingDirection)
        {
            int firstBlockRow, firstBlockCol;

            (firstBlockRow, firstBlockCol) = GetFirstBlockPosFromMask(kind, facingDirection);

            return new Position(position.X + firstBlockCol, position.Y + firstBlockRow);
        }

        public static Position GetInitialPositionByKind(TetriminoKind kind)
        {
            int length = kind switch
            {
                TetriminoKind.Linear => 4,
                TetriminoKind.Cubic => 2,
                TetriminoKind.LShapedCis or TetriminoKind.LShapedTrans or TetriminoKind.ZigZagTrans or TetriminoKind.ZigZagCis or TetriminoKind.TeeShaped => 3,
                _ => throw new ArgumentException(null, nameof(kind)),
            };
            int row = 0;
            int column = (PeriotrisConst.PlayAreaWidth - length) / 2;
            return new Position(column, row);
        }

        public static Position GetPositionByFirstBlockPosition(Position firstBlockPosition, TetriminoKind kind,
                    Direction facingDirection)
        {
            int firstBlockRow, firstBlockCol;

            (firstBlockRow, firstBlockCol) = GetFirstBlockPosFromMask(kind, facingDirection);

            return new Position(firstBlockPosition.X - firstBlockCol, firstBlockPosition.Y - firstBlockRow);
        }

        /// <summary>
        ///     Fill new blocks with the proper <see cref="Block.AtomicNumber" /> according to
        ///     the <see cref="Block.Identifier" />.
        /// </summary>
        /// <param name="oldBlocks">The old blocks</param>
        /// <param name="newBlocks">The new blocks which will be filled with old atomic number</param>
        public static void MapAtomicNumberForNewBlocks(IReadOnlyList<Block> oldBlocks, IReadOnlyList<Block> newBlocks)
        {
            foreach (Block oldBlock in oldBlocks)
            {
                IEnumerable<Block> newBlockList =
                    from block in newBlocks
                    where block.Identifier == oldBlock.Identifier
                    select block;
                foreach (Block newBlock in newBlockList)
                {
                    newBlock.AtomicNumber = oldBlock.AtomicNumber;
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <remarks>May need updating when block pattern changes.</remarks>
        private static (int row, int col) GetFirstBlockPosFromMask(TetriminoKind kind, Direction facingDirection)
        {
            return kind switch
            {
                TetriminoKind.Linear => facingDirection switch
                {
                    Direction.Left => (2, 3),
                    Direction.Up => (3, 1),
                    Direction.Right => (1, 3),
                    Direction.Down => (3, 2),
                    _ => throw new ArgumentOutOfRangeException(nameof(facingDirection), facingDirection, null),
                },
                TetriminoKind.Cubic => (1, 1),
                TetriminoKind.LShapedCis => facingDirection switch
                {
                    Direction.Left => (1, 2),
                    Direction.Up => (2, 2),
                    Direction.Right => (2, 0),
                    Direction.Down => (2, 1),
                    _ => throw new ArgumentOutOfRangeException(nameof(facingDirection), facingDirection, null),
                },
                TetriminoKind.LShapedTrans => facingDirection switch
                {
                    Direction.Left => (2, 2),
                    Direction.Up => (2, 1),
                    Direction.Right => (1, 2),
                    Direction.Down => (2, 1),
                    _ => throw new ArgumentOutOfRangeException(nameof(facingDirection), facingDirection, null),
                },
                TetriminoKind.ZigZagCis => facingDirection switch
                {
                    Direction.Left => (2, 0),
                    Direction.Up => (1, 2),
                    Direction.Right => (2, 1),
                    Direction.Down => (2, 2),
                    _ => throw new ArgumentOutOfRangeException(nameof(facingDirection), facingDirection, null),
                },
                TetriminoKind.ZigZagTrans => facingDirection switch
                {
                    Direction.Left => (2, 1),
                    Direction.Up => (1, 1),
                    Direction.Right => (2, 2),
                    Direction.Down => (2, 1),
                    _ => throw new ArgumentOutOfRangeException(nameof(facingDirection), facingDirection, null),
                },
                TetriminoKind.TeeShaped => facingDirection switch
                {
                    Direction.Left => (2, 1),
                    Direction.Up => (1, 2),
                    Direction.Right => (2, 1),
                    Direction.Down => (2, 1),
                    _ => throw new ArgumentOutOfRangeException(nameof(facingDirection), facingDirection, null),
                },
                _ => throw new ArgumentException(null, nameof(kind)),
            };
        }
    }
}