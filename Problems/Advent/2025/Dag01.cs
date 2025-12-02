using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2025;
internal class Dag01 : Problem
{
    public override Task ExecuteAsync()
    {
        int count = 0;
        int count2 = 0;
        int position = 50;
        foreach (var line in Input.Split(Environment.NewLine))
        {
            int move = int.Parse(line.Substring(1));
            int direction = line[0] == 'L' ? -1 : 1;
            for (int s = 0; s < move; s++)
            {
                position = (position + direction + 100) % 100;
                if (position == 0)
                {
                    count2++;
                }
            }

            if (position == 0)
            {
                count++;
            }
        }

        Result = (count, count2).ToString();
        return Task.CompletedTask;
    }

    protected override string? TestInput => @"L68
L30
R48
L5
R60
L55
L1
L99
R14
L82";
    protected override bool UseTestInput => false;

    public override int Nummer => 202501;
}
