namespace EightPuzzleGame.Calculators
{
    public interface IHValueCalculator
    {
        float Execute(INode goalNode, INode node);
    }
}