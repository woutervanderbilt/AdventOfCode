using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Models
{
    public class Grid<T>
    {
        private IDictionary<(int, int), T> grid = new Dictionary<(int, int), T>();

        public GridMember<T> this[int x, int y]
        {
            get { return grid.TryGetValue((x,y), out var t) ? new GridMember<T>(t) : new GridMember<T>(); }
            set { grid[(x, y)] = value; }
        }

        public IEnumerable<(T value, int x, int y)> AllMembers()
        {
            foreach (var t in grid)
            {
                yield return (t.Value, t.Key.Item1, t.Key.Item2);
            }
        }


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

        public Grid<T> Copy()
        {
            var copy = new Grid<T>();
            copy.grid = new Dictionary<(int, int), T>(grid);
            return copy;
        }
    }

    public class GridMember<T>
    {
        public GridMember(T value)
        {
            Value = value;
            Found = true;
        }

        public GridMember()
        {}

        public T Value { get; set; }
        public bool Found { get; set; }

        public static implicit operator GridMember<T>(T t)
        {
            return new GridMember<T>(t);
        }

        public static implicit operator T(GridMember<T> g)
        {
            return g.Value;
        }
    }

}
