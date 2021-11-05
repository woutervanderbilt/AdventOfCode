using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent
{
    public class Dag13 : Problem
    {
        private const int input = 1350;

        public override Task ExecuteAsync()
        {
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            IList<(int, int)> current = new List<(int, int)>();
            visited.Add((1, 1));
            current.Add((1,1));
            int step = 0;
            bool found = false;
            while (step < 50)
            {
                step++;
                IList<(int, int)> next = new List<(int, int)>();
                foreach ((int x, int y) location in current)
                {
                    foreach (var neighbour in Neighbours(location.x, location.y))
                    {
                        if (!visited.Contains(neighbour))
                        {
                            visited.Add(neighbour);
                            next.Add(neighbour);
                            if (neighbour == (31, 39))
                            {
                                found = true;
                            }
                        }
                    }
                }

                current = next;
            }

            Result = visited.Count.ToString();
            return Task.CompletedTask;
        }

        IEnumerable<(int, int)> Neighbours(int x, int y)
        {
            if (x > 0)
            {
                if (IsOpen(x - 1, y))
                {
                    yield return (x - 1, y);
                }
            }

            if (y > 0)
            {
                if (IsOpen(x, y - 1))
                {
                    yield return (x, y - 1);
                }
            }
            if (IsOpen(x + 1, y))
            {
                yield return (x + 1, y);
            }
            if (IsOpen(x, y + 1))
            {
                yield return (x, y + 1);
            }
        }

        bool IsOpen(int x, int y)
        {
            var b = x * x + 3 * x + 2 * x * y + y + y * y + input;
            bool isOpen = true;
            while (b > 0)
            {
                isOpen ^= b % 2 == 1;
                b >>= 1;
            }

            return isOpen;
        }

        public override int Nummer => 201613;
    }
}
