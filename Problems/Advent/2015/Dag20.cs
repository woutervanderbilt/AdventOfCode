using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;

namespace Problems.Advent._2015;

internal class Dag20 : Problem
{
    private const int input = 36000000;
    public override Task ExecuteAsync()
    {
        var factorizer = new Factorizer(input / 10);
        for (int i = 1; i <= input / 10; i++)
        {
            if (factorizer.Divisors(i).Where(d => d * 50 >= i).Sum() * 11 > input)
            {
                Result = i.ToString();
                break;
            }
        }
        return Task.CompletedTask;
    }

    public override int Nummer => 201520;
}