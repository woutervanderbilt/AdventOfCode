using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2018;

public class Dag7 : Problem
{
    private const string input = @"Step P must be finished before step O can begin.
Step H must be finished before step X can begin.
Step M must be finished before step Q can begin.
Step E must be finished before step U can begin.
Step G must be finished before step O can begin.
Step W must be finished before step F can begin.
Step O must be finished before step F can begin.
Step B must be finished before step X can begin.
Step F must be finished before step C can begin.
Step A must be finished before step L can begin.
Step C must be finished before step D can begin.
Step D must be finished before step Y can begin.
Step V must be finished before step R can begin.
Step I must be finished before step Y can begin.
Step X must be finished before step K can begin.
Step T must be finished before step S can begin.
Step Y must be finished before step J can begin.
Step Z must be finished before step R can begin.
Step R must be finished before step K can begin.
Step K must be finished before step N can begin.
Step U must be finished before step N can begin.
Step Q must be finished before step N can begin.
Step N must be finished before step J can begin.
Step S must be finished before step J can begin.
Step L must be finished before step J can begin.
Step A must be finished before step C can begin.
Step S must be finished before step L can begin.
Step X must be finished before step S can begin.
Step T must be finished before step J can begin.
Step B must be finished before step C can begin.
Step G must be finished before step N can begin.
Step M must be finished before step O can begin.
Step Y must be finished before step K can begin.
Step B must be finished before step Y can begin.
Step Y must be finished before step U can begin.
Step F must be finished before step J can begin.
Step A must be finished before step N can begin.
Step W must be finished before step Y can begin.
Step C must be finished before step R can begin.
Step Q must be finished before step J can begin.
Step O must be finished before step L can begin.
Step Q must be finished before step S can begin.
Step H must be finished before step E can begin.
Step N must be finished before step S can begin.
Step A must be finished before step T can begin.
Step C must be finished before step K can begin.
Step Z must be finished before step J can begin.
Step U must be finished before step Q can begin.
Step B must be finished before step F can begin.
Step W must be finished before step X can begin.
Step H must be finished before step Q can begin.
Step B must be finished before step V can begin.
Step Z must be finished before step U can begin.
Step O must be finished before step A can begin.
Step C must be finished before step I can begin.
Step I must be finished before step T can begin.
Step E must be finished before step D can begin.
Step V must be finished before step S can begin.
Step F must be finished before step V can begin.
Step C must be finished before step S can begin.
Step I must be finished before step U can begin.
Step F must be finished before step Z can begin.
Step A must be finished before step X can begin.
Step C must be finished before step N can begin.
Step G must be finished before step F can begin.
Step O must be finished before step R can begin.
Step V must be finished before step X can begin.
Step E must be finished before step A can begin.
Step K must be finished before step Q can begin.
Step Z must be finished before step K can begin.
Step T must be finished before step K can begin.
Step Y must be finished before step Z can begin.
Step W must be finished before step B can begin.
Step E must be finished before step V can begin.
Step W must be finished before step J can begin.
Step I must be finished before step S can begin.
Step H must be finished before step L can begin.
Step G must be finished before step I can begin.
Step X must be finished before step L can begin.
Step H must be finished before step G can begin.
Step H must be finished before step Z can begin.
Step H must be finished before step N can begin.
Step D must be finished before step I can begin.
Step E must be finished before step J can begin.
Step X must be finished before step R can begin.
Step O must be finished before step J can begin.
Step N must be finished before step L can begin.
Step X must be finished before step N can begin.
Step V must be finished before step Q can begin.
Step P must be finished before step Y can begin.
Step H must be finished before step U can begin.
Step X must be finished before step Z can begin.
Step G must be finished before step Q can begin.
Step B must be finished before step Q can begin.
Step Y must be finished before step L can begin.
Step U must be finished before step J can begin.
Step W must be finished before step V can begin.
Step G must be finished before step C can begin.
Step G must be finished before step B can begin.
Step O must be finished before step B can begin.
Step R must be finished before step N can begin.";

    public override Task ExecuteAsync()
    {
        IList<Tuple<string, string>> pairs = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
            .Select(s => new Tuple<string, string>(s.Substring(5, 1), s.Substring(36, 1))).ToList();
        IDictionary<string, List<string>> restrictions = new Dictionary<string, List<string>>();
        foreach (var s in pairs.Select(p => p.Item1))
        {
            if (!restrictions.ContainsKey(s))
            {
                restrictions.Add(s, new List<string>());
            }
        }
        foreach (var s in pairs.Select(p => p.Item2))
        {
            if (!restrictions.ContainsKey(s))
            {
                restrictions.Add(s, new List<string>());
            }
        }

        foreach (var pair in pairs)
        {
            if (!restrictions[pair.Item2].Contains(pair.Item1))
            {
                restrictions[pair.Item2].Add(pair.Item1);
            }
        }
        IDictionary<string, int> workToDo = new Dictionary<string, int>();
        int c = 61;
        foreach (var node in restrictions.Keys.OrderBy(s => s))
        {
            workToDo[node] = c;
            c++;
        }

        int t = 0;
        while (restrictions.Any())
        {
            t++;
            var openNodes = restrictions.Where(r => !r.Value.Any()).OrderBy(s => s.Key).Select(s => s.Key);
            {
                int w = 1;
                foreach (var node in openNodes)
                {
                    workToDo[node]--;
                    if (workToDo[node] == 0)
                    {
                        restrictions.Remove(node);
                        foreach (var restriction in restrictions)
                        {
                            if (restriction.Value.Contains(node))
                            {
                                restriction.Value.Remove(node);
                            }
                        }
                    }

                    w++;
                    if (w == 6)
                    {
                        break;
                    }
                }
            }
        }


        Result = t.ToString();
        //StringBuilder sb = new StringBuilder();
        //while (restrictions.Any())
        //{
        //    string l = restrictions.Where(r => !r.Value.Any()).OrderBy(s => s.Key).First().Key;
        //    sb.Append(l);
        //    restrictions.Remove(l);
        //    foreach (var restriction in restrictions)
        //    {
        //        if (restriction.Value.Contains(l))
        //        {
        //            restriction.Value.Remove(l);
        //        }
        //    }
        //}

        return Task.CompletedTask;
    }

    public override int Nummer => 201807;
}