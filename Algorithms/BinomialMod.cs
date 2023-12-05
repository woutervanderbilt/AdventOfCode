using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Algorithms;

public class BinomialMod
{
    private readonly IList<long> factorials = new List<long>();
    private readonly IList<long> inverseFactorials = new List<long>();
    private int maxFactorial = 0;

    public long Mod { get; }

    public BinomialMod(long mod)
    {
        Mod = mod;
        factorials.Add(1);
        inverseFactorials.Add(1);
    }

    public long Binomial(long n, long k)
    {
        if (k > n)
        {
            return 0;
        }
        if (n > Mod || k > Mod)
        {
            return Binomial(n / Mod, k / Mod) * Binomial(n % Mod, k % Mod) % Mod;
        }

        var intN = (int) n;
        var intK = (int) k;
        UpdateFactorial(intN);

        return factorials[intN] * inverseFactorials[intK] % Mod * inverseFactorials[intN- intK] % Mod;
    }

    public long Factorial(int n)
    {
        UpdateFactorial(n);
        return factorials[n];
    }

    private void UpdateFactorial(int n)
    {
        if (n > maxFactorial)
        {
            var lastFactorial = factorials[maxFactorial];
            for (long i = maxFactorial + 1; i <= n; i++)
            {
                lastFactorial = lastFactorial * i % Mod;
                factorials.Add(lastFactorial);
                inverseFactorials.Add(new ResidueClass(lastFactorial, Mod).Inverse().Value);
            }

            maxFactorial = n;
        }
    }

}