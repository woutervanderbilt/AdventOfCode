using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag01 : Problem
{
    private const string testinput = @"two1nine
eightwothree
abcone2threexyz
xtwone3four
4nineeightseven2
zoneight234
7pqrstsixteen";
    public override async Task ExecuteAsync()
    {
        var digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var reverseDigits = digits.Select(d => new string(d.Reverse().ToArray())).ToList();

        (long, long) result = (0, 0);
        foreach (var line in Input.Split(Environment.NewLine))
        {
            result.Item1 += 10 * FirstDigit(line, false, false) + FirstDigit(line, true, false);
        }

        foreach (var line in Input.Split(Environment.NewLine))
        {
            result.Item2 += 10 * FirstDigit(line, false, true) + FirstDigit(line, true, true);
        }

        int FirstDigit(string line, bool reverse, bool part2)
        {
            var digitsToUse = reverse ? reverseDigits : digits;
            if (reverse)
            {
                line = new string(line.Reverse().ToArray());
            }

            int value = 0;
            int minIndex = int.MaxValue;
            for (int i = 0; i <= 9; i++)
            {
                CheckDigit(i.ToString());
                if (part2)
                {
                    CheckDigit(digitsToUse[i]);
                }

                void CheckDigit(string s)
                {
                    var index = line.IndexOf(s);
                    if (index >= 0 && index < minIndex)
                    {
                        minIndex = index;
                        value = i;
                    }
                }
            }

            return value;
        }

        Result = result.ToString();
    }

    public override int Nummer => 202301;
}