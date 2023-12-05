using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2017;

internal class Dag15 : Problem
{
    private const long Mod = 2147483647;
    private const long AStart = 116;
    private const long BStart = 299;
    private const int SampleSize = 5000000;
    private const long Cutoff = 1 << 16; 
    public override Task ExecuteAsync()
    {
        using var a = Generator(AStart, 16807, 4).GetEnumerator();
        using var b = Generator(BStart, 48271, 8).GetEnumerator();
        int score = 0;
        for (int i = 0; i < SampleSize; i++)
        {
            a.MoveNext();
            b.MoveNext();
            var aValue = a.Current;
            var bValue = b.Current;
            if (aValue % Cutoff == bValue % Cutoff)
            {
                score++;
            }
        }

        Result = $"{score}";
        return Task.CompletedTask;
    }

    IEnumerable<long> Generator(long seed, long factor, int condition)
    {
        while (true)
        {
            seed = (seed * factor % Mod);
            if (seed % condition == 0)
            {
                yield return seed;
            }
        }
    }

    public override int Nummer => 201715;
}