using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag07 : Problem
{
    private const string testinput = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
QQQJA 483";

    public override async Task ExecuteAsync()
    {

        var hands = new List<Hand>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var split = line.Split(' ');
            hands.Add(new Hand { Cards = split[0], Bid = long.Parse(split[1]) });
        }

        long result = 0;
        int index = 1;
        foreach (var hand in hands.OrderBy(h => h.Value()))
        {
            result += index * hand.Bid;
            index++;
        }
        long result2 = 0;
        index = 1;
        foreach (var hand in hands.OrderBy(h => h.Value(true)))
        {
            result2 += index * hand.Bid;
            index++;
        }

        Result = (result, result2).ToString();
    }

    private class Hand
    {
        private const string CardValues = "23456789TJQKA";
        private const string JokerValues = "J23456789TQKA";
        public string Cards { get; set; }
        public long Bid { get; set; }

        public long Value(bool jokers = false)
        {
            long value = 0;
            long f = 1;
            var counter = new Counter<char>();
            int jokerCount = 0;
            foreach (var card in Cards.Reverse())
            {
                if (jokers && card == 'J')
                {
                    jokerCount++;
                }
                else
                {
                    counter[card]++;
                }
                value += (jokers ? JokerValues : CardValues).IndexOf(card) * f;
                f *= 100;
            }

            if (counter.Values.Count() == 1 || jokerCount == 5)
            {
                value += f * 7;
            }
            else if (counter.Values.Any(v => v + jokerCount == 4))
            {
                value += f * 6;
            }
            else if (counter.Values.Any(v => v == 3) && counter.Values.Any(v => v == 2)
                     || jokerCount == 1 && counter.Values.Count(v => v == 2) == 2)
            {
                value += f * 5;
            }
            else if (counter.Values.Any(v => v + jokerCount == 3))
            {
                value += f * 4;
            }
            else if (counter.Values.Count(v => v == 2) == 2)
            {
                value += f * 3;
            }
            else if (counter.Values.Any(v => v + jokerCount == 2))
            {
                value += f * 2;
            }

            return value;
        }
    }

    public override int Nummer => 202307;
}