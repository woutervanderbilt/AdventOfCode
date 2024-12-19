using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag19 : Problem
{
    public override async Task ExecuteAsync()
    {
        var availablePatterns = new HashSet<string>(Input.Split(Environment.NewLine)[0].Split(',').OrderBy(p => p.Length).Select(p => p.Trim()));
        var cache = new Dictionary<string, long>();

        long count = 0;
        long totalCount = 0;
        foreach (var line in Input.Split(Environment.NewLine).Skip(2))
        {
            var towelCount = MakeTowel(line);
            totalCount += towelCount;
            if (towelCount > 0)
            {
                count++;
            }
        }
        Result = (count, totalCount).ToString();

        long MakeTowel(string target)
        {
            if (cache.TryGetValue(target, out var res))
            {
                return res;
            }

            res = 0;
            foreach (var pattern in availablePatterns)
            {
                if (target == pattern)
                {
                    res++;
                }
                else if (target.StartsWith(pattern))
                {
                    res += MakeTowel(target.Substring(pattern.Length));
                }
            }
            cache[target] = res;
            return res;
        }
    }

    protected override bool UseTestInput => false;

    protected override string TestInput => @"r, wr, b, g, bwu, rb, gb, br

brwrr
bggr
gbbr
rrbgbr
ubwu
bwurrg
brgr
bbrgwb";
    public override int Nummer => 202419;
}