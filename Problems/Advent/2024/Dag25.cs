using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Problems.Advent._2024;

internal class Dag25 : Problem
{
    public override async Task ExecuteAsync()
    {
        IList<int[]> keys = new List<int[]>();
        IList<int[]> locks = new List<int[]>();
        long result = 0;
        foreach (var grid in Input.Split($"{Environment.NewLine}{Environment.NewLine}"))
        {
            var array = new int[5];
            foreach (var line in grid.Split(Environment.NewLine))
            {
                foreach (var (value, index) in line.Indexed())
                {
                    if (value == '#')
                    {
                        array[index]++;
                    }
                }
            }

            bool isLock = grid.StartsWith("#");
            var addTo = isLock ? locks : keys;
            var compareTo = isLock ? keys : locks;
            addTo.Add(array);
            foreach (var compare in compareTo)
            {
                if (array.Indexed().All(a => a.item + compare[a.index] < 8))
                {
                    result++;
                }
            }
        }

        Result = result.ToString();
    }
    protected override bool UseTestInput => false;

    protected override string TestInput => @"#####
.####
.####
.####
.#.#.
.#...
.....

#####
##.##
.#.##
...##
...#.
...#.
.....

.....
#....
#....
#...#
#.#.#
#.###
#####

.....
.....
#.#..
###..
###.#
###.#
#####

.....
.....
.....
#....
#.#..
#.#.#
#####";
    public override int Nummer => 202425;
}