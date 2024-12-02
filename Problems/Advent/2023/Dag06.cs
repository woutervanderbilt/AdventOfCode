using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag06 : Problem
{
    public override async Task ExecuteAsync()
    {

        var times = new List<long>();
        var distances = new List<long>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            if (line.StartsWith("Time:"))
            {
                times.AddRange(line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse));
            }
            else
            {
                distances.AddRange(line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse));
            }
        }

        long result = 1;
        for (int i = 0; i < times.Count; i++)
        {
            long count = 0;
            for (int j = 0; j <= times[i]; j++)
            {
                if (j * (times[i] - j) > distances[i])
                {
                    count++;
                }
            }

            result *= count;
        }

        long time = 47986698;
        long distance = 400121310111540;
        var x = (long)Math.Ceiling((time - Math.Sqrt(time * time - 4 * distance)) / 2);
        long result2 = time + 1 - 2 * x;

        Result = (result, result2).ToString();
    }

    public override int Nummer => 202306;
}

