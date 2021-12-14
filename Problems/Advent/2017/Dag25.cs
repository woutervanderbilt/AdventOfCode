using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2017
{
    internal class Dag25 : Problem
    {
        public override Task ExecuteAsync()
        {
            string state = "A";
            int pointer = 0;
            HashSet<int> tape = new HashSet<int>();
            for (int i = 0; i < 12656374; i++)
            {
                switch (state)
                {
                    case "A":
                        if (tape.Contains(pointer))
                        {
                            tape.Remove(pointer);
                            pointer--;
                            state = "C";
                        }
                        else
                        {
                            tape.Add(pointer);
                            pointer++;
                            state = "B";
                        }
                        break;
                    case "B":
                        if (tape.Contains(pointer))
                        {
                            pointer--;
                            state = "D";
                        }
                        else
                        {
                            tape.Add(pointer);
                            pointer--;
                            state = "A";
                        }
                        break;
                    case "C":
                        if (tape.Contains(pointer))
                        {
                            tape.Remove(pointer);
                            pointer++;
                        }
                        else
                        {
                            tape.Add(pointer);
                            pointer++;
                            state = "D";
                        }
                        break;
                    case "D":
                        if (tape.Contains(pointer))
                        {
                            tape.Remove(pointer);
                            pointer++;
                            state = "E";
                        }
                        else
                        {
                            pointer--;
                            state = "B";
                        }
                        break;
                    case "E":
                        if (tape.Contains(pointer))
                        {
                            pointer--;
                            state = "F";
                        }
                        else
                        {
                            tape.Add(pointer);
                            pointer++;
                            state = "C";
                        }
                        break;
                    case "F":
                        if (tape.Contains(pointer))
                        {
                            pointer++;
                            state = "A";
                        }
                        else
                        {
                            tape.Add(pointer);
                            pointer--;
                            state = "E";
                        }
                        break;
                }
            }

            Result = tape.Count.ToString();
            return Task.CompletedTask;
        }

        public override int Nummer => 201725;
    }
}
