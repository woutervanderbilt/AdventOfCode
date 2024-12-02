using Algorithms;
using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Problems.Advent._2017;

internal class Dag23 : Problem
{
    private const string input = @"set b 1000
set c b
jnz a 2
jnz 1 5
mul b 100
sub b -100000
set c b
sub c -17000
set f 1
set d 2
set e 2
set g d
mul g e
sub g b
jnz g 2
set f 0
sub e -1
set g e
sub g b
jnz g -8
sub d -1
set g d
sub g b
jnz g -13
jnz f 2
sub h -1
set g b
sub g c
jnz g 2
jnz 1 3
sub b -17
jnz 1 -23";
    public override Task ExecuteAsync()
    {
        // Hij geeft het aantal samengestelde getallen x tussen b = 79 * 100 + 100000 en c = b + 17000 met x % 17 == b % 17
        var primes = new Primes(125000);
        int ct = 0;
        for (int b = 107900; b <= 124900; b += 17)
        {
            if (!primes.IsPrime(b))
            {
                ct++;
            }
        }

        Result = ct.ToString();
        return Task.CompletedTask;


        var register = new CounterLong<string>();
        register["a"] = 0;
        IList<string> instructions = input.Split(Environment.NewLine);
        int pointer = 0;
        bool terminated = false;
        int mulCount = 0;
        while (!terminated)
        {
            Step();
        }

        Result = register["h"].ToString();

        void Step()
        {
            if (pointer < 0 || pointer >= instructions.Count)
            {
                terminated = true;
                return;
            }
            var instruction = instructions[pointer];
            pointer++;
            var words = instruction.Split(' ');
            switch (words[0])
            {
                case "set":
                    register[words[1]] = Value(words[2]);
                    break;
                case "sub":
                    if (words[1] == "h")
                    {

                    }
                    register[words[1]] -= Value(words[2]);
                    break;
                case "mul":
                    register[words[1]] *= Value(words[2]);
                    mulCount++;
                    break;
                case "jnz":
                    if (Value(words[1]) != 0)
                    {
                        pointer--;
                        pointer += (int)Value(words[2]);
                    }
                    break;
            }

            long Value(string r)
            {
                if (long.TryParse(r, out var v))
                {
                    return v;
                }

                return register[r];
            }
        }

        return Task.CompletedTask;
    }

    public override int Nummer => 201723;
}