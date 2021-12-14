using System;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2017
{
    internal class Dag22 : Problem
    {
        private const string input = @".#...#.#.##..##....##.#.#
###.###..##...##.##....##
....#.###..#...#####..#.#
.##.######..###.##..#...#
#..#..#..##..###...#..###
..####...#.##.#.#.##.####
#......#..####..###..###.
#####.##.#.#.##.###.#.#.#
.#.###....###....##....##
.......########.#.#...#..
...###.####.##..###.##..#
#.#.###.####.###.###.###.
.######...###.....#......
....##.###..#.#.###...##.
#.###..###.#.#.##.#.##.##
#.#.#..###...###.###.....
##..##.##...##.##..##.#.#
.....##......##..#.##...#
..##.#.###.#...#####.#.##
....##..#.#.#.#..###.#..#
###..##.##....##.#....##.
#..####...####.#.##..#.##
####.###...####..##.#.#.#
#.#.#.###.....###.##.###.
.#...##.#.##..###.#.###..";

        private const string testinput = @"..#
#..
...";

        public override Task ExecuteAsync()
        {
            var grid = new Grid<char>();
            int y = 0;
            foreach (var line in input.Split(Environment.NewLine))
            {
                int x = 0;
                foreach (var c in line)
                {
                    grid[x, y] = c;
                    x++;
                }

                y--;
            }

            (int x, int y) currentNode = ((grid.MinX + grid.MaxX) / 2, (grid.MinY + grid.MaxY) / 2);
            int count = 0;
            var direction = GridDirection.North;
            for (int i = 0; i < 10000000; i++)
            {
                //grid.Print();
                //Console.WriteLine(currentNode);
                var infected = grid[currentNode.x, currentNode.y];
                if (!infected.Found)
                {
                    infected = new GridMember<char>('.', currentNode.x, currentNode.y);
                }

                grid[currentNode.x, currentNode.y] = infected.Value switch
                {
                    '.' => 'w',
                    'w' => '#',
                    '#' => 'f',
                    'f' => '.'
                };
                if (infected.Value == '.')
                {
                    direction = direction switch
                    {
                        GridDirection.East => GridDirection.North,
                        GridDirection.South => GridDirection.East,
                        GridDirection.West => GridDirection.South,
                        GridDirection.North => GridDirection.West,
                        _ => throw new Exception()
                    };
                }
                else if (infected.Value == '#')
                {
                    direction = direction switch
                    {
                        GridDirection.East => GridDirection.South,
                        GridDirection.South => GridDirection.West,
                        GridDirection.West => GridDirection.North,
                        GridDirection.North => GridDirection.East,
                        _ => throw new Exception()
                    };
                }
                else if (infected.Value == 'f')
                {
                    direction = direction switch
                    {
                        GridDirection.East => GridDirection.West,
                        GridDirection.South => GridDirection.North,
                        GridDirection.West => GridDirection.East,
                        GridDirection.North => GridDirection.South,
                        _ => throw new Exception()
                    };
                }
                else
                {
                    count++;
                }

                currentNode = grid.MoveInDirection(currentNode, direction).Location;
            }

            Result = count.ToString();
            return Task.CompletedTask;
        }

        public override int Nummer => 201722;
    }
}
