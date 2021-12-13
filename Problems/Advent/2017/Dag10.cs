using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2017
{
    internal class Dag10 : Problem
    {
        private const string input = @"165,1,255,31,87,52,24,113,0,91,148,254,158,2,73,153";
        public override Task ExecuteAsync()
        {
            IList<int> list = Enumerable.Range(0, 256).ToList();
            int currentPosition = 0;
            int skipsize = 0;
            foreach (var length in input.Split(',').Select(int.Parse))
            {
                var newList = list.ToList();
                for (int i = 0; i < length; i++)
                {
                    newList[(currentPosition + i) % 256] = list[(currentPosition + length - i - 1) % 256];
                }

                currentPosition = (currentPosition + length + skipsize) % 256;
                skipsize++;
                list = newList;
            }

            var hash = new KnotHash(input).GetHash();

            Result = $"{list[0] * list[1]}   {hash}";
            return Task.CompletedTask;
        }

        public override int Nummer => 201710;
    }
}
