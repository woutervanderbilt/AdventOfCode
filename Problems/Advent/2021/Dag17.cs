using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2021;

internal class Dag17 : Problem
{
    private readonly (int x, int y) MinTarget = (240,-90);
    private readonly (int x, int y) MaxTarget = (292, -57);
    public override Task ExecuteAsync()
    {
        long highest = 0;
        var test = Try(6,9);
        int count = 0;

        for (int vx = 1; vx <= 400; vx++)
        {
            for (int vy = -400; vy <= 400; vy++)
            {
                var t = Try(vx, vy);
                if (t.Item1)
                {
                    count++;
                    highest = Math.Max(highest, t.Item2);
                }


            }
        }

        Result = $"{highest}  {count}";

        (bool, int) Try(int vx, int vy)
        {
            int maxy = 0;
            (int x, int y) position = (0, 0);
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            while (position.x <= MaxTarget.x && position.y >= MinTarget.y)
            {
                if (position.x >= MinTarget.x && position.y <= MaxTarget.y)
                {
                    return (true, maxy);
                }

                position = Step();
                maxy = Math.Max(maxy, position.y);
                visited.Add(position);

            }

            return (false, 0);

            (int x, int y) Step()
            {
                var result = (position.x + vx, position.y + vy);
                if (vx > 0)
                {
                    vx--;
                }
                else if (vx < 0)
                {
                    vx++;
                }

                vy--;
                return result;
            }
        }

        return Task.CompletedTask;
    }

    public override int Nummer => 202117;
}