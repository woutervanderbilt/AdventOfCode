using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2020
{
    public class Dag25 : Problem
    {
        #region input

        private const string input = @"16616892
14505727";
        #endregion
        public override Task ExecuteAsync()
        {
            var split = input.Split(Environment.NewLine);
            var cardKey = long.Parse(split[0]);
            var doorKey = long.Parse(split[1]);
            //cardKey = 5764801;
            //doorKey = 17807724;
            long mod = 20201227;
            long cardPrivate = -1;
            long doorPrivate = -1;
            long current = 1;
            long index = 1;
            long subject = 7;
            while (cardPrivate == -1 || doorPrivate == -1)
            {
                current = current * subject % mod;
                if (current == cardKey)
                {
                    cardPrivate = index;
                }

                if (current == doorKey)
                {
                    doorPrivate = index;
                }

                index++;
            }

            Result = new ResidueClass(cardKey, mod).ToThePower(doorPrivate) + " " + new ResidueClass(doorKey, mod).ToThePower(cardPrivate);

            return Task.CompletedTask;
        }

        public override int Nummer => 202025;
    }
}
