using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2021
{
    internal class Dag14 : Problem
    {
        private const string input = @"CKKOHNSBPCPCHVNKHFFK

KO -> C
SO -> S
BF -> V
VN -> B
OV -> K
VH -> O
KV -> N
KB -> F
NB -> C
HS -> K
PF -> B
HB -> N
OC -> H
FS -> F
VV -> S
KF -> C
FN -> F
KP -> S
HO -> N
NH -> K
OO -> S
FB -> C
BP -> F
CH -> N
SN -> O
KN -> B
CV -> O
CC -> B
VB -> C
PH -> V
CO -> K
KS -> K
BK -> N
FH -> S
PV -> H
CB -> P
FO -> F
BB -> K
OB -> C
HH -> F
ON -> O
FK -> B
NF -> F
SV -> F
CP -> H
SS -> B
OP -> H
NS -> O
HK -> N
BC -> P
NV -> V
VS -> F
PC -> V
CS -> F
NP -> V
PS -> F
VC -> F
KK -> S
PO -> P
HF -> H
KC -> P
SF -> N
BV -> N
FF -> V
FV -> V
BO -> N
OS -> C
OF -> H
CN -> S
NO -> O
NC -> B
VK -> C
HN -> B
PK -> N
SK -> S
HV -> F
BH -> B
OK -> S
VO -> B
BS -> H
PP -> N
SC -> K
BN -> P
FC -> S
SB -> B
SH -> H
NN -> V
NK -> N
VF -> H
CF -> F
PB -> C
SP -> P
KH -> C
VP -> N
CK -> H
HP -> P
FP -> B
HC -> O
PN -> F
OH -> H";

        private const string testinput = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";
        public override Task ExecuteAsync()
        {
            long mod = 1000000007;
            int numberOfLetters = 10;
            var size = numberOfLetters * numberOfLetters;
            IDictionary<string, string> substitutions = new Dictionary<string, string>();
            string start = "";
            foreach (var line in input.Split(Environment.NewLine))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                else if (string.IsNullOrWhiteSpace(start))
                {
                    start = line;
                }
                else
                {
                    var words = line.Split(' ');
                    substitutions[words[0]] = words[2];
                }
            }

            var pairs = substitutions.Keys.ToList();

            var matrix = new SquareMatrix(size, mod);
            for (int i = 0; i < size; i++)
            {
                var a = pairs[i];
                var b = substitutions[a];
                var i1 = pairs.IndexOf($"{a[0]}{b}");
                var i2 = pairs.IndexOf($"{b}{a[1]}");
                matrix[i, i1] = 1;
                matrix[i, i2] = 1;
            }

            var vector = new Matrix(1, size, mod);
            var s = "";
            foreach (var c in start)
            {
                s += c;
                if (s.Length == 3)
                {
                    s = s.Substring(1);
                }

                if (s.Length == 2)
                {
                    vector[0, pairs.IndexOf(s)]++;
                }
            }

            vector = vector.Times(matrix.PowerMod(10000000000000000000));

            var counter = new CounterLong<char>(mod);

            for (int i = 0; i < size; i++)
            {
                var pair = pairs[i];
                counter[pair[0]] += vector[0, i];
            }
            counter[start.Last()]++;

            Result = (counter.Values.Max() - counter.Values.Min()).ToString();

            return Task.CompletedTask;
        }

        public override int Nummer => 202114;
    }
}
