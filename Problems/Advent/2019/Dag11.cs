﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2019;

public class Dag11 : Problem
{
    private const string input = @"3,8,1005,8,345,1106,0,11,0,0,0,104,1,104,0,3,8,102,-1,8,10,1001,10,1,10,4,10,108,1,8,10,4,10,102,1,8,28,1006,0,94,2,106,5,10,1,1109,12,10,3,8,1002,8,-1,10,1001,10,1,10,4,10,1008,8,1,10,4,10,101,0,8,62,1,103,6,10,1,108,12,10,3,8,102,-1,8,10,1001,10,1,10,4,10,1008,8,0,10,4,10,102,1,8,92,2,104,18,10,2,1109,2,10,2,1007,5,10,1,7,4,10,3,8,102,-1,8,10,1001,10,1,10,4,10,108,0,8,10,4,10,102,1,8,129,2,1004,15,10,2,1103,15,10,2,1009,6,10,3,8,102,-1,8,10,1001,10,1,10,4,10,1008,8,1,10,4,10,101,0,8,164,2,1109,14,10,1,1107,18,10,1,1109,13,10,1,1107,11,10,3,8,102,-1,8,10,101,1,10,10,4,10,108,0,8,10,4,10,1001,8,0,201,2,104,20,10,1,107,8,10,1,1007,5,10,3,8,102,-1,8,10,101,1,10,10,4,10,1008,8,1,10,4,10,101,0,8,236,3,8,1002,8,-1,10,1001,10,1,10,4,10,108,0,8,10,4,10,1001,8,0,257,3,8,102,-1,8,10,101,1,10,10,4,10,108,1,8,10,4,10,102,1,8,279,1,107,0,10,1,107,16,10,1006,0,24,1,101,3,10,3,8,102,-1,8,10,101,1,10,10,4,10,108,0,8,10,4,10,1002,8,1,316,2,1108,15,10,2,4,11,10,101,1,9,9,1007,9,934,10,1005,10,15,99,109,667,104,0,104,1,21101,0,936995730328,1,21102,362,1,0,1105,1,466,21102,1,838210728716,1,21101,373,0,0,1105,1,466,3,10,104,0,104,1,3,10,104,0,104,0,3,10,104,0,104,1,3,10,104,0,104,1,3,10,104,0,104,0,3,10,104,0,104,1,21102,1,235350789351,1,21101,0,420,0,1105,1,466,21102,29195603035,1,1,21102,1,431,0,1105,1,466,3,10,104,0,104,0,3,10,104,0,104,0,21101,0,825016079204,1,21101,0,454,0,1105,1,466,21101,837896786700,0,1,21102,1,465,0,1106,0,466,99,109,2,21201,-1,0,1,21101,0,40,2,21102,1,497,3,21101,0,487,0,1105,1,530,109,-2,2106,0,0,0,1,0,0,1,109,2,3,10,204,-1,1001,492,493,508,4,0,1001,492,1,492,108,4,492,10,1006,10,524,1101,0,0,492,109,-2,2105,1,0,0,109,4,2102,1,-1,529,1207,-3,0,10,1006,10,547,21102,1,0,-3,21201,-3,0,1,22102,1,-2,2,21101,1,0,3,21102,1,566,0,1105,1,571,109,-4,2106,0,0,109,5,1207,-3,1,10,1006,10,594,2207,-4,-2,10,1006,10,594,21201,-4,0,-4,1106,0,662,21201,-4,0,1,21201,-3,-1,2,21202,-2,2,3,21101,613,0,0,1105,1,571,22101,0,1,-4,21101,0,1,-1,2207,-4,-2,10,1006,10,632,21101,0,0,-1,22202,-2,-1,-2,2107,0,-3,10,1006,10,654,22101,0,-1,1,21102,654,1,0,105,1,529,21202,-2,-1,-2,22201,-4,-2,-4,109,-5,2105,1,0";

    public override Task ExecuteAsync()
    {
        var robot = new PaintingRobot(new IntCodeComputer(input).Compile());
        robot.Paint(0);
        Result = robot.NumberOfSquaresPainted.ToString();
        Console.WriteLine();
        Console.WriteLine("2:");
        Console.WriteLine();
        var robot2 = new PaintingRobot(new IntCodeComputer(input).Compile());
        robot2.Paint(1);
        return Task.CompletedTask;
    }


    private class PaintingRobot
    {
        private readonly IntCodeComputer computer;

        public PaintingRobot(IntCodeComputer computer)
        {
            this.computer = computer;
        }

        private int DirectionIndex { get; set; }
        private (int, int) Location { get; set; }

        private IDictionary<(int, int), int> Painted { get; set; } = new Dictionary<(int, int), int>();

        public int NumberOfSquaresPainted => Painted.Count;

        public void Paint(int start)
        {
            computer.AddParameters(start);
            var output = computer.Run().ToList();
            while (computer.IsRunning)
            {
                Painted[Location] = (int)output[0];
                if (output[1] == 0)
                {
                    DirectionIndex = (DirectionIndex + 1) % 4;
                }
                else
                {
                    DirectionIndex = (DirectionIndex + 3) % 4;
                }

                Location = (Location.Item1 + Directions[DirectionIndex].Item1,
                    Location.Item2 + Directions[DirectionIndex].Item2);
                computer.AddParameters(GetInputParameter());
                output = computer.Run().ToList();
            }

            ShowPainting();
        }

        private void ShowPainting()
        {
            int xMax = Painted.Max(p => p.Key.Item1);
            int xMin = Painted.Min(p => p.Key.Item1);
            int yMax = Painted.Max(p => p.Key.Item2);
            int yMin = Painted.Min(p => p.Key.Item2);
            for (int y = yMax; y >= yMin; y--)
            {
                StringBuilder sb = new StringBuilder();
                for (int x = xMax; x >= xMin; x--)
                {
                    sb.Append(Painted.ContainsKey((x, y)) ? (Painted[(x, y)] == 0 ? " " : "█") : ".");
                }

                Console.WriteLine(sb);
            }
        }



        private static IList<(int, int)> Directions = new List<(int, int)>
        {
            (0, 1),
            (1, 0),
            (0, -1),
            (-1, 0)
        };

        private long GetInputParameter()
        {
            if (Painted.ContainsKey(Location))
            {
                return Painted[Location];
            }

            return 0;
        }
    }

    public override int Nummer => 201911;
}