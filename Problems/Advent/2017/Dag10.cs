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

            IList<int> lengths = input.Select(c => (int)c).ToList();
            lengths.Add(17);
            lengths.Add(31);
            lengths.Add(73);
            lengths.Add(47);
            lengths.Add(23);
            list = Enumerable.Range(0, 256).ToList();
            currentPosition = 0;
            skipsize = 0;
            for (int cycle = 0; cycle < 64; cycle++)
            {
                foreach (var length in lengths)
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
            }

            IList<int> hash = new List<int>();
            for (int i = 0; i < 16; i++)
            {
                int xor = 0;
                for (int j = 0; j < 16; j++)
                {
                    xor ^= list[16 * i + j];
                }

                hash.Add(xor);
            }

            var sb = new StringBuilder();
            foreach (var h in hash)
            {
                sb.Append(h.ToString("x2"));
            }

            Result = $"{list[0] * list[1]}   {sb}";
            return Task.CompletedTask;
        }

        public override int Nummer => 201710;
    }
}
