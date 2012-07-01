using System.Linq;

namespace EightPuzzleGame
{
    public class EightPuzzleNode : INode
    {
        private int _emptyTileIndex;

        public EightPuzzleNode()
        {
            _emptyTileIndex = -1;
        }

        public int[] Tiles { get; set; }

        public int EmptyTileIndex
        {
            get
            {
                if (_emptyTileIndex == -1)
                    _emptyTileIndex = GetEmptyTilePosition(this);

                return _emptyTileIndex;
            }
        }

        #region INode Members

        public float F { get; set; }
        public float G { get; set; }
        public float H { get; set; }

        public INode Parent { get; set; }

        public bool HasEqualState(INode node)
        {
            var testNode = node as EightPuzzleNode;

            return testNode != null && Tiles.SequenceEqual(testNode.Tiles);
        }

        #endregion

        private static int GetEmptyTilePosition(EightPuzzleNode node)
        {
            int emptyTilePos = -1;

            for (int i = 0; i < 9; i++)
            {
                if (node.Tiles[i] == 0)
                {
                    emptyTilePos = i;
                    break;
                }
            }

            return emptyTilePos;
        }
    }
}