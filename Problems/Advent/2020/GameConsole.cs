using System;
using System.Collections.Generic;
using System.Text;

namespace Problems.Advent._2020
{
    public class GameConsole
    {
        public GameConsole(string input)
        {
            Instructions = new List<Instruction>();
            foreach (var line in input.Split(Environment.NewLine))
            {
                var split = line.Split(' ');
                InstructionType type = split[0] switch
                {
                    "acc" => InstructionType.Acc,
                    "jmp" => InstructionType.Jmp,
                    "nop" => InstructionType.Nop,
                    _ => throw new Exception("Onbekende instructie")
                };
                var argument = int.Parse(split[1].Substring(1)) * (split[1][0] == '-' ? -1 : 1);
                Instructions.Add(new Instruction{Operation = type, Argument = argument});
            }
        }

        public IList<Instruction> Instructions { get; }
        public int Pointer { get; set; }
        public long Accumulator { get; set; }
        public bool IsRunning { get; set; }

        public void Step()
        {
            if (Pointer >= Instructions.Count)
            {
                IsRunning = false;
                return;
            }
            var instruction = Instructions[Pointer];
            if (instruction.Operation == InstructionType.Acc)
            {
                Acc(instruction.Argument);
            }
            else if (instruction.Operation == InstructionType.Jmp)
            {
                Jmp(instruction.Argument);
            }
            else if(instruction.Operation == InstructionType.Nop)
            {
                Nop(instruction.Argument);
            }
        }

        public void Run()
        {
            IsRunning = true;
            while (IsRunning)
            {
                Step();
            }
        }

        public void Acc(int p)
        {
            Accumulator += p;
            Pointer++;
        }

        public void Jmp(int p)
        {
            Pointer += p;
        }

        public void Nop(int p)
        {
            Pointer++;
        }

        public class Instruction
        {
            public InstructionType Operation { get; set; }
            public int Argument { get; set; }
        }

        public enum InstructionType
        {
            Acc,
            Jmp,
            Nop
        }
    }

}
