﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag19 : Problem
{
    private const string testinput = @"Blueprint 1: Each ore robot costs 4 ore. Each clay robot costs 2 ore. Each obsidian robot costs 3 ore and 14 clay. Each geode robot costs 2 ore and 7 obsidian.
Blueprint 2: Each ore robot costs 2 ore. Each clay robot costs 3 ore. Each obsidian robot costs 3 ore and 8 clay. Each geode robot costs 3 ore and 12 obsidian.";
    public override async Task ExecuteAsync()
    {
        IList<Factory> factories = new List<Factory>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var factory = new Factory();
            var words = line.Split();
            factory.Id = long.Parse(words[1].Replace(":", ""));
            factory.OreCost = long.Parse(words[6]);
            factory.ClayCost = long.Parse(words[12]);
            factory.ObsidianCost = (long.Parse(words[18]), long.Parse(words[21]));
            factory.GeodeCost = (long.Parse(words[27]), long.Parse(words[30]));
            factories.Add(factory);
        }

        bool partOne = true;

        IList<long> factoryValues = new List<long>();
        long result = 1;
        var sw = Stopwatch.StartNew();
        Solve();
        sw.Stop();
        var sw2 = Stopwatch.StartNew();
        partOne = false;
        Solve();
        sw2.Stop();
        void Solve()
        {
            foreach (var factory in factories.Take(partOne ? factories.Count : 3))
            {
                HashSet<State> states = new HashSet<State>();
                states.Add(new State { OreRobots = 1 });
                for (int minute = 1; minute <= (partOne ? 24 : 32); minute++)
                {
                    HashSet<State> newStates = new HashSet<State>();
                    foreach (var state in states)
                    {
                        foreach (var newState in factory.NextStates(state))
                        {
                            newStates.Add(newState.Collect(state));
                        }
                    }

                    states = new HashSet<State>(newStates.OrderByDescending(s => s.Geodes * 100 + s.GeodeRobots * 80
                            + s.Obsidian * 3 + s.ObsidianRobots * 3 + s.Clay * 2 + s.ClayRobots * 2 + s.Ore + s.OreRobots)
                        .Take(5000));
                }

                Console.WriteLine((factory.Id, states.Max(s => s.Geodes)));
                if (partOne)
                {
                    factoryValues.Add(states.Max(s => s.Geodes) * factory.Id);
                }
                else
                {
                    result *= states.Max(s => s.Geodes);
                }
            }
        }

        Result = (factoryValues.Sum(), result, sw.ElapsedMilliseconds, sw2.ElapsedMilliseconds).ToString();
    }

    private class State
    {
        public long Ore { get; set; }
        public long Clay { get; set; }
        public long Obsidian { get; set; }
        public long Geodes { get; set; }

        public long OreRobots { get; set; }
        public long ClayRobots { get; set; }
        public long ObsidianRobots { get; set; }
        public long GeodeRobots { get; set; }

        public bool SkippedOre { get; set; }
        public bool SkippedClay { get; set; }
        public bool SkippedObsidian { get; set; }

        public State Copy()
        {
            return new State
            {
                Ore = Ore,
                Clay = Clay,
                Obsidian = Obsidian,
                Geodes = Geodes,
                OreRobots = OreRobots,
                ClayRobots = ClayRobots,
                ObsidianRobots = ObsidianRobots,
                GeodeRobots = GeodeRobots
            };
        }

        public State Collect(State prev)
        {
            Ore += prev.OreRobots;
            Clay += prev.ClayRobots;
            Obsidian += prev.ObsidianRobots;
            Geodes += prev.GeodeRobots;
            return this;
        }

        public State BuyOreRobot(long cost)
        {
            Ore -= cost;
            OreRobots++;
            return this;
        }
        public State BuyClayRobot(long cost)
        {
            Ore -= cost;
            ClayRobots++;
            return this;
        }
        public State BuyObsidianRobot(long oreCost, long clayCost)
        {
            Ore -= oreCost;
            Clay -= clayCost;
            ObsidianRobots++;
            return this;
        }

        public State BuyGeodeRobot(long oreCost, long obsidianCost)
        {
            Ore -= oreCost;
            Obsidian -= obsidianCost;
            GeodeRobots++;
            return this;
        }

        public override bool Equals(object obj)
        {
            return Equals((State)obj);
        }

        protected bool Equals(State other)
        {
            return Ore == other.Ore && Clay == other.Clay && Obsidian == other.Obsidian && Geodes == other.Geodes && OreRobots == other.OreRobots && ClayRobots == other.ClayRobots && ObsidianRobots == other.ObsidianRobots && GeodeRobots == other.GeodeRobots && SkippedOre == other.SkippedOre && SkippedClay == other.SkippedClay && SkippedObsidian == other.SkippedObsidian;
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Ore);
            hashCode.Add(Clay);
            hashCode.Add(Obsidian);
            hashCode.Add(Geodes);
            hashCode.Add(OreRobots);
            hashCode.Add(ClayRobots);
            hashCode.Add(ObsidianRobots);
            hashCode.Add(GeodeRobots);
            hashCode.Add(SkippedOre);
            hashCode.Add(SkippedClay);
            hashCode.Add(SkippedObsidian);
            return hashCode.ToHashCode();
        }
    }
    private class Factory
    {
        public long Id { get; set; }
        public long OreCost { get; set; }
        public long ClayCost { get; set; }
        public (long, long) ObsidianCost { get; set; }
        public (long, long) GeodeCost { get; set; }

        public IEnumerable<State> NextStates(State state)
        {
            if (state.Ore >= GeodeCost.Item1 && state.Obsidian >= GeodeCost.Item2)
            {
                yield return state.Copy().BuyGeodeRobot(GeodeCost.Item1, GeodeCost.Item2);
                yield break;
            }
            if (!state.SkippedOre && state.Ore >= OreCost
                                  && (state.OreRobots < ClayCost || state.OreRobots < ObsidianCost.Item1 || state.OreRobots < GeodeCost.Item1))
            {
                yield return state.Copy().BuyOreRobot(OreCost);
            }

            if (!state.SkippedClay && state.Ore >= ClayCost && state.ClayRobots < ObsidianCost.Item2 && state.ClayRobots < ObsidianCost.Item2)
            {
                yield return state.Copy().BuyClayRobot(ClayCost);
            }

            if (!state.SkippedObsidian && state.Ore >= ObsidianCost.Item1 && state.Clay >= ObsidianCost.Item2 && state.ObsidianRobots < GeodeCost.Item2)
            {
                yield return state.Copy().BuyObsidianRobot(ObsidianCost.Item1, ObsidianCost.Item2);
            }

            var copy = state.Copy();
            copy.SkippedOre = state.Ore >= OreCost;
            copy.SkippedClay = state.Ore >= ClayCost;
            copy.SkippedObsidian = state.Ore >= ObsidianCost.Item1 && state.Clay >= ObsidianCost.Item2;
            yield return copy;
        }
    }
    public override int Nummer => 202219;
}