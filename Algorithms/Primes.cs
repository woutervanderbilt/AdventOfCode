using System;
using System.Collections.Generic;


namespace Algorithms;

public class Primes
{
    private int Limit { get; }
    private bool[] compositeFlags;
    private IList<long> primes = new List<long> { 2 };
    private bool isInitialized = false;
    private int LengthOfList;

    public Primes(int limit)
    {
        Limit = limit;
        LengthOfList = (Limit - 1) / 2;
        compositeFlags = new bool[LengthOfList];
    }

    public Primes Initialize()
    {
        for (long i = 0; i < LengthOfList; i++)
        {
            if (compositeFlags[i])
            {
                continue;
            }
            var p = 2 * i + 3;
            primes.Add(p);
            for (long j = 2*i*i+6*i+3; j < LengthOfList; j += p)
            {
                compositeFlags[j] = true;
            }
        }
        isInitialized = true;
        return this;
    }

    public long this[int i]
    {
        get
        {
            if (!isInitialized)
            {
                Initialize();
            }

            return primes[i];
        }
    }


    public bool IsPrime(long p)
    {
        if (p < 2)
        {
            return false;
        }
        if (p % 2 == 0)
        {
            return p == 2;
        }

        if (!isInitialized)
        {
            Initialize();
        }

        if (p < Limit)
        {
            return !compositeFlags[(p - 3) / 2];
        }

        if ((long)Limit * Limit < p)
        {
            throw new Exception("Not enough precomputed primes");
        }
        foreach (var prime in primes)
        {
            if (p % prime == 0)
            {
                return false;
            }

            if (prime * prime > p)
            {
                return true;
            }
        }

        return true;
    }

    public int PrimePi(int l)
    {
        if (l > Limit)
        {
            throw new ArgumentException(nameof(l));
        }
        if (!isInitialized)
        {
            Initialize();
        }

        if (l < 2)
        {
            return 0;
        }
        return ComputePrimePi(l, 0, primes.Count);
    }

    private int ComputePrimePi(int l, int left, int right)
    {
        if (left == right - 1)
        {
            return right;
        }

        int mid = (left + right) / 2;
        var p = primes[mid];
        if (p == l)
        {
            return mid + 1;
        }

        return p < l ? ComputePrimePi(l, mid, right) : ComputePrimePi(l, left, mid);
    }

    public IEnumerable<long> AllPrimes()
    {
        if (!isInitialized)
        {
            Initialize();
        }
        foreach (var prime in primes)
        {
            yield return prime;
        }
    }
}