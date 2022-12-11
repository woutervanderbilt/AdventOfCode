using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Algorithms;

namespace Problems.Advent._2022
{
    internal class Dag11 : Problem
    {
        private const string input = @"Monkey 0:
  Starting items: 54, 61, 97, 63, 74
  Operation: new = old * 7
  Test: divisible by 17
    If true: throw to monkey 5
    If false: throw to monkey 3

Monkey 1:
  Starting items: 61, 70, 97, 64, 99, 83, 52, 87
  Operation: new = old + 8
  Test: divisible by 2
    If true: throw to monkey 7
    If false: throw to monkey 6

Monkey 2:
  Starting items: 60, 67, 80, 65
  Operation: new = old * 13
  Test: divisible by 5
    If true: throw to monkey 1
    If false: throw to monkey 6

Monkey 3:
  Starting items: 61, 70, 76, 69, 82, 56
  Operation: new = old + 7
  Test: divisible by 3
    If true: throw to monkey 5
    If false: throw to monkey 2

Monkey 4:
  Starting items: 79, 98
  Operation: new = old + 2
  Test: divisible by 7
    If true: throw to monkey 0
    If false: throw to monkey 3

Monkey 5:
  Starting items: 72, 79, 55
  Operation: new = old + 1
  Test: divisible by 13
    If true: throw to monkey 2
    If false: throw to monkey 1

Monkey 6:
  Starting items: 63
  Operation: new = old + 4
  Test: divisible by 19
    If true: throw to monkey 7
    If false: throw to monkey 4

Monkey 7:
  Starting items: 72, 51, 93, 63, 80, 86, 81
  Operation: new = old * old
  Test: divisible by 11
    If true: throw to monkey 0
    If false: throw to monkey 4";

        public override Task ExecuteAsync()
        {
            Monkey currentMonkey = null;
            IList<Monkey> monkeys = new List<Monkey>();

            foreach (var line in input.Split(Environment.NewLine))
            {
                if (line.StartsWith("Monkey"))
                {
                    currentMonkey = new Monkey
                    {
                        Number = int.Parse(line.Substring(7, 1))
                    };
                    monkeys.Add(currentMonkey);
                }
                else
                {
                    var words = line.Split().ToList();
                    if (words.Any(w => w == "Starting"))
                    {
                        foreach (var word in words)
                        {
                            if (int.TryParse(word.Replace(",", ""), out var item))
                            {
                                currentMonkey.Items.Add(item);
                            }
                        }
                    }
                    else if(words.Any(w => w == "Operation:"))
                    {
                        currentMonkey.Operation = currentMonkey.Number switch
                        {
                            0 => old => old * 7,
                            1 => old => old + 8,
                            2 => old => old * 13,
                            3 => old => old + 7,
                            4 => old => old + 2,
                            5 => old => old + 1,
                            6 => old => old + 4,
                            7 => old => old * old,
                        };
                    }
                    else if (words.Any(w => w == "Test:"))
                    {
                        currentMonkey.DivisibilityTest = int.Parse(words.Last());
                    }
                    else if (words.Any(w => w == "true:"))
                    {
                        currentMonkey.ThrowToIfTrue = int.Parse(words.Last());
                    }
                    else if (words.Any(w => w == "false:"))
                    {
                        currentMonkey.ThrowToIfFalse = int.Parse(words.Last());
                    }
                }
            }

            var lcm = monkeys.Aggregate(1L, (a, b) => EulerMath.LCM(a, b.DivisibilityTest));


            for (int i = 1; i <= 10000; i++)
            {
                Round();
            }

            var inspections = monkeys.Select(m => m.NumberOfInspections).OrderByDescending(n => n).ToList();
            Result = (inspections[0] * inspections[1]).ToString();


            void Round()
            {
                foreach (var monkey in monkeys)
                {
                    foreach (var item in monkey.Items)
                    {
                        monkey.NumberOfInspections++;
                        var newWorryLevel = monkey.Operation(item);
                        //newWorryLevel /= 3;
                        newWorryLevel %= lcm;
                        if (newWorryLevel % monkey.DivisibilityTest == 0)
                        {
                            monkeys[monkey.ThrowToIfTrue].Items.Add(newWorryLevel);
                        }
                        else
                        {
                            monkeys[monkey.ThrowToIfFalse].Items.Add(newWorryLevel);
                        }
                    }
                    monkey.Items.Clear();
                }
            }

            return Task.CompletedTask;
        }


        private class Monkey
        {
            public int Number { get; set; }
            public IList<long> Items { get; set; } = new List<long>();
            public Func<long, long> Operation { get; set; }

            public int DivisibilityTest { get; set; }

            public int ThrowToIfTrue { get; set; }
            public int ThrowToIfFalse { get; set; }
            public long NumberOfInspections { get; set; }
        }

        public override int Nummer => 202211;
    }
}
