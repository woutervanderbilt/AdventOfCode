using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2025;
internal class Dag03 : Problem
{
    public override Task ExecuteAsync()
    {
        long result = 0;
        long result2 = 0;
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var tens = line.Substring(0, line.Length - 1).Max();
            var units = line.Substring(line.IndexOf(tens) + 1).Max();
            result += long.Parse($"{tens}{units}");

            var cutLine = line;
            string joltage = "";
            for (int i = 11; i >= 0; i--)
            {
                var digit = cutLine.Substring(0, cutLine.Length - i).Max();
                joltage += digit;
                cutLine = cutLine.Substring(cutLine.IndexOf(digit) + 1);
            }

            result2 += long.Parse(joltage);
        }

        Result = (result, result2).ToString();
        return Task.CompletedTask;
    }

    protected override string TestInput => @"987654321111111
811111111111119
234234234234278
818181911112111";

    protected override bool UseTestInput => false;
    public override int Nummer => 202503;
}