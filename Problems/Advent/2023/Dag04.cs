using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2023;

internal class Dag04 : Problem
{
    private const string testinput = @"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";
    public override async Task ExecuteAsync()
    {
        string input = await GetInputAsync();
        long result = 0;
        CounterLong<int> counter = new CounterLong<int>();
        IList<long> wins = new List<long>();
        IList<long> numberOfCopys = new List<long>();
        foreach (var line in input.Split(Environment.NewLine))
        {
            var split = line.Split(':');
            var values = split[1].Split('|');
            var winning = values[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var card = values[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var winCount = card.Count(v => winning.Contains(v));
            if (winCount >= 1)
            {
                result += (long)Math.Pow(2, winCount - 1);
            }
            wins.Add(winCount);
            numberOfCopys.Add(1);
        }

        for (int i = 0; i < numberOfCopys.Count; i++)
        {
            WinCards(i);
        }

        long result2 = numberOfCopys.Sum();


        Result = (result, result2).ToString();

        void WinCards(int index)
        {
            var count = numberOfCopys[index];
            for (int i = index + 1; i <= index + wins[index]; i++)
            {
                numberOfCopys[i] += count;
            }
        }
    }

    public override int Nummer => 202304;
}