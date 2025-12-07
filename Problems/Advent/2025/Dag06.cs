using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Problems.Advent._2025;
internal class Dag06 : Problem
{
    public override Task ExecuteAsync()
    {
        IList<IList<long>> numbers = [];
        IList<string> operations = [];
        IList<IList<long>> numbers2 = [];
        var splitLines = Input.Split(Environment.NewLine);
        foreach (var line in splitLines)
        {
            if (line.Contains('+'))
            {
                foreach (var o in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                {
                    operations.Add(o);
                }
            }
            else
            {
                foreach (var (n, i) in line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Indexed())
                {
                    if (numbers.Count < i + 1)
                    {
                        numbers.Add([]);
                    }
                    numbers[i].Add(long.Parse(n));
                }
            }
        }

        IList<long> c = [];
        for (int i = 0; i < splitLines[0].Length; i++)
        {
            if (splitLines[^1][i] != ' ')
            {
                c = [];
                numbers2.Add(c);
            }

            long n = 0;
            for (int j = 0; j < splitLines.Length - 1; j++)
            {
                var d = splitLines[j][i];
                if (d != ' ')
                {
                    n = 10 * n + long.Parse(d.ToString());
                }
            }

            if (n != 0)
            {
                c.Add(n);
            }
        }


            long result = 0;
        long result2 = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            result += operations[i] == "*" ? numbers[i].Product() : numbers[i].Sum();
            result2 += operations[i] == "*" ? numbers2[i].Product() : numbers2[i].Sum();
        }

        Result = (result, result2).ToString();
        return Task.CompletedTask;
    }
    protected override string TestInput => @"123 328  51 64 
 45 64  387 23 
  6 98  215 314
*   +   *   +  ";

    protected override bool UseTestInput => false;
    public override int Nummer => 202506;
}