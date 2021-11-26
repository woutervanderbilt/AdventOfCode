using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2015
{
    internal class Dag15 : Problem
    {
        private const string input = @"Sprinkles: capacity 5, durability -1, flavor 0, texture 0, calories 5
PeanutButter: capacity -1, durability 3, flavor 0, texture 0, calories 1
Frosting: capacity 0, durability -1, flavor 4, texture 0, calories 6
Sugar: capacity -1, durability 0, flavor 0, texture 2, calories 8";
        public override Task ExecuteAsync()
        {
            var ingredients = input.Split(Environment.NewLine).Select(l =>
            {
                var words = l.Replace(",","").Split(' ');
                return (long.Parse(words[2]), long.Parse(words[4]), long.Parse(words[6]), long.Parse(words[8]),
                    long.Parse(words[10]));
            }).ToList();

            var max = 0L;

            for (long i1 = 0; i1 <= 100; i1++)
            {
                for (long i2 = 0; i1 + i2 <= 100; i2++)
                {
                    for (long i3 = 0; i1 + i2 + i3 <= 100; i3++)
                    {
                        var i4 = 100 - i1 - i2 - i3;
                        var p1 = Math.Max(0, ingredients[0].Item1 * i1 + ingredients[1].Item1 * i2 + ingredients[2].Item1 * i3 + ingredients[3].Item1 * i4);
                        var p2 = Math.Max(0, ingredients[0].Item2 * i1 + ingredients[1].Item2 * i2 + ingredients[2].Item2 * i3 + ingredients[3].Item2 * i4);
                        var p3 = Math.Max(0, ingredients[0].Item3 * i1 + ingredients[1].Item3 * i2 + ingredients[2].Item3 * i3 + ingredients[3].Item3 * i4);
                        var p4 = Math.Max(0, ingredients[0].Item4 * i1 + ingredients[1].Item4 * i2 + ingredients[2].Item4 * i3 + ingredients[3].Item4 * i4);
                        var p5 = Math.Max(0, ingredients[0].Item5 * i1 + ingredients[1].Item5 * i2 + ingredients[2].Item5 * i3 + ingredients[3].Item5 * i4);
                        if (p5 == 500)
                        {
                            long total = p1 * p2 * p3 * p4;
                            if (total > max)
                            {
                                max = total;
                            }
                        }
                    }

                }
            }

            Result = max.ToString();
            return Task.CompletedTask;
        }

        public override int Nummer => 201515;
    }
}
