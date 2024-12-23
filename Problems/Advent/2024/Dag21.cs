using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag21 : Problem
{
    public override async Task ExecuteAsync()
    {
        const string ups = "^^^^";
        const string lefts = "<<<<";
        const string downs = "vvvv";
        const string rights = ">>>>";
        const string a = "AAAAAA";

        var codes = Input.Split(Environment.NewLine);
        var binomial = new Binomial();
        IList<(int x, int y)> numberPad =
        [
            (1, 0),
            (0, 1),
            (1, 1),
            (2, 1),
            (0, 2),
            (1, 2),
            (2, 2),
            (0, 3),
            (1, 3),
            (2, 3),
            (2, 0)
        ];

        IList<(int x, int y)> directionsPad = // 0 = left, 1 = down, 2 = right, 3 = up, 4 = A
        [
            (0, 0),
            (1, 0),
            (2, 0),
            (1, 1),
            (2, 1)
        ];

        long result1 = 0;

        IDictionary<string, Counter<string>> transitions = new Dictionary<string, Counter<string>>();
        foreach (var code in codes)
        {
            var instructions = MakeCodeOnNumpad(code).First();
            var split = instructions.Split("A");
            foreach (var chunk in split.Distinct())
            {
                transitions[chunk] = new Counter<string>();
                var newInstructions = MakeCodeOnDirectionsPad(chunk+"A").First();
                var newChunks = newInstructions.Substring(0, newInstructions.Length - 1).Split("A");
                foreach (var newChunk in newChunks)
                {
                    transitions[chunk][newChunk]++;
                }
            }
            for (int i = 1; i <= 4; i++)
            {
                instructions = MakeCodeOnDirectionsPad(instructions).First();
                split = instructions.Split("A");
                foreach (var chunk in split.Distinct().Where(c => !transitions.ContainsKey(c)))
                {
                    transitions[chunk] = new Counter<string>();
                    var newInstructions = MakeCodeOnDirectionsPad(chunk + "A").First();
                    var newChunks = newInstructions.Substring(0, newInstructions.Length - 1).Split("A");
                    foreach (var newChunk in newChunks)
                    {
                        transitions[chunk][newChunk]++;
                    }
                }
            }
            instructions = MakeCodeOnNumpad(code).First();
            split = instructions.Substring(0, instructions.Length - 1).Split("A");
            CounterLong<string> counter = new();
            foreach (var chunk in split)
            {
                counter[chunk]++;
            }

            for (int i = 1; i <= 25; i++)
            {
                var newCounter = new CounterLong<string>();
                foreach (var key in counter.Keys)
                {
                    var value = counter[key];
                    foreach (var newKey in transitions[key].Keys)
                    {
                        newCounter[newKey] += value * (transitions[key][newKey]);
                    }
                }
                counter = newCounter;
            }


            var test = MakeCodeOnDirectionsPad(instructions).First();

            result1 += long.Parse(code.Substring(0,3)) * counter.Keys.Sum(k => counter[k] * (k.Length + 1));
        }

        Result = (result1).ToString();

        IEnumerable<string> MakeCodeOnNumpad(string code)
        {
            IList<string> strings = [""];
            int current = 10;
            for (int index = 0; index < 4; index++)
            {
                IList<string> newStrings = [];
                int next;
                if (!int.TryParse(code.Substring(index, 1), out next))
                {
                    next = 10;
                }

                foreach (var m in Move(current, next))
                {
                    foreach (var s in strings)
                    {
                        newStrings.Add(s + m);
                    }
                }
                current = next;
                strings = newStrings;

                IEnumerable<string> Move(int from, int to)
                {
                    var fromCoordinates = numberPad[from];
                    var toCoordinates = numberPad[to];
                    if (fromCoordinates.x > toCoordinates.x)
                    {
                        var leftString = lefts.Substring(0, fromCoordinates.x - toCoordinates.x);
                        if (fromCoordinates.y > toCoordinates.y)
                        {
                            var downString = downs.Substring(0, fromCoordinates.y - toCoordinates.y);
                            yield return leftString + downString + "A";
                        }
                        else if (fromCoordinates.y < toCoordinates.y)
                        {
                            var upString = ups.Substring(0, toCoordinates.y - fromCoordinates.y);
                            if (fromCoordinates.y != 0 || toCoordinates.x != 0)
                            {
                                yield return leftString + upString + "A";
                            }
                            else
                            {
                                yield return upString + leftString + "A";
                            }
                        }
                        else
                        {
                            yield return leftString + "A";
                        }
                    }
                    else if (fromCoordinates.x < toCoordinates.x)
                    {
                        var rightString = rights.Substring(0, toCoordinates.x - fromCoordinates.x);
                        if (fromCoordinates.y > toCoordinates.y)
                        {
                            var downString = downs.Substring(0, fromCoordinates.y - toCoordinates.y);
                            if (fromCoordinates.x != 0 || toCoordinates.y != 0)
                            {
                                yield return downString + rightString + "A";
                            }
                            else
                            {
                                yield return rightString + downString + "A";
                            }
                        }
                        else if (fromCoordinates.y < toCoordinates.y)
                        {
                            var upString = ups.Substring(0, toCoordinates.y - fromCoordinates.y);
                            yield return upString + rightString + "A";
                        }
                        else
                        {
                            yield return rightString + "A";
                        }
                    }
                    else
                    {
                        if (fromCoordinates.y > toCoordinates.y)
                        {
                            var downString = downs.Substring(0, fromCoordinates.y - toCoordinates.y);
                            yield return downString + "A";
                        }
                        else if (fromCoordinates.y < toCoordinates.y)
                        {
                            var upString = ups.Substring(0, toCoordinates.y - fromCoordinates.y);
                            yield return  upString + "A";
                        }
                        else
                        {
                            yield return "A";
                        }
                    }
                }
            }

            return strings;
        }

        IEnumerable<string> MakeCodeOnDirectionsPad(string code)
        {
            IList<string> strings = [""];
            int current = 4;
            for (int index = 0; index < code.Length; index++)
            {
                IList<string> newStrings = [];
                int next = "<v>^A".IndexOf(code[index]);

                foreach (var m in Move(current, next))
                {
                    foreach (var s in strings)
                    {
                        newStrings.Add(s + m);
                    }
                }
                current = next;
                strings = newStrings;

                IEnumerable<string> Move(int from, int to)
                {
                    var fromCoordinates = directionsPad[from];
                    var toCoordinates = directionsPad[to];
                    if (fromCoordinates.x > toCoordinates.x)
                    {
                        var leftString = lefts.Substring(0, fromCoordinates.x - toCoordinates.x);
                        if (fromCoordinates.y > toCoordinates.y)
                        {
                            var downString = downs.Substring(0, fromCoordinates.y - toCoordinates.y);
                            if (fromCoordinates.y != 1 || toCoordinates.x != 0)
                            {
                                yield return leftString + downString + "A";
                            }
                            else
                            {
                                yield return downString + leftString + "A";
                            }
                        }
                        else if (fromCoordinates.y < toCoordinates.y)
                        {
                            var upString = ups.Substring(0, toCoordinates.y - fromCoordinates.y);
                            yield return leftString + upString + "A";
                        }
                        else
                        {
                            yield return leftString + "A";
                        }
                    }
                    else if (fromCoordinates.x < toCoordinates.x)
                    {
                        var rightString = rights.Substring(0, toCoordinates.x - fromCoordinates.x);
                        if (fromCoordinates.y > toCoordinates.y)
                        {
                            var downString = downs.Substring(0, fromCoordinates.y - toCoordinates.y);
                            yield return downString + rightString + "A";
                        }
                        else if (fromCoordinates.y < toCoordinates.y)
                        {
                            var upString = ups.Substring(0, toCoordinates.y - fromCoordinates.y);
                            if (fromCoordinates.x != 0 || toCoordinates.y != 1)
                            {
                                yield return upString + rightString + "A";
                            }
                            else
                            {
                                yield return rightString + upString + "A";
                            }
                        }
                        else
                        {
                            yield return rightString + "A";
                        }
                    }
                    else
                    {
                        if (fromCoordinates.y > toCoordinates.y)
                        {
                            var downString = downs.Substring(0, fromCoordinates.y - toCoordinates.y);
                            yield return downString + "A";
                        }
                        else if (fromCoordinates.y < toCoordinates.y)
                        {
                            var upString = ups.Substring(0, toCoordinates.y - fromCoordinates.y);
                            yield return upString + "A";
                        }
                        else
                        {
                            yield return "A";
                        }
                    }
                }
            }

            return strings;
        }
    }

    protected override bool UseTestInput => false;

    protected override string TestInput => @"029A
980A
179A
456A
379A";
    public override int Nummer => 202421;
}