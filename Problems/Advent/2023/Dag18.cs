using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag18 : Problem
{
    public override async Task ExecuteAsync()
    {
        var instructions = new List<Instruction>();

        foreach (var line in Input.Split(Environment.NewLine))
        {
            var split = line.Split(' ');
            instructions.Add(new Instruction(split[0], long.Parse(split[1]), split[2]));
        }

        long x = 0;
        long y = 0;
        IList<(long, long)> vertices = new List<(long, long)> { (x, y) };
        long edge2 = 0;
        foreach (var instruction in instructions)
        {
            var length = long.Parse(instruction.Color.Substring(2, 5), System.Globalization.NumberStyles.HexNumber);
            string direction = instruction.Color[7] switch
            {
                '0' => "R",
                '1' => "D",
                '2' => "L",
                '3' => "U"
            };
            edge2 += length;
            (x, y) = direction switch
            {
                "D" => (x, y + length),
                "R" => (x + length, y),
                "U" => (x, y - length),
                "L" => (x - length, y)
            };
            vertices.Add((x, y));
        }

        long result = edge2 / 2 + 1 + vertices.ConsecutivePairs().Sum(v => v.Item1.Item2 * (v.Item1.Item1 - v.Item2.Item1));

        Result = result.ToString();
    }

    record Instruction(string Direction, long Length, string Color);

    public override int Nummer => 202318;
}