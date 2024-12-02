using Algorithms.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag15 : Problem
{
    private const string testinput = @"rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7";
    public override async Task ExecuteAsync()
    {
        long total = 0;
        var boxes = new List<(string, int)>[256];
        for (int i = 0; i < 256; i++)
        {
            boxes[i] = new List<(string, int)>();
        }

        foreach (var line in Input.Split(','))
        {
            List<(string, int)> box = null;
            string label = line.Split('=')[0].Split('-')[0];
            bool set = true;
            long current = 0;
            foreach (var c in line)
            {
                if (c == '=' || c == '-')
                {
                    box = boxes[current];
                    set = c == '=';
                }
                current += c;
                current *= 17;
                current %= 256;
            }
            if (set)
            {
                var focalLength = int.Parse(line.Split('=')[1]);
                bool changed = false;
                for (int i = 0; i < box.Count; i++)
                {
                    if (box[i].Item1 == label)
                    {
                        box[i] = (label, focalLength);
                        changed = true;
                        break;
                    }
                }

                if (!changed)
                {
                    box.Add((label, focalLength));
                }
            }
            else
            {
                for (int i = 0; i < box.Count; i++)
                {
                    if (box[i].Item1 == label)
                    {
                        box.RemoveAt(i);
                        break;
                    }
                }
            }
            total += current;
        }

        long result2 = 0;
        foreach (var (box, index) in boxes.Indexed())
        {
            foreach (var (lens, index2) in box.Indexed())
            {
                result2 += (index + 1L) * (index2 + 1) * lens.Item2;
            }
        }
        Result = (total, result2).ToString();
    }

    public override int Nummer => 202315;
}