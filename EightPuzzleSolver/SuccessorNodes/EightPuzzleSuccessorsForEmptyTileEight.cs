using System.Collections.Generic;

namespace EightPuzzleGame.SuccessorNodes
{
    public class EightPuzzleSuccessorsForEmptyTileEight : EightPuzzleSuccessorNodesCalculationRuleBase
    {
        public override IEnumerable<INode> GetSuccessors(INode node)
        {
            var result = new List<INode>();

            AddSuccessor((EightPuzzleNode) node, result, 5);
            AddSuccessor((EightPuzzleNode) node, result, 7);

            return result;
        }

        public override bool Match(INode node)
        {
            return ((EightPuzzleNode) node).EmptyTileIndex == 8;
        }
    }
}