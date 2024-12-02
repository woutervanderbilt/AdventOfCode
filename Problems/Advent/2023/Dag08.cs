using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag08 : Problem
{
    private const string testinput = @"LR

11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)";

    public override async Task ExecuteAsync()
    {
        var dict = new Dictionary<string, (string, string)>();
        string instructions = null;

        foreach (var line in Input.Split(Environment.NewLine))
        {
            if (instructions == null)
            {
                instructions = line;
                continue;
            }

            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            var split = line.Replace(" ", "").Replace("(", "").Replace(")", "").Split('=');
            var dest = split[1].Split(',');
            dict[split[0]] = (dest[0], dest[1]);
        }

        var result = Steps("AAA", true);

        var startingLocations = dict.Keys.Where(k => k.EndsWith('A'));
        var result2 = 1L;
        foreach (var start in startingLocations)
        {
            var steps2 = Steps(start, false);
            result2 = EulerMath.LCM(result2, steps2); // LCM werkt alleen omdat de input lief is
        }

        Result = (result, result2).ToString();

        int Steps(string location, bool targetZZZ)
        {
            int steps = 0;
            while (targetZZZ ? (location != "ZZZ") : !location.EndsWith('Z'))
            {
                var instruction = instructions[steps % instructions.Length];
                location = instruction == 'L' ? dict[location].Item1 : dict[location].Item2;
                steps++;
            }

            return steps;
        }
    }



    public override int Nummer => 202308;
}