using Algorithms.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag17 : Problem
{
    //private const string input = @">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>";


    public override async Task ExecuteAsync()
    {

        Grid<bool> chamber = new Grid<bool>();
        for (int x = 1; x <= 7; x++)
        {
            chamber[x, 0] = true;
        }
        IList<Grid<bool>> blocks = new List<Grid<bool>>();
        var block1 = new Grid<bool>();
        block1[3, 0] = true;
        block1[4, 0] = true;
        block1[5, 0] = true;
        block1[6, 0] = true;
        blocks.Add(block1);
        var block2 = new Grid<bool>();
        block2[4, 0] = true;
        block2[3, 1] = true;
        block2[4, 1] = true;
        block2[5, 1] = true;
        block2[4, 2] = true;
        blocks.Add(block2);
        var block3 = new Grid<bool>();
        block3[3, 0] = true;
        block3[4, 0] = true;
        block3[5, 0] = true;
        block3[5, 1] = true;
        block3[5, 2] = true;
        blocks.Add(block3);
        var block4 = new Grid<bool>();
        block4[3, 0] = true;
        block4[3, 1] = true;
        block4[3, 2] = true;
        block4[3, 3] = true;
        blocks.Add(block4);
        var block5 = new Grid<bool>();
        block5[3, 0] = true;
        block5[4, 0] = true;
        block5[3, 1] = true;
        block5[4, 1] = true;
        blocks.Add(block5);


        int jetIndex = 0;
        int fallenRocks = 0;
        int highestIndex = 0;
        long? firstIndex = null;
        long firstHeight = 0;
        long limit = 1000000000000;
        long heightToAdd = 0;
        for (long i = 0; i < limit; i++)
        {
            int position = 0;
            int height = highestIndex + 3;
            var block = blocks[(int)(i % 5)].Copy();
            while (true)
            {
                int prevPosition = position;
                var wind = Input[jetIndex];
                jetIndex++;
                if (jetIndex == Input.Length)
                {
                    jetIndex = 0;
                }

                if (wind == '>')
                {
                    if (position + block.MaxX < 7)
                    {
                        if (!block.AllMembers().Any(m =>
                            {
                                var c = chamber[m.x + position + 1, m.y + height + 1];
                                return c.Found;
                            }))
                        {
                            position++;
                        }
                    }
                }
                else if (wind == '<')
                {
                    if (position + block.MinX > 1)
                    {
                        if (!block.AllMembers().Any(m =>
                            {
                                var c = chamber[m.x + position - 1, m.y + height + 1];
                                return c.Found;
                            }))
                        {
                            position--;
                        }
                    }
                }

                if (!block.AllMembers().Any(m =>
                    {
                        var c = chamber[m.x + position, m.y + height];
                        return c.Found;
                    }))
                {
                    height--;
                }
                else
                {
                    foreach (var m in block.AllMembers())
                    {
                        chamber[m.x + position, m.y + height + 1] = true;
                    }

                    var diff = highestIndex - height;
                    if (diff == 51 && heightToAdd == 0)
                    {
                        if (firstIndex == null)
                        {
                            firstIndex = i;
                            firstHeight = highestIndex;
                        }
                        else
                        {
                            long cycle = i - firstIndex.Value;
                            long cycleHeight = highestIndex - firstHeight;
                            long cyclesToAdd = limit / cycle - i / cycle - 1;
                            i += cyclesToAdd * cycle;
                            heightToAdd = cyclesToAdd * cycleHeight;
                        }
                    }
                    //chamber.Print();
                    //Console.WriteLine();
                    highestIndex = chamber.MaxY;
                    break;
                }
            }
        }

        Result = (heightToAdd + highestIndex).ToString();

    }

    public override int Nummer => 202217;
}