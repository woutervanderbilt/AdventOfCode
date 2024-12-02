using Algorithms.Extensions;
using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag03 : Problem
{
    const string testinput = @"467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..";
    public override async Task ExecuteAsync()
    {

        var grid = new Grid<char>();
        int y = 0;
        foreach (var line in Input.Split(Environment.NewLine))
        {
            int x = 0;
            foreach (char c in line)
            {
                grid[x, y] = c;
                x++;
            }

            y++;
        }

        long result = 0;
        int currentValue = 0;
        bool currentAdjacent = false;
        int currentLine = 0;
        HashSet<(int, int)> currentGears = new HashSet<(int, int)>();
        IDictionary<(int, int), IList<long>> gears = new Dictionary<(int, int), IList<long>>();
        foreach (var member in grid.AllMembers())
        {
            if (currentLine != member.y || !char.IsDigit(member.value))
            {
                if (currentAdjacent)
                {
                    result += currentValue;
                }
                foreach (var gear in currentGears)
                {
                    if (!gears.ContainsKey(gear))
                    {
                        gears[gear] = new List<long>();
                    }
                    gears[gear].Add(currentValue);
                }
                currentLine = member.y;
                currentValue = 0;
                currentAdjacent = false;
                currentGears = new HashSet<(int, int)>();
            }
            if (char.IsDigit(member.value))
            {
                currentValue = 10 * currentValue + member.value - '0';
                currentAdjacent |= grid.Neighbours((member.x, member.y), true)
                    .Any(n => !char.IsDigit(n.Value) && n.Value != '.');
                foreach (var neighbour in grid.Neighbours((member.x, member.y), true))
                {
                    if (neighbour.Value == '*')
                    {
                        currentGears.Add(neighbour.Location);
                    }
                }
            }
        }

        long gearRatio = 0;
        foreach (var gear in gears.Values)
        {
            if (gear.Count == 2)
            {
                gearRatio += gear.Product();
            }
        }

        Result = (result, gearRatio).ToString();
    }

    public override int Nummer => 202303;
}