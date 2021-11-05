using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2018
{
    public class Dag12 : Problem
    {
        private const string input =
            @"##.######...#.##.#...#...##.####..###.#.##.#.##...##..#...##.#..##....##...........#.#.#..###.#

.###. => #
#.##. => .
.#.## => #
...## => .
###.# => #
##.## => .
..... => .
#..#. => #
..#.. => #
#.### => #
##.#. => .
..#.# => #
#.#.# => #
.##.# => #
.#..# => #
#..## => #
##..# => #
#...# => .
...#. => #
##### => .
###.. => #
#.#.. => .
....# => .
.#### => #
..### => .
..##. => #
.##.. => .
#.... => .
####. => #
.#.#. => .
.#... => #
##... => #";
        public override Task ExecuteAsync()
        {
            HashSet<byte> habitableConfigurations = new HashSet<byte>();
            foreach (var s in input.Split(new []{Environment.NewLine}, StringSplitOptions.None).Skip(2).Where(s => s.EndsWith("#")).Select(s => s.Substring(0,5)))
            {
                byte b = 0;
                byte c = 1;
                for (int i = 0; i < 5; i++)
                {
                    if (s[4 - i] == '#')
                    {
                        b += c;
                    }
                    c <<= 1;
                }

                habitableConfigurations.Add(b);
            }

            IList<byte> currentState = new List<byte> {0, 0, 0, 0};
            foreach (char c in input)
            {
                if (c == '#')
                {
                    currentState.Add(1);
                }
                else if (c == '.')
                {
                    currentState.Add(0);
                }
                else
                {
                    break;
                }
            }

            currentState.Add(0);
            currentState.Add(0);
            currentState.Add(0);
            currentState.Add(0);
            int offset = -4;
            int previous = GetResult(offset, currentState);
            for (int step = 1; step <= 1000; step++)
            {
                int count = currentState.Count;
                IList<byte> newState = new List<byte>{0,0,0,0};
                offset -= 4;
                for (int i = 0; i < currentState.Count; i++)
                {
                    byte c;
                    if (i == 0)
                    {
                        c = (byte) (4 * currentState[0] + 2 * currentState[1] + currentState[2]);
                    }
                    else if (i == 1)
                    {
                        c = (byte) (8 * currentState[0] + 4 * currentState[1] + 2 * currentState[2] + currentState[3]);
                    }
                    else if (i == count - 2)
                    {
                        c = (byte) (16 * currentState[count - 4] + 8 * currentState[count - 3] +
                                    4 * currentState[count - 2] + 2 * currentState[count - 1]);
                    }
                    else if (i == count - 1)
                    {
                        c = (byte) (16 * currentState[count - 3] + 8 * currentState[count - 2] +
                                    4 * currentState[count - 1]);
                    }
                    else
                    {
                        c = (byte) (16 * currentState[i - 2] + 8 * currentState[i - 1] + 4 * currentState[i] +
                                    2 * currentState[i + 1] + currentState[i + 2]);
                    }
                    newState.Add(habitableConfigurations.Contains(c) ? (byte)1 : (byte)0);
                }
                newState.Add(0);
                newState.Add(0);
                newState.Add(0);
                newState.Add(0);
                currentState = newState;

                int newResult = GetResult(offset, currentState);
                Console.WriteLine($"{step} : {newResult} ({newResult - previous})");
                previous = newResult;

            }

            var result = GetResult(offset, currentState);

            Result = result.ToString();
            return Task.CompletedTask;
        }

        private static int GetResult(int offset, IList<byte> currentState)
        {
            int result = 0;
            for (int p = offset; p < currentState.Count + offset; p++)
            {
                if (currentState[p - offset] == 1)
                {
                    result += p;
                }
            }

            return result;
        }

        public override int Nummer => 201812;
    }
}
