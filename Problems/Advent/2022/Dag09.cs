using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Problems.Advent._2022
{
    internal class Dag09 : Problem
    {
        public override async Task ExecuteAsync()
        {
            var input = await GetInputAsync();
            int knotcount = 10;

            Result = input.Split(Environment.NewLine)
                .Select(s => s.Split())
                .SelectMany(w => Enumerable.Repeat(ParseDirection(w[0]), int.Parse(w[1])))
                .AggregateList((IList<(int, int)>)Enumerable.Repeat((0, 0), knotcount).ToList(), ApplyMove)
                .Select(r => r.Last())
                .Distinct()
                .Count()
                .ToString();

            (int, int) ParseDirection(string direction)
            {
                return direction switch
                {
                    "R" => (1, 0),
                    "L" => (-1, 0),
                    "U" => (0, 1),
                    "D" => (0, -1)
                };
            }

            IList<(int, int)> ApplyMove(IList<(int, int)> rope, (int, int) move)
            {
                return rope.Skip(1)
                    .AggregateList((rope[0].Item1 + move.Item1, rope[0].Item2 + move.Item2), MoveTail);
            }

            (int, int) MoveTail((int, int) head, (int, int) tail)
            {
                var dx = head.Item1 - tail.Item1;
                var dy = head.Item2 - tail.Item2;

                var distance = Math.Max(Math.Abs(head.Item1 - tail.Item1), Math.Abs(head.Item2 - tail.Item2));
                if (distance > 1)
                {
                    return (tail.Item1 + Math.Sign(dx), tail.Item2 + Math.Sign(dy));
                }

                return tail;

            }
        }

        public override int Nummer => 202209;
    }
}
