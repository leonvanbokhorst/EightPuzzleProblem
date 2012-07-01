using System.Collections.Generic;

namespace EightPuzzleGame.SuccessorNodes
{
    public interface ISuccessorNodesGenerator
    {
        IEnumerable<INode> Execute(INode node);
    }
}