using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2024;

internal class Dag09 : Problem
{
    public override async Task ExecuteAsync()
    {
        IList<(long, long, bool)> blocks = [];
        long filenumber = 0;
        bool empty = false;
        foreach (var c in Input)
        {
            long length = long.Parse(new [] { c });
            if (empty)
            {
                blocks.Add((-1, length, false));
            }
            else
            {
                blocks.Add((filenumber, length, false));
                filenumber++;
            }

            empty = !empty;
        }

        var blocksCopy = blocks.ToList();

        IList<(long, long)> compressed = [];
        int i2 = blocks.Count - 1;
        for (int i1 = 0; i1 < blocks.Count; i1++)
        {
            var block = blocks[i1];
            if (block.Item1 >= 0)
            {
                compressed.Add((block.Item1, block.Item2));
                continue;
            }
            else
            {
                long filled = 0;
                while (filled < block.Item2)
                {
                    if (i2 <= i1)
                    {
                        break;
                    }
                    var endblock = blocks[i2];
                    if (endblock.Item1 == -1)
                    {
                        i2--;
                        continue;
                    }

                    if (endblock.Item2 > block.Item2 - filled)
                    {
                        compressed.Add((endblock.Item1, block.Item2 - filled));
                        blocks[i2] = (endblock.Item1, endblock.Item2 - block.Item2 + filled, false);
                        filled = block.Item2;
                    }
                    else
                    {
                        compressed.Add((endblock.Item1, endblock.Item2));
                        filled += endblock.Item2;
                        i2--;   
                    }
                }

                if (i2 <= i1)
                {
                    break;
                }
            }
        }

        var r1 = CheckSum();
        compressed = [];
        for (int i0 = 0; i0 < blocksCopy.Count; i0++)
        {
            var block = blocksCopy[i0];
            if (block.Item1 >= 0 && !block.Item3)
            {
                compressed.Add((block.Item1, block.Item2));
            }
            else
            {
                long filled = 0;
                for (int i1 = blocksCopy.Count - 1; i1 > i0; i1--)
                {
                    var blockToMove = blocksCopy[i1];
                    if (blockToMove.Item3 || blockToMove.Item1 == -1)
                    {
                        continue;
                    }

                    if (blockToMove.Item2 <= block.Item2 - filled)
                    {
                        blocksCopy[i1] = (blockToMove.Item1, blockToMove.Item2, true);
                        compressed.Add((blockToMove.Item1, blockToMove.Item2));
                        filled += blockToMove.Item2;
                    }
                }

                if (filled < block.Item2)
                {
                    compressed.Add((0, block.Item2 - filled));
                }
            }
        }

        var r2 = CheckSum();

        Result = (r1, r2).ToString();

        long CheckSum()
        {
            long result = 0;
            long index = 0;
            foreach (var compressedBlock in compressed)
            {
                result += compressedBlock.Item1 * ((index + compressedBlock.Item2) * (index + compressedBlock.Item2 - 1) / 2 -
                                                   index * (index - 1) / 2);
                index += compressedBlock.Item2;
            }

            return result;
        }
    }

    protected override bool UseTestInput => false;
    protected override string TestInput => "2333133121414131402";

    public override int Nummer => 202409;
}