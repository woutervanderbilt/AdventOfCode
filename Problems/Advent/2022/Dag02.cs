using System;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag02 : Problem
{
    public override async Task ExecuteAsync()
    {
        int score = 0;
        foreach (var line in Input.Split(Environment.NewLine))
        {
            //score += line switch
            //{
            //    "A X" => 4,
            //    "A Y" => 8,
            //    "A Z" => 3,
            //    "B X" => 1,
            //    "B Y" => 5,
            //    "B Z" => 9,
            //    "C X" => 7,
            //    "C Y" => 2,
            //    "C Z" => 6,
            //};
            score += line switch
            {
                "A X" => 3,
                "A Y" => 4,
                "A Z" => 8,
                "B X" => 1,
                "B Y" => 5,
                "B Z" => 9,
                "C X" => 2,
                "C Y" => 6,
                "C Z" => 7,
            };
        }

        Result = score.ToString();
    }

    public override int Nummer => 202202;
}