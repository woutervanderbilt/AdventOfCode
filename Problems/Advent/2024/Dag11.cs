using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag11 : Problem
{
    public override async Task ExecuteAsync()
    {
        CounterLong<long> counter = new();
        foreach (var stone in Input.Split(' ').Select(long.Parse))
        {
            counter[stone]++;
        }

        long result1 = 0;
        for (int i = 1; i <= 75; i++)
        {
            var newCounter = new CounterLong<long>();
            foreach (var stone in counter.Keys)
            {
                var count = counter[stone];
                foreach (var newStone in Blink(stone))
                {
                    newCounter[newStone] += count;
                }
            }
            counter = newCounter;
            if (i == 25)
            {
                result1 = counter.Values.Sum();
            }
        }
        Result = (result1, counter.Values.Sum()).ToString();


        IEnumerable<long> Blink(long stone)
        {
            if (stone == 0)
            {
                yield return 1;
                yield break;
            }
            var stoneAsString = stone.ToString();
            if (stoneAsString.Length % 2 == 0)
            {
                yield return long.Parse(stoneAsString.Substring(0, stoneAsString.Length / 2));
                yield return long.Parse(stoneAsString.Substring(stoneAsString.Length / 2, stoneAsString.Length / 2));
            }
            else
            {
                yield return stone * 2024;
            }
        }
    }

    protected override bool UseTestInput => false;
    protected override string TestInput => @"125 17";

    public override int Nummer => 202411;
}