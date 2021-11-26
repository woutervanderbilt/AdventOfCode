using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2015
{
    internal class Dag14 : Problem
    {
        private const string input = @"Vixen can fly 19 km/s for 7 seconds, but then must rest for 124 seconds.
Rudolph can fly 3 km/s for 15 seconds, but then must rest for 28 seconds.
Donner can fly 19 km/s for 9 seconds, but then must rest for 164 seconds.
Blitzen can fly 19 km/s for 9 seconds, but then must rest for 158 seconds.
Comet can fly 13 km/s for 7 seconds, but then must rest for 82 seconds.
Cupid can fly 25 km/s for 6 seconds, but then must rest for 145 seconds.
Dasher can fly 14 km/s for 3 seconds, but then must rest for 38 seconds.
Dancer can fly 3 km/s for 16 seconds, but then must rest for 37 seconds.
Prancer can fly 25 km/s for 6 seconds, but then must rest for 143 seconds.";

        private const string test = @"Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.";
        public override Task ExecuteAsync()
        {
            int rounds = 2503;

            IList<(int, int, int)> reindeer = input.Split(Environment.NewLine).Select(l =>
            {
                var words = l.Split(' ');
                return (int.Parse(words[3]), int.Parse(words[6]), int.Parse(words[13]));
            }).ToList();

            Result = reindeer.Max(r =>
                (rounds / (r.Item2 + r.Item3) * r.Item2 + Math.Min(r.Item2, rounds % (r.Item2 + r.Item3))) * r.Item1).ToString();

            IList<int> distances = new List<int>();
            IList<int> scores = new List<int>();
            foreach (var _ in reindeer)
            {
                distances.Add(0);
                scores.Add(0);
            }

            for (int s = 0; s < rounds; s++)
            {
                for (int i = 0; i < reindeer.Count; i++)
                {
                    var r = reindeer[i];
                    if (s % (r.Item2 + r.Item3) < r.Item2)
                    {
                        distances[i] += r.Item1;
                    }
                }

                int leadingDistance = 0;
                for (int i = 0; i < reindeer.Count; i++)
                {
                    if (distances[i] >= leadingDistance)
                    {
                        leadingDistance = distances[i];
                    }
                }
                for (int i = 0; i < reindeer.Count; i++)
                {
                    scores[i] += distances[i] == leadingDistance ? 1 : 0;
                }
            }

            Result = scores.Max().ToString();

            return Task.CompletedTask;
        }

        public override int Nummer => 201514;
    }
}
