using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Problems.Advent._2024;

internal class Dag07 : Problem
{
    public override async Task ExecuteAsync()
    {
        IList<long> targets = [];
        IList<IList<long>> numbers = [];
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var split = line.Split(": ");
            targets.Add(long.Parse(split[0]));
            numbers.Add(split[1].Split(' ').Select(long.Parse).ToList());
        }

        long result = 0;
        foreach (var (target, index) in targets.Indexed())
        {
            var numbersForTarget = numbers[index];
            if (AddDigit(numbersForTarget[0], 0))
            {
                result += target;
            }

            bool AddDigit(long current, int numberIndex)
            {
                if (numberIndex == numbersForTarget.Count - 1)
                {
                    return current == target;
                }
                var number = numbersForTarget[numberIndex + 1];
                if (current * number <= target)
                {
                    if (AddDigit(current * number, numberIndex + 1))
                    {
                        return true;
                    }
                }
                if (current + number <= target)
                {
                    if (AddDigit(current + number, numberIndex + 1))
                    {
                        return true;
                    }
                }

                var shift = current;
                for (int i = 1; i <= number.ToString().Length; i++)
                {
                    shift *= 10;
                }
                if (shift + number <= target)
                {
                    if (AddDigit(shift + number, numberIndex + 1))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        Result = result.ToString();
    }

    protected override bool UseTestInput => false;

    protected override string TestInput => @"190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20";

    public override int Nummer => 202407;
}