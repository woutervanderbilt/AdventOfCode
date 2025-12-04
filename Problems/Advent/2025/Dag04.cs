using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2025;
internal class Dag04 : Problem
{
    public override Task ExecuteAsync()
    {
        var grid = Grid<bool>.FromInput(Input, c => c == '@');
        long result = 0;
        long result2 = 0;
        bool removed = true;
        foreach (var member in grid.AllGridMembers().Where(m => m.Value))
        {
            if (grid.Neighbours(member.Location, true).Count(n => n.Value) < 4)
            {
                result++;
            }
        }
        while (removed)
        {
            Console.SetCursorPosition(0,0);
            grid.Print(false, '@');
            removed = false;
            var toRemove = new List<GridMember<bool>>();
            foreach (var member in grid.AllGridMembers().Where(m => m.Value))
            {
                if (grid.Neighbours(member.Location, true).Count(n => n.Value) < 4)
                {
                    toRemove.Add(member);
                    result2++;
                }
            }

            if (toRemove.Any())
            {
                removed = true;
                foreach (var gridMember in toRemove)
                {
                    grid[gridMember.X, gridMember.Y] = false;
                }
            }
        }

        Result = (result, result2).ToString();
        return Task.CompletedTask;
    }
    protected override string TestInput => @"..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.";

    protected override bool UseTestInput => false;
    public override int Nummer => 202504;
}