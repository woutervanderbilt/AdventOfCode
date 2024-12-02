using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Problems.Advent._2024;

internal class Dag02 : Problem
{
    private const string testinput = @"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9";

    public override async Task ExecuteAsync()
    {
        IList<IList<int>> lists = [];
        string input = await GetInputAsync();
        foreach (var line in input.Split(Environment.NewLine))
        {
            lists.Add(line.Split(' ').Select(int.Parse).ToList());
        }

        Result = lists.Count(l => IsSafe(l, true)).ToString();

        bool IsSafe(IList<int> list, bool canRemove)
        {
            var diffs = list.Zipper((a,b) => b - a).ToList();
            if (diffs.All(d => d == 1 || d == 2 || d == 3) || diffs.All(d => d == -1 || d == -2 || d == -3))
            {
                return true;
            }

            if (canRemove)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var copy = list.ToList();
                    copy.RemoveAt(i);
                    if (IsSafe(copy, false))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

    public override int Nummer => 202402;
}