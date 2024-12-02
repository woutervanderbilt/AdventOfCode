using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag22 : Problem
{
    private const string testinput = @"        ...#
        .#..
        #...
        ....
...#.......#
........#...
..#....#....
..........#.
        ...#....
        .....#..
        .#......
        ......#.

10R5L5R10L4R5L5";

    public override async Task ExecuteAsync()
    {
        var grid = new Grid<char>();
        IList<(int, char)> instructions = new List<(int, char)>();
        {
            bool buildingGrid = true;
            int y = 0;
            foreach (var line in Input.Split(Environment.NewLine))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    buildingGrid = false;
                    continue;
                }

                if (buildingGrid)
                {
                    int x = 0;
                    foreach (var c in line)
                    {
                        grid[x, y] = c;
                        x++;
                    }

                    y--;
                }
                else
                {
                    string currentInstruction = string.Empty;
                    foreach (var c in line)
                    {
                        if (char.IsDigit(c))
                        {
                            currentInstruction += c;
                        }
                        else
                        {
                            instructions.Add((int.Parse(currentInstruction), c));
                            currentInstruction = string.Empty;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(currentInstruction))
                    {
                        instructions.Add((int.Parse(currentInstruction), ' '));
                    }
                }
            }
        }
        //grid.Print();
        grid.FillBlanks(' ');
        int minX = grid.MinX;
        int maxX = grid.MaxX;
        int minY = grid.MinY;
        int maxY = grid.MaxY;

        IDictionary<int, (int, int)> xBoundaries = new Dictionary<int, (int, int)>();
        IDictionary<int, (int, int)> yBoundaries = new Dictionary<int, (int, int)>();

        for (int x = minX; x <= maxX; x++)
        {
            if (x == 66)
            {

            }
            int? first = null;
            for (int y = minY; y <= maxY; y++)
            {
                if (!first.HasValue && grid[x, y] != ' ')
                {
                    first = y;
                }
                else if (first.HasValue && grid[x, y] == ' ')
                {
                    xBoundaries[x] = (first.Value, y - 1);
                    break;
                }
                else if (y == maxY)
                {
                    xBoundaries[x] = (first.Value, y);
                }
            }
        }
        for (int y = minY; y <= maxY; y++)
        {
            int? first = null;
            for (int x = minX; x <= maxX; x++)
            {
                if (!first.HasValue && grid[x, y] != ' ')
                {
                    first = x;
                }
                else if (first.HasValue && grid[x, y] == ' ')
                {
                    yBoundaries[y] = (first.Value, x - 1);
                    break;
                }
                else if (x == maxX)
                {
                    yBoundaries[y] = (first.Value, x);
                }
            }
        }



        (int x, int y) currentPosition = (yBoundaries[0].Item1, 0);
        GridDirection currentDirection = GridDirection.East;
        foreach (var instruction in instructions)
        {
            if (currentPosition == (73, 0))
            {

            }
            //Console.WriteLine((instruction, (currentPosition.Item1 + 1, -currentPosition.Item2 + 3), currentDirection));
            for (int i = 1; i <= instruction.Item1; i++)
            {
                GridMember<char> next;
                if (currentDirection == GridDirection.East)
                {
                    next = grid.East(currentPosition);
                    if (!next.Found || next.Value == ' ')
                    {
                        //next = grid[yBoundaries[currentPosition.y].Item1, currentPosition.y];
                        var fold = DetermineFold(currentPosition, currentDirection);
                        next = fold.member;
                        if (next.Value != '#')
                        {
                            currentDirection = fold.direction;
                        }
                    }
                }
                else if (currentDirection == GridDirection.South)
                {
                    next = grid.South(currentPosition);
                    if (!next.Found || next.Value == ' ')
                    {
                        //next = grid[currentPosition.x, xBoundaries[currentPosition.x].Item2];
                        var fold = DetermineFold(currentPosition, currentDirection);
                        next = fold.member;
                        if (next.Value != '#')
                        {
                            currentDirection = fold.direction;
                        }
                    }
                }
                else if (currentDirection == GridDirection.West)
                {
                    next = grid.West(currentPosition);
                    if (!next.Found || next.Value == ' ')
                    {
                        //next = grid[yBoundaries[currentPosition.y].Item2, currentPosition.y];
                        var fold = DetermineFold(currentPosition, currentDirection);
                        next = fold.member;
                        if (next.Value != '#')
                        {
                            currentDirection = fold.direction;
                        }
                    }
                }
                else if (currentDirection == GridDirection.North)
                {
                    next = grid.North(currentPosition);
                    if (!next.Found || next.Value == ' ')
                    {
                        //next = grid[currentPosition.x, xBoundaries[currentPosition.x].Item1];
                        var fold = DetermineFold(currentPosition, currentDirection);
                        next = fold.member;
                        if (next.Value != '#')
                        {
                            currentDirection = fold.direction;
                        }
                    }
                }
                else
                {
                    throw new Exception();
                }

                if (next.Value == '.')
                {
                    currentPosition = next.Location;
                    //Console.WriteLine(((currentPosition.Item1 + 1, -currentPosition.Item2 + 3), currentDirection));
                }
                else
                {
                    break;
                }

                //Console.WriteLine((currentPosition, currentDirection));
            }
            currentDirection = (currentDirection, instruction.Item2) switch
            {
                (GridDirection.North, 'L') => GridDirection.West,
                (GridDirection.North, 'R') => GridDirection.East,
                (GridDirection.East, 'L') => GridDirection.North,
                (GridDirection.East, 'R') => GridDirection.South,
                (GridDirection.South, 'L') => GridDirection.East,
                (GridDirection.South, 'R') => GridDirection.West,
                (GridDirection.West, 'L') => GridDirection.South,
                (GridDirection.West, 'R') => GridDirection.North,
                _ => currentDirection
            };
        }

        Result = (1000 * (-currentPosition.y + 1)
                  + 4 * (currentPosition.x + 1)
                  + DirectionValue(currentDirection)).ToString();


        (GridMember<char> member, GridDirection direction) DetermineFold((int, int) from, GridDirection direction)
        {
            var fold = DetermineFoldInternal();
            //Console.WriteLine($"{from} {direction}  ->  {fold.member.Location} {fold.direction}");
            return fold;

            (GridMember<char> member, GridDirection direction) DetermineFoldInternal()
            {
                if (direction == GridDirection.North)
                {
                    if (from.Item1 < 50)
                    {
                        return (grid[50, -from.Item1 - 50], GridDirection.East);
                    }

                    if (from.Item1 < 100)
                    {
                        return (grid[0, -from.Item1 - 100], GridDirection.East);
                    }

                    return (grid[from.Item1 - 100, -199], GridDirection.North);
                }

                if (direction == GridDirection.East)
                {
                    if (from.Item2 > -50)
                    {
                        return (grid[99, -149 - from.Item2], GridDirection.West);
                    }

                    if (from.Item2 > -100)
                    {
                        return (grid[50 - from.Item2, -49], GridDirection.North);
                    }

                    if (from.Item2 > -150)
                    {
                        return (grid[149, -149 - from.Item2], GridDirection.West);
                    }

                    return (grid[-100 - from.Item2, -149], GridDirection.North);
                }

                if (direction == GridDirection.South)
                {
                    if (from.Item1 < 50)
                    {
                        return (grid[from.Item1 + 100, 0], GridDirection.South);
                    }

                    if (from.Item1 < 100)
                    {
                        return (grid[49, -100 - from.Item1], GridDirection.West);
                    }

                    return (grid[99, 50 - from.Item1], GridDirection.West);
                }

                if (from.Item2 > -50)
                {
                    return (grid[0, -149 - from.Item2], GridDirection.East);
                }

                if (from.Item2 > -100)
                {
                    return (grid[-50 - from.Item2, -100], GridDirection.South);
                }

                if (from.Item2 > -150)
                {
                    return (grid[50, -149 - from.Item2], GridDirection.East);
                }

                return (grid[-100 - from.Item2, 0], GridDirection.South);
            }
        }


        int DirectionValue(GridDirection direction)
        {
            return direction switch
            {
                GridDirection.East => 0,
                GridDirection.South => 1,
                GridDirection.West => 2,
                GridDirection.North => 3,
                _ => throw new Exception()
            };
        }
    }

    public override int Nummer => 202222;
}