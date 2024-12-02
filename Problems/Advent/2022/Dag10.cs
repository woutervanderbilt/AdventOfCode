using Algorithms.Extensions;
using Algorithms.Models;
using System;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag10 : Problem
{
    public override async Task ExecuteAsync()
    {
        int register = 1;
        int cycle = 0;
        long strenth = 0;
        var grid = new Grid<bool>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            if (line == "noop")
            {
                cycle++;
                AddSignalStrength();
            }
            else
            {
                var split = line.Split();
                var value = int.Parse(split[1]);
                cycle++;
                AddSignalStrength();
                cycle++;
                AddSignalStrength();
                register += value;
            }


        }
        grid.Print();
        void AddSignalStrength()
        {
            if (cycle % 40 == 20 && cycle < 260)
            {
                strenth += cycle * register;
            }

            if (cycle <= 240)
            {
                grid[(cycle - 1) % 40, 6 - (cycle - 1) / 40] = Math.Abs(register - (cycle - 1) % 40) <= 1;
                //grid.Print(true);
            }
        }

        Result = strenth.ToString();
    }

    public override int Nummer => 202210;
}