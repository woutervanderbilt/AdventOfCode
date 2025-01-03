﻿using Algorithms.Extensions;
using Algorithms.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2021;

internal class Dag20 : Problem
{
    private const string input = @"#.#.#.....###.###..##...##.#.###..##..#.#..#.#..###.#.####.######......#.#..###.#....#.#...########....#.#..#.##.##.#.######..#..#..#.##.##.##..###..##.####.##.##.#.##.##..#.#..#####..##..#.##.#.#......###.#.#..#.#..##.###..###.#####.#...##.##.#.##..####..#.....####..........#...#.#..#..#..##.##....##...#.#..#.....#.##..####.#.##.#.##.#.####.##.#.##..#..##.#.##.###.....##.#.####...#.#.##..#..##...####..#.#.#...###....#..#.#..#..###..#..#..#...#.#.##.##.#...######.##..##.###.#.###.###..#......#..#..#.#...#..

##..#.#...#...#.#..#..##.#.#.##.##.####.##.#.#.##..##..##..#...##..##.#....##.#.####.##...#..#....##
###..#..#..##..#####..##.#.##.##.##.#...##......#...#..#.#..#.....#####...#.######...#.....#...##.##
..##.#..#......#.....##......##.###.###..#####..###.####.#.#....#.#.##..##....####..#.....###..#.##.
#.##....#.....#.....#..####..##.####...#..#####.#.#.##.##.##.#..###...####..###.#...#.###..#..#..###
#.##..#....#.#..#.##....#..#...##.#..#..##.#.#####...#..###...##.#.#....#..#..#....##.#..##..##..#.#
...####.#.####..#.###.....##..#...##...#.######....####...#.#....##.#......#.#.##.##.###...#...#...#
##..##.#....#.....#.#.#####.#.####.#.#.#.#####.###..#.......###.#.###......###.##..##.#####.#.##.###
####.#..#####.##....###...##..###..#...###..###.####..#.##..##.#...####.....#..#.#..##...##.#.###...
.#..#...##...####.#.###......#..##...#.##.##.#.#.##.#..##.#.#.#.#..###...###..###..###...###....#...
#.#####..###....###..##....######.#.#..#...#.####.###.####..#.##..##..#.#.#.#..#####....##.##...##..
....#.#.......#.#...#.##...#.#.##.#.###.#.####..#.####...########...#.###.#.#.....#.####.#..#..#.###
.##.###.##..#....##..#.##..###......#.##.##.##...#.#...##.#######.#.#.#..###..##..####....##...#..##
#....#..##..#.######....##.#.#........#..#.#..#.....#.#..##.#.#.##.##.#####..##...#.##..#..#....####
#..##..#.#.....###.#.###.##.#.#.###...###...###..##..##.##.......##......##.#.##.#...#.##..#....#..#
#.#.#.#.#.###..###.##..#..#........###..###.##..##.####.##....#..#.......#...###..#..#..#...#.....#.
##...##.####..#####...#.#.##...##...####...##.##.##.#.#####..#..###.#.###.###.#.#.#..#...#.#.####..#
..#..##..#####.##..##...#....###..#.#.....##...######.#..##.#..#####..#.##.#.#.#..#..#.#######..###.
.....#.#..####..##.###..###.....#.##...#.#.#...#..#...####.#....#..#...#.##...#..##..#.##....##.###.
......#.#...####....##.#....##..####.#...##...##..#.#.#.###..#.#..##....##...##.#.#..##.##.....###.#
#.####..###..###.#...##..#.#.####..#...#.....###.##..###...#....#######.####.#...#.#.###..####...#.#
###...#.#...#..####.##..###...........#..#....#..#.####.#.......##.##.###.#.#....#.#.#.#...#.#..#...
.##.#.#.#.#...###...#...#..#.#.#...##..#..##....#...##..#.#..###.#....##.###....###...######.##.####
.....##....#....#.#######.#..##..#..#.....###..#....#.####.##.#..##.#...##..##.#.#.###....#..#...###
..##.#.###.#.####.#.#######.#...#.##.#..##.#####...#.###...###.##.#.###...#..#......########..##..#.
####...#..##......#.#.###.#####.#....#..#..##.....#....##.#.#...###......###.#...#.##.#.......#.....
#.##...#.##..###.#####..###..##.#..##..#..##.##..###...#.##.#..######.##.#...#.#.##....###.#..#.##.#
##.#...##.#.####.#.#.#...#..#.####.##.#..#.#.##...##.###..#..###..#.###....#.###.#.#.###.#...####.##
.##...#..#..##..#######...#..####...###..#..#.#..##.#.##.#..#..###.#.##..#.#...###...#######.####.##
##..#.##.#...###.........#.#..#..#.#..#.#..#...##.#.##......#.####.##..###..#.###.#.#####.###...#.#.
...#.###.#..#....####.###.##..####.#.###..##.#.####.##...#.##..#.##.###....#.#.#.##......#.####.....
.###.#######..#....####.#..#.#...####.#.....#.#.#.###.###.#.##.###.####..#####...#.....##...###....#
#..#..#.######.##.###.....###..##.#...###.#.#####...####..###..##.###...#..##....##...##.#.##.##..#.
..##...#...#.####..##...#....#..#.##..###.####.##..###.#..####..##.#.####..####..##.#####..###.###..
.#..#..#..#....##.#.#####.#.#......#.###.....#.####..#.#.#......#..#.#....#....####..###.#.....#..#.
##.#.##....#...#...#.##.#..........####.##...#..#..##.###...#.#..##########..###.##.#.###.#.#.#.##.#
..#.##.####....##.#..#.##...##.##..##.###.##.....##..##..#.#.#.#.....#...#...##.#..#.....#####.####.
#.#.#..####.####....###.##.##.....###..#####.#......#.#...#..###..##.###.#....#.#.#####.#..#.#######
##..###.#.##..####..#..#.#..##..#...###....#..##.####..##..##.##..###.###.####.#.##.###..##.####.#..
..#.##.#.#####.#....###.#.#..#.###.#.#...##.#.#....#.##...#..#####..###..#.#.####.#...#.####...##...
...###.#..##.#.#...#..#.#.##.#.##.##.#.#.#####..###...#...#...#.#.###......#.##.#.#..#.###.##.####.#
#....#.##......##...##.....####.#.##..##.#..##.###########..#..##.#...##.##......##....#......##.#..
##...#####.###.###..#.###....#.#.#..#..#.#####...###....#.##.#.####....#.#....######....#.#.##.####.
....##....#..##......##.....#.##..####.##.##.#.#.#....#...#...##.##..#....#..##...#.#....#.#..#.###.
...#.......#.#...#....#.#.#....#...#...##.##...###.####......#..###.##....######.##.####.##.....#...
####..###..##...#......##...##..#.#...###..####.###.#....##.###.#..##.#...##.##........####.#...###.
..##.##.#..####..###.#..####...#..#.#..#...#.##..#..##.#######....#...##..#..#.#......#.#.####.#.#..
####.#.#...##....###..#.#..#..#.#...####.###...#####..######.#.....#..###.##.##........###.##.##.###
.#.#..#....##.###..##.......###.#...#.######...#####.#..#######...##.##.#..#...#.....#...####.###..#
..#....##.....#....###..##.##..####.....###...#.#...####..###..##....#...###...####.##..########....
..........###...#.......##...####...#######....##..#.##.##.###..###...#######..#..####.##..#.##..##.
#######...###...##.##..#.#....#..#..#...###..#..#.#.#..#..###..#....#...##....#..#.#.......#########
.#..##........##.......#.###..#.#.#####.##.#.####..#.#.##...#..#...#.#.##..##.#..##.#####.##....##.#
....##....##.#..#.#...#.....###....##...#.#.#...#.###.....#.#.....#..#####.#..##..#.#####........#..
##.##.#....#..##..##.##.###..#.#.##..###.#..##...####.######.#.#.#...#..#.#.#...#.#..######.#....#..
##.###.#......###..#.#..#.#..#...######.##.##.#####.####......######...####.##.#####...#..#...#.###.
.#########....##..###..#.#....####.###.....#..#...##.###.##..####.#.##..#..#....##..###.##..##.#.##.
#.#.#.###...#####..###.####.#####.##.#.#...##..##.#.#...###..##....###.#...##.###.....###...########
###.#.###.....#.#.#..#.#...###.##........#.####..#...###.#.##.####..###.#..#...##.#..##.#.#...#.##.#
..##.#..#.#..##.##.##...####..####.#####.##..#...####...##...###...#####.#####.##...###..#...#.#.##.
##.#.#.#.####..#.##.#...#........##..#.###.###.#.....#..#..##.#####..##.#.####.#......###.#####..#.#
#.######.###...#.###..#..#.#.#.#.###.##..###.###..#.###..#####...##..####..##.######.#.##..#.#.##...
.##.#.#.####...###.......#.####...#..###.#.....#.#......##.#.##.###.#####....##.#.#.###......###.#..
###..#.##.####....##.##.#..#.###........###.####....#...#...##...#..###.##.###..####.#.#.#.##.#.....
###...#.###.....#...#.#.#..#.#....##.#.#.#.#.#..#..##.###.###...#....#####..####.##...##.#.###.#..##
..##......#..####...##.#..##.##.......##.####.#.#.###.###...##.#.###..###...########.##...#.##....##
.#...#.##..#..###.####.##.#.#.#..#..#.#....#..#..........#####.##.#.#.###.#.##....#...##.#.#.#..#...
..#...##..#.#.###.##..##..####.####..#.....####.##..#.#.#....#..##.##.#####...####.#..#.#...#....#.#
..##..#..#.#..........###.##..###..#...###.###...###..#.##.#####...####.##...####.##...#####.#.#....
..#..####.....###..#..##..##.#..#.####.##..##..#.#.##.##.##..#....#.####.#.#..##.#.####.#..#.##.#..#
.#.#.#############..###..##..######........##..###.#..###..##.....###.#.###.#.##.#.#.#.##.#..####..#
...#.###...#.#..#########.###.#..##..###.#.##......########.#....#######....#...#...###..#.#####..#.
..########.####..#..#.#..#..##.#.##...###.#..####..#.#####...##.###.###.##..##.#.#..##...##.##.#.#..
..##.##.#.......#.##..#.#.#####...#.#..#.#####...###.##....#....#..#..####...##....#......#....###..
...#...#..#.###..##...##.##..##.#.###...#...###..###.#..#######..#..##..####..##.#.#.#.#..#.##..#...
.#####...##.##.#.#.#.###.#.#..##.....#..###...#..#.##.#...#.....#.#...#..#.#...#..#######.#.#######.
#.##.#...###.#.##.#..#....##.##..#.##.##.#.##.##..#.#..##..#.#..#..#...##..####....#.##.#####....##.
#..#..###.###.##...#########.##.#.###....##.###.###.#.##.#.###....#.#..#.....######...#.#.#....#.#..
.....#.######.###.##.........##...#..#..#..##.##..#..###..##..#.#.##.#.#.###.......#.##.....####...#
.######.#.####...#.###......#..#.###.##.###.....##.#####..###...##.##.#...#.....#..#...##.#.#.#.####
.##..##.#.#..#..##..##.####.#...####......##...##.#####.###..#...#.##..#.#...#.#..#..#..#...#....###
...##.#..#.#..#.###.####.#.#.....#.#.#..##.##.#..#.###.#...##.####.#...#.##..#..####.#####..#.#.#..#
#.##.#..#..##.#..##...#.##.#.###...##.##..#.##.#.#..#..#..##..##.##.#.....#..##...#.#..#....#..####.
#.##..###...##..####.##.#.##..##........###.#..###.#.####..####.#.##.#....#######.#####..##.#..#####
..###.#.#...##....##...##..#..#.#.#.....#..#.#.#.####...#..#...#..#......###.##..#####.####..####..#
..#...#.##..###.#.##..#...###..##.#####.###.#.#.......#.#....###.####..#..#.#..#...###.#.#..###..##.
##.#.#.##.#..###.###......###..##..#..##.#..#.##.#..###..#.####...#..#####..#.####.##.#...#..#.##.#.
..#.##.#......#..............##.###..##.###.#.#.##...##.#.......#######.#...#..##.#..####..#.##.#.##
.##..........##...###......#.#.....#.##.##.##..####..##.#.##.#..###.#..####..##.#..#..#.###.##..#..#
##...##...###...#.##..##.####.....#.#.####.##..##.##.##........#.##...##...###########...#..#..#...#
.##.##.#..##.#.########...###...###.#...#.####...#.###.##.###...#...###...##...#........##.##.###.#.
##.#..###...######.#.#.#.#.#.#..........#..##...##..#....#..###..######.....#.#..##.#.#..##.##.##.#.
###.##..#.##..#...#.#...#.##...#.###.#..#..#..##.##.##..#..#..###.#.##...##...#.#.##.###.....#.###.#
.##..#.##....#.#......###.##.#.##......##..#.##..##..#..##..########..##.#..##...#..#...###.#...#.##
.###..#.#.......#....#...#.#....###.#.###.##.##..#.#.....#...#####.#..####.##.##.#.#.#.....#####.#..
##...##.#####.#....###.#.##.###.#.#.#..#..###..##..####..##..###.....##.#.########..#..##..#.#.#.###
..#.##.#.##..###..####.##..#..###....#..#....#.##..#.####.##.#...#.##.##..########.##.##.#.#.#...##.
.#..###.######.#.###.##.#.##......##.###.##.#....#......###....####.##.###.#..##.####.#..###.#......
#.....###....##.....###.#..#....#.#...#.#....#.##.######.####.###########...#..#..#..##.#.##.##....#
.##.#.#..#...#.#.##..#...####..#.#.#...##..#..#..##...####.#...######.....##...##.##.#..###.###..#..
..#.#..##....##...####.#...#...###..#......#.##....#.##...##......####.##.#.##.#.#.#..#...#..##..#..";

    private const string testinput = @"..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#

#..#.
#....
##..#
..#..
..###";
    public override Task ExecuteAsync()
    {
        string enhancement = "";
        var grid = new Grid<bool>();
        bool first = true;
        int y = 0;
        foreach (var line in input.Split(Environment.NewLine))
        {
            if (first)
            {
                enhancement = line;
                first = false;
                continue;
            }
            else if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            int x = 0;
            foreach (var c in line)
            {
                grid[x, y] = c == '#';
                x++;
            }

            y--;
        }
        grid.Print();
        int iterations = 50;
        for (int i = 1; i <= iterations; i++)
        {
            grid = Enhance(i % 2 == 0);
        }
        //grid.Print();

        Result = $"{grid.AllMembers().Count(b => b.value)}";


        Grid<bool> Enhance(bool even)
        {
            var result = new Grid<bool>();
            var minX = grid.MinX - 2;
            var maxX = grid.MaxX + 2;
            var minY = grid.MinY - 2;
            var maxY = grid.MaxY + 2;
            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    int index = 0;
                    int power = 1;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            var gm = grid[x - j, y + i];
                            index += (gm.Found && gm.Value || !gm.Found && even) ? power : 0;
                            power *= 2;
                        }
                    }

                    result[x, y] = enhancement[index] == '#';
                }
            }
            Console.WriteLine();
            result.Print();
            return result;
        }


        return Task.CompletedTask;
    }


    public override int Nummer => 202120;
}