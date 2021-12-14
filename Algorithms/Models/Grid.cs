using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Models
{
    public class Grid<T>
    {
        private IDictionary<(int, int), T> grid = new Dictionary<(int, int), T>();

        public GridMember<T> this[int x, int y]
        {
            get { return grid.TryGetValue((x,y), out var t) ? new GridMember<T>(t, x, y) : new GridMember<T>(x, y); }
            set { grid[(x, y)] = value; }
        }

        public IEnumerable<(T value, int x, int y)> AllMembers()
        {
            foreach (var t in grid)
            {
                yield return (t.Value, t.Key.Item1, t.Key.Item2);
            }
        }

        public int MinX => grid.Keys.Min(k => k.Item1);
        public int MaxX => grid.Keys.Max(k => k.Item1);
        public int MinY => grid.Keys.Min(k => k.Item2);
        public int MaxY => grid.Keys.Max(k => k.Item2);
        public int Size => grid.Count;


        public IEnumerable<(T value, int x, int y)> Neighbours((int, int) location, bool includeDiagonal)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0 || (i * j != 0 && !includeDiagonal))
                    {
                        continue;
                    }

                    var gridMember = this[location.Item1 + i, location.Item2 + j];
                    if (gridMember.Found)
                    {
                        yield return (gridMember, location.Item1 + i, location.Item2 + j);
                    }
                }
            }
        }

        public GridMember<T> North((int x, int y) location) => this[location.x, location.y + 1];
        public GridMember<T> NorthEast((int x, int y) location) => this[location.x + 1, location.y + 1];
        public GridMember<T> East((int x, int y) location) => this[location.x + 1, location.y];
        public GridMember<T> SouthEast((int x, int y) location) => this[location.x + 1, location.y - 1];
        public GridMember<T> South((int x, int y) location) => this[location.x, location.y - 1];
        public GridMember<T> SouthWest((int x, int y) location) => this[location.x - 1, location.y - 1];
        public GridMember<T> West((int x, int y) location) => this[location.x - 1, location.y];
        public GridMember<T> NorthWest((int x, int y) location) => this[location.x - 1, location.y + 1];

        public GridMember<T> MoveInDirection((int x, int y) location, GridDirection direction)
        {
            return direction switch
            {
                GridDirection.North => North(location),
                GridDirection.NorthEast => NorthEast(location),
                GridDirection.East => East(location),
                GridDirection.SouthEast => SouthEast(location),
                GridDirection.South => South(location),
                GridDirection.SouthWest => SouthWest(location),
                GridDirection.West => West(location),
                GridDirection.NorthWest => NorthWest(location),
                _ => throw new ArgumentException("Unknown direction", nameof(direction))
            };
        }


        public int GroupCount(bool includeDiagonal)
        {
            int groupCount = 0;
            bool newGroup = true;
            HashSet<(int, int)> grouped = new HashSet<(int, int)>();
            while (newGroup)
            {
                newGroup = false;
                (int, int) seed = (0,0);
                bool seedFound = false;
                foreach (var v in grid.Keys)
                {
                    if (!grouped.Contains(v))
                    {
                        seed = v;
                        seedFound = true;
                        break;
                    }
                }

                if (!seedFound)
                {
                    continue;
                }

                newGroup = true;
                groupCount++;
                HashSet<(int, int)> group = new HashSet<(int, int)> { seed };
                IList<(int, int)> added = new List<(int, int)> { seed };
                grouped.Add(seed);
                while (added.Any())
                {
                    IList<(int, int)> newAdded = new List<(int, int)>();
                    foreach (var i in added)
                    {
                        foreach (var c in Neighbours(i, includeDiagonal))
                        {
                            if (!group.Contains((c.x, c.y)))
                            {
                                newAdded.Add((c.x, c.y));
                                group.Add((c.x, c.y));
                                grouped.Add((c.x, c.y));
                            }
                        }
                    }

                    added = newAdded;
                }
            }

            return groupCount;
        }

        public Grid<T> Copy()
        {
            var copy = new Grid<T>();
            copy.grid = new Dictionary<(int, int), T>(grid);
            return copy;
        }

        public Grid<T> Rotate(int numberOfQuarterTurnsRight)
        {
            var turns = numberOfQuarterTurnsRight % 4;
            if (turns == 0)
            {
                return Copy();
            }

            var rotatedGrid = new Dictionary<(int, int), T>();
            if (turns == 1)
            {
                foreach (var t in grid)
                {
                    rotatedGrid[(t.Key.Item2, -t.Key.Item1)] = t.Value;
                }
            }
            else if (turns == 2)
            {
                foreach (var t in grid)
                {
                    rotatedGrid[(-t.Key.Item1, -t.Key.Item2)] = t.Value;
                }
            }
            else if (turns == 3)
            {
                foreach (var t in grid)
                {
                    rotatedGrid[(-t.Key.Item2, t.Key.Item1)] = t.Value;
                }
            }

            return new Grid<T>(){grid = rotatedGrid};
        }

        public Grid<T> FlipX()
        {
            var flippedGrid = new Dictionary<(int,int), T>();
            foreach (var t in grid)
            {
                flippedGrid[(-t.Key.Item1, t.Key.Item2)] = t.Value;
            }

            return new Grid<T> { grid = flippedGrid };
        }

    }

    public class GridMember<T>
    {
        public GridMember(T value, int x, int y)
        {
            Value = value;
            X = x;
            Y = y;
            Found = true;
        }

        public GridMember(int x, int y)
        {
            X = x;
            Y = y;
        }

        public T Value { get; }
        public bool Found { get; }

        public int X { get; }
        public int Y { get; }

        public (int, int) Location => (X, Y);

        public static implicit operator GridMember<T>(T t)
        {
            return new GridMember<T>(t, 0, 0);
        }

        public static implicit operator T(GridMember<T> g)
        {
            return g.Value;
        }
    }

    public enum GridDirection
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest,
    }
}
