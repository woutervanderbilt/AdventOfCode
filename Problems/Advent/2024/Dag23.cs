using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag23 : Problem
{
    public override async Task ExecuteAsync()
    {
        IDictionary<string, List<string>> connections = new Dictionary<string, List<string>>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var computers = line.Split('-');
            if (!connections.ContainsKey(computers[0]))
            {
                connections[computers[0]] = new List<string>();
            }
            if (!connections.ContainsKey(computers[1]))
            {
                connections[computers[1]] = new List<string>();
            }
            connections.AddToList(computers[0], computers[1]);
            connections.AddToList(computers[1], computers[0]);
        }

        var graph = new Graph<string>(Input.Split(Environment.NewLine).Select(l => (l.Split('-')[0], l.Split('-')[1], 1L)), true);

        var result1 = graph.Vertices.Sum(v1 => graph.Neighbours(v1)
            .Sum(v2 => graph.Neighbours(v2)
                .Count(v3 => graph.Neighbours(v3).Contains(v1)
                    && (v1.StartsWith("t") || v2.StartsWith("t") || v3.StartsWith("t"))))) / 6;

        var cliques = graph.Cliques().ToList();



        var maxCliqueLength = cliques.Max(c => c.Count);
        var maxClique = cliques.First(c => c.Count == maxCliqueLength);
        var result2 = string.Join(',', maxClique.OrderBy(c => c));

        Result = (result1, result2).ToString();
    }
    protected override bool UseTestInput => false;

    protected override string TestInput => @"kh-tc
qp-kh
de-cg
ka-co
yn-aq
qp-ub
cg-tb
vc-aq
tb-ka
wh-tc
yn-cg
kh-ub
ta-co
de-co
tc-td
tb-wq
wh-td
ta-ka
td-qp
aq-cg
wq-ub
ub-vc
de-ta
wq-aq
wq-vc
wh-yn
ka-de
kh-ta
co-tc
wh-qp
tb-vc
td-yn";
    public override int Nummer => 202423;
}