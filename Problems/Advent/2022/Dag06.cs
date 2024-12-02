using System;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag06 : Problem
{
    public override async Task ExecuteAsync()
    {
        int markerLength = 14;
        string buffer = "";
        int index = 1;
        foreach (var c in Input)
        {
            buffer += c;
            if (buffer.Length > markerLength)
            {
                buffer = buffer.Substring(1);
            }

            if (buffer.Length == markerLength && buffer.Distinct().Count() == markerLength)
            {
                Result = index.ToString();
                break;
            }
            index++;
        }
    }

    public override int Nummer => 202206;
}