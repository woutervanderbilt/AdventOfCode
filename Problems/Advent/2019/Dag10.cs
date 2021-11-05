using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;
using Algorithms.Models;

namespace Problems.Advent._2019
{
    public class Dag10 : Problem
    {
        private const string input = @"....#...####.#.#...........#........
#####..#.#.#......#####...#.#...#...
##.##..#.#.#.....#.....##.#.#..#....
...#..#...#.##........#..#.......#.#
#...##...###...###..#...#.....#.....
##.......#.....#.........#.#....#.#.
..#...#.##.##.....#....##..#......#.
..###..##..#..#...#......##...#....#
##..##.....#...#.#...#......#.#.#..#
...###....#..#.#......#...#.......#.
#....#...##.......#..#.......#..#...
#...........#.....#.....#.#...#.##.#
###..#....####..#.###...#....#..#...
##....#.#..#.#......##.......#....#.
..#.#....#.#.#..#...#.##.##..#......
...#.....#......#.#.#.##.....#..###.
..#.#.###.......#..#.#....##.....#..
.#.#.#...#..#.#..##.#..........#...#
.....#.#.#...#..#..#...###.#...#.#..
#..#..#.....#.##..##...##.#.....#...
....##....#.##...#..........#.##....
...#....###.#...##........##.##..##.
#..#....#......#......###...........
##...#..#.##.##..##....#..#..##..#.#
.#....#..##.....#.#............##...
.###.........#....#.##.#..#.#..#.#..
#...#..#...#.#.#.....#....#......###
#...........##.#....#.##......#.#..#
....#...#..#...#.####...#.#..#.##...
......####.....#..#....#....#....#.#
.##.#..###..####...#.......#.#....#.
#.###....#....#..........#.....###.#
...#......#....##...##..#..#...###..
..#...###.###.........#.#..#.#..#...
.#.#.............#.#....#...........
..#...#.###...##....##.#.#.#....#.#.";

        private string testinput = @".#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.##########...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##";

        public override Task ExecuteAsync()
        {
            IDictionary<(int, int), Asteroid> asteroids = new Dictionary<(int, int), Asteroid>();
            int y = 0;
            foreach (var line in input.Split(new []{Environment.NewLine}, StringSplitOptions.None))
            {
                for(int x = 0; x<line.Length; x++)
                {
                    if (line[x] == '#')
                    {
                        var asteroid = new Asteroid(x, y);
                        asteroids[(x, y)] = asteroid;
                    }
                }

                y++;
            }

            foreach (var asteroid in asteroids.Values)
            {
                foreach (var asteroid2 in asteroids.Values)
                {
                    if(asteroid.X > asteroid2.X || (asteroid.X == asteroid2.X && asteroid.Y >= asteroid2.Y))
                    {
                        continue;
                    }

                    var dx = asteroid2.X - asteroid.X;
                    var dy = asteroid2.Y - asteroid.Y;

                    var ggd = (int)EulerMath.GCD(dx < 0 ? -dx : dx, dy < 0 ? -dy : dy);
                    bool inSight = true;
                    var stepX = dx / ggd;
                    var stepY = dy / ggd;
                    var currentX = asteroid.X + stepX;
                    var currentY = asteroid.Y + stepY;
                    while (currentX != asteroid2.X || currentY != asteroid2.Y)
                    {
                        if (asteroids.ContainsKey((currentX, currentY)))
                        {
                            inSight = false;
                            break;
                        }

                        currentX += stepX;
                        currentY += stepY;
                    }
                    if(inSight)
                    {
                        asteroid.InSight.Add(asteroid2);
                        asteroid2.InSight.Add(asteroid);
                    }
                }
            }
            var chosenStation = asteroids.Values.OrderByDescending(a => a.InSight.Count).First();
            IList<Asteroid> x0yp = new List<Asteroid>();
            IList<Asteroid> x0yn = new List<Asteroid>();
            IList<Asteroid> xpy0 = new List<Asteroid>();
            IList<Asteroid> xny0 = new List<Asteroid>();
            Dictionary<(int, int),IList<Asteroid>> xpyp = new Dictionary<(int, int), IList<Asteroid>>();
            Dictionary<(int, int), IList<Asteroid>> xpyn = new Dictionary<(int, int), IList<Asteroid>>();
            Dictionary<(int, int), IList<Asteroid>> xnyn = new Dictionary<(int, int), IList<Asteroid>>();
            Dictionary<(int, int), IList<Asteroid>> xnyp = new Dictionary<(int, int), IList<Asteroid>>();


            foreach (var asteroid in asteroids.Values)
            {
                if (asteroid == chosenStation)
                {
                    continue;
                }
                var dx = asteroid.X - chosenStation.X;
                var dy = chosenStation.Y - asteroid.Y;
                var ggd = (int)EulerMath.GCD(dx < 0 ? -dx : dx, dy < 0 ? -dy : dy);
                var sx = dx / ggd;
                var sy = dy / ggd;
                if (dx == 0)
                {
                    if (dy > 0)
                    {
                        x0yp.Add(asteroid);
                    }
                    else
                    {
                        x0yn.Add(asteroid);
                    }
                }
                else if(dx > 0)
                {
                    if (dy == 0)
                    {
                        xpy0.Add(asteroid);
                    }
                    else if (dy > 0)
                    {
                        if (!xpyp.ContainsKey((sx, sy)))
                        {
                            xpyp[(sx,sy)] = new List<Asteroid>();
                        }
                        xpyp[(sx,sy)].Add(asteroid);
                    }
                    else
                    {
                        if (!xpyn.ContainsKey((sx, -sy)))
                        {
                            xpyn[(sx, -sy)] = new List<Asteroid>();
                        }
                        xpyn[(sx, -sy)].Add(asteroid);
                    }
                }
                else
                {
                    if (dy == 0)
                    {
                        xny0.Add(asteroid);
                    }
                    else if (dy > 0)
                    {
                        if (!xnyp.ContainsKey((-sx, sy)))
                        {
                            xnyp[(-sx, sy)] = new List<Asteroid>();
                        }
                        xnyp[(-sx, sy)].Add(asteroid);
                    }
                    else
                    {
                        if (!xnyn.ContainsKey((-sx, -sy)))
                        {
                            xnyn[(-sx, -sy)] = new List<Asteroid>();
                        }
                        xnyn[(-sx, -sy)].Add(asteroid);
                    }
                }
            }
            var ray1 = new Ray(x0yp.OrderBy(a => a.DistanceTo(chosenStation)).ToList(),0);

            IList<Ray> rays2 = xpyp.OrderBy(r => (double) r.Key.Item1 / r.Key.Item2)
                .Select(r => new Ray(r.Value.OrderBy(a => a.DistanceTo(chosenStation)).ToList(), (double)r.Key.Item1 / r.Key.Item2)).ToList();

            var ray3 = new Ray(xpy0.OrderBy(a => a.DistanceTo(chosenStation)).ToList(),0);

            IList<Ray> rays4 = xpyn.OrderByDescending(r => (double)r.Key.Item1 / r.Key.Item2)
                .Select(r => new Ray(r.Value.OrderBy(a => a.DistanceTo(chosenStation)).ToList(), (double)r.Key.Item1 / r.Key.Item2)).ToList();

            var ray5 = new Ray(x0yn.OrderBy(a => a.DistanceTo(chosenStation)).ToList(),0);

            IList<Ray> rays6 = xnyn.OrderBy(r => (double)r.Key.Item1 / r.Key.Item2)
                .Select(r => new Ray(r.Value.OrderBy(a => a.DistanceTo(chosenStation)).ToList(), (double)r.Key.Item1 / r.Key.Item2)).ToList();

            var ray7 = new Ray(xny0.OrderBy(a => a.DistanceTo(chosenStation)).ToList(),0);

            IList<Ray> rays8 = xnyp.OrderByDescending(r => (double)r.Key.Item1 / r.Key.Item2)
                .Select(r => new Ray(r.Value.OrderBy(a => a.DistanceTo(chosenStation)).ToList(), (double)r.Key.Item1 / r.Key.Item2)).ToList();

            var previousRay = ray1;
            foreach (var ray in rays2)
            {
                previousRay.NextRay = ray;
                previousRay = ray;
            }
            previousRay.NextRay = ray3;
            previousRay = ray3;
            foreach (var ray in rays4)
            {
                previousRay.NextRay = ray;
                previousRay = ray;
            }
            previousRay.NextRay = ray5;
            previousRay = ray5;
            foreach (var ray in rays6)
            {
                previousRay.NextRay = ray;
                previousRay = ray;
            }
            previousRay.NextRay = ray7;
            previousRay = ray7;
            foreach (var ray in rays8)
            {
                previousRay.NextRay = ray;
                previousRay = ray;
            }
            previousRay.NextRay = ray1;

            Asteroid currentAsteroid = null;
            var currentRay = ray1;
            for (int i = 1; i <= 200; i++)
            {
                currentAsteroid = currentRay.GetNextAsteroid();
                Console.WriteLine(i+" "+100*currentAsteroid.X + currentAsteroid.Y);
                currentRay = currentRay.NextRay;
            }


            Result = chosenStation.InSight.Count.ToString() +" " + (100*currentAsteroid.X + currentAsteroid.Y);
            return Task.CompletedTask;
        }

        private class Ray
        {
            public Ray(IList<Asteroid> asteroids, double slope)
            {
                Asteroids = asteroids;
                Slope = slope;
            }
            public Ray NextRay { get; set; }
            public IList<Asteroid> Asteroids { get; }
            public double Slope { get; set; }

            public Asteroid GetNextAsteroid()
            {
                if (Asteroids.Any())
                {
                    var result = Asteroids.First();
                    Asteroids.Remove(result);
                    return result;
                }

                return NextRay.GetNextAsteroid();
            }
        }

        private class Asteroid
        {
            public Asteroid(int x, int y)
            {
                X = x;
                Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public IList<Asteroid> InSight = new List<Asteroid>();

            public long DistanceTo(Asteroid chosenStation)
            {
                var dx = X - chosenStation.X;
                var dy = Y - chosenStation.Y;
                return dx * dx + dy * dy;
            }
        }

        public override int Nummer => 201910;
    }
}
