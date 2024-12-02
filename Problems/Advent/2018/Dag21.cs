using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2018;

internal class Dag21 : Problem
{
    private const string input = @"#ip 4
seti 123 0 5
bani 5 456 5
eqri 5 72 5
addr 5 4 4
seti 0 0 4
seti 0 7 5
bori 5 65536 3
seti 733884 6 5
bani 3 255 1
addr 5 1 5
bani 5 16777215 5
muli 5 65899 5
bani 5 16777215 5
gtir 256 3 1
addr 1 4 4
addi 4 1 4
seti 27 8 4
seti 0 6 1
addi 1 1 2
muli 2 256 2
gtrr 2 3 2
addr 2 4 4
addi 4 1 4
seti 25 4 4
addi 1 1 1
seti 17 8 4
setr 1 7 3
seti 7 0 4
eqrr 5 0 1
addr 1 4 4
seti 5 9 4";
    public override Task ExecuteAsync()
    {
        long i1 = 0, i3 = 65536, i5 = 733884;
        HashSet<long> results = new HashSet<long>();
        HashSet<(long, long)> states = new HashSet<(long, long)>();
        while (true)
        {
            i1 = i3 & 255;
            i5 += i1;
            i5 &= 16777215;
            i5 *= 65899;
            i5 &= 16777215;
            if (256 > i3)
            {
                if (!states.Add((i3, i5)))
                {
                    break;
                }
                else
                {
                    results.Add(i5);
                    i3 = i5 | 65536;
                    i5 = 733884;
                }
            }
            else
            {
                i3 /= 256;
            }
        }

        Result = results.Last().ToString();


        int r0 = 0;
        var device = new ElfDevice(input, 6);
        device.Register[0] = r0;
        while (device.ExecuteInstruction())
        {
            //if (device.InstructionPointer == 28)
            //{
            //    if (!values.Contains(device.Register[5]))
            //    {
            //        Console.WriteLine(device.Register[5]);
            //        values.Add(device.Register[5]);
            //    }
            //    else
            //    {
            //        Result = values.Last().ToString();
            //    }
            //}
        }

        Result = r0.ToString();
        return Task.CompletedTask;
    }

    public override int Nummer => 201821;
}