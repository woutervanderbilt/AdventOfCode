using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2021
{
    internal class Dag24 : Problem
    {
        private const string input = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 7
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 8
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 10
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 16
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 8
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -8
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 3
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 1
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 10
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 8
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -6
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 8
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 14
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 4
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -5
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 14
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -4
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 6
mul y x
add z y";
        public override Task ExecuteAsync()
        {
            for (int i1 = 1; i1 <= 9; i1++)
            {
                for (int i2 = 1; i2 <= 9; i2++)
                {
                    for (int i3 = 1; i3 <= 9; i3++)
                    {
                        for (int i4 = 1; i4 <= 9; i4++)
                        {
                            for (int i5 = 1; i5 <= 9; i5++)
                            {
                                for (int i6 = 1; i6 <= 9; i6++)
                                {
                                    for (int i7 = 1; i7 <= 9; i7++)
                                    {
                                        var register = new CounterLong<string>();
                                        var res = new StringBuilder();
                                        int i = 1;
                                        bool cont = true;
                                        foreach (var instruction in input.Split(Environment.NewLine))
                                        {
                                            var words = instruction.Split(' ');
                                            long b = 0;
                                            var a = words[1];
                                            if (words.Length > 2)
                                            {
                                                if (!long.TryParse(words[2], out b))
                                                {
                                                    b = register[words[2]];
                                                }
                                            }
                                            
                                            switch (words[0])
                                            {
                                                case "inp":
                                                    //Console.WriteLine($"input number {i++}");
                                                    //b = long.Parse(Console.ReadLine());
                                                    switch (i)
                                                    {
                                                        case 1:
                                                            b = i1;
                                                            break;
                                                        case 2:
                                                            b = i2;
                                                            break;
                                                        case 3:
                                                            b = i3;
                                                            break;
                                                        case 4:
                                                            b = i4;
                                                            break;
                                                        case 5:
                                                            b = register["z"] % 26 - 8;
                                                            break;
                                                        case 6:
                                                            b = i5;
                                                            break;
                                                        case 7:
                                                            b = register["z"] % 26 - 11;
                                                            break;
                                                        case 8:
                                                            b = i6;
                                                            break;
                                                        case 9:
                                                            b = register["z"] % 26 - 6;
                                                            break;
                                                        case 10:
                                                            b = register["z"] % 26 - 9;
                                                            break;
                                                        case 11:
                                                            b = i7;
                                                            break;
                                                        case 12:
                                                            b = register["z"] % 26 - 5;
                                                            break;
                                                        case 13:
                                                            b = register["z"] % 26 - 4;
                                                            break;
                                                        case 14:
                                                            b = register["z"] % 26 - 9;
                                                            break;
                                                    }
                                                    i++;
                                                    if (b > 9 || b < 1)
                                                    {
                                                        cont = false;
                                                    }
                                                    res.Append(b);
                                                    register[a] = b;
                                                    break;
                                                case "add":
                                                    register[a] += b;
                                                    break;
                                                case "mul":
                                                    register[a] *= b;
                                                    break;
                                                case "div":
                                                    register[a] /= b;
                                                    break;
                                                case "mod":
                                                    if (register[a] < 0 || b == 0)
                                                    {
                                                        throw new Exception();
                                                    }

                                                    register[a] %= b;
                                                    break;
                                                case "eql":
                                                    register[a] = register[a] == b ? 1 : 0;
                                                    break;
                                            }

                                            if (!cont)
                                            {
                                                break;
                                            }
                                            //Console.WriteLine($"{instruction} -> {(register["w"], register["x"], register["y"], register["z"])}  {register["z"] % 26} {(a == "z" ? "!!!" : "")}");
                                        }

                                        if (cont && register["z"] == 0)
                                        {
                                            Console.WriteLine(res);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            return Task.CompletedTask;
        }

        public override int Nummer => 202124;
    }
}
