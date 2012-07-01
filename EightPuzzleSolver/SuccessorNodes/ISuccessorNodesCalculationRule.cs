using System.Collections.Generic;

namespace EightPuzzleGame.SuccessorNodes
{
    public interface ISuccessorNodesCalculationRule
    {
        IEnumerable<INode> GetSuccessors(INode node);
        bool Match(INode node);
    }
}