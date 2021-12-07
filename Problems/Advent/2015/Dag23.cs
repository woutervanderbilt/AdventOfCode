using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2015
{
    internal class Dag23 : Problem
    {
        private const string input = @"jio a, +16
inc a
inc a
tpl a
tpl a
tpl a
inc a
inc a
tpl a
inc a
inc a
tpl a
tpl a
tpl a
inc a
jmp +23
tpl a
inc a
inc a
tpl a
inc a
inc a
tpl a
tpl a
inc a
inc a
tpl a
inc a
tpl a
inc a
tpl a
inc a
inc a
tpl a
inc a
tpl a
tpl a
inc a
jio a, +8
inc b
jie a, +4
tpl a
inc a
jmp +2
hlf a
jmp -7";

        public override Task ExecuteAsync()
        {
            var instructions = input.Split(Environment.NewLine).Select(l => l.Replace(",","").Split(' ')).ToList();
            IDictionary<string, long> registers = new Dictionary<string, long>();
            registers["a"] = 1;
            registers["b"] = 0;
            int index = 0;
            while (index >= 0 && index < instructions.Count)
            {
                var instruction = instructions[index];
                switch (instruction[0])
                {
                    case "hlf":
                        registers[instruction[1]] /= 2;
                        index++;
                        break;
                    case "tpl":
                        registers[instruction[1]] *= 3;
                        index++;
                        break;
                    case "inc":
                        registers[instruction[1]]++;
                        index++;
                        break;
                    case "jmp":
                        index += int.Parse(instruction[1]);
                        break;
                    case "jie":
                        if (registers[instruction[1]] % 2 == 0)
                        {
                            index += int.Parse(instruction[2]);
                        }
                        else
                        {
                            index++;
                        }
                        break;
                    case "jio":
                        if (registers[instruction[1]] == 1)
                        {
                            index += int.Parse(instruction[2]);
                        }
                        else
                        {
                            index++;
                        }
                        break;
                }
            }

            Result = registers["b"].ToString();
            return Task.CompletedTask;
        }

        public override int Nummer => 201523;
    }
}
