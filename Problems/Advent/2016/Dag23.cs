using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent;

public class Dag23 : Problem
{
    private const string input = @"cpy a b
dec b
cpy a d
cpy 0 a
cpy b c
inc a
dec c
jnz c -2
dec d
jnz d -5
dec b
cpy b c
cpy c d
dec d
inc c
jnz d -2
tgl c
cpy -16 c
jnz 1 c
cpy 77 c
jnz 87 d
inc a
inc d
jnz d -2
inc c
jnz c -5";

    public override Task ExecuteAsync()
    {
        for (int a = 6; a <= 12; a++)
        {
            Console.WriteLine(a);
            var assembunny = new Assembunny(input);
            assembunny.A = a;
            assembunny.Run();
            Result = assembunny.A.ToString();
            Console.WriteLine(Result);
            Console.WriteLine();
        }

        return Task.CompletedTask;
    }

    public override int Nummer => 201623;
}