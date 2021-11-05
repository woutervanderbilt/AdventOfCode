using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent
{
    public class Dag12 : Problem
    {
        private const string input = @"cpy 1 a
cpy 1 b
cpy 26 d
jnz c 2
jnz 1 5
cpy 7 c
inc d
dec c
jnz c -2
cpy a c
inc a
dec b
jnz b -2
cpy c b
dec d
jnz d -6
cpy 19 c
cpy 14 d
inc a
dec d
jnz d -2
dec c
jnz c -5";

        public override Task ExecuteAsync()
        {
            var assembunny = new Assembunny(input) {C = 1};
            assembunny.Run();

            Result = assembunny.A.ToString();
            return Task.CompletedTask;
        }

        public override int Nummer => 201612;
    }
}
