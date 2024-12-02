using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag21 : Problem
{
    public override async Task ExecuteAsync()
    {
        long low = 0;
        long high = 1;
        long shout = 1;
        while (true)
        {
            IDictionary<string, Monkey> monkeys = new Dictionary<string, Monkey>();
            foreach (var line in Input.Split(Environment.NewLine))
            {
                var words = line.Split();
                var name = words[0].Replace(":", "");
                var monkey = GetMonkey(name);
                if (words.Length == 2)
                {
                    monkey.Number = name == "humn" ? shout : long.Parse(words[1]);
                }
                else
                {
                    monkey.Lhs = GetMonkey(words[1]);
                    monkey.Rhs = GetMonkey(words[3]);
                    monkey.Lhs!.SendsTo.Add(monkey);
                    monkey.Rhs!.SendsTo.Add(monkey);
                    monkey.Operation = words[2] switch
                    {
                        "+" => (a, b) => a + b,
                        "-" => (a, b) => a - b,
                        "*" => (a, b) => a * b,
                        "/" => (a, b) => a / b
                    };
                }
            }

            Monkey GetMonkey(string monkeyName)
            {
                Monkey result;
                if (!monkeys.TryGetValue(monkeyName, out result))
                {
                    result = new Monkey { Name = monkeyName };
                    monkeys[monkeyName] = result;
                }

                return result;
            }

            var nextMonkeys = new HashSet<Monkey>(monkeys.Values.Where(m => m.Number.HasValue));
            while (nextMonkeys.Any())
            {
                bool stop = false;
                var newNextMonkeys = new HashSet<Monkey>();
                foreach (var monkey in nextMonkeys)
                {
                    if (monkey.Lhs != null && monkey.Rhs != null
                                           && monkey.Lhs.Number.HasValue && monkey.Rhs.Number.HasValue)
                    {
                        monkey.Number = monkey.Operation!(monkey.Lhs.Number!.Value, monkey.Rhs.Number!.Value);
                        if (monkey.Name == "root")
                        {
                            //Result = monkey.Number.ToString();
                            //return Task.CompletedTask;
                            if (monkey.Lhs.Number == monkey.Rhs.Number)
                            {
                                Result = shout.ToString();
                                return;
                            }
                            else
                            {
                                var diff = monkey.Lhs.Number - monkey.Rhs.Number;
                                //Console.WriteLine((shout, diff));
                                if (diff > 0)
                                {
                                    if (shout == high)
                                    {
                                        shout *= 10;
                                        high = shout;
                                    }
                                    else
                                    {
                                        low = shout;
                                        shout = (shout + high) / 2;
                                    }
                                }
                                else
                                {
                                    high = shout;
                                    shout = (low + shout) / 2;
                                }
                                stop = true;
                                break;
                            }
                        }
                    }

                    if (monkey.Number.HasValue)
                    {
                        foreach (var listener in monkey.SendsTo.Where(m => !m.Number.HasValue))
                        {
                            newNextMonkeys.Add(listener);
                        }
                    }
                }

                if (stop)
                {
                    break;
                }
                nextMonkeys = newNextMonkeys;
            }
        }
    }

    private class Monkey
    {
        public string Name { get; set; }
        public long? Number { get; set; }
        public Monkey? Lhs { get; set; }
        public Monkey? Rhs { get; set; }
        public Func<long, long, long>? Operation { get; set; }
        public IList<Monkey> SendsTo { get; set; } = new List<Monkey>();

        public override bool Equals(object obj)
        {
            return Equals((Monkey)obj);
        }

        protected bool Equals(Monkey other)
        {
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }


    public override int Nummer => 202221;
}