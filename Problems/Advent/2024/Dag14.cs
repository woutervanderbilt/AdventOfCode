using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2024;

internal class Dag14 : Problem
{
    public override async Task ExecuteAsync()
    {
        const long width = 101;
        const long height = 103;
        IList<(long x, long y, long vx, long vy)> robots = [];
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var numbers = line.FindAllNumbers().ToList();
            robots.Add((numbers[0], numbers[1], numbers[2], numbers[3]));
        }

        var roboCopy = robots.ToList();
        var locations = robots.Select(r => Move(r, 100));
        var grouped = locations.GroupBy(Quadrant);
        var result = grouped.Where(g => g.Key > 0).Select(g => (long)g.Count()).Product();

        int maxX = 0;
        int maxY = 0;
        int xSteps = 0;
        int ySteps = 0;
        for(int i = 0; i < Math.Max(width, height); i++)
        {
            var closeCountX = 0;
            var closeCountY = 0;
            foreach (var robot in robots)
            {
                foreach (var robot2 in robots)
                {
                    if(Math.Abs(robot.x - robot2.x) <= 3)
                    {
                        closeCountX++;
                    }
                    if (Math.Abs(robot.y - robot2.y) <= 3)
                    {
                        closeCountY++;
                    }
                }
            }

            if (closeCountX > maxX)
            {
                maxX = closeCountX;
                xSteps = i;
            }
            if (closeCountY > maxY)
            {
                maxY = closeCountY;
                ySteps = i;
            }
            robots = robots.Select(r => Move(r, 1)).ToList();
        }

        long result2 = new ResidueClass(xSteps, width).Chinese(new ResidueClass(ySteps, height)).Value;


        var grid = new Grid<bool>();
        foreach (var robot in roboCopy.Select(r => Move(r, result2)))
        {
            grid[(int)robot.x, (int)(height - robot.y)] = true;
        }
        grid.Print();
        Result = (result, result2).ToString();

        (long x, long y, long vx, long vy) Move((long x, long y, long vx, long vy) robot, long steps)
        {
            return ((robot.x + (robot.vx + width) * steps) % width, (robot.y + (robot.vy + height) * steps) % height, robot.vx, robot.vy);
        }

        int Quadrant((long x, long y, long vx, long vy) item)
        {
            return item switch
            {
                { x: < width / 2, y: < height / 2 } => 1,
                { x: < width / 2, y: > height / 2 } => 2,
                { x: > width / 2, y: < height / 2 } => 3,
                { x: > width / 2, y: > height / 2 } => 4,
                _ => 0
            };
        }
    }

    protected override bool UseTestInput => false;


    protected override string TestInput => @"p=0,4 v=3,-3
p=6,3 v=-1,-3
p=10,3 v=-1,2
p=2,0 v=2,-1
p=0,0 v=1,3
p=3,0 v=-2,-2
p=7,6 v=-1,-3
p=3,0 v=-1,-2
p=9,3 v=2,3
p=7,3 v=-1,2
p=2,4 v=2,-3
p=9,5 v=-3,-3";

    public override int Nummer => 202414;
}