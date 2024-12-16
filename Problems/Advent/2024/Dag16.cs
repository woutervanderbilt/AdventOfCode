using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag16 : Problem
{
    public override async Task ExecuteAsync()
    {
        var grid = Grid<char>.FromInput(Input, c => c);
        var start = grid.AllGridMembers().Single(m => m.Value == 'S');
        var target = grid.AllGridMembers().Single(m => m.Value == 'E');
        grid[start.X, start.Y] = '.';
        grid[target.X, target.Y] = '.';
        IDictionary<(int, int, GridDirection), long> costs = new Dictionary<(int, int, GridDirection), long>();
        IDictionary<(int, int, GridDirection), HashSet<(int, int, GridDirection)>> comingFrom =
            new Dictionary<(int, int, GridDirection), HashSet<(int, int, GridDirection)>>();
        costs[(start.X, start.Y, GridDirection.East)] = 0;
        IList<(int x, int y, GridDirection direction)> lastVisited = [(start.X, start.Y, GridDirection.East)];
        long min = long.MaxValue;
        HashSet<GridDirection> directions = [];
        while (lastVisited.Any())
        {
            var newLastVisited = new List<(int, int, GridDirection)>();
            foreach (var location in lastVisited)
            {
                if (location.x == target.X && location.y == target.Y)
                {
                    if (costs[location] <= min)
                    {
                        if (costs[location] < min)
                        {
                            min = costs[location];
                            directions = [location.direction];
                        }
                        else
                        {
                            directions.Add(location.direction);
                        }
                    }
                }
                var currentCost = costs[location];
                var move = grid.MoveInDirection((location.x, location.y), location.direction);
                if (move.Value == '.' && (!costs.TryGetValue((move.X, move.Y, location.direction), out var oldCost) || oldCost >= currentCost + 1))
                {
                    costs[(move.X, move.Y, location.direction)] = currentCost + 1;
                    newLastVisited.Add((move.X, move.Y, location.direction));
                    if (oldCost > currentCost + 1)
                    {
                        comingFrom[(move.X, move.Y, location.direction)] = [location];
                    }
                    else
                    {
                        comingFrom.AddToList((move.X, move.Y, location.direction), location);
                    }
                }

                if (!costs.TryGetValue((location.x, location.y, location.direction.TurnRight()), out var rightCost) ||
                    rightCost >= currentCost + 1000)
                {
                    costs[(location.x, location.y, location.direction.TurnRight())] = currentCost + 1000;
                    newLastVisited.Add((location.x, location.y, location.direction.TurnRight()));
                    if (rightCost > currentCost + 1000)
                    {
                        comingFrom[(location.x, location.y, location.direction.TurnRight())] = [location];
                    }
                    else
                    {
                        comingFrom.AddToList((location.x, location.y, location.direction.TurnRight()), location);
                    }
                }

                if (!costs.TryGetValue((location.x, location.y, location.direction.TurnLeft()), out var leftCost) ||
                    leftCost >= currentCost + 1000)
                {
                    costs[(location.x, location.y, location.direction.TurnLeft())] = currentCost + 1000;
                    newLastVisited.Add((location.x, location.y, location.direction.TurnLeft()));
                    if (leftCost > currentCost + 1000)
                    {
                        comingFrom[(location.x, location.y, location.direction.TurnLeft())] = [location];
                    }
                    else
                    {
                        comingFrom.AddToList((location.x, location.y, location.direction.TurnLeft()), location);
                    }
                }
            }

            lastVisited = newLastVisited;
        }

        HashSet<(int x, int y)> goodSeats = [];
        HashSet<(int x, int y, GridDirection direction)> paths =
            new HashSet<(int x, int y, GridDirection direction)>(directions.Select(d => (target.X, target.Y, d)));
        while (paths.Any())
        {
            var newPaths = new HashSet<(int x, int y, GridDirection direction)>();
            foreach (var path in paths)
            {
                goodSeats.Add((path.x, path.y));
                if (comingFrom.TryGetValue((path.x, path.y, path.direction), out var from))
                {
                    foreach (var f in from)
                    {
                        newPaths.Add(f);
                    }
                }
            }

            paths = newPaths;
        }

        Result = (min, goodSeats.Count).ToString();
    }

    protected override bool UseTestInput => false;

    protected override string TestInput => @"#################
#...#...#...#..E#
#.#.#.#.#.#.#.#.#
#.#.#.#...#...#.#
#.#.#.#.###.#.#.#
#...#.#.#.....#.#
#.#.#.#.#.#####.#
#.#...#.#.#.....#
#.#.#####.#.###.#
#.#.#.......#...#
#.#.###.#####.###
#.#.#...#.....#.#
#.#.#.#####.###.#
#.#.#.........#.#
#.#.#.#########.#
#S#.............#
#################";


    public override int Nummer => 202416;
}