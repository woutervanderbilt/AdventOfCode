using System.Collections.Generic;
using System.Threading.Tasks;

namespace Problems.Advent._2017;

internal class Dag03 : Problem
{
    public override Task ExecuteAsync()
    {
        int direction = 0;
        IDictionary<(int, int), int> spiral = new Dictionary<(int, int), int>();
        (int x, int y) location = (0, 0);
        spiral[location] = 1;
        while (spiral[location] <= 325489)
        {
            Step();
            Fill();
        }

        Result = spiral[location].ToString();



        return Task.CompletedTask;

        void Step()
        {
            if (direction == 0)
            {
                if (!spiral.ContainsKey((location.x + 1, location.y)))
                {
                    direction = 1;
                    location = (location.x + 1, location.y);
                }
                else
                {
                    location = (location.x, location.y - 1);
                }
            }
            else if (direction == 1)
            {
                if (!spiral.ContainsKey((location.x, location.y + 1)))
                {
                    direction = 2;
                    location = (location.x, location.y + 1);
                }
                else
                {
                    location = (location.x + 1, location.y);
                }
            }
            else if (direction == 2)
            {
                if (!spiral.ContainsKey((location.x - 1, location.y)))
                {
                    direction = 3;
                    location = (location.x - 1, location.y);
                }
                else
                {
                    location = (location.x, location.y + 1);
                }
            }
            else
            {
                if (!spiral.ContainsKey((location.x, location.y - 1)))
                {
                    direction = 0;
                    location = (location.x, location.y - 1);
                }
                else
                {
                    location = (location.x - 1, location.y);
                }

            }
        }

        void Fill()
        {
            int sum = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (spiral.TryGetValue((location.x + i, location.y + j), out var value))
                    {
                        sum += value;
                    }

                }
            }

            spiral[location] = sum;
        }
    }

    public override int Nummer => 201703;
}