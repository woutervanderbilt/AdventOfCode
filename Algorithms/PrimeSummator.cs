using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms;

public class PrimeSummator
{
    private long modulus;
    private IDictionary<long, long> S = new Dictionary<long, long>();
        
    public PrimeSummator(long modulus)
    {
        this.modulus = modulus;

    }

    public long Sum(long l)
    {
        if(!S.ContainsKey(l))
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
            if (i % 2 == 0)
            {
                S[i] = (((i / 2) % modulus) * ((i + 1) % modulus) - 1 + modulus) % modulus;
            }
            else
            {
                S[i] = ((i % modulus) * ((i + 1)/2 % modulus) - 1 + modulus) % modulus;
            }

                
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

                    S[i] -= p * (S[i / p] - sp);
                    S[i] = S[i] % modulus;
                    if (S[i] < 0)
                    {
                        S[i] += modulus;
                    }
                }
            }
        }
    }

}