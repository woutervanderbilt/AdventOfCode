using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class PrimeCounter
    {
        private IDictionary<long, long> S = new Dictionary<long, long>();
        private Primes smallPrimes = new Primes(200);

        public long PrimePi(long l)
        {
            if (l <= 200)
            {
                return smallPrimes.PrimePi((int)l);
            }
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
                S[i] = i - 1;
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

                        S[i] -= (S[i / p] - sp);
                    }
                }
            }
        }
    }
}
