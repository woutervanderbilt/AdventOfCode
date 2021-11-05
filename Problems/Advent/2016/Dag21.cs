using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent
{
    public class Dag21 : Problem
    {
        private const string input = @"swap position 5 with position 6
reverse positions 1 through 6
rotate right 7 steps
rotate based on position of letter c
rotate right 7 steps
reverse positions 0 through 4
swap letter f with letter h
reverse positions 1 through 2
move position 1 to position 0
rotate based on position of letter f
move position 6 to position 3
reverse positions 3 through 6
rotate based on position of letter c
rotate based on position of letter b
move position 2 to position 4
swap letter b with letter d
move position 1 to position 6
move position 7 to position 1
swap letter f with letter c
move position 2 to position 3
swap position 1 with position 7
reverse positions 3 through 5
swap position 1 with position 4
move position 4 to position 7
rotate right 4 steps
reverse positions 3 through 6
move position 0 to position 6
swap position 3 with position 5
swap letter e with letter h
rotate based on position of letter c
swap position 4 with position 7
reverse positions 0 through 5
rotate right 5 steps
rotate left 0 steps
rotate based on position of letter f
swap letter e with letter b
rotate right 2 steps
rotate based on position of letter c
swap letter a with letter e
rotate left 4 steps
rotate left 0 steps
move position 6 to position 7
rotate right 2 steps
rotate left 6 steps
rotate based on position of letter d
swap letter a with letter b
move position 5 to position 4
reverse positions 0 through 7
rotate left 3 steps
rotate based on position of letter e
rotate based on position of letter h
swap position 4 with position 6
reverse positions 4 through 5
reverse positions 5 through 7
rotate left 3 steps
move position 7 to position 2
move position 3 to position 4
swap letter b with letter d
reverse positions 3 through 4
swap letter e with letter a
rotate left 4 steps
swap position 3 with position 4
swap position 7 with position 5
rotate right 1 step
rotate based on position of letter g
reverse positions 0 through 3
swap letter g with letter b
rotate based on position of letter b
swap letter a with letter c
swap position 0 with position 2
reverse positions 1 through 3
rotate left 7 steps
swap letter f with letter a
move position 5 to position 0
reverse positions 1 through 5
rotate based on position of letter d
rotate based on position of letter c
rotate left 2 steps
swap letter b with letter a
swap letter f with letter c
swap letter h with letter f
rotate based on position of letter b
rotate left 3 steps
swap letter b with letter h
reverse positions 1 through 7
rotate based on position of letter h
swap position 1 with position 5
rotate left 1 step
rotate based on position of letter h
reverse positions 0 through 1
swap position 5 with position 7
reverse positions 0 through 2
reverse positions 1 through 3
move position 1 to position 4
reverse positions 1 through 3
rotate left 1 step
swap position 4 with position 1
move position 1 to position 3
rotate right 2 steps
move position 0 to position 5";


        private const string input2 =
            @"swap position 4 with position 0 swaps the first and last letters, producing the input for the next step, ebcda.
swap letter d with letter b swaps the positions of d and b: edcba.
reverse positions 0 through 4 causes the entire string to be reversed, producing abcde.
rotate left 1 step shifts all letters left one position, causing the first letter to wrap to the end of the string: bcdea.
move position 1 to position 4 removes the letter at position 1 (c), then inserts it at position 4 (the end of the string): bdeac.
move position 3 to position 0 removes the letter at position 3 (a), then inserts it at position 0 (the front of the string): abdec.
rotate based on position of letter b finds the index of letter b (1), then rotates the string right once plus a number of times equal to that index (2): ecabd.
rotate based on position of letter d finds the index of letter d (4), then rotates the string right once, plus a number of times equal to that index, plus an additional time because the index was at least 4, for a total of 6 right rotations: decab.";
        public override Task ExecuteAsync()
        {
            //string currentpass = "abcdefgh";
            string currentpass = "fbgdceah";
            bool reverseAll = true;
            IEnumerable<string> instructions = input.Split(Environment.NewLine);
            if (reverseAll)
            {
                instructions = instructions.Reverse();
            }
            foreach (var instruction in instructions)
            {
                var temp = ApplyInstruction(reverseAll, currentpass);
                var test = ApplyInstruction(!reverseAll, temp);
                if (test != currentpass)
                {

                }


                currentpass = temp;

                string ApplyInstruction(bool reverse, string pass)
                {
                    var words = instruction.Split(' ').ToList();
                    if (instruction.StartsWith("swap position"))
                    {
                        int p1 = int.Parse(words[2]);
                        int p2 = int.Parse(words[5]);
                        var c1 = pass[p1];
                        var c2 = pass[p2];
                        var sb = new StringBuilder(pass);
                        sb[p1] = c2;
                        sb[p2] = c1;
                        return sb.ToString();
                    }
                    else if (instruction.StartsWith("swap letter"))
                    {
                        var c1 = words[2].First();
                        var c2 = words[5].First();
                        var sb = new StringBuilder(pass);
                        sb[pass.IndexOf(c1)] = c2;
                        sb[pass.IndexOf(c2)] = c1;
                        return sb.ToString();
                    }
                    else if (instruction.StartsWith("rotate left"))
                    {
                        int rotate = int.Parse(words[2]);
                        if (reverse)
                        {
                            rotate = pass.Length - rotate;
                        }
                        var sb = new StringBuilder(pass.Substring(rotate)).Append(pass.Substring(0, rotate));
                        return sb.ToString();
                    }
                    else if(instruction.StartsWith("rotate right"))
                    {
                        int rotate = int.Parse(words[2]);
                        if (reverse)
                        {
                            rotate = pass.Length - rotate;
                        }
                        var sb = new StringBuilder(pass.Substring(pass.Length - rotate)).Append(pass.Substring(0, pass.Length - rotate));
                        return sb.ToString();
                    }
                    else if (instruction.StartsWith("rotate based"))
                    {
                        int rotate = pass.IndexOf(words[6].First());
                        if (reverse)
                        {
                            rotate = new List<int> {1,1,6,2,7,3,0,4}[rotate];
                            var sb2 = new StringBuilder(pass.Substring(rotate)).Append(pass.Substring(0, rotate));
                            return sb2.ToString();
                        }
                        rotate += rotate >= 4 ? 2 : 1;
                        rotate = rotate % pass.Length;
                        var sb = new StringBuilder(pass.Substring(pass.Length - rotate)).Append(pass.Substring(0, pass.Length - rotate));
                        return sb.ToString();
                    }
                    else if (instruction.StartsWith("reverse positions"))
                    {
                        int p1 = int.Parse(words[2]);
                        int p2 = int.Parse(words[4]);
                        var sb = new StringBuilder(pass.Substring(0, p1))
                            .Append(string.Concat(pass.Substring(p1, p2 - p1 + 1).Reverse()))
                            .Append(pass.Substring(p2 + 1, pass.Length - p2 - 1));
                        return sb.ToString();
                    }
                    else if (instruction.StartsWith("move position"))
                    {
                        int p1 = int.Parse(words[2]);
                        int p2 = int.Parse(words[5]);
                        if (reverse)
                        {
                            (p1, p2) = (p2, p1);
                        }
                        char c = pass[p1];
                        var sb = new StringBuilder(pass.Replace(c.ToString(), string.Empty));
                        sb.Insert(p2, c);
                        return sb.ToString();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }

            Result = currentpass;
            return Task.CompletedTask;
        }

        public override int Nummer => 201621;
    }
}
