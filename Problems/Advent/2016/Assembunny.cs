using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Advent;

public class Assembunny
{
    private IList<string> instructions;

    public Assembunny(string program)
    {
        instructions = program.Split(Environment.NewLine).ToList();
    }

    public IEnumerable<int> Run()
    {
        while (!Finished)
        {
            //Console.WriteLine($"{A} {B} {C} {D}   {instructions[Index]}");
            var step = Step();
            if (step.HasValue)
            {
                yield return step.Value;
            }
        }
    }

    private int? Step()
    {
        int? output = null;
        var instruction = instructions[Index].Split(' ').ToList();
        if (instruction[0] == "cpy")
        {
            int value = instruction[1] switch
            {
                "a" => A,
                "b" => B,
                "c" => C,
                "d" => D,
                _ => int.Parse(instruction[1])
            };
            _ = instruction[2] switch
            {
                "a" => A = value,
                "b" => B = value,
                "c" => C = value,
                "d" => D = value
            };
            Index++;
        }
        else if (instruction[0] == "inc")
        {
            _ = instruction[1] switch
            {
                "a" => A++,
                "b" => B++,
                "c" => C++,
                "d" => D++
            };
            Index++;
        }
        else if (instruction[0] == "dec")
        {
            _ = instruction[1] switch
            {
                "a" => A--,
                "b" => B--,
                "c" => C--,
                "d" => D--
            };
            Index++;
        }
        else if (instruction[0] == "jnz")
        {
            int value = instruction[1] switch
            {
                "a" => A,
                "b" => B,
                "c" => C,
                "d" => D,
                _ => int.Parse(instruction[1])
            };
            if (value != 0)
            {
                Index += instruction[2] switch
                {
                    "a" => A,
                    "b" => B,
                    "c" => C,
                    "d" => D,
                    _ => int.Parse(instruction[2])
                };
            }
            else
            {
                Index++;
            }
        }
        else if (instruction[0] == "tgl")
        {
            int indexToToggle = Index + (instruction[1] switch
            {
                "a" => A,
                "b" => B,
                "c" => C,
                "d" => D,
                _ => int.Parse(instruction[2])
            });
            if (indexToToggle < instructions.Count)
            {
                var instructionToToggle = instructions[indexToToggle];
                Console.WriteLine($"{indexToToggle}  {instructionToToggle}");
                var split = instructionToToggle.Split(' ');
                if (split.Length == 2)
                {
                    if (split[0] == "inc")
                    {
                        instructions[indexToToggle] = instructionToToggle.Replace("inc", "dec");
                    }
                    else
                    {
                        instructions[indexToToggle] = "inc" + instructionToToggle.Substring(3);
                    }
                }
                else
                {
                    if (split[0] == "jnz")
                    {
                        instructions[indexToToggle] = instructionToToggle.Replace("jnz", "cpy");
                    }
                    else
                    {
                        instructions[indexToToggle] = "jnz" + instructionToToggle.Substring(3);
                    }
                }
            }

            Index++;
        }
        else if (instruction[0] == "out")
        {
            output = instruction[1] switch
            {
                "a" => A,
                "b" => B,
                "c" => C,
                "d" => D,
                _ => int.Parse(instruction[1])
            };
            //Console.WriteLine($"{A}");
            Index++;
        }

        if (Index >= instructions.Count)
        {
            Finished = true;
        }

        return output;
    }
    public bool Finished { get; set; }
    public int Index { get; set; }

    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }
    public int D { get; set; }
}