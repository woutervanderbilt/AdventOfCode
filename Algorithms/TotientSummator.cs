using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms;

public class TotientSummator
{
    private readonly long modulus;
    private IDictionary<long, long> TotientSums { get; }

    public TotientSummator(long modulus)
    {
        this.modulus = modulus;
        TotientSums = new Dictionary<long, long>();
    }

    public long GetTotientSum(long l)
    {
        if (TotientSums.ContainsKey(l))
        {
            return TotientSums[l];
        }

        var s = ComputeTotientSum(l);
        TotientSums[l] = s;
        return s;
    }

    private long ComputeTotientSum(long l)
    {
        var lmod = l % modulus;
        var result = ((lmod * (lmod + 1)) / 2) % modulus;
        for (long m = 2; m * m <= l; m++)
        {
            result = result - GetTotientSum(l / m);
            if (result < 0)
            {
                result += modulus;
            }
        }

        for (long d = 1; d * d <= l; d++)
        {
            if (d != l / d)
            {
                result = result - (l / d - l / (d + 1)) * GetTotientSum(d);
                if (result < 0)
                {
                    result += modulus;
                }
            }
        }

        return result;
    }
}