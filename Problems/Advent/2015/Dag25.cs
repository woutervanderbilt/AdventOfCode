using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2015
{
    internal class Dag25 : Problem
    {
        public override Task ExecuteAsync()
        {
            var b = new ResidueClass(20151125, 33554393);
            var p = new ResidueClass(252533, 33554393);
            var completeDiagonals = 2947 + 3029 - 2;
            Result = (b * p.ToThePower(completeDiagonals * (completeDiagonals + 1) / 2 + 3028)).ToString();
            return Task.CompletedTask;


            int r = 1;
            int c = 1;
            foreach (var code in Codes())
            {
                if (r == 2947 && c == 3029)
                {
                    Result = code.ToString();
                    break;
                }

                if (r == 1)
                {
                    r = c + 1;
                    c = 1;
                }
                else
                {
                    r--;
                    c++;
                }
            }



            return Task.CompletedTask;
        }

        IEnumerable<long> Codes()
        {
            long code = 20151125;
            while (true)
            {
                yield return code;
                code = (code * 252533) % 33554393;
            }
        }

        public override int Nummer => 201525;
    }
}
