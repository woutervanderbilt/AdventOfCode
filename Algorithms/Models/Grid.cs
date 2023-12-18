using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Models;

public class Grid<T>
{
    private IDictionary<(int, int), T> grid = new Dictionary<(int, int), T>();

    public static Grid<T> FromInput(string input, Func<char, T> f)
    {
        var grid = new Grid<T>();
        foreach (var (line, y) in input.Split(Environment.NewLine).Reverse().Indexed())
        {
            foreach (var (c, x) in line.Indexed())
            {
                grid[x, y] = f(c);
            }
        }

        return grid;
    }

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

    public IEnumerable<GridMember<T>> AllGridMembers()
    {
        foreach (var t in grid)
        {
            yield return new GridMember<T>(t.Value, t.Key.Item1, t.Key.Item2);
        }
    }

    public int MinX => grid.Keys.Min(k => k.Item1);
    public int MaxX => grid.Keys.Max(k => k.Item1);
    public int MinY => grid.Keys.Min(k => k.Item2);
    public int MaxY => grid.Keys.Max(k => k.Item2);
    public int Size => grid.Count;

    public Func<GridMember<T>, GridMember<T>, bool> CanMove { get; set; } = (_, _) => true;
    public Func<GridMember<T>, GridMember<T>, long> Cost { get; set; } = (_, _) => 1;

    public IEnumerable<GridMember<T>> Neighbours((int, int) location, bool includeDiagonal)
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
                if (gridMember.Found && CanMove(grid[location], gridMember))
                {
                    yield return gridMember;
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
                        if (!group.Contains(c.Location))
                        {
                            newAdded.Add(c.Location);
                            group.Add(c.Location);
                            grouped.Add(c.Location);
                        }
                    }
                }

                added = newAdded;
            }
        }

        return groupCount;
    }


    /// <summary>
    /// Vind het goedkoopste pad van from-lijst naar to-lijst
    /// In CanMove kan je restricties aangeven of het mogelijk is te bewegen. Default true
    /// In Cost kan je de kosten van een overgang definieren. Default 1
    /// </summary>
    public (IList<GridMember<T>> path, long cost, bool found) ShortestPath(IEnumerable<(int, int)> from, IEnumerable<(int, int)> to, bool includeDiagonal)
    {
        var toHash = new HashSet<(int, int)>(to);
        IList<GridMember<T>> current = from.Select(v => this[v.Item1, v.Item2]).ToList();
        IDictionary<(int, int), GridMember<T>> paths = new Dictionary<(int, int), GridMember<T>>();
        IDictionary<(int, int),long> costs = current.ToDictionary(f => f.Location, _ => 0L);
        int steps = 0;
        long minCost = long.MaxValue;
        GridMember<T>? finish = null;
        while (true)
        {
            steps++;
            IList<GridMember<T>> newCurrent = new List<GridMember<T>>();
            long min = long.MaxValue;
            foreach (var member in current)
            {
                var cost = costs[member.Location];
                foreach (var neighbour in Neighbours(member.Location, includeDiagonal))
                {
                    var newCost = cost + Cost(member, neighbour);
                    var visited = costs.TryGetValue(neighbour.Location, out var previousCost);
                    if (!visited || newCost < previousCost)
                    {
                        min = Math.Min(min, newCost);
                        newCurrent.Add(neighbour);
                        paths[neighbour.Location] = member;
                        costs[neighbour.Location] = newCost;
                        if (toHash.Contains(neighbour.Location))
                        {
                            minCost = newCost;
                            finish = neighbour;
                        }
                    }
                }
            }

            if (min > minCost || !current.Any())
            {
                if (finish == null)
                {
                    return (new List<GridMember<T>>(), 0, false);
                }
                IList<GridMember<T>> path = new List<GridMember<T>>();
                path.Add(finish);
                var step = finish;
                while (paths.TryGetValue(step!.Location, out step))
                {
                    path.Add(step);
                }

                return (path, minCost, true);
            }
            current = newCurrent;
        }
    }

    public Grid<T> FillBlanks(T value, int borderX = 0, int borderY = 0)
    {
        var minX = MinX;
        var maxX = MaxX;
        var minY = MinY;
        var maxY = MaxY;
        for (int x = minX - borderX; x <= maxX + borderX; x++)
        {
            for (int y = minY - borderY; y <= maxY + borderY; y++)
            {
                if (!this[x, y].Found)
                {
                    this[x, y] = value;
                }
            }
        }

        return this;
    }

    public Grid<T> Copy()
    {
        var copy = new Grid<T>();
        copy.grid = new Dictionary<(int, int), T>(grid);
        copy.Cost = Cost;
        copy.CanMove = CanMove;
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