using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Extensions;

public static class NumberExtensions
{
    public static IList<IList<int>> Partitions(this int n)
    {
        var cache = new Dictionary<(int,int), IList<IList<int>>>();

        IList<IList<int>> result = new List<IList<int>>();
        for (int m = 1; m <= n; m++)
        {
            foreach (var partition in Partitions(m, n-m))
            {
                var copy = partition.ToList();
                copy.Add(m);
                result.Add(copy);
            }
        }

        return result;

        IList<IList<int>> Partitions(int m, int t)
        {
            if (t == 0)
            {
                return new List<IList<int>>{new List<int>()};
            }
            if (cache.ContainsKey((m, t)))
            {
                return cache[(m, t)];
            }
            IList<IList<int>> intermediateResult = new List<IList<int>>();
            for (int i = 1; i <= m && i <= t; i++)
            {
                foreach (var partition in Partitions(i, t-i))
                {
                    var copy = partition.ToList();
                    copy.Add(i);
                    intermediateResult.Add(copy);
                }
            }

            cache[(m, n)] = intermediateResult;
            return intermediateResult;
        }



    }


    public static long Reverse(this long n, int b = 10)
    {
        long result = 0;
        while (n > 0)
        {
            result *= b;
            result += n % b;
            n /= b;
        }

        return result;
    }

    public static long Reverse(this int n, int b = 10)
    {
        long result = 0;
        while (n > 0)
        {
            result *= b;
            result += n % b;
            n /= b;
        }

        return result;
    }

    public static BigInteger Reverse(this BigInteger n, int b = 10)
    {
        BigInteger result = 0;
        while (n > 0)
        {
            result *= b;
            result += n % b;
            n /= b;
        }

        return result;
    }

    public static long Reverse(this short n, short b = 10)
    {
        long result = 0;
        while (n > 0)
        {
            result *= b;
            result += n % b;
            n /= b;
        }

        return result;
    }

    public static bool IsPalindrome(this long n)
    {
        return n == n.Reverse();
    }

    public static bool IsPalindrome(this int n)
    {
        return n == n.Reverse();
    }

    public static bool IsPalindrome(this short n)
    {
        return n == n.Reverse();
    }

    public static bool IsSquare(this long l)
    {
        var s = (long)Math.Sqrt(l);
        return s * s == l;
    }

    public static bool IsSquare(this int l)
    {
        var s = (int)Math.Sqrt(l);
        return s * s == l;
    }

    public static bool IsSquare(this short l)
    {
        var s = (short)Math.Sqrt(l);
        return s * s == l;
    }

    public static int DigitSum(this int l, int numberBase = 10)
    {
        int result = 0;
        while (l > 0)
        {
            result += (l % numberBase);
            l /= numberBase;
        }

        return result;
    }

    public static int DigitSum(this long l, int numberBase = 10)
    {
        int result = 0;
        while (l > 0)
        {
            result += (int)(l % numberBase);
            l /= numberBase;
        }

        return result;
    }

    public static int DigitSum(this BigInteger l, int numberBase = 10)
    {
        int result = 0;
        while (l > 0)
        {
            result += (int)(l % numberBase);
            l /= numberBase;
        }

        return result;
    }

    public static int NumberOfDigits(this long l, int numberBase = 10)
    {
        int result = 0;
        while (l > 0)
        {
            l /= numberBase;
            result++;
        }

        return result;
    }

    public static int FirstDigit(this long l, int numberBase = 10)
    {
        while (l >= numberBase)
        {
            l /= numberBase;
        }

        return (int)l;
    }

    public static IEnumerable<int> Digits(this long l, int numberBase = 10)
    {
        var reverse = l.Reverse(numberBase);
        long yielded = 0;
        while (reverse > 0)
        {
            var toYield = (int) (reverse % numberBase);
            yield return toYield;
            yielded *= numberBase;
            yielded += toYield;
            reverse /= numberBase;
        }

        while (yielded != l)
        {
            yield return 0;
            yielded *= numberBase;
        }
    }

    public static IEnumerable<int> Digits(this BigInteger l, int numberBase = 10)
    {
        var reverse = l.Reverse(numberBase);
        BigInteger yielded = 0;
        while (reverse > 0)
        {
            var toYield = (int)(reverse % numberBase);
            yield return toYield;
            yielded *= 10;
            yielded += toYield;
            reverse /= numberBase;
        }

        while (yielded != l)
        {
            yield return 0;
            yielded *= 10;
        }
    }

    public static short Valuation(this long l, long p)
    {
        short v = 0;
        while (l % p == 0)
        {
            l /= p;
            v++;
        }

        return v;
    }

    public static decimal Sqrt(this decimal x, decimal epsilon = 0.0M)
    {
        if (x < 0) throw new OverflowException("Cannot calculate square root from a negative number");

        decimal current = (decimal)Math.Sqrt((double)x), previous;
        do
        {
            previous = current;
            if (previous == 0.0M) return 0;
            current = (previous + x / previous) / 2;
        }
        while (Math.Abs(previous - current) > epsilon);
        return current;
    }

    public static bool IsCoprimeWith(this int a, int b)
    {
        return EulerMath.GCD(a, b) == 1;
    }

    public static bool IsCoprimeWith(this long a, long b)
    {
        return EulerMath.GCD(a, b) == 1;
    }
}