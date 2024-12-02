using Algorithms.Models;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Problems.Advent._2021;

internal class Dag06 : Problem
{
    private const string input = @"3,5,3,5,1,3,1,1,5,5,1,1,1,2,2,2,3,1,1,5,1,1,5,5,3,2,2,5,4,4,1,5,1,4,4,5,2,4,1,1,5,3,1,1,4,1,1,1,1,4,1,1,1,1,2,1,1,4,1,1,1,2,3,5,5,1,1,3,1,4,1,3,4,5,1,4,5,1,1,4,1,3,1,5,1,2,1,1,2,1,4,1,1,1,4,4,3,1,1,1,1,1,4,1,4,5,2,1,4,5,4,1,1,1,2,2,1,4,4,1,1,4,1,1,1,2,3,4,2,4,1,1,5,4,2,1,5,1,1,5,1,2,1,1,1,5,5,2,1,4,3,1,2,2,4,1,2,1,1,5,1,3,2,4,3,1,4,3,1,2,1,1,1,1,1,4,3,3,1,3,1,1,5,1,1,1,1,3,3,1,3,5,1,5,5,2,1,2,1,4,2,3,4,1,4,2,4,2,5,3,4,3,5,1,2,1,1,4,1,3,5,1,4,1,2,4,3,1,5,1,1,2,2,4,2,3,1,1,1,5,2,1,4,1,1,1,4,1,3,3,2,4,1,4,2,5,1,5,2,1,4,1,3,1,2,5,5,4,1,2,3,3,2,2,1,3,3,1,4,4,1,1,4,1,1,5,1,2,4,2,1,4,1,1,4,3,5,1,2,1";
    public override Task ExecuteAsync()
    {
        var matrix = new SquareMatrix(9, 1000000007);
        for (int i = 1; i <= 8; i++)
        {
            matrix[i, i - 1] = 1;
        }

        matrix[0, 6] = 1;
        matrix[0, 8] = 1;

        BigInteger powerOfTen = 1;
        for (int i = 1; i <= 100000; i++)
        {
            powerOfTen *= 10;
        }

        var power = matrix.PowerMod(powerOfTen);
        var vector = new Matrix(1, 9);
        foreach (var l in input.Split(',').Select(int.Parse))
        {
            vector[0, l]++;
        }

        var result = vector.Times(power);
        long sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += result[0, i];
        }

        Result = sum.ToString();

        return Task.CompletedTask;
    }

    public override int Nummer => 202106;
}