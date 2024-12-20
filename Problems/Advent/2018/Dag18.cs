﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2018;

public class Dag18 : Problem
{
    private const string input = @"..|.#...||..||.#|#..|...#.#..#.|#.|...|#|.#.|.||#.
.|#....##.#||.......|..|...|..#.#...#...|.#.......
..#......||..|.#||####.#....#...#..#||..|#..|#.|.|
.||..|.#...##..#..|.#....##...#...#####....#.||.##
.....|.|.#|.##....#.#..#.|..|#|.||.||....#|..|#.||
.|||#...||....#......###.#|..||..#.|..|.#....|..#|
.#.|#.|#......###...||...||.##|..#.#..#.#....#..||
.......#...|...|###|.|#.....##.#||.|.....|.#.|.|#.
|....||||#|#||.#...|#.#.||...|....|...|...#|.#....
#|..#.|.#|..|.#...#|.#|..|...|..|#.#....|..|.#.|#|
#.#.|.|.....|..|...#.#.....#.##...|#.#..#.#|.##..|
#..#...#|....||......#...|.##...#.|.|||.|..##...#.
#..|.|#....||#...#.#|...#|...#.#.|#||..#..|..|....
||...|||...||#..#...#|.....#...........#|.#...#.#.
...||..#|###||.|.#|#|#.||..|.#...#|......|#|#..#||
#.|.|.|#.||.#.|..#|.|.#|#.###.|......||.||..|#....
.###.|#|#.#..##...|.####.....|#..#.#...#.#...##.|.
.........#....|.#...|.#..|....||..||.#|......##.##
##|..#.#....#..#....|#.......##.||.||....||#..#...
...#.|.|.|.|..#|......|.##|.||...|#|..|.|..#...|..
...||.....|#..#|.#...#|.#....|...#.|.....#|.||.#|.
.|#||.....||...|.|.|...|#..##.||#|......#|...|#...
#.....|...|#.#.............##..|.|||..#.....#|#...
.#|...#....|.||##|..#....||#.#...#..|....|#|#.....
..||.#..#.#|.||..#..#..##.#|#..#.#.#.........|...#
||..#|..##.....|#..|..|.||..|#.##.#..#..##...###.#
#|.......#|..###..|||.#|.#.......||..........|.|..
##.##..|...#|##..##....||...|#|...|.|.#.####.....#
#|.|....|#...#....|...#|.#.#...#.|..#.|...##.|#.#|
..#|#||....|.|.....#...|....#.||##....|...|.|#||#.
..#...|.||........|..|.|.|#...|...#.|####.#.#...|.
...|#|..|..||.#|#...|.#|.|...#|...#....#...###.|..
.####....##|......|.#...##.|.|###.....#|...|...|..
.|...||...|...#..|#.#..#|..##......||..|........#.
|.|.#...#.|.#..||||..##...|.|.....#.#.#...|......|
|...#..#|#.||#...|.|...|..|.||#.||........#.......
|......#|.|....||#.||.....|..|#|.|..#|.||#.##.#..#
.#||.|##..###.......##..|......|.....|#|.##..###.#
..#.....#..|#...|......|#...#..|.#|.#....||||.....
.|#.#.#.........................|...#..|..|.#.|...
#..##||.|..#|..###......|....#...|.|..#|..#.....|.
|....||......|..#....|.....|##.#.|...|....#|||.||.
..#.###.#..|.|#.#...|..|...|....|#|........#...##.
.||..|||###..#.#..|.#.|....##..|..#|.|...##|..||#|
.|.|....|.|||......|.||#.|........#...#..#.#..#|.|
...|#..#.||...||...|..||||..||..|#|..|....|##.|..|
..|....|..|#.......|#..|...#..#.#..|.#.....#.#..#|
...|.#|..#.......|##..|.|.###|.|.|.||#..#.#|...#.|
|.||...|#..|.#..||#|.||...#|..#.|.#..........|||||
..##|...#|#...#..#.....#...|#.|..|##...#.|...#....";
    public override Task ExecuteAsync()
    {
        int target = 1000000000;
        IList<string> hs = new List<string>();
        IList<int> results = new List<int>();
        var map = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
        int result = 0;
        for (int m = 1; m <= target; m++)
        {
            int totalTrees = 0;
            int totalLumber = 0;
            List<string> newMap = new List<string>();
            var newMapAsString = new StringBuilder();
            for (int i = 0; i < map.Count; i++)
            {
                var line = map[i];
                var newLine = new StringBuilder();
                for (int j = 0; j < line.Length; j++)
                {
                    int trees = 0;
                    int lumber = 0;
                    int open = 0;

                    for (int di = -1; di <= 1; di++)
                    {
                        for (int dj = -1; dj <= 1; dj++)
                        {
                            if (di == 0 && dj == 0 || i + di < 0 || j + dj < 0 || i + di >= map.Count ||
                                j + dj >= line.Length)
                            {
                                continue;
                            }

                            switch (map[i + di][j + dj])
                            {
                                case '.':
                                    open++;
                                    break;
                                case '|':
                                    trees++;
                                    break;
                                case '#':
                                    lumber++;
                                    break;
                            }
                        }
                    }

                    switch (line[j])
                    {
                        case '.':
                            if (trees >= 3)
                            {
                                newLine.Append('|');
                                totalTrees++;
                            }
                            else
                            {
                                newLine.Append('.');
                            }
                            break;
                        case '|':
                            if (lumber >= 3)
                            {
                                newLine.Append('#');
                                totalLumber++;
                            }
                            else
                            {
                                newLine.Append('|');
                                totalTrees++;
                            }
                            break;
                        case '#':
                            if (lumber >= 1 && trees >= 1)
                            {
                                newLine.Append('#');
                                totalLumber++;
                            }
                            else
                            {
                                newLine.Append('.');
                            }
                            break;
                    }
                }
                newMap.Add(newLine.ToString());
                newMapAsString.Append(newLine);
                result = totalTrees * totalLumber;
                //Console.WriteLine(result);
            }

            var mapstring = newMapAsString.ToString();
            if (hs.Contains(mapstring))
            {
                var i = hs.IndexOf(mapstring) + 1;
                var cycleLength = m - i;
                var x = (target - m) % cycleLength;
                Result = results[i + x - 1].ToString();
                return Task.CompletedTask;

            }

            hs.Add(mapstring);
            results.Add(result);
            map = newMap;
            if (m >= 460)
            {
                Console.WriteLine($"{m - 460} {result}");
            }
            //Console.WriteLine(result);

        }

        Result = result.ToString();
        return Task.CompletedTask;
    }

    public override int Nummer => 201818;
}