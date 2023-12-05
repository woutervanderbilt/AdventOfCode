using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag05 : Problem
{
    private const string testinput = @"seeds: 79 14 55 13

seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4";
    public override async Task ExecuteAsync()
    {
        string input = await GetInputAsync();
        var seeds = new List<long>();
        var seedRanges = new List<(long, long)>();
        IDictionary<string, string> mapNames = new Dictionary<string, string>();
        IDictionary<(string, string), List<(long destinationStart, long sourceStart, long length)>> maps =
            new Dictionary<(string, string), List<(long destinationStart, long sourceStart, long length)>>();
        (string, string) mapName = default;
        List<(long destinationStart, long sourceStart, long length)> list = default;
        foreach (var line in input.Split(Environment.NewLine))
        {
            if (line.StartsWith("seeds:"))
            {
                seeds.AddRange(line.Split(' ').Skip(1).Select(long.Parse));
                long? currentSeed = null;
                foreach (var seed in seeds)
                {
                    if (currentSeed == null)
                    {
                        currentSeed = seed;
                    }
                    else
                    {
                        seedRanges.Add((currentSeed.Value, currentSeed.Value + seed - 1));
                        currentSeed = null;
                    }
                }
                continue;
            }

            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (line.Contains('-'))
            {
                var split = line.Split('-');
                var dest = split[2].Split(' ')[0];
                mapName = (split[0], dest);
                list = new List<(long destinationStart, long sourceStart, long length)>();
                maps[mapName] = list;
                mapNames[split[0]] = dest;
                continue;
            }

            var values = line.Split(' ').Select(long.Parse).ToList();
            list.Add((values[0], values[1], values[2]));
        }

        string currentName = "seed";
        while (mapNames.ContainsKey(currentName))
        {
            var target = mapNames[currentName];
            var currentMaps = maps[(currentName, target)];
            var newSeeds = new List<long>();
            var newSeedRanges = new List<(long, long)>();
            foreach (var seed in seeds)
            {
                bool found = false;
                foreach (var map in currentMaps)
                {
                    if (seed >= map.sourceStart && seed < map.sourceStart + map.length)
                    {
                        newSeeds.Add(map.destinationStart + seed - map.sourceStart);
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    newSeeds.Add(seed);
                }
            }

            foreach (var seedRange in seedRanges)
            {
                IList<(long, long)> addedRanges = new List<(long, long)>();
                foreach (var map in currentMaps)
                {
                    if (map.sourceStart <= seedRange.Item2 && map.sourceStart + map.length - 1 >= seedRange.Item1)
                    {
                        var rangeToMove = (Math.Max(seedRange.Item1, map.sourceStart),
                            Math.Min(seedRange.Item2, map.sourceStart + map.length - 1));
                        addedRanges.Add(rangeToMove);
                        newSeedRanges.Add((rangeToMove.Item1 + map.destinationStart - map.sourceStart,
                            rangeToMove.Item2 + map.destinationStart - map.sourceStart));
                    }
                }
                long start = seedRange.Item1;
                foreach (var range in addedRanges.OrderBy(r => r.Item1))
                {
                    if (range.Item1 > start)
                    {
                        newSeedRanges.Add((start, range.Item1 - 1));
                    }

                    start = range.Item2 + 1;
                    if (start > seedRange.Item2)
                    {
                        break;
                    }
                }

                if (start <= seedRange.Item2)
                {
                    newSeedRanges.Add((start, seedRange.Item2));
                }
            }

            currentName = target;
            seeds = newSeeds;
            seedRanges = newSeedRanges;
        }

        Result = (seeds.Min(), seedRanges.Select(r => r.Item1).Min()).ToString();
    }

    public override int Nummer => 202305;
}