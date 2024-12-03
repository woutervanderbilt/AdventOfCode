using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problems.Advent._2024;

internal class Dag03 : Problem
{
    public override async Task ExecuteAsync()
    {
        var regex = new Regex(@"mul\((\d+),(\d+)\)");
        long result = 0;
        foreach (var line in Input.Split("don't()"))
        {
            foreach (var enabledPart in line.Split("do()").Skip(1))
            {
                result += regex.Matches(enabledPart)
                    .Sum(m => long.Parse(m.Groups[1].Value) * long.Parse(m.Groups[2].Value));
            }
        }

        Result = result.ToString();
    }

    public override int Nummer => 202403;
}