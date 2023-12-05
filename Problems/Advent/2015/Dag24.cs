using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Problems.Advent._2015;

internal class Dag24 : Problem
{
    private const string input = @"1
3
5
11
13
17
19
23
29
31
41
43
47
53
59
61
67
71
73
79
83
89
97
101
103
107
109
113";

    public override Task ExecuteAsync()
    {
        var values = input.Split(Environment.NewLine).Select(long.Parse).ToList();
        var total = values.Sum();
        var target = total / 4;

        var subsets = Subsets(new List<long>(), 0, 0);
        var min = subsets.Min(s => s.Count);
        subsets = subsets.Where(s => s.Count == min).OrderBy(s => s.Product()).ToList();
        Result = subsets[0].Product().ToString();

        IList<IList<long>> Subsets(IList<long> start, int index, long sum)
        {
            var result = new List<IList<long>>();
            for (int i = index; i < values.Count; i++)
            {
                var value = values[i];
                if (sum + value == target)
                {
                    var copy = start.ToList();
                    copy.Add(value);
                    result.Add(copy);
                }
                else if (value + sum < target)
                {
                    var copy = start.ToList();
                    copy.Add(value);
                    result.AddRange(Subsets(copy, i + 1, value + sum));
                }
            }
                
            return result;
        }



        return Task.CompletedTask;
    }

    public override int Nummer => 201524;
}