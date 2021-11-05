using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2020
{
    public class Dag13 : Problem
    {
        #region input

        private const string input = @"1000001
29,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,41,x,x,x,x,x,x,x,x,x,577,x,x,x,x,x,x,x,x,x,x,x,x,13,17,x,x,x,x,19,x,x,x,23,x,x,x,x,x,x,x,601,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,37";
        #endregion

        private string testinput = @"939
67,7,59,61";
        public override Task ExecuteAsync()
        {
            var inputlines = input.Split(Environment.NewLine);
            ResidueClassBigInt c = new ResidueClassBigInt(0,1);
            int offset = -1;
            foreach (var busLine in inputlines[1].Split(','))
            {
                offset++;
                if(busLine == "x")
                {
                    continue;
                }
                var busNumber = long.Parse(busLine);
                c = c.Chinese(new ResidueClassBigInt(busNumber - offset, busNumber));
            }
            Result = c.ToString();
            return Task.CompletedTask;
        }

        public override int Nummer => 202013;
    }
}
