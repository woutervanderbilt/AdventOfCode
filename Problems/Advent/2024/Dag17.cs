using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Problems.Advent._2024;

internal class Dag17 : Problem
{
    public override async Task ExecuteAsync()
    {
        var computer = new Computer(Input);
        Result = string.Join(',', computer.Run());


        string target = Input.Split(Environment.NewLine)[4].Substring(9);

        long min = long.MaxValue;
        IList<long> endings = [0];
        while (endings.Any())
        {
            IList<long> newEndings = [];
            foreach (var ending in endings)
            {
                foreach (var l in Try(ending * 8))
                {
                    newEndings.Add(l);
                }
            }

            endings = newEndings;
        }

        Result += $"  {min}";

        IEnumerable<long> Try(long aa)
        {
            for (long a = aa + 0; a <= aa + 7; a++)
            {
                var computer = new Computer(Input);
                computer.SetA(a);

                var output = computer.Run();

                var outputAsString = string.Join(',', output);
                if(target.EndsWith(outputAsString))
                {
                    if (target == outputAsString)
                    {
                        if (a < min)
                        {
                            min = a;
                        }
                    }
                    else
                    {
                        yield return a;
                    }
                }
            }
        }

    }

    private class Computer
    {
        public Computer(string input)
        {
            var lines = input.Split(Environment.NewLine);
            A = lines[0].FindAllNumbers().First(); ;
            B = lines[1].FindAllNumbers().First();
            C = lines[2].FindAllNumbers().First();
            Instructions = lines[4].FindAllNumbersAsInt().ToArray();
        }

        private long A { get; set; }
        private long B { get; set; }
        private long C { get; set; }
        private int Pointer { get; set; }
        private int[] Instructions { get; set; }
        private IList<long> Output { get; set; } = [];

        public void SetA(long a) => A = a;

        public IList<long> Run()
        {
            while (Step())
            {
                // Do nothing
            }
            return Output;
        }

        private bool Step()
        {
            if (Pointer >= Instructions.Length - 1)
            {
                return false;
            }
            bool jump = true;
            ExecuteInstruction(Instructions[Pointer], Instructions[Pointer + 1]);
            if (jump)
            {
                Pointer += 2;
            }

            return true;

            void ExecuteInstruction(int opCode, int operand)
            {
                if (opCode == 0)
                {
                    A >>= (int)Combo(operand);
                }
                else if (opCode == 1)
                {
                    B ^= operand;
                }
                else if (opCode == 2)
                {
                    B = Combo(operand) % 8;
                }
                else if (opCode == 3)
                {
                    if (A != 0)
                    {
                        jump &= Pointer == operand;
                        Pointer = operand;
                    }
                }
                else if (opCode == 4)
                {
                    B ^= C;
                }
                else if (opCode == 5)
                {
                    Output.Add(Combo(operand)  % 8);
                }
                else if (opCode == 6)
                {
                    B = A >> (int)Combo(operand);
                }
                else if (opCode == 7)
                {
                    C = A >> (int)Combo(operand);
                }
            }
        }

        private long Combo(int operand)
        {
            return operand switch
            {
                <= 3 => operand,
                4 => A,
                5 => B,
                6 => C,
                _ => throw new InvalidOperationException()
            };
        }
    }

    protected override bool UseTestInput => false;

    protected override string TestInput => @"Register A: 729
Register B: 0
Register C: 0

Program: 0,1,5,4,3,0";

    public override int Nummer => 202417;
}