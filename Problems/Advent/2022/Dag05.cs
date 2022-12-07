using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2022
{
    internal class Dag05 : Problem
    {
        private const string input = @"[N]         [C]     [Z]            
[Q] [G]     [V]     [S]         [V]
[L] [C]     [M]     [T]     [W] [L]
[S] [H]     [L]     [C] [D] [H] [S]
[C] [V] [F] [D]     [D] [B] [Q] [F]
[Z] [T] [Z] [T] [C] [J] [G] [S] [Q]
[P] [P] [C] [W] [W] [F] [W] [J] [C]
[T] [L] [D] [G] [P] [P] [V] [N] [R]
 1   2   3   4   5   6   7   8   9 

move 6 from 2 to 1
move 4 from 6 to 3
move 1 from 6 to 5
move 8 from 3 to 8
move 13 from 8 to 2
move 2 from 7 to 6
move 10 from 1 to 6
move 3 from 2 to 8
move 5 from 4 to 2
move 15 from 6 to 5
move 1 from 1 to 4
move 2 from 7 to 3
move 2 from 4 to 2
move 12 from 5 to 1
move 4 from 8 to 9
move 15 from 1 to 3
move 10 from 9 to 7
move 1 from 5 to 1
move 1 from 4 to 8
move 3 from 7 to 6
move 8 from 2 to 6
move 1 from 9 to 8
move 5 from 2 to 3
move 1 from 4 to 1
move 16 from 3 to 1
move 2 from 2 to 7
move 13 from 1 to 6
move 1 from 2 to 4
move 2 from 2 to 9
move 1 from 4 to 7
move 2 from 8 to 2
move 2 from 2 to 9
move 1 from 6 to 8
move 2 from 3 to 8
move 2 from 1 to 9
move 1 from 3 to 9
move 1 from 3 to 2
move 5 from 5 to 1
move 2 from 9 to 3
move 1 from 2 to 3
move 2 from 1 to 3
move 3 from 3 to 2
move 1 from 5 to 7
move 2 from 7 to 6
move 2 from 8 to 3
move 1 from 8 to 9
move 6 from 3 to 4
move 3 from 9 to 6
move 8 from 6 to 4
move 1 from 2 to 3
move 1 from 2 to 6
move 1 from 2 to 9
move 1 from 3 to 9
move 5 from 9 to 5
move 7 from 7 to 4
move 14 from 4 to 6
move 1 from 5 to 3
move 5 from 1 to 9
move 4 from 5 to 4
move 1 from 1 to 7
move 1 from 3 to 8
move 1 from 8 to 4
move 4 from 9 to 7
move 6 from 6 to 5
move 10 from 4 to 6
move 1 from 9 to 6
move 1 from 4 to 3
move 1 from 3 to 6
move 1 from 4 to 2
move 35 from 6 to 3
move 1 from 2 to 3
move 4 from 5 to 8
move 2 from 5 to 4
move 3 from 8 to 2
move 2 from 4 to 8
move 26 from 3 to 8
move 3 from 2 to 9
move 6 from 3 to 5
move 3 from 5 to 7
move 3 from 7 to 4
move 3 from 4 to 5
move 1 from 9 to 5
move 6 from 5 to 1
move 2 from 8 to 6
move 11 from 8 to 5
move 9 from 5 to 4
move 1 from 9 to 7
move 2 from 7 to 9
move 3 from 1 to 4
move 1 from 5 to 7
move 8 from 6 to 1
move 5 from 7 to 9
move 7 from 9 to 2
move 3 from 2 to 9
move 3 from 7 to 1
move 4 from 9 to 8
move 2 from 5 to 6
move 2 from 2 to 8
move 2 from 6 to 9
move 13 from 8 to 1
move 1 from 2 to 8
move 3 from 3 to 5
move 1 from 9 to 8
move 3 from 5 to 4
move 1 from 9 to 3
move 1 from 2 to 3
move 4 from 8 to 2
move 3 from 2 to 4
move 19 from 1 to 2
move 8 from 1 to 8
move 1 from 4 to 3
move 1 from 4 to 1
move 7 from 2 to 1
move 1 from 3 to 1
move 2 from 3 to 1
move 15 from 4 to 5
move 1 from 1 to 7
move 11 from 2 to 8
move 2 from 2 to 9
move 1 from 3 to 5
move 2 from 9 to 4
move 12 from 8 to 3
move 16 from 5 to 1
move 3 from 4 to 3
move 1 from 7 to 5
move 2 from 8 to 6
move 1 from 5 to 4
move 1 from 4 to 9
move 18 from 1 to 9
move 8 from 3 to 8
move 9 from 8 to 2
move 4 from 9 to 2
move 8 from 1 to 2
move 2 from 6 to 4
move 17 from 2 to 1
move 1 from 4 to 5
move 3 from 2 to 6
move 1 from 2 to 9
move 2 from 6 to 1
move 3 from 3 to 6
move 1 from 4 to 6
move 2 from 3 to 2
move 16 from 9 to 5
move 14 from 5 to 4
move 3 from 5 to 8
move 1 from 2 to 4
move 4 from 8 to 6
move 1 from 2 to 8
move 1 from 3 to 9
move 1 from 3 to 9
move 2 from 9 to 1
move 10 from 8 to 7
move 7 from 6 to 9
move 16 from 1 to 5
move 7 from 4 to 3
move 1 from 8 to 4
move 5 from 4 to 2
move 1 from 5 to 9
move 5 from 9 to 1
move 5 from 1 to 2
move 2 from 9 to 7
move 1 from 1 to 7
move 1 from 6 to 8
move 4 from 4 to 5
move 1 from 6 to 9
move 9 from 2 to 1
move 11 from 5 to 6
move 2 from 9 to 2
move 4 from 3 to 4
move 4 from 4 to 6
move 1 from 3 to 4
move 11 from 7 to 4
move 9 from 4 to 7
move 11 from 7 to 2
move 2 from 3 to 5
move 2 from 4 to 8
move 7 from 5 to 2
move 1 from 8 to 3
move 1 from 5 to 1
move 1 from 3 to 7
move 6 from 2 to 9
move 1 from 8 to 9
move 6 from 9 to 2
move 15 from 6 to 2
move 1 from 7 to 2
move 31 from 2 to 7
move 22 from 7 to 3
move 2 from 5 to 1
move 3 from 7 to 4
move 1 from 4 to 9
move 3 from 4 to 3
move 1 from 8 to 6
move 1 from 9 to 6
move 15 from 1 to 5
move 1 from 9 to 5
move 1 from 1 to 8
move 2 from 6 to 8
move 1 from 8 to 4
move 1 from 4 to 6
move 1 from 6 to 9
move 10 from 3 to 1
move 1 from 9 to 7
move 2 from 7 to 8
move 10 from 5 to 1
move 12 from 1 to 4
move 1 from 3 to 8
move 11 from 4 to 8
move 1 from 8 to 3
move 5 from 5 to 8
move 1 from 5 to 8
move 6 from 8 to 6
move 3 from 2 to 1
move 1 from 6 to 2
move 5 from 1 to 6
move 3 from 1 to 4
move 3 from 2 to 8
move 1 from 2 to 9
move 8 from 3 to 5
move 2 from 1 to 3
move 3 from 7 to 5
move 2 from 3 to 5
move 3 from 5 to 2
move 1 from 7 to 9
move 2 from 9 to 1
move 1 from 6 to 9
move 2 from 4 to 8
move 5 from 6 to 5
move 1 from 6 to 7
move 1 from 9 to 8
move 3 from 6 to 5
move 7 from 8 to 9
move 5 from 9 to 1
move 2 from 4 to 8
move 11 from 5 to 9
move 3 from 2 to 3
move 2 from 5 to 8
move 4 from 3 to 7
move 11 from 9 to 5
move 3 from 7 to 5
move 1 from 3 to 5
move 8 from 1 to 4
move 5 from 3 to 9
move 15 from 5 to 4
move 8 from 4 to 1
move 12 from 8 to 1
move 4 from 5 to 8
move 12 from 4 to 5
move 3 from 7 to 2
move 11 from 5 to 7
move 8 from 8 to 7
move 7 from 9 to 8
move 2 from 5 to 7
move 4 from 7 to 8
move 9 from 8 to 4
move 11 from 4 to 5
move 6 from 7 to 8
move 9 from 8 to 7
move 18 from 7 to 5
move 1 from 8 to 1
move 4 from 1 to 5
move 1 from 7 to 2
move 6 from 1 to 9
move 1 from 2 to 4
move 1 from 4 to 3
move 3 from 1 to 7
move 1 from 4 to 2
move 3 from 2 to 5
move 2 from 9 to 5
move 1 from 2 to 6
move 4 from 7 to 8
move 1 from 6 to 2
move 1 from 2 to 4
move 4 from 8 to 5
move 3 from 9 to 7
move 1 from 9 to 5
move 1 from 4 to 3
move 2 from 3 to 8
move 2 from 7 to 4
move 28 from 5 to 8
move 1 from 8 to 9
move 1 from 9 to 3
move 6 from 5 to 6
move 5 from 5 to 2
move 1 from 3 to 4
move 1 from 7 to 4
move 1 from 5 to 6
move 16 from 8 to 3
move 7 from 1 to 8
move 4 from 4 to 9
move 1 from 2 to 4
move 3 from 2 to 3
move 6 from 6 to 8
move 10 from 3 to 8
move 1 from 2 to 7
move 1 from 6 to 7
move 11 from 8 to 5
move 2 from 7 to 8
move 1 from 1 to 9
move 5 from 9 to 5
move 4 from 3 to 2
move 1 from 4 to 2
move 1 from 3 to 8
move 3 from 8 to 2
move 19 from 8 to 7
move 6 from 7 to 6
move 4 from 5 to 2
move 9 from 7 to 5
move 1 from 7 to 1
move 5 from 6 to 9
move 1 from 7 to 4
move 1 from 6 to 7
move 1 from 4 to 7
move 1 from 1 to 2
move 2 from 7 to 3
move 6 from 5 to 9
move 9 from 9 to 1
move 17 from 5 to 4
move 2 from 3 to 1
move 13 from 4 to 7
move 3 from 3 to 5
move 7 from 1 to 4
move 1 from 5 to 8
move 2 from 5 to 2
move 6 from 7 to 3
move 1 from 5 to 7
move 1 from 9 to 1
move 2 from 3 to 2
move 1 from 9 to 3
move 9 from 7 to 3
move 10 from 3 to 5
move 8 from 4 to 2
move 1 from 4 to 1
move 13 from 2 to 4
move 5 from 4 to 3
move 1 from 5 to 9
move 1 from 7 to 2
move 6 from 4 to 2
move 4 from 1 to 8
move 3 from 4 to 6
move 9 from 8 to 9
move 17 from 2 to 3
move 2 from 8 to 6
move 1 from 4 to 3
move 2 from 6 to 3
move 2 from 1 to 3
move 13 from 3 to 4
move 8 from 9 to 8
move 7 from 4 to 6
move 3 from 5 to 6
move 5 from 8 to 2
move 9 from 6 to 1
move 7 from 2 to 4
move 2 from 6 to 9
move 1 from 1 to 5
move 18 from 3 to 8
move 5 from 1 to 3
move 1 from 6 to 1
move 9 from 4 to 7
move 11 from 8 to 7
move 5 from 7 to 5
move 2 from 4 to 5
move 1 from 6 to 2
move 13 from 7 to 8
move 1 from 4 to 9
move 1 from 9 to 6
move 4 from 1 to 5
move 1 from 7 to 6
move 9 from 5 to 7
move 8 from 5 to 6
move 10 from 7 to 2
move 1 from 5 to 7
move 1 from 7 to 1
move 17 from 8 to 2
move 9 from 6 to 7
move 6 from 7 to 1
move 2 from 7 to 2
move 1 from 4 to 2
move 12 from 2 to 8
move 7 from 1 to 2
move 6 from 8 to 6
move 3 from 8 to 2
move 1 from 7 to 2
move 2 from 3 to 4
move 1 from 4 to 9
move 2 from 3 to 5
move 2 from 3 to 7
move 1 from 4 to 6
move 2 from 7 to 1
move 7 from 2 to 7
move 6 from 7 to 1
move 1 from 5 to 2
move 6 from 8 to 4
move 4 from 9 to 7
move 1 from 5 to 2
move 3 from 8 to 1
move 1 from 9 to 4
move 1 from 7 to 8
move 1 from 8 to 1
move 4 from 7 to 8
move 1 from 4 to 2
move 3 from 6 to 9
move 2 from 9 to 7
move 1 from 9 to 3
move 2 from 4 to 3
move 2 from 8 to 3
move 5 from 3 to 4
move 4 from 6 to 2
move 8 from 2 to 9
move 1 from 6 to 5
move 10 from 2 to 3
move 2 from 8 to 3
move 8 from 9 to 3
move 9 from 2 to 5
move 1 from 2 to 4
move 1 from 2 to 3
move 7 from 5 to 6
move 1 from 5 to 7
move 13 from 3 to 4
move 2 from 7 to 8
move 5 from 3 to 1
move 1 from 5 to 3
move 1 from 8 to 5
move 1 from 2 to 8
move 1 from 7 to 9
move 1 from 4 to 2
move 15 from 4 to 8
move 6 from 4 to 7
move 6 from 7 to 8
move 1 from 6 to 5
move 1 from 4 to 6
move 1 from 9 to 6
move 2 from 5 to 2
move 6 from 6 to 4
move 6 from 1 to 8
move 6 from 4 to 9
move 2 from 6 to 1
move 1 from 2 to 9
move 26 from 8 to 1
move 4 from 3 to 7
move 2 from 2 to 5
move 16 from 1 to 4
move 3 from 9 to 8
move 3 from 8 to 7
move 3 from 5 to 1
move 2 from 9 to 2
move 1 from 9 to 7
move 1 from 9 to 1
move 8 from 4 to 1
move 4 from 4 to 9
move 1 from 2 to 3
move 1 from 3 to 7
move 2 from 8 to 2
move 3 from 4 to 2
move 1 from 4 to 7
move 9 from 7 to 5
move 1 from 9 to 8
move 2 from 9 to 8
move 5 from 5 to 7
move 1 from 9 to 5
move 6 from 2 to 6
move 1 from 8 to 2
move 5 from 6 to 5
move 1 from 7 to 4
move 3 from 8 to 9
move 3 from 9 to 7
move 1 from 6 to 4
move 2 from 4 to 1
move 2 from 5 to 8
move 1 from 2 to 9
move 2 from 8 to 9
move 3 from 9 to 3
move 8 from 7 to 3
move 4 from 5 to 8
move 1 from 3 to 9
move 3 from 5 to 8
move 1 from 5 to 3
move 6 from 8 to 6
move 3 from 3 to 9
move 5 from 3 to 2
move 5 from 6 to 4
move 14 from 1 to 5
move 8 from 5 to 6
move 2 from 3 to 2
move 4 from 9 to 1
move 1 from 8 to 7
move 7 from 2 to 3
move 6 from 3 to 7
move 3 from 5 to 3
move 1 from 3 to 9
move 12 from 1 to 5
move 1 from 9 to 7
move 2 from 3 to 1
move 1 from 7 to 8
move 1 from 8 to 7
move 2 from 3 to 6
move 2 from 1 to 9
move 2 from 5 to 6
move 2 from 9 to 7
move 9 from 7 to 3
move 7 from 1 to 5
move 5 from 5 to 2
move 8 from 6 to 8
move 5 from 8 to 9";

        public override Task ExecuteAsync()
        {
            int numberOfStacks = 
                " 0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0  "
                    .Count(c => c == '0');
            var bigInput = File.ReadAllText(@"C:\temp\aoc_2022_day05_large_input-3.txt");
            IList<IList<char>> lists = new List<IList<char>>();
            for (int i = 0; i < numberOfStacks; i++)
            {
                lists.Add(new List<char>());
            }
            foreach (var line in bigInput.Split('\n'))
            {
                int index = 0;
                if (line.Any(c => c == '0' || c == '1'))
                {
                    break;
                }
                foreach (var c in line)
                {
                    if (index % 4 == 1 && c != ' ')
                    {
                        lists[index / 4].Add(c);
                    }
                    index++;
                }
            }

            var tops = new List<(int, int)>();
            for (int i = 1; i <= numberOfStacks; i++)
            {
                tops.Add((i,0));
            }

            int linenumber = 0;
            foreach (var line in bigInput.Split('\n').Reverse().Skip(1))
            {
                linenumber++;
                if (linenumber % 50000 == 0)
                {
                    Console.WriteLine(linenumber);
                }
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }
                var words = line.Split();
                int count = int.Parse(words[1]);
                int from = int.Parse(words[3]);
                int to = int.Parse(words[5]);
                var newTops = new List<(int, int)>();
                foreach (var top in tops)
                {
                    if (top.Item1 == from)
                    {
                        newTops.Add((top.Item1, top.Item2 + count));
                    }
                    else if (top.Item1 == to)
                    {
                        if (top.Item2 + 1 <= count)
                        {
                            //newTops.Add((from, top.Item2));
                            newTops.Add((from, count - top.Item2 - 1));
                        }
                        else
                        {
                            newTops.Add((top.Item1, top.Item2 - count));
                        }
                    }
                    else
                    {
                        newTops.Add(top);
                    }
                }

                tops = newTops;
            }

            Result = "";
            foreach (var top in tops)
            {
                Result += lists[top.Item1 - 1][top.Item2];
            }
            return Task.CompletedTask;








            IList<Stack<char>> stacks = new List<Stack<char>>();
            for (int i = 0; i <= 8; i++)
            {
                stacks.Add(new Stack<char>());
            }
            bool initializing = true;
            foreach (var line in input.Split(Environment.NewLine))
            {
                if(string.IsNullOrWhiteSpace(line))
                {
                    IList<Stack<char>> newStacks = new List<Stack<char>>();
                    foreach (var stack in stacks)
                    {
                        var newStack = new Stack<char>();
                        while (stack.TryPop(out var c))
                        {
                            newStack.Push(c);
                        }
                        newStacks.Add(newStack);
                    }

                    stacks = newStacks;
                    initializing = false;
                    continue;
                }
                if (initializing)
                {
                    int index = 0;
                    foreach (var c in line)
                    {
                        if (index % 4 == 1 && c != ' ')
                        {
                            stacks[index/4].Push(c);
                        }
                        index++;
                    }
                }
                else
                {
                    var words = line.Split();
                    int count = int.Parse(words[1]);
                    int from = int.Parse(words[3]);
                    int to = int.Parse(words[5]);
                    Stack<char> move = new Stack<char>();
                    for (int i = 1; i <= count; i++)
                    {
                        var c = stacks[from - 1].Pop();
                        move.Push(c);
                    }

                    while (move.TryPop(out var c))
                    {
                        stacks[to - 1].Push(c);
                    }
                }
            }

            var sb = new StringBuilder();
            foreach (var stack in stacks)
            {
                sb.Append(stack.Peek());
            }

            Result = sb.ToString();
            return Task.CompletedTask;
        }

        public override int Nummer => 202205;
    }
}
