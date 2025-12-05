using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2025;
internal class Dag05 : Problem
{
    public override Task ExecuteAsync()
    {
        IList<(long, long)> ranges = [];
        IList<long> ids = [];
        bool readingRanges = true;
        foreach (var line in Input.Split(Environment.NewLine))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                readingRanges = false;
            }
            else if (readingRanges)
            {
                var split = line.Split('-');
                ranges.Add((long.Parse(split[0]), long.Parse(split[1])));
            }
            else
            {
                ids.Add(long.Parse(line));
            }
        }

        long result = 0;
        long result2 = 0;
        foreach (var id in ids)
        {
            if (ranges.Any(r => r.Item1 <= id && r.Item2 >= id))
            {
                result++;
            }
        }

        ranges = ranges.OrderBy(r => r.Item1).ThenBy(r => r.Item2).ToList();

        long currentStart = 0;
        long currentEnd = 0;
        foreach (var range in ranges)
        {
            if (range.Item1 <= currentEnd)
            {
                currentEnd = Math.Max(currentEnd, range.Item2);
            }
            else
            {
                Console.WriteLine((currentStart, currentEnd, currentEnd - currentStart + 1));
                result2 += currentEnd - currentStart + 1;
                currentStart = range.Item1;
                currentEnd = range.Item2;
            }
        }

        Console.WriteLine((currentStart, currentEnd, currentEnd - currentStart + 1));
        result2 += currentEnd - currentStart;
        Result = (result, result2).ToString();

        return Task.CompletedTask;
    }
    protected override string TestInput => @"3-5
10-14
16-20
12-18

1
5
8
11
17
32";

    protected override bool UseTestInput => false;
    public override int Nummer => 202505;
}