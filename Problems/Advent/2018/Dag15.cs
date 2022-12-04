using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2018
{
    public class Dag15 : Problem
    {
        private const string input = @"################################
####.#######..G..########.....##
##...........G#..#######.......#
#...#...G.....#######..#......##
########.......######..##.E...##
########......G..####..###....##
#...###.#.....##..G##.....#...##
##....#.G#....####..##........##
##..#....#..#######...........##
#####...G.G..#######...G......##
#########.GG..G####...###......#
#########.G....EG.....###.....##
########......#####...##########
#########....#######..##########
#########G..#########.##########
#########...#########.##########
######...G..#########.##########
#G###......G#########.##########
#.##.....G..#########..#########
#............#######...#########
#...#.........#####....#########
#####.G..................#######
####.....................#######
####.........E..........########
#####..........E....E....#######
####....#.......#...#....#######
####.......##.....E.#E...#######
#####..E...####.......##########
########....###.E..E############
#########.....##################
#############.##################
################################";

        private const string example = @"#########
#G..G..G#
#.......#
#.......#
#G..E..G#
#.......#
#.......#
#G..G..G#
#########";

        private const string testinput0 = @"#######
#.G...#
#...EG#
#.#.#G#
#..G#E#
#.....#
#######";
        private const string testinput1 = @"#######
#G..#E#
#E#E.E#
#G.##.#
#...#E#
#...E.#
#######";

        private const string testinput2 = @"#######
#E..EG#
#.#G.E#
#E.##E#
#G..#.#
#..E#.#
#######";

        private const string testinput3 = @"#######
#E.G#.#
#.#G..#
#G.#.G#
#G..#.#
#...E.#
#######
";

        private const string testinput4 = @"#######
#.E...#
#.#..G#
#.###.#
#E#G#G#
#...#G#
#######";

        private const string testinput5 = @"#########
#G......#
#.E.#...#
#..##..G#
#...##..#
#...#...#
#.G...G.#
#.....G.#
#########";

        private const string blaat = @"######
#.G..#
##..##
#...E#
#E...#
######";

        public override Task ExecuteAsync()
        {
            for (int strength = 3; strength <= 16; strength++)
            {
                var battleField = CreateBattleField(strength);
                battleField.FightTillEveryoneIsDead();
            }

            return Task.CompletedTask;
        }

        private static BattleField CreateBattleField(int elfStrength)
        {
            IDictionary<Coordinate, Location> map = new Dictionary<Coordinate, Location>();
            int rowNumber = 0;
            int creatureid = 1;
            foreach (var row in input.Split(new[] {Environment.NewLine}, StringSplitOptions.None))
            {
                int columnNumber = 0;
                foreach (var locationChar in row)
                {
                    if (locationChar != '#')
                    {
                        var coordinate = new Coordinate(rowNumber, columnNumber);
                        var location = new Location(coordinate);
                        var westNeighbourCoordinate = new Coordinate(rowNumber, columnNumber - 1);
                        var northNeighbourCoordinate = new Coordinate(rowNumber - 1, columnNumber);
                        if (map.ContainsKey(westNeighbourCoordinate))
                        {
                            var westNeighbour = map[westNeighbourCoordinate];
                            westNeighbour.Neighbours.Add(location);
                            location.Neighbours.Add(westNeighbour);
                        }

                        if (map.ContainsKey(northNeighbourCoordinate))
                        {
                            var northNeighbour = map[northNeighbourCoordinate];
                            northNeighbour.Neighbours.Add(location);
                            location.Neighbours.Add(northNeighbour);
                        }

                        if (locationChar == 'E')
                        {
                            var elf = new Elf(location, creatureid++, elfStrength);
                            location.Occupant = elf;
                        }
                        else if (locationChar == 'G')
                        {
                            var goblin = new Goblin(location, creatureid++);
                            location.Occupant = goblin;
                        }

                        map.Add(coordinate, location);
                    }

                    columnNumber++;
                }

                rowNumber++;
            }

            var battleField = new BattleField(map);
            return battleField;
        }

        public override int Nummer => 201815;

        private abstract class Creature
        {
            protected Creature(Location location, int id)
            {
                Location = location;
                Hitpoints = 200;
                IsAlive = true;
                Id = id;
            }

            public int Id { get; }
            public int Hitpoints { get; private set; }
            public bool IsAlive { get; private set; }
            public Location Location { get; set; }
            public void TakeHit(int strength)
            {
                Hitpoints -= strength;
                if (Hitpoints <= 0)
                {
                    //dood!
                    IsAlive = false;
                    Location.Occupant = null;
                }
            }

            public void AttackNearestEnemy()
            {
                var victim = GetNeighbouringEnemy();
                victim?.TakeHit(Strength);
            }

            protected abstract Creature GetNeighbouringEnemy();
            public abstract int Strength { get; }
        }

        private class Elf : Creature
        {
            public Elf(Location location, int id, int strength) : base(location, id)
            {
                Strength = strength;
            }

            protected override Creature GetNeighbouringEnemy()
            {
                var enemyLocation = Location.Neighbours.Where(l => l.Occupant is Goblin).OrderBy(l => l.Occupant.Hitpoints).ThenBy(l => l.Coordinate)
                    .FirstOrDefault();
                return enemyLocation?.Occupant;
            }

            public override int Strength { get; }
        }

        private class Goblin : Creature
        {
            public Goblin(Location location, int id) : base(location, id)
            {
            }

            protected override Creature GetNeighbouringEnemy()
            {
                var enemyLocation = Location.Neighbours.Where(l => l.Occupant is Elf).OrderBy(l => l.Occupant.Hitpoints).ThenBy(l => l.Coordinate)
                    .FirstOrDefault();
                return enemyLocation?.Occupant;
            }

            public override int Strength => 3;
        }

        private class Location
        {
            public Location(Coordinate coordinate)
            {
                Coordinate = coordinate;
                Neighbours = new List<Location>();
            }
            public Coordinate Coordinate { get; }
            public IList<Location> Neighbours { get; }
            public Creature Occupant { get; set; }
        }

        private class BattleField
        {
            public BattleField(IDictionary<Coordinate, Location> map)
            {
                Map = map;
                Locations = new ReadOnlyCollection<Location>(map.Values.ToList());
                Elves = new ReadOnlyCollection<Elf>(Locations.Where(l => (l.Occupant as Elf) != null).Select(l => (Elf)l.Occupant).ToList());
                Goblins = new ReadOnlyCollection<Goblin>(Locations.Where(l => (l.Occupant as Goblin) != null).Select(l => (Goblin)l.Occupant).ToList());
                MaxRowNumber = Locations.Max(l => l.Coordinate.Row);
                MaxColumnNumber = Locations.Max(l => l.Coordinate.Column);
            }
            private IDictionary<Coordinate, Location> Map { get; }
            private int TurnNumber { get; set; }
            private int MaxRowNumber { get; }
            private int MaxColumnNumber { get; }

            public IReadOnlyCollection<Location> Locations { get; }
            public IReadOnlyCollection<Elf> Elves { get; }
            public IReadOnlyCollection<Goblin> Goblins { get; }

            public IEnumerable<Coordinate> ElfTargets => Elves.Where(e => e.IsAlive).SelectMany(e => e.Location.Neighbours).Select(l => l.Coordinate);
            public IEnumerable<Coordinate> GoblinTargets => Goblins.Where(g => g.IsAlive).SelectMany(g => g.Location.Neighbours).Select(l => l.Coordinate);

            public int BattleResult
            {
                get
                {
                    return TurnNumber * (Elves.Where(e => e.IsAlive).Sum(e => e.Hitpoints) +
                                         Goblins.Where(g => g.IsAlive).Sum(g => g.Hitpoints));
                }
            }
            public void FightTillEveryoneIsDead()
            {
                while (Elves.All(e => e.IsAlive) && Goblins.Any(g => g.IsAlive))
                {
                    PerformTurn();
                }

                if (Elves.All(e => e.IsAlive))
                {
                    Console.WriteLine(Elves.First().Strength+" "+BattleResult);
                }
                //Console.WriteLine(this);
            }

            private void PerformTurn()
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(this);
                Thread.Sleep(40);
                //Console.ReadKey();
                TurnNumber++;
                foreach (var creature in Elves.Union<Creature>(Goblins).OrderBy(c => c.Location.Coordinate))
                {
                    if (!(Elves.Any(e => e.IsAlive) && Goblins.Any(g => g.IsAlive)))
                    {
                        TurnNumber--;
                        return;
                    }
                    if (creature.IsAlive)
                    {
                        MoveCreatureTowardsEnemy(creature);
                        creature.AttackNearestEnemy();
                    }
                }
            }

            private void MoveCreatureTowardsEnemy(Creature creature)
            {
                HashSet<Coordinate> targets = new HashSet<Coordinate>((creature is Elf ? GoblinTargets : ElfTargets));
                if (targets.Contains(creature.Location.Coordinate))
                {
                    return;
                }
                IDictionary<Coordinate, IList<Path>> paths = new Dictionary<Coordinate, IList<Path>>();
                paths.Add(creature.Location.Coordinate, new List<Path>{new Path(creature.Location)});
                IDictionary<Coordinate, IList<Path>> addedLocations = new Dictionary<Coordinate, IList<Path>>();
                addedLocations.Add(creature.Location.Coordinate, new List<Path>{new Path(creature.Location)});
                Location target = null;
                while (target == null && addedLocations.Any())
                {
                    IDictionary<Coordinate, IList<Path>> newAddedLocations = new Dictionary<Coordinate, IList<Path>>();
                    foreach (var addedLocation in addedLocations)
                    {
                        foreach (var path in addedLocation.Value)
                        {
                            foreach (var neighbour in path.Target.Neighbours.Where(l =>
                                l.Occupant == null))
                            {
                                if (!paths.ContainsKey(neighbour.Coordinate))
                                {
                                    var newPath = new Path(path, neighbour);
                                    if (!newAddedLocations.ContainsKey(neighbour.Coordinate))
                                    {
                                        newAddedLocations.Add(neighbour.Coordinate, new List<Path>{newPath});
                                        if (targets.Contains(neighbour.Coordinate) &&
                                            (target == null || target.Coordinate > neighbour.Coordinate))
                                        {
                                            target = neighbour;
                                        }
                                    }
                                    else
                                    {
                                        if(newAddedLocations[neighbour.Coordinate].All(p => p.FirstStep != newPath.FirstStep))
                                        newAddedLocations[neighbour.Coordinate].Add(newPath);
                                    }
                                }
                            }
                        }
                    }

                    foreach (var newAddedLocation in newAddedLocations)
                    {
                        paths.Add(newAddedLocation);
                    }
                    addedLocations = newAddedLocations;
                }

                if (target != null)
                {
                    Location location = null;
                    foreach (var path in paths[target.Coordinate])
                    {
                        if (location == null || path.FirstStep.Coordinate < location.Coordinate)
                        {
                            location = path.FirstStep;
                        }
                    }
                    //Console.Write($"{creature.Location.Coordinate} => {location.Coordinate} ");
                    creature.Location.Occupant = null;
                    creature.Location = location;
                    creature.Location.Occupant = creature;
                }
                else
                {
                    {
                        //Console.Write($"{creature.Location.Coordinate}!! ");
                    }
                }
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                for (int row = 0; row <= MaxRowNumber; row++)
                {
                    for (int column = 0; column <= MaxColumnNumber; column++)
                    {
                        var coordinate = new Coordinate(row, column);
                        if (Map.ContainsKey(coordinate))
                        {
                            if (Map[coordinate].Occupant != null)
                            {
                                sb.Append(Map[coordinate].Occupant is Elf ? 'E' : 'G');
                            }
                            else
                            {
                                sb.Append('.');
                            }
                        }
                        else
                        {
                            sb.Append('#');
                        }
                    }

                    sb.Append(Environment.NewLine);
                }

                return sb.ToString();
            }

            private class Path
            {
                public Path(Location start)
                {
                    Start = start;
                    Target = start;
                    FirstStep = null;
                }

                public Path(Path previous, Location nextStep)
                {
                    Start = previous.Start;
                    Target = nextStep;
                    FirstStep = previous.FirstStep ?? Target;
                }

                public Location Start { get; }
                public Location Target { get; }
                public Location FirstStep { get; set; }
            }
        }
    }
}
