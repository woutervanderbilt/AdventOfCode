using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag24 : Problem
{
    private const string testinput = @"#.######
#>>.<^<#
#.<..<<#
#>v.><>#
#<^v^^>#
######.#";
    public override async Task ExecuteAsync()
    {
        IDictionary<(int, int), IList<char>> blizzards = new Dictionary<(int, int), IList<char>>();
        int y = 0;
        foreach (var line in Input.Split(Environment.NewLine))
        {
            int x = 0;
            foreach (var c in line)
            {
                if (c == '>' || c == 'v' || c == '<' || c == '^')
                {
                    blizzards[(x, y)] = new List<char> { c };
                }
                x++;
            }

            y++;
        }

        (int, int) start = (1, 0);
        (int, int) target = (120, 26);
        //(int, int) target = (6, 5);
        IList<(int, int, char)> moves = new List<(int, int, char)>
        {
            (0, 1, 'v'),
            (1, 0, '>'),
            (0, 0, '.'),
            (-1, 0, '<'),
            (0, -1, '^'),
        };
        IList<(int, int, char)> movesBack = new List<(int, int, char)>
        {
            (0, -1, '^'),
            (-1, 0, '<'),
            (0, 0, '.'),
            (0, 1, 'v'),
            (1, 0, '>'),
        };

        IList<IDictionary<(int, int), IList<char>>>
            blizzardCache = new List<IDictionary<(int, int), IList<char>>>();
        blizzardCache.Add(blizzards);
        var stage1 = Move(1, 1);
        var stage2 = Move(stage1 + 1, 2);
        var stage3 = Move(stage2 + 1, 3);

        Result = stage3.ToString();

        int Move(int startStep, int stage)
        {
            int fastest = 2000; //int.MaxValue;
            string bestPath = "";



            HashSet<(int, int, int)> visited = new HashSet<(int, int, int)>();
            Step(startStep, stage == 2 ? target : start, "");

            void Step(int step, (int, int) currentPosition, string path)
            {
                if (path == "vv.^>>v<^>.vv>>>v") //"v")
                {

                }

                if (step >= fastest)
                {
                    return;
                }

                if (visited.Contains((currentPosition.Item1, currentPosition.Item2, step)))
                {
                    return;
                }

                visited.Add((currentPosition.Item1, currentPosition.Item2, step));
                if (step >= blizzardCache.Count)
                {
                    AddBlizzardsToCache();
                }

                foreach (var move in stage == 2 ? movesBack : moves)
                {
                    var nextPosition = (currentPosition.Item1 + move.Item1, currentPosition.Item2 + move.Item2);
                    if (nextPosition == target && stage == 1 || nextPosition == target && stage == 3 || nextPosition == start && stage == 2)
                    {
                        fastest = Math.Min(fastest, step);
                        bestPath = path + move.Item3;
                        return;
                    }

                    if (blizzardCache[step].ContainsKey(nextPosition))
                    {
                        continue;
                    }

                    if ((nextPosition.Item1 <= 0 || nextPosition.Item2 <= 0 || nextPosition.Item1 > target.Item1 ||
                         nextPosition.Item2 >= target.Item2))
                    {
                        if (nextPosition != start && nextPosition != target)
                        {
                            continue;
                        }

                        if (nextPosition == target)
                        {

                        }

                        if (nextPosition == start)
                        {

                        }
                    }

                    Step(step + 1, nextPosition, path + move.Item3);
                }
            }

            void AddBlizzardsToCache()
            {
                var movedBlizzards = new Dictionary<(int, int), IList<char>>();
                var currentBlizzards = blizzardCache.Last();
                foreach (var blizzardLocation in currentBlizzards)
                {
                    foreach (var blizzard in currentBlizzards[blizzardLocation.Key])
                    {
                        var newLocation = blizzard switch
                        {
                            '>' => (blizzardLocation.Key.Item1 == target.Item1 ? 1 : blizzardLocation.Key.Item1 + 1,
                                blizzardLocation.Key.Item2),
                            '<' => (blizzardLocation.Key.Item1 == 1 ? target.Item1 : blizzardLocation.Key.Item1 - 1,
                                blizzardLocation.Key.Item2),
                            '^' => (blizzardLocation.Key.Item1,
                                blizzardLocation.Key.Item2 == 1
                                    ? target.Item2 - 1
                                    : blizzardLocation.Key.Item2 - 1),
                            'v' => (blizzardLocation.Key.Item1,
                                blizzardLocation.Key.Item2 == target.Item2 - 1 ? 1 : blizzardLocation.Key.Item2 + 1)
                        };
                        if (!movedBlizzards.ContainsKey(newLocation))
                        {
                            movedBlizzards[newLocation] = new List<char>();
                        }

                        movedBlizzards[newLocation].Add(blizzard);
                    }
                }

                blizzardCache.Add(movedBlizzards);
            }

            Console.WriteLine(bestPath);
            return fastest;
        }
    }

    public override int Nummer => 202224;
}