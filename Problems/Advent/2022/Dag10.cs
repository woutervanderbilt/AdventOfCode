using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2022
{
    internal class Dag10 : Problem
    {
        private const string input = @"addx 2
addx 3
noop
addx 1
addx 27
addx -23
addx 5
noop
addx 1
noop
addx 4
addx 1
noop
addx 4
addx 5
noop
noop
noop
addx 5
addx -4
addx 4
noop
addx 1
addx -38
noop
noop
addx 7
addx 8
addx -3
noop
addx 3
noop
addx 5
noop
noop
addx -2
addx 2
addx 9
addx -2
addx 6
addx 1
addx -4
addx 5
addx 2
addx -14
addx -6
addx -16
addx 1
addx 5
addx 1
addx 4
addx -2
noop
addx -7
addx -3
addx 17
addx 5
noop
noop
addx 19
addx -16
noop
addx 14
addx -8
addx 2
noop
addx 4
noop
addx -35
addx -2
noop
noop
addx 7
addx 19
addx -26
addx 10
addx 29
addx -21
noop
addx 4
noop
noop
addx -9
addx 4
addx 8
addx 7
noop
addx -2
addx 5
addx 2
addx -19
addx -18
noop
noop
noop
noop
addx 7
addx -7
addx 37
addx -27
addx 5
addx 2
addx -12
addx 4
addx 11
noop
noop
noop
addx 5
addx -14
addx 21
addx -4
addx 5
addx 2
noop
addx -35
noop
noop
noop
noop
addx 7
addx 1
noop
noop
addx 5
addx -1
addx 5
addx 1
noop
addx 4
addx 1
noop
noop
addx 4
noop
addx 1
addx 2
addx 5
addx 2
addx 1
noop
noop
noop
noop";


        private const string testinput = @"addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop";
        public override Task ExecuteAsync()
        {
            int register = 1;
            int cycle = 0;
            long strenth = 0;
            var grid = new Grid<bool>();
            foreach (var line in input.Split(Environment.NewLine))
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
                    cycle ++;
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
            return Task.CompletedTask;
        }

        public override int Nummer => 202210;
    }
}
