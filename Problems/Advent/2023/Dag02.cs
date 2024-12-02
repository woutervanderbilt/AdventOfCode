using System;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag02 : Problem
{
    public override async Task ExecuteAsync()
    {
        int maxRed = 12;
        int maxGreen = 13;
        int maxBlue = 14;

        long sumValidGameIds = 0;
        long totalPower = 0;
        foreach (var line in Input.Split(Environment.NewLine))
        {
            long minRed = 0;
            long minBlue = 0;
            long minGreen = 0;
            var gameSplit = line.Split(':');
            int gameId = int.Parse(gameSplit[0].Split(' ')[1]);
            bool valid = true;
            foreach (var show in gameSplit[1].Split(';'))
            {
                foreach (var color in show.Split(','))
                {
                    var split = color.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var count = int.Parse(split[0]);
                    if (split[1] == "blue")
                    {
                        valid &= count <= maxBlue;
                        minBlue = Math.Max(minBlue, count);
                    }
                    else if (split[1] == "red")
                    {
                        valid &= count <= maxRed;
                        minRed = Math.Max(minRed, count);
                    }
                    else if (split[1] == "green")
                    {
                        valid &= count <= maxGreen;
                        minGreen = Math.Max(minGreen, count);
                    }
                }
            }
            if (valid)
            {
                sumValidGameIds += gameId;
            }

            totalPower += minGreen * minBlue * minRed;
        }

        Result = (sumValidGameIds, totalPower).ToString();
    }

    public override int Nummer => 202302;
}