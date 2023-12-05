using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag25 : Problem
{
    private const string testinput = @"1=-0-2
12111
2=0=
21
2=01
111
20012
112
1=-1=
1-12
12
1=
122";
    public override async Task ExecuteAsync()
    {
        var input = await GetInputAsync();
        Result = LongToSnafu(input.Split(Environment.NewLine)
            .Select(SnafuToLong)
            .Sum());
    }

    long SnafuToLong(string s)
    {
        long result = 0;
        long power = 1;
        foreach (var c in s.Reverse())
        {
            result += c switch
            {
                '1' => power,
                '2' => 2 * power,
                '-' => -power,
                '=' => -2 * power,
                _ => 0
            };
            power *= 5;
        }

        return result;
    }

    string LongToSnafu(long l)
    {
        string snafu = "";
        while (l != 0)
        {
            var mod = l % 5;
            snafu += mod switch
            {
                0 => '0',
                1 => '1',
                2 => '2',
                3 => '=',
                4 => '-'
            };
            l /= 5;
            if (mod > 2)
            {
                l++;
            }
        }
        return new string(snafu.Reverse().ToArray());
    }

    public override int Nummer => 202225;
}