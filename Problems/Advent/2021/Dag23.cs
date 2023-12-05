using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2021;

internal class Dag23 : Problem
{
    private const string input = @"#############
#...........#
###B#C#A#B###
  #C#D#D#A#
  #########";

    private const string input2 = @"#############
#...........#
###B#C#A#B###
  #D#C#B#A#
  #D#B#A#C#
  #C#D#D#A#
  #########";

    private const string testinput = @"#############
#...........#
###B#C#B#D###
  #A#D#C#A#
  #########";

    public override Task ExecuteAsync()
    {
        var state = new State{RoomA = "", RoomB = "", RoomC = "", RoomD = "", Hallway = "......."};
            
        foreach (var line in input2.Split(Environment.NewLine).Skip(2))
        {
            if (line.StartsWith("  ##"))
            {
                break;
            }
            else
            {
                state.RoomA += line[3];
                state.RoomB += line[5];
                state.RoomC += line[7];
                state.RoomD += line[9];
            }
        }

        State.RoomLength = state.RoomA.Length;

        var targetState = new State
        {
            Hallway = ".......",
            RoomA = "".PadRight(State.RoomLength, 'A'),
            RoomB = "".PadRight(State.RoomLength, 'B'),
            RoomC = "".PadRight(State.RoomLength, 'C'),
            RoomD = "".PadRight(State.RoomLength, 'D')
        };

        IDictionary<State, int> costs = new Dictionary<State, int>();
        var queue = new PriorityQueue<State, int>();
        queue.Enqueue(state, 0);
        while (queue.TryDequeue(out var s, out var cost))
        {
            foreach (var move in s.Moves())
            {
                if (!costs.TryGetValue(move.state, out var prevCost) || prevCost > cost + move.cost)
                {
                    costs[move.state] = cost + move.cost;
                    queue.Enqueue(move.state, cost + move.cost);
                    if (move.state.Equals(targetState))
                    {
                        break;
                    }
                }
            }
        }

        Result = costs[targetState].ToString();
        return Task.CompletedTask;
    }

    private class State
    {
        public static int RoomLength { get; set; }
        public string Hallway { get; set; }
        public string RoomA { get; set; }
        public string RoomB { get; set; }
        public string RoomC { get; set; }
        public string RoomD { get; set; }

        public IEnumerable<(State state, int cost)> Moves()
        {
            for (int i = 0; i < 7; i++)
            {
                var amphipod = Hallway[i];
                if (amphipod == '.')
                {
                    continue;
                }

                if (amphipod == 'A' && RoomA.All(c => c == '.' || c == amphipod))
                {
                    if (i < 2)
                    {
                        var hallwayCost = HallwayCost(i, 'A');
                        if (Hallway.Substring(i + 1, 1 - i).All(c => c == '.'))
                        {
                            var count = RoomA.Count(c => c == amphipod) + 1;
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(i, 1).Insert(i, ".");
                            copy.RoomA = "".PadRight(count, amphipod).PadLeft(RoomLength, '.');
                            yield return (copy, (hallwayCost + RoomLength - count + 1) * Energy(amphipod));
                        }
                    }
                    else
                    {
                        var hallwayCost = HallwayCost(i, 'A');
                        if (Hallway.Substring(2, i - 2).All(c => c == '.'))
                        {
                            var count = RoomA.Count(c => c == amphipod) + 1;
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(i, 1).Insert(i, ".");
                            copy.RoomA = "".PadRight(count, amphipod).PadLeft(RoomLength, '.');
                            yield return (copy, (hallwayCost + RoomLength - count + 1) * Energy(amphipod));
                        }
                    }
                }

                else if (amphipod == 'B' && RoomB.All(c => c == '.' || c == amphipod))
                {
                    if (i < 3)
                    {
                        var hallwayCost = HallwayCost(i, 'B');
                        if (Hallway.Substring(i + 1, 2 - i).All(c => c == '.'))
                        {
                            var count = RoomB.Count(c => c == amphipod) + 1;
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(i, 1).Insert(i, ".");
                            copy.RoomB = "".PadRight(count, amphipod).PadLeft(RoomLength, '.');
                            yield return (copy, (hallwayCost + RoomLength - count + 1) * Energy(amphipod));
                        }
                    }
                    else
                    {
                        var hallwayCost = HallwayCost(i, 'B');
                        if (Hallway.Substring(3, i - 3).All(c => c == '.'))
                        {
                            var count = RoomB.Count(c => c == amphipod) + 1;
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(i, 1).Insert(i, ".");
                            copy.RoomB = "".PadRight(count, amphipod).PadLeft(RoomLength, '.');
                            yield return (copy, (hallwayCost + RoomLength - count + 1) * Energy(amphipod));
                        }
                    }
                }

                else if (amphipod == 'C' && RoomC.All(c => c == '.' || c == amphipod))
                {
                    if (i < 4)
                    {
                        var hallwayCost = HallwayCost(i, 'C');
                        if (Hallway.Substring(i + 1, 3 - i).All(c => c == '.'))
                        {
                            var count = RoomC.Count(c => c == amphipod) + 1;
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(i, 1).Insert(i, ".");
                            copy.RoomC = "".PadRight(count, amphipod).PadLeft(RoomLength, '.');
                            yield return (copy, (hallwayCost + RoomLength - count + 1) * Energy(amphipod));
                        }
                    }
                    else
                    {
                        var hallwayCost = HallwayCost(i, 'C');
                        if (Hallway.Substring(4, i - 4).All(c => c == '.'))
                        {
                            var count = RoomC.Count(c => c == amphipod) + 1;
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(i, 1).Insert(i, ".");
                            copy.RoomC = "".PadRight(count, amphipod).PadLeft(RoomLength, '.');
                            yield return (copy, (hallwayCost + RoomLength - count + 1) * Energy(amphipod));
                        }
                    }
                }

                else if (amphipod == 'D' && RoomD.All(c => c == '.' || c == amphipod))
                {
                    if (i < 5)
                    {
                        var hallwayCost = HallwayCost(i, 'D');
                        if (Hallway.Substring(i + 1, 4 - i).All(c => c == '.'))
                        {
                            var count = RoomD.Count(c => c == amphipod) + 1;
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(i, 1).Insert(i, ".");
                            copy.RoomD = "".PadRight(count, amphipod).PadLeft(RoomLength, '.');
                            yield return (copy, (hallwayCost + RoomLength - count + 1) * Energy(amphipod));
                        }
                    }
                    else
                    {
                        var hallwayCost = HallwayCost(i, 'D');
                        if (Hallway.Substring(5, i - 5).All(c => c == '.'))
                        {
                            var count = RoomD.Count(c => c == amphipod) + 1;
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(i, 1).Insert(i, ".");
                            copy.RoomD = "".PadRight(count, amphipod).PadLeft(RoomLength, '.');
                            yield return (copy, (hallwayCost + RoomLength - count + 1) * Energy(amphipod));
                        }
                    }
                }
            }

            if (!RoomA.All(c => c == '.' || c == 'A'))
            {
                var roomATop = RoomA.FirstOrDefault(c => c != '.');
                if (roomATop != default(char))
                {
                    int index = RoomA.IndexOf(roomATop);

                    for (int l = 1; l >= 0; l--)
                    {
                        if (Hallway[l] == '.')
                        {
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(l, 1).Insert(l, roomATop.ToString());
                            copy.RoomA = copy.RoomA.Remove(index, 1).Insert(index, ".");
                            yield return (copy, Energy(roomATop) * (index + 1 + HallwayCost(l, 'A')));
                        }
                        else
                        {
                            break;
                        }
                    }

                    for (int r = 2; r <= 6; r++)
                    {
                        if (Hallway[r] == '.')
                        {
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(r, 1).Insert(r, roomATop.ToString());
                            copy.RoomA = copy.RoomA.Remove(index, 1).Insert(index, ".");
                            yield return (copy, Energy(roomATop) * (index + 1 + HallwayCost(r, 'A')));
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (!RoomB.All(c => c == '.' || c == 'B'))
            {
                var roomBTop = RoomB.FirstOrDefault(c => c != '.');
                if (roomBTop != default(char))
                {
                    int index = RoomB.IndexOf(roomBTop);

                    for (int l = 2; l >= 0; l--)
                    {
                        if (Hallway[l] == '.')
                        {
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(l, 1).Insert(l, roomBTop.ToString());
                            copy.RoomB = copy.RoomB.Remove(index, 1).Insert(index, ".");
                            yield return (copy, Energy(roomBTop) * (index + 1 + HallwayCost(l, 'B')));
                        }
                        else
                        {
                            break;
                        }
                    }

                    for (int r = 3; r <= 6; r++)
                    {
                        if (Hallway[r] == '.')
                        {
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(r, 1).Insert(r, roomBTop.ToString());
                            copy.RoomB = copy.RoomB.Remove(index, 1).Insert(index, ".");
                            yield return (copy, Energy(roomBTop) * (index + 1 + HallwayCost(r, 'B')));
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (!RoomC.All(c => c == '.' || c == 'C'))
            {
                var roomCTop = RoomC.FirstOrDefault(c => c != '.');
                if (roomCTop != default(char))
                {
                    int index = RoomC.IndexOf(roomCTop);

                    for (int l = 3; l >= 0; l--)
                    {
                        if (Hallway[l] == '.')
                        {
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(l, 1).Insert(l, roomCTop.ToString());
                            copy.RoomC = copy.RoomC.Remove(index, 1).Insert(index, ".");
                            yield return (copy, Energy(roomCTop) * (index + 1 + HallwayCost(l, 'C')));
                        }
                        else
                        {
                            break;
                        }
                    }

                    for (int r = 4; r <= 6; r++)
                    {
                        if (Hallway[r] == '.')
                        {
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(r, 1).Insert(r, roomCTop.ToString());
                            copy.RoomC = copy.RoomC.Remove(index, 1).Insert(index, ".");
                            yield return (copy, Energy(roomCTop) * (index + 1 + HallwayCost(r, 'C')));
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (!RoomD.All(c => c == '.' || c == 'D'))
            {
                var roomDTop = RoomD.FirstOrDefault(c => c != '.');
                if (roomDTop != default(char))
                {
                    int index = RoomD.IndexOf(roomDTop);

                    for (int l = 4; l >= 0; l--)
                    {
                        if (Hallway[l] == '.')
                        {
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(l, 1).Insert(l, roomDTop.ToString());
                            copy.RoomD = copy.RoomD.Remove(index, 1).Insert(index, ".");
                            yield return (copy, Energy(roomDTop) * (index + 1 + HallwayCost(l, 'D')));
                        }
                        else
                        {
                            break;
                        }
                    }

                    for (int r = 5; r <= 6; r++)
                    {
                        if (Hallway[r] == '.')
                        {
                            var copy = Copy();
                            copy.Hallway = copy.Hallway.Remove(r, 1).Insert(r, roomDTop.ToString());
                            copy.RoomD = copy.RoomD.Remove(index, 1).Insert(index, ".");
                            yield return (copy, Energy(roomDTop) * (index + 1 + HallwayCost(r, 'D')));
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        int Energy(char c)
        {
            return c switch
            {
                'A' => 1,
                'B' => 10,
                'C' => 100,
                'D' => 1000
            };
        }

        int HallwayCost(int i, char room)
        {
            if (room == 'A')
            {
                return i switch
                {
                    0 => 2,
                    1 => 1,
                    2 => 1,
                    3 => 3,
                    4 => 5,
                    5 => 7,
                    6 => 8
                };
            }
            if (room == 'B')
            {
                return i switch
                {
                    0 => 4,
                    1 => 3,
                    2 => 1,
                    3 => 1,
                    4 => 3,
                    5 => 5,
                    6 => 6
                };
            }
            if (room == 'C')
            {
                return i switch
                {
                    0 => 6,
                    1 => 5,
                    2 => 3,
                    3 => 1,
                    4 => 1,
                    5 => 3,
                    6 => 4
                };
            }
            if (room == 'D')
            {
                return i switch
                {
                    0 => 8,
                    1 => 7,
                    2 => 5,
                    3 => 3,
                    4 => 1,
                    5 => 1,
                    6 => 2
                };
            }

            throw new Exception();
        }

        public State Copy()
        {
            return new State
            {
                RoomA = RoomA,
                RoomB = RoomB,
                RoomC = RoomC,
                RoomD = RoomD,
                Hallway = Hallway
            };
        }

        public override string ToString()
        {
            return $"{Hallway};{RoomA};{RoomB};{RoomC};{RoomD}";
        }

        public override bool Equals(object? obj)
        {
            return Equals((State) obj);
        }

        protected bool Equals(State other)
        {
            return Hallway == other.Hallway && RoomA == other.RoomA && RoomB == other.RoomB && RoomC == other.RoomC && RoomD == other.RoomD;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hallway, RoomA, RoomB, RoomC, RoomD);
        }
    }


    public override int Nummer => 202123;
}