using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Problems.Advent._2021;

internal class Dag12 : Problem
{
    private const string input = @"bm-XY
ol-JS
bm-im
RD-ol
bm-QI
JS-ja
im-gq
end-im
ja-ol
JS-gq
bm-AF
RD-start
RD-ja
start-ol
cj-bm
start-JS
AF-ol
end-QI
QI-gq
ja-gq
end-AF
im-QI
bm-gq
ja-QI
gq-RD";
    public override Task ExecuteAsync()
    {
        IDictionary<string, IList<string>> connections = new Dictionary<string, IList<string>>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var words = line.Split('-');
            if (!connections.ContainsKey(words[0]))
            {
                connections[words[0]] = new List<string>();
            }
            if (!connections.ContainsKey(words[1]))
            {
                connections[words[1]] = new List<string>();
            }
            connections[words[0]].Add(words[1]);
            connections[words[1]].Add(words[0]);
        }



        Result = PathCount("start", new HashSet<string> { "start" }, false).ToString();

        long PathCount(string current, HashSet<string> visited, bool twice)
        {
            if (current == "end")
            {
                return 1;
            }

            long result = 0;
            foreach (var cave in connections[current])
            {
                if (cave.ToUpper() == cave)
                {
                    result += PathCount(cave, new HashSet<string>(visited), twice);
                }
                else if (!visited.Contains(cave))
                {
                    var copy = new HashSet<string>(visited);
                    copy.Add(cave);
                    result += PathCount(cave, copy, twice);
                }
                else if (!twice && cave != "start")
                {
                    var copy = new HashSet<string>(visited);
                    copy.Add(cave);
                    result += PathCount(cave, copy, true);
                }
            }

            return result;
        }

        return Task.CompletedTask;
    }

    public override int Nummer => 202112;
}