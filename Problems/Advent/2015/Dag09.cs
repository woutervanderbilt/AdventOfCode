using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Problems.Advent._2015;

internal class Dag09 : Problem
{
    private const string input = @"Tristram to AlphaCentauri = 34
Tristram to Snowdin = 100
Tristram to Tambi = 63
Tristram to Faerun = 108
Tristram to Norrath = 111
Tristram to Straylight = 89
Tristram to Arbre = 132
AlphaCentauri to Snowdin = 4
AlphaCentauri to Tambi = 79
AlphaCentauri to Faerun = 44
AlphaCentauri to Norrath = 147
AlphaCentauri to Straylight = 133
AlphaCentauri to Arbre = 74
Snowdin to Tambi = 105
Snowdin to Faerun = 95
Snowdin to Norrath = 48
Snowdin to Straylight = 88
Snowdin to Arbre = 7
Tambi to Faerun = 68
Tambi to Norrath = 134
Tambi to Straylight = 107
Tambi to Arbre = 40
Faerun to Norrath = 11
Faerun to Straylight = 66
Faerun to Arbre = 144
Norrath to Straylight = 115
Norrath to Arbre = 135
Straylight to Arbre = 127";

    public override Task ExecuteAsync()
    {
        IDictionary<(string, string), int> distances = new Dictionary<(string, string), int>();
        HashSet<string> cities = new HashSet<string>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var words = line.Split(' ');
            distances[(words[0], words[2])] = int.Parse(words[4]);
            cities.Add(words[0]);
            cities.Add(words[2]);
        }

        int min = int.MaxValue;
        int max = 0;
        foreach (var trip in cities.Permutations())
        {
            string prev = "";
            int length = 0;
            foreach (var city in trip)
            {
                if (prev != "")
                {
                    length += Distance(prev, city);
                }

                prev = city;
            }

            min = Math.Min(min, length);
            max = Math.Max(max, length);
        }

        Result = max.ToString();

        int Distance(string start, string destination)
        {
            return distances.ContainsKey((start, destination)) ? distances[(start, destination)] : distances[(destination, start)];
        }
        return Task.CompletedTask;
    }

    public override int Nummer => 201509;
}