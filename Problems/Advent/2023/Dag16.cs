using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag16 : Problem
{
    private const string testinput = @".|...\....
|.-.\.....
.....|-...
........|.
..........
.........\
..../.\\..
.-.-/..|..
.|....-|.\
..//.|....";
    public override async Task ExecuteAsync()
    {

        var grid = Grid<char>.FromInput(Input, c => c);
        int maxX = grid.MaxX;
        int maxY = grid.MaxY;
        long max = 0;
        for (int y = 0; y <= maxY; y++)
        {
            var initialBeam = new Beam(GridDirection.East, 0, y);
            max = Math.Max(Count(initialBeam), max);
            initialBeam = new Beam(GridDirection.West, maxX, y);
            max = Math.Max(Count(initialBeam), max);
        }
        for (int x = 0; x <= maxX; x++)
        {
            var initialBeam = new Beam(GridDirection.North, x, 0);
            max = Math.Max(Count(initialBeam), max);
            initialBeam = new Beam(GridDirection.South, x, maxY);
            max = Math.Max(Count(initialBeam), max);
        }


        Result = max.ToString();

        int Count(Beam initialBeam)
        {
            var beams = new HashSet<Beam>();
            IList<Beam> currentBeams = new List<Beam>();
            currentBeams.Add(initialBeam);
            beams.Add(initialBeam);
            while (currentBeams.Any())
            {
                var newCurrentBeams = new List<Beam>();
                foreach (var beam in currentBeams)
                {
                    foreach (var newBeam in NewBeams())
                    {
                        if (beams.Add(newBeam))
                        {
                            newCurrentBeams.Add(newBeam);
                        }
                    }

                    IEnumerable<Beam> NewBeams()
                    {
                        var v = grid[beam.X, beam.Y].Value;
                        if (v == '.')
                        {
                            switch (beam.Direction)
                            {
                                case GridDirection.North:
                                    if (beam.Y < maxY)
                                    {
                                        yield return new Beam(GridDirection.North, beam.X, beam.Y + 1);
                                    }

                                    break;
                                case GridDirection.East:
                                    if (beam.X < maxX)
                                    {
                                        yield return new Beam(GridDirection.East, beam.X + 1, beam.Y);
                                    }

                                    break;
                                case GridDirection.South:
                                    if (beam.Y > 0)
                                    {
                                        yield return new Beam(GridDirection.South, beam.X, beam.Y - 1);
                                    }

                                    break;
                                case GridDirection.West:
                                    if (beam.X > 0)
                                    {
                                        yield return new Beam(GridDirection.West, beam.X - 1, beam.Y);
                                    }

                                    break;
                            }
                        }
                        else if (v == '/')
                        {
                            switch (beam.Direction)
                            {
                                case GridDirection.North:
                                    if (beam.X < maxX)
                                    {
                                        yield return new Beam(GridDirection.East, beam.X + 1, beam.Y);
                                    }

                                    break;
                                case GridDirection.East:
                                    if (beam.Y < maxY)
                                    {
                                        yield return new Beam(GridDirection.North, beam.X, beam.Y + 1);
                                    }

                                    break;
                                case GridDirection.South:
                                    if (beam.X > 0)
                                    {
                                        yield return new Beam(GridDirection.West, beam.X - 1, beam.Y);
                                    }

                                    break;
                                case GridDirection.West:
                                    if (beam.Y > 0)
                                    {
                                        yield return new Beam(GridDirection.South, beam.X, beam.Y - 1);
                                    }

                                    break;
                            }
                        }
                        else if (v == '\\')
                        {
                            switch (beam.Direction)
                            {
                                case GridDirection.North:
                                    if (beam.X > 0)
                                    {
                                        yield return new Beam(GridDirection.West, beam.X - 1, beam.Y);
                                    }

                                    break;
                                case GridDirection.East:
                                    if (beam.Y > 0)
                                    {
                                        yield return new Beam(GridDirection.South, beam.X, beam.Y - 1);
                                    }

                                    break;
                                case GridDirection.South:
                                    if (beam.X < maxX)
                                    {
                                        yield return new Beam(GridDirection.East, beam.X + 1, beam.Y);
                                    }

                                    break;
                                case GridDirection.West:
                                    if (beam.Y < maxY)
                                    {
                                        yield return new Beam(GridDirection.North, beam.X, beam.Y + 1);
                                    }

                                    break;
                            }
                        }
                        else if (v == '-')
                        {
                            switch (beam.Direction)
                            {
                                case GridDirection.North:
                                case GridDirection.South:
                                    if (beam.X < maxX)
                                    {
                                        yield return new Beam(GridDirection.East, beam.X + 1, beam.Y);
                                    }

                                    if (beam.X > 0)
                                    {
                                        yield return new Beam(GridDirection.West, beam.X - 1, beam.Y);
                                    }

                                    break;
                                case GridDirection.East:
                                    if (beam.X < maxX)
                                    {
                                        yield return new Beam(GridDirection.East, beam.X + 1, beam.Y);
                                    }

                                    break;

                                case GridDirection.West:
                                    if (beam.X > 0)
                                    {
                                        yield return new Beam(GridDirection.West, beam.X - 1, beam.Y);
                                    }

                                    break;
                            }
                        }
                        else if (v == '|')
                        {
                            switch (beam.Direction)
                            {
                                case GridDirection.North:
                                    if (beam.Y < maxY)
                                    {
                                        yield return new Beam(GridDirection.North, beam.X, beam.Y + 1);
                                    }

                                    break;
                                case GridDirection.East:
                                case GridDirection.West:
                                    if (beam.Y < maxY)
                                    {
                                        yield return new Beam(GridDirection.North, beam.X, beam.Y + 1);
                                    }

                                    if (beam.Y > 0)
                                    {
                                        yield return new Beam(GridDirection.South, beam.X, beam.Y - 1);
                                    }

                                    break;
                                case GridDirection.South:
                                    if (beam.Y > 0)
                                    {
                                        yield return new Beam(GridDirection.South, beam.X, beam.Y - 1);
                                    }

                                    break;
                            }
                        }

                        yield break;
                    }
                }

                currentBeams = newCurrentBeams;
            }

            return beams.GroupBy(b => (b.X, b.Y)).Count();
        }
    }

    record Beam(GridDirection Direction, int X, int Y);

    public override int Nummer => 202316;
}