﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2019;

public class Dag20 : Problem
{
    private const string input = @"                                 C X   J         X     B         U       N     J                                 
                                 N Z   I         Y     U         D       U     M                                 
  ###############################.#.###.#########.#####.#########.#######.#####.###############################  
  #...#.#.#.......#...#...#...........#...#.#...#...#...#.#...#...#.........#.....#...#.#.......#.......#.#.#.#  
  ###.#.#.#.#.###.###.###.#####.#######.###.#.#####.#.###.#.#.###.#.#.#.#.#######.#.###.#.###.###.#######.#.#.#  
  #.#...#...#.#.#...#...#.#.......#...#.#.#...#.....#.#...#.#...#.#.#.#.#.#.#.....#...#...#.#...#.#...#...#...#  
  #.###.#.#####.#.###.#.#.#.#####.#.#.#.###.#.###.###.###.#.###.#.#.#######.###.###.###.###.#####.#.#####.#.###  
  #.......#...#.#...#.#.....#.#...#.#.#.#...#.#.....#.....#...#...#.#.....#...#...#.....#.#.....#.#...#.#.....#  
  #.###.#.###.#.###.#####.#.#.#.###.#.#.#.###.#.###.#####.#.#####.#.#.###.#.#.###.#.###.#.#.###.#.#.###.###.###  
  #.#...#.#.....#.#...#.#.#.#.......#.#...#...#.#.#.#.#...#...#...#.....#.#.#.......#.....#...#.....#.#.......#  
  #.###########.#.###.#.#############.#####.#.#.#.###.#.###.#####.#.#.###.#.###.###.###.#.#.#########.###.#####  
  #.#...........#...#.............#...#.#...#.#.....#...#.#.....#.#.#.#.#.#.#...#.#.#.#.#.....#.#...#.........#  
  #########.###.###.#######.###.###.###.#.#####.#######.#.###.#########.#.#.###.#.###.#.###.###.###.###.###.#.#  
  #...#.#.#.#...#.#.#.#.....#.#.......#.......#...#.#.....#.....#.....#...#...#.....#.....#.#...#.#.......#.#.#  
  #.###.#.#####.#.#.#.###.###.###.#.#.###.#####.###.#.#####.###.#####.#.#.#.#################.###.###.#.#.#####  
  #.............#.....#...#.#.....#.#.#.#.....#...#.....#...#.....#...#.#.#.....#.#...#.....#.#...#...#.#...#.#  
  #############.###.#.#.###.###.#.#####.#.#####.#.###.###.#.###.#####.###.#.###.#.#.#####.#.#.###.###.#######.#  
  #.#.....#.....#.#.#.#.#.......#.#...#.......#.#.#...#.#.#...#.#...#.#...#...#.#.#...#.#.#.....#.#.#.#.#.#...#  
  #.#####.#####.#.###.#######.#.###.#.#.#######.#####.#.###.#.#.###.#.#.###.#####.###.#.###.#.#.#.#.#.#.#.#.#.#  
  #.....#.#.............#.#...#...#.#.......#.#...#.....#...#.#.#.#.......#.#.......#.......#.#...........#.#.#  
  #####.#.#.###.###.#.###.#####.#########.###.###.###.###.#.#####.#######.#.###.#####.###.#.#########.#######.#  
  #.#.#.......#.#...#.................#.....#.......#...#.#.......#.#.....#...#...#.....#.#.....#.......#...#.#  
  #.#.###.#.#####.###.#.#.###.#.###.###.###.#.#.#####.#####.###.###.#.###.#.###.###.###############.#.#.###.#.#  
  #.#...#.#.#.....#...#.#...#.#.#.#.#...#.#.#.#.....#.....#.#...#.#.....#.#.....................#...#.#.#.#...#  
  #.###.#############.###########.#.###.#.#######.#####.#######.#.###.#.#########.#######.###.#.#.#####.#.#.###  
  #.#...#...#.#.#...#.....#...........#...#.#.........#.....#.#.....#.#.#.#.........#.#.#.#...#.#.#.#.#.#.....#  
  #.###.#.###.#.#.#####.###.#.#######.#.#.#.###.###.###.#.###.###.#.###.#.###.#.###.#.#.###########.#.#######.#  
  #...#.#.......#.........#.#.#.......#.#.....#...#...#.#.#.......#.#.....#...#...#.#...#.....#...#...........#  
  #.###.#.#########.#.###.#.#######.#.#######.###.#######.#.#############.#.###########.###.###.#############.#  
  #.#.........#.....#.#.#.#.#      M E       U   H       U D             V X        #.#.#.....#.....#.#.#.#...#  
  #.###.###############.#####      F Y       D   L       I R             E Z        #.#.#.#######.###.#.#.###.#  
  #.#.....#.#...#.....#.#.#.#                                                       #.......#.#.#.#...#.#...#.#  
  #.#####.#.###.#.#####.#.#.#                                                       ###.###.#.#.#.#.###.###.#.#  
  #.#.#...#...#...#...#.#...#                                                       #...#.#.....#...#.#.....#.#  
  #.#.###.#.#####.###.#.#.###                                                       ###.#.#.#######.#.#####.#.#  
  #.............#.......#...#                                                       #.#...#...#.#.#...#.#......VE
  #.#######.#####.###.###.###                                                       #.###.#.###.#.###.#.#.#.###  
  #...#.........#...#...#.#.#                                                     TJ......#...............#...#  
  ###.#.#########.#.#####.#.#                                                       #.###.#########.###########  
DR..#.#...#.....#.#.#...#.#..HP                                                     #.#...#.#.#.#.#.#.........#  
  #.#.###.#.###.#.#.###.#.#.#                                                       #.###.#.#.#.#.###.#####.###  
  #.....#...#.#...#.........#                                                       #...#.#...#.#.......#...#.#  
  #######.###.###############                                                       #######.###.#####.###.###.#  
  #.....#.#.......#.#.....#.#                                                       #.#...#.#.#.#...#...#.#....TJ
  #.###.###.###.#.#.#.###.#.#                                                       #.###.#.#.#.#.###.###.#.###  
HP..#.....#...#.#...#...#...#                                                     BU..................#.....#.#  
  #####.###.#####.#.###.#.#.#                                                       #########.#########.#####.#  
  #.........#.....#...#.#.#.#                                                     TC........#.#.#...#.#.#.....#  
  ###########.###.#.#.#.###.#                                                       ###.###.###.#.#.#.#####.#.#  
  #.#.#.....#.#.#.#.#...#.#..FN                                                     #...#.........#...#.....#.#  
  #.#.###.#####.#########.###                                                       #########.#####.#.#.#####.#  
MF..#.#...#.....#...#...#....XY                                                     #...#.#...#.#.#.#.....#.#..FN
  #.#.#.#.#####.#.###.#.#.###                                                       ###.#.#####.#.#####.###.###  
  #.#...#.#.#.........#.#.#.#                                                       #.................#.#.#...#  
  #.#.#.###.###.#.###.#.#.#.#                                                       #.###.###.#.#.###.###.#.#.#  
  #...#.........#...#.#.....#                                                       #.#.....#.#.#.#.#.....#.#..WI
  ###############.#########.#                                                       #.#####.#.#.#.#.#####.#.###  
  #...........#...#...#.#...#                                                     EH..#.#...#.#.#.#...#...#...#  
  #.#####.###.#####.###.#####                                                       ###.#############.#.#####.#  
  #.#...#.#.....#.#.......#.#                                                       #.....#.#...#...#.........#  
  #.#######.#.###.#.###.###.#                                                       ###.###.###.###.#########.#  
  #.......#.#.#.....#...#....YW                                                     #.......#...#...........#.#  
  #####.###.#####.#.###.###.#                                                       #.###.###.#.#.###.#.#######  
TA........#.......#.#.......#                                                     MR..#.#...#.#.....#.#...#....EY
  ###.#.#####.#####.###.#####                                                       #.#.#.###.###########.###.#  
  #...#.#...#.#.....#.......#                                                       #.#.#...#.....#.#.#.......#  
  #######.#.#############.#.#                                                       ###.#.#.###.###.#.#####.###  
  #...#...#.#.#.....#...#.#.#                                                       #...#.#.....#...#.#.#...#.#  
  #.###.###.#.#.#######.#####                                                       ###.###########.#.#.#####.#  
MR....#...#.......#.....#.#.#                                                       #.......#...............#..FM
  #.#####.#####.###.#####.#.#                                                       #.#.#.###.###.#.#####.###.#  
  #.........#................NU                                                   JI..#.#...#.#.#.#...#...#...#  
  ###########################                                                       #.#.#.###.#.#.#######.#.###  
  #...#.#...........#.#.....#                                                       #.#.#...#...#.....#...#...#  
  #.#.#.###.#####.#.#.###.#.#                                                       #######.#.###########.###.#  
ZZ..#.....#.....#.#.#.....#.#                                                       #.#.#.......#...#...#.....#  
  #.#####.#.#######.###.###.#                                                       #.#.#########.#####.#######  
  #...#.....#.#.#.#.....#.#..TA                                                     #.#.#.............#.....#..BW
  #.###.###.#.#.#.#.#.#.#.#.#                                                       #.#.#.#.#.#.#.###.#.###.#.#  
UI....#.#.......#...#.#.#...#                                                       #.....#.#.#.#.#.......#...#  
  #.###.#.#####.#####.#.#####                                                       #.#.###.#####.#####.###.#.#  
  #.#...#.#.#.....#...#.....#                                                     HM..#.#.....#.....#...#...#.#  
  #.#######.#.#######.#######                                                       #.#####.#####.#####.###.#.#  
  #.....#.......#.....#...#.#                                                       #...#...#...#...#.....#.#.#  
  #.#######.#.###.#.#.#.#.#.#      C       F         W         J   B     F          #.#########.#.###.#####.###  
  #.#.#.#.#.#.#...#.#.#.#.#.#      N       M         I         M   W     A          #...#.........#...#.......#  
  #.#.#.#.#####.#####.###.#.#######.#######.#########.#########.###.#####.###########.#######.###.###.#####.###  
  #.........#.....#...#.#.....#.#.#.....#...........#...#.....#.#...#...............#.......#...#.#.....#.....#  
  ###.#.#.#.#.#.###.###.#.#.#.#.#.#.###.#.#.###.#######.#.###.#.#.#######.###.#.#.#.###.#####.#.###.#####.#.#.#  
  #...#.#.#.#.#.#.....#...#.#.........#.#.#...#.#.#.#...#...#.#.#.#...#.#.#.#.#.#.#...#...#...#.#...#.....#.#.#  
  ###.#.#.#.#.#.#######.#.#######.#####.#######.#.#.###.###.#.#.#.#.#.#.###.###.#####.#.###.#######.#.###.#.#.#  
  #...#.#.#.#.#.....#...#.#.#.....#.#.....#.#...#.......#...#.#.#...#.......#.....#.#.#.#.......#...#...#.#.#.#  
  #######.#####.###########.#####.#.###.###.#.#.#.#######.###.#.###.###.#######.###.###########.#####.###.###.#  
  #...........#.....#.........#.#.#.......#...#.#.....#...#...#.#.#.#.#.#.#.#...#.#.......#.#.#.#.#...#.....#.#  
  #####.#.###.#.#.###########.#.#######.###.#######.#.###.#.###.#.###.#.#.#.###.#.#.#.#.###.#.###.#####.#.#.#.#  
  #.....#...#.#.#.#...#.#.#.......#.......#.....#.#.#...#.#.......#.......#...#.....#.#.............#.#.#.#.#.#  
  #.#.#.###.###.#####.#.#.#######.###.#####.#.#.#.#####.#.#.###.#####.#######.#.###########.#.#####.#.###.#.#.#  
  #.#.#...#.#.#.#.....#...............#.#.#.#.#...#.#.#.#.#.#...#...........#.....#.#.#...#.#.....#.....#.#.#.#  
  #.###.###.#.#######.#.#.#####.#.###.#.#.#####.#.#.#.#.#.#####.#######.#####.#####.#.#.#.###.#.#########.#.#.#  
  #...#.#.........#.....#...#.#.#...#.......#.#.#...#...#.....#.#...#...#.#.#.#.#...#.#.#...#.#.......#...#.#.#  
  #.###.###.#.###.#.###.#####.#########.#####.#.#######.#.#######.###.#.#.#.#.#.###.#.#.#######.###.#.###.#.#.#  
  #.#.....#.#.#...#.#...#.#.#.#.#.#...#.....#.....#...#.#.......#...#.#.#...............#.#...#.#.#.#.#...#.#.#  
  #.#.#####.#.#####.#####.#.#.#.#.###.#.#######.###.###.#.#########.###.#.#.#.#.###.#.###.#.#####.###.###.#.###  
  #.#.....#.#...#...#.#.#.#.....#.#.#.#...#.....#.......#.....#.#.#.#.#.#.#.#.#...#.#.#.............#...#.#...#  
  ###.#####.#.#####.#.#.#.#.###.#.#.#.#.#######.#.###.###.#####.#.#.#.#.#.#########.###.###.###.#########.###.#  
  #...#.....#.....#.#.......#...........#.#.#...#...#.#.....#...........#.#.#.#.........#...#.#.#...#.#.#.#...#  
  #.#####.###.#####.#############.#.#.###.#.#.#.#.#.#.###.#######.#####.#.#.#.#####.#########.###.###.#.#.#####  
  #...#.....#...#...#.............#.#...#.....#.#.#.#.#.......#.#.....#.#.#.....#...#.....#.#...#.....#.#.....#  
  #.#####.#.###########.#.#.###.#######.#.#######.###.###.#####.###.#####.#.#####.#.#.#.#.#.#.###.#.###.#######  
  #...#...#...#.........#.#.#...#.......#.....#...#...#.#...#...#.......#.#.#...#.#...#.#.........#...........#  
  #.#######.#####.#.#####.#.#####.#####.#####.###.#####.#.###.#.#.###.###.#.###.###.#.#####.###.#.###.#.###.#.#  
  #.#.........#...#.....#.#.#.....#.......#.....#.....#.......#.#...#.#...........#.#.....#...#.#.#...#...#.#.#  
  #####################################.###.#######.#########.###.#.#######.###################################  
                                       H   Y       H         F   A E       T                                     
                                       M   W       L         A   A H       C                                     ";

    private const string testinput1 = @"         A           
         A           
  #######.#########  
  #######.........#  
  #######.#######.#  
  #######.#######.#  
  #######.#######.#  
  #####  B    ###.#  
BC...##  C    ###.#  
  ##.##       ###.#  
  ##...DE  F  ###.#  
  #####    G  ###.#  
  #########.#####.#  
DE..#######...###.#  
  #.#########.###.#  
FG..#########.....#  
  ###########.#####  
             Z       
             Z       ";

    private const string testinput2 = @"             Z L X W       C                 
             Z P Q B       K                 
  ###########.#.#.#.#######.###############  
  #...#.......#.#.......#.#.......#.#.#...#  
  ###.#.#.#.#.#.#.#.###.#.#.#######.#.#.###  
  #.#...#.#.#...#.#.#...#...#...#.#.......#  
  #.###.#######.###.###.#.###.###.#.#######  
  #...#.......#.#...#...#.............#...#  
  #.#########.#######.#.#######.#######.###  
  #...#.#    F       R I       Z    #.#.#.#  
  #.###.#    D       E C       H    #.#.#.#  
  #.#...#                           #...#.#  
  #.###.#                           #.###.#  
  #.#....OA                       WB..#.#..ZH
  #.###.#                           #.#.#.#  
CJ......#                           #.....#  
  #######                           #######  
  #.#....CK                         #......IC
  #.###.#                           #.###.#  
  #.....#                           #...#.#  
  ###.###                           #.#.#.#  
XF....#.#                         RF..#.#.#  
  #####.#                           #######  
  #......CJ                       NM..#...#  
  ###.#.#                           #.###.#  
RE....#.#                           #......RF
  ###.###        X   X       L      #.#.#.#  
  #.....#        F   Q       P      #.#.#.#  
  ###.###########.###.#######.#########.###  
  #.....#...#.....#.......#...#.....#.#...#  
  #####.#.###.#######.#######.###.###.#.#.#  
  #.......#.......#.#.#.#.#...#...#...#.#.#  
  #####.###.#####.#.#.#.#.###.###.#.###.###  
  #.......#.....#.#...#...............#...#  
  #############.#.#.###.###################  
               A O F   N                     
               A A D   M                     ";

    public override Task ExecuteAsync()
    {
        var lines = input.Split(new[] {Environment.NewLine}, StringSplitOptions.None);

        IDictionary<(int, int), IList<string>> locations = new Dictionary<(int, int), IList<string>>();
        IDictionary<string, IList<(int, int)>> portals = new Dictionary<string, IList<(int, int)>>();
        string letters = "ABCDEHFGHIJKLMNOPQRSTUVWXYZ";
        int linesize = 0;
        int linenumber = lines.Length;
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            linesize = line.Length;
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == '.')
                {
                    locations[(i,j)] = new List<string>();
                    if (letters.Contains(line[j - 1]))
                    {
                        string portal = line.Substring(j - 2, 2);
                        AddPortal(portal);
                    }

                    if (letters.Contains(line[j + 1]))
                    {
                        string portal = line.Substring(j + 1, 2);
                        AddPortal(portal);
                    }

                    if (letters.Contains(lines[i - 1][j]))
                    {
                        string portal = $"{lines[i - 2][j]}{lines[i-1][j]}";
                        AddPortal(portal);
                    }

                    if (letters.Contains(lines[i + 1][j]))
                    {
                        string portal = $"{lines[i + 1][j]}{lines[i + 2][j]}";
                        AddPortal(portal);
                    }
                }


                void AddPortal(string portal)
                {
                    locations[(i,j)].Add(portal);
                    if (portals.ContainsKey(portal))
                    {
                        portals[portal].Add((i,j));
                    }
                    else
                    {
                        portals[portal] = new List<(int, int)>{(i,j)};
                    }
                }
            }
        }

        HashSet<(int,int,int)> visited = new HashSet<(int, int, int)>();
        IList<(int,int, int )> current = new List<(int, int, int)>();
        int step = 0;
        var start = portals["AA"].First();
        var end = portals["ZZ"].First();
        visited.Add((start.Item1, start.Item2, 0));
        current.Add((start.Item1, start.Item2, 0));
        while (!visited.Contains((end.Item1, end.Item2, 0)))
        {
            step++;
            IList<(int, int, int)> nextCurrent = new List<(int, int, int)>();
            foreach (var location in current)
            {
                TestNeighbour((location.Item1 - 1, location.Item2, location.Item3)); 
                TestNeighbour((location.Item1 + 1, location.Item2, location.Item3));
                TestNeighbour((location.Item1, location.Item2 - 1, location.Item3));
                TestNeighbour((location.Item1, location.Item2 + 1, location.Item3));
                foreach (var portal in locations[(location.Item1, location.Item2)])
                {
                    var portalNeighbours = portals[portal].Where(n => n != (location.Item1, location.Item2));
                    var levelChange =
                        (location.Item1 == 2 || location.Item2 == 2 || location.Item1 == linenumber - 3 ||
                         location.Item2 == linesize - 3)
                            ? -1
                            : 1;
                    foreach (var portalNeighbour in portalNeighbours)
                    {
                        TestNeighbour((portalNeighbour.Item1, portalNeighbour.Item2, location.Item3 + levelChange));
                    }
                }




                void TestNeighbour((int, int, int) neighbour)
                {
                    if (neighbour.Item3 < 0)
                    {
                        return;
                    }
                    //if (Math.Abs(neighbour.Item3) > 30)
                    //{
                    //    return;
                    //}
                    if (visited.Contains(neighbour))
                    {
                        return;
                    }
                    if (locations.ContainsKey((neighbour.Item1, neighbour.Item2)))
                    {
                        visited.Add(neighbour);
                        nextCurrent.Add(neighbour);
                    }
                }
            }

            current = nextCurrent;
        }

        Result = step.ToString();

        return Task.CompletedTask;
    }

    public override int Nummer => 201920;
}