using Algorithms.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2019;

public class Dag22 : Problem
{
    private const string input = @"deal with increment 31
deal into new stack
cut -7558
deal with increment 49
cut 194
deal with increment 23
cut -4891
deal with increment 53
cut 5938
deal with increment 61
cut 7454
deal into new stack
deal with increment 31
cut 3138
deal with increment 53
cut 3553
deal with increment 61
cut -5824
deal with increment 42
cut -889
deal with increment 34
cut 7128
deal with increment 42
cut -9003
deal with increment 75
cut 13
deal with increment 75
cut -3065
deal with increment 74
cut -8156
deal with increment 39
cut 4242
deal with increment 24
cut -405
deal with increment 27
cut 6273
deal with increment 19
cut -9826
deal with increment 58
deal into new stack
cut -6927
deal with increment 65
cut -9906
deal with increment 31
deal into new stack
deal with increment 42
deal into new stack
deal with increment 39
cut -4271
deal into new stack
deal with increment 32
cut -8799
deal with increment 69
cut 2277
deal with increment 55
cut 2871
deal with increment 54
cut -2118
deal with increment 15
cut 1529
deal with increment 57
cut -4745
deal with increment 23
cut -5959
deal with increment 58
deal into new stack
deal with increment 48
deal into new stack
cut 2501
deal into new stack
deal with increment 42
deal into new stack
cut 831
deal with increment 74
cut -3119
deal with increment 33
cut 967
deal with increment 69
cut 9191
deal with increment 9
cut 5489
deal with increment 62
cut -9107
deal with increment 14
cut -7717
deal with increment 56
cut 7900
deal with increment 49
cut 631
deal with increment 14
deal into new stack
deal with increment 58
cut -9978
deal with increment 48
deal into new stack
deal with increment 66
cut -1554
deal into new stack
cut 897
deal with increment 36";

    private const string testinput = @"deal into new stack
cut -2
deal with increment 7
cut 8
cut -4
deal with increment 7
cut 3
deal with increment 9
deal with increment 3
cut -1";

    private const string testinput2 = @"deal with increment 7
deal with increment 9
cut -2";


    private const long Modulus = 119315717514047;
    private const long Shuffles = 101741582076661;

    public override Task ExecuteAsync()
    {
        var a = new ResidueClassBigInt(1, Modulus);
        var b = new ResidueClassBigInt(0, Modulus);
        foreach (var instruction in input.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
        {
            if (instruction.StartsWith("deal into"))
            {
                a = -a;
                b = -b - new ResidueClassBigInt(1, Modulus);
            }
            else if (instruction.StartsWith("deal with increment"))
            {
                var increment = new ResidueClassBigInt(int.Parse(instruction.Split(' ').Last()), Modulus);
                a *= increment;
                b *= increment;

            }
            else
            {
                var n = new ResidueClassBigInt(int.Parse(instruction.Split(' ').Last()), Modulus);
                b = b - n;
            }
        }

        var aa = a.ToThePower(Shuffles);
        var bb = (a.ToThePower(Shuffles) - new ResidueClassBigInt(1, Modulus)) *
                 (a - new ResidueClassBigInt(1, Modulus)).Inverse() * b;
        Result = ((new ResidueClassBigInt(2020, Modulus) - bb) * aa.Inverse()).ToString();

        return Task.CompletedTask;
    }

    public override int Nummer => 201922;
}