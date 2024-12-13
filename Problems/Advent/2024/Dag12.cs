using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag12 : Problem
{
    public override async Task ExecuteAsync()
    {
        var grid = Grid<char>.FromInput(Input, c => c);
        grid.CanMove = (a, b) => a.Value == b.Value;
        long result1 = grid.Groups().Sum(g => g.Count * g.Sum(m => 4 - grid.Neighbours(m.Location, false).Count()));
        long result2 = grid.Groups().Sum(g => g.Count * g.Sum(SideStarts)); ;

        Result = (result1, result2).ToString();

        int SideStarts(GridMember<char> member)
        {
            return GridConstants.MajorDirections.Count(IsStartOfSide);

            bool IsStartOfSide(GridDirection direction)
            {
                var neighbour = grid.MoveInDirection(member.Location, direction);
                if (neighbour.Value == member.Value)
                {
                    return false;
                }
                if (grid.MoveInDirection(member.Location, direction.TurnRight()).Value != member.Value)
                {
                    return true;
                }

                return grid.MoveInDirection(neighbour.Location, direction.TurnRight()).Value == member.Value;

            }
        }
    }

    public override int Nummer => 202412;

    protected override bool UseTestInput => false;

    protected override string TestInput => @"RRRRIICCFF
RRRRIICCCF
VVRRRCCFFF
VVRCCCJFFF
VVVVCJJCFE
VVIVCCJJEE
VVIIICJJEE
MIIIIIJJEE
MIIISIJEEE
MMMISSJEEE";
}