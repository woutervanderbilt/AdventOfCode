using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2022;

internal class Dag13 : Problem
{
    public override async Task ExecuteAsync()
    {
        IList<(string, string)> pairs = new List<(string, string)>();
        string? left = null;
        foreach (var line in Input.Split(Environment.NewLine))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                left = null;
                continue;
            }

            if (left == null)
            {
                left = line;
            }
            else
            {
                pairs.Add((left, line));
            }
        }

        long result = 0;
        for (int index = 1; index <= pairs.Count; index++)
        {
            if (Compare(pairs[index - 1]))
            {
                Console.WriteLine(index);
                result += index;
            }
        }

        List<ListData> list = Input.Split(Environment.NewLine).Where(l => !string.IsNullOrWhiteSpace(l))
            .Select(Parse)
            .ToList();
        list.Add(Parse("[[2]]"));
        list.Add(Parse("[[6]]"));
        list.Sort();
        int i = 1;
        long r = 1;
        foreach (var listData in list)
        {
            if (listData.IsDivider())
            {
                r *= i;
            }

            i++;
        }
        Result = (result, r).ToString();
    }

    bool Compare((string left, string right) pair)
    {
        ListData leftData = Parse(pair.left);
        ListData rightData = Parse(pair.right);
        return Compare(leftData, rightData).Value;
    }

    bool? Compare(ListData left, ListData right)
    {
        if (left.IsList && !right.IsList)
        {
            return Compare(left, new ListData { IsList = true, Values = new List<ListData> { right } });
        }

        if (!left.IsList && right.IsList)
        {
            return Compare(new ListData { IsList = true, Values = new List<ListData> { left } }, right);
        }

        if (left.IsList && right.IsList)
        {
            int index = 0;
            foreach (var leftValue in left.Values)
            {
                if (right.Values.Count <= index)
                {
                    return false;
                }

                var compare = Compare(leftValue, right.Values[index]);
                if (compare.HasValue)
                {
                    return compare.Value;
                }

                index++;
            }

            return left.Values.Count == right.Values.Count ? null : left.Values.Count < right.Values.Count;
        }

        return left.Value == right.Value ? null : left.Value < right.Value;
    }

    ListData Parse(string s)
    {
        Stack<ListData> stack = new Stack<ListData>();
        ListData? currentList = null;
        string value = "";
        foreach (var c in s)
        {
            if (c == '[')
            {
                if (currentList != null)
                {
                    stack.Push(currentList);
                }
                currentList = new ListData { IsList = true };
            }
            else if (c == ']')
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    currentList.Values.Add(new ListData { IsList = false, Value = int.Parse(value) });
                    value = "";
                }
                if (stack.Any())
                {
                    var previous = stack.Pop();
                    previous.Values.Add(currentList);
                    currentList = previous;
                }
                else
                {
                    currentList.s = s;
                    return currentList;
                }
            }
            else if (c == ',')
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    currentList.Values.Add(new ListData { IsList = false, Value = int.Parse(value) });
                    value = "";
                }
            }
            else
            {
                if (char.IsDigit(c))
                {
                    value += c;
                }
            }
        }

        return stack.Pop();
    }


    private class ListData : IComparable<ListData>
    {
        public IList<ListData> Values { get; set; } = new List<ListData>();
        public int? Value { get; set; }
        public bool IsList { get; set; }
        public string s { get; set; }

        public bool IsDivider()
        {
            return s == "[[2]]" || s == "[[6]]";
        }

        public int CompareTo(ListData other)
        {
            var c = Compare(this, other);
            return c.HasValue ? c.Value ? -1 : 1 : 0;
        }

        public override string ToString() => s;



        private bool? Compare(ListData left, ListData right)
        {
            if (left.IsList && !right.IsList)
            {
                return Compare(left, new ListData { IsList = true, Values = new List<ListData> { right } });
            }

            if (!left.IsList && right.IsList)
            {
                return Compare(new ListData { IsList = true, Values = new List<ListData> { left } }, right);
            }

            if (left.IsList && right.IsList)
            {
                int index = 0;
                foreach (var leftValue in left.Values)
                {
                    if (right.Values.Count <= index)
                    {
                        return false;
                    }

                    var compare = Compare(leftValue, right.Values[index]);
                    if (compare.HasValue)
                    {
                        return compare.Value;
                    }

                    index++;
                }

                return left.Values.Count == right.Values.Count ? null : left.Values.Count < right.Values.Count;
            }

            return left.Value == right.Value ? null : left.Value < right.Value;
        }
    }

    public override int Nummer => 202213;
}