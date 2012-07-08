using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EightPuzzleGame;
using EightPuzzleGame.Calculators;
using EightPuzzleGame.SuccessorNodes;

namespace EightPuzzleConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                var goal = new EightPuzzleNode { Tiles = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 } };
                var start = new EightPuzzleNode { Tiles = new int[9] };

                Console.WriteLine("Enter a valid start state (e.g. 867254301");
                string userinput = Console.ReadLine();


                if (userinput != null)
                {
                    int i = 0;

                    foreach (char s in userinput)
                    {
                        int tile;


                        if (!int.TryParse(s.ToString(), out tile)) continue;

                        start.Tiles[i++] = tile; 
                    }

                    var pathFinder = new PathFinder(
                        new EightPuzzleSuccessorNodesGenerator(),
                        new EightPuzzleGValueCalculator(),
                        new EightPuzzleManhattanDistanceCalulator());

                    INode result = pathFinder.Execute(start, goal);
                    PrintSolution(result);

                    Console.ReadKey();
                }
            } while (Console.ReadLine() != "exit");
        }

        private static void PrintSolution(INode node)
        {

            if (node != null)
            {
                var stack = new Stack<INode>();

                do
                {
                    stack.Push(node);
                } while ((node = node.Parent) != null);

                var step = 0;

                foreach (EightPuzzleNode solutionNode in stack)
                {
                    Console.Clear();

                    Console.WriteLine("");

                    string tiles = solutionNode.Tiles
                        .Aggregate("", (current, i) => current + i.ToString());

                    for (int i = 0; i < 9; i++)
                    {
                        Console.WriteLine("  {0} {1} {2}",
                            tiles[i] == '0' ? '_' : tiles[i],
                            tiles[i + 1] == '0' ? '_' : tiles[i + 1],
                            tiles[i + 2] == '0' ? '_' : tiles[i + 2]);
                        i = i + 2;
                    }

                    Thread.Sleep(500);
                    step++;
                }

                Console.WriteLine("");
                Console.WriteLine("{0} steps", step);
            }
            else
            {
                Console.WriteLine("No solution");
            }

        }
    }
}