using System;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2022
{
    internal class Dag14 : Problem
    {
        private const string testinput = @"498,4 -> 498,6 -> 496,6
503,4 -> 502,4 -> 502,9 -> 494,9";
        public override async Task ExecuteAsync()
        {
            var input = await GetInputAsync();
            Grid<char> map = new Grid<char>();
            foreach (var line in input.Split(Environment.NewLine))
            {
                int? currentX = null;
                int? currentY = null;
                foreach (var word in line.Split())
                {
                    if (word == "->")
                    {
                        continue;
                    }

                    var s = word.Split(',');
                    int x = int.Parse(s[0]);
                    int y =  int.Parse(s[1]);
                    if (currentX != null)
                    {
                        if (x == currentX)
                        {
                            for (int yy = Math.Min(y, currentY.Value); yy <= Math.Max(y, currentY.Value); yy++)
                            {
                                map[x, yy] = '#';
                            }
                        }
                        else
                        {
                            for (int xx = Math.Min(x, currentX.Value); xx <= Math.Max(x, currentX.Value); xx++)
                            {
                                map[xx, y] = '#';
                            }
                        }
                    }

                    currentX = x;
                    currentY = y;
                }
            }
            
            var maxY = map.MaxY;

            for (int i = 500-maxY-2; i <= 500 + maxY + 2; i++)
            {
                map[i, maxY + 2] = '#';
            }
            map[500, 0] = '+';
            map.FillBlanks('.');
            
            
            //map.Print(reverseY:true);
            while (Step(out var current))
            {
                map[current.Item1, current.Item2] = 'o';
            }
            //map.Print(reverseY: true);
            Result = map.AllMembers().Count(m => m.value == 'o' || m.value == '+').ToString();


            bool Step(out (int, int) currentSand)
            {
                currentSand = (500, 0);
                var localCurrentSand = currentSand;
                var nextSand = Drop();
                while (currentSand != nextSand)
                {
                    currentSand = nextSand;
                    localCurrentSand = nextSand;
                    nextSand = Drop();
                    //if (nextSand.Item2 == maxY)
                    //{
                    //    return false;
                    //}
                }

                if (currentSand == (500, 0))
                {
                    return false;
                }
                return true;


                (int, int) Drop()
                {
                    if (map[localCurrentSand.Item1, localCurrentSand.Item2 + 1] == '.')
                    {
                        return (localCurrentSand.Item1, localCurrentSand.Item2 + 1);
                    }
                    if (map[localCurrentSand.Item1 - 1, localCurrentSand.Item2 + 1] == '.')
                    {
                        return (localCurrentSand.Item1 - 1, localCurrentSand.Item2 + 1);
                    }
                    if (map[localCurrentSand.Item1 + 1, localCurrentSand.Item2 + 1] == '.')
                    {
                        return (localCurrentSand.Item1 + 1, localCurrentSand.Item2 + 1);
                    }

                    return localCurrentSand;
                }
            }
        }

        public override int Nummer => 202214;
    }
}
