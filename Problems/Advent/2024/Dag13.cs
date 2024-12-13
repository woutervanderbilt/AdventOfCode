using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag13 : Problem
{
    public override async Task ExecuteAsync()
    {
        IList<(long ax, long ay, long bx, long by, long x, long y)> machines = [];
        foreach (var machine in Input.Split(Environment.NewLine).Chunk(4))
        {
            var s = machine[0].Split('+');
            long ay = long.Parse(s[2]);
            long ax = long.Parse(s[1].Split(',')[0]);
            s = machine[1].Split('+');
            long by = long.Parse(s[2]);
            long bx = long.Parse(s[1].Split(',')[0]);
            s = machine[2].Split('=');
            long y = long.Parse(s[2]);
            long x = long.Parse(s[1].Split(',')[0]);
            machines.Add((ax, ay, bx, by, x, y));
        }

        long result1 = 0;
        long result2 = 0;

        foreach (var (ax, ay, bx, by, x, y) in machines)
        {
            var (a, b) = Solve(ax, ay, bx, by, x, y);
            if (a.Denominator == 1 && b.Denominator == 1 && a.Denominator <= 100 && b.Denominator <= 100)
            {
                if (a.Numerator >= 0 && b.Numerator >= 0)
                {
                    result1 += 3 * a.Numerator + b.Numerator;
                }
            }
            (a, b) = Solve(ax, ay, bx, by, x + 10000000000000, y + 10000000000000);
            if (a.Denominator == 1 && b.Denominator == 1)
            {
                if (a.Numerator >= 0 && b.Numerator >= 0)
                {
                    result2 += 3 * a.Numerator + b.Numerator;
                }
            }
        }

        Result = (result1, result2).ToString();


        (Rational a, Rational b) Solve(long ax, long ay, long bx, long by, long x, long y)
        {
            Rational b = new Rational(y * ax - ay * x, by * ax - bx * ay);
            Rational a = (x - b * bx) / ax;

            return (a, b);
        }
    }

    protected override bool UseTestInput => false;

    protected override string TestInput => @"Button A: X+94, Y+34
Button B: X+22, Y+67
Prize: X=8400, Y=5400

Button A: X+26, Y+66
Button B: X+67, Y+21
Prize: X=12748, Y=12176

Button A: X+17, Y+86
Button B: X+84, Y+37
Prize: X=7870, Y=6450

Button A: X+69, Y+23
Button B: X+27, Y+71
Prize: X=18641, Y=10279";

    public override int Nummer => 202413;
}