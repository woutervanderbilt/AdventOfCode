using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2018;

public class Dag6 : Problem
{
    private const string input = @"124, 262
182, 343
79, 341
44, 244
212, 64
42, 240
225, 195
192, 325
192, 318
42, 235
276, 196
181, 262
199, 151
166, 214
49, 81
202, 239
130, 167
166, 87
197, 53
341, 346
235, 241
99, 278
163, 184
85, 152
349, 334
175, 308
147, 51
251, 93
163, 123
151, 219
162, 107
71, 58
249, 293
223, 119
46, 176
214, 140
80, 156
265, 153
92, 359
103, 186
242, 104
272, 202
292, 93
304, 55
115, 357
43, 182
184, 282
352, 228
267, 147
248, 271";

    public override Task ExecuteAsync()
    {
        IList<Point> points = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Select((s) =>
        {
            var ss = s.Split(',');
            return new Point(int.Parse(ss[0]), int.Parse(ss[1]));
        }).ToList();
        int minX = points.Min(p => p.X);
        int maxX = points.Max(p => p.X);
        int minY = points.Min(p => p.Y);
        int maxY = points.Max(p => p.Y);
        int count = 0;
        for (int x = minX; x <= maxX; x++)
        {
            for (int y = minY; y <= maxY; y++)
            {
                int totalDistance = 0;
                foreach (var point in points)
                {
                    totalDistance += Math.Abs(point.X - x) + Math.Abs(point.Y - y);
                    if (totalDistance >= 10000)
                    {
                        break;
                    }
                }

                if (totalDistance < 10000)
                {
                    count++;
                }
            }
        }




        IDictionary<Point, ClosestValue> currentClosestValues = new Dictionary<Point, ClosestValue>();
        IDictionary<Point, ClosestValue> allClosestValues = new Dictionary<Point, ClosestValue>();
        foreach (var point in points)
        {
            var closestValue = new ClosestValue(0, point);
            allClosestValues.Add(point, closestValue);
            currentClosestValues.Add(point, closestValue);
        }

        while (currentClosestValues.Any())
        {
            IDictionary<Point, ClosestValue> newClosestValues = new Dictionary<Point, ClosestValue>();
            foreach (var currentClosestValue in currentClosestValues)
            {
                foreach (var point in currentClosestValue.Key.Neighbours())
                {
                    if (point.X < minX || point.X > maxX || point.Y < minY || point.Y > maxY)
                    {
                        continue;
                    }

                    if (allClosestValues.ContainsKey(point))
                    {
                        continue;
                    }

                    if (newClosestValues.ContainsKey(point))
                    {
                        foreach (var origin in currentClosestValue.Value.Points)
                        {
                            if (!newClosestValues[point].Points.Contains(origin))
                            {
                                newClosestValues[point].Points.Add(origin);
                            }
                        }
                    }
                    else
                    {
                        newClosestValues[point] = new ClosestValue(currentClosestValue.Value);
                    }
                }
            }

            foreach (var newClosestValue in newClosestValues)
            {
                allClosestValues[newClosestValue.Key] = newClosestValue.Value;
            }
            currentClosestValues = newClosestValues;
        }
        IList<Point> borderPoints = new List<Point>();
        foreach (var borderPoint in allClosestValues.Keys.Where(p => p.X == minX || p.X == maxX || p.Y == minY || p.Y == maxY))
        {
            foreach (var point in allClosestValues[borderPoint].Points)
            {
                if (!borderPoints.Contains(point))
                {
                    borderPoints.Add(point);
                }
            }
        }
        IDictionary<Point, int> finiteAreas = new Dictionary<Point, int>();
        foreach (var closestValue in allClosestValues.Values)
        {
            if (closestValue.Points.Count == 1)
            {
                var point = closestValue.Points.Single();
                if (!borderPoints.Contains(point))
                {
                    if (finiteAreas.ContainsKey(point))
                    {
                        finiteAreas[point]++;
                    }
                    else
                    {
                        finiteAreas[point] = 1;
                    }
                }
            }
        }

        Result = finiteAreas.Values.Max() + " " + count;
        return Task.CompletedTask;
    }

    public override int Nummer => 201806;


    private class ClosestValue
    {
        public ClosestValue(ClosestValue closestValue)
        {
            Distance = closestValue.Distance;
            Points = new HashSet<Point>();
            foreach (var point in closestValue.Points)
            {
                Points.Add(point);
            }
        }

        public ClosestValue(int distance, Point point)
        {
            Distance = distance;
            Points = new HashSet<Point> { point };
        }
        public int Distance { get; }
        public HashSet<Point> Points { get; }
    }
    private struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public IEnumerable<Point> Neighbours()
        {
            yield return new Point(X - 1, Y);
            yield return new Point(X + 1, Y);
            yield return new Point(X, Y - 1);
            yield return new Point(X, Y + 1);
        }

    }
}