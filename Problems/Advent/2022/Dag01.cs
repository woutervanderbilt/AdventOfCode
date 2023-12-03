using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2022
{
    internal class Dag01 : Problem
    {

        public override async Task ExecuteAsync()
        {
            var input = await GetInputAsync();
            int elf1 = 0;
            int elf2 = 0;
            int elf3 = 0;

            int current = 0;
            foreach (var line in input.Split(Environment.NewLine))
            {
                if (int.TryParse(line, out var calories))
                {
                    current += calories;
                }
                else
                {
                    if (current > elf3)
                    {
                        if (current > elf2)
                        {
                            if (current > elf1)
                            {
                                elf3 = elf2;
                                elf2 = elf1;
                                elf1 = current;
                            }
                            else
                            {
                                elf3 = elf2;
                                elf2 = current;
                            }
                        }
                        else
                        {
                            elf3 = current;
                        }

                    }

                    current = 0;
                }
            }

            Result = (elf1 + elf2 + elf3).ToString();
        }

        public override int Nummer => 202201;
    }
}
