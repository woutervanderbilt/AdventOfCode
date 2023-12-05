using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2020;

public class Dag18 : Problem
{
    #region input

    private const string input = @"2 * (8 + 3 * 3 + (4 + 5)) + 7 * 2
2 * (5 * 7 + (2 * 2 + 7) + (5 + 2 * 8 + 4 * 4) + 9) * (9 * (7 * 2) * (7 + 3 * 3 * 2 + 4) * 9 + (2 * 4 * 9) + 8) + 6 * (8 + 2 * 8)
5 * 3 * 7 * 2 * (5 * 9 + (3 * 5 * 2 + 6 + 7) + (6 + 2 + 9 * 7) + 4)
(9 + (7 * 5 + 9 + 2) * 7 * 7 * (7 * 9)) * (7 + 4 + (2 + 9 + 7 + 5 * 9) * 7) + 5 + 6 + 6 + 5
4 * 2 + 4 + 9 * (4 * 4 * 7 + 9 * 7 * (4 * 2 * 2 + 2 * 4 + 4)) * 8
6 * (6 + 6 * (2 + 2 + 6 * 9 + 4 * 3) + 4 * 4 * (3 * 2 * 8 * 2)) * 7 * 2
5 * 7 * ((7 * 2 * 2 * 2) * 5)
5 * (4 + 9) + 3
4 + (7 + 7 + 3 + 5) + (7 * 8)
8 + 9 + (9 + (6 + 2) * (6 + 9) * (6 + 5 * 2 + 7 + 3) * 8 + 9) * 8 * 3
8 + (5 + (2 + 7 + 9) + 2 * 9 * 5) + 4 + 2 + 7
(3 * 6 + 3 + 6) * 9 * 7 + 2 + 7
9 * 4 + 3 + 3 + 2 + 5
8 + (3 + 8 + 6 + 2) * (9 * 6 * 5) * 3 + 2 + 4
6 * ((7 * 7) * 7 + 9)
5 + 7 + (2 * 5 + (8 + 2 * 5 * 3 * 6)) + 8 * 8
(8 + 5) + 3 * (3 * 5 * 9 * (9 + 3)) * ((5 * 2 + 9 + 3 * 3) + 3) * 9
5 + 4 + 5 + 3 * (5 + 9)
9 + 5 + 5 + 3 * (3 + 5 + 7 * 5 * (4 + 3 + 6)) + 2
2 * ((3 * 7 + 9 + 3 + 6) + 7) * 5 + (7 + 9) * ((8 + 6) + 9 + (8 + 7 * 3 + 2)) + 6
9 + 7
6 * (9 * (6 * 4 * 9 * 4 * 2) + 9 * 5)
3 + 5 + 2 + (6 + 6 * 2 + 7 * 3) * 7 * 6
8 + 3 + 8 * (7 + 4 * 8 + 6 * (6 + 8 * 4 * 7 * 9))
6 * 6 * (3 * 5 * 8 * 6 + 3 * (7 + 6 * 3 + 5)) * 7 + 2 * (4 + (4 + 2 * 6 * 4 * 4 * 8) + 6)
(5 * 7 * (9 * 3 + 2 * 6)) + 5 * 5
3 + 4 * 7 + 8 + 4
2 + 9 + 8 + 8 + (3 + (6 + 7 + 5 * 5 + 9 * 3) * 2 * (8 + 3 * 9 + 6 * 2) * (7 * 8) + 9) + (8 * (5 + 6 * 4 * 6 * 5) + 2 + (4 * 5 + 9))
(9 * 8) + 7 + ((3 + 9 + 5 + 3 * 2) * 4 + (7 * 8 + 5 + 8) * 3 + 6 + 6)
4 * 6 * 7 * 2
(6 * 6 + 7 + 3 + (2 * 3 * 8 + 6 + 4) + 2) * 6 * 4 + 4
((7 + 4) * (9 * 4) * 2 * 3) + (3 * 2 + 4 * (2 + 7 * 9 + 7 * 6) + 6 + 9) * (8 + 9 * 5 + 8 * 3) * 5 * 8
(3 + 7 * 9 + 3 * 7 * 8) * 4 * 4
4 * ((3 + 4) + 5 + 9 + 9 * (7 + 8 * 7)) * (5 + 2 * 6 + 7 * 3) + 9
5 + 8 * 5 + 4 * ((4 * 6) * 5 * 5) + 6
4 + (4 + 8 * 6 + 3 * (7 * 8 * 6 + 6) * 6) + (3 + 9 + (3 + 8) * (3 * 6 * 2 + 6 * 7) + 7) + 4 + 2
3 * 8 + (6 * (6 + 6 * 3 * 8 + 5 + 2) * (3 + 4 + 4 + 3 * 4) * 9 * (7 + 3 * 3 + 5)) + (2 + (7 * 6) + 2 * 3 * 4 * 8)
2 * 3 + ((9 * 3 * 7 * 5 * 5) * (3 + 5 + 9 + 6 + 5 + 2) * 6 + 6) + 5
((3 + 8 * 6 * 5) * 7 * 4 + 5 + 2 * (6 * 8 * 5 + 5 * 8)) + (7 + 7 + 9 * 3 * 4 * (6 + 7))
2 + (8 + 9) + (9 + 6 + (2 + 5 * 3) * 9) + 6
8 + (8 * 2) + 3 + 3 + 7 * 8
8 + ((3 * 7 * 7 * 3 + 2) + 6 + 5 * 4) + 2 * 4
(4 + 5) * (8 * 6 * (3 + 6) * (7 + 5 * 5 + 7 * 7 * 7) + 8) * 8
8 * 3 * 9 + (9 + 9 + 9) * 3 * 7
(9 * 7 * 8 + 8 * 9) * 4 + 9
7 * (7 * 9 * 9 + (6 + 4 + 3 * 9)) * 8 + 8 + 2
6 * 7 + 7 * (4 * (2 * 8 * 8) * 5) + 6 + ((7 * 7 * 7 + 6 + 4 + 5) + (2 + 4 + 5 * 7 * 6) + 3)
(5 + (7 + 7 + 8) * 2 + (7 + 6 + 6 + 3 + 9 + 7) * 4) + 2 * 8 * 2 + 4
(3 * (5 * 3 + 2 + 9 + 8 * 4) + 4 + (3 + 2 * 7 * 8 + 9 * 7)) + 9 + 9 * 4 + 2 * (7 + (5 + 7 * 4) * (9 * 2 * 4 * 9 + 3) + 8 * 7 * 3)
(5 * 2) + (3 * 6) + 5 + 2 + (9 * (9 + 6 + 8 + 5 + 4 + 9) * 2 * 7 * 4 + (3 + 4 * 7))
5 + (8 + 9 + (9 + 7 * 4 * 4) * (7 * 2 + 2))
((8 * 5) * 4 + 5 * 4 * 4 * 2) * 8
6 * (3 + (3 * 3 * 6) * (3 + 7 * 2) * 7) + 6 * 9
3 * 2 * 4 + (6 + 9 * 4 + 7 + (4 * 5) + 6) + (7 + (6 + 5 + 4) + 6 * 9 + (6 + 9 * 5 + 6) * 3) + 5
(3 * 4 * 2 + 2) * (2 + 5 * 4 * 9) * 6 * (2 + 5 * 9 * 6 + 9 * 4) + (4 + 4 * 8 + 8) * 6
7 + (4 * (8 + 2)) * 3 + (4 + 3) + 8 * 2
2 + 6 + 8 + (4 * (6 + 7) + 6 * 5 * 8) + 9
(4 * 9 + 3 * (2 + 4 * 2 * 8) + 3) * (3 * 9) + 7 * 3
4 + 7 + (8 * 5)
3 * 7 * 7 + 4
7 + 5 + (8 + 3 * 7 * 3 * 4 * 8) + 4 * 3 * 2
(9 + 8 * (2 * 8)) * ((8 + 4 * 5 * 3 * 6) + (8 * 7) + 6 * 2)
(3 * (6 + 2 * 2 + 6 + 2 * 8)) * (9 + 2 + 6 * 6 + 3)
(7 + 8 + 7 + 7) + 9 + 2 + 3 + 8 * (7 + (8 + 2) + 2 * 8 * (2 + 8 + 8 + 8 * 8 * 5) + 7)
2 * (2 + 3 * 9 + 8 + 7 + (4 * 4 * 2)) * (7 * 6 * 7 * 6 + 4 * 4) * (3 * 6 * 5 * 8) + 2 + 7
9 + (9 + 5 * (2 + 9 * 7) * 2) * 8 * 9
4 + 7 * 5 + 3 + 9 + (8 * 3 + 9 + 5 + 2 + 7)
(2 * 6 + 2 * 3 + 4) + 6
7 + (9 * 2 + 4)
(4 + 6 + 3 * 2 * 9) * 8 * 6 * 5
(5 * 7 * (3 * 6 * 4)) * (7 + (4 + 9)) + 7 * 2 + 8
4 + ((6 + 4) * 6 * (2 + 3 + 5 + 7 * 6) * 2) + 6 + (3 * 9) * 6
((6 + 4 + 9 * 6 + 8 * 2) + (4 * 4 * 2 * 9 + 3 + 3) * 7 * 2 + 6) + (2 * 9) + 6 * 6 * 8
(9 * 7 * 2 * 3 * 3) + (4 * 5 * 5 * 4 + 9 * 3) + ((3 * 2 + 8 * 5) * 8) + 4 * 7
4 + 7 + 9 * 7 * (9 * (4 * 8 + 8 * 9 * 5) + (6 * 2 + 6 + 2 + 4) + 8 * 6 + 9)
9 + 6 * 6 * ((2 * 3 * 5) * 5 + (6 + 4 * 4 * 8 * 3 * 6)) + 8 * 9
9 * ((6 * 9 * 5 * 6) * (3 + 5 * 4 + 3 * 3) * 8 * 3) + (9 * 7 + 6 + (2 + 8 + 6 * 2 + 5 * 8) + 9 * 3) + 2 * 5
3 + 4 * 4
(4 * 6 + (6 + 9) * 3) + 8 * (3 * 6 + 8 + 3) * 7
4 * 3 + 3 + 8 + (2 * 9 * 4)
8 + 6 * ((2 + 2 * 6 + 9 * 8) + 9)
9 + (7 + (8 + 3 + 2 + 2 * 6) + 7 * 3 * 5 + (4 * 7)) * 9 + (8 + (3 * 6 + 8) * 7) + (7 * 9 * 2)
7 + 5 * 7 + 8 + (9 * 8 * 4 + 2)
3 + 6 + (2 * 9) * 7 * 6 + 7
((4 + 5 * 4 * 8 + 4) + (8 + 2) * 5) * 7 * 7 + 7 + 9
(4 + 8 + 6 + 9) * 4
(3 + 3) + 8
3 + (3 * 8 + (4 + 2 * 4) * 5 + 7)
2 * 3 * 3 + 9
7 * 6 + 9 * (5 + 4 + 2 * (5 + 5) + 5 * 8)
2 + 5 * 6 * (2 * 8 + 7 + 3) + 7
(4 + 4 + (5 * 5 * 7) * 6) + 2 * 9 + 3 + 3 + 6
5 + (7 * 6 + (3 + 9 * 5 + 2) * 9 * (7 * 9 + 8 + 9)) + 5
5 * 5 * (8 + 9 + (2 + 5 * 3 + 5 + 8)) * 4
3 * 9 * (8 * 6 + 8 + 8 * 4) * ((2 + 2) * 2 + 8 + 5)
(2 + 8 * (6 * 5 * 4 * 8 + 8 * 2)) + 2 * 2 * 6 + 7
(2 + 6) * 4 + 2 * 4 * 7 * 7
((9 + 6 + 2 * 3 * 4 + 6) * 2) + 5 + 3
2 * (8 * 6 + 8 + 9 * 5) + (5 + 5 * 7 + 4 * 7)
((3 + 7 + 6 + 5) * (7 * 5 * 6 + 9) * (8 * 5 * 4 * 5) * 9 * 3) + ((9 * 7 * 5 + 8) * 6 + 7 + 6) + 5 + 6 * 6
6 * (7 * 6 * 2 * (8 * 8)) * 4
((5 * 9 * 6 * 8 + 9) + 4 + (5 * 4 + 2 * 7 + 4 * 9) + 4) * 6 * 6 + 5 + 3 * 2
5 + (7 * 7 * (9 * 8)) + (8 + 6 + (3 + 5 + 7 + 6) + (7 * 6 + 2) + 8 + 2)
8 + 2 + (9 + (4 * 5 * 4 * 9 * 8)) * 7 * (8 * 9 + (2 * 7 * 4 * 7 * 3 * 4) + (4 * 8 * 4) + 3)
(4 + (9 + 7)) * (8 + 4 * 9 * 7 * 6) * (6 * 9)
4 * 8 * (6 * 3 * 8 + 8) * 8
6 * 9 + 8 + 6 * 3 + 7
4 + (7 * 5 + 8 * 2) * 2 * 6 + 3
(9 + 8) * 7 * (9 * (2 * 7 * 6 + 4 * 4) + (9 * 5) * 2 * 5 + 8) * (2 + 2 * 2)
8 + (5 * (7 + 6) * 3 + 7 + (2 + 7 + 9 + 4 * 6)) + 7 + 8 + 4
8 + 5 * ((5 + 3 + 7 + 3 * 7 + 7) * 4)
6 + (4 * 6 + 5 * 4 * 3 * 2) + 6
(4 + (4 + 8) + 9 + 6 + (7 + 2) + (7 * 5 + 5 + 2 + 9 + 5)) + ((7 * 6 + 8 * 2 * 2 * 3) + 4 * 7 + 3 * 4 * 4) + 2
2 * 4 * 7 + (2 + 9 + (7 + 9 + 7 * 5) * 9 + 9) * 8 * (3 + 8)
3 * (8 + 5 + (6 + 2 * 3 + 7)) * (7 * 5 * 5) * 3
9 + ((9 * 7 + 7 * 3 + 9) * 4) * ((6 * 8 + 9 + 6 * 6 + 6) + 8 * (2 * 9 + 7 * 9))
(4 + 6) * 2 + 2
9 + 5 * (2 * 7) + 7 * 8
(2 + 7 * 4) * 4 + 5 * 5
8 + (3 * 3 * 9 * 5) * 4 + 2
2 * (3 + 3) + (8 + 6 + 8 + 7 * 6 + 4) * 3
9 * (2 * 3 + 2) + 3 * 9 + 5 * 5
8 + 3 + 7 + (3 * 5)
3 + (3 + 9 * 9 * 5 + 3 * 8)
5 + (6 * 4 * 8 + 8 + 5 + 4) * 8 + 6 * (6 * 4 * 9)
(4 + 3 * 2 + 4 * 9 + 8) + 4
(4 + 4 + 3 + 8 + 6) + 7 + (3 * 7 * 6) + 7 * 9 * 6
5 + 5 + 6 * (3 + 9 * (2 + 5 * 2 + 3) * 4 * (5 * 7))
((8 * 6 * 3) * 5 + (9 * 5 * 8 * 9 + 5) + 8 + 3) * 3 + 3
7 + 4 * (7 * 6 * 3 * (6 * 6 + 8) * 5 * 8)
6 + ((8 + 6 + 2 * 6) * (2 + 4 + 7 * 4 + 5) * 5 * (7 + 5 * 3)) * ((2 * 6 * 7) * 2)
((7 * 3 * 2 + 2 + 7) * (8 * 4 + 4 + 3 * 5) + (5 * 4 + 3 + 3) + 9 * 5 * (4 + 9 * 3 * 7 + 2 * 6)) * 5 * 9 + 3 * (4 * 5)
2 + 7 * (6 * (9 + 4 + 7 * 7) * 8) + 3 * 8 * 7
(8 + (6 + 8 * 9 + 8) * (7 * 8)) + 9
(3 + 8 * 4 + (8 + 7 + 5 * 9 + 9) + 7 + 3) + 7 * (4 + (7 * 7))
8 + 2 + 7 * (8 * 4 + 4 * (3 * 8 + 3 * 4 * 9 + 2) + 4) * 7 * 6
(9 + 2 + 5 + 4 + 3 + 8) * 2 + 5 * 6 + ((6 * 9 * 6 * 7) * 5 + 6 + 5 * 3 * 4)
3 + (4 + 7 + 4 * 6 + 9) * 9 + 5 + 4
(2 + 2 + 3 + 4) * 4 * 9 + ((2 + 2 * 6 + 5) + (6 * 8 + 7 + 6 * 3 * 6) + 2 + 5 * (9 * 2 + 6 + 9 * 2 + 3) + 3)
5 + (7 + 6 * (3 + 4 * 7 * 9 * 5 * 5)) * 5 + 4 + 6
3 + (4 * (2 + 8 * 9) + 8 * 3) * 9 * 5 + 5 + ((5 * 2 * 7 + 9 + 9 * 5) * 5 * 6 * 4 + 3)
2 * 5 + 8 * 6 + 4 * (3 + 4)
8 + 6 * 7 + (4 * 5 * 5) + (7 + 4) * (7 + 7)
7 * (3 + 8 + 3 + (2 + 8) * 8) * (6 * (3 * 9 * 6) + 7 + 9 * 3) * 7
6 + (6 * 5 * 7 + 5) + 3 * 6 * 7 + 8
(7 * 6 + 9) + 8 * 6
9 + 4 + 5 * 4 * 7 + (6 + 9 * 3 + 4 * 8)
(4 + 3 + (8 + 6 + 4) + 7) * 9 * 6
(2 + 3 * 6 * 4 * 2 + 2) * 3 + 9 + 6 * 6 + 4
((9 * 5 + 4 * 4 + 9) * 8 + 5 * 8 + 9) * 8 + ((3 + 5 + 3 * 7) + 8 * 2) * 8
7 * ((2 + 2 + 7 + 7) + 4 * 8 * 7 + 3 + 9) * 2 + 2 * 8
((7 * 2 * 3 + 3 * 3 * 5) * 3 + (7 * 6 * 9 * 8 * 2 * 2) * 8 * 3) * 6 * 6 * 8
8 * 6 * (6 * 6 * 2 + (8 * 2) * 3) * 5 + (9 * 5 + (8 * 8 * 9))
7 + ((2 * 7 * 4 * 3 * 7 + 8) + 8 + 5 + (4 * 8 * 3 * 3) + 7) + (5 + 6 * 7 * 3 + (2 + 6)) + 2 + 7
(7 * (6 * 5 * 8 * 4 + 8) * 4 * 6) * 2 * (4 * 9 * 5) + 4 * 6 * 7
8 * (7 * 6 * 9 * 2 * 6 + 7) + (9 + 4 * 9 + 7 + 5 * 5) * ((5 * 5 + 2) + 6 * (5 + 5 + 6 + 3 * 2 + 3) + 6 * 4) * 9
2 + 8 * 9 * 6
5 + 9 * (6 * 8 * (9 * 3) * 2 + 4 * 3)
6 * 9 + 7 + 3 * ((8 * 9 + 9) + 4)
(3 * 5 + 7 * 2) * 2 + 7 * (4 * (3 + 9 + 5 * 3 * 9) + 8 * 9 + (7 + 8 + 5 + 7 + 7 + 6) * 6) * 7 * ((4 * 6 * 4 + 4) + 8 * 9)
7 + 7 * (4 * 6 + 4 + 2 + 9) * (2 * 3 + 7 + 2)
((3 + 4 * 3 * 8 * 6) + 4 + 6 * 4) * 5 * ((4 * 4 + 8 * 8) * 9 * 8 + 5)
5 + 4 * (3 * (7 + 7) + (5 * 7 + 9 + 6 * 3) * 8 * 8 * (9 * 6 + 6)) + 4 + 5 + 9
6 * 2 * (3 + 3 + 6) * 4 + 3 + 6
7 * (9 * 7) + 4 + 4 * (9 + 8 + (4 * 5 * 2 + 6 * 8 * 6) + 7 * (8 * 8 + 6 + 7)) * (8 * (2 * 5 * 7 * 5 + 8))
8 + (9 + 2 + 4 + 6) + ((7 * 8 * 4 * 8 + 8) + 2) + (5 * 7 + 4 + 8 + 5 * 2)
(7 * 7 + 8 + (8 + 9 + 9 * 8 * 9 * 8)) * 9 + 2 + 7 + 6
(7 * 3 * (6 + 5 + 3 * 7 * 4) + 8 * (3 + 4) + 5) * 3 + 3 + 9 + (4 * 7 + 6 * 9 * 4 * (3 * 6 * 8 * 7 + 7 * 5))
(5 + (2 + 5 + 5 * 3 * 3)) + (5 + 7 + 8) * (8 + 9 + 3 * 9)
8 + 7 + (5 * (2 + 8 * 4 + 7 + 3) + 7 * (9 + 5 + 5))
2 * 4 + (7 + 5 + 5 * 8 * 3) * 6
3 + 9 + 7 * 5 * (8 + 4 + 3 * (9 + 2 * 8 * 7 + 9)) + 8
2 * 3 + (8 + 2 * 9 * 9 + 7)
((9 + 5 + 4) * 7 + 3) * 8
7 * 6 * (6 + 3 * 5 + (2 * 9) + 9) + 3 * 7
2 + 7 * 9
(4 + 7 * (6 * 3) * 9) * ((6 + 6 + 8 + 8 + 3) + 4 + 5) + 9
(5 * 7 * 2 + 6 + 6) * 3 + (9 + 2) * 6
4 + 3 * ((6 * 2 + 5 * 2) * (5 + 7 * 5 + 9) + 3) + 6 + 3 * 8
(9 + 2 * 2) * 6 + (6 * (4 + 7 * 7 * 9 * 2 * 3) + 3 + 5 + 9 * (6 * 7 * 2))
(6 * 4) * 4 + 2 + 9
(5 * 8 + 3 * (3 * 6 + 7 + 7 * 8)) * (9 + 6 * 9 * 7 * (8 * 6 + 5 + 8) + 2) * 2 + (3 + 5 * 4) * 5 * 9
6 + 2 + 7 + (6 * (3 * 2))
6 * (3 + (3 + 5 * 8 + 3 * 4) * 6 * (4 * 8 * 2 * 3 * 7)) * 2
7 + 5 + ((9 + 6 + 7) + 2 + 8 * 8) * 5
5 * 6
7 * 8 + ((8 * 6 * 5 + 9 * 8) + 6 * 3 * 8) * 4
(9 * 8 + 3 + 6 * (2 * 4 + 9 + 6 * 7) + 6) + 4 + 3 + 3 + (8 + 8 * 8) * 8
5 * 7 + (6 * 3 * (9 * 5) * 6 + 4)
6 * 2 * 3 * 4 * 6 + (3 * 8 * (8 * 9))
5 + 7 + 3
5 + 2 * 5 + 2 + 6 * (3 + (3 + 6 + 6 + 5 + 3 * 9) * (9 * 3 * 3 * 9 * 6) + 7 * 9 * 7)
9 + 8 + (5 + 9 * 3) * (8 + (3 + 3 * 7 + 9 + 5) * 5) + 5 * 3
5 * 5 + (7 * 6 + 6 * 8 + (3 * 2 + 6 * 6) + 7) * 9 * 9
8 + 3 + 4 + (6 * 4 + 7 * 9 * (2 * 4 + 5 + 8) * 5) * (7 * 9) + 3
(2 * 4 * 6 * 2 + (7 + 9 * 2 * 8) * 9) + 4 + 9 * (9 * 9 + 7 * 6 + 5 * 7)
(5 + 3 * 9 * 3 * 6) + 6 * 6 + 3 * 2 + (6 + 3)
9 * (7 * 6 + 4 + 8 * 5 + 6) * 7 + 3 + (5 * 7)
6 * (7 + 3 * 2 * 8)
7 * (7 + 8 + (7 + 6 * 4 + 7) * 2 * 9) * 9 + 9 + 2 + 9
8 + (6 + 5 * 8 * 3 + 5 + 9) * (6 + 3 * 8 * 4 * 8 + 9)
(3 * (3 + 9 + 6) + (9 + 7 * 5 + 2 + 7 * 8) * (6 + 6 * 7)) + 5 * 2 * 4
3 + 7 + 6 * ((4 * 9) * 2) * 5 + 9
5 * (2 + (5 * 6 + 7 + 9)) + ((2 * 6 + 5 * 6 + 3) + (8 * 4)) * 8
(2 + 9 + 6) * 3 + 9 * 9 + 2 * 6
(4 * 3) * (3 * 8 + 3) * 2 + 6 + 6
(5 + 4) + (6 * (8 + 5 + 7 + 9) * (5 + 6 * 3) + (5 + 2 + 7 * 6))
9 + (2 + (5 + 2 + 6 + 4) + (7 * 4)) * (8 * 9)
6 * (6 * 2) + 5 * 8 + 8
3 + (5 * 8 + (2 * 4 + 2) * 2)
2 * 7 + (2 * 5 * 2 * 5 + 9 * (4 * 7 * 7 * 3 * 3 * 8)) + 6 + (6 * (9 * 8 * 6 + 3 * 2 * 2) + (2 * 4) * 3 + 8 + 5)
9 * 4 * (4 * (8 + 8 * 9)) + (8 * 4 * 6 * 6 * 2) + 7 + 6
(9 * 6 + 7) * ((9 * 5 + 8 + 4) + (9 * 8 + 2 + 3) * 7)
(8 * 9 + 7) * (7 * 4 + 6 * 2) + 7 * 4 * 9 + 4
(5 * 4 * (4 + 9 + 7) + (6 + 8 * 6 + 3 * 2) + 7) * 8 * 2 + 8 + (3 * 4 * 3 * 7)
6 + 7 + ((4 * 9 * 2) + 6) + 9 + 5
9 + 7 * (5 + 6 * 2 * (7 * 4 + 2) + 2) + ((2 * 8 + 9) + 4 * 5 + 4 + (5 * 3 * 6)) * 7
4 * 6 + 8 * 4 + 8 * 2
3 * ((8 * 5 + 2 * 8) * (4 + 3 + 3) * (7 * 4 * 9 * 4 * 3) + 9)
9 * 9 * 9 * ((9 + 2) + 4 + 6 + 4 + 5)
3 * 2 * 7 + 4 * 5 * ((2 + 9 * 5) + 8 + 4 + 5 * (5 + 3 + 6 + 4 + 8 * 4) + 4)
5 + 5 + (2 * 8 + (5 * 2) * 7) + 9
((9 * 7 + 9 * 7 * 9 * 5) + 8 + 5 + 7) + 3 * 5 * 4
7 * ((5 + 8 + 6) + 9 * 9 * (6 + 9 * 8)) + 4
9 * ((6 + 9) * 5 * (2 + 8 + 2 + 3 * 9) + 5) + 5 + 5 + 4
((2 * 9 * 2 + 3 * 5) * (4 + 5 * 6)) * 9 + 4 + (3 + 8 * 4 * 8)
8 + (6 + 9 + (4 * 4 + 7 * 5 + 8) + 7 * 7) + 2 + (5 + 6 + 6)
2 + ((8 * 5 + 2 + 6 + 4 + 5) * 9 + 5 + 3 + 4)
6 + (5 + 9 + 5 * 6 + 2) * 6 + (6 * (7 * 4 * 3 + 4 * 6)) + 4
4 + (4 + 9 * 7 * (6 * 6 + 4) + (4 * 2 + 5 * 2 * 3 + 8)) * 6 * 2
4 * 6 + 3 * 6 + (9 + 5 * 3 * 7) * 6
2 + 6
8 + 7 + (6 * 8 * 8) * (7 * 3 + 9) * 7 * (2 + 3 * 3 * 7 + 7)
5 + (9 + 7 + 4) + (5 + (9 * 8 + 9 * 7 * 8) * 5) + (2 * 2) * 2
8 + 7 * 7 * 9 + ((5 * 4 + 8 + 3 + 7) + 4 + 9 * 8 * 4) * 6
(5 + 2 * 6) * 9
3 + 8 + 9 + (4 + (5 * 9 * 5 * 4 + 3) * 5) * (5 + 9 + (4 + 5))
(9 * (7 + 3 + 7 * 2 * 6) * 8) + 5 * 3 + 8 + 7 + 7
2 * 8
4 * 3 * 9 + (4 + 8) + (3 * 7) * 7
(7 + 4 * 2) * (5 * 7) + 6
2 * (9 * (5 * 6) * 6 + 7 * 3 + 9) * (4 + 3) + 6
6 * (6 * (5 * 8 * 2 + 7 * 7) + 3) * (4 + 6) + 9 + 6
5 * (9 * 4) + 5 * 7
5 * 9 + 8 * (4 + 2 * 2 * 2 * (5 + 3 * 8 * 5 + 7) + 3) + 8 * 9
5 * 8 + ((6 * 7 * 4 * 2 * 5) + 2 * (8 + 3 * 3 + 9 + 6) * 3 * 9 + 9) * 9 * 7
((4 * 7 + 7) + 5 + 7 * 6 + 4) + ((8 * 8 * 3 * 2 * 3 + 8) + 9 * 2 * 3) * 2 * 9 * 4
5 + 8 + 9 * 6 * 4
8 + 6 * 3 * 8 + 5 * 3
7 + 3 + 9 + 9 * ((7 + 3 * 9 + 6 + 9 * 6) * 6 + 2 * 7 + 5 + (9 * 2 + 4 * 2 * 9))
5 + (7 + 9 + 7) * 3 + (6 * 6) * 8 + 3
4 + (4 + (5 + 3 + 5)) * (4 * 3) + (4 + 2 * 9 + 9) + 5
6 + 3 * 8 + 9 * (2 + 9 * 7 + 5) + (2 * 9 + (7 * 4 * 9 * 2 * 5 + 8) + (3 + 6 * 7 + 5) * 9 + 5)
(4 + (9 * 8 * 6 + 2 + 2) * 4 + 3) + 5 + (6 * 6 * (9 * 3 * 4 * 2 + 6)) * 4
4 * 6 * (9 * (5 * 2) + (8 * 6 + 3 * 8)) * (7 + 4 * (2 + 7 * 9 * 2 * 7 + 4) * 8 + (3 + 7) + 2) * 8
5 + 3 + 7 + 5 + 6
((2 + 2 * 8 + 8 * 2 + 8) * 2 + 3) * 4
9 * 9
3 * (2 * 2 * 3 * 3 * 6 * 5) * 6 * 5 * 9
8 + 2 * (5 * 7 * 8 * 9 + 3 * 3)
7 + 3 + 6 * 6
5 * 4 * 4
7 * 7 * 5 * (3 + 7 + 6 + 6) * 9 * 2
(6 + (4 * 2 + 4 + 9 * 9) * 4 * 8 * 8) + 7 * 9 * (4 * 5 * 6 * 5 * 4) * (3 + 3 + 7 + 4 * 7) + 6
8 + 8 + 8 + 7 * 4
7 + (4 + 8 + 7 + (2 * 8 + 5 + 9)) + (7 * 2 * 2) * 5
2 * 3 * 8 * (4 + 4 * (5 * 3 * 6) + (3 + 8) * 6)
((7 * 4 * 4) * 8 + 8 + 9 * 5) * (9 * 2 * 9 + 4 * 5) * 5 + 7 * 8
(9 * 5 + 8 + 3 * 7) + (9 + 9 * 7 * 9) * (6 * 2 * 8)
9 + 3 + ((9 + 9 * 4 + 7 + 9 + 7) * 8 * 8 + 4) * 3 + (5 + 5 * 8 + 8 * 9)
3 * (7 * 6 * (5 * 2 * 7) + 6 * 6 + (4 * 6 + 8 * 5 * 4 + 3)) * 9
5 + 9 + ((6 * 9 + 7 * 7 * 3) + (7 + 2 + 7 + 3))
6 + 7 + 2 * ((9 * 7 * 7 * 6 * 8 + 9) + 7 * 9 * 8 + 5 * (5 * 9 + 7 * 8))
(3 * 8 + 8 + 9 + (5 + 2 * 5 * 2)) * 9 * 5 + 2 * (9 + (2 * 9 + 7 + 5))
9 + 8 * 8 + 6 * 8 + (3 + (9 * 9) * 5 * 9)
7 + 5 + (6 * 5 + 9 * 3 * 4 * 9) * 3
5 + ((5 * 5 + 5 + 2) * 5 + 3)
4 * 2 + 3 * (4 + 2 + 5 * (4 * 3 * 8 * 7) + 6) * 2 * 8
2 * 3 + (3 * 5 + (4 + 6 * 5) * 5 * 4) * 2 + 2 + 4
(6 * 6 + 5) * (5 * 3 + (6 * 2 + 8 * 2 * 9 * 2))
9 + 2 * 7 * 5 + 9 + 5
5 * (4 * 4 * 5 * 5 * (4 * 2 * 7 * 4 * 6) * 9) * 9 * 9 * 9
(2 + 4 + 8 * (4 + 8 + 2 * 9 * 5) + 3) * 5 + 8
6 * (7 * 6 + 8 * (3 * 5 * 5 + 8 * 4 * 7)) + 9 * 7 * 8
3 * 6 * 5 * (2 * 5 * 8 + 3 + 2 + 7) * 9
5 + (6 * 6 + 9) + 4 + 8
9 + ((2 + 6 + 2) + 9 * (7 * 4 + 2 + 7) + 9) + 6
6 + (2 + (9 + 9 * 5 + 9 + 8 + 3)) + 7 + (2 + (3 + 8) + 8) * 6
8 + (5 + 7 + (9 * 5 + 3 + 7 + 3) + 2 * 2 * (2 + 8))
6 * 2 * 3 * (6 + (9 * 9) + 3 + (7 * 8 + 4 * 9 * 2 + 8) * (6 * 7))
7 * (8 * (7 * 6 + 3 * 4 * 3) * 5) * (9 * 6 * 8) + 8 + 4
4 * 6 * (2 * (6 + 9) * 6) * (3 + 9 + 6 + (4 * 4 * 5)) * 9
2 + 8 + ((4 * 5 * 3 + 6 + 3) + (4 * 8 + 4 + 4) * (6 * 5 + 9 * 7) * 6) * (8 + (7 + 7 + 5 * 7))
2 * (6 + (4 * 7 + 7 + 7 + 8 * 6)) + 4 * 5
5 * (6 + 4 * 9 + (3 + 7) + (2 * 2 * 4 * 8) + 6) + 7
6 * 7 * 3 + (8 * 5) + 9
((3 + 3) * (6 * 8 * 2 * 4)) + 2
(3 * 7 + (5 * 4 * 9 * 5 + 9) * 9 * 4) + 6 + 3 * (4 + 5 + 6)
3 * (5 + 9 + 6) * 5 * 7 + 3
2 + (2 + (5 * 8) * 2)
9 + (8 * 7 + 8 * 5) * 6
5 * 5 + 2 * 3 * 9 * ((3 * 9) + (7 * 7 + 5 + 7 * 7) + (4 + 6 + 3 + 4) + 8 + 4)
4 + 6 * 6 + (5 + 9 * 4 * 5 + 4 * 2)
((8 + 5 * 2 + 7 + 4 + 8) * 5 * 8) * 7 + (3 * (4 + 6 + 4) * (9 + 5))
9 * 5 + (7 + 8 * 8 * 6 * (8 + 3 + 6)) + (3 * 8 + 8) + 8 + 9
((5 * 7 + 2 + 7) * 5 * (6 + 5 + 9)) + (2 + 7) * 5
(5 + 6 * (4 * 8 * 5 + 9 + 4)) * 7 * 6
((6 * 7 + 8 + 8 + 4 * 8) + (7 + 2 + 5 * 5)) + 3 * 6 * 4
2 + ((6 * 2 + 2) * 7 + 2 * 4 * (5 * 7 + 7 * 7)) * 4 + (2 + 8) * 7 + 2
((3 * 4 * 7 + 8 * 5) * 8 * 7 + 6) + 3
5 + ((6 * 3 + 2 + 5) * (9 + 9 + 4 * 6) * 9 + 2 * 6) * 6 * ((6 * 7 * 9 * 5 + 9) * 3)
7 + (9 * 7 * 2) * 2 * (7 + (5 + 8 + 6 + 2)) * 3 + 5
5 + (7 + 5 * 4) + (2 + 7 + 7) + 7 * 9
(2 * 2 + 9 + 7 + (7 + 7 * 7 + 9)) * 7 * 6
(6 * 3 * 9 * (9 + 8 * 9 + 5 * 6)) * (2 + 6 + 9 * 9) * 7 * 3
4 + 5 + 9 * (5 * 3 + 7 + 6 * 4)
6 + ((5 + 5 * 4 * 8 + 5) + 8 + 6) * 3
(7 * 4 * (3 * 8 * 5 * 8 * 7 * 7) * 6) * 6 + (3 * (3 * 2 + 2 * 2)) + 7 * 2 + 5
4 * 2 * 7 + (7 + 2 + (2 + 3 * 6 * 7)) * 4
8 * (9 * 8 + (9 * 7 * 2 * 8 + 8) + 7 * 2 + (5 * 8 * 9 + 5 + 2 * 8))
2 * 9 * ((5 * 2 * 5 * 2 * 9 + 3) + 7 * 2 + 8 + 7 + 3) + 9 + 3 + 5
(2 + (9 * 6) + 8 + 4 * 6 * 4) * 8 * (8 + 6 + (3 * 5 * 8 + 3 + 7)) + 5
7 + 2 + (7 + 3 + 9)
4 + 4 * 8 * 7 * 4
((3 + 2 + 9 + 3) + 4 * 9 + 2) + 4 + 4 + 3
4 + 2 * 6 * ((5 * 4) * 6 + (5 * 8 * 4 * 4) + (7 * 5 + 6 + 3) * 5) * 5
3 + 6 + (4 * 8) + 2
(5 * 6 * 6 + 3) * 3 * 8
(4 + 7 * 2 * 8 + 3) * 8 * (6 * 2) * 9 * 4 * 4
6 + 3 + 9
((2 + 8 * 7) * 6) * 9 * 7 + 6 * 4 * 3
7 * 4 + (8 + 7 * 9) + 2 + 2 * (6 + (9 * 5) * 6 + 9 + (5 + 3 * 7 + 5 * 2) + 3)
3 + 4 + 3 * (2 + 8 + 3 + 7 * 8 * (8 + 4 * 3 + 3 * 8 * 3)) + (7 + 4 + 3 * (6 * 4) + 2 + 9) * 6
2 + 6 * (2 * 6) + 4 + (2 + 7 + 8 * 7 + 5)
6 + (3 * 3 * (6 * 7)) + ((4 + 9 + 9) + (8 + 2 * 5 * 2 * 8 * 2) + 2 + 4 + 8 * (7 * 8 * 3)) + 6 + 5
3 * ((8 + 8) * 2 * (3 * 5 + 6 * 7 + 2) * 9) + 3
3 + 6 * 5 * (6 + 4 * 8 * (4 + 3 * 8 + 3 + 7 * 9) * 4 + (8 + 6 + 3 + 9 * 5 + 8)) * 4 + 2
(3 + 9 * 4 * 8 + 7) + 9 + 4 + 5 + 9
3 + 4 + ((5 + 4 * 7 + 2) + 2 + 8 + 2 * 8 * (2 + 5 * 4 + 4 + 9)) * 5 * 2
9 + (2 * 5 + 9 * 9) * 3 + (6 + 3 + 6)
6 * 4 + 7 + (8 + 9) * 3 + (8 + 5 + 3 * 8 * 8 + 4)
5 * 9 * 5 * ((6 + 8 * 7 * 3 + 2) * 9 * 6 * 8)
7 + 2 + (9 * 8 * 7 * (5 * 9 + 6 + 2 + 4 * 2) + 7 + 9) + 8 * (3 + 6)
4 * (4 + 2 + (8 * 8 + 8 + 9 + 6) * 5 + (9 + 4 + 7 + 7 + 3)) * 6 * (3 * 8 + 9 + 9 + 7) * 3
3 + 5 * 8 * (4 + 7 * 3 * 5)
5 + ((4 * 9 * 8 * 5) * (9 * 9 * 7))
3 + (2 + 3 * 4) + 7
(4 + 3 + 7) + 9 * 7 * (6 + (8 * 3 + 6 + 6 + 4 * 8) * 4 + 9 + 4 * 7) * 2
3 + (4 + 7 * 3 * 7 * 9 + 2) * (2 * 6) * 9
(6 + 6 * 9 * 6) * 3 + 3 + 6 + 7 * 8
9 * 9 + 7 * (6 * 5 + 9)
(9 * 7 * 9) + 7 * ((4 * 9 + 7 * 5) * 7 * 6 * 2 * 6 * 4) * 4 + 4
2 + ((6 + 3) + 9 + 7 * 7 * (8 + 5) * (6 + 7 + 7 * 4 + 2 + 3)) + 3
(2 + 2 * (2 * 2) * 2) + 2 * 6 * 6 + (7 * (8 + 3 + 2 * 8) * 5 + 7 * 3 * 8)
(8 * 8 * 5 * 4) * (9 * 8) + 3 * (2 + 7 * (5 * 6 * 2 + 3 * 4 + 6) + 2)
8 + 6 + (4 * 3 + 2) * 3 + 3 + (3 + 7 + (6 + 4 * 6))
(6 + (8 * 7) + 4 * 5) * 5 + 9
8 + 9 + 3 + (7 + 6 + (7 * 2 * 6 + 2 * 2) * (5 + 6 * 9) + (3 + 3) + 4) * (2 + 9 + 3 * 7 * 8 + (8 + 5 * 9 + 2)) * 9
7 * ((7 * 3 * 4) * 3 * 4) * 7 * 4 + 8 + 7
(7 + 9 + 7) * 7 + 5 + 9 * (3 + 7 * 3) * 5
(8 * 8 + 8) + 8 + 2 * (3 + (2 + 7 + 6 + 3) * 4 + 4 * 8 + 5)
((9 + 6 * 9 * 5 + 4) + (4 * 5 * 3 + 6 * 6 + 8) + (6 + 3 * 7 + 3 + 8 + 3)) * (2 + 6 * 8 + 8) + (5 * 3) * 2
3 + ((4 * 9 * 6 + 6 * 9) * 7 * 5 * 8)
3 * 3 + (2 + (8 + 9 * 4 + 2)) + 5 * 3 * (7 + 2 * 4 * 9 + 5)
4 * 4 * (2 * 9 + 3 + 4) * 4 + (5 + 4 * 6 * 6)
8 + (6 * 6 * 5) * (3 * 8 + 4 * 7 + 8) * 2
9 + 4 + (9 + 3 * 7 + 9) * 7 + 7
2 + 4 + (9 + 3 * 2 * (5 * 7) + (5 + 6 * 4))
(3 + 9 * 8 * 7 * 9) + 4 + 4 * 4 * (9 * 6 + (2 * 7 + 3 + 6 * 5 * 5) + 8 + 7) * (2 * (2 * 6) + 9 + (8 * 6 + 6 + 8))
(2 + 3 * (5 + 8 * 3) * (8 + 3) + 9 * 8) + 5";
    #endregion

    private const string testinput = @"2 * 3 + (4 * 5)
5 + (8 * 3 + 9 + 3 * 4 * 3)
5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))
((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2";
    public override Task ExecuteAsync()
    {
        long result = 0;
        foreach (var line in input.Split(Environment.NewLine))
        {
            result += Compute(line.Replace(" ",""));
        }

        Result = result.ToString();
        return Task.CompletedTask;
    }

    string TransformLine(string line)
    {
        int count = line.Count(c => c == '+');
        for (int i = 1; i <= count; i++)
        {
            int j = i;
            var index = line.TakeWhile(c => (j -= (c == '+' ? 1 : 0)) > 0).Count();
            int pCount = 0;
            for (int after = index + 1; after <= line.Length; after++)
            {
                if (line[after] == '(')
                {
                    pCount++;
                }
                else if (line[after] == ')')
                {
                    pCount--;
                }

                if (pCount == 0)
                {
                    line = line.Insert(after + 1, ")");
                    break;
                }
            }

            pCount = 0;
            for (int before = index - 1; before >= 0; before--)
            {
                if (line[before] == ')')
                {
                    pCount++;
                }
                else if (line[before] == '(')
                {
                    pCount--;
                }

                if (pCount == 0)
                {
                    line = line.Insert(before, "(");
                    break;
                }
            }
        }

        return line;
    }

    long Compute(string line)
    {
        Stack<(long,char)> stack = new Stack<(long, char)>();
        long l = -1;
        long current = 0;
        char previous = ' ';
        bool start = true;
        line = TransformLine(line);
        foreach (var c in line)
        {
            if(long.TryParse(c.ToString(), out l))
            {
                if (start)
                {
                    current = l;
                    start = false;
                }
                else
                {
                    if (previous == '*')
                    {
                        current *= l;
                    }
                    else
                    {
                        current += l;
                    }
                }
            }

            else if (c == '(')
            {
                stack.Push((current, previous));
                start = true;
                current = 0;
            }
            else if (c == ')')
            {
                var pop = stack.Pop();
                if (pop.Item2 == '*')
                {
                    current *= pop.Item1;
                }
                else if (pop.Item2 == '+')
                {
                    current += pop.Item1;
                }
                else
                {
                    current = current;
                }
            }


            previous = c;
        }

        return current;
    }

    public override int Nummer => 202018;
}