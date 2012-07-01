using System.Collections.Generic;
using System.Linq;

namespace EightPuzzleGame.SuccessorNodes
{
    public class EightPuzzleSuccessorNodesCalculationRuleBase : ISuccessorNodesCalculationRule
    {
        #region ISuccessorNodesCalculationRule Members

        public virtual IEnumerable<INode> GetSuccessors(INode node)
        {
            return null;
        }

        public virtual bool Match(INode node)
        {
            return false;
        }

        #endregion

        protected static void AddSuccessor(EightPuzzleNode node,
                                           ICollection<INode> result,
                                           int swapTile)
        {
            var newState = node.Tiles.Clone() as int[];
            if (newState == null) return;
            newState[node.EmptyTileIndex] = newState[swapTile];
            newState[swapTile] = 0;

            if (!IsEqualToParentState(node.Parent, newState))
                result.Add(new EightPuzzleNode {Tiles = newState, Parent = node});
        }

        private static bool IsEqualToParentState(INode node, IEnumerable<int> state)
        {
            return node != null && state.SequenceEqual(((EightPuzzleNode) node).Tiles);
        }
    }
}