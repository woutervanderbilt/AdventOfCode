using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Problems.Advent._2019
{
    public class Dag7 : Problem
    {
        private string program =
            @"3,8,1001,8,10,8,105,1,0,0,21,34,59,68,89,102,183,264,345,426,99999,3,9,102,5,9,9,1001,9,5,9,4,9,99,3,9,101,3,9,9,1002,9,5,9,101,5,9,9,1002,9,3,9,1001,9,5,9,4,9,99,3,9,101,5,9,9,4,9,99,3,9,102,4,9,9,101,3,9,9,102,5,9,9,101,4,9,9,4,9,99,3,9,1002,9,5,9,1001,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,101,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,99,3,9,1001,9,1,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,99,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1001,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,99,3,9,101,1,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,102,2,9,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,101,2,9,9,4,9,99,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,102,2,9,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,3,9,101,1,9,9,4,9,3,9,1001,9,1,9,4,9,3,9,1001,9,2,9,4,9,3,9,1002,9,2,9,4,9,99";



        public override Task ExecuteAsync()
        {
            Result = Part2().ToString();
            return Task.CompletedTask;
            long max = 0;
            foreach (var permutation in Enumerable.Range(0,5).Permutations().Select(p => p.ToList()))
            {
                long input = 0;
                for (int i = 0; i < 5; i++)
                {
                    var computer = new IntCodeComputer(program);
                    computer.Compile();
                    computer.AddParameters(permutation[i], input);
                    input = computer.Run().First();
                }

                if (input > max)
                {
                    max = input;
                }
            }

            Result = max.ToString();
            return Task.CompletedTask;
        }

        private long Part2()
        {
            long max = 0;
            foreach (var permutation in Enumerable.Range(5, 5).Permutations().Select(p => p.ToList()))
            {
                IList<IntCodeComputer> amplifiers = new List<IntCodeComputer>();
                for (int i = 0; i < 5; i++)
                {
                    var amplifier = new IntCodeComputer(program);
                    amplifier.Compile();
                    amplifier.AddParameters(permutation[i]);
                    amplifiers.Add(amplifier);
                }
                amplifiers[0].AddParameters(0);

                bool running = true;
                long finalOutput = 0;
                while (running)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        var amplifier = amplifiers[i];
                        var nextAmplifier = amplifiers[(i + 1) % 5];
                        foreach (var output in amplifier.Run())
                        {
                            finalOutput = output;
                            nextAmplifier.AddParameters(output);
                        }

                        if (i == 4 && !amplifier.IsRunning)
                        {
                            running = false;
                        }
                    }
                }
                if (finalOutput > max)
                {
                    max = finalOutput;
                }
            }

            return max;
        }

        public override int Nummer => 201907;
    }
}
