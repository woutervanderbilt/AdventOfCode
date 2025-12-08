using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Problems.Advent._2025;
internal class Dag08 : Problem
{
    public override Task ExecuteAsync()
    {
        IDictionary<int, (long, long, long)> junctionBoxes = new Dictionary<int, (long, long, long)>();
        IList<(int, int, long)> connections = [];
        IDictionary<int, IList<int>> circuits = new Dictionary<int, IList<int>>();
        IDictionary<int, int> circuitMap = new Dictionary<int, int>();
        long result = 0;
        long result2 = 0;

        foreach (var (line, index) in Input.Split(Environment.NewLine).Indexed())
        {
            var split = line.Split(',');
            junctionBoxes[index] = (long.Parse(split[0]), long.Parse(split[1]), long.Parse(split[2]));
            circuits[index] = [index];
            circuitMap[index] = index;
        }

        foreach (var junctionBox1 in junctionBoxes)
        {
            foreach (var junctionBox2 in junctionBoxes)
            {
                if (junctionBox1.Key < junctionBox2.Key)
                {
                    connections.Add((junctionBox1.Key, junctionBox2.Key, 
                        (junctionBox1.Value.Item2 - junctionBox2.Value.Item2) * (junctionBox1.Value.Item2 - junctionBox2.Value.Item2) +
                        (junctionBox1.Value.Item3 - junctionBox2.Value.Item3) * (junctionBox1.Value.Item3 - junctionBox2.Value.Item3) +
                        (junctionBox1.Value.Item1 - junctionBox2.Value.Item1) * (junctionBox1.Value.Item1 - junctionBox2.Value.Item1)));
                }
            }
        }
        connections = connections.OrderBy(d => d.Item3).ToList();
        long connectionCount = 0;
        foreach (var connection in connections)
        {
            if (connectionCount == (UseTestInput ? 10 : 1000))
            {
                var largestGroups = circuits.Values.OrderByDescending(v => v.Count).Take(3);
                result = largestGroups.Select(g => g.Count).Aggregate(1L, (a, b) => a * b);
            }
            connectionCount++;
            if (circuitMap[connection.Item1] == circuitMap[connection.Item2])
            {
                continue;
            }

            var circuitToRemove = circuitMap[connection.Item2];
            foreach (var box in circuits[circuitMap[connection.Item2]])
            {
                circuitMap[box] = circuitMap[connection.Item1];
                circuits[circuitMap[connection.Item1]].Add(box);
            }

            circuits.Remove(circuitToRemove);

            if (circuits.Count == 1)
            {
                result2 = junctionBoxes[connection.Item1].Item1 * junctionBoxes[connection.Item2].Item1;
                break;
            }
        }

        Result = (result, result2).ToString();
        return Task.CompletedTask;
    }
    protected override string TestInput => @"162,817,812
57,618,57
906,360,560
592,479,940
352,342,300
466,668,158
542,29,236
431,825,988
739,650,466
52,470,668
216,146,977
819,987,18
117,168,530
805,96,715
346,949,466
970,615,88
941,993,340
862,61,35
984,92,344
425,690,689";

    protected override bool UseTestInput => false;
    public override int Nummer => 202508;
}