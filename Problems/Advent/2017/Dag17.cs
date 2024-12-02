using System.Collections.Generic;
using System.Threading.Tasks;

namespace Problems.Advent._2017;

internal class Dag17 : Problem
{
    public override Task ExecuteAsync()
    {
        IList<int> list = new List<int> { 0 };
        int index = 0;
        for (int i = 1; i <= 2017; i++)
        {
            index = (index + 382) % i;
            list.Insert(index + 1, i);
            index = (index + 1) % (i + 1);
        }

        var valueAfter0 = -1;
        var indexPart2 = 0;
        int indexOf0 = 0;
        for (int i = 1; i < 50000000; i++)
        {
            indexPart2 = (indexPart2 + 382) % i;
            if (indexPart2 < indexOf0)
            {
                indexOf0++;
            }
            else if (indexPart2 == indexOf0)
            {
                valueAfter0 = i;
            }
            indexPart2 = (indexPart2 + 1) % (i + 1);

        }

        Result = $"{list[(index + 1) % 2017]} {valueAfter0}";
        return Task.CompletedTask;
    }

    public override int Nummer => 201717;
}