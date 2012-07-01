namespace EightPuzzleGame
{
    public interface INode
    {
        float F { get; set; } // total of G + H
        float G { get; set; } // Cost of the path until now
        float H { get; set; } // Heurstic - estimated costs to goalnode
        INode Parent { get; set; }

        bool HasEqualState(INode node);
    }
}