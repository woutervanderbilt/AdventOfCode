using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent
{
    public class Dag25 : Problem
    {
        private const string input = @"cpy a d
cpy 7 c
cpy 365 b
inc d
dec b
jnz b -2
dec c
jnz c -5
cpy d a
jnz 0 0
cpy a b
cpy 0 a
cpy 2 c
jnz b 2
jnz 1 6
dec b
dec c
jnz c -4
inc a
jnz 1 -7
cpy 2 b
jnz c 2
jnz 1 4
dec b
dec c
jnz 1 -4
jnz 0 0
out b
jnz a -19
jnz 1 -21";

        public override Task ExecuteAsync()
        {
            for (int a = 175; a <= 1000000; a++)
            {
                var assembunny = new Assembunny(input);
                assembunny.A = a;
                var output = string.Join(',', assembunny.Run().Take(120));
                if (output.StartsWith("0,1,0,1,0,1,0,1"))
                {
                    Console.WriteLine($"{a} {output}");
                }
            }



            return Task.CompletedTask;
        }

        public override int Nummer => 201625;
    }
}
