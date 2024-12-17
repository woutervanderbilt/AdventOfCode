using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithms.Extensions;
public static class StringExtensions
{
    private static readonly Regex NumbersRegex = new (@"-*\d+");
    public static IEnumerable<long> FindAllNumbers(this string s)
    {
        return NumbersRegex.Matches(s).Select(m => long.Parse(m.Value));
    }

    public static IEnumerable<int> FindAllNumbersAsInt(this string s)
    {
        return NumbersRegex.Matches(s).Select(m => int.Parse(m.Value));
    }
}
