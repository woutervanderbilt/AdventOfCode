using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Problems.Advent._2023;

internal class Dag20 : Problem
{
    private const string testinput = @"broadcaster -> a, b, c
%a -> b
%b -> c
%c -> inv
&inv -> a";

    private const string testinput2 = @"broadcaster -> a
%a -> inv, con
&inv -> b
%b -> con
&con -> rx";

    public override async Task ExecuteAsync()
    {
        IDictionary<string, IModule> modules = new Dictionary<string, IModule>();
        var pulseQueue = new Queue<(bool isHigh, IModule target, IModule source)>();

        string input = await GetInputAsync();
        foreach (var line in input.Split(Environment.NewLine))
        {
            var split = line.Replace(" ", "").Split("->");
            if (split[0][0] == '%')
            {
                var name = split[0].Substring(1);
                modules[name] = new FLipFlopModule(name, pulseQueue, split[1].Split(','));
            }
            else if (split[0][0] == '&')
            {
                var name = split[0].Substring(1);
                modules[name] = new ConjunctionModule(name, pulseQueue, split[1].Split(','));
            }
            else
            {
                modules[split[0]] = new BroadCasterModule(split[0], pulseQueue, split[1].Split(','));
            }
        }

        modules["rx"] = new OutputModule("rx");

        foreach (var module in modules.Values)
        {
            module.Initialize(modules);
        }

        long totalLow = 0;
        long totalHigh = 0;
        long result = 0;
        long result2 = 0;
        var rs = modules["rs"] as ConjunctionModule;
        for (int i = 1; i < int.MaxValue; i++)
        {
            var d = PushButton(i);
            totalLow += d.low;
            totalHigh += d.high;
            if (i == 1000)
            {
                result = totalHigh * totalLow;
            }

            if (result != 0 && result2 != 0)
            {
                break;
            }
        }

        Result = (result, result2).ToString();


        (long low, long high) PushButton(int i)
        {
            long low = 0;
            long high = 0;
            pulseQueue.Enqueue((false, modules["broadcaster"], null));
            while (pulseQueue.TryDequeue(out var pulse))
            {
                //Console.WriteLine($"{pulse.source?.Name ?? "button"} -{(pulse.isHigh ? "high" : "low")}-> {pulse.target.Name}");
                if (pulse.isHigh)
                {
                    high++;
                }
                else
                {
                    low++;
                }
                pulse.target.ReceivePulse(pulse.isHigh, pulse.source, i);
                if (pulse.target.Name == "rs")
                {
                    if (rs.Part2 != 0)
                    {
                        result2 = rs.Part2;
                    }
                }
            }

            return (low, high);
        }


    }

    private interface IModule
    {
        Queue<(bool isHigh, IModule target, IModule source)> PulseQueue { get; }
        void ReceivePulse(bool isHigh, IModule from, int buttonCount);
        string Name { get; }
        IList<IModule> Destinations { get; }
        void Initialize(IDictionary<string, IModule> modulesByName);
    }

    private class FLipFlopModule(string name, Queue<(bool isHigh, IModule target, IModule source)> pulseQueue, IList<string> destinations) : IModule
    {
        public bool SwitchedOn { get; set; }
        public Queue<(bool isHigh, IModule target, IModule source)> PulseQueue => pulseQueue;

        public void ReceivePulse(bool isHigh, IModule from, int buttonCount)
        {
            if (isHigh)
            {
                return;
            }

            SwitchedOn = !SwitchedOn;
            if (SwitchedOn)
            {
                foreach (var destination in Destinations)
                {
                    pulseQueue.Enqueue((true, destination, this));
                }
            }
            else
            {
                foreach (var destination in Destinations)
                {
                    pulseQueue.Enqueue((false, destination, this));
                }
            }
        }

        public string Name => name;
        public IList<IModule> Destinations { get; } = new List<IModule>();
        public void Initialize(IDictionary<string, IModule> modulesByName)
        {
            foreach (var destination in destinations)
            {
                var module = modulesByName[destination];
                Destinations.Add(module);
                if (module is ConjunctionModule conjunction)
                {
                    conjunction.AddSource(this);
                }
            }
        }
    }

    private class ConjunctionModule(string name, Queue<(bool isHigh, IModule target, IModule source)> pulseQueue, IList<string> destinations) : IModule
    {
        public IDictionary<string, bool> Memory = new Dictionary<string, bool>();

        public Queue<(bool isHigh, IModule target, IModule source)> PulseQueue => pulseQueue;

        public bool LastFire { get; private set; }

        private long dl = 0;
        private long fr = 0;
        private long rv = 0;
        private long bt = 0;

        public long Part2 { get; private set; }
        public void ReceivePulse(bool isHigh, IModule from, int buttonCount)
        {
            
            Memory[from.Name] = isHigh;
            if (Memory.Values.All(h => h))
            {
                foreach (var destination in Destinations)
                {
                    pulseQueue.Enqueue((false, destination, this));
                    LastFire = false;
                }
            }
            else
            {
                foreach (var destination in Destinations)
                {
                    pulseQueue.Enqueue((true, destination, this));
                    LastFire = true;
                }
            }

            if (name == "rs")
            {
                if (dl == 0 && Memory["dl"])
                {
                    dl = buttonCount;
                    Part2 = dl * fr * rv * bt;
                }
                if (fr == 0 && Memory["fr"])
                {
                    fr = buttonCount;
                    Part2 = dl * fr * rv * bt;
                }
                if (rv == 0 && Memory["rv"])
                {
                    rv = buttonCount;
                    Part2 = dl * fr * rv * bt;
                }
                if (bt == 0 && Memory["bt"])
                {
                    bt = buttonCount;
                    Part2 = dl * fr * rv * bt;
                }
            }
        }

        public string Name => name;
        public IList<IModule> Destinations { get; } = new List<IModule>();
        public void Initialize(IDictionary<string, IModule> modulesByName)
        {
            foreach (var destination in destinations)
            {
                var module = modulesByName[destination];
                Destinations.Add(module);
                if (module is ConjunctionModule conjunction)
                {
                    conjunction.AddSource(this);
                }
            }
        }

        public void AddSource(IModule source)
        {
            Memory[source.Name] = false;
        }
    }

    private class BroadCasterModule(string name, Queue<(bool isHigh, IModule target, IModule source)> pulseQueue, IList<string> destinations) : IModule
    {
        public Queue<(bool isHigh, IModule target, IModule source)> PulseQueue => pulseQueue;
        public void ReceivePulse(bool isHigh, IModule from, int buttonCount)
        {
            foreach (var destination in Destinations)
            {
                pulseQueue.Enqueue((isHigh, destination, this));
            }
        }

        public string Name => name;
        public IList<IModule> Destinations { get; } = new List<IModule>();
        public void Initialize(IDictionary<string, IModule> modulesByName)
        {
            foreach (var destination in destinations)
            {
                var module = modulesByName[destination];
                Destinations.Add(module);
                if (module is ConjunctionModule conjunction)
                {
                    conjunction.AddSource(this);
                }
            }
        }
    }

    private class OutputModule(string name) : IModule
    {
        public Queue<(bool isHigh, IModule target, IModule source)> PulseQueue { get; }
        public void ReceivePulse(bool isHigh, IModule from, int buttonCount)
        {
        }

        public string Name => name;
        public IList<IModule> Destinations { get; }
        public void Initialize(IDictionary<string, IModule> modulesByName)
        {
        }
    }
    

    public override int Nummer => 202320;
}