using Periotris.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Periotris.Net.Model.Generation
{
    internal static class GeneratorHelper
    {
        /// <summary>
        ///     Total available blocks in <see cref="GeneratorHelper.PeriodicTableTemplate" />.
        /// </summary>
        /// <remarks>
        ///     Update this if the whole pattern is changed.
        /// </remarks>
        public static readonly int TotalAvailableBlocks = 108;

        public static readonly Block[,] PeriodicTableTemplate =
        {
            {
                new Block(TetriminoKind.UnavailableToFill, new Position(0, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(1, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(2, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(3, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(4, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(5, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(6, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(7, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(8, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(9, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(10, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(11, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(12, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(13, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(14, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(15, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(16, 0)),
                new Block(TetriminoKind.UnavailableToFill, new Position(17, 0))
            },
            {
                new Block(TetriminoKind.UnavailableToFill, new Position(0, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(1, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(2, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(3, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(4, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(5, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(6, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(7, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(8, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(9, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(10, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(11, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(12, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(13, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(14, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(15, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(16, 1)),
                new Block(TetriminoKind.UnavailableToFill, new Position(17, 1))
            },
            {
                new Block(TetriminoKind.UnavailableToFill, new Position(0, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(1, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(2, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(3, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(4, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(5, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(6, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(7, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(8, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(9, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(10, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(11, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(12, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(13, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(14, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(15, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(16, 2)),
                new Block(TetriminoKind.UnavailableToFill, new Position(17, 2))
            },
            {
                new Block(TetriminoKind.AvailableToFill, new Position(0, 3), -1),
                new Block(TetriminoKind.UnavailableToFill, new Position(1, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(2, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(3, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(4, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(5, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(6, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(7, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(8, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(9, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(10, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(11, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(12, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(13, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(14, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(15, 3)),
                new Block(TetriminoKind.UnavailableToFill, new Position(16, 3)),
                new Block(TetriminoKind.AvailableToFill, new Position(17, 3), -18)
            },
            {
                new Block(TetriminoKind.AvailableToFill, new Position(0, 4), 1),
                new Block(TetriminoKind.AvailableToFill, new Position(1, 4), -2),
                new Block(TetriminoKind.UnavailableToFill, new Position(2, 4)),
                new Block(TetriminoKind.UnavailableToFill, new Position(3, 4)),
                new Block(TetriminoKind.UnavailableToFill, new Position(4, 4)),
                new Block(TetriminoKind.UnavailableToFill, new Position(5, 4)),
                new Block(TetriminoKind.UnavailableToFill, new Position(6, 4)),
                new Block(TetriminoKind.UnavailableToFill, new Position(7, 4)),
                new Block(TetriminoKind.UnavailableToFill, new Position(8, 4)),
                new Block(TetriminoKind.UnavailableToFill, new Position(9, 4)),
                new Block(TetriminoKind.UnavailableToFill, new Position(10, 4)),
                new Block(TetriminoKind.UnavailableToFill, new Position(11, 4)),
                new Block(TetriminoKind.AvailableToFill, new Position(12, 4), -13),
                new Block(TetriminoKind.AvailableToFill, new Position(13, 4), -14),
                new Block(TetriminoKind.AvailableToFill, new Position(14, 4), -15),
                new Block(TetriminoKind.AvailableToFill, new Position(15, 4), -16),
                new Block(TetriminoKind.AvailableToFill, new Position(16, 4), -17),
                new Block(TetriminoKind.AvailableToFill, new Position(17, 4), 2)
            },
            {
                new Block(TetriminoKind.AvailableToFill, new Position(0, 5), 3),
                new Block(TetriminoKind.AvailableToFill, new Position(1, 5), 4),
                new Block(TetriminoKind.UnavailableToFill, new Position(2, 5)),
                new Block(TetriminoKind.UnavailableToFill, new Position(3, 5)),
                new Block(TetriminoKind.UnavailableToFill, new Position(4, 5)),
                new Block(TetriminoKind.UnavailableToFill, new Position(5, 5)),
                new Block(TetriminoKind.UnavailableToFill, new Position(6, 5)),
                new Block(TetriminoKind.UnavailableToFill, new Position(7, 5)),
                new Block(TetriminoKind.UnavailableToFill, new Position(8, 5)),
                new Block(TetriminoKind.UnavailableToFill, new Position(9, 5)),
                new Block(TetriminoKind.UnavailableToFill, new Position(10, 5)),
                new Block(TetriminoKind.UnavailableToFill, new Position(11, 5)),
                new Block(TetriminoKind.AvailableToFill, new Position(12, 5), 5),
                new Block(TetriminoKind.AvailableToFill, new Position(13, 5), 6),
                new Block(TetriminoKind.AvailableToFill, new Position(14, 5), 7),
                new Block(TetriminoKind.AvailableToFill, new Position(15, 5), 8),
                new Block(TetriminoKind.AvailableToFill, new Position(16, 5), 9),
                new Block(TetriminoKind.AvailableToFill, new Position(17, 5), 10)
            },
            {
                new Block(TetriminoKind.AvailableToFill, new Position(0, 6), 11),
                new Block(TetriminoKind.AvailableToFill, new Position(1, 6), 12),
                new Block(TetriminoKind.AvailableToFill, new Position(2, 6), -3),
                new Block(TetriminoKind.AvailableToFill, new Position(3, 6), -4),
                new Block(TetriminoKind.AvailableToFill, new Position(4, 6), -5),
                new Block(TetriminoKind.AvailableToFill, new Position(5, 6), -6),
                new Block(TetriminoKind.AvailableToFill, new Position(6, 6), -7),
                new Block(TetriminoKind.AvailableToFill, new Position(7, 6), -8),
                new Block(TetriminoKind.AvailableToFill, new Position(8, 6), -9),
                new Block(TetriminoKind.AvailableToFill, new Position(9, 6), -10),
                new Block(TetriminoKind.AvailableToFill, new Position(10, 6), -11),
                new Block(TetriminoKind.AvailableToFill, new Position(11, 6), -12),
                new Block(TetriminoKind.AvailableToFill, new Position(12, 6), 13),
                new Block(TetriminoKind.AvailableToFill, new Position(13, 6), 14),
                new Block(TetriminoKind.AvailableToFill, new Position(14, 6), 15),
                new Block(TetriminoKind.AvailableToFill, new Position(15, 6), 16),
                new Block(TetriminoKind.AvailableToFill, new Position(16, 6), 17),
                new Block(TetriminoKind.AvailableToFill, new Position(17, 6), 18)
            },
            {
                new Block(TetriminoKind.AvailableToFill, new Position(0, 7), 19),
                new Block(TetriminoKind.AvailableToFill, new Position(1, 7), 20),
                new Block(TetriminoKind.AvailableToFill, new Position(2, 7), 21),
                new Block(TetriminoKind.AvailableToFill, new Position(3, 7), 22),
                new Block(TetriminoKind.AvailableToFill, new Position(4, 7), 23),
                new Block(TetriminoKind.AvailableToFill, new Position(5, 7), 24),
                new Block(TetriminoKind.AvailableToFill, new Position(6, 7), 25),
                new Block(TetriminoKind.AvailableToFill, new Position(7, 7), 26),
                new Block(TetriminoKind.AvailableToFill, new Position(8, 7), 27),
                new Block(TetriminoKind.AvailableToFill, new Position(9, 7), 28),
                new Block(TetriminoKind.AvailableToFill, new Position(10, 7), 29),
                new Block(TetriminoKind.AvailableToFill, new Position(11, 7), 30),
                new Block(TetriminoKind.AvailableToFill, new Position(12, 7), 31),
                new Block(TetriminoKind.AvailableToFill, new Position(13, 7), 32),
                new Block(TetriminoKind.AvailableToFill, new Position(14, 7), 33),
                new Block(TetriminoKind.AvailableToFill, new Position(15, 7), 34),
                new Block(TetriminoKind.AvailableToFill, new Position(16, 7), 35),
                new Block(TetriminoKind.AvailableToFill, new Position(17, 7), 36)
            },
            {
                new Block(TetriminoKind.AvailableToFill, new Position(0, 8), 37),
                new Block(TetriminoKind.AvailableToFill, new Position(1, 8), 38),
                new Block(TetriminoKind.AvailableToFill, new Position(2, 8), 39),
                new Block(TetriminoKind.AvailableToFill, new Position(3, 8), 40),
                new Block(TetriminoKind.AvailableToFill, new Position(4, 8), 41),
                new Block(TetriminoKind.AvailableToFill, new Position(5, 8), 42),
                new Block(TetriminoKind.AvailableToFill, new Position(6, 8), 43),
                new Block(TetriminoKind.AvailableToFill, new Position(7, 8), 44),
                new Block(TetriminoKind.AvailableToFill, new Position(8, 8), 45),
                new Block(TetriminoKind.AvailableToFill, new Position(9, 8), 46),
                new Block(TetriminoKind.AvailableToFill, new Position(10, 8), 47),
                new Block(TetriminoKind.AvailableToFill, new Position(11, 8), 48),
                new Block(TetriminoKind.AvailableToFill, new Position(12, 8), 49),
                new Block(TetriminoKind.AvailableToFill, new Position(13, 8), 50),
                new Block(TetriminoKind.AvailableToFill, new Position(14, 8), 51),
                new Block(TetriminoKind.AvailableToFill, new Position(15, 8), 52),
                new Block(TetriminoKind.AvailableToFill, new Position(16, 8), 53),
                new Block(TetriminoKind.AvailableToFill, new Position(17, 8), 54)
            },
            {
                new Block(TetriminoKind.AvailableToFill, new Position(0, 9), 55),
                new Block(TetriminoKind.AvailableToFill, new Position(1, 9), 56),
                new Block(TetriminoKind.AvailableToFill, new Position(2, 9), 57),
                new Block(TetriminoKind.AvailableToFill, new Position(3, 9), 72),
                new Block(TetriminoKind.AvailableToFill, new Position(4, 9), 73),
                new Block(TetriminoKind.AvailableToFill, new Position(5, 9), 74),
                new Block(TetriminoKind.AvailableToFill, new Position(6, 9), 75),
                new Block(TetriminoKind.AvailableToFill, new Position(7, 9), 76),
                new Block(TetriminoKind.AvailableToFill, new Position(8, 9), 77),
                new Block(TetriminoKind.AvailableToFill, new Position(9, 9), 78),
                new Block(TetriminoKind.AvailableToFill, new Position(10, 9), 79),
                new Block(TetriminoKind.AvailableToFill, new Position(11, 9), 80),
                new Block(TetriminoKind.AvailableToFill, new Position(12, 9), 81),
                new Block(TetriminoKind.AvailableToFill, new Position(13, 9), 82),
                new Block(TetriminoKind.AvailableToFill, new Position(14, 9), 83),
                new Block(TetriminoKind.AvailableToFill, new Position(15, 9), 84),
                new Block(TetriminoKind.AvailableToFill, new Position(16, 9), 85),
                new Block(TetriminoKind.AvailableToFill, new Position(17, 9), 86)
            },
            {
                new Block(TetriminoKind.AvailableToFill, new Position(0, 10), 87),
                new Block(TetriminoKind.AvailableToFill, new Position(1, 10), 88),
                new Block(TetriminoKind.AvailableToFill, new Position(2, 10), 89),
                new Block(TetriminoKind.AvailableToFill, new Position(3, 10), 104),
                new Block(TetriminoKind.AvailableToFill, new Position(4, 10), 105),
                new Block(TetriminoKind.AvailableToFill, new Position(5, 10), 106),
                new Block(TetriminoKind.AvailableToFill, new Position(6, 10), 107),
                new Block(TetriminoKind.AvailableToFill, new Position(7, 10), 108),
                new Block(TetriminoKind.AvailableToFill, new Position(8, 10), 109),
                new Block(TetriminoKind.AvailableToFill, new Position(9, 10), 110),
                new Block(TetriminoKind.AvailableToFill, new Position(10, 10), 111),
                new Block(TetriminoKind.AvailableToFill, new Position(11, 10), 112),
                new Block(TetriminoKind.AvailableToFill, new Position(12, 10), 113),
                new Block(TetriminoKind.AvailableToFill, new Position(13, 10), 114),
                new Block(TetriminoKind.AvailableToFill, new Position(14, 10), 115),
                new Block(TetriminoKind.AvailableToFill, new Position(15, 10), 116),
                new Block(TetriminoKind.AvailableToFill, new Position(16, 10), 117),
                new Block(TetriminoKind.AvailableToFill, new Position(17, 10), 118)
            }
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

        public static readonly int[,] LinearUpMask =
        {
            {0, 1, 0, 0},
            {0, 2, 0, 0},
            {0, 3, 0, 0},
            {0, 4, 0, 0}
        };

        public static readonly int[,] LinearRightMask =
        {
            {0, 0, 0, 0},
            {4, 3, 2, 1},
            {0, 0, 0, 0},
            {0, 0, 0, 0}
        };

        public static readonly int[,] LinearDownMask =
        {
            {0, 0, 4, 0},
            {0, 0, 3, 0},
            {0, 0, 2, 0},
            {0, 0, 1, 0}
        };

        public static readonly int[,] CubicMaskUp =
        {
            {1, 2},
            {4, 3}
        };

        public static readonly int[,] CubicMaskRight =
        {
            {4, 1},
            {3, 2}
        };

        public static readonly int[,] CubicMaskLeft =
        {
            {2, 3},
            {1, 4}
        };

        public static readonly int[,] CubicMaskDown =
        {
            {3, 4},
            {2, 1}
        };

        public static readonly int[,] LCisUpMask =
        {
            {0, 1, 0},
            {0, 2, 0},
            {0, 3, 4}
        };

        public static readonly int[,] LCisRightMask =
        {
            {0, 0, 0},
            {3, 2, 1},
            {4, 0, 0}
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

        public static readonly int[,] LTransUpMask =
        {
            {0, 1, 0},
            {0, 2, 0},
            {4, 3, 0}
        };

        public static readonly int[,] LTransRightMask =
        {
            {4, 0, 0},
            {3, 2, 1},
            {0, 0, 0}
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

        public static readonly int[,] ZCisUpMask =
        {
            {1, 2, 0},
            {0, 3, 4},
            {0, 0, 0}
        };

        public static readonly int[,] ZCisRightMask =
        {
            {0, 0, 1},
            {0, 3, 2},
            {0, 4, 0}
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

        public static readonly int[,] ZTransUpMask =
        {
            {0, 3, 4},
            {1, 2, 0},
            {0, 0, 0}
        };

        public static readonly int[,] ZTransRightMask =
        {
            {0, 1, 0},
            {0, 2, 3},
            {0, 0, 4}
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

        public static readonly int[,] TeeUpMask =
        {
            {0, 1, 0},
            {2, 3, 4},
            {0, 0, 0}
        };

        public static readonly int[,] TeeRightMask =
        {
            {0, 2, 0},
            {0, 3, 1},
            {0, 4, 0}
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

        public static Position GetInitialPositionByKind(TetriminoKind kind)
        {
            var length = kind switch
            {
                TetriminoKind.Linear => 4,
                TetriminoKind.Cubic => 2,
                TetriminoKind.LShapedCis or TetriminoKind.LShapedTrans or TetriminoKind.ZigZagTrans or TetriminoKind.ZigZagCis or TetriminoKind.TeeShaped => 3,
                _ => throw new ArgumentException(null, nameof(kind)),
            };
            int row = 0;
            int column = (TetrisConst.PlayAreaWidth - length) / 2;
            return new Position(column, row);
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

        public static Position GetPositionByFirstBlockPosition(Position firstBlockPosition, TetriminoKind kind,
            Direction facingDirection)
        {
            int firstBlockRow, firstBlockCol;

            (firstBlockRow, firstBlockCol) = GetFirstBlockPosFromMask(kind, facingDirection);

            return new Position(firstBlockPosition.X - firstBlockCol, firstBlockPosition.Y - firstBlockRow);
        }

        public static Position GetFirstBlockPositionByPosition(Position position, TetriminoKind kind,
            Direction facingDirection)
        {
            int firstBlockRow, firstBlockCol;

            (firstBlockRow, firstBlockCol) = GetFirstBlockPosFromMask(kind, facingDirection);

            return new Position(position.X + firstBlockCol, position.Y + firstBlockRow);
        }
    }
}