using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace Problems.Advent._2021;

internal class Dag18 : Problem
{
    private const string input = @"[[8,8],5]
[[[[9,0],1],4],[[3,6],[0,5]]]
[[9,[0,[4,5]]],[1,[[6,8],4]]]
[[8,7],[[[8,5],[2,0]],[[6,3],[5,0]]]]
[[[1,8],2],[[[9,1],[2,0]],[1,[9,4]]]]
[[[6,[8,8]],[6,4]],[[8,2],[[0,8],9]]]
[[[6,3],[9,[9,1]]],[[0,0],1]]
[[[[2,7],[8,2]],[[9,6],[5,1]]],[[[7,6],[6,0]],[4,2]]]
[[[8,[9,1]],[9,3]],[[[5,4],[8,0]],[[3,5],[9,5]]]]
[[[3,[4,9]],2],[[7,9],7]]
[[[7,[9,0]],5],[[[3,4],[2,6]],[[3,5],[7,2]]]]
[[8,[8,9]],[[[3,2],[6,2]],4]]
[[[[8,0],3],[3,8]],[[[5,0],[7,3]],[5,[3,0]]]]
[4,[[3,[0,9]],[[5,0],[2,0]]]]
[[[[0,1],5],[3,[9,6]]],[[[4,4],5],[[3,8],[5,1]]]]
[[[[4,8],8],0],[5,[[1,7],[4,3]]]]
[[3,[[1,1],[5,6]]],[7,[[4,0],[0,7]]]]
[9,[4,[[1,3],2]]]
[[[1,[2,7]],[[4,7],3]],[2,1]]
[[[9,5],[2,5]],[[[8,9],[4,5]],2]]
[[2,[[7,4],6]],[[1,[0,7]],[[4,8],8]]]
[[[[0,5],3],[7,0]],9]
[[[[1,4],[4,3]],7],[[9,4],[6,[8,6]]]]
[[[7,2],[[3,3],1]],[5,9]]
[[[9,[6,2]],2],[[6,5],6]]
[[5,[3,2]],[[[2,4],[1,5]],[6,3]]]
[6,3]
[[9,6],[[[8,2],[5,6]],[[3,5],[3,3]]]]
[[[[2,5],7],4],[8,3]]
[[[[6,1],9],[0,6]],[6,2]]
[[[[8,4],2],[[0,1],[5,8]]],9]
[[[7,0],[4,9]],[[[9,9],[4,4]],[6,6]]]
[[[9,8],[2,0]],[[9,[6,2]],[6,[5,6]]]]
[[[9,8],[[0,6],[3,5]]],[[[4,7],[7,5]],[7,[8,5]]]]
[[[[9,0],[1,6]],[2,[5,3]]],[[[2,0],[0,3]],[[9,1],[7,7]]]]
[[[5,[2,2]],[2,[1,0]]],[1,1]]
[[[9,[7,2]],[[2,7],1]],[[5,7],[[8,7],7]]]
[[[9,[9,4]],[[0,8],2]],[0,[[2,2],[4,1]]]]
[[[5,5],[9,[2,0]]],[[[9,0],6],1]]
[[[1,9],[[9,5],[5,6]]],[6,[5,[9,4]]]]
[[[[8,6],9],9],[[7,2],[7,[2,6]]]]
[[[[6,4],7],7],[[2,[9,7]],7]]
[[7,[[5,6],9]],[[[9,8],8],[[8,9],[1,0]]]]
[[[0,[7,6]],0],[[[2,5],1],9]]
[[[3,[4,1]],[4,2]],[0,[[6,0],[1,6]]]]
[[9,[0,0]],[[[3,0],[9,9]],[1,[1,5]]]]
[[[[9,9],1],6],[5,6]]
[3,4]
[[[[5,4],9],6],2]
[[5,4],[[6,[7,4]],[[0,3],0]]]
[[[3,[9,6]],4],[[[9,8],6],3]]
[[5,[1,[5,5]]],[[[3,8],[0,1]],[[9,3],[6,2]]]]
[[4,[0,3]],1]
[[[7,[2,9]],[[5,8],2]],[[[4,4],[2,0]],8]]
[[[[4,0],0],8],7]
[[[[3,0],0],[[6,0],3]],[[[1,5],1],[3,[0,0]]]]
[[[[8,1],5],0],[[[3,9],[8,3]],[[6,9],[5,1]]]]
[[7,7],[[[8,5],2],[9,2]]]
[[[[4,9],9],[6,[5,3]]],[[[7,1],[7,1]],[[9,5],[7,0]]]]
[[7,[0,5]],[7,[2,[1,6]]]]
[[9,[0,[0,2]]],[[1,1],[[6,6],[5,3]]]]
[[[2,9],[[6,9],9]],[[[4,2],7],[1,[2,3]]]]
[[[0,1],[3,3]],[3,[[2,7],2]]]
[[[5,6],8],[[[4,9],[3,3]],[6,[5,2]]]]
[[4,[4,[2,5]]],[[2,[4,8]],[3,[7,7]]]]
[[2,5],[[[9,6],[9,3]],[[4,5],[2,3]]]]
[[5,[0,5]],[[[2,1],[0,5]],3]]
[[[[2,0],5],[[7,9],[4,5]]],[0,[[1,4],9]]]
[[[[1,3],2],[[3,9],[9,5]]],[[[4,1],[3,8]],0]]
[[[[1,8],[8,3]],[3,0]],[[5,1],[4,8]]]
[[1,6],[3,2]]
[[4,5],[[[9,3],[8,6]],[2,[8,6]]]]
[[[[4,4],1],[[7,3],2]],[[9,[2,1]],[8,2]]]
[0,[[2,[3,8]],9]]
[[1,[5,0]],[0,[[2,6],[8,5]]]]
[[6,[6,1]],[[2,[7,9]],[[8,3],1]]]
[[[2,[5,9]],[[8,9],1]],[[[5,2],2],4]]
[[[4,3],5],[[6,[3,6]],5]]
[1,[6,[6,2]]]
[[[[4,9],3],9],[[3,9],[8,[4,9]]]]
[[[[7,1],[1,6]],[[7,8],[3,7]]],[[[5,3],7],[9,[3,1]]]]
[[[[0,8],[8,9]],2],7]
[[[[3,7],[9,8]],[[7,1],8]],[[4,[4,6]],8]]
[3,[3,[[4,4],5]]]
[[3,[[2,3],7]],[[7,9],2]]
[[[[0,6],[5,1]],[[7,2],5]],[9,8]]
[[4,0],[[4,3],[7,2]]]
[[[8,[1,1]],[7,[9,1]]],[9,[9,[0,8]]]]
[9,[[[4,5],8],[[3,4],9]]]
[[[6,[4,7]],[8,7]],[[[3,8],5],[[2,1],[3,5]]]]
[[[[5,5],[6,8]],[[2,3],6]],[8,[5,7]]]
[[5,[[6,1],[3,6]]],[[[0,6],[7,1]],[9,[8,4]]]]
[[[[0,1],[4,9]],[[1,7],[3,3]]],[6,[3,[6,1]]]]
[[[[3,8],5],[[4,7],2]],2]
[[6,[[4,4],0]],[[2,[4,5]],[8,2]]]
[[6,[9,[7,0]]],[[9,[1,6]],[[6,1],1]]]
[[[[2,1],[5,7]],[5,[9,3]]],[[[7,9],[4,2]],4]]
[[3,1],[[7,8],[[8,8],9]]]
[[[[9,4],[1,8]],[9,[3,7]]],[[6,9],[[7,2],1]]]
[[[9,3],2],9]";

    private const string testinput = @"[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]
[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]";

    public override Task ExecuteAsync()
    {
        IList<SnailFishNumber> snailFishNumbers =
            input.Split(Environment.NewLine).Select(i => new SnailFishNumber(i)).ToList();

        SnailFishNumber sum = null;
        foreach (var snailFishNumber in snailFishNumbers)
        {
            if (sum == null)
            {
                sum = snailFishNumber;
            }
            else
            {
                sum += snailFishNumber;
            }
        }

        long max = 0;
        foreach (var snailFishNumber in snailFishNumbers)
        {
            foreach (var snailfIshNumber2 in snailFishNumbers)
            {
                var magnitude = (snailFishNumber + snailfIshNumber2).Magnitude();
                max = Math.Max(max, magnitude);
            }
        }


        Result = $"{sum!.Magnitude()} {max}";


        return Task.CompletedTask;
    }

    private class SnailFishNumber
    {
        public SnailFishNumber(string input)
        {
            if (int.TryParse(input.Substring(0,1), out var value))
            {
                RegularValue = value;
                IsRegular = true;
                return;
            }
            int depth = 0;
            int splitIndex = 0;
            foreach (var c in input)
            {
                if (c == '[')
                {
                    depth++;
                }
                else if (c == ']')
                {
                    depth--;
                }

                if (depth == 1 && c == ',')
                {
                    break;
                }

                splitIndex++;
            }

            input = input.Substring(0, input.Length - 1);
            Left = new SnailFishNumber(input.Substring(1, splitIndex));
            Left.IsLeftPart = true;
            Right = new SnailFishNumber(input.Substring(splitIndex+1));
            Left.Parent = this;
            Right.Parent = this;
        }

        public SnailFishNumber()
        {
        }


        public SnailFishNumber Left { get; set; }
        public SnailFishNumber Right { get; set; }
        public SnailFishNumber Parent { get; set; }
        private bool IsRegular { get; set; }
        private bool IsLeftPart { get; set; }
        public long RegularValue { get; set; }

        private SnailFishNumber Reduce()
        {
            while (Explode(0) || Split())
            {

            }

            return this;
        }

        private bool Explode(int depth)
        {
            if (depth < 4)
            {
                if (!IsRegular)
                {
                    return Left.Explode(depth + 1) || Right.Explode(depth + 1);
                }

                return false;
            }
            else
            {
                if (IsRegular)
                {
                    return false;
                }
                long leftAddition = Left.RegularValue;
                long rightAddition = Right.RegularValue;
                    
                if (IsLeftPart)
                {
                    var rightPart = Parent.Right;
                    while (!rightPart.IsRegular)
                    {
                        rightPart = rightPart.Left;
                    }

                    rightPart.RegularValue += rightAddition;
                    var parent = Parent;
                    while (parent is { IsLeftPart: true })
                    {
                        parent = parent.Parent;
                    }

                    if (parent != null && parent.Parent != null)
                    {
                        rightPart = parent.Parent.Left;
                        while (!rightPart.IsRegular)
                        {
                            rightPart = rightPart.Right;
                        }

                        rightPart.RegularValue += leftAddition;
                    }
                }
                else
                {
                    var leftPart = Parent.Left;
                    while (!leftPart.IsRegular)
                    {
                        leftPart = leftPart.Right;
                    }

                    leftPart.RegularValue += leftAddition;
                    var parent = Parent;
                    while (parent is { IsLeftPart: false })
                    {
                        parent = parent.Parent;
                    }

                    if (parent != null && parent.Parent != null)
                    {
                        leftPart = parent.Parent.Right;
                        while (!leftPart.IsRegular)
                        {
                            leftPart = leftPart.Left;
                        }

                        leftPart.RegularValue += rightAddition;
                    }
                }

                Left = null;
                Right = null;
                IsRegular = true;
                RegularValue = 0;
                return true;
            }
        }

        private bool Split()
        {
            if (IsRegular && RegularValue >= 10)
            {
                var split = new SnailFishNumber
                {
                    Parent = Parent,
                    IsLeftPart = IsLeftPart,
                    Left = new SnailFishNumber
                    {
                        RegularValue = RegularValue / 2,
                        IsRegular = true,
                        IsLeftPart = true
                    },
                    Right = new SnailFishNumber
                    {
                        RegularValue = (RegularValue + 1) / 2,
                        IsRegular = true
                    }
                };
                split.Left.Parent = split;
                split.Right.Parent = split;
                if (IsLeftPart)
                {
                    Parent.Left = split;
                }
                else
                {
                    Parent.Right = split;
                }

                return true;
            }
            else if (!IsRegular)
            {
                return Left.Split() || Right.Split();
            }
            return false;
        }

        public long Magnitude()
        {
            if (IsRegular)
            {
                return RegularValue;
            }

            return 3 * Left.Magnitude() + 2 * Right.Magnitude();
        }

        public SnailFishNumber Copy()
        {
            return new SnailFishNumber
            {
                IsRegular = IsRegular,
                IsLeftPart = IsLeftPart,
                Left = Left?.Copy(),
                Right = Right?.Copy(),
                RegularValue = RegularValue
            };
        }

        public override string ToString()
        {
            if (IsRegular)
            {
                return $"{RegularValue}";
            }
            else
            {
                return $"[{Left},{Right}]";
            }
        }

        void SetParent(SnailFishNumber parent)
        {
            Parent = parent;
            Left?.SetParent(this);
            Right?.SetParent(this);
        }

        public static SnailFishNumber operator + (SnailFishNumber lhs, SnailFishNumber rhs)
        {
            var sum = new SnailFishNumber
            {
                Left = lhs.Copy(),
                Right = rhs.Copy()
            };

            sum.Left.IsLeftPart = true;
            sum.SetParent(null);
            return sum.Reduce();
        }
    }

    public override int Nummer => 202118;
}