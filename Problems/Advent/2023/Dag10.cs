using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2023;

internal class Dag10 : Problem
{
    private const string testinput = @"FF7FSF7F7F7F7F7F---7
L|LJ||||||||||||F--J
FL-7LJLJ||||||LJL-77
F--JF--7||LJLJ7F7FJ-
L---JF-JLJ.||-FJLJJ7
|F|F-JF---7F7-L7L|7|
|FFJF7L7F-JF7|JL---7
7-L-JL7||F7|L7F-7F7|
L.L7LFJ|||||FJL7||LJ
L7JLJL-JLJLJL--JLJ.L";

    public override async Task ExecuteAsync()
    {
        var grid = new Grid<char>();
        string input = await GetInputAsync();
        int y = 0;
        foreach (var line in input.Split(Environment.NewLine).Reverse())
        {
            int x = 0;
            foreach (char c in line)
            {
                grid[x, y] = c;
                x++;
            }

            y++;
        }

        var start = grid.AllGridMembers().Single(c => c.Value == 'S');

        long max = 0;
        HashSet<(int, int)> loop = null;
        var north = Try(GridDirection.North);
        if (north.Item1 > max)
        {
            max = north.Item1;
            loop = north.Item2;
        }
        var south = Try(GridDirection.South);
        if (south.Item1 > max)
        {
            max = south.Item1;
            loop = south.Item2;
        }
        var east = Try(GridDirection.East);
        if (east.Item1 > max)
        {
            max = east.Item1;
            loop = east.Item2;
        }
        var west = Try(GridDirection.West);
        if (west.Item1 > max)
        {
            max = west.Item1;
            loop = west.Item2;
        }

        HashSet<(int, int)> right = new HashSet<(int, int)>();
        HashSet<(int, int)> left = new HashSet<(int, int)>();
        (int, int) prev = (-1, -1);
        foreach (var loopMember in loop)
        {
            if (prev == (-1, -1))
            {
                prev = loopMember;
                continue;
            }

            if (prev.Item1 == loopMember.Item1)
            {
                if (prev.Item2 == loopMember.Item2 + 1)
                {
                    AddMemberGroup((prev.Item1 + 1, prev.Item2), right);
                    AddMemberGroup((prev.Item1 - 1, prev.Item2), left);
                    AddMemberGroup((prev.Item1 + 1, loopMember.Item2), right);
                    AddMemberGroup((prev.Item1 - 1, loopMember.Item2), left);
                }
                else if(prev.Item2 == loopMember.Item2 - 1)
                {
                    AddMemberGroup((prev.Item1 + 1, prev.Item2), left);
                    AddMemberGroup((prev.Item1 - 1, prev.Item2), right);
                    AddMemberGroup((prev.Item1 + 1, loopMember.Item2), left);
                    AddMemberGroup((prev.Item1 - 1, loopMember.Item2), right);
                }

            }
            else if (prev.Item1 == loopMember.Item1 + 1)
            {
                AddMemberGroup((prev.Item1, prev.Item2 - 1), right);
                AddMemberGroup((prev.Item1, prev.Item2 + 1), left);
                AddMemberGroup((loopMember.Item1, prev.Item2 - 1), right);
                AddMemberGroup((loopMember.Item1, prev.Item2 + 1), left);
            }
            else if (prev.Item1 == loopMember.Item1 - 1)
            {
                AddMemberGroup((prev.Item1, prev.Item2 - 1), left);
                AddMemberGroup((prev.Item1, prev.Item2 + 1), right);
                AddMemberGroup((loopMember.Item1, prev.Item2 - 1), left);
                AddMemberGroup((loopMember.Item1, prev.Item2 + 1), right);
            }

            prev = loopMember;
        }

        var newgrid = new Grid<char>();
        foreach (var m in grid.AllGridMembers())
        {
            if (left.Contains(m.Location))
            {
                newgrid[m.Location.Item1, m.Location.Item2] = '*';
            }
            else if (right.Contains(m.Location))
            {
                newgrid[m.Location.Item1, m.Location.Item2] = '.';
            }
            else if(loop.Contains(m.Location))
            {
                newgrid[m.Location.Item1, m.Location.Item2] = m.Value;
            }
            else
            {
                newgrid[m.Location.Item1, m.Location.Item2] = '?';
            }
        }

        newgrid.Print();

        void AddMemberGroup((int, int) location, HashSet<(int, int)> part)
        {
            if (part.Contains(location) || loop.Contains(location) || location.Item1 < 0 || location.Item1 > grid.MaxX || location.Item2 < 0 || location.Item2 > grid.MaxY)
            {
                return;
            }
            IList<(int, int)> added = new List<(int, int)> { location };
            part.Add(location);
            while (added.Any())
            {
                var newAdded = new List<(int, int)>();
                foreach (var l in added)
                {
                    foreach (var n in grid.Neighbours(l, false))
                    {
                        if (part.Contains(n.Location) || loop.Contains(n.Location))
                        {
                            continue;
                        }
                        newAdded.Add(n.Location);
                        part.Add(n.Location);
                    }
                }

                added = newAdded;
            }
        }

        var result2 = left.Any(l => l.Item1 == 0) ? right.Count : left.Count;


        Result = (((max + 1) / 2), result2).ToString();


        (long, HashSet<(int, int)>) Try(GridDirection direction)
        {
            var members = new HashSet<(int, int)>();
            long count = 0;
            var currentLocation = start;
            while (currentLocation.Value != 'S' || count == 0)
            {
                count++;
                currentLocation = grid.MoveInDirection(currentLocation.Location, direction);
                members.Add(currentLocation.Location);
                direction = (direction, currentLocation.Value) switch
                {
                    (GridDirection.North, 'F') => GridDirection.East,
                    (GridDirection.North, '|') => GridDirection.North,
                    (GridDirection.North, '7') => GridDirection.West,

                    (GridDirection.East, 'J') => GridDirection.North,
                    (GridDirection.East, '-') => GridDirection.East,
                    (GridDirection.East, '7') => GridDirection.South,

                    (GridDirection.South, 'L') => GridDirection.East,
                    (GridDirection.South, '|') => GridDirection.South,
                    (GridDirection.South, 'J') => GridDirection.West,

                    (GridDirection.West, 'F') => GridDirection.South,
                    (GridDirection.West, '-') => GridDirection.West,
                    (GridDirection.West, 'L') => GridDirection.North,

                    (_, _) => GridDirection.NorthEast
                };
                if (direction == GridDirection.NorthEast && currentLocation.Value != 'S')
                {
                    return (0, members);
                }
            }

            return (count, members);
        }
    }


    public override int Nummer => 202310;
}