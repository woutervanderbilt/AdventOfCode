using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag03 : Problem
{
    private const string testinput = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";
    public override async Task ExecuteAsync()
    {
        long total = 0;
        long total2 = 0;
        IList<string> group = new List<string>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var l = line.Length;
            var r = (line.Substring(0, l / 2), line.Substring(l / 2));
            var intersect = r.Item1.Intersect(r.Item2);
            foreach (var c in intersect.Distinct())
            {
                total += CharValue(c);
            }
            group.Add(line);
            if (group.Count == 3)
            {
                var counter = new Counter<char>();
                foreach (var rucksack in group)
                {
                    foreach (var c in rucksack.Distinct())
                    {
                        counter[c]++;
                    }
                }

                var badge = counter.Keys.Single(k => counter[k] == 3);
                total2 += CharValue(badge);

                group = new List<string>();
            }
        }


        Result = (total, total2).ToString();
    }

    private static long CharValue(char c)
    {
        long s = 0;
        if (c >= 97)
        {
            s += c - 96;
        }
        else
        {
            s += c - 38;
        }

        return s;
    }

    public override int Nummer => 202203;
}