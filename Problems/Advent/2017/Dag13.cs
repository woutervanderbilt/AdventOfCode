using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2017;

internal class Dag13 : Problem
{
    private const string input = @"0: 3
1: 2
2: 4
4: 6
6: 5
8: 6
10: 6
12: 4
14: 8
16: 8
18: 9
20: 8
22: 6
24: 14
26: 12
28: 10
30: 12
32: 8
34: 10
36: 8
38: 8
40: 12
42: 12
44: 12
46: 12
48: 14
52: 14
54: 12
56: 12
58: 12
60: 12
62: 14
64: 14
66: 14
68: 14
70: 14
72: 14
80: 18
82: 14
84: 20
86: 14
90: 17
96: 20
98: 24";

    private const string testinput = @"0: 3
1: 2
4: 4
6: 4";
    public override Task ExecuteAsync()
    {
        IDictionary<int, int> firewall = input.Split(Environment.NewLine)
            .Select(l => l.Replace(":", "").Split(' ').Select(int.Parse).ToList())
            .ToDictionary(l => l[0], l => l[1]);
        int i = 0;
        while (true)
        {
            //var damage = firewall.Where(f => (f.Key + i) % (2 * f.Value - 2) == 0).Sum(f => f.Key * f.Value);
            var hit = firewall.Any(f => (f.Key + i) % (2 * f.Value - 2) == 0);
            if (!hit)
            {
                break;
            }

            i++;
        }

        Result = i.ToString();
        return Task.CompletedTask;
    }

    public override int Nummer => 201713;
}