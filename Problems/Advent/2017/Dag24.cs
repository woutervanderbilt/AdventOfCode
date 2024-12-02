using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2017;

internal class Dag24 : Problem
{
    private const string input = @"14/42
2/3
6/44
4/10
23/49
35/39
46/46
5/29
13/20
33/9
24/50
0/30
9/10
41/44
35/50
44/50
5/11
21/24
7/39
46/31
38/38
22/26
8/9
16/4
23/39
26/5
40/40
29/29
5/20
3/32
42/11
16/14
27/49
36/20
18/39
49/41
16/6
24/46
44/48
36/4
6/6
13/6
42/12
29/41
39/39
9/3
30/2
25/20
15/6
15/23
28/40
8/7
26/23
48/10
28/28
2/13
48/14";
    public override Task ExecuteAsync()
    {
        var components = input.Split(Environment.NewLine).Select(l => l.Split('/').Select(int.Parse).ToList()).ToList();

        long length = 0;
        long strength = 0;
        Add(0, new HashSet<int>(), 0);
        Result = strength.ToString();

        void Add(int port, HashSet<int> used, int currentValue)
        {
            if (used.Count > length)
            {
                length = used.Count;
                strength = currentValue;
            }
            else if (used.Count == length)
            {
                strength = Math.Max(currentValue, strength);
            }
            for (int i = 0; i < components.Count; i++)
            {
                if (!used.Contains(i))
                {
                    var component = components[i];
                    if (component[0] == port)
                    {
                        var copy = new HashSet<int>(used);
                        copy.Add(i);
                        Add(component[1], copy, currentValue + component[0] + component[1]);
                    }
                    else if (component[1] == port)
                    {
                        var copy = new HashSet<int>(used);
                        copy.Add(i);
                        Add(component[0], copy, currentValue + component[0] + component[1]);
                    }
                }
            }
        }
        return Task.CompletedTask;
    }

    public override int Nummer => 201724;
}