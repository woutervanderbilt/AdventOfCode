using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2018;

public class Dag16 : Problem
{
    #region input
    private const string input = @"Before: [0, 1, 2, 1]
12 3 2 2
After:  [0, 1, 1, 1]

Before: [3, 3, 2, 2]
1 0 2 2
After:  [3, 3, 2, 2]

Before: [1, 1, 2, 1]
2 0 2 1
After:  [1, 0, 2, 1]

Before: [0, 1, 1, 3]
13 3 1 3
After:  [0, 1, 1, 1]

Before: [2, 3, 2, 2]
1 1 2 2
After:  [2, 3, 2, 2]

Before: [2, 0, 2, 3]
9 2 0 0
After:  [4, 0, 2, 3]

Before: [3, 1, 1, 2]
5 0 3 2
After:  [3, 1, 2, 2]

Before: [1, 1, 2, 1]
2 0 2 3
After:  [1, 1, 2, 0]

Before: [0, 3, 0, 0]
10 3 2 0
After:  [1, 3, 0, 0]

Before: [1, 1, 0, 2]
10 2 2 0
After:  [1, 1, 0, 2]

Before: [0, 2, 1, 2]
7 0 0 0
After:  [0, 2, 1, 2]

Before: [3, 0, 2, 1]
12 3 2 1
After:  [3, 1, 2, 1]

Before: [0, 3, 1, 2]
4 2 3 0
After:  [1, 3, 1, 2]

Before: [1, 1, 0, 1]
6 1 3 3
After:  [1, 1, 0, 1]

Before: [0, 1, 0, 3]
3 3 3 1
After:  [0, 3, 0, 3]

Before: [1, 1, 2, 0]
11 1 0 1
After:  [1, 1, 2, 0]

Before: [1, 1, 0, 3]
15 0 2 3
After:  [1, 1, 0, 0]

Before: [3, 1, 2, 1]
6 1 3 2
After:  [3, 1, 1, 1]

Before: [3, 3, 2, 3]
1 1 2 0
After:  [2, 3, 2, 3]

Before: [0, 1, 0, 1]
6 1 3 2
After:  [0, 1, 1, 1]

Before: [3, 3, 2, 3]
1 0 2 2
After:  [3, 3, 2, 3]

Before: [1, 2, 1, 2]
4 2 3 2
After:  [1, 2, 1, 2]

Before: [3, 2, 1, 3]
5 0 1 1
After:  [3, 2, 1, 3]

Before: [3, 2, 1, 1]
14 1 2 1
After:  [3, 0, 1, 1]

Before: [1, 1, 0, 1]
15 0 2 0
After:  [0, 1, 0, 1]

Before: [3, 2, 3, 1]
13 3 1 2
After:  [3, 2, 0, 1]

Before: [1, 3, 0, 2]
15 0 2 1
After:  [1, 0, 0, 2]

Before: [0, 3, 0, 3]
3 3 3 3
After:  [0, 3, 0, 3]

Before: [0, 3, 2, 3]
14 3 1 0
After:  [1, 3, 2, 3]

Before: [0, 1, 3, 1]
6 1 3 3
After:  [0, 1, 3, 1]

Before: [1, 2, 2, 1]
2 0 2 0
After:  [0, 2, 2, 1]

Before: [1, 1, 0, 2]
11 1 0 1
After:  [1, 1, 0, 2]

Before: [0, 1, 2, 1]
0 1 2 1
After:  [0, 0, 2, 1]

Before: [1, 2, 2, 1]
3 2 2 2
After:  [1, 2, 2, 1]

Before: [1, 1, 0, 1]
6 1 3 2
After:  [1, 1, 1, 1]

Before: [1, 3, 2, 2]
1 1 2 0
After:  [2, 3, 2, 2]

Before: [1, 2, 3, 3]
8 1 3 3
After:  [1, 2, 3, 2]

Before: [1, 1, 3, 2]
11 1 0 3
After:  [1, 1, 3, 1]

Before: [0, 0, 0, 2]
7 0 0 1
After:  [0, 0, 0, 2]

Before: [1, 1, 1, 2]
11 1 0 0
After:  [1, 1, 1, 2]

Before: [2, 0, 0, 3]
8 0 3 2
After:  [2, 0, 2, 3]

Before: [1, 3, 2, 1]
12 3 2 2
After:  [1, 3, 1, 1]

Before: [2, 3, 2, 1]
12 3 2 3
After:  [2, 3, 2, 1]

Before: [2, 1, 3, 3]
8 0 3 2
After:  [2, 1, 2, 3]

Before: [2, 0, 2, 1]
12 3 2 1
After:  [2, 1, 2, 1]

Before: [2, 3, 3, 1]
4 3 2 3
After:  [2, 3, 3, 1]

Before: [2, 0, 2, 3]
5 3 0 2
After:  [2, 0, 2, 3]

Before: [0, 3, 2, 2]
1 1 2 2
After:  [0, 3, 2, 2]

Before: [0, 2, 2, 3]
3 3 3 1
After:  [0, 3, 2, 3]

Before: [1, 2, 1, 2]
14 1 2 2
After:  [1, 2, 0, 2]

Before: [1, 0, 3, 0]
10 3 3 2
After:  [1, 0, 1, 0]

Before: [2, 3, 2, 1]
12 3 2 2
After:  [2, 3, 1, 1]

Before: [1, 3, 1, 2]
14 3 2 3
After:  [1, 3, 1, 0]

Before: [0, 1, 2, 1]
6 1 3 2
After:  [0, 1, 1, 1]

Before: [2, 1, 2, 1]
6 1 3 3
After:  [2, 1, 2, 1]

Before: [1, 2, 0, 1]
13 3 1 3
After:  [1, 2, 0, 0]

Before: [1, 1, 2, 2]
11 1 0 1
After:  [1, 1, 2, 2]

Before: [2, 2, 3, 1]
4 3 2 1
After:  [2, 1, 3, 1]

Before: [1, 0, 3, 2]
10 3 3 3
After:  [1, 0, 3, 1]

Before: [2, 2, 0, 0]
10 3 2 2
After:  [2, 2, 1, 0]

Before: [2, 1, 2, 1]
6 1 3 1
After:  [2, 1, 2, 1]

Before: [2, 1, 3, 1]
6 1 3 1
After:  [2, 1, 3, 1]

Before: [0, 3, 2, 0]
7 0 0 3
After:  [0, 3, 2, 0]

Before: [3, 3, 0, 2]
14 1 3 0
After:  [0, 3, 0, 2]

Before: [2, 2, 2, 2]
3 2 2 2
After:  [2, 2, 2, 2]

Before: [2, 2, 1, 3]
8 1 3 3
After:  [2, 2, 1, 2]

Before: [1, 0, 0, 0]
15 0 2 1
After:  [1, 0, 0, 0]

Before: [1, 1, 2, 3]
0 1 2 0
After:  [0, 1, 2, 3]

Before: [0, 1, 0, 1]
7 0 0 1
After:  [0, 0, 0, 1]

Before: [0, 1, 3, 3]
13 2 1 0
After:  [1, 1, 3, 3]

Before: [1, 1, 0, 0]
10 3 3 3
After:  [1, 1, 0, 1]

Before: [2, 1, 2, 3]
5 3 0 1
After:  [2, 2, 2, 3]

Before: [0, 1, 1, 3]
3 3 3 1
After:  [0, 3, 1, 3]

Before: [0, 2, 3, 2]
10 3 3 0
After:  [1, 2, 3, 2]

Before: [1, 1, 3, 2]
11 1 0 2
After:  [1, 1, 1, 2]

Before: [1, 0, 2, 1]
12 3 2 0
After:  [1, 0, 2, 1]

Before: [3, 3, 1, 2]
14 3 2 1
After:  [3, 0, 1, 2]

Before: [1, 1, 2, 1]
11 1 0 2
After:  [1, 1, 1, 1]

Before: [2, 1, 1, 2]
4 2 3 0
After:  [1, 1, 1, 2]

Before: [1, 2, 0, 3]
15 0 2 0
After:  [0, 2, 0, 3]

Before: [2, 1, 2, 3]
5 3 0 2
After:  [2, 1, 2, 3]

Before: [0, 0, 2, 3]
7 0 0 2
After:  [0, 0, 0, 3]

Before: [1, 2, 1, 3]
8 1 3 3
After:  [1, 2, 1, 2]

Before: [2, 2, 3, 2]
10 3 3 0
After:  [1, 2, 3, 2]

Before: [3, 3, 2, 3]
1 1 2 3
After:  [3, 3, 2, 2]

Before: [0, 3, 0, 3]
3 3 3 1
After:  [0, 3, 0, 3]

Before: [0, 1, 1, 2]
4 2 3 0
After:  [1, 1, 1, 2]

Before: [3, 1, 2, 1]
12 3 2 0
After:  [1, 1, 2, 1]

Before: [2, 3, 2, 3]
1 1 2 3
After:  [2, 3, 2, 2]

Before: [2, 1, 2, 3]
8 0 3 0
After:  [2, 1, 2, 3]

Before: [1, 3, 1, 3]
8 2 3 2
After:  [1, 3, 1, 3]

Before: [0, 0, 2, 1]
7 0 0 3
After:  [0, 0, 2, 0]

Before: [1, 1, 2, 3]
11 1 0 1
After:  [1, 1, 2, 3]

Before: [1, 1, 2, 2]
11 1 0 3
After:  [1, 1, 2, 1]

Before: [0, 0, 0, 3]
10 2 2 3
After:  [0, 0, 0, 1]

Before: [0, 1, 0, 0]
10 2 2 2
After:  [0, 1, 1, 0]

Before: [1, 1, 2, 2]
2 0 2 0
After:  [0, 1, 2, 2]

Before: [2, 1, 2, 3]
0 1 2 1
After:  [2, 0, 2, 3]

Before: [1, 3, 2, 3]
1 3 2 2
After:  [1, 3, 2, 3]

Before: [0, 1, 2, 1]
0 1 2 0
After:  [0, 1, 2, 1]

Before: [1, 0, 2, 2]
2 0 2 0
After:  [0, 0, 2, 2]

Before: [1, 1, 2, 0]
0 1 2 1
After:  [1, 0, 2, 0]

Before: [1, 1, 0, 3]
8 0 3 1
After:  [1, 1, 0, 3]

Before: [1, 3, 1, 3]
8 2 3 1
After:  [1, 1, 1, 3]

Before: [3, 2, 2, 3]
1 0 2 3
After:  [3, 2, 2, 2]

Before: [2, 1, 0, 1]
6 1 3 2
After:  [2, 1, 1, 1]

Before: [2, 3, 2, 1]
1 1 2 3
After:  [2, 3, 2, 2]

Before: [3, 0, 1, 2]
4 2 3 2
After:  [3, 0, 1, 2]

Before: [1, 1, 2, 3]
2 0 2 1
After:  [1, 0, 2, 3]

Before: [3, 2, 0, 3]
3 3 3 2
After:  [3, 2, 3, 3]

Before: [2, 3, 2, 0]
3 2 2 1
After:  [2, 2, 2, 0]

Before: [1, 1, 1, 0]
9 2 0 2
After:  [1, 1, 2, 0]

Before: [0, 1, 2, 2]
0 1 2 0
After:  [0, 1, 2, 2]

Before: [2, 1, 1, 2]
14 3 2 0
After:  [0, 1, 1, 2]

Before: [1, 2, 0, 3]
15 0 2 2
After:  [1, 2, 0, 3]

Before: [3, 2, 3, 3]
8 1 3 3
After:  [3, 2, 3, 2]

Before: [1, 2, 2, 2]
2 0 2 3
After:  [1, 2, 2, 0]

Before: [1, 1, 2, 3]
1 3 2 1
After:  [1, 2, 2, 3]

Before: [0, 1, 3, 1]
13 2 1 2
After:  [0, 1, 1, 1]

Before: [1, 2, 1, 2]
4 2 3 0
After:  [1, 2, 1, 2]

Before: [2, 2, 2, 3]
1 3 2 1
After:  [2, 2, 2, 3]

Before: [1, 2, 1, 3]
8 0 3 3
After:  [1, 2, 1, 1]

Before: [2, 3, 2, 0]
1 1 2 0
After:  [2, 3, 2, 0]

Before: [2, 0, 1, 3]
8 0 3 1
After:  [2, 2, 1, 3]

Before: [0, 3, 1, 1]
7 0 0 0
After:  [0, 3, 1, 1]

Before: [3, 2, 1, 3]
8 1 3 3
After:  [3, 2, 1, 2]

Before: [1, 1, 2, 0]
11 1 0 2
After:  [1, 1, 1, 0]

Before: [0, 0, 0, 3]
7 0 0 0
After:  [0, 0, 0, 3]

Before: [0, 1, 2, 3]
1 3 2 0
After:  [2, 1, 2, 3]

Before: [1, 2, 0, 0]
10 3 3 1
After:  [1, 1, 0, 0]

Before: [1, 3, 0, 1]
15 0 2 0
After:  [0, 3, 0, 1]

Before: [1, 1, 0, 1]
11 1 0 3
After:  [1, 1, 0, 1]

Before: [0, 0, 1, 2]
4 2 3 1
After:  [0, 1, 1, 2]

Before: [0, 1, 3, 1]
4 3 2 3
After:  [0, 1, 3, 1]

Before: [3, 1, 3, 1]
6 1 3 3
After:  [3, 1, 3, 1]

Before: [2, 1, 2, 2]
0 1 2 1
After:  [2, 0, 2, 2]

Before: [3, 2, 1, 3]
8 2 3 0
After:  [1, 2, 1, 3]

Before: [0, 3, 2, 2]
1 1 2 3
After:  [0, 3, 2, 2]

Before: [2, 3, 3, 3]
5 3 0 3
After:  [2, 3, 3, 2]

Before: [0, 3, 2, 1]
12 3 2 2
After:  [0, 3, 1, 1]

Before: [0, 2, 2, 3]
7 0 0 2
After:  [0, 2, 0, 3]

Before: [2, 0, 1, 3]
5 3 0 1
After:  [2, 2, 1, 3]

Before: [2, 2, 3, 3]
8 0 3 2
After:  [2, 2, 2, 3]

Before: [2, 0, 2, 1]
12 3 2 0
After:  [1, 0, 2, 1]

Before: [0, 2, 3, 3]
7 0 0 2
After:  [0, 2, 0, 3]

Before: [0, 1, 2, 1]
12 3 2 1
After:  [0, 1, 2, 1]

Before: [0, 2, 1, 0]
7 0 0 0
After:  [0, 2, 1, 0]

Before: [2, 1, 3, 1]
4 3 2 0
After:  [1, 1, 3, 1]

Before: [2, 3, 3, 1]
4 3 2 1
After:  [2, 1, 3, 1]

Before: [1, 1, 2, 1]
12 3 2 2
After:  [1, 1, 1, 1]

Before: [0, 3, 3, 1]
7 0 0 1
After:  [0, 0, 3, 1]

Before: [2, 1, 2, 0]
10 3 3 0
After:  [1, 1, 2, 0]

Before: [1, 0, 2, 0]
2 0 2 2
After:  [1, 0, 0, 0]

Before: [3, 1, 1, 3]
8 2 3 3
After:  [3, 1, 1, 1]

Before: [1, 1, 2, 3]
13 3 1 3
After:  [1, 1, 2, 1]

Before: [2, 1, 1, 2]
14 3 2 1
After:  [2, 0, 1, 2]

Before: [1, 2, 2, 0]
2 0 2 1
After:  [1, 0, 2, 0]

Before: [0, 1, 2, 0]
0 1 2 0
After:  [0, 1, 2, 0]

Before: [2, 0, 3, 3]
8 0 3 2
After:  [2, 0, 2, 3]

Before: [1, 1, 0, 2]
15 0 2 2
After:  [1, 1, 0, 2]

Before: [1, 1, 0, 0]
15 0 2 1
After:  [1, 0, 0, 0]

Before: [2, 0, 3, 1]
4 3 2 2
After:  [2, 0, 1, 1]

Before: [3, 0, 2, 1]
12 3 2 3
After:  [3, 0, 2, 1]

Before: [1, 3, 2, 0]
2 0 2 2
After:  [1, 3, 0, 0]

Before: [2, 1, 2, 0]
0 1 2 0
After:  [0, 1, 2, 0]

Before: [2, 2, 3, 3]
5 3 1 2
After:  [2, 2, 2, 3]

Before: [2, 2, 0, 3]
8 1 3 1
After:  [2, 2, 0, 3]

Before: [0, 2, 1, 1]
7 0 0 3
After:  [0, 2, 1, 0]

Before: [1, 3, 2, 2]
2 0 2 0
After:  [0, 3, 2, 2]

Before: [2, 1, 2, 0]
0 1 2 2
After:  [2, 1, 0, 0]

Before: [0, 0, 0, 2]
10 3 3 1
After:  [0, 1, 0, 2]

Before: [2, 3, 1, 2]
9 3 0 0
After:  [4, 3, 1, 2]

Before: [1, 2, 2, 3]
8 0 3 3
After:  [1, 2, 2, 1]

Before: [0, 2, 2, 1]
12 3 2 1
After:  [0, 1, 2, 1]

Before: [1, 3, 3, 1]
4 3 2 0
After:  [1, 3, 3, 1]

Before: [2, 0, 3, 3]
8 0 3 3
After:  [2, 0, 3, 2]

Before: [2, 1, 3, 2]
9 0 0 0
After:  [4, 1, 3, 2]

Before: [2, 2, 1, 2]
14 1 2 2
After:  [2, 2, 0, 2]

Before: [3, 3, 2, 2]
14 1 3 0
After:  [0, 3, 2, 2]

Before: [3, 0, 0, 2]
10 3 3 3
After:  [3, 0, 0, 1]

Before: [0, 2, 1, 3]
8 2 3 1
After:  [0, 1, 1, 3]

Before: [2, 3, 3, 1]
4 3 2 2
After:  [2, 3, 1, 1]

Before: [3, 1, 0, 3]
13 3 1 1
After:  [3, 1, 0, 3]

Before: [1, 0, 0, 3]
15 0 2 2
After:  [1, 0, 0, 3]

Before: [2, 1, 0, 1]
6 1 3 3
After:  [2, 1, 0, 1]

Before: [1, 3, 1, 0]
9 2 0 3
After:  [1, 3, 1, 2]

Before: [0, 3, 2, 1]
12 3 2 1
After:  [0, 1, 2, 1]

Before: [1, 1, 1, 1]
9 2 0 0
After:  [2, 1, 1, 1]

Before: [0, 2, 2, 1]
7 0 0 1
After:  [0, 0, 2, 1]

Before: [2, 0, 3, 1]
4 3 2 1
After:  [2, 1, 3, 1]

Before: [3, 2, 3, 2]
13 1 2 3
After:  [3, 2, 3, 0]

Before: [1, 1, 1, 3]
3 3 3 3
After:  [1, 1, 1, 3]

Before: [0, 2, 3, 1]
4 3 2 3
After:  [0, 2, 3, 1]

Before: [2, 0, 1, 2]
4 2 3 3
After:  [2, 0, 1, 1]

Before: [1, 1, 2, 1]
6 1 3 3
After:  [1, 1, 2, 1]

Before: [0, 2, 2, 0]
9 1 1 3
After:  [0, 2, 2, 4]

Before: [3, 1, 2, 3]
0 1 2 2
After:  [3, 1, 0, 3]

Before: [2, 1, 3, 1]
13 2 1 1
After:  [2, 1, 3, 1]

Before: [0, 1, 0, 0]
10 3 2 0
After:  [1, 1, 0, 0]

Before: [1, 1, 3, 1]
11 1 0 1
After:  [1, 1, 3, 1]

Before: [2, 3, 1, 3]
14 3 1 1
After:  [2, 1, 1, 3]

Before: [0, 2, 2, 1]
9 2 1 0
After:  [4, 2, 2, 1]

Before: [0, 1, 3, 3]
13 3 1 1
After:  [0, 1, 3, 3]

Before: [1, 0, 2, 1]
12 3 2 2
After:  [1, 0, 1, 1]

Before: [1, 0, 0, 1]
15 0 2 0
After:  [0, 0, 0, 1]

Before: [3, 1, 2, 3]
0 1 2 1
After:  [3, 0, 2, 3]

Before: [1, 1, 2, 2]
2 0 2 3
After:  [1, 1, 2, 0]

Before: [3, 3, 0, 3]
14 3 1 0
After:  [1, 3, 0, 3]

Before: [0, 1, 0, 2]
7 0 0 0
After:  [0, 1, 0, 2]

Before: [0, 3, 1, 3]
14 3 1 1
After:  [0, 1, 1, 3]

Before: [3, 0, 1, 2]
5 0 3 1
After:  [3, 2, 1, 2]

Before: [2, 2, 1, 1]
13 2 1 0
After:  [0, 2, 1, 1]

Before: [3, 1, 2, 1]
0 1 2 2
After:  [3, 1, 0, 1]

Before: [0, 1, 3, 2]
7 0 0 3
After:  [0, 1, 3, 0]

Before: [3, 1, 1, 1]
6 1 3 3
After:  [3, 1, 1, 1]

Before: [3, 2, 3, 0]
5 0 1 1
After:  [3, 2, 3, 0]

Before: [0, 3, 2, 3]
1 3 2 1
After:  [0, 2, 2, 3]

Before: [2, 1, 1, 2]
9 0 0 1
After:  [2, 4, 1, 2]

Before: [2, 2, 0, 3]
8 0 3 0
After:  [2, 2, 0, 3]

Before: [0, 1, 1, 1]
6 1 3 2
After:  [0, 1, 1, 1]

Before: [1, 3, 3, 2]
5 1 3 3
After:  [1, 3, 3, 2]

Before: [1, 1, 0, 0]
11 1 0 1
After:  [1, 1, 0, 0]

Before: [3, 3, 1, 3]
13 2 1 0
After:  [0, 3, 1, 3]

Before: [1, 0, 1, 3]
8 0 3 1
After:  [1, 1, 1, 3]

Before: [0, 1, 2, 1]
6 1 3 1
After:  [0, 1, 2, 1]

Before: [0, 0, 3, 1]
7 0 0 2
After:  [0, 0, 0, 1]

Before: [3, 1, 2, 1]
12 3 2 2
After:  [3, 1, 1, 1]

Before: [3, 0, 0, 2]
5 0 3 3
After:  [3, 0, 0, 2]

Before: [1, 3, 1, 2]
4 2 3 2
After:  [1, 3, 1, 2]

Before: [1, 1, 1, 1]
11 1 0 1
After:  [1, 1, 1, 1]

Before: [0, 3, 0, 2]
14 1 3 3
After:  [0, 3, 0, 0]

Before: [0, 3, 2, 1]
1 1 2 2
After:  [0, 3, 2, 1]

Before: [0, 2, 1, 2]
4 2 3 2
After:  [0, 2, 1, 2]

Before: [1, 1, 3, 3]
3 3 3 2
After:  [1, 1, 3, 3]

Before: [0, 2, 0, 0]
7 0 0 3
After:  [0, 2, 0, 0]

Before: [1, 1, 0, 3]
15 0 2 2
After:  [1, 1, 0, 3]

Before: [1, 1, 2, 1]
0 1 2 3
After:  [1, 1, 2, 0]

Before: [3, 0, 1, 2]
14 3 2 2
After:  [3, 0, 0, 2]

Before: [1, 3, 2, 2]
14 1 3 3
After:  [1, 3, 2, 0]

Before: [1, 1, 2, 1]
11 1 0 1
After:  [1, 1, 2, 1]

Before: [1, 1, 1, 1]
11 1 0 2
After:  [1, 1, 1, 1]

Before: [0, 0, 2, 3]
1 3 2 0
After:  [2, 0, 2, 3]

Before: [2, 3, 2, 3]
3 3 3 2
After:  [2, 3, 3, 3]

Before: [1, 0, 0, 0]
10 3 2 1
After:  [1, 1, 0, 0]

Before: [2, 2, 2, 3]
9 0 1 3
After:  [2, 2, 2, 4]

Before: [1, 0, 0, 1]
15 0 2 3
After:  [1, 0, 0, 0]

Before: [1, 0, 2, 1]
2 0 2 1
After:  [1, 0, 2, 1]

Before: [1, 3, 2, 3]
2 0 2 0
After:  [0, 3, 2, 3]

Before: [3, 2, 3, 1]
13 1 2 1
After:  [3, 0, 3, 1]

Before: [0, 1, 1, 3]
8 2 3 3
After:  [0, 1, 1, 1]

Before: [1, 3, 2, 3]
8 0 3 0
After:  [1, 3, 2, 3]

Before: [1, 3, 2, 2]
2 0 2 2
After:  [1, 3, 0, 2]

Before: [0, 0, 2, 1]
12 3 2 2
After:  [0, 0, 1, 1]

Before: [1, 3, 0, 3]
14 3 1 1
After:  [1, 1, 0, 3]

Before: [0, 0, 2, 1]
12 3 2 0
After:  [1, 0, 2, 1]

Before: [1, 2, 0, 0]
15 0 2 0
After:  [0, 2, 0, 0]

Before: [1, 1, 0, 3]
11 1 0 0
After:  [1, 1, 0, 3]

Before: [1, 1, 2, 0]
2 0 2 0
After:  [0, 1, 2, 0]

Before: [2, 2, 2, 1]
12 3 2 3
After:  [2, 2, 2, 1]

Before: [3, 1, 2, 3]
13 3 1 2
After:  [3, 1, 1, 3]

Before: [3, 1, 2, 0]
1 0 2 1
After:  [3, 2, 2, 0]

Before: [0, 2, 1, 2]
14 1 2 3
After:  [0, 2, 1, 0]

Before: [3, 3, 1, 2]
5 1 3 3
After:  [3, 3, 1, 2]

Before: [2, 2, 3, 1]
9 1 0 3
After:  [2, 2, 3, 4]

Before: [1, 3, 3, 2]
14 1 3 2
After:  [1, 3, 0, 2]

Before: [1, 1, 2, 1]
0 1 2 1
After:  [1, 0, 2, 1]

Before: [1, 3, 2, 1]
12 3 2 3
After:  [1, 3, 2, 1]

Before: [1, 1, 3, 2]
11 1 0 0
After:  [1, 1, 3, 2]

Before: [2, 1, 0, 3]
3 3 3 2
After:  [2, 1, 3, 3]

Before: [1, 0, 3, 3]
3 3 3 0
After:  [3, 0, 3, 3]

Before: [1, 2, 2, 3]
1 3 2 3
After:  [1, 2, 2, 2]

Before: [0, 1, 2, 1]
0 1 2 2
After:  [0, 1, 0, 1]

Before: [3, 1, 1, 2]
5 0 3 1
After:  [3, 2, 1, 2]

Before: [3, 2, 2, 1]
12 3 2 2
After:  [3, 2, 1, 1]

Before: [1, 1, 1, 0]
11 1 0 2
After:  [1, 1, 1, 0]

Before: [2, 3, 2, 3]
8 0 3 3
After:  [2, 3, 2, 2]

Before: [1, 3, 2, 1]
2 0 2 1
After:  [1, 0, 2, 1]

Before: [2, 1, 2, 1]
12 3 2 0
After:  [1, 1, 2, 1]

Before: [3, 0, 2, 3]
1 3 2 2
After:  [3, 0, 2, 3]

Before: [3, 2, 0, 3]
5 0 1 0
After:  [2, 2, 0, 3]

Before: [1, 1, 2, 2]
9 3 3 3
After:  [1, 1, 2, 4]

Before: [1, 1, 0, 1]
11 1 0 0
After:  [1, 1, 0, 1]

Before: [1, 2, 3, 0]
13 1 2 0
After:  [0, 2, 3, 0]

Before: [3, 2, 0, 1]
10 2 2 3
After:  [3, 2, 0, 1]

Before: [3, 3, 2, 1]
12 3 2 2
After:  [3, 3, 1, 1]

Before: [1, 3, 2, 1]
2 0 2 0
After:  [0, 3, 2, 1]

Before: [1, 2, 2, 3]
8 1 3 3
After:  [1, 2, 2, 2]

Before: [2, 1, 2, 3]
8 0 3 2
After:  [2, 1, 2, 3]

Before: [2, 2, 2, 3]
1 3 2 2
After:  [2, 2, 2, 3]

Before: [1, 1, 1, 0]
11 1 0 3
After:  [1, 1, 1, 1]

Before: [2, 2, 0, 3]
5 3 1 2
After:  [2, 2, 2, 3]

Before: [3, 3, 3, 3]
14 3 1 2
After:  [3, 3, 1, 3]

Before: [3, 2, 2, 0]
3 2 2 1
After:  [3, 2, 2, 0]

Before: [1, 3, 1, 3]
3 3 3 3
After:  [1, 3, 1, 3]

Before: [0, 1, 2, 3]
0 1 2 0
After:  [0, 1, 2, 3]

Before: [1, 0, 3, 1]
4 3 2 3
After:  [1, 0, 3, 1]

Before: [1, 3, 3, 1]
4 3 2 1
After:  [1, 1, 3, 1]

Before: [3, 3, 1, 2]
14 3 2 0
After:  [0, 3, 1, 2]

Before: [3, 2, 2, 1]
1 0 2 2
After:  [3, 2, 2, 1]

Before: [2, 1, 0, 1]
6 1 3 1
After:  [2, 1, 0, 1]

Before: [2, 0, 3, 3]
3 3 3 2
After:  [2, 0, 3, 3]

Before: [3, 1, 2, 1]
12 3 2 3
After:  [3, 1, 2, 1]

Before: [0, 3, 2, 1]
12 3 2 0
After:  [1, 3, 2, 1]

Before: [1, 0, 2, 3]
2 0 2 1
After:  [1, 0, 2, 3]

Before: [2, 0, 1, 2]
4 2 3 1
After:  [2, 1, 1, 2]

Before: [2, 2, 3, 3]
9 1 1 3
After:  [2, 2, 3, 4]

Before: [0, 3, 0, 3]
14 3 1 2
After:  [0, 3, 1, 3]

Before: [3, 1, 2, 1]
0 1 2 1
After:  [3, 0, 2, 1]

Before: [0, 3, 0, 1]
7 0 0 1
After:  [0, 0, 0, 1]

Before: [0, 2, 3, 1]
4 3 2 1
After:  [0, 1, 3, 1]

Before: [1, 1, 2, 0]
11 1 0 3
After:  [1, 1, 2, 1]

Before: [1, 3, 2, 2]
1 1 2 1
After:  [1, 2, 2, 2]

Before: [1, 1, 2, 2]
11 1 0 0
After:  [1, 1, 2, 2]

Before: [0, 3, 1, 3]
13 2 1 1
After:  [0, 0, 1, 3]

Before: [2, 3, 0, 2]
5 1 0 2
After:  [2, 3, 2, 2]

Before: [2, 2, 1, 2]
13 2 1 2
After:  [2, 2, 0, 2]

Before: [1, 2, 3, 3]
8 0 3 0
After:  [1, 2, 3, 3]

Before: [1, 3, 0, 1]
15 0 2 2
After:  [1, 3, 0, 1]

Before: [1, 1, 2, 3]
11 1 0 0
After:  [1, 1, 2, 3]

Before: [2, 3, 0, 0]
5 1 0 1
After:  [2, 2, 0, 0]

Before: [1, 2, 2, 1]
12 3 2 3
After:  [1, 2, 2, 1]

Before: [0, 1, 2, 1]
6 1 3 3
After:  [0, 1, 2, 1]

Before: [1, 2, 1, 3]
3 3 3 2
After:  [1, 2, 3, 3]

Before: [1, 0, 0, 1]
15 0 2 2
After:  [1, 0, 0, 1]

Before: [0, 1, 3, 1]
6 1 3 2
After:  [0, 1, 1, 1]

Before: [3, 2, 2, 1]
12 3 2 3
After:  [3, 2, 2, 1]

Before: [1, 0, 2, 1]
12 3 2 1
After:  [1, 1, 2, 1]

Before: [1, 3, 0, 3]
15 0 2 3
After:  [1, 3, 0, 0]

Before: [2, 1, 2, 1]
12 3 2 3
After:  [2, 1, 2, 1]

Before: [2, 2, 3, 2]
9 1 3 3
After:  [2, 2, 3, 4]

Before: [2, 2, 0, 3]
5 3 0 0
After:  [2, 2, 0, 3]

Before: [3, 1, 0, 0]
10 2 2 1
After:  [3, 1, 0, 0]

Before: [1, 2, 1, 3]
8 2 3 3
After:  [1, 2, 1, 1]

Before: [1, 1, 3, 1]
6 1 3 0
After:  [1, 1, 3, 1]

Before: [0, 2, 2, 1]
12 3 2 3
After:  [0, 2, 2, 1]

Before: [1, 1, 2, 3]
2 0 2 0
After:  [0, 1, 2, 3]

Before: [2, 3, 1, 2]
4 2 3 1
After:  [2, 1, 1, 2]

Before: [1, 0, 2, 1]
12 3 2 3
After:  [1, 0, 2, 1]

Before: [1, 3, 1, 2]
14 3 2 2
After:  [1, 3, 0, 2]

Before: [3, 1, 2, 1]
6 1 3 3
After:  [3, 1, 2, 1]

Before: [3, 0, 2, 2]
9 3 3 3
After:  [3, 0, 2, 4]

Before: [0, 2, 2, 0]
3 2 2 2
After:  [0, 2, 2, 0]

Before: [1, 1, 0, 0]
11 1 0 2
After:  [1, 1, 1, 0]

Before: [1, 3, 2, 2]
14 1 3 0
After:  [0, 3, 2, 2]

Before: [1, 1, 0, 3]
8 0 3 0
After:  [1, 1, 0, 3]

Before: [2, 2, 1, 0]
14 1 2 1
After:  [2, 0, 1, 0]

Before: [3, 2, 3, 1]
4 3 2 3
After:  [3, 2, 3, 1]

Before: [0, 2, 0, 0]
10 2 2 3
After:  [0, 2, 0, 1]

Before: [2, 2, 1, 2]
4 2 3 2
After:  [2, 2, 1, 2]

Before: [1, 3, 0, 3]
15 0 2 1
After:  [1, 0, 0, 3]

Before: [1, 0, 3, 1]
4 3 2 1
After:  [1, 1, 3, 1]

Before: [1, 0, 2, 3]
8 0 3 3
After:  [1, 0, 2, 1]

Before: [3, 0, 0, 0]
10 2 2 0
After:  [1, 0, 0, 0]

Before: [1, 1, 3, 1]
6 1 3 1
After:  [1, 1, 3, 1]

Before: [0, 2, 0, 0]
10 3 3 1
After:  [0, 1, 0, 0]

Before: [2, 1, 0, 1]
6 1 3 0
After:  [1, 1, 0, 1]

Before: [0, 1, 0, 1]
6 1 3 3
After:  [0, 1, 0, 1]

Before: [0, 3, 0, 3]
7 0 0 2
After:  [0, 3, 0, 3]

Before: [1, 3, 0, 0]
15 0 2 1
After:  [1, 0, 0, 0]

Before: [2, 1, 1, 1]
6 1 3 0
After:  [1, 1, 1, 1]

Before: [1, 2, 3, 1]
4 3 2 1
After:  [1, 1, 3, 1]

Before: [1, 2, 0, 2]
9 3 3 1
After:  [1, 4, 0, 2]

Before: [1, 2, 2, 3]
2 0 2 3
After:  [1, 2, 2, 0]

Before: [0, 2, 1, 3]
8 1 3 0
After:  [2, 2, 1, 3]

Before: [3, 2, 2, 0]
1 0 2 2
After:  [3, 2, 2, 0]

Before: [0, 1, 2, 3]
0 1 2 3
After:  [0, 1, 2, 0]

Before: [2, 2, 2, 1]
12 3 2 2
After:  [2, 2, 1, 1]

Before: [1, 2, 1, 2]
9 3 1 3
After:  [1, 2, 1, 4]

Before: [1, 1, 1, 1]
11 1 0 3
After:  [1, 1, 1, 1]

Before: [1, 1, 0, 3]
15 0 2 0
After:  [0, 1, 0, 3]

Before: [0, 1, 1, 1]
6 1 3 3
After:  [0, 1, 1, 1]

Before: [2, 3, 1, 3]
3 3 3 0
After:  [3, 3, 1, 3]

Before: [3, 3, 2, 1]
12 3 2 1
After:  [3, 1, 2, 1]

Before: [3, 2, 2, 3]
5 3 1 3
After:  [3, 2, 2, 2]

Before: [1, 1, 2, 3]
0 1 2 3
After:  [1, 1, 2, 0]

Before: [0, 3, 0, 3]
14 3 1 3
After:  [0, 3, 0, 1]

Before: [3, 2, 1, 3]
9 1 1 2
After:  [3, 2, 4, 3]

Before: [2, 3, 2, 3]
1 1 2 0
After:  [2, 3, 2, 3]

Before: [0, 3, 2, 3]
7 0 0 3
After:  [0, 3, 2, 0]

Before: [0, 2, 1, 3]
8 2 3 3
After:  [0, 2, 1, 1]

Before: [0, 1, 2, 2]
3 2 2 2
After:  [0, 1, 2, 2]

Before: [3, 2, 2, 3]
8 1 3 0
After:  [2, 2, 2, 3]

Before: [0, 1, 1, 1]
6 1 3 0
After:  [1, 1, 1, 1]

Before: [2, 2, 1, 2]
9 3 0 0
After:  [4, 2, 1, 2]

Before: [0, 0, 1, 2]
4 2 3 2
After:  [0, 0, 1, 2]

Before: [1, 0, 0, 2]
15 0 2 3
After:  [1, 0, 0, 0]

Before: [2, 1, 2, 3]
0 1 2 0
After:  [0, 1, 2, 3]

Before: [2, 0, 0, 0]
10 3 2 0
After:  [1, 0, 0, 0]

Before: [0, 1, 3, 1]
6 1 3 0
After:  [1, 1, 3, 1]

Before: [2, 2, 0, 2]
9 1 3 2
After:  [2, 2, 4, 2]

Before: [1, 0, 2, 1]
2 0 2 2
After:  [1, 0, 0, 1]

Before: [3, 1, 1, 1]
6 1 3 1
After:  [3, 1, 1, 1]

Before: [1, 0, 2, 2]
2 0 2 1
After:  [1, 0, 2, 2]

Before: [3, 2, 2, 3]
1 0 2 1
After:  [3, 2, 2, 3]

Before: [0, 3, 2, 3]
1 3 2 3
After:  [0, 3, 2, 2]

Before: [1, 0, 2, 3]
1 3 2 1
After:  [1, 2, 2, 3]

Before: [2, 2, 1, 2]
4 2 3 3
After:  [2, 2, 1, 1]

Before: [1, 1, 1, 2]
14 3 2 3
After:  [1, 1, 1, 0]

Before: [2, 3, 1, 2]
4 2 3 0
After:  [1, 3, 1, 2]

Before: [2, 3, 0, 3]
9 0 0 3
After:  [2, 3, 0, 4]

Before: [2, 0, 2, 3]
3 3 3 2
After:  [2, 0, 3, 3]

Before: [1, 1, 1, 2]
4 2 3 0
After:  [1, 1, 1, 2]

Before: [3, 2, 3, 3]
5 0 1 0
After:  [2, 2, 3, 3]

Before: [1, 1, 2, 0]
11 1 0 0
After:  [1, 1, 2, 0]

Before: [3, 2, 3, 0]
13 1 2 1
After:  [3, 0, 3, 0]

Before: [1, 1, 0, 2]
15 0 2 0
After:  [0, 1, 0, 2]

Before: [1, 0, 2, 2]
2 0 2 3
After:  [1, 0, 2, 0]

Before: [1, 2, 1, 1]
13 2 1 3
After:  [1, 2, 1, 0]

Before: [3, 0, 2, 1]
1 0 2 2
After:  [3, 0, 2, 1]

Before: [2, 2, 1, 3]
8 0 3 0
After:  [2, 2, 1, 3]

Before: [2, 2, 2, 2]
9 2 1 3
After:  [2, 2, 2, 4]

Before: [0, 0, 1, 0]
7 0 0 0
After:  [0, 0, 1, 0]

Before: [2, 3, 1, 1]
9 2 3 0
After:  [2, 3, 1, 1]

Before: [1, 0, 1, 2]
4 2 3 3
After:  [1, 0, 1, 1]

Before: [3, 1, 1, 3]
13 3 1 3
After:  [3, 1, 1, 1]

Before: [3, 2, 2, 3]
3 3 3 2
After:  [3, 2, 3, 3]

Before: [2, 1, 2, 3]
0 1 2 2
After:  [2, 1, 0, 3]

Before: [1, 2, 2, 1]
2 0 2 1
After:  [1, 0, 2, 1]

Before: [0, 2, 2, 1]
12 3 2 0
After:  [1, 2, 2, 1]

Before: [3, 2, 0, 0]
5 0 1 2
After:  [3, 2, 2, 0]

Before: [0, 1, 1, 2]
4 2 3 1
After:  [0, 1, 1, 2]

Before: [3, 1, 2, 0]
3 2 2 2
After:  [3, 1, 2, 0]

Before: [1, 1, 0, 3]
15 0 2 1
After:  [1, 0, 0, 3]

Before: [0, 3, 2, 3]
1 1 2 1
After:  [0, 2, 2, 3]

Before: [1, 1, 0, 0]
10 3 3 2
After:  [1, 1, 1, 0]

Before: [1, 1, 2, 2]
2 0 2 2
After:  [1, 1, 0, 2]

Before: [1, 1, 2, 0]
0 1 2 0
After:  [0, 1, 2, 0]

Before: [3, 2, 2, 2]
5 0 3 3
After:  [3, 2, 2, 2]

Before: [3, 1, 2, 1]
0 1 2 3
After:  [3, 1, 2, 0]

Before: [2, 0, 2, 0]
3 2 2 1
After:  [2, 2, 2, 0]

Before: [0, 1, 0, 1]
6 1 3 1
After:  [0, 1, 0, 1]

Before: [3, 2, 2, 0]
10 3 3 0
After:  [1, 2, 2, 0]

Before: [1, 1, 1, 1]
6 1 3 2
After:  [1, 1, 1, 1]

Before: [3, 3, 2, 2]
1 0 2 0
After:  [2, 3, 2, 2]

Before: [1, 1, 3, 1]
11 1 0 3
After:  [1, 1, 3, 1]

Before: [0, 2, 1, 2]
7 0 0 3
After:  [0, 2, 1, 0]

Before: [1, 3, 2, 1]
12 3 2 1
After:  [1, 1, 2, 1]

Before: [1, 3, 1, 3]
8 0 3 1
After:  [1, 1, 1, 3]

Before: [2, 2, 0, 2]
9 0 3 0
After:  [4, 2, 0, 2]

Before: [1, 1, 1, 1]
11 1 0 0
After:  [1, 1, 1, 1]

Before: [0, 2, 2, 1]
12 3 2 2
After:  [0, 2, 1, 1]

Before: [1, 1, 3, 1]
13 2 1 3
After:  [1, 1, 3, 1]

Before: [3, 1, 1, 2]
9 3 3 3
After:  [3, 1, 1, 4]

Before: [0, 1, 3, 1]
7 0 0 0
After:  [0, 1, 3, 1]

Before: [1, 1, 3, 1]
6 1 3 2
After:  [1, 1, 1, 1]

Before: [1, 2, 0, 1]
15 0 2 1
After:  [1, 0, 0, 1]

Before: [1, 1, 2, 1]
12 3 2 0
After:  [1, 1, 2, 1]

Before: [1, 0, 1, 1]
9 2 0 1
After:  [1, 2, 1, 1]

Before: [2, 1, 0, 3]
8 0 3 0
After:  [2, 1, 0, 3]

Before: [3, 1, 2, 2]
0 1 2 1
After:  [3, 0, 2, 2]

Before: [1, 3, 1, 0]
13 2 1 3
After:  [1, 3, 1, 0]

Before: [2, 0, 3, 3]
3 3 3 1
After:  [2, 3, 3, 3]

Before: [1, 1, 2, 1]
11 1 0 0
After:  [1, 1, 2, 1]

Before: [0, 3, 2, 1]
12 3 2 3
After:  [0, 3, 2, 1]

Before: [3, 2, 1, 2]
4 2 3 1
After:  [3, 1, 1, 2]

Before: [1, 1, 2, 1]
6 1 3 1
After:  [1, 1, 2, 1]

Before: [3, 3, 2, 1]
12 3 2 0
After:  [1, 3, 2, 1]

Before: [1, 1, 3, 3]
11 1 0 3
After:  [1, 1, 3, 1]

Before: [2, 3, 2, 0]
1 1 2 3
After:  [2, 3, 2, 2]

Before: [3, 1, 2, 0]
0 1 2 0
After:  [0, 1, 2, 0]

Before: [2, 2, 3, 3]
13 1 2 1
After:  [2, 0, 3, 3]

Before: [0, 0, 2, 1]
12 3 2 1
After:  [0, 1, 2, 1]

Before: [1, 3, 3, 3]
8 0 3 0
After:  [1, 3, 3, 3]

Before: [2, 3, 2, 2]
3 2 2 3
After:  [2, 3, 2, 2]

Before: [3, 2, 1, 3]
5 3 1 2
After:  [3, 2, 2, 3]

Before: [0, 3, 0, 0]
10 3 3 1
After:  [0, 1, 0, 0]

Before: [2, 1, 2, 3]
1 3 2 3
After:  [2, 1, 2, 2]

Before: [1, 3, 2, 3]
8 0 3 2
After:  [1, 3, 1, 3]

Before: [2, 1, 2, 2]
9 0 0 0
After:  [4, 1, 2, 2]

Before: [3, 3, 0, 2]
5 1 3 1
After:  [3, 2, 0, 2]

Before: [3, 2, 1, 3]
8 2 3 1
After:  [3, 1, 1, 3]

Before: [2, 3, 3, 3]
9 0 0 3
After:  [2, 3, 3, 4]

Before: [3, 0, 2, 1]
12 3 2 0
After:  [1, 0, 2, 1]

Before: [2, 1, 2, 2]
0 1 2 3
After:  [2, 1, 2, 0]

Before: [2, 1, 0, 2]
10 2 2 2
After:  [2, 1, 1, 2]

Before: [2, 1, 0, 3]
5 3 0 1
After:  [2, 2, 0, 3]

Before: [1, 1, 2, 1]
12 3 2 1
After:  [1, 1, 2, 1]

Before: [2, 3, 2, 2]
1 1 2 3
After:  [2, 3, 2, 2]

Before: [0, 2, 1, 2]
13 2 1 0
After:  [0, 2, 1, 2]

Before: [1, 2, 3, 3]
8 0 3 3
After:  [1, 2, 3, 1]

Before: [1, 0, 2, 1]
2 0 2 3
After:  [1, 0, 2, 0]

Before: [1, 0, 0, 3]
15 0 2 3
After:  [1, 0, 0, 0]

Before: [1, 1, 1, 3]
11 1 0 0
After:  [1, 1, 1, 3]

Before: [3, 1, 3, 3]
13 2 1 1
After:  [3, 1, 3, 3]

Before: [3, 2, 2, 1]
12 3 2 1
After:  [3, 1, 2, 1]

Before: [3, 2, 1, 2]
5 0 3 3
After:  [3, 2, 1, 2]

Before: [2, 2, 2, 2]
9 2 1 0
After:  [4, 2, 2, 2]

Before: [0, 2, 3, 2]
9 1 3 3
After:  [0, 2, 3, 4]

Before: [3, 2, 2, 3]
1 3 2 1
After:  [3, 2, 2, 3]

Before: [0, 3, 2, 3]
1 3 2 2
After:  [0, 3, 2, 3]

Before: [1, 1, 2, 2]
11 1 0 2
After:  [1, 1, 1, 2]

Before: [3, 1, 1, 2]
4 2 3 0
After:  [1, 1, 1, 2]

Before: [1, 1, 2, 0]
0 1 2 3
After:  [1, 1, 2, 0]

Before: [0, 3, 1, 1]
13 2 1 1
After:  [0, 0, 1, 1]

Before: [2, 3, 2, 3]
1 1 2 2
After:  [2, 3, 2, 3]

Before: [3, 2, 0, 1]
5 0 1 1
After:  [3, 2, 0, 1]

Before: [2, 0, 3, 0]
10 3 3 2
After:  [2, 0, 1, 0]

Before: [0, 0, 1, 2]
14 3 2 3
After:  [0, 0, 1, 0]

Before: [1, 1, 1, 3]
11 1 0 2
After:  [1, 1, 1, 3]

Before: [0, 3, 2, 2]
5 1 3 1
After:  [0, 2, 2, 2]

Before: [1, 2, 2, 3]
8 0 3 2
After:  [1, 2, 1, 3]

Before: [0, 0, 1, 2]
4 2 3 0
After:  [1, 0, 1, 2]

Before: [0, 2, 1, 2]
4 2 3 3
After:  [0, 2, 1, 1]

Before: [0, 2, 0, 3]
3 3 3 2
After:  [0, 2, 3, 3]

Before: [1, 1, 2, 1]
0 1 2 0
After:  [0, 1, 2, 1]

Before: [1, 1, 0, 1]
15 0 2 1
After:  [1, 0, 0, 1]

Before: [1, 2, 0, 2]
15 0 2 0
After:  [0, 2, 0, 2]

Before: [1, 0, 0, 3]
15 0 2 0
After:  [0, 0, 0, 3]

Before: [0, 1, 2, 3]
1 3 2 1
After:  [0, 2, 2, 3]

Before: [1, 3, 2, 1]
12 3 2 0
After:  [1, 3, 2, 1]

Before: [3, 3, 2, 2]
5 1 3 2
After:  [3, 3, 2, 2]

Before: [1, 1, 0, 1]
6 1 3 0
After:  [1, 1, 0, 1]

Before: [3, 3, 3, 3]
3 3 3 3
After:  [3, 3, 3, 3]

Before: [1, 1, 2, 1]
0 1 2 2
After:  [1, 1, 0, 1]

Before: [3, 1, 3, 1]
6 1 3 1
After:  [3, 1, 3, 1]

Before: [3, 2, 1, 0]
13 2 1 1
After:  [3, 0, 1, 0]

Before: [0, 2, 3, 0]
7 0 0 2
After:  [0, 2, 0, 0]

Before: [3, 3, 1, 3]
8 2 3 2
After:  [3, 3, 1, 3]

Before: [2, 1, 2, 1]
6 1 3 2
After:  [2, 1, 1, 1]

Before: [1, 3, 2, 0]
2 0 2 0
After:  [0, 3, 2, 0]

Before: [0, 3, 1, 2]
10 3 3 0
After:  [1, 3, 1, 2]

Before: [1, 2, 0, 0]
15 0 2 2
After:  [1, 2, 0, 0]

Before: [1, 3, 0, 0]
15 0 2 2
After:  [1, 3, 0, 0]

Before: [2, 2, 2, 1]
12 3 2 0
After:  [1, 2, 2, 1]

Before: [1, 1, 0, 2]
11 1 0 3
After:  [1, 1, 0, 1]

Before: [2, 1, 2, 1]
0 1 2 0
After:  [0, 1, 2, 1]

Before: [3, 2, 1, 1]
9 1 1 2
After:  [3, 2, 4, 1]

Before: [1, 0, 0, 0]
15 0 2 0
After:  [0, 0, 0, 0]

Before: [2, 3, 0, 2]
5 1 3 3
After:  [2, 3, 0, 2]

Before: [1, 3, 2, 2]
1 1 2 3
After:  [1, 3, 2, 2]

Before: [2, 3, 3, 0]
5 1 0 1
After:  [2, 2, 3, 0]

Before: [1, 3, 2, 3]
2 0 2 1
After:  [1, 0, 2, 3]

Before: [1, 2, 0, 1]
15 0 2 0
After:  [0, 2, 0, 1]

Before: [3, 2, 3, 2]
13 1 2 2
After:  [3, 2, 0, 2]

Before: [3, 2, 3, 3]
13 1 2 1
After:  [3, 0, 3, 3]

Before: [3, 1, 0, 1]
6 1 3 2
After:  [3, 1, 1, 1]

Before: [1, 1, 1, 2]
11 1 0 1
After:  [1, 1, 1, 2]

Before: [1, 2, 2, 1]
12 3 2 0
After:  [1, 2, 2, 1]

Before: [2, 2, 3, 3]
9 1 0 0
After:  [4, 2, 3, 3]

Before: [0, 1, 0, 1]
6 1 3 0
After:  [1, 1, 0, 1]

Before: [1, 0, 3, 1]
4 3 2 0
After:  [1, 0, 3, 1]

Before: [0, 1, 3, 1]
6 1 3 1
After:  [0, 1, 3, 1]

Before: [3, 2, 3, 1]
13 3 1 1
After:  [3, 0, 3, 1]

Before: [1, 0, 1, 3]
8 2 3 1
After:  [1, 1, 1, 3]

Before: [2, 0, 2, 0]
10 3 3 3
After:  [2, 0, 2, 1]

Before: [3, 2, 2, 2]
5 0 3 2
After:  [3, 2, 2, 2]

Before: [1, 2, 0, 3]
15 0 2 1
After:  [1, 0, 0, 3]

Before: [0, 3, 1, 3]
8 2 3 1
After:  [0, 1, 1, 3]

Before: [0, 3, 2, 2]
5 1 3 2
After:  [0, 3, 2, 2]

Before: [1, 1, 0, 3]
11 1 0 3
After:  [1, 1, 0, 1]

Before: [1, 2, 0, 2]
15 0 2 2
After:  [1, 2, 0, 2]

Before: [1, 1, 2, 1]
6 1 3 0
After:  [1, 1, 2, 1]

Before: [1, 0, 2, 2]
3 2 2 2
After:  [1, 0, 2, 2]

Before: [2, 1, 2, 3]
8 0 3 3
After:  [2, 1, 2, 2]

Before: [1, 3, 0, 0]
15 0 2 3
After:  [1, 3, 0, 0]

Before: [2, 2, 2, 3]
1 3 2 0
After:  [2, 2, 2, 3]

Before: [3, 2, 2, 3]
1 3 2 2
After:  [3, 2, 2, 3]

Before: [3, 1, 3, 1]
4 3 2 2
After:  [3, 1, 1, 1]

Before: [1, 3, 2, 2]
2 0 2 3
After:  [1, 3, 2, 0]

Before: [1, 1, 3, 0]
11 1 0 2
After:  [1, 1, 1, 0]

Before: [2, 3, 2, 2]
5 1 0 2
After:  [2, 3, 2, 2]

Before: [1, 1, 2, 1]
12 3 2 3
After:  [1, 1, 2, 1]

Before: [0, 0, 2, 2]
7 0 0 3
After:  [0, 0, 2, 0]

Before: [3, 1, 1, 3]
13 3 1 2
After:  [3, 1, 1, 3]

Before: [1, 1, 0, 3]
11 1 0 2
After:  [1, 1, 1, 3]

Before: [3, 2, 1, 2]
5 0 3 2
After:  [3, 2, 2, 2]

Before: [0, 2, 2, 2]
10 3 3 0
After:  [1, 2, 2, 2]

Before: [3, 2, 1, 1]
14 1 2 3
After:  [3, 2, 1, 0]

Before: [1, 2, 1, 2]
13 2 1 2
After:  [1, 2, 0, 2]

Before: [0, 0, 3, 1]
4 3 2 1
After:  [0, 1, 3, 1]

Before: [2, 1, 2, 1]
0 1 2 3
After:  [2, 1, 2, 0]

Before: [3, 0, 2, 2]
3 2 2 1
After:  [3, 2, 2, 2]

Before: [1, 1, 3, 0]
11 1 0 0
After:  [1, 1, 3, 0]

Before: [2, 3, 1, 0]
13 2 1 2
After:  [2, 3, 0, 0]

Before: [2, 1, 2, 3]
1 3 2 0
After:  [2, 1, 2, 3]

Before: [1, 3, 1, 2]
4 2 3 0
After:  [1, 3, 1, 2]

Before: [0, 1, 0, 0]
7 0 0 2
After:  [0, 1, 0, 0]

Before: [3, 1, 1, 3]
3 3 3 2
After:  [3, 1, 3, 3]

Before: [1, 1, 2, 1]
2 0 2 2
After:  [1, 1, 0, 1]

Before: [1, 2, 3, 0]
10 3 3 0
After:  [1, 2, 3, 0]

Before: [0, 3, 2, 1]
1 1 2 1
After:  [0, 2, 2, 1]

Before: [0, 3, 3, 1]
7 0 0 3
After:  [0, 3, 3, 0]

Before: [1, 2, 2, 0]
3 2 2 2
After:  [1, 2, 2, 0]

Before: [1, 1, 0, 1]
11 1 0 2
After:  [1, 1, 1, 1]

Before: [2, 1, 3, 3]
13 3 1 0
After:  [1, 1, 3, 3]

Before: [3, 2, 2, 1]
5 0 1 2
After:  [3, 2, 2, 1]

Before: [2, 1, 0, 3]
5 3 0 3
After:  [2, 1, 0, 2]

Before: [1, 1, 1, 2]
4 2 3 2
After:  [1, 1, 1, 2]

Before: [2, 1, 2, 1]
12 3 2 2
After:  [2, 1, 1, 1]

Before: [3, 1, 2, 2]
9 3 3 1
After:  [3, 4, 2, 2]

Before: [1, 3, 2, 2]
9 3 3 0
After:  [4, 3, 2, 2]

Before: [1, 2, 0, 3]
5 3 1 0
After:  [2, 2, 0, 3]

Before: [1, 2, 2, 0]
2 0 2 2
After:  [1, 2, 0, 0]

Before: [3, 2, 3, 1]
13 3 1 0
After:  [0, 2, 3, 1]

Before: [0, 3, 3, 2]
14 1 3 0
After:  [0, 3, 3, 2]

Before: [0, 3, 1, 1]
9 2 3 2
After:  [0, 3, 2, 1]

Before: [2, 1, 2, 3]
5 3 0 3
After:  [2, 1, 2, 2]

Before: [2, 2, 2, 1]
12 3 2 1
After:  [2, 1, 2, 1]

Before: [2, 1, 2, 3]
0 1 2 3
After:  [2, 1, 2, 0]

Before: [0, 2, 0, 3]
8 1 3 1
After:  [0, 2, 0, 3]

Before: [1, 1, 2, 2]
2 0 2 1
After:  [1, 0, 2, 2]

Before: [2, 3, 2, 1]
1 1 2 2
After:  [2, 3, 2, 1]

Before: [0, 3, 0, 3]
3 3 3 0
After:  [3, 3, 0, 3]

Before: [1, 3, 0, 2]
15 0 2 3
After:  [1, 3, 0, 0]

Before: [3, 0, 2, 3]
1 0 2 3
After:  [3, 0, 2, 2]

Before: [0, 2, 0, 1]
7 0 0 2
After:  [0, 2, 0, 1]

Before: [1, 2, 2, 1]
2 0 2 2
After:  [1, 2, 0, 1]

Before: [0, 0, 2, 2]
7 0 0 1
After:  [0, 0, 2, 2]

Before: [3, 0, 2, 1]
12 3 2 2
After:  [3, 0, 1, 1]

Before: [2, 2, 1, 1]
13 3 1 0
After:  [0, 2, 1, 1]

Before: [3, 1, 0, 1]
6 1 3 1
After:  [3, 1, 0, 1]

Before: [3, 3, 2, 0]
1 1 2 0
After:  [2, 3, 2, 0]

Before: [2, 2, 1, 2]
9 1 1 3
After:  [2, 2, 1, 4]

Before: [3, 2, 3, 0]
5 0 1 3
After:  [3, 2, 3, 2]

Before: [1, 0, 2, 3]
2 0 2 3
After:  [1, 0, 2, 0]

Before: [1, 1, 2, 3]
0 1 2 1
After:  [1, 0, 2, 3]

Before: [2, 2, 2, 2]
9 3 3 1
After:  [2, 4, 2, 2]

Before: [1, 2, 2, 0]
2 0 2 0
After:  [0, 2, 2, 0]

Before: [1, 0, 0, 1]
10 2 2 1
After:  [1, 1, 0, 1]

Before: [1, 1, 2, 3]
11 1 0 2
After:  [1, 1, 1, 3]

Before: [2, 2, 0, 2]
9 1 3 3
After:  [2, 2, 0, 4]

Before: [2, 2, 1, 2]
4 2 3 1
After:  [2, 1, 1, 2]

Before: [1, 2, 2, 2]
3 2 2 2
After:  [1, 2, 2, 2]

Before: [2, 0, 1, 3]
8 0 3 2
After:  [2, 0, 2, 3]

Before: [3, 3, 0, 2]
10 3 3 2
After:  [3, 3, 1, 2]

Before: [1, 2, 2, 3]
2 0 2 0
After:  [0, 2, 2, 3]

Before: [0, 2, 1, 3]
14 1 2 1
After:  [0, 0, 1, 3]

Before: [3, 1, 1, 2]
4 2 3 2
After:  [3, 1, 1, 2]

Before: [2, 3, 2, 3]
14 3 1 1
After:  [2, 1, 2, 3]

Before: [1, 1, 0, 0]
11 1 0 0
After:  [1, 1, 0, 0]

Before: [2, 3, 1, 3]
8 2 3 3
After:  [2, 3, 1, 1]

Before: [3, 3, 2, 1]
12 3 2 3
After:  [3, 3, 2, 1]

Before: [0, 1, 0, 3]
7 0 0 0
After:  [0, 1, 0, 3]

Before: [3, 3, 3, 1]
4 3 2 2
After:  [3, 3, 1, 1]

Before: [2, 2, 3, 3]
8 0 3 0
After:  [2, 2, 3, 3]

Before: [2, 2, 0, 0]
10 3 3 2
After:  [2, 2, 1, 0]

Before: [1, 1, 1, 1]
6 1 3 3
After:  [1, 1, 1, 1]

Before: [2, 3, 3, 2]
10 3 3 3
After:  [2, 3, 3, 1]

Before: [2, 1, 3, 1]
6 1 3 0
After:  [1, 1, 3, 1]

Before: [1, 0, 0, 3]
8 0 3 3
After:  [1, 0, 0, 1]

Before: [1, 0, 0, 3]
15 0 2 1
After:  [1, 0, 0, 3]

Before: [2, 2, 0, 2]
9 3 3 3
After:  [2, 2, 0, 4]

Before: [3, 2, 0, 3]
8 1 3 0
After:  [2, 2, 0, 3]

Before: [0, 2, 2, 0]
3 2 2 3
After:  [0, 2, 2, 2]

Before: [3, 1, 3, 1]
6 1 3 0
After:  [1, 1, 3, 1]

Before: [1, 0, 2, 0]
2 0 2 1
After:  [1, 0, 2, 0]

Before: [2, 3, 0, 3]
3 3 3 1
After:  [2, 3, 0, 3]

Before: [0, 1, 2, 0]
10 3 3 0
After:  [1, 1, 2, 0]

Before: [1, 3, 0, 0]
15 0 2 0
After:  [0, 3, 0, 0]

Before: [1, 1, 0, 2]
11 1 0 0
After:  [1, 1, 0, 2]

Before: [0, 2, 2, 2]
7 0 0 1
After:  [0, 0, 2, 2]

Before: [2, 3, 1, 2]
14 1 3 1
After:  [2, 0, 1, 2]

Before: [2, 2, 1, 3]
8 0 3 2
After:  [2, 2, 2, 3]

Before: [3, 3, 2, 3]
1 3 2 3
After:  [3, 3, 2, 2]

Before: [2, 3, 2, 3]
1 3 2 1
After:  [2, 2, 2, 3]

Before: [1, 1, 2, 2]
0 1 2 3
After:  [1, 1, 2, 0]

Before: [0, 1, 1, 3]
7 0 0 1
After:  [0, 0, 1, 3]

Before: [1, 1, 1, 2]
11 1 0 2
After:  [1, 1, 1, 2]

Before: [1, 0, 1, 2]
4 2 3 2
After:  [1, 0, 1, 2]

Before: [0, 2, 3, 1]
4 3 2 2
After:  [0, 2, 1, 1]

Before: [1, 1, 1, 3]
11 1 0 1
After:  [1, 1, 1, 3]

Before: [1, 1, 0, 2]
15 0 2 1
After:  [1, 0, 0, 2]

Before: [0, 2, 1, 2]
14 1 2 1
After:  [0, 0, 1, 2]

Before: [1, 2, 1, 1]
13 3 1 2
After:  [1, 2, 0, 1]

Before: [1, 3, 0, 2]
15 0 2 2
After:  [1, 3, 0, 2]

Before: [0, 3, 3, 2]
14 1 3 3
After:  [0, 3, 3, 0]

Before: [2, 0, 1, 1]
9 0 0 3
After:  [2, 0, 1, 4]

Before: [1, 1, 0, 1]
6 1 3 1
After:  [1, 1, 0, 1]

Before: [3, 3, 2, 2]
9 2 3 0
After:  [4, 3, 2, 2]

Before: [2, 1, 2, 3]
5 3 0 0
After:  [2, 1, 2, 3]

Before: [2, 1, 2, 2]
9 3 3 2
After:  [2, 1, 4, 2]

Before: [0, 1, 2, 2]
0 1 2 1
After:  [0, 0, 2, 2]

Before: [2, 2, 3, 1]
4 3 2 3
After:  [2, 2, 3, 1]

Before: [3, 2, 3, 0]
10 3 3 3
After:  [3, 2, 3, 1]

Before: [3, 1, 2, 0]
1 0 2 0
After:  [2, 1, 2, 0]

Before: [1, 3, 2, 3]
2 0 2 3
After:  [1, 3, 2, 0]

Before: [1, 0, 0, 0]
15 0 2 2
After:  [1, 0, 0, 0]

Before: [1, 3, 2, 1]
1 1 2 3
After:  [1, 3, 2, 2]

Before: [3, 2, 2, 3]
5 3 1 1
After:  [3, 2, 2, 3]

Before: [2, 1, 2, 1]
0 1 2 2
After:  [2, 1, 0, 1]

Before: [2, 2, 1, 3]
9 1 1 1
After:  [2, 4, 1, 3]

Before: [1, 2, 2, 0]
9 2 1 2
After:  [1, 2, 4, 0]

Before: [3, 1, 2, 3]
0 1 2 0
After:  [0, 1, 2, 3]

Before: [1, 2, 2, 1]
2 0 2 3
After:  [1, 2, 2, 0]

Before: [0, 2, 2, 1]
9 1 1 2
After:  [0, 2, 4, 1]

Before: [2, 2, 2, 2]
9 2 3 1
After:  [2, 4, 2, 2]

Before: [2, 2, 2, 0]
3 2 2 0
After:  [2, 2, 2, 0]

Before: [1, 1, 3, 1]
11 1 0 2
After:  [1, 1, 1, 1]

Before: [2, 0, 3, 1]
9 0 0 1
After:  [2, 4, 3, 1]

Before: [1, 0, 2, 0]
2 0 2 0
After:  [0, 0, 2, 0]

Before: [2, 3, 0, 3]
10 2 2 0
After:  [1, 3, 0, 3]

Before: [3, 1, 3, 2]
13 2 1 1
After:  [3, 1, 3, 2]

Before: [3, 2, 0, 2]
10 3 3 1
After:  [3, 1, 0, 2]

Before: [3, 1, 1, 2]
14 3 2 1
After:  [3, 0, 1, 2]

Before: [0, 1, 2, 1]
3 2 2 2
After:  [0, 1, 2, 1]

Before: [0, 1, 2, 1]
7 0 0 3
After:  [0, 1, 2, 0]

Before: [1, 1, 1, 2]
11 1 0 3
After:  [1, 1, 1, 1]

Before: [3, 2, 2, 3]
5 3 1 2
After:  [3, 2, 2, 3]

Before: [3, 0, 2, 3]
1 0 2 0
After:  [2, 0, 2, 3]

Before: [1, 1, 2, 2]
0 1 2 2
After:  [1, 1, 0, 2]

Before: [1, 1, 0, 3]
11 1 0 1
After:  [1, 1, 0, 3]

Before: [3, 1, 2, 0]
0 1 2 1
After:  [3, 0, 2, 0]

Before: [1, 1, 0, 1]
11 1 0 1
After:  [1, 1, 0, 1]

Before: [2, 3, 2, 1]
12 3 2 1
After:  [2, 1, 2, 1]

Before: [0, 1, 3, 1]
4 3 2 1
After:  [0, 1, 3, 1]

Before: [1, 3, 2, 0]
2 0 2 1
After:  [1, 0, 2, 0]

Before: [0, 1, 3, 3]
7 0 0 2
After:  [0, 1, 0, 3]

Before: [3, 1, 3, 1]
6 1 3 2
After:  [3, 1, 1, 1]

Before: [1, 2, 3, 1]
4 3 2 0
After:  [1, 2, 3, 1]

Before: [3, 2, 2, 3]
3 3 3 1
After:  [3, 3, 2, 3]

Before: [2, 1, 2, 1]
6 1 3 0
After:  [1, 1, 2, 1]

Before: [1, 1, 2, 3]
11 1 0 3
After:  [1, 1, 2, 1]

Before: [0, 0, 1, 3]
7 0 0 0
After:  [0, 0, 1, 3]

Before: [2, 2, 1, 2]
9 3 3 0
After:  [4, 2, 1, 2]

Before: [0, 2, 1, 3]
7 0 0 1
After:  [0, 0, 1, 3]

Before: [1, 1, 1, 0]
11 1 0 0
After:  [1, 1, 1, 0]

Before: [0, 1, 2, 1]
6 1 3 0
After:  [1, 1, 2, 1]

Before: [0, 3, 3, 2]
7 0 0 0
After:  [0, 3, 3, 2]

Before: [3, 1, 2, 2]
0 1 2 3
After:  [3, 1, 2, 0]

Before: [3, 1, 2, 0]
0 1 2 3
After:  [3, 1, 2, 0]

Before: [3, 1, 2, 0]
3 2 2 3
After:  [3, 1, 2, 2]

Before: [2, 2, 1, 3]
8 1 3 2
After:  [2, 2, 2, 3]

Before: [1, 2, 1, 3]
9 2 0 3
After:  [1, 2, 1, 2]

Before: [3, 2, 2, 1]
12 3 2 0
After:  [1, 2, 2, 1]

Before: [2, 3, 2, 3]
8 0 3 1
After:  [2, 2, 2, 3]

Before: [1, 1, 1, 3]
13 3 1 1
After:  [1, 1, 1, 3]

Before: [0, 0, 2, 1]
12 3 2 3
After:  [0, 0, 2, 1]

Before: [1, 0, 0, 2]
10 3 3 3
After:  [1, 0, 0, 1]

Before: [3, 2, 3, 1]
4 3 2 1
After:  [3, 1, 3, 1]

Before: [3, 3, 2, 1]
1 1 2 2
After:  [3, 3, 2, 1]

Before: [3, 2, 2, 3]
5 0 1 2
After:  [3, 2, 2, 3]

Before: [1, 1, 0, 0]
15 0 2 0
After:  [0, 1, 0, 0]

Before: [2, 3, 3, 2]
9 3 0 3
After:  [2, 3, 3, 4]

Before: [2, 3, 2, 1]
12 3 2 0
After:  [1, 3, 2, 1]

Before: [0, 1, 1, 3]
3 3 3 0
After:  [3, 1, 1, 3]

Before: [1, 1, 0, 0]
15 0 2 2
After:  [1, 1, 0, 0]

Before: [2, 3, 2, 1]
5 1 0 1
After:  [2, 2, 2, 1]

Before: [2, 1, 1, 1]
6 1 3 1
After:  [2, 1, 1, 1]

Before: [3, 1, 2, 1]
1 0 2 0
After:  [2, 1, 2, 1]

Before: [2, 0, 1, 2]
9 3 0 3
After:  [2, 0, 1, 4]

Before: [2, 1, 1, 1]
6 1 3 2
After:  [2, 1, 1, 1]

Before: [1, 1, 2, 2]
0 1 2 0
After:  [0, 1, 2, 2]

Before: [2, 3, 1, 3]
14 3 1 0
After:  [1, 3, 1, 3]

Before: [3, 3, 3, 2]
5 0 3 0
After:  [2, 3, 3, 2]

Before: [3, 3, 2, 3]
3 2 2 1
After:  [3, 2, 2, 3]

Before: [1, 2, 3, 3]
13 1 2 1
After:  [1, 0, 3, 3]

Before: [2, 1, 0, 3]
13 3 1 2
After:  [2, 1, 1, 3]

Before: [0, 0, 3, 1]
4 3 2 3
After:  [0, 0, 3, 1]

Before: [0, 2, 3, 1]
4 3 2 0
After:  [1, 2, 3, 1]

Before: [0, 1, 3, 2]
7 0 0 0
After:  [0, 1, 3, 2]

Before: [1, 3, 2, 1]
2 0 2 2
After:  [1, 3, 0, 1]

Before: [1, 2, 0, 1]
15 0 2 3
After:  [1, 2, 0, 0]

Before: [2, 0, 2, 1]
12 3 2 2
After:  [2, 0, 1, 1]

Before: [2, 1, 1, 3]
8 2 3 1
After:  [2, 1, 1, 3]

Before: [2, 3, 2, 0]
1 1 2 2
After:  [2, 3, 2, 0]

Before: [1, 3, 2, 2]
9 2 3 0
After:  [4, 3, 2, 2]

Before: [3, 3, 1, 2]
14 3 2 2
After:  [3, 3, 0, 2]

Before: [0, 0, 2, 0]
7 0 0 1
After:  [0, 0, 2, 0]

Before: [2, 1, 2, 3]
3 2 2 2
After:  [2, 1, 2, 3]

Before: [3, 2, 1, 1]
14 1 2 2
After:  [3, 2, 0, 1]

Before: [1, 0, 2, 2]
10 3 3 0
After:  [1, 0, 2, 2]

Before: [2, 2, 3, 0]
10 3 3 2
After:  [2, 2, 1, 0]

Before: [3, 2, 3, 0]
10 3 3 0
After:  [1, 2, 3, 0]

Before: [1, 1, 3, 1]
6 1 3 3
After:  [1, 1, 3, 1]

Before: [3, 3, 3, 1]
4 3 2 0
After:  [1, 3, 3, 1]

Before: [0, 3, 3, 3]
14 3 1 2
After:  [0, 3, 1, 3]

Before: [3, 2, 1, 2]
4 2 3 0
After:  [1, 2, 1, 2]

Before: [2, 1, 2, 1]
9 2 0 3
After:  [2, 1, 2, 4]

Before: [0, 1, 2, 3]
7 0 0 1
After:  [0, 0, 2, 3]

Before: [3, 0, 1, 2]
4 2 3 3
After:  [3, 0, 1, 1]

Before: [2, 2, 0, 3]
8 0 3 2
After:  [2, 2, 2, 3]

Before: [0, 1, 2, 1]
12 3 2 0
After:  [1, 1, 2, 1]

Before: [1, 1, 3, 3]
11 1 0 1
After:  [1, 1, 3, 3]

Before: [0, 1, 2, 2]
3 2 2 1
After:  [0, 2, 2, 2]



7 2 0 0
11 0 2 0
2 1 1 3
7 0 0 2
11 2 2 2
13 0 3 2
7 2 1 2
9 1 2 1
8 1 0 2
2 3 1 3
2 3 1 1
14 0 1 3
7 3 2 3
7 3 1 3
9 3 2 2
8 2 0 0
7 1 0 2
11 2 2 2
2 0 2 1
2 0 0 3
2 3 1 2
7 2 1 2
9 0 2 0
8 0 2 1
2 2 3 0
2 3 2 3
2 3 2 2
0 0 2 2
7 2 1 2
7 2 2 2
9 1 2 1
8 1 3 0
2 2 1 3
2 1 2 1
2 2 3 2
15 1 3 3
7 3 3 3
9 3 0 0
8 0 3 2
2 3 1 1
2 2 0 3
2 1 3 0
15 0 3 0
7 0 2 0
7 0 3 0
9 2 0 2
8 2 2 3
2 2 1 0
2 3 2 2
7 1 0 1
11 1 1 1
0 0 2 1
7 1 2 1
9 1 3 3
8 3 2 1
7 1 0 3
11 3 1 3
13 0 3 3
7 3 3 3
9 1 3 1
8 1 1 3
7 0 0 2
11 2 2 2
2 3 1 0
2 0 3 1
14 2 0 0
7 0 1 0
9 0 3 3
8 3 2 1
2 1 2 0
2 2 2 3
2 0 2 2
7 0 2 3
7 3 3 3
9 3 1 1
8 1 1 0
2 0 2 1
7 1 0 3
11 3 1 3
11 3 1 1
7 1 3 1
9 1 0 0
8 0 3 2
2 1 2 0
7 3 0 1
11 1 0 1
2 2 1 3
11 0 1 1
7 1 1 1
7 1 1 1
9 1 2 2
7 1 0 0
11 0 3 0
2 1 3 1
15 1 3 3
7 3 1 3
9 2 3 2
8 2 3 3
2 0 3 2
1 0 2 2
7 2 2 2
7 2 2 2
9 2 3 3
2 2 3 0
2 3 0 2
2 2 2 1
0 0 2 2
7 2 2 2
9 3 2 3
7 3 0 0
11 0 3 0
7 2 0 2
11 2 0 2
0 2 0 0
7 0 2 0
9 3 0 3
2 3 2 0
2 3 3 1
0 2 0 1
7 1 2 1
9 1 3 3
8 3 3 1
2 3 3 2
2 3 0 3
1 3 2 3
7 3 3 3
9 3 1 1
2 1 3 3
2 0 1 2
9 3 3 2
7 2 1 2
9 2 1 1
8 1 3 0
7 2 0 3
11 3 0 3
7 1 0 2
11 2 2 2
2 2 1 1
12 3 2 3
7 3 3 3
9 3 0 0
8 0 2 2
2 0 3 1
7 1 0 0
11 0 1 0
2 1 1 3
11 3 1 1
7 1 3 1
9 2 1 2
7 0 0 0
11 0 2 0
2 3 2 1
13 0 3 0
7 0 2 0
7 0 1 0
9 2 0 2
8 2 0 0
2 1 2 1
7 0 0 2
11 2 2 2
9 1 3 1
7 1 2 1
9 1 0 0
8 0 1 1
2 1 0 2
2 2 2 3
2 2 1 0
10 0 3 2
7 2 3 2
7 2 1 2
9 1 2 1
8 1 3 2
2 3 1 1
2 3 2 3
5 1 0 3
7 3 3 3
7 3 1 3
9 2 3 2
2 2 1 1
2 2 0 3
10 0 3 0
7 0 3 0
9 2 0 2
8 2 3 0
2 0 3 1
2 2 0 2
7 1 0 3
11 3 0 3
12 3 2 1
7 1 2 1
9 0 1 0
8 0 3 1
2 3 0 2
2 2 2 0
2 2 3 3
6 0 2 3
7 3 2 3
9 3 1 1
8 1 3 0
2 3 1 3
2 0 1 1
1 3 2 1
7 1 1 1
9 1 0 0
7 0 0 3
11 3 0 3
2 0 3 2
2 3 2 1
1 1 2 2
7 2 1 2
7 2 3 2
9 2 0 0
2 2 0 3
2 0 0 1
2 0 3 2
4 2 3 3
7 3 1 3
9 3 0 0
8 0 1 1
2 2 3 2
2 1 3 0
2 0 1 3
12 3 2 3
7 3 3 3
9 1 3 1
8 1 3 3
2 3 2 1
2 3 1 0
6 2 0 2
7 2 3 2
7 2 1 2
9 3 2 3
8 3 2 2
2 1 3 3
2 1 3 0
9 0 0 1
7 1 2 1
7 1 3 1
9 1 2 2
2 2 2 0
2 1 0 1
2 0 0 3
15 1 0 3
7 3 3 3
9 3 2 2
8 2 1 1
2 0 2 0
7 0 0 3
11 3 2 3
7 0 0 2
11 2 2 2
2 3 2 2
7 2 3 2
9 1 2 1
2 2 0 2
7 2 0 3
11 3 0 3
2 3 2 0
12 3 2 2
7 2 3 2
9 2 1 1
8 1 0 0
2 2 1 2
7 3 0 1
11 1 2 1
12 3 2 1
7 1 2 1
7 1 1 1
9 0 1 0
8 0 0 1
2 0 2 0
12 3 2 2
7 2 3 2
7 2 3 2
9 1 2 1
2 1 1 2
7 0 0 3
11 3 2 3
2 3 2 0
1 0 2 3
7 3 2 3
9 1 3 1
8 1 1 3
2 3 2 2
2 2 0 0
2 3 1 1
14 0 1 2
7 2 3 2
9 3 2 3
8 3 0 1
7 0 0 3
11 3 0 3
2 1 3 0
7 3 0 2
11 2 3 2
4 3 2 0
7 0 3 0
9 0 1 1
8 1 1 0
2 2 2 3
2 3 3 1
1 1 2 2
7 2 1 2
9 2 0 0
8 0 0 1
2 3 1 2
2 1 0 3
2 3 1 0
7 3 2 2
7 2 1 2
7 2 1 2
9 2 1 1
8 1 1 3
2 1 3 0
2 2 1 2
2 2 2 1
8 0 2 0
7 0 2 0
9 3 0 3
8 3 1 0
2 2 2 3
2 1 2 1
15 1 3 2
7 2 2 2
9 0 2 0
2 3 1 2
2 3 1 1
5 1 3 1
7 1 3 1
9 0 1 0
8 0 3 1
2 0 3 2
2 2 2 0
10 0 3 3
7 3 1 3
7 3 1 3
9 3 1 1
8 1 3 0
7 3 0 3
11 3 0 3
2 1 1 1
2 2 2 2
12 3 2 1
7 1 1 1
9 1 0 0
8 0 3 2
2 1 0 0
2 3 1 3
2 3 3 1
9 0 0 0
7 0 1 0
9 0 2 2
8 2 2 3
2 2 0 1
2 3 3 2
2 2 2 0
6 1 2 1
7 1 3 1
9 1 3 3
2 1 3 0
2 1 3 1
7 1 2 2
7 2 2 2
9 3 2 3
8 3 3 0
2 0 2 3
2 2 1 2
3 2 3 2
7 2 3 2
7 2 2 2
9 2 0 0
8 0 3 1
2 1 3 2
7 3 0 3
11 3 2 3
2 2 0 0
10 0 3 3
7 3 3 3
9 3 1 1
8 1 1 3
2 2 0 1
7 0 0 2
11 2 3 2
2 1 1 0
6 1 2 2
7 2 1 2
7 2 2 2
9 2 3 3
7 1 0 2
11 2 0 2
2 1 2 1
7 0 2 2
7 2 3 2
9 2 3 3
8 3 0 2
2 1 1 3
9 3 0 1
7 1 3 1
9 1 2 2
2 2 2 3
2 2 0 1
7 1 0 0
11 0 2 0
3 1 3 1
7 1 2 1
7 1 1 1
9 1 2 2
8 2 2 0
7 3 0 2
11 2 2 2
2 0 3 3
2 3 2 1
12 3 2 1
7 1 1 1
9 1 0 0
8 0 2 3
2 2 1 0
2 3 0 2
2 3 0 1
2 2 1 0
7 0 1 0
9 3 0 3
8 3 0 1
7 1 0 2
11 2 2 2
2 0 2 0
2 0 0 3
12 3 2 3
7 3 3 3
9 3 1 1
8 1 0 3
2 1 1 0
2 0 2 1
8 0 2 0
7 0 2 0
9 0 3 3
2 2 0 0
2 1 2 1
2 1 1 2
15 1 0 2
7 2 3 2
9 2 3 3
8 3 0 0
7 0 0 1
11 1 3 1
2 3 2 3
7 0 0 2
11 2 1 2
1 3 2 3
7 3 3 3
7 3 1 3
9 0 3 0
8 0 3 2
2 0 2 1
2 1 2 0
7 3 0 3
11 3 1 3
11 0 1 1
7 1 2 1
9 1 2 2
8 2 3 3
2 3 3 1
7 0 0 0
11 0 0 0
2 0 3 2
2 2 1 1
7 1 3 1
9 1 3 3
7 2 0 1
11 1 3 1
2 1 2 2
1 1 2 2
7 2 3 2
9 2 3 3
8 3 1 1
7 3 0 0
11 0 3 0
2 2 3 2
2 2 0 3
3 2 3 2
7 2 1 2
9 1 2 1
8 1 3 3
2 2 2 0
2 2 3 1
2 3 2 2
6 0 2 1
7 1 3 1
7 1 2 1
9 3 1 3
8 3 0 1
2 3 3 3
2 0 1 2
2 0 1 0
1 3 2 0
7 0 1 0
9 1 0 1
7 0 0 0
11 0 0 0
2 1 2 3
2 2 3 0
7 0 2 0
9 1 0 1
2 2 0 0
2 2 0 3
2 1 2 2
2 3 0 0
7 0 2 0
7 0 2 0
9 0 1 1
8 1 0 0
2 1 2 3
7 1 0 1
11 1 1 1
2 0 1 2
9 3 3 1
7 1 3 1
7 1 3 1
9 0 1 0
7 2 0 2
11 2 1 2
7 2 0 1
11 1 1 1
7 0 0 3
11 3 0 3
2 3 1 3
7 3 3 3
9 3 0 0
8 0 3 1
2 0 0 3
2 3 2 0
2 3 2 2
4 3 2 2
7 2 1 2
9 2 1 1
8 1 0 3
2 0 0 2
7 3 0 1
11 1 2 1
7 3 0 0
11 0 1 0
7 0 2 0
7 0 2 0
9 0 3 3
2 3 1 2
2 2 3 0
6 1 2 0
7 0 1 0
7 0 3 0
9 0 3 3
2 0 2 1
2 1 1 0
7 3 0 2
11 2 2 2
11 0 1 2
7 2 3 2
9 3 2 3
8 3 2 1
2 0 3 2
2 2 0 3
15 0 3 3
7 3 3 3
7 3 3 3
9 1 3 1
2 2 1 2
2 0 1 3
2 0 2 0
3 2 3 0
7 0 2 0
9 0 1 1
2 2 1 0
7 2 0 2
11 2 0 2
2 1 2 3
13 0 3 0
7 0 2 0
7 0 1 0
9 1 0 1
2 2 2 0
2 3 3 2
6 0 2 0
7 0 2 0
9 0 1 1
8 1 3 3
2 2 2 1
2 0 3 2
2 1 2 0
7 0 2 1
7 1 3 1
9 3 1 3
8 3 3 2
2 3 3 3
7 3 0 0
11 0 3 0
2 2 0 1
6 1 0 3
7 3 1 3
9 3 2 2
8 2 3 1
2 2 2 3
2 2 2 2
2 1 2 0
15 0 3 0
7 0 1 0
9 1 0 1
8 1 1 2
2 1 0 1
2 1 0 3
2 2 3 0
15 3 0 0
7 0 2 0
9 2 0 2
8 2 3 0
2 2 0 3
2 0 1 2
7 1 2 2
7 2 1 2
9 2 0 0
8 0 0 1
2 3 2 2
7 1 0 0
11 0 1 0
7 0 2 0
7 0 3 0
9 1 0 1
8 1 2 0
7 3 0 3
11 3 0 3
2 3 3 1
4 3 2 1
7 1 3 1
9 0 1 0
2 1 3 3
2 0 3 2
2 1 1 1
9 1 3 3
7 3 2 3
9 3 0 0
8 0 2 2
2 2 1 0
7 2 0 1
11 1 3 1
2 2 1 3
14 0 1 3
7 3 2 3
7 3 2 3
9 3 2 2
8 2 0 1
2 3 2 3
2 3 2 2
5 3 0 2
7 2 3 2
7 2 3 2
9 1 2 1
7 0 0 0
11 0 1 0
2 2 1 2
7 3 0 3
11 3 2 3
3 2 3 2
7 2 3 2
9 2 1 1
8 1 1 2
2 1 1 3
2 0 0 1
9 3 0 1
7 1 3 1
9 1 2 2
8 2 0 1
2 2 3 2
7 0 0 3
11 3 2 3
3 2 3 0
7 0 3 0
9 1 0 1
2 0 1 3
2 2 0 0
3 2 3 0
7 0 1 0
9 0 1 1
8 1 3 0
2 3 3 2
2 2 0 1
2 3 3 3
6 1 2 3
7 3 3 3
9 0 3 0
8 0 0 1
2 0 0 3
2 0 3 0
4 3 2 3
7 3 3 3
7 3 1 3
9 1 3 1
8 1 2 3
2 2 1 1
2 3 3 0
6 1 2 2
7 2 3 2
9 2 3 3
2 2 0 2
7 1 0 0
11 0 1 0
2 1 0 1
9 1 0 1
7 1 2 1
7 1 1 1
9 1 3 3
8 3 3 2
2 1 3 3
2 1 3 1
7 3 0 0
11 0 3 0
2 3 1 0
7 0 1 0
9 0 2 2
8 2 0 1
7 3 0 0
11 0 2 0
2 1 2 2
13 0 3 0
7 0 2 0
7 0 1 0
9 1 0 1
8 1 0 0
7 1 0 1
11 1 1 1
2 0 0 3
2 2 1 2
12 3 2 2
7 2 3 2
9 0 2 0
8 0 0 1
2 3 1 2
2 3 1 3
2 1 2 0
9 0 0 0
7 0 3 0
9 1 0 1
2 1 0 3
2 2 1 0
2 2 3 2
13 0 3 3
7 3 1 3
7 3 2 3
9 1 3 1
8 1 0 3
2 0 2 1
2 3 1 2
0 0 2 0
7 0 3 0
7 0 2 0
9 0 3 3
8 3 0 2
2 1 0 3
2 0 0 0
2 1 3 1
2 3 1 1
7 1 1 1
9 2 1 2
8 2 0 0
2 3 1 2
7 2 0 1
11 1 1 1
7 3 2 1
7 1 1 1
9 1 0 0
8 0 1 2
7 1 0 1
11 1 3 1
2 2 3 0
2 0 1 3
2 3 0 0
7 0 1 0
9 0 2 2
8 2 2 1
2 1 2 0
7 2 0 3
11 3 1 3
2 1 1 2
9 3 0 3
7 3 3 3
7 3 1 3
9 1 3 1
7 3 0 3
11 3 0 3
2 0 0 2
2 3 3 0
0 2 0 2
7 2 2 2
7 2 3 2
9 1 2 1
8 1 3 0
2 3 3 2
2 0 0 1
7 2 0 3
11 3 1 3
11 3 1 1
7 1 3 1
7 1 3 1
9 1 0 0
7 2 0 3
11 3 2 3
2 3 0 1
7 2 0 2
11 2 2 2
14 2 1 1
7 1 1 1
9 1 0 0
8 0 2 1
7 0 0 0
11 0 2 0
2 3 3 2
2 1 2 3
7 3 2 2
7 2 2 2
9 2 1 1
8 1 0 0
2 1 3 1
2 3 3 2
2 2 3 3
15 1 3 1
7 1 3 1
9 0 1 0
8 0 1 1
2 0 1 2
2 2 0 0
10 0 3 2
7 2 2 2
9 2 1 1
8 1 1 2
7 2 0 0
11 0 3 0
2 0 2 3
7 1 0 1
11 1 2 1
6 1 0 3
7 3 2 3
9 2 3 2
2 1 3 0
2 1 1 1
7 2 0 3
11 3 2 3
15 1 3 3
7 3 3 3
7 3 1 3
9 3 2 2
8 2 2 3
7 2 0 2
11 2 0 2
2 0 3 1
7 0 2 2
7 2 1 2
9 2 3 3
8 3 1 2
7 3 0 0
11 0 2 0
2 0 1 3
3 0 3 1
7 1 1 1
9 2 1 2
8 2 0 1
2 1 2 3
2 2 2 2
13 0 3 0
7 0 2 0
9 1 0 1
2 0 0 2
2 3 3 0
2 2 2 3
4 2 3 3
7 3 1 3
9 3 1 1
8 1 2 2
2 0 3 1
2 1 0 0
2 0 2 3
11 0 1 1
7 1 2 1
9 2 1 2
8 2 2 1
7 1 0 2
11 2 0 2
2 2 3 3
4 2 3 0
7 0 3 0
9 0 1 1
8 1 2 0
7 3 0 1
11 1 3 1
7 0 0 3
11 3 1 3
11 3 1 2
7 2 2 2
7 2 3 2
9 2 0 0
8 0 2 1
2 1 0 0
7 3 0 2
11 2 2 2
2 0 1 3
8 0 2 0
7 0 3 0
9 0 1 1
8 1 0 0
7 2 0 1
11 1 2 1
12 3 2 2
7 2 3 2
9 0 2 0
7 2 0 1
11 1 1 1
2 3 1 2
2 2 1 3
7 1 2 2
7 2 3 2
7 2 2 2
9 0 2 0
2 0 2 3
2 2 3 1
2 3 2 2
4 3 2 3
7 3 3 3
7 3 1 3
9 0 3 0
8 0 1 1
2 0 1 2
2 3 1 3
2 2 3 0
5 3 0 3
7 3 3 3
9 3 1 1
8 1 3 3
2 1 3 0
2 1 3 1
7 1 0 2
11 2 2 2
8 0 2 2
7 2 3 2
9 3 2 3
8 3 1 1
2 1 2 3
2 3 0 2
9 3 0 3
7 3 2 3
9 3 1 1
2 0 3 3
2 2 2 0
6 0 2 0
7 0 2 0
9 1 0 1
2 3 3 0
2 2 3 3
7 3 1 3
9 1 3 1
8 1 0 0";
    #endregion

    private static IList<string> OperatorNames => new List<string>
    {
        "addr",
        "addi",
        "mulr",
        "muli",
        "banr",
        "bani",
        "borr",
        "bori",
        "setr",
        "seti",
        "gtir",
        "gtri",
        "gtrr",
        "eqir",
        "eqri",
        "eqrr"
    };

    public override Task ExecuteAsync()
    {
        IDictionary<int, IList<string>> possibleValues = new Dictionary<int, IList<string>>();
        for (int i = 0; i <= 15; i++)
        {
            possibleValues.Add(i, new List<string>(OperatorNames));
        }


        int total = 0;
        var regelEnumerator = ((IEnumerable<string>)input.Split(new[] { Environment.NewLine }, StringSplitOptions.None)).GetEnumerator();
        regelEnumerator.MoveNext();
        while (regelEnumerator.Current.StartsWith("Before"))
        {
            string c = regelEnumerator.Current;
            int[] register = { int.Parse(c.Substring(9, 1)), int.Parse(c.Substring(12, 1)), int.Parse(c.Substring(15, 1)), int.Parse(c.Substring(18, 1)) };
            regelEnumerator.MoveNext();
            c = regelEnumerator.Current;
            int[] instructions = c.Split(' ').Select(int.Parse).ToArray();
            regelEnumerator.MoveNext();
            c = regelEnumerator.Current;
            int[] result = { int.Parse(c.Substring(9, 1)), int.Parse(c.Substring(12, 1)), int.Parse(c.Substring(15, 1)), int.Parse(c.Substring(18, 1)) };
            regelEnumerator.MoveNext();
            regelEnumerator.MoveNext();
            var candidates = OperatorNames.Where(o =>
                ExecuteInstructions(register, instructions, o).SequenceEqual(result));
            IList<string> newPossibleValues = new List<string>();
            foreach (var name in possibleValues[instructions[0]])
            {
                if (candidates.Contains(name))
                {
                    newPossibleValues.Add(name);
                }
            }
            if (candidates.Count() >= 3)
            {
                total++;
            }

            possibleValues[instructions[0]] = newPossibleValues;
        }

        regelEnumerator.MoveNext();
        IList<int[]> instructionSets = new List<int[]>();
        while (regelEnumerator.MoveNext())
        {
            instructionSets.Add(regelEnumerator.Current.Split(' ').Select(int.Parse).ToArray());
        }

        IDictionary<int, string> opCodes = SolveOpcodes(possibleValues, new Dictionary<int, string>());
        var currentRegister = new int[] { 0, 0, 0, 0 };
        foreach (var instructionSet in instructionSets)
        {
            currentRegister = ExecuteInstructions(currentRegister, instructionSet, opCodes[instructionSet[0]]);
        }
        Result = total.ToString() + " " + currentRegister[0];
        return Task.CompletedTask;
    }

    private IDictionary<int, string> SolveOpcodes(IDictionary<int, IList<string>> possibleValues, IDictionary<int, string> mapped)
    {
        int? nextKey = null;
        foreach (var key in possibleValues.OrderBy(kvp => kvp.Value.Count).Select(kvp => kvp.Key))
        {
            if (!mapped.Keys.Contains(key))
            {
                nextKey = key;
                break;
            }
        }

        if (nextKey == null)
        {
            return null;
        }
        foreach (var opcode in possibleValues[nextKey.Value].Where(c => !mapped.Values.Contains(c)))
        {
            IDictionary<int, string> newMapped = new Dictionary<int, string>(mapped);
            newMapped[nextKey.Value] = opcode;
            if (newMapped.Count == possibleValues.Count)
            {
                return newMapped;
            }

            var rec = SolveOpcodes(possibleValues, newMapped);
            if (rec != null)
            {
                return rec;
            }

        }

        return null;
    }

    public int[] ExecuteInstructions(int[] register, int[] instructions, string name)
    {
        int[] result = new int[4];
        for (int i = 0; i < 4; i++)
        {
            if (instructions[3] != i)
            {
                result[i] = register[i];
            }
        }

        int a = instructions[1];
        int b = instructions[2];
        int c = instructions[3];
        int value = 0;
        switch (name)
        {
            case "addr":
                value = register[a] + register[b];
                break;
            case "addi":
                value = register[a] + b;
                break;
            case "mulr":
                value = register[a] * register[b];
                break;
            case "muli":
                value = register[a] * b;
                break;
            case "banr":
                value = register[a] & register[b];
                break;
            case "bani":
                value = register[a] & b;
                break;
            case "borr":
                value = register[a] | register[b];
                break;
            case "bori":
                value = register[a] | b;
                break;
            case "setr":
                value = register[a];
                break;
            case "seti":
                value = a;
                break;
            case "gtir":
                value = a > register[b] ? 1 : 0;
                break;
            case "gtri":
                value = register[a] > b ? 1 : 0;
                break;
            case "gtrr":
                value = register[a] > register[b] ? 1 : 0;
                break;
            case "eqir":
                value = a == register[b] ? 1 : 0;
                break;
            case "eqri":
                value = register[a] == b ? 1 : 0;
                break;
            case "eqrr":
                value = register[a] == register[b] ? 1 : 0;
                break;
        }

        result[c] = value;

        return result;
    }

    public override int Nummer => 201816;
}