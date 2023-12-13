using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2023;

internal class Dag13 : Problem
{
    private const string testinput = @"#.##..##.
..#.##.#.
##......#
##......#
..#.##.#.
..##..##.
#.#.##.#.

#...##..#
#....#..#
..##..###
#####.##.
#####.##.
..##..###
#....#..#";

    public override async Task ExecuteAsync()
    {
        List<Grid<bool>> grids = new List<Grid<bool>>();
        var currentGrid = new Grid<bool>();
        grids.Add(currentGrid);
        string input = await GetInputAsync();
        int y = 0;
        foreach (var line in input.Split(Environment.NewLine))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                currentGrid = new Grid<bool>();
                grids.Add(currentGrid);
                y = 0;
                continue;
            }

            int x = 0;
            foreach (var c in line)
            {
                currentGrid[x, y] = c == '#';
                x++;
            }

            y++;
        }

        long result = 0;
        foreach (var grid in grids)
        {
            bool foundMirror = false;
            for (int xs = 0; xs <= grid.MaxX; xs++)
            {
                for (int ys = 0; ys <= grid.MaxY; ys++)
                {
                    grid[xs, ys] = !grid[xs, ys];
                    var xm = (grid.MinX + grid.MaxX) / 2;
                    var ym = (grid.MinY + grid.MaxY) / 2;
                    var delta = 1;
                    var deltaSign = 1;
                    while (xm >= 0 && xm <= grid.MaxX || ym >= 0 && ym <= grid.MaxY)
                    {
                        bool everythingIsMirrored = true;
                        bool usedSmudge = false;
                        if (xm >= 0 && xm < grid.MaxX)
                        {
                            for (int i = 0; i <= Math.Min(xm, grid.MaxX - xm - 1); i++)
                            {
                                for (int j = 0; j <= grid.MaxY; j++)
                                {
                                    usedSmudge |= (xs, ys) == (xm - i, j);
                                    usedSmudge |= (xs, ys) == (xm +i + 1, j);
                                    if (grid[xm - i, j].Value != grid[xm + i + 1, j].Value)
                                    {
                                        everythingIsMirrored = false;
                                        break;
                                    }
                                }

                                if (!everythingIsMirrored)
                                {
                                    break;
                                }
                            }

                            if (everythingIsMirrored && usedSmudge)
                            {
                                grid.Print();
                                Console.WriteLine($"x: {xm + 1}  {(xs, ys)}");
                                foundMirror = true;
                                result += xm + 1;
                                break;
                            }
                        }

                        if (ym >= 0 && ym < grid.MaxY)
                        {
                            everythingIsMirrored = true;
                            usedSmudge = false;
                            for (int i = 0; i <= Math.Min(ym, grid.MaxY - ym - 1); i++)
                            {
                                for (int j = 0; j <= grid.MaxX; j++)
                                {
                                    usedSmudge |= (xs, ys) == (j, ym - i);
                                    usedSmudge |= (xs, ys) == (j, ym + i + 1);
                                    if (grid[j, ym - i].Value != grid[j, ym + i + 1].Value)
                                    {
                                        everythingIsMirrored = false;
                                        break;
                                    }
                                }

                                if (!everythingIsMirrored)
                                {
                                    break;
                                }
                            }

                            if (everythingIsMirrored && usedSmudge)
                            {
                                grid.Print();
                                Console.WriteLine($"y: {ym + 1}   {(xs, ys)}");
                                foundMirror = true;
                                result += 100 * (ym + 1);
                                break;
                            }
                        }

                        xm += delta * deltaSign;
                        ym += delta * deltaSign;
                        delta++;
                        deltaSign = -deltaSign;
                    }

                    grid[xs, ys] = !grid[xs, ys];
                    if (foundMirror)
                    {
                        break;
                    }
                }

                if (foundMirror)
                {
                    break;
                }
            }
            Console.WriteLine();
        }

        Result = result.ToString();

    }

    public override int Nummer => 202313;
}