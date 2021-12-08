using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms.Models;

namespace Problems.Advent._2018
{
    internal class ElfDevice
    {
        public ElfDevice(string input, int registerSize)
        {
            foreach (var line in input.Split(Environment.NewLine))
            {
                if (line.StartsWith("#ip"))
                {
                    InstructionPointerBinding = int.Parse(line.Last().ToString());
                }
                else
                {
                    program.Add(line);
                }
            }

            Register = new int[registerSize];
        }

        private IList<string> program = new List<string>();

        public int[] Register { get; set; }

        private int InstructionPointerBinding { get; set; }

        private int InstructionPointer { get; set; }

        private Counter<int> LineCounter = new Counter<int>();

        public bool ExecuteInstruction()
        {
            LineCounter[InstructionPointer]++;
            if (InstructionPointer < 0 || InstructionPointer >= program.Count)
            {
                return false;
            }

            Register[InstructionPointerBinding] = InstructionPointer;
            var line = program[Register[InstructionPointerBinding]];
            if (!new int[] { 3, 4, 5, 6, 8, 9, 10, 11 }.Contains(InstructionPointer))
            {
                Console.WriteLine($"{line}      {string.Join(',', Register)}     {InstructionPointer}");
            }
            //Console.WriteLine($"{line}      {string.Join(',',Register)}     {InstructionPointer}");
            var split = line.Split(' ');
            var name = split[0];
            var instructions = split.Skip(1).Select(int.Parse).ToList();
            int[] result = new int[Register.Length];
            for (int i = 0; i < Register.Length; i++)
            {
                if (instructions[2] != i)
                {
                    result[i] = Register[i];
                }
            }

            int a = instructions[0];
            int b = instructions[1];
            int c = instructions[2];
            int value = 0;
            switch (name)
            {
                case "addr":
                    value = Register[a] + Register[b];
                    break;
                case "addi":
                    value = Register[a] + b;
                    break;
                case "mulr":
                    value = Register[a] * Register[b];
                    break;
                case "muli":
                    value = Register[a] * b;
                    break;
                case "banr":
                    value = Register[a] & Register[b];
                    break;
                case "bani":
                    value = Register[a] & b;
                    break;
                case "borr":
                    value = Register[a] | Register[b];
                    break;
                case "bori":
                    value = Register[a] | b;
                    break;
                case "setr":
                    value = Register[a];
                    break;
                case "seti":
                    value = a;
                    break;
                case "gtir":
                    value = a > Register[b] ? 1 : 0;
                    break;
                case "gtri":
                    value = Register[a] > b ? 1 : 0;
                    break;
                case "gtrr":
                    value = Register[a] > Register[b] ? 1 : 0;
                    break;
                case "eqir":
                    value = a == Register[b] ? 1 : 0;
                    break;
                case "eqri":
                    value = Register[a] == b ? 1 : 0;
                    break;
                case "eqrr":
                    value = Register[a] == Register[b] ? 1 : 0;
                    break;
            }

            result[c] = value;

            Register = result;
            InstructionPointer = Register[InstructionPointerBinding] + 1;
            return true;
        }
    }
}
