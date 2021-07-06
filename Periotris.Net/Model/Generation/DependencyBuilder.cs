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

using System.Collections.Generic;
using System.Linq;

namespace Periotris.Net.Model.Generation
{
    /// <summary>
    ///     Tetrimino-tetrimino dependency relationship builder.
    /// </summary>
    internal static class DependencyBuilder
    {
        public static IReadOnlyList<TetriminoNode> GetTetriminoDependencyGraph(IReadOnlyList<Tetrimino> tetriminos,
            int playAreaWidth, int playAreaHeight)
        {
            // Build block map
            List<TetriminoNode> tetriminoNodes = new(tetriminos.Count);
            MemoizedBlock[,] memoizedMap = new MemoizedBlock[playAreaHeight, playAreaWidth];
            foreach (Tetrimino tetrimino in tetriminos)
            {
                TetriminoNode tetriminoNode = new(tetrimino.Kind,
                    tetrimino.Position,
                    GeneratorHelper.GetFirstBlockPositionByPosition(tetrimino.Position, tetrimino.Kind,
                        tetrimino.FacingDirection),
                    tetrimino.FacingDirection
                );
                tetriminoNode.Blocks = tetriminoNode.MemoizedBlocks =
                    GetMemoizedBlocksForTetriminoNode(tetriminoNode, tetrimino);

                foreach (MemoizedBlock block in tetriminoNode.MemoizedBlocks)
                {
                    memoizedMap[block.Position.Y, block.Position.X] = block;
                }

                tetriminoNodes.Add(tetriminoNode);
            }

            // Get dependency relationship
            foreach (TetriminoNode tetriminoNode in tetriminoNodes)
            {
                foreach (MemoizedBlock block in tetriminoNode.MemoizedBlocks)
                {
                    // if a blocker under the current block is occupied then
                    // this tetrimino can not be placed until the underlying block's
                    // owner is placed, i.e., this tetrimino depends on the underlying
                    // block's owner.
                    int dependedBlockRow = block.Position.Y + 1;
                    int dependedBlockCol = block.Position.X;
                    if (!TryGetOccupiedTetriminoNode(
                        memoizedMap,
                        dependedBlockRow, dependedBlockCol,
                        playAreaWidth, playAreaHeight,
                        out TetriminoNode dependOn
                    ) || dependOn == tetriminoNode)
                    {
                        continue;
                    }

                    dependOn.DependedBy.Add(tetriminoNode);
                    tetriminoNode.Depending.Add(dependOn);
                }
            }

            return tetriminoNodes;
        }

        private static IReadOnlyList<MemoizedBlock> GetMemoizedBlocksForTetriminoNode(TetriminoNode node,
            Tetrimino tetrimino)
        {
            return tetrimino.Blocks.Select(
                block => new MemoizedBlock(block.FilledBy, block.Position, node, block.AtomicNumber, block.Identifier)
            ).ToList();
        }

        private static bool TryGetOccupiedTetriminoNode(MemoizedBlock[,] map,
            int row, int col,
            int playAreaWidth, int playAreaHeight,
            out TetriminoNode result)
        {
            if (row < 0 || row >= playAreaHeight || col < 0 || col >= playAreaWidth)
            {
                result = null;
                return false;
            }

            MemoizedBlock cell = map[row, col];
            if (cell == null
                || cell.FilledBy == TetriminoKind.AvailableToFill
                || cell.FilledBy == TetriminoKind.UnavailableToFill)
            {
                result = null;
                return false;
            }

            result = cell.Owner;
            return true;
        }
    }
}