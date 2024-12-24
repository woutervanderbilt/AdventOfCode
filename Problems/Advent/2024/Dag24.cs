using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Problems.Advent._2024;

internal class Dag24 : Problem
{
    public override async Task ExecuteAsync()
    {
        IDictionary<string, bool> inputs = new Dictionary<string, bool>();
        IDictionary<string, (string input1, string input2, Operator op)> gates = new Dictionary<string, (string input1, string input2, Operator op)> ();
        IDictionary<string, List<string>> outputs = new Dictionary<string, List<string>>();
        bool readingInput = true;
        foreach (var line in Input.Split(Environment.NewLine))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                readingInput = false;
                continue;
            }

            if (readingInput)
            {
                var split = line.Split(": ");
                inputs[split[0]] = split[1] == "1";
            }
            else
            {
                var words = line.Split(' ');
                gates[words[4]] = (words[0], words[2], words[1] switch
                {
                    "AND" => Operator.And,
                    "OR" => Operator.Or,
                    "XOR" => Operator.Xor,
                    _ => throw new InvalidOperationException()
                });
                outputs.AddToList(words[0], words[4]);
                outputs.AddToList(words[2], words[4]);
            }
        }

        long result1 = Output();


        SwapGates("z06", "ksv");
        SwapGates("z20", "tqq");
        SwapGates("z39", "ckb");
        IList<string> possibleResults = [];
        var random = new Random();

        while (possibleResults.Count != 1)
        {
            foreach (var inputsKey in inputs.Keys)
            {
                inputs[inputsKey] = random.Next(2) == 0;
            }

            long x = 0;
            long power = 1;
            foreach (var input in inputs.Where(i => i.Key.StartsWith("x")))
            {
                if (input.Value)
                {
                    x += power;
                }

                power *= 2;
            }

            long y = 0;
            power = 1;
            foreach (var input in inputs.Where(i => i.Key.StartsWith("y")))
            {
                if (input.Value)
                {
                    y += power;
                }

                power *= 2;
            }

            IList<string> swapped = ["z06", "z20", "z39", "ksv", "tqq", "ckb"];

            IList<string> results = [];
            foreach (var pair in gates.Pairs(true, false))
            {
                SwapGates(pair.Item1.Key, pair.Item2.Key);
                var output = Output();
                if (output == x + y)
                {
                    var res = swapped.Concat([pair.Item1.Key, pair.Item2.Key]).OrderBy(k => k);
                    results.Add(string.Join(',', res));
                }

                SwapGates(pair.Item1.Key, pair.Item2.Key);
            }

            if (!possibleResults.Any())
            {
                possibleResults = results;
            }
            else
            {
                possibleResults = possibleResults.Intersect(results).ToList();
            }
        }

        void SwapGates(string g1, string g2)
        {
            var s1 = gates[g1];
            var s2 = gates[g2];
            gates[g2] = s1;
            gates[g1] = s2;
            outputs.RemoveFromList(s1.input1, g1);
            outputs.RemoveFromList(s1.input2, g1);
            outputs.RemoveFromList(s2.input1, g2);
            outputs.RemoveFromList(s2.input2, g2);
            outputs.AddToList(s1.input1, g2);
            outputs.AddToList(s1.input2, g2);
            outputs.AddToList(s2.input1, g1);
            outputs.AddToList(s2.input2, g1);
        }

        Result = (result1, possibleResults[0]).ToString();

        long Output()
        {
            var signals = new Dictionary<string, bool>();

            foreach (var input in inputs)
            {
                AddSignal(input.Key, input.Value);
            }

            long result = 0;
            long power = 1;
            foreach (var signal in signals.Where(s => s.Key.StartsWith("z")).OrderBy(k => k.Key))
            {
                if (signal.Value)
                {
                    result += power;
                }

                power *= 2;
            }

            return result;

            void AddSignal(string gate, bool value)
            {
                signals[gate] = value;
                if (!outputs.ContainsKey(gate))
                {
                    return;
                }
                foreach (var output in outputs[gate])
                {
                    var nextGate = gates[output];
                    if (signals.TryGetValue(nextGate.input1, out var s1) &&
                        signals.TryGetValue(nextGate.input2, out var s2))
                    {
                        var outputSignal = nextGate.op switch
                        {
                            Operator.And => s1 && s2,
                            Operator.Or => s1 || s2,
                            Operator.Xor => s1 ^ s2,
                            _ => throw new InvalidOperationException()
                        };

                        AddSignal(output, outputSignal);
                    }
                }
            }
        }
    }

    private enum Operator
    {
        And,
        Or,
        Xor
    }


    protected override bool UseTestInput => false;

    protected override string TestInput => @"x00: 1
x01: 0
x02: 1
x03: 1
x04: 0
y00: 1
y01: 1
y02: 1
y03: 1
y04: 1

ntg XOR fgs -> mjb
y02 OR x01 -> tnw
kwq OR kpj -> z05
x00 OR x03 -> fst
tgd XOR rvg -> z01
vdt OR tnw -> bfw
bfw AND frj -> z10
ffh OR nrd -> bqk
y00 AND y03 -> djm
y03 OR y00 -> psh
bqk OR frj -> z08
tnw OR fst -> frj
gnj AND tgd -> z11
bfw XOR mjb -> z00
x03 OR x00 -> vdt
gnj AND wpb -> z02
x04 AND y00 -> kjc
djm OR pbm -> qhw
nrd AND vdt -> hwm
kjc AND fst -> rvg
y04 OR y02 -> fgs
y01 AND x02 -> pbm
ntg OR kjc -> kwq
psh XOR fgs -> tgd
qhw XOR tgd -> z09
pbm OR djm -> kpj
x03 XOR y03 -> ffh
x00 XOR y04 -> ntg
bfw OR bqk -> z06
nrd XOR fgs -> wpb
frj XOR qhw -> z04
bqk OR frj -> z07
y03 OR x01 -> nrd
hwm AND bqk -> z03
tgd XOR rvg -> z12
tnw OR pbm -> gnj";
    public override int Nummer => 202424;
}