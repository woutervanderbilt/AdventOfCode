using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag04 : Problem
{
    public override async Task ExecuteAsync()
    {
        var input = await GetInputAsync();
        int result = 0;
        int result2 = 0;
        foreach (var line in input.Split(Environment.NewLine))
        {
            var ranges = line.Split(',');
            var r1 = ranges[0].Split('-');
            var r2 = ranges[1].Split('-');
            var r1min = int.Parse(r1[0]);
            var r1max = int.Parse(r1[1]);
            var r2min = int.Parse(r2[0]);
            var r2max = int.Parse(r2[1]);
            if (r1min <= r2min && r1max >= r2max || r1min >= r2min && r1max <= r2max)
            {
                result++;
            }

            if (r1min <= r2max && r1max >= r2min)
            {
                result2++;
            }
        }

        Result = (result, result2).ToString();
    }

    public override int Nummer => 202204;
}