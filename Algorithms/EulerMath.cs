using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms;

public static class EulerMath
{
    public static long GCD(long a, long b, params long[] c)
    {
        long gcd = GCD(a, b);
        foreach (var l in c)
        {
            if (gcd == 1)
            {
                return 1;
            }

            gcd = GCD(gcd, l);
        }

        return gcd;
    }

    public static long GCD(long a, long b)
    {
        if (a < 0)
        {
            a = -a;
        }

        if (b < 0)
        {
            b = -b;
        }
        if (b == 0)
        {
            return a;
        }

        if (a == 0)
        {
            return b;
        }
        if (a > b)
        {
            return GCD(b, a % b);
        }
        return GCD(a, b % a);
    }

    public static BigInteger GCD(BigInteger a, BigInteger b)
    {
        if (a < 0)
        {
            a = -a;
        }

        if (b < 0)
        {
            b = -b;
        }
        if (b == 0)
        {
            return a;
        }

        if (a == 0)
        {
            return b;
        }
        if (a > b)
        {
            return GCD(b, a % b);
        }
        return GCD(a, b % a);
    }

    public static long LCM(long a, long b, params long[] c)
    {
        long lcm = LCM(a, b);
        foreach (var l in c)
        {
            lcm = LCM(lcm, l);
        }

        return lcm;
    }

    public static long LCM(long a, long b)
    {
        return a / GCD(a, b) * b;
    }

    public static (long cxa, long cb, long gcd) ExtendedEuclidean(long a, long b)
    {
        long x0 = 1, xn = 1;
        long y0 = 0, yn = 0;
        long x1 = 0;
        long y1 = 1;
        long q;
        long r = a % b;

        while (r > 0)
        {
            q = a / b;
            xn = x0 - q * x1;
            yn = y0 - q * y1;

            x0 = x1;
            y0 = y1;
            x1 = xn;
            y1 = yn;
            a = b;
            b = r;
            r = a % b;
        }

        return (xn, yn, b);
    }

    public static (BigInteger cxa, BigInteger cb, BigInteger gcd) ExtendedEuclidean(BigInteger a, BigInteger b)
    {
        BigInteger x0 = 1, xn = 1;
        BigInteger y0 = 0, yn = 0;
        BigInteger x1 = 0;
        BigInteger y1 = 1;
        BigInteger q;
        BigInteger r = a % b;

        while (r > 0)
        {
            q = a / b;
            xn = x0 - q * x1;
            yn = y0 - q * y1;

            x0 = x1;
            y0 = y1;
            x1 = xn;
            y1 = yn;
            a = b;
            b = r;
            r = a % b;
        }

        return (xn, yn, b);
    }

    public static long NumberOfFactors(long n, long p)
    {
        long result = 0;
        long primePower = 1;
        while (n / p >= primePower)
        {
            primePower *= p;
            result += n / primePower;
        }

        return result;
    }

    public static (double, double) QuadraticFormula(double a, double b, double c)
    {
        var d = Math.Sqrt(b * b - 4 * a * c);
        return ((-b + d) / (2 * a), (-b - d) / (2 * a));
    }

    public static int Max(int a, int b, params int[] rest)
    {
        var max = Math.Max(a, b);
        foreach (var r in rest)
        {
            max = Math.Max(max, r);
        }

        return max;
    }
}