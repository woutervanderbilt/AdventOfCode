using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2024;

internal class Dag02 : Problem
{
    public override async Task ExecuteAsync()
    {
        IList<IList<int>> lists = [];

        foreach (var line in Input.Split(Environment.NewLine))
        {
            lists.Add(line.Split(' ').Select(int.Parse).ToList());
        }

        Result = lists.Count(l => IsSafe(l, true)).ToString();

        bool IsSafe(IList<int> list, bool canRemove)
        {
            var diffs = list.Zipper((a, b) => b - a).ToList();
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