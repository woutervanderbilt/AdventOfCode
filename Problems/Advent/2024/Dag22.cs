using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag22 : Problem
{
    public override Task ExecuteAsync()
    {
        IList<IList<long>> cycles = [];
        IDictionary<long, (int cycle, int index)> dict = new Dictionary<long, (int cycle, int index)>();
        for (int i = 0; i < 16777215; i++)
        {
            if (dict.ContainsKey(i))
            {
                continue;
            }
            IList<long> cycle = new List<long> { i };
            cycles.Add(cycle);
            dict[i] = (cycles.Count - 1, 0);
            var loop = Next(i);
            while (!dict.ContainsKey(loop))
            {
                cycle.Add(loop);
                dict[loop] = (cycles.Count - 1, cycle.Count - 1);
                loop = Next(loop);
            }
        }

        long result = 0;
        foreach (var secret in Input.Split(Environment.NewLine).Select(long.Parse))
        {
            var location = dict[secret];
            var next = cycles[location.cycle][(location.index + 2000) % cycles[location.cycle].Count];
            result += next;
        }

        CounterLong<(long, long, long, long)> counter = new CounterLong<(long, long, long, long)>();

        foreach (var secret in Input.Split(Environment.NewLine).Select(long.Parse))
        {
            IDictionary<(long, long, long, long), long> maxBananas = new Dictionary<(long, long, long, long), long>();
            long current = secret;
            
            var next = Next(current);
            long d1 = next % 10 - current % 10;
            (current, next) = (next, Next(next));
            long d2 = next % 10 - current % 10;
            (current, next) = (next, Next(next));
            long d3 = next % 10 - current % 10;
            (current, next) = (next, Next(next));
            long d4 = next % 10 - current % 10;
            for (int i = 1; i <= 1997; i++)
            {
                (current, next) = (next, Next(next));
                if (!maxBananas.TryGetValue((d1, d2, d3, d4), out _))
                {
                   maxBananas[(d1, d2, d3, d4)] = current % 10;
                }
                (d1, d2, d3, d4) = (d2, d3, d4, next % 10 - current % 10);
            }

            foreach (var maxBanana in maxBananas)
            {
                counter[maxBanana.Key] += maxBanana.Value;
            }
        }

        var result2 = counter.Values.Max();
        Result = (result, result2).ToString();
        return Task.CompletedTask;

        long Next(long secret)
        {
            secret = ((secret << 6) ^ secret) & 16777215;
            secret = ((secret >> 5) ^ secret) & 16777215;
            return ((secret << 11) ^ secret) & 16777215;
        }
    }
    protected override bool UseTestInput => false;

    protected override string TestInput => @"1
2
3
2024";
    public override int Nummer => 202422;
}