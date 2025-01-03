﻿using Algorithms.Extensions;
using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag23 : Problem
{
    private const string testinput = @".....
..##.
..#..
.....
..##.
.....";
    public override async Task ExecuteAsync()
    {
        var grid = new Grid<bool>();
        int y = 0;
        foreach (var line in Input.Split(Environment.NewLine).Reverse())
        {
            int x = 0;
            foreach (var c in line)
            {
                grid[x, y] = c == '#';
                x++;
            }

            y++;
        }

        IDictionary<GridDirection, IList<GridDirection>> lookTo =
            new Dictionary<GridDirection, IList<GridDirection>>();
        lookTo[GridDirection.North] = new List<GridDirection>
            { GridDirection.NorthWest, GridDirection.North, GridDirection.NorthEast };
        lookTo[GridDirection.East] = new List<GridDirection>
            { GridDirection.NorthEast, GridDirection.East, GridDirection.SouthEast };
        lookTo[GridDirection.South] = new List<GridDirection>
            { GridDirection.SouthEast, GridDirection.South, GridDirection.SouthWest };
        lookTo[GridDirection.West] = new List<GridDirection>
            { GridDirection.NorthWest, GridDirection.West, GridDirection.SouthWest };
        IList<GridDirection> directions = new List<GridDirection>
            { GridDirection.North, GridDirection.South, GridDirection.West, GridDirection.East };


        for (int s = 0; s < 100000000; s++)
        {
            var nextGrid = Step(s);
            if (nextGrid == null)
            {
                break;
            }

            grid = nextGrid;
        }
        //grid.Print();
        Result += " " + grid.AllGridMembers().Count(m => !m);

        Grid<bool> Step(int step)
        {
            var newGrid = new Grid<bool>();
            IDictionary<(int, int), IList<GridMember<bool>>> moves = new Dictionary<(int, int), IList<GridMember<bool>>>();
            foreach (var elf in grid.AllGridMembers().Where(m => m))
            {
                bool moved = false;
                if (grid.Neighbours(elf.Location, true).Any(m => m.Found && m.Value))
                {
                    for (int d = step; d < step + 4; d++)
                    {
                        var direction = directions[d % 4];
                        if (CanMove(direction))
                        {
                            var move = TryMove(direction).Location;
                            if (!moves.ContainsKey(move))
                            {
                                moves[move] = new List<GridMember<bool>>();
                            }
                            moves[move].Add(elf);
                            moved = true;
                            break;
                        }
                    }
                }

                if (!moved)
                {
                    if (!moves.ContainsKey(elf.Location))
                    {
                        moves[elf.Location] = new List<GridMember<bool>>();
                    }
                    moves[elf.Location].Add(elf);
                }

                bool CanMove(GridDirection direction)
                {
                    foreach (var gridDirection in lookTo[direction])
                    {
                        var occupied = TryMove(gridDirection);
                        if (occupied)
                        {
                            return false;
                        }
                    }

                    return true;
                }

                GridMember<bool> TryMove(GridDirection gridDirection)
                {
                    return gridDirection switch
                    {
                        GridDirection.North => grid.North(elf.Location),
                        GridDirection.NorthEast => grid.NorthEast(elf.Location),
                        GridDirection.East => grid.East(elf.Location),
                        GridDirection.SouthEast => grid.SouthEast(elf.Location),
                        GridDirection.South => grid.South(elf.Location),
                        GridDirection.SouthWest => grid.SouthWest(elf.Location),
                        GridDirection.West => grid.West(elf.Location),
                        GridDirection.NorthWest => grid.NorthWest(elf.Location),
                    }
                        ;
                }
            }

            bool someElfMoved = false;
            foreach (var move in moves)
            {
                if (move.Value.Count == 1)
                {
                    newGrid[move.Key.Item1, move.Key.Item2] = true;
                    if (move.Key != move.Value[0].Location)
                    {
                        someElfMoved = true;
                    }
                }
                else
                {
                    foreach (var elf in move.Value)
                    {
                        newGrid[elf.X, elf.Y] = true;
                    }
                }
            }

            if (!someElfMoved)
            {
                Result = (step + 1).ToString();
                return null;
            }

            newGrid.FillBlanks(false);
            return newGrid;
        }
    }

    public override int Nummer => 202223;
}