using Algorithms.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag17 : Problem
{
    private const string testinput = @"2413432311323
3215453535623
3255245654254
3446585845452
4546657867536
1438598798454
4457876987766
3637877979653
4654967986887
4564679986453
1224686865563
2546548887735
4322674655533";

    public override async Task ExecuteAsync()
    {
        var grid = Grid<int>.FromInput(Input, c => int.Parse(c.ToString()));
        int maxX = grid.MaxX;
        int maxY = grid.MaxY;
        HashSet<Node> visitedNodes = new HashSet<Node>();
        var currentNodes = new Dictionary<long, IList<Node>>();
        currentNodes[0] = new List<Node>
        {
            new Node(0, maxY, GridDirection.East, 1),
            new Node(0, maxY, GridDirection.South, 1)
        };
        int currentCost = 0;
        while (true)
        {

            if (!currentNodes.TryGetValue(currentCost, out var nodesAtCost))
            {
                currentCost++;
                continue;
            }

            foreach (var node in nodesAtCost)
            {
                if ((node.X, node.Y) == (maxX, 0))
                {
                    Result = currentCost.ToString();
                    return;
                }

                if (visitedNodes.Contains(node))
                {
                    continue;
                }

                visitedNodes.Add(node);

                foreach (var next in NextNodes())
                {
                    if (next.X >= 0 && next.X <= maxX && next.Y >= 0 && next.Y <= maxY)
                    {
                        if (!visitedNodes.Contains(next))
                        {
                            var cost = grid[next.X, next.Y];
                            if (!currentNodes.ContainsKey(currentCost + cost))
                            {
                                currentNodes[currentCost + cost] = new List<Node>();
                            }

                            currentNodes[currentCost + cost].Add(next);
                        }
                    }
                }



                IEnumerable<Node> NextNodes()
                {
                    if (node.StepsSinceTurn >= 4)
                    {
                        Node next = node.Direction switch
                        {
                            GridDirection.North => new Node(node.X + 1, node.Y, GridDirection.East, 1),
                            GridDirection.East => new Node(node.X, node.Y - 1, GridDirection.South, 1),
                            GridDirection.South => new Node(node.X - 1, node.Y, GridDirection.West, 1),
                            GridDirection.West => new Node(node.X, node.Y + 1, GridDirection.North, 1),
                        };
                        if (next.X >= 0 && next.X <= maxX && next.Y >= 0 && next.Y <= maxY)
                        {
                            if (!visitedNodes.Contains(next))
                            {
                                yield return next;
                            }
                        }

                        next = node.Direction switch
                        {
                            GridDirection.North => new Node(node.X - 1, node.Y, GridDirection.West, 1),
                            GridDirection.East => new Node(node.X, node.Y + 1, GridDirection.North, 1),
                            GridDirection.South => new Node(node.X + 1, node.Y, GridDirection.East, 1),
                            GridDirection.West => new Node(node.X, node.Y - 1, GridDirection.South, 1),
                        };

                        yield return next;
                    }

                    if (node.StepsSinceTurn < 10)
                    {
                        Node next = node.Direction switch
                        {
                            GridDirection.North => new Node(node.X, node.Y + 1, GridDirection.North,
                                node.StepsSinceTurn + 1),
                            GridDirection.East => new Node(node.X + 1, node.Y, GridDirection.East,
                                node.StepsSinceTurn + 1),
                            GridDirection.South => new Node(node.X, node.Y - 1, GridDirection.South,
                                node.StepsSinceTurn + 1),
                            GridDirection.West => new Node(node.X - 1, node.Y, GridDirection.West,
                                node.StepsSinceTurn + 1),
                        };

                        yield return next;
                    }
                }
            }

            currentCost++;
        }
    }

    record Node(int X, int Y, GridDirection Direction, int StepsSinceTurn);

    public override int Nummer => 202317;
}