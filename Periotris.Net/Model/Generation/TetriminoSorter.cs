using System;
using System.Collections.Generic;
using System.Linq;

namespace Periotris.Net.Model.Generation
{
    /// <summary>
    ///     Topological sorting performer.
    /// </summary>
    internal static class TetriminoSorter
    {
        public static IReadOnlyList<Tetrimino> Sort(IReadOnlyList<Tetrimino> tetriminos,
            int playAreaWidth, int playAreaHeight)
        {
            IReadOnlyList<TetriminoNode> graph = DependencyBuilder.GetTetriminoDependencyGraph(
                tetriminos, playAreaWidth, playAreaHeight);

            List<TetriminoNode> startNodes = new(
                from node in graph
                where node.Depending.Count == 0
                select node
            );
            List<TetriminoNode> result = new();

            while (startNodes.Count != 0)
            {
                TetriminoNode n = startNodes[0];
                startNodes.Remove(n);
                result.Add(n);
                List<TetriminoNode> dependedBy = n.DependedBy.ToList();
                foreach (TetriminoNode m in dependedBy)
                {
                    n.DependedBy.Remove(m);
                    m.Depending.Remove(n);
                    if (m.Depending.Count == 0)
                    {
                        startNodes.Add(m);
                    }
                }
            }

            if (graph.Any(node => node.DependedBy.Count != 0 || node.Depending.Count != 0))
            {
                throw new ArgumentException(null, nameof(tetriminos));
            }

            return result;
        }
    }
}