using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent;

public class Dag08 : Problem
{
    private const string input = @"rect 1x1
rotate row y=0 by 5
rect 1x1
rotate row y=0 by 6
rect 1x1
rotate row y=0 by 5
rect 1x1
rotate row y=0 by 2
rect 1x1
rotate row y=0 by 5
rect 2x1
rotate row y=0 by 2
rect 1x1
rotate row y=0 by 4
rect 1x1
rotate row y=0 by 3
rect 2x1
rotate row y=0 by 7
rect 3x1
rotate row y=0 by 3
rect 1x1
rotate row y=0 by 3
rect 1x2
rotate row y=1 by 13
rotate column x=0 by 1
rect 2x1
rotate row y=0 by 5
rotate column x=0 by 1
rect 3x1
rotate row y=0 by 18
rotate column x=13 by 1
rotate column x=7 by 2
rotate column x=2 by 3
rotate column x=0 by 1
rect 17x1
rotate row y=3 by 13
rotate row y=1 by 37
rotate row y=0 by 11
rotate column x=7 by 1
rotate column x=6 by 1
rotate column x=4 by 1
rotate column x=0 by 1
rect 10x1
rotate row y=2 by 37
rotate column x=19 by 2
rotate column x=9 by 2
rotate row y=3 by 5
rotate row y=2 by 1
rotate row y=1 by 4
rotate row y=0 by 4
rect 1x4
rotate column x=25 by 3
rotate row y=3 by 5
rotate row y=2 by 2
rotate row y=1 by 1
rotate row y=0 by 1
rect 1x5
rotate row y=2 by 10
rotate column x=39 by 1
rotate column x=35 by 1
rotate column x=29 by 1
rotate column x=19 by 1
rotate column x=7 by 2
rotate row y=4 by 22
rotate row y=3 by 5
rotate row y=1 by 21
rotate row y=0 by 10
rotate column x=2 by 2
rotate column x=0 by 2
rect 4x2
rotate column x=46 by 2
rotate column x=44 by 2
rotate column x=42 by 1
rotate column x=41 by 1
rotate column x=40 by 2
rotate column x=38 by 2
rotate column x=37 by 3
rotate column x=35 by 1
rotate column x=33 by 2
rotate column x=32 by 1
rotate column x=31 by 2
rotate column x=30 by 1
rotate column x=28 by 1
rotate column x=27 by 3
rotate column x=26 by 1
rotate column x=23 by 2
rotate column x=22 by 1
rotate column x=21 by 1
rotate column x=20 by 1
rotate column x=19 by 1
rotate column x=18 by 2
rotate column x=16 by 2
rotate column x=15 by 1
rotate column x=13 by 1
rotate column x=12 by 1
rotate column x=11 by 1
rotate column x=10 by 1
rotate column x=7 by 1
rotate column x=6 by 1
rotate column x=5 by 1
rotate column x=3 by 2
rotate column x=2 by 1
rotate column x=1 by 1
rotate column x=0 by 1
rect 49x1
rotate row y=2 by 34
rotate column x=44 by 1
rotate column x=40 by 2
rotate column x=39 by 1
rotate column x=35 by 4
rotate column x=34 by 1
rotate column x=30 by 4
rotate column x=29 by 1
rotate column x=24 by 1
rotate column x=15 by 4
rotate column x=14 by 1
rotate column x=13 by 3
rotate column x=10 by 4
rotate column x=9 by 1
rotate column x=5 by 4
rotate column x=4 by 3
rotate row y=5 by 20
rotate row y=4 by 20
rotate row y=3 by 48
rotate row y=2 by 20
rotate row y=1 by 41
rotate column x=47 by 5
rotate column x=46 by 5
rotate column x=45 by 4
rotate column x=43 by 5
rotate column x=41 by 5
rotate column x=33 by 1
rotate column x=32 by 3
rotate column x=23 by 5
rotate column x=22 by 1
rotate column x=21 by 2
rotate column x=18 by 2
rotate column x=17 by 3
rotate column x=16 by 2
rotate column x=13 by 5
rotate column x=12 by 5
rotate column x=11 by 5
rotate column x=3 by 5
rotate column x=2 by 5
rotate column x=1 by 5";

    public override Task ExecuteAsync()
    {
        var display = new Display();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            if (line.StartsWith("rect"))
            {
                var parameters = line.Split(' ')[1].Split('x').Select(int.Parse).ToList();
                display.Rect(parameters[0], parameters[1]);
            }
            else
            {
                var split = line.Split(' ').ToList();
                var p1 = int.Parse(split[2].Substring(2));
                var p2 = int.Parse(split[4]);
                if (split[1] == "row")
                {
                    display.RotateRow(p1, p2);
                }
                else
                {
                    display.RotateColumn(p1, p2);
                }
            }
        }

        Result = display.PixelCount.ToString();
        display.Show();
        return Task.CompletedTask;
    }

    private class Display
    {
        private bool[,] pixels = new bool[50, 6];

        public void Rect(int a, int b)
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    pixels[i, j] = true;
                }
            }
        }

        public void RotateRow(int a, int b)
        {
            bool[] temp = new bool[50];
            for (int i = 0; i < 50; i++)
            {
                temp[i] = pixels[(i + 50 - b) % 50, a];
            }

            for (int i = 0; i < 50; i++)
            {
                pixels[i, a] = temp[i];
            }
        }

        public void RotateColumn(int a, int b)
        {
            bool[] temp = new bool[6];
            for (int i = 0; i < 6; i++)
            {
                temp[i] = pixels[a, (i + 6 - b) % 6];
            }

            for (int i = 0; i < 6; i++)
            {
                pixels[a, i] = temp[i];
            }
        }

        public int PixelCount
        {
            get
            {
                int res = 0;
                for (int a = 0; a < 50; a++)
                {
                    for (int b = 0; b < 6; b++)
                    {
                        if (pixels[a, b])
                        {
                            res++;
                        }
                    }
                }

                return res;
            }
        }

        public void Show()
        {
            for (int i = 0; i < 6; i++)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < 50; j++)
                {
                    sb.Append(pixels[j, i] ? '#' : '.');
                }
                Console.WriteLine(sb);
            }
        }
    }

    public override int Nummer => 201608;
}