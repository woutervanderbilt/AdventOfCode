using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2019;

public class Dag24 : Problem
{
    private const string input = @".##.#
###..
#...#
##.#.
.###.";

    private const string testinput = @"....#
#..#.
#..##
..#..
#....";
    public override Task ExecuteAsync()
    {
        IDictionary<int, IDictionary<(int,int), bool>> bugs = new Dictionary<int, IDictionary<(int, int), bool>>();
        int i = 0;
        var levelZeroBugs = new Dictionary<(int,int), bool>();
        foreach (var line in input.Split(new []{Environment.NewLine}, StringSplitOptions.None))
        {
            int j = 0;
            foreach (var location in line)
            {
                levelZeroBugs[(i, j)] = location == '#';
                j++;
            }

            i++;
        }

        bugs[-1] = EmptyLevel();
        bugs[0] = levelZeroBugs;
        bugs[1] = EmptyLevel();

        for (int s = 1; s <= 200; s++)
        {
            bugs = Step(bugs);
        }

        long result = 0;
        foreach (var bug in bugs.Values)
        {
            result += bug.Values.Count(b => b);
        }

        return Task.CompletedTask;
    }
        
    IDictionary<int, IDictionary<(int, int), bool>> Step(IDictionary<int, IDictionary<(int, int), bool>> input)
    {
        var result = new Dictionary<int, IDictionary<(int, int), bool>>();
        var minLevel = input.Keys.Min();
        var maxLevel = input.Keys.Max();
        result[minLevel - 1] = EmptyLevel();
        foreach (var level in input.Keys.OrderBy(k => k))
        {
            var newLevel = new Dictionary<(int, int), bool>();
            result[level] = newLevel;
            var currentLevel = input[level];
            foreach (var b in currentLevel)
            {
                int n = NumberOfBugNeighbors();
                if (b.Value)
                {
                    newLevel[b.Key] = n == 1;
                }
                else
                {
                    newLevel[b.Key] = n == 1 || n == 2;
                }

                int NumberOfBugNeighbors()
                {
                    int count = 0;
                    var i = b.Key.Item1;
                    var j = b.Key.Item2;
                    if (i == 2 && j == 2)
                    {
                        return 0;
                    }
                    var previousLevel = input.ContainsKey(level - 1) ? input[level - 1] : null;
                    var nextLevel = input.ContainsKey(level + 1) ? input[level + 1] : null;
                    if (i > 0)
                    {
                        count += currentLevel[(i - 1, j)] ? 1 : 0;
                    }
                    else if(previousLevel != null)
                    {
                        count += previousLevel[(1, 2)] ? 1 : 0;
                    }

                    if (i < 4)
                    {
                        count += currentLevel[(i + 1, j)] ? 1 : 0;
                    }
                    else if (previousLevel != null)
                    {
                        count += previousLevel[(3, 2)] ? 1 : 0;
                    }
                    if (j > 0)
                    {
                        count += currentLevel[(i, j - 1)] ? 1 : 0;
                    }
                    else if (previousLevel != null)
                    {
                        count += previousLevel[(2, 1)] ? 1 : 0;
                    }

                    if (j < 4)
                    {
                        count += currentLevel[(i, j + 1)] ? 1 : 0;
                    }
                    else if (previousLevel != null)
                    {
                        count += previousLevel[(2, 3)] ? 1 : 0;
                    }

                    if (nextLevel != null)
                    {
                        if (i == 1 && j == 2)
                        {
                            for (int k = 0; k < 5; k++)
                            {
                                if (nextLevel[(0, k)])
                                {
                                    count++;
                                }
                            }
                        }
                        else if (i == 2 && j == 1)
                        {
                            for (int k = 0; k < 5; k++)
                            {
                                if (nextLevel[(k, 0)])
                                {
                                    count++;
                                }
                            }
                        }
                        else if (i == 2 && j == 3)
                        {
                            for (int k = 0; k < 5; k++)
                            {
                                if (nextLevel[(k, 4)])
                                {
                                    count++;
                                }
                            }
                        }
                        else if (i == 3 && j == 2)
                        {
                            for (int k = 0; k < 5; k++)
                            {
                                if (nextLevel[(4, k)])
                                {
                                    count++;
                                }
                            }
                        }
                    }




                    return count;
                }
            }
        }

        result[maxLevel + 1] = EmptyLevel();
        return result;
    }

    private IDictionary<(int, int), bool> EmptyLevel()
    {
        var result = new Dictionary<(int,int),bool>();
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                result[(i, j)] = false;
            }
        }

        return result;
    }


    public override int Nummer => 201924;
}