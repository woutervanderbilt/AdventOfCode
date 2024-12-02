using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2019;

public class Dag16 : Problem
{
    private const string input =
        @"59719896749391372935980241840868095901909650477974922926863874668817926756504816327136638260644919270589305499504699701736406883012172909202912675166762841246709052187371758225695359676410279518694947094323466110604412184843328145082858383186144864220867912457193726817225273989002642178918584132902751560672461100948770988856677526693132615515437829437045916042287792937505148994701494994595404345537543400830028374701775936185956190469052693669806665481610052844626982468241111349622754998877546914382626821708059755592288986918651172943415960912020715327234415148476336205299713749014282618817141515873262264265988745414393060010837408970796104077";

    private const int skip = 5971989;
    private const string testinput = "12345678";
    private readonly IList<long> wavePattern = new List<long> { 0, 1, 0, -1 };
    public override Task ExecuteAsync()
    {
        IList<long> inputLongs = input.Select(c => long.Parse(c.ToString())).ToList();
        for (int phase = 0; phase < 100; phase++)
        {
            inputLongs = Apply(inputLongs).ToList();
        }

        Result = string.Join("", inputLongs.Take(8));

        IList<long> digits = input.Select(c => long.Parse(c.ToString())).Reverse().ToList();
        inputLongs = new List<long>();
        for (int i = 0; i < 10000 * 650 - skip; i++)
        {
            inputLongs.Add(digits[i % 650]);
        }
        for (int i = 0; i < 100; i++)
        {
            inputLongs = Apply2(inputLongs).ToList();
        }

        Result += " " + string.Join("", inputLongs.Reverse().Take(8));
        return Task.CompletedTask;
    }

    private IEnumerable<long> Apply2(IList<long> inputList)
    {
        long sum = 0;
        foreach (var l in inputList)
        {
            sum = (sum + l) % 10;
            yield return sum;
        }
    }

    private IEnumerable<long> Apply(IList<long> inputList)
    {
        for (int i = 0; i < inputList.Count; i++)
        {
            long result = 0;
            IList<long> pattern = Pattern(i + 1).Skip(1).Take(inputList.Count).ToList();
            for (int j = 0; j < inputList.Count; j++)
            {
                result += pattern[j] * inputList[j];
            }

            yield return Math.Abs(result) % 10;
        }


        IEnumerable<long> Pattern(int index)
        {
            int waveIndex = 0;
            while (true)
            {
                long wavePhase = wavePattern[waveIndex];
                for (int i = 0; i < index; i++)
                {
                    yield return wavePhase;
                }

                waveIndex = (waveIndex + 1) % 4;
            }
        }

    }

    public override int Nummer => 201916;
}