using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EightPuzzleGame;
using EightPuzzleGame.Calculators;
using EightPuzzleGame.SuccessorNodes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EightPuzzleSolverTests.Model
{
    [TestClass]
    public class EightPuzzleTests
    {
        private static readonly EightPuzzleNode Goal =
            new EightPuzzleNode {Tiles = new[] {1, 2, 3, 4, 5, 6, 7, 8, 0}};

        private PathFinder _pathFinder;

        [TestInitialize]
        public void Init() 
        {
            _pathFinder = new PathFinder(
                new EightPuzzleSuccessorNodesGenerator(),
                new EightPuzzleGValueCalculator(),
                new EightPuzzleManhattanDistanceCalulator());
        }

        [TestMethod]
        public void GivenSimpleState_ShouldFindSolution()
        {
            // arrange
            var start = new EightPuzzleNode {Tiles = new[] {4, 1, 3, 0, 2, 6, 7, 5, 8}};

            // act
            INode result = _pathFinder.Execute(start, Goal);

            // assert
            PrintSolution(_pathFinder, result);

            Assert.IsTrue(Goal.HasEqualState(result));
        }

        [TestMethod]
        public void GivenMediumState_ShouldFindSolution()
        {
            // arrange
            var start = new EightPuzzleNode {Tiles = new[] {3, 0, 5, 7, 8, 6, 1, 2, 4}};

            // act
            INode result = _pathFinder.Execute(start, Goal);

            // assert
            PrintSolution(_pathFinder, result);

            Assert.IsTrue(Goal.HasEqualState(result));
        }

        [TestMethod]
        public void GivenHardestState_ShouldFindSolution()
        {
            // arrange
            var start = new EightPuzzleNode {Tiles = new[] {8, 6, 7, 2, 5, 4, 3, 0, 1}};

            // act
            INode result = _pathFinder.Execute(start, Goal);

            // assert
            PrintSolution(_pathFinder, result);

            Assert.IsTrue(Goal.HasEqualState(result));
        }

        private static void PrintSolution(PathFinder pathFinder, INode result)
        {
            int steps = 0;
            INode node = result;

            if (node != null)
            {
                var stack = new Stack<INode>();

                do
                {
                    stack.Push(node);
                } while ((node = node.Parent) != null);

                Debug.WriteLine("8-Puzzle Solved in {0} Cycles", pathFinder.Cycles);
                Debug.WriteLine("-------------------------------------------");

                foreach (EightPuzzleNode solutionNode in stack)
                {
                    string tiles = solutionNode.Tiles
                        .Aggregate("", (current, i) => current + i.ToString());

                    Debug.WriteLine("{0:00} - {1} -  F: {2:00.0}  G: {3:00.0}  H: {4:00.0}",
                                    steps++,
                                    tiles,
                                    solutionNode.F, solutionNode.G, solutionNode.H);
                }
            }
            else
            {
                Debug.WriteLine("No solution");
            }
        }
    }
}