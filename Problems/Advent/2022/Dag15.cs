using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2022
{
    internal class Dag15 : Problem
    {
        private const string input = @"";

        private const string testinput = @"Sensor at x=2, y=18: closest beacon is at x=-2, y=15
Sensor at x=9, y=16: closest beacon is at x=10, y=16
Sensor at x=13, y=2: closest beacon is at x=15, y=3
Sensor at x=12, y=14: closest beacon is at x=10, y=16
Sensor at x=10, y=20: closest beacon is at x=10, y=16
Sensor at x=14, y=17: closest beacon is at x=10, y=16
Sensor at x=8, y=7: closest beacon is at x=2, y=10
Sensor at x=2, y=0: closest beacon is at x=2, y=10
Sensor at x=0, y=11: closest beacon is at x=2, y=10
Sensor at x=20, y=14: closest beacon is at x=25, y=17
Sensor at x=17, y=20: closest beacon is at x=21, y=22
Sensor at x=16, y=7: closest beacon is at x=15, y=3
Sensor at x=14, y=3: closest beacon is at x=15, y=3
Sensor at x=20, y=1: closest beacon is at x=15, y=3";
        public override async Task ExecuteAsync()
        {
            var input = await GetInputAsync();
            IDictionary<(int, int), (int, int)> sensors = new Dictionary<(int, int), (int, int)>();
            foreach (var line in input.Split(Environment.NewLine))
            {
                var words = line.Split();
                var x = words[2].Replace(",", "").Substring(2);
                var y = words[3].Replace(":", "").Substring(2);
                var bx = words[8].Replace(",", "").Substring(2);
                var by = words[9].Replace(",", "").Substring(2);
                sensors[(int.Parse(x), int.Parse(y))] = (int.Parse(bx), int.Parse(by));
            }
            

            int count = 0;
            int fixedY = 2000000;
            //fixedY = 10;
            //for (int x = - maxX * 3; x <= maxX * 3; x++)
            //{
            //    if (sensors.Any(s => Dist(s.Key, s.Value) >= Dist(s.Key, (x, fixedY))))
            //    {
            //        if (sensors.Any(s => s.Value == (x, fixedY)))
            //        {
            //            Console.WriteLine(x);
            //        }
            //        //Console.WriteLine(x);
            //        count++;
            //    }
            //}
            IList<(int, int)> beacons = new List<(int, int)>();
            int size = 4000000;
            for (int x = 0; x <= size; x++)
            {
                IList<(int, int)> ranges = new List<(int, int)>();
                foreach (var sensor in sensors)
                {
                    var d = Dist(sensor.Key, sensor.Value);
                    var dx = Math.Abs(sensor.Key.Item1 - x);
                    if (dx <= d)
                    {
                        var minY = Math.Max(sensor.Key.Item2 + dx - d, 0);
                        var maxY = Math.Min(sensor.Key.Item2 - dx + d, size);
                        ranges.Add((minY, maxY));
                    }
                }

                int current = 0;
                foreach (var range in ranges.OrderBy(r => r.Item1))
                {
                    if (range.Item1 > current)
                    {
                        for (int c = current; c < range.Item1; c++)
                        {
                            beacons.Add((x, c));
                        }
                    }

                    current = Math.Max(current, range.Item2 + 1);
                }
            }

            Result = (beacons[0].Item1 * 4000000L + beacons[0].Item2).ToString();
        }

        static int Dist((int, int) s, (int, int) b)
        {
            return Math.Abs(s.Item1 - b.Item1) + Math.Abs(s.Item2 - b.Item2);
        }

        public override int Nummer => 202215;
    }
}
