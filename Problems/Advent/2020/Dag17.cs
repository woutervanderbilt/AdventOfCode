using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2020
{
    public class Dag17 : Problem
    {
        #region input

        private const string input = @"##..#.#.
###.#.##
..###..#
.#....##
.#..####
#####...
#######.
#.##.#.#";

        private const string testinput = @".#.
..#
###";

        private const int dimensions = 5;
        #endregion
        public override Task ExecuteAsync()
        {
            HashSet<Cube> activeCubes = new HashSet<Cube>();
            int x = 0;
            foreach (var line in input.Split(Environment.NewLine))
            {
                for (int y = 0; y < line.Length; y++)
                {
                    if (line[y] == '#')
                    {
                        activeCubes.Add(new Cube(x, y));
                    }
                }

                x++;
            }

            for (int i = 1; i <= 6; i++)
            {
                Step();
                Console.WriteLine($"{i} : {activeCubes.Count}");
            }

            Result = activeCubes.Count.ToString();

            void Step()
            {
                HashSet<Cube> newActiveCubes = new HashSet<Cube>();
                foreach (var activeCube in activeCubes)
                {
                    var neighbours = Neighbours(activeCube).ToList();
                    var count = neighbours.Count(c => activeCubes.Contains(c));
                    if (count == 2 || count == 3)
                    {
                        newActiveCubes.Add(activeCube);
                    }

                    foreach (var neighbour in neighbours)
                    {
                        if (!newActiveCubes.Contains(neighbour))
                        {
                            var count2 = Neighbours(neighbour).Count(c => activeCubes.Contains(c));
                            if (count2 == 3)
                            {
                                newActiveCubes.Add(neighbour);
                            }
                        }
                    }
                }

                activeCubes = newActiveCubes;
            }

            IEnumerable<Cube> Neighbours(Cube cube)
            {
                IList<Cube> list = new List<Cube>{cube.Copy()};
                for (int i = 0; i < dimensions; i++)
                {
                    IList<Cube> newList = new List<Cube>();
                    foreach (var cube1 in list)
                    {
                        newList.Add(cube1);
                        var left = cube1.Copy();
                        left.Coordinates[i]--;
                        newList.Add(left);
                        var right = cube1.Copy();
                        right.Coordinates[i]++;
                        newList.Add(right);
                    }

                    list = newList;
                }

                return list.Where(c => !c.Equals(cube));
            }


            return Task.CompletedTask;
        }

        private struct Cube
        {
            public Cube(int x, int y)
            {
                Coordinates = new int[dimensions];
                Coordinates[0] = x;
                Coordinates[1] = y;
            }

            public Cube Copy()
            {
                int[] copy = new int[dimensions];
                Coordinates.CopyTo(copy,0);
                return new Cube{Coordinates = copy};
            }

            public int[] Coordinates { get; set; }

            public override bool Equals(object? obj)
            {
                return Equals((Cube) obj);
            }

            public bool Equals(Cube other)
            {
                return Coordinates.SequenceEqual(other.Coordinates);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hash = 31;
                    foreach (var coordinate in Coordinates)
                    {
                        hash = 17 * hash + coordinate;
                    }

                    return hash;
                }
            }

            public override string ToString()
            {
                return string.Join(',', Coordinates);
            }
        }


        public override int Nummer => 202017;
    }
}
