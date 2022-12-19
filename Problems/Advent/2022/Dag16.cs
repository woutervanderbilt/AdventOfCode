using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Problems.Advent._2022
{
    internal class Dag16 : Problem
    {
        private const string input = @"Valve ZN has flow rate=0; tunnels lead to valves SD, ZV
Valve HO has flow rate=17; tunnel leads to valve LT
Valve FT has flow rate=6; tunnels lead to valves DW, BV, JA, FB, TV
Valve AD has flow rate=0; tunnels lead to valves AA, JG
Valve GE has flow rate=0; tunnels lead to valves JG, RD
Valve GI has flow rate=0; tunnels lead to valves WJ, RD
Valve RM has flow rate=0; tunnels lead to valves BU, WJ
Valve GV has flow rate=0; tunnels lead to valves WB, HS
Valve VA has flow rate=0; tunnels lead to valves AA, HS
Valve TJ has flow rate=21; tunnel leads to valve CK
Valve WB has flow rate=0; tunnels lead to valves GV, EV
Valve DV has flow rate=19; tunnels lead to valves OI, NK
Valve EL has flow rate=0; tunnels lead to valves HS, YC
Valve KU has flow rate=0; tunnels lead to valves WJ, OI
Valve WI has flow rate=16; tunnels lead to valves SD, AN, GS, JV
Valve JG has flow rate=3; tunnels lead to valves SV, BU, GC, GE, AD
Valve TC has flow rate=0; tunnels lead to valves TV, WJ
Valve GC has flow rate=0; tunnels lead to valves JG, JA
Valve LS has flow rate=0; tunnels lead to valves JH, YP
Valve OI has flow rate=0; tunnels lead to valves KU, DV
Valve ZH has flow rate=0; tunnels lead to valves YZ, RD
Valve YZ has flow rate=0; tunnels lead to valves ZH, AA
Valve YP has flow rate=0; tunnels lead to valves KS, LS
Valve CK has flow rate=0; tunnels lead to valves EG, TJ
Valve NY has flow rate=0; tunnels lead to valves HS, UU
Valve IQ has flow rate=18; tunnel leads to valve YC
Valve HI has flow rate=0; tunnels lead to valves SS, RD
Valve DW has flow rate=0; tunnels lead to valves FT, JH
Valve EV has flow rate=7; tunnels lead to valves SV, WB, SS, GS
Valve SV has flow rate=0; tunnels lead to valves JG, EV
Valve BU has flow rate=0; tunnels lead to valves JG, RM
Valve GS has flow rate=0; tunnels lead to valves EV, WI
Valve UY has flow rate=0; tunnels lead to valves WJ, FE
Valve AA has flow rate=0; tunnels lead to valves VA, YZ, AD, FB
Valve SD has flow rate=0; tunnels lead to valves WI, ZN
Valve KS has flow rate=23; tunnel leads to valve YP
Valve RD has flow rate=4; tunnels lead to valves GI, HI, BV, ZH, GE
Valve ZV has flow rate=15; tunnel leads to valve ZN
Valve HB has flow rate=0; tunnels lead to valves HS, AN
Valve UU has flow rate=0; tunnels lead to valves EG, NY
Valve SS has flow rate=0; tunnels lead to valves HI, EV
Valve HS has flow rate=12; tunnels lead to valves HB, EL, VA, GV, NY
Valve LT has flow rate=0; tunnels lead to valves DS, HO
Valve JH has flow rate=5; tunnels lead to valves LS, FE, QU, NK, DW
Valve AN has flow rate=0; tunnels lead to valves HB, WI
Valve NK has flow rate=0; tunnels lead to valves DV, JH
Valve JA has flow rate=0; tunnels lead to valves GC, FT
Valve EG has flow rate=14; tunnels lead to valves CK, UU, DS
Valve JV has flow rate=0; tunnels lead to valves QU, WI
Valve WJ has flow rate=8; tunnels lead to valves GI, RM, KU, UY, TC
Valve FE has flow rate=0; tunnels lead to valves JH, UY
Valve TV has flow rate=0; tunnels lead to valves FT, TC
Valve YC has flow rate=0; tunnels lead to valves IQ, EL
Valve QU has flow rate=0; tunnels lead to valves JV, JH
Valve DS has flow rate=0; tunnels lead to valves LT, EG
Valve BV has flow rate=0; tunnels lead to valves FT, RD
Valve FB has flow rate=0; tunnels lead to valves AA, FT";


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
        public override Task ExecuteAsync()
        {
            IDictionary<string, Valve> valves = new Dictionary<string, Valve>();
            foreach (var line in input.Split(Environment.NewLine))
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
                        HashSet<string> visited = new HashSet<string>{fromValve.Name};
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
                    for(int j = 1; j <= pathLength; j++)
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
       

            return Task.CompletedTask;
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
}
