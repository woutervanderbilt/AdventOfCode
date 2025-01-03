﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2019;

public class Dag15 : Problem
{
    private const string input = @"3,1033,1008,1033,1,1032,1005,1032,31,1008,1033,2,1032,1005,1032,58,1008,1033,3,1032,1005,1032,81,1008,1033,4,1032,1005,1032,104,99,101,0,1034,1039,1001,1036,0,1041,1001,1035,-1,1040,1008,1038,0,1043,102,-1,1043,1032,1,1037,1032,1042,1106,0,124,101,0,1034,1039,101,0,1036,1041,1001,1035,1,1040,1008,1038,0,1043,1,1037,1038,1042,1105,1,124,1001,1034,-1,1039,1008,1036,0,1041,1002,1035,1,1040,1001,1038,0,1043,1002,1037,1,1042,1106,0,124,1001,1034,1,1039,1008,1036,0,1041,102,1,1035,1040,1001,1038,0,1043,102,1,1037,1042,1006,1039,217,1006,1040,217,1008,1039,40,1032,1005,1032,217,1008,1040,40,1032,1005,1032,217,1008,1039,39,1032,1006,1032,165,1008,1040,39,1032,1006,1032,165,1101,2,0,1044,1106,0,224,2,1041,1043,1032,1006,1032,179,1102,1,1,1044,1106,0,224,1,1041,1043,1032,1006,1032,217,1,1042,1043,1032,1001,1032,-1,1032,1002,1032,39,1032,1,1032,1039,1032,101,-1,1032,1032,101,252,1032,211,1007,0,59,1044,1106,0,224,1101,0,0,1044,1106,0,224,1006,1044,247,101,0,1039,1034,1001,1040,0,1035,1002,1041,1,1036,102,1,1043,1038,101,0,1042,1037,4,1044,1105,1,0,33,20,19,43,28,91,62,55,96,28,52,9,24,99,11,45,80,58,96,2,8,76,1,37,5,95,18,6,97,67,47,4,19,29,74,57,45,65,17,43,93,33,71,93,26,2,86,11,31,74,85,36,94,20,89,68,45,99,43,21,3,92,69,95,8,30,84,45,10,64,95,49,60,60,45,30,94,36,17,97,90,39,4,97,76,28,80,92,5,66,20,69,95,43,95,35,30,67,67,87,36,44,11,83,62,73,42,80,20,99,79,46,1,75,85,24,5,84,47,78,91,91,38,74,16,31,96,37,60,69,12,96,2,5,83,24,67,42,7,67,94,77,34,6,75,2,61,37,15,11,65,13,63,39,42,93,22,12,89,58,98,28,69,13,98,68,34,13,93,56,85,28,92,45,84,79,70,12,27,85,1,86,94,57,64,30,75,78,49,91,19,94,77,34,40,15,64,26,34,31,70,65,34,65,7,73,61,8,23,82,55,78,36,93,10,29,64,42,99,34,91,17,33,98,45,44,74,98,60,76,6,44,73,11,13,11,73,92,55,90,3,54,23,75,28,36,82,89,84,6,39,31,39,98,34,61,21,93,48,71,80,7,46,76,71,17,7,91,6,22,76,70,27,98,35,29,69,93,42,81,62,46,87,47,51,66,2,60,3,76,68,68,74,70,3,89,18,2,57,74,79,97,16,5,73,19,90,49,6,41,88,83,34,63,52,84,14,19,76,78,88,19,92,90,34,16,69,45,85,30,71,16,77,30,43,65,85,66,11,2,72,3,83,84,14,86,90,74,79,35,33,29,78,9,92,35,64,32,30,66,9,65,30,85,81,44,95,41,22,16,28,75,63,72,23,5,73,24,89,80,25,40,88,62,3,68,6,80,6,39,17,76,24,78,6,90,79,38,44,78,85,29,48,25,75,27,76,92,19,93,21,61,56,13,64,92,52,77,12,33,77,41,75,86,29,34,65,38,66,17,15,95,50,87,52,64,72,73,6,26,80,71,8,86,1,23,67,10,72,89,9,95,60,20,46,64,99,34,46,65,14,54,93,84,4,13,86,12,26,68,56,33,83,12,93,42,74,9,99,62,22,20,83,75,13,71,96,53,96,41,8,15,76,97,55,8,78,85,57,79,30,87,17,46,62,85,14,70,63,82,28,46,96,35,89,6,9,27,44,86,93,28,9,97,73,14,7,84,64,15,62,14,17,88,92,82,11,47,63,73,13,94,98,88,15,37,38,11,2,74,20,73,94,26,96,64,56,80,53,48,85,85,35,15,90,63,9,42,99,81,97,26,94,32,24,96,61,38,18,57,22,76,7,5,43,55,97,74,35,99,86,24,25,8,60,75,18,61,14,97,52,64,97,45,29,69,91,43,40,99,58,72,73,70,45,5,97,37,89,77,32,92,94,6,33,72,64,35,75,14,32,99,64,54,78,1,92,35,30,71,11,48,82,61,49,12,46,75,54,52,33,92,24,11,72,72,16,17,57,72,68,46,15,85,58,74,55,54,87,97,44,94,16,84,57,56,96,33,79,7,70,50,23,98,91,6,62,51,73,68,17,83,93,56,15,81,99,88,15,13,93,53,48,69,2,14,83,86,39,4,54,69,52,42,60,79,92,38,68,90,48,77,46,77,16,89,3,96,77,11,77,23,73,98,35,3,1,97,48,62,36,74,13,93,19,71,23,70,64,64,14,71,86,98,20,95,1,97,30,92,16,98,63,94,56,90,49,94,28,88,43,84,38,74,83,62,4,98,63,69,0,0,21,21,1,10,1,0,0,0,0,0,0";
    public override Task ExecuteAsync()
    {
        var computer = new IntCodeComputer(input).Compile();
        IDictionary<(long, long), long> map = new Dictionary<(long, long), long>();
        IDictionary<(long, long), long> comingFromDirections = new Dictionary<(long, long), long>();
        (long, long) targetLocation = (0, 0);
        (long, long) location = (0, 0);
        map[location] = 1;
        while (true)
        {
            bool foundNewLocation = true;
            long comingFrom = 0;
            (long, long) nextLocation = (0, 0);
            if (!map.ContainsKey(North(location)))
            {
                computer.AddParameters(1);
                nextLocation = North(location);
                comingFrom = 2;
            }
            else if (!map.ContainsKey(East(location)))
            {
                computer.AddParameters(4);
                nextLocation = East(location);
                comingFrom = 3;
            }
            else if (!map.ContainsKey(South(location)))
            {
                computer.AddParameters(2);
                nextLocation = South(location);
                comingFrom = 1;
            }
            else if (!map.ContainsKey(West(location)))
            {
                computer.AddParameters(3);
                nextLocation = West(location);
                comingFrom = 4;
            }
            else
            {
                foundNewLocation = false;
                if (comingFromDirections.ContainsKey(location))
                {
                    var direction = comingFromDirections[location];
                    computer.AddParameters(direction);
                    switch (direction)
                    {
                        case 1:
                            nextLocation = North(location);
                            break;
                        case 2:
                            nextLocation = South(location);
                            break;
                        case 3:
                            nextLocation = West(location);
                            break;
                        case 4:
                            nextLocation = East(location);
                            break;
                    }
                }
                else
                {
                    break;
                }
            }

            var result = computer.Run().First();
            if (foundNewLocation)
            {
                map[nextLocation] = result;
                comingFromDirections[nextLocation] = comingFrom;
            }

            if (result != 0)
            {
                location = nextLocation;
                if (result == 2)
                {
                    targetLocation = location;
                }
            }
        }


        HashSet<(long, long)> visited = new HashSet<(long, long)>();
        int step = 0;
        IList<(long, long)> current = new List<(long, long)> { targetLocation };
        long totalMap = map.Count(m => m.Value != 0);
        while (visited.Count < totalMap)
        {
            IList<(long, long)> next = new List<(long, long)>();
            foreach (var currentLocation in current)
            {
                var n = North(currentLocation);
                var e = East(currentLocation);
                var s = South(currentLocation);
                var w = West(currentLocation);
                if (!visited.Contains(n) && map[n] != 0)
                {
                    visited.Add(n);
                    next.Add(n);
                }
                if (!visited.Contains(e) && map[e] != 0)
                {
                    visited.Add(e);
                    next.Add(e);
                }
                if (!visited.Contains(s) && map[s] != 0)
                {
                    visited.Add(s);
                    next.Add(s);
                }
                if (!visited.Contains(w) && map[w] != 0)
                {
                    visited.Add(w);
                    next.Add(w);
                }
            }

            step++;
            current = next;
        }

        (long, long) North((long, long) l)
        {
            return (l.Item1, l.Item2 + 1);
        }
        (long, long) East((long, long) l)
        {
            return (l.Item1 + 1, l.Item2);
        }
        (long, long) South((long, long) l)
        {
            return (l.Item1, l.Item2 - 1);
        }
        (long, long) West((long, long) l)
        {
            return (l.Item1 - 1, l.Item2);
        }

        Result = step.ToString();

        return Task.CompletedTask;
    }



    public override int Nummer => 201915;
}