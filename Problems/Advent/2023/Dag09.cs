using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag09 : Problem
{
    public override async Task ExecuteAsync()
    {
        IList<IList<long>> oasis = new List<IList<long>>();
        string input = await GetInputAsync();
        foreach (var line in input.Split(Environment.NewLine))
        {
                oasis.Add(line.Split(' ').Select(long.Parse).ToList());
        }

        long result = 0;
        long result2 = 0;
        foreach (var history in oasis)
        {
            IList<IList<long>> deltas = new List<IList<long>> { history };
            var current = history;
            while (current.Any(c => c != 0))
            {
                var newCurrent = new List<long>();
                long? prev = null; 
                foreach (var v in current)
                {
                    if (prev.HasValue)
                    {
                        newCurrent.Add(v - prev.Value);
                    }

                    prev = v;
                }

                current = newCurrent;
                deltas.Add(current);
            }

            result += deltas.Sum(d => d.Last());
            var lastHistory = deltas.Last();
            foreach (var h in deltas.Reverse().Skip(1))
            {
                h.Insert(0, h[0] - lastHistory[0]);
                lastHistory = h;
            }

            result2 += deltas[0][0];
        }

       

        Result = (result, result2).ToString();
    }

    public override int Nummer => 202309;
}