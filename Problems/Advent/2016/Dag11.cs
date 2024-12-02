using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent;

public class Dag11 : Problem
{
    private const string input = @"The first floor contains a thulium generator, a thulium-compatible microchip, a plutonium generator, and a strontium generator.
The second floor contains a plutonium-compatible microchip and a strontium-compatible microchip.
The third floor contains a promethium generator, a promethium-compatible microchip, a ruthenium generator, and a ruthenium-compatible microchip.
The fourth floor contains nothing relevant.";

    public override Task ExecuteAsync()
    {
        var visitedStates = new HashSet<State>();
        var initialState = new State
        {
            E = 1,
            ChipsAndGenerators = new List<int> { 1, 1, 2, 1, 2, 1, 3, 3, 3, 3, 1, 1, 1, 1 }
        };
        visitedStates.Add(initialState);
        IList<State> currentStates = new List<State> { initialState };
        int steps = 0;
        bool finished = false;
        while (!finished)
        {
            steps++;
            IList<State> nextStates = new List<State>();
            foreach (var currentState in currentStates)
            {
                foreach (var neighbouringState in currentState.NeighbouringStates())
                {
                    if (!visitedStates.Contains(neighbouringState))
                    {
                        visitedStates.Add(neighbouringState);
                        nextStates.Add(neighbouringState);
                        if (neighbouringState.IsFinish())
                        {
                            finished = true;
                            break;
                        }
                    }
                    else
                    {

                    }
                }
            }

            currentStates = nextStates;
        }

        Result = steps.ToString();
        return Task.CompletedTask;
    }

    private class State
    {
        public IList<int> ChipsAndGenerators { get; set; }

        public int E { get; set; }

        public bool IsValid()
        {
            for (int i = 0; i < 14; i += 2)
            {
                if (ChipsAndGenerators[i] != ChipsAndGenerators[i + 1])
                {
                    for (int j = 1; j < 14; j += 2)
                    {
                        if (i != j - 1 && ChipsAndGenerators[i] == ChipsAndGenerators[j])
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public IEnumerable<State> NeighbouringStates()
        {
            IList<int> sameFloor = new List<int>();
            for (int i = 0; i < 14; i++)
            {
                if (ChipsAndGenerators[i] == E)
                {
                    sameFloor.Add(i);
                }
            }

            IList<(int, int)> toMove = new List<(int, int)>();
            for (int i = 0; i < sameFloor.Count; i++)
            {
                toMove.Add((sameFloor[i], -1));
                for (int j = i + 1; j < sameFloor.Count; j++)
                {
                    toMove.Add((sameFloor[i], sameFloor[j]));
                }
            }


            if (E != 1)
            {
                foreach (var move in toMove)
                {
                    var clone = Clone();
                    clone.E--;
                    clone.ChipsAndGenerators[move.Item1]--;
                    if (move.Item2 != -1)
                    {
                        clone.ChipsAndGenerators[move.Item2]--;
                    }

                    if (clone.IsValid())
                    {
                        yield return clone;
                    }
                }
            }

            if (E != 4)
            {
                foreach (var move in toMove)
                {
                    var clone = Clone();
                    clone.E++;
                    clone.ChipsAndGenerators[move.Item1]++;
                    if (move.Item2 != -1)
                    {
                        clone.ChipsAndGenerators[move.Item2]++;
                    }

                    if (clone.IsValid())
                    {
                        yield return clone;
                    }
                }
            }
        }

        public State Clone()
        {
            return new State
            {
                E = E,
                ChipsAndGenerators = ChipsAndGenerators.ToList()
            };
        }

        public override bool Equals(object? obj)
        {
            return Equals((State)obj);
        }

        protected bool Equals(State other)
        {
            return E == other.E && ChipsAndGenerators.SequenceEqual(other.ChipsAndGenerators);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(E);
            foreach (var chipsAndGenerator in ChipsAndGenerators)
            {
                hashCode.Add(chipsAndGenerator);
            }

            return hashCode.ToHashCode();
        }

        public bool IsFinish()
        {
            return ChipsAndGenerators.All(i => i == 4);
        }
    }

    public override int Nummer => 201611;
}