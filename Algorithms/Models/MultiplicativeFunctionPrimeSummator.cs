using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Models;

public class MultiplicativeFunctionPrimeSummator
{
    private IDictionary<long, long> S = new Dictionary<long, long>();

    public MultiplicativeFunctionPrimeSummator(long mod, Func<long, long> f, Func<long, long> summation)
    {
        Mod = mod;
        F = f;
        Summation = summation;
    }

    public long Mod { get; }
    private Func<long, long> F { get; }
    private Func<long, long> Summation { get; }

    public long Sum(long l)
    {
        if (!S.ContainsKey(l))
        {
            Initialize(l);
        }

        return S[l];
    }

    private void Initialize(long l)
    {
        IList<long> v = new List<long>();
        long sqrt = 0;
        for (long k = 1; k * k <= l; k++)
        {
            sqrt = l / k;
            v.Add(sqrt);
        }

        for (long k = sqrt - 1; k >= 0; k--)
        {
            v.Add(k);
        }

        foreach (var i in v)
        {
            S[i] = Summation(i) - 1;
        }

        S[0] = 0;
        for (var p = 1; p <= sqrt + 1; p++)
        {
            if (S[p] != S[p - 1])
            {
                var sp = S[p - 1];
                var p2 = (long)p * p;
                foreach (var i in v)
                {
                    if (i < p2)
                    {
                        break;
                    }

                    S[i] -= F(p) * (S[i / p] - sp);
                    S[i] = S[i] % Mod;
                    if (S[i] < 0)
                    {
                        S[i] += Mod;
                    }
                }
            }
        }
    }
}