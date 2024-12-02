using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2024;

internal class Dag01 : Problem
{
    private const string testinput = @"3   4
4   3
2   5
1   3
3   9
3   3";

    public override async Task ExecuteAsync()
    {
        IList<int> left = [], right = [];
        string input = await GetInputAsync();
        foreach (var line in input.Split(Environment.NewLine))
        {
            var numbers = line.Split("   ").Select(int.Parse).ToArray();
            left.Add(numbers[0]);
            right.Add(numbers[1]);
        }

        var leftSorted = left.OrderBy(i => i).ToArray();
        var rightSorted = right.OrderBy(i => i).ToArray();
        Result = Enumerable.Range(0, left.Count).Sum(i => Math.Abs(leftSorted[i] - rightSorted[i])).ToString();

        Result += " - ";
        Result += left.Sum(i => i * right.Count(j => j == i)).ToString();
    }

    public override int Nummer => 202401;
}