using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problems.Advent._2025;
internal class Dag02 : Problem
{
    public override Task ExecuteAsync()
    {
        long result = 0;
        long result2 = 0;
        IList<(long, long)> ranges = [];
        foreach (var range in Input.Split(','))
        {
            var split = range.Split('-');
            ranges.Add((long.Parse(split[0]), long.Parse(split[1])));
        }
        ranges = ranges.OrderBy(r => r.Item1).ToList();
        var regex = new Regex(@"^(\d+)\1$");
        var regex2 = new Regex(@"^(\d+)\1+$");
        foreach (var range in ranges)
        {
            
            for (long n = range.Item1; n <= range.Item2; n++)
            {
                if (regex.IsMatch(n.ToString()))
                {
                    result += n;
                }
                if (regex2.IsMatch(n.ToString()))
                {
                    result2 += n;
                }
            }
        }

        Result = (result, result2).ToString();
        
        return Task.CompletedTask;
    }

    protected override string? TestInput => @"11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
    protected override bool UseTestInput => false;

    public override int Nummer => 202502;
}