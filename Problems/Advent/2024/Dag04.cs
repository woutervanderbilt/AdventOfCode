using Algorithms.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2024;

internal class Dag04 : Problem
{
    public override async Task ExecuteAsync()
    {
        var grid = Grid<char>.FromInput(Input, c => c);
        long count = 0, count2 = 0;
        foreach (var letter in grid.AllGridMembers())
        {
            if (letter.Value != 'X')
            {
                continue;
            }
            foreach (GridDirection direction in Enum.GetValues(typeof(GridDirection)))
            {
                var spike = grid.Spike(letter, direction, 4).ToList();
                if(spike.All(m => m.Found) && new string(spike.Select(m => m.Value).ToArray()) == "XMAS")
                {
                    count++;
                }
            }
        }

        foreach (var letter in grid.AllGridMembers())
        {
            if (letter.Value != 'A')
            {
                continue;
            }
            var spike1 = grid.Spike(grid.MoveInDirection(letter.Location, GridDirection.NorthEast), GridDirection.SouthWest, 3).ToList();
            var spike2 = grid.Spike(grid.MoveInDirection(letter.Location, GridDirection.NorthWest), GridDirection.SouthEast, 3).ToList();
            if (spike1.All(m => m.Found) && spike2.All(m => m.Found))
            {
                var string1 = new string(spike1.Select(m => m.Value).ToArray());
                var string2 = new string(spike2.Select(m => m.Value).ToArray());
                IList<string> sammas = ["SAM", "MAS"];
                if(sammas.Contains(string1) && sammas.Contains(string2))
                {
                    count2++;
                }
            }
        }
        Result = (count, count2).ToString();

    }

    public override int Nummer => 202404;
}