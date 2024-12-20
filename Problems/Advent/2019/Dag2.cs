﻿using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2019;

public class Dag2 : Problem
{
    public override Task ExecuteAsync()
    {
        for (int noun = 0; noun <= 99; noun++)
        {
            for (int verb = 0; verb <= 99; verb++)
            {
                var input =
                    "1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,13,1,19,1,6,19,23,2,6,23,27,1,5,27,31,2,31,9,35,1,35,5,39,1,39,5,43,1,43,10,47,2,6,47,51,1,51,5,55,2,55,6,59,1,5,59,63,2,63,6,67,1,5,67,71,1,71,6,75,2,75,10,79,1,79,5,83,2,83,6,87,1,87,5,91,2,9,91,95,1,95,6,99,2,9,99,103,2,9,103,107,1,5,107,111,1,111,5,115,1,115,13,119,1,13,119,123,2,6,123,127,1,5,127,131,1,9,131,135,1,135,9,139,2,139,6,143,1,143,5,147,2,147,6,151,1,5,151,155,2,6,155,159,1,159,2,163,1,9,163,0,99,2,0,14,0";
                //var input = "1,1,1,4,99,5,6,0,99";
                var program = input.Split(',').Select(int.Parse).ToList();
                program[1] = noun;
                program[2] = verb;
                int currentPosition = 0;
                bool valid = true;
                var instruction = program[currentPosition];
                while (instruction != 99)
                {
                    if (instruction == 1)
                    {
                        program[program[currentPosition + 3]] =
                            program[program[currentPosition + 1]] + program[program[currentPosition + 2]];
                    }
                    else if (instruction == 2)
                    {
                        program[program[currentPosition + 3]] =
                            program[program[currentPosition + 1]] * program[program[currentPosition + 2]];
                    }
                    else
                    {
                        valid = false;
                        break;
                    }

                    currentPosition += 4;
                    instruction = program[currentPosition];
                }

                if (valid)
                {
                    if (program[0] == 19690720)
                    {
                        Result = (100 * noun + verb).ToString();
                        return Task.CompletedTask;
                    }
                }
            }
        }



        return Task.CompletedTask;
    }

    public override int Nummer => 201902;
}