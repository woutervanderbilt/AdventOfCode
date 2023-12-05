using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2022;

internal class Dag08 : Problem
{
    private const string testinput = @"30373
25512
65332
33549
35390";

    public override async Task ExecuteAsync()
    {
        var input = await GetInputAsync();
        var grid = new Grid<int>();
        {
            int y = 0;
            foreach (var line in input.Split(Environment.NewLine))
            {
                int x = 0;
                foreach (var c in line)
                {
                    int tree = int.Parse(c.ToString());
                    grid[x, y] = tree;
                    x++;
                }

                y++;
            }
        }

        HashSet<(int, int)> visibleTrees = new HashSet<(int, int)>();

        //for (int x = 0; x <= grid.MaxX; x++)
        //{
        //    int height = -1;
        //    for (int y = 0; y <= grid.MaxY; y++)
        //    {
        //        var tree = grid[x, y];
        //        if (tree > height)
        //        {
        //            visibleTrees.Add((x, y));
        //            height = tree;
        //        }
        //    }
        //    height = -1;
        //    for (int y = grid.MaxY; y >= 0; y--)
        //    {
        //        var tree = grid[x, y];
        //        if (tree > height)
        //        {
        //            visibleTrees.Add((x, y));
        //            height = tree;
        //        }
        //    }
        //}

        //for (int x = grid.MaxX; x >= 0; x--)
        //{
        //    int height = -1;
        //    for (int y = 0; y <= grid.MaxY; y++)
        //    {
        //        var tree = grid[x, y];
        //        if (tree > height)
        //        {
        //            visibleTrees.Add((x, y));
        //            height = tree;
        //        }
        //    }
        //    height = -1;
        //    for (int y = grid.MaxY; y >= 0; y--)
        //    {
        //        var tree = grid[x, y];
        //        if (tree > height)
        //        {
        //            visibleTrees.Add((x, y));
        //            height = tree;
        //        }
        //    }
        //}

        //for (int y = 0; y <= grid.MaxY; y++)
        //{
        //    int height = -1;
        //    for (int x = 0; x <= grid.MaxX; x++)
        //    {
        //        var tree = grid[x, y];
        //        if (tree > height)
        //        {
        //            visibleTrees.Add((x, y));
        //            height = tree;
        //        }
        //    }
        //    height = -1;
        //    for (int x = grid.MaxX; x >= 0; x--)
        //    {
        //        var tree = grid[x, y];
        //        if (tree > height)
        //        {
        //            visibleTrees.Add((x, y));
        //            height = tree;
        //        }
        //    }
        //}

        //for (int y = grid.MaxY; y >= 0; y--)
        //{
        //    int height = -1;
        //    for (int x = 0; x <= grid.MaxX; x++)
        //    {
        //        var tree = grid[x, y];
        //        if (tree > height)
        //        {
        //            visibleTrees.Add((x, y));
        //            height = tree;
        //        }
        //    }
        //    height = -1;
        //    for (int x = grid.MaxX; x >= 0; x--)
        //    {
        //        var tree = grid[x, y];
        //        if (tree > height)
        //        {
        //            visibleTrees.Add((x, y));
        //            height = tree;
        //        }
        //    }
        //}

        long maxScore = 0;

        for (int x = 0; x <= grid.MaxX; x++)
        {
            for (int y = 0; y <= grid.MaxY; y++)
            {
                long score = 1;
                var tree = grid[x, y];
                int xx = x - 1;
                while (xx >= 0 && grid[xx, y] < tree)
                {
                    xx--;
                }

                score *= x - xx - (xx < 0 ?  1 : 0);

                xx = x + 1;
                while (xx <= grid.MaxY && grid[xx, y] < tree)
                {
                    xx++;
                }

                score *= xx - x - (xx > grid.MaxX ? 1 : 0);

                int yy = y - 1;
                while (yy >= 0 && grid[x, yy] < tree)
                {
                    yy--;
                }

                score *= y - yy - (yy < 0 ? 1 : 0);

                yy = y + 1;
                while (yy <= grid.MaxY && grid[x, yy] < tree)
                {
                    yy++;
                }

                score *= yy - y - (yy > grid.MaxY ? 1 : 0);

                if (score > maxScore)
                {
                    maxScore = score;
                }
            }
                
        }

        Result = maxScore.ToString();
    }

    public override int Nummer => 202208;
}