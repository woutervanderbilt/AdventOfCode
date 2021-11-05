using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent
{
    public class Dag15 : Problem
    {
        public override Task ExecuteAsync()
        {
            IList<ResidueClass> discs = new List<ResidueClass>();
            //discs.Add(new ResidueClass(4, 5));
            //discs.Add(new ResidueClass(1, 2));
            discs.Add(new ResidueClass(0, 7));
            discs.Add(new ResidueClass(0, 13));
            discs.Add(new ResidueClass(2, 3));
            discs.Add(new ResidueClass(2, 5));
            discs.Add(new ResidueClass(0, 17));
            discs.Add(new ResidueClass(7, 19));
            discs.Add(new ResidueClass(0, 11));
            var result = new ResidueClass(0, 1);
            int time = 0;
            foreach (var disc in discs)
            {
                time++;
                result = result.Chinese(-disc - time);
            }

            Result = result.ToString();

            return Task.CompletedTask;
        }

        public override int Nummer => 201615;
    }
}
