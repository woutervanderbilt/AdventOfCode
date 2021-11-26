using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2015
{
    internal class Dag17 : Problem
    {
        public override Task ExecuteAsync()
        {
            IList<int> buckets = new List<int>
            {
                50,
                44,
                11,
                49,
                42,
                46,
                18,
                32,
                26,
                40,
                21,
                7,
                18,
                43,
                10,
                47,
                36,
                24,
                22,
                40
            };
            long[,] counts = new long[buckets.Count + 1, 151];
            counts[0, 0] = 1;
            for (int i = 0; i < buckets.Count; i++)
            {
                var bucket = buckets[i];
                for (int j = i; j >= 0; j--)
                {
                    for (int k = 0; k + bucket <= 150; k++)
                    {
                        counts[j + 1, k + bucket] += counts[j, k];
                    }
                }
            }

            for (int i = 0; i < buckets.Count; i++)
            {
                if (counts[i, 150] != 0)
                {
                    Result = counts[i, 150].ToString();
                    break;
                }
            }
            return Task.CompletedTask;
        }

        public override int Nummer => 201517;
    }
}
