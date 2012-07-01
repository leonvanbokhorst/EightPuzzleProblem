namespace EightPuzzleGame.Calculators
{
    public class EightPuzzleGValueCalculator : IGValueCalculator
    {
        private const float CostFactor = 0.265f; // trial and error based

        #region IGValueCalculator Members

        public float Execute(INode node)
        {
            return node.G + CostFactor;
        }

        #endregion
    }
}