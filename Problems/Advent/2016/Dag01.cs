using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Problems.Advent;

class Dag01 : Problem
{
    private const string input =
        @"L1, R3, R1, L5, L2, L5, R4, L2, R2, R2, L2, R1, L5, R3, L4, L1, L2, R3, R5, L2, R5, L1, R2, L5, R4, R2, R2, L1, L1, R1, L3, L1, R1, L3, R5, R3, R3, L4, R4, L2, L4, R1, R1, L193, R2, L1, R54, R1, L1, R71, L4, R3, R191, R3, R2, L4, R3, R2, L2, L4, L5, R4, R1, L2, L2, L3, L2, L1, R4, R1, R5, R3, L5, R3, R4, L2, R3, L1, L3, L3, L5, L1, L3, L3, L1, R3, L3, L2, R1, L3, L1, R5, R4, R3, R2, R3, L1, L2, R4, L3, R1, L1, L1, R5, R2, R4, R5, L1, L1, R1, L2, L4, R3, L1, L3, R5, R4, R3, R3, L2, R2, L1, R4, R2, L3, L4, L2, R2, R2, L4, R3, R5, L2, R2, R4, R5, L2, L3, L2, R5, L4, L2, R3, L5, R2, L1, R1, R3, R3, L5, L2, L2, R5";

    public override Task ExecuteAsync()
    {
        int x = 0;
        int y = 0;
        int direction = 0;
        HashSet<(int, int)> visited = new HashSet<(int, int)> { (0, 0) };
        foreach (var s in input.Split(','))
        {
            var trimmed = s.Trim();
            if (trimmed.StartsWith("R"))
            {
                direction = (direction + 1) % 4;
            }
            else
            {
                direction = (direction + 3) % 4;
            }

            int d = int.Parse(trimmed.Substring(1));
            if (direction == 0)
            {
                for (int i = 1; i <= d; i++)
                {
                    y++;
                    if (Check())
                    {
                        Result = (Math.Abs(x) + Math.Abs(y)).ToString();
                        return Task.CompletedTask;
                    }
                }
            }
            else if (direction == 1)
            {
                for (int i = 1; i <= d; i++)
                {
                    x++;
                    if (Check())
                    {
                        Result = (Math.Abs(x) + Math.Abs(y)).ToString();
                        return Task.CompletedTask;
                    }
                }
            }
            else if (direction == 2)
            {
                for (int i = 1; i <= d; i++)
                {
                    y--;
                    if (Check())
                    {
                        Result = (Math.Abs(x) + Math.Abs(y)).ToString();
                        return Task.CompletedTask;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= d; i++)
                {
                    x--;
                    if (Check())
                    {
                        Result = (Math.Abs(x) + Math.Abs(y)).ToString();
                        return Task.CompletedTask;
                    }
                }
            }
        }

        bool Check()
        {
            if (visited.Contains((x, y)))
            {
                return true;
            }

            visited.Add((x, y));
            return false;
        }
        Result = (Math.Abs(x) + Math.Abs(y)).ToString();
        return Task.CompletedTask;
    }

    public override int Nummer => 201601;
}