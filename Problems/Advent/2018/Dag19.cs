using Algorithms;
using System.Threading.Tasks;

namespace Problems.Advent._2018;

internal class Dag19 : Problem
{
    private const string input = @"#ip 5
addi 5 16 5
seti 1 1 4
seti 1 8 2
mulr 4 2 3
eqrr 3 1 3
addr 3 5 5
addi 5 1 5
addr 4 0 0
addi 2 1 2
gtrr 2 1 3
addr 5 3 5
seti 2 6 5
addi 4 1 4
gtrr 4 1 3
addr 3 5 5
seti 1 4 5
mulr 5 5 5
addi 1 2 1
mulr 1 1 1
mulr 5 1 1
muli 1 11 1
addi 3 7 3
mulr 3 5 3
addi 3 8 3
addr 1 3 1
addr 5 0 5
seti 0 9 5
setr 5 8 3
mulr 3 5 3
addr 5 3 3
mulr 5 3 3
muli 3 14 3
mulr 3 5 3
addr 1 3 1
seti 0 4 0
seti 0 3 5";

    public override Task ExecuteAsync()
    {
        var factorizer = new Factorizer(10551398);
        Result = factorizer.DivisorSum(10551398).ToString();
        return Task.CompletedTask;


        var elfDevice = new ElfDevice(input, 6);
        elfDevice.Register[0] = 1;
        while (elfDevice.ExecuteInstruction())
        {

        }

        Result = elfDevice.Register[0].ToString();
        return Task.CompletedTask;
    }

    public override int Nummer => 201819;
}