using System.Collections.Generic;
using System.Linq;
using EightPuzzleGame.Calculators;
using EightPuzzleGame.SuccessorNodes;

namespace EightPuzzleGame
{
    public class PathFinder
    {
        private readonly ISuccessorNodesGenerator _successorNodesGenerator;
        private readonly IGValueCalculator _gValueCalculator;
        private readonly IHValueCalculator _hValueCalculator;

        public PathFinder(ISuccessorNodesGenerator successorNodesGenerator,
                          IGValueCalculator gValueCalculator,
                          IHValueCalculator hValueCalculator)
        {
            _successorNodesGenerator = successorNodesGenerator;
            _gValueCalculator = gValueCalculator;
            _hValueCalculator = hValueCalculator;
        }

        public int Cycles { get; private set; }

        public INode Execute(INode startNode, INode goalNode)
        {
            Cycles = 0;

            var openList = new List<INode> {startNode};
            var closedList = new List<INode>();

            while (openList.Count > 0)
            {
                Cycles++;
                INode currentNode = GetBestNodeFromOpenList(openList);

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                IEnumerable<INode> successorNodes =
                    _successorNodesGenerator.Execute(currentNode);

                foreach (INode successorNode in successorNodes)
                {
                    if (successorNode.HasEqualState(goalNode))
                        return successorNode;

                    successorNode.G = _gValueCalculator.Execute(currentNode);
                    successorNode.H = _hValueCalculator.Execute(goalNode, successorNode);
                    successorNode.F = successorNode.G + successorNode.H;

                    if (OpenListHasBetterNode(successorNode, openList))
                        continue;

                    openList.Add(successorNode);
                }
            }

            return null;
        }

        private static INode GetBestNodeFromOpenList(IEnumerable<INode> openList)
        {
            return openList.OrderBy(n => n.F).First();
        }

        private static bool OpenListHasBetterNode(INode successor, IEnumerable<INode> list)
        {
            return list.FirstOrDefault(n => n.G.Equals(successor.G) 
                    && n.F < successor.F) != null;
        }
    }
}