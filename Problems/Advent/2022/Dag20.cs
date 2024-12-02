using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag20 : Problem
{
    private const string testinput = @"1
2
-3
3
-2
0
4";

    public override async Task ExecuteAsync()
    {
        IList<Number> list = new List<Number>();
        Number? prev = null;
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var number = new Number { Value = long.Parse(line) * 811589153 };
            if (prev != null)
            {
                prev.Next = number;
                number.Previous = prev;
            }
            list.Add(number);
            prev = number;
        }

        list.Last().Next = list.First();
        list.First().Previous = list.Last();

        for (int j = 1; j <= 10; j++)
        {
            foreach (var number in list)
            {
                //var loop = number.Next;
                //while (loop != number)
                //{
                //    Console.Write($"{loop.Value}, ");
                //    loop = loop.Next;
                //}
                //Console.Write($"{number.Value}, ");
                //Console.WriteLine();
                var move = number.Value % (list.Count - 1);
                if (move == 0)
                {
                    continue;
                }

                if (move < 0)
                {
                    move = list.Count + move - 1;
                }

                var current = number;
                for (int i = 1; i <= move; i++)
                {
                    current = current.Next;
                }

                number.Remove();
                number.InsertThisNumberAfter(current);
            }
        }

        long result = 0;
        var target = list.Single(n => n.Value == 0);
        for (int i = 1; i <= 3000; i++)
        {
            target = target.Next;
            if (i % 1000 == 0)
            {
                result += target.Value;
            }
        }

        Result = result.ToString();
    }

    public override int Nummer => 202220;

    private class Number
    {
        public long Value { get; set; }
        public Number Next { get; set; }
        public Number Previous { get; set; }

        public void Remove()
        {
            Previous.Next = Next;
            Next.Previous = Previous;
        }

        public void InsertThisNumberAfter(Number number)
        {
            number.Next.Previous = this;
            Next = number.Next;
            Previous = number;
            number.Next = this;
        }

        public override string ToString()
        {
            return $"{Value}  ({(Previous.Value, Next.Value)}";
        }
    }
}