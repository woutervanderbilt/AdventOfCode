using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag16 : Problem
{
    private const string testinput = @"Valve AA has flow rate=0; tunnels lead to valves DD, II, BB
Valve BB has flow rate=13; tunnels lead to valves CC, AA
Valve CC has flow rate=2; tunnels lead to valves DD, BB
Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE
Valve EE has flow rate=3; tunnels lead to valves FF, DD
Valve FF has flow rate=0; tunnels lead to valves EE, GG
Valve GG has flow rate=0; tunnels lead to valves FF, HH
Valve HH has flow rate=22; tunnel leads to valve GG
Valve II has flow rate=0; tunnels lead to valves AA, JJ
Valve JJ has flow rate=21; tunnel leads to valve II";
    public override async Task ExecuteAsync()
    {
        IDictionary<string, Valve> valves = new Dictionary<string, Valve>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var words = line.Split();
            var name = words[1];
            Valve valve;
            if (valves.ContainsKey(name))
            {
                valve = valves[name];
            }
            else
            {
                valve = new Valve { Name = name };
                valves[name] = valve;
            }

            var fr = int.Parse(words[4].Substring(5).Replace(";", ""));
            valve.FlowRate = fr;
            foreach (var to in words.Skip(9))
            {
                var toValveName = to.Replace(",", "");
                Valve toValve;
                if (valves.ContainsKey(toValveName))
                {
                    toValve = valves[toValveName];
                }
                else
                {
                    toValve = new Valve { Name = toValveName };
                    valves[toValveName] = toValve;
                }

                valve.FlowsTo.Add(toValve);
            }
        }

        foreach (var valve in valves.Values)
        {
            valve.FlowsTo = valve.FlowsTo.OrderByDescending(v => v.FlowRate).ToList();
        }

        IList<Valve> flowingValves =
            valves.Values.Where(v => v.FlowRate > 0).OrderByDescending(v => v.FlowRate).ToList();
        int totalFLowRate = flowingValves.Sum(v => v.FlowRate);
        var pointValves = flowingValves.ToList();
        pointValves.Add(valves["AA"]);

        IDictionary<(string, string), int> shortestPaths = new Dictionary<(string, string), int>();
        foreach (var fromValve in pointValves)
        {
            foreach (var toValve in pointValves)
            {
                if (fromValve != toValve && toValve.Name != "AA")
                {
                    bool found = false;
                    HashSet<string> visited = new HashSet<string> { fromValve.Name };
                    IList<Valve> current = new List<Valve> { fromValve };

                    int steps = 0;
                    while (!current.Contains(toValve))
                    {
                        steps++;
                        IList<Valve> newCurrent = new List<Valve>();
                        foreach (var valve in current)
                        {
                            foreach (var nextValve in valve.FlowsTo)
                            {

                                if (visited.Contains(nextValve.Name))
                                {
                                    continue;
                                }

                                newCurrent.Add(nextValve);
                                if (nextValve == toValve)
                                {
                                    shortestPaths[(fromValve.Name, toValve.Name)] = steps;
                                    found = true;
                                    break;
                                }
                            }

                            if (found)
                            {
                                break;
                            }
                        }

                        if (found)
                        {
                            break;
                        }
                        current = newCurrent;
                    }
                }
            }
        }

        var sw = Stopwatch.StartNew();
        long max = 0;
        int totalMinutes = 26;
        IList<Valve> bestRoute = null;
        Valve start = valves["AA"];
        //AddValve(start, new List<Valve>(), 1, 0, 0);
        Step(start, start, new List<Valve>(), -1, 0, 0, 0, 0);
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds);

        void Step(Valve? myTarget, Valve? elephantsTarget, IList<Valve> visitedValves, int minute, int flowrate, long totalPressure, int myStepsRemaining, int elephantsStepsRemaining)
        {
            if (totalPressure + (totalMinutes - minute) * totalFLowRate < max)
            {
                return;
            }
            if (max < totalPressure)
            {
                max = totalPressure;
                Console.WriteLine(max);
            }
            if (minute == totalMinutes)
            {
                return;
            }
            if (myStepsRemaining == 0)
            {
                if (elephantsStepsRemaining == 0)
                {
                    var myTargetValves = flowingValves.Except(visitedValves).OrderByDescending(v => v.FlowRate).ToList();
                    var elephantsTargetValves = flowingValves.Except(visitedValves).OrderByDescending(v => v.FlowRate).ToList();
                    if (visitedValves.Count == flowingValves.Count)
                    {
                        Step(null, null, visitedValves, minute + 1, flowrate + myTarget.FlowRate + elephantsTarget.FlowRate,
                            totalPressure + flowrate, 10000, 10000);
                    }
                    else if (myTargetValves.Count == 1)
                    {
                        var ed = shortestPaths[(elephantsTarget.Name, myTargetValves[0].Name)];
                        var md = shortestPaths[(myTarget.Name, myTargetValves[0].Name)];
                        if (md < ed)
                        {
                            Step(myTargetValves[0], null, flowingValves, minute + 1, flowrate + myTarget.FlowRate + elephantsTarget.FlowRate,
                                totalPressure + flowrate, md, 10000);
                        }
                        else
                        {
                            Step(null, elephantsTargetValves[0], flowingValves, minute + 1, flowrate + myTarget.FlowRate + elephantsTarget.FlowRate,
                                totalPressure + flowrate, 10000, ed);
                        }
                    }
                    else
                    {

                        foreach (var elephantsTargetValve in elephantsTargetValves)
                        {
                            foreach (var myTargetValve in myTargetValves)
                            {
                                if (myTargetValve == elephantsTargetValve)
                                {
                                    continue;
                                }

                                var copy = visitedValves.ToList();
                                copy.Add(myTargetValve);
                                copy.Add(elephantsTargetValve);
                                Step(myTargetValve, elephantsTargetValve, copy, minute + 1,
                                    flowrate + myTarget.FlowRate + elephantsTarget.FlowRate,
                                    totalPressure + flowrate,
                                    shortestPaths[(myTarget.Name, myTargetValve.Name)],
                                    shortestPaths[(elephantsTarget.Name, elephantsTargetValve.Name)]);
                            }
                        }
                    }
                }
                else
                {
                    var targetValves = flowingValves.Except(visitedValves).OrderByDescending(v => v.FlowRate);
                    if (visitedValves.Count == flowingValves.Count)
                    {
                        Step(null, elephantsTarget, visitedValves, minute + 1, flowrate + myTarget.FlowRate,
                            totalPressure + flowrate, 10000, elephantsStepsRemaining - 1);
                    }
                    else
                    {
                        foreach (var targetValve in targetValves)
                        {
                            var copy = visitedValves.ToList();
                            copy.Add(targetValve);
                            Step(targetValve, elephantsTarget, copy, minute + 1, flowrate + myTarget.FlowRate,
                                totalPressure + flowrate,
                                shortestPaths[(myTarget.Name, targetValve.Name)],
                                elephantsStepsRemaining - 1);
                        }
                    }
                }

            }

            if (elephantsStepsRemaining == 0)
            {
                var targetValves = flowingValves.Except(visitedValves).OrderByDescending(v => v.FlowRate);
                if (visitedValves.Count == flowingValves.Count)
                {
                    Step(myTarget, null, visitedValves, minute + 1, flowrate + elephantsTarget.FlowRate,
                        totalPressure + flowrate, myStepsRemaining - 1, 10000);
                }
                else
                {
                    foreach (var targetValve in targetValves)
                    {
                        var copy = visitedValves.ToList();
                        copy.Add(targetValve);
                        Step(myTarget, targetValve, copy, minute + 1, flowrate + elephantsTarget.FlowRate,
                            totalPressure + flowrate, myStepsRemaining - 1,
                            shortestPaths[(elephantsTarget.Name, targetValve.Name)]);
                    }
                }
            }
            else
            {
                Step(myTarget, elephantsTarget, visitedValves, minute + 1, flowrate, totalPressure + flowrate, myStepsRemaining - 1, elephantsStepsRemaining - 1);
            }
        }


        void AddValve(Valve currentValve, IList<Valve> visitedValves, int minute, int flowrate, long totalPressure)
        {
            if (totalPressure + (totalMinutes - minute) * totalFLowRate < max)
            {
                return;
            }
            if (visitedValves.Count == flowingValves.Count)
            {
                totalPressure += (totalMinutes - minute) * flowrate;
                if (max < totalPressure)
                {
                    max = totalPressure;
                    bestRoute = visitedValves;
                }

                return;
            }
            var targetValves = flowingValves.Except(visitedValves);//.OrderByDescending(v => v.FlowRate / shortestPaths[(currentValve.Name, v.Name)].Count);
            int i = 0;
            foreach (var targetValve in targetValves)
            {
                int localMinute = minute;
                int localFlowrate = flowrate;
                long localPressure = totalPressure;
                var pathLength = shortestPaths[(currentValve.Name, targetValve.Name)];
                for (int j = 1; j <= pathLength; j++)
                {
                    localMinute++;
                    localPressure += localFlowrate;
                    if (localMinute == totalMinutes)
                    {
                        if (max < localPressure)
                        {
                            max = localPressure;
                            bestRoute = visitedValves;
                        }
                        break;
                    }
                }

                if (localMinute == totalMinutes)
                {
                    if (max < localPressure)
                    {
                        max = localPressure;
                        bestRoute = visitedValves;
                    }
                    continue;
                }

                localFlowrate += targetValve.FlowRate;
                localPressure += localFlowrate;
                localMinute++;
                if (localMinute == totalMinutes)
                {
                    if (max < localPressure)
                    {
                        max = localPressure;
                        bestRoute = visitedValves;
                    }
                    continue;
                }
                var copy = visitedValves.ToList();
                copy.Add(targetValve);
                AddValve(targetValve, copy, localMinute, localFlowrate, localPressure);
                i++;
            }

            if (max < totalPressure)
            {
                max = totalPressure;
                bestRoute = visitedValves;
            };
        }

        Result = max.ToString();
    }

    public override int Nummer => 202216;

    private class Valve
    {
        public string Name { get; set; }
        public int FlowRate { get; set; }
        public IList<Valve> FlowsTo { get; set; } = new List<Valve>();

        public override string ToString() => (Name, FlowRate).ToString();
    }
}