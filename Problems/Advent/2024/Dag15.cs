using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag15 : Problem
{
    public override async Task ExecuteAsync()
    {
        var splitInput = Input.Split($"{Environment.NewLine}{Environment.NewLine}");
        var grid = Grid<char>.FromInput(splitInput[0], c => c);
        string instructions = splitInput[1].Replace(Environment.NewLine,"");
        var robot = grid.AllGridMembers().Single(m => m.Value == '@');
        foreach (var instruction in instructions)
        {
            var direction = instruction switch
            {
                '^' => GridDirection.North,
                'v' => GridDirection.South,
                '<' => GridDirection.West,
                '>' => GridDirection.East,
                _ => throw new InvalidOperationException()
            };
            int boxMoves = 0;
            var nextRobotLocation = grid.MoveInDirection(robot.Location, direction);
            var location = nextRobotLocation;
            while (location.Value == 'O')
            {
                location = grid.MoveInDirection(location.Location, direction);
                boxMoves++;
            }

            if (location.Value == '.')
            {
                grid[robot.X, robot.Y] = '.';
                grid[location.X, location.Y] = 'O';
                grid[nextRobotLocation.X, nextRobotLocation.Y] = '@';
                robot = nextRobotLocation;
            }
        }

        long result = grid.AllGridMembers().Where(m => m.Value == 'O').Sum(m => 100 *(grid.MaxY - m.Y) + m.X);


        var grid2 = Grid<char>.FromInput(string.Concat(splitInput[0].Select(MapChar)), c => c);
        string MapChar(char c) => c switch
        {
            '@' => "@.",
            'O' => "[]",
            '#' => "##",
            '.' => "..",
            _ => $"{c}"
        };

        robot = grid2.AllGridMembers().Single(m => m.Value == '@');
        foreach (var instruction in instructions)
        {
            //Console.SetCursorPosition(0, 0);
            //grid2.Print();

            var direction = instruction switch
            {
                '^' => GridDirection.North,
                'v' => GridDirection.South,
                '<' => GridDirection.West,
                '>' => GridDirection.East,
                _ => throw new InvalidOperationException()
            };
            int boxMoves = 0;
            var nextRobotLocation = grid2.MoveInDirection(robot.Location, direction);
            if (direction == GridDirection.West || direction == GridDirection.East)
            {
                var location = nextRobotLocation;
                while (location.Value == '[' || location.Value == ']')
                {
                    location = grid2.MoveInDirection(location.Location, direction);
                    boxMoves++;
                }

                if (location.Value == '.')
                {
                    grid2[robot.X, robot.Y] = '.';
                    location = nextRobotLocation;
                    while (location.Value == '[' || location.Value == ']')
                    {
                        var valueToFill = location.Value;
                        location = grid2.MoveInDirection(location.Location, direction);
                        grid2[location.X, location.Y] = valueToFill;
                        boxMoves++;
                    }

                    ;
                    grid2[nextRobotLocation.X, nextRobotLocation.Y] = '@';
                    robot = nextRobotLocation;
                }
            }
            else
            {
                if (nextRobotLocation.Value == '.')
                {
                    grid2[nextRobotLocation.X, nextRobotLocation.Y] = '@';
                    grid2[robot.X, robot.Y] = '.';
                    robot = nextRobotLocation;
                }
                else if (nextRobotLocation.Value != '#')
                {
                    IList<GridMember<char>> movingLocations = [nextRobotLocation];
                    IList<GridMember<char>> lastMovingLocations = [nextRobotLocation];
                    if (nextRobotLocation.Value == '[')
                    {
                        var east = grid2.MoveInDirection(nextRobotLocation.Location, GridDirection.East);
                        movingLocations.Add(east);
                        lastMovingLocations.Add(east);
                    }
                    else if(nextRobotLocation.Value == ']')
                    {
                        var west = grid2.MoveInDirection(nextRobotLocation.Location, GridDirection.West);
                        movingLocations.Add(west);
                        lastMovingLocations.Add(west);
                    }
                    bool stop = false;
                    while (lastMovingLocations.Any())
                    {
                        stop = false;   
                        IList<GridMember<char>> newLastMovingLocations = [];
                        foreach (var location in lastMovingLocations)
                        {
                            var next = grid2.MoveInDirection(location.Location, direction);
                            if (next.Value == '#')
                            {
                                newLastMovingLocations = [];
                                stop = true;
                                break;
                            }

                            if (next.Value == '[')
                            {
                                newLastMovingLocations.Add(next);
                                newLastMovingLocations.Add(grid2.MoveInDirection(next.Location, GridDirection.East));
                            }

                            if (next.Value == ']')
                            {
                                newLastMovingLocations.Add(next);
                                newLastMovingLocations.Add(grid2.MoveInDirection(next.Location, GridDirection.West));
                            }
                        }

                        if (stop)
                        {
                            break;
                        }

                        foreach (var movingLocation in newLastMovingLocations)
                        {
                            if (!movingLocations.Any(m => m.Location == movingLocation.Location))
                            {
                                movingLocations.Add(movingLocation);
                            }
                        }
                        lastMovingLocations = newLastMovingLocations;
                    }

                    if (!stop)
                    {
                        grid2[robot.X, robot.Y] = '.';
                        foreach (var location in movingLocations.Reverse())
                        {
                            grid2[location.X, location.Y] = '.';
                            var target = grid2.MoveInDirection(location.Location, direction);
                            grid2[target.X, target.Y] = location.Value;
                        }

                        grid2[nextRobotLocation.X, nextRobotLocation.Y] = '@';
                        robot = nextRobotLocation;
                    }
                }
            }
        }

        long result2 = grid2.AllGridMembers().Where(m => m.Value == '[').Sum(m => 100 * (grid2.MaxY - m.Y) + m.X);
        Result = (result, result2).ToString();
    }

    protected override bool UseTestInput => false;

    protected override string TestInput => @"##########
#..O..O.O#
#......O.#
#.OO..O.O#
#..O@..O.#
#O#..O...#
#O..O..O.#
#.OO.O.OO#
#....O...#
##########

<vv>^<v^>v>^vv^v>v<>v^v<v<^vv<<<^><<><>>v<vvv<>^v^>^<<<><<v<<<v^vv^v>^
vvv<<^>^v^^><<>>><>^<<><^vv^^<>vvv<>><^^v>^>vv<>v<<<<v<^v>^<^^>>>^<v<v
><>vv>v^v^<>><>>>><^^>vv>v<^^^>>v^v^<^^>v^^>v^<^v>v<>>v^v^<v>v^^<^^vv<
<<v<^>>^^^^>>>v^<>vvv^><v<<<>^^^vv^<vvv>^>v<^^^^v<>^>vvvv><>>v^<<^^^^^
^><^><>>><>^^<<^^v>>><^<v>^<vv>>v>>>^v><>^v><<<<v>>v<v<v>vvv>^<><<>^><
^>><>^v<><^vvv<^^<><v<<<<<><^v<<<><<<^^<v<^^^><^>>^<v^><<<^>>^v<v^v<v^
>^>>^v>vv>^<<^v<>><<><<v<<v><>v<^vv<<<>^^v^>^^>>><<^v>>v^v><^^>>^<>vv^
<><^^>^^^<><vvvvv^v<v<<>^v<v>v<<^><<><<><<<^^<<<^<<>><<><^^^>^^<>^>v<>
^^>vv<^v^v<vv>^<><v<^v>^^^>>>^^vvv^>vvv<>>>^<^>>>>>^<<^v>^vvv<>^<><<v>
v^^>>><<^^<>>^v^<v^vv<>v^<<>^<^v^v><^<<<><<^<v><v<>vv>>v><v^<vv<>v^<<^";

    public override int Nummer => 202415;
}