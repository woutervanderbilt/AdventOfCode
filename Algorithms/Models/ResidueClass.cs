using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models;

public class ResidueClass
{
    public ResidueClass(long value, long modulus)
    {
        Value = value % modulus + (value < 0 ? modulus : 0);
        Modulus = modulus;
    }
    public long Value { get; set; }
    public long Modulus { get; set; }

    public static ResidueClass operator +(ResidueClass l, ResidueClass r)
    {
        if(l.Modulus != r.Modulus)
        {
            throw new ArgumentException("Moduli komen niet overen", nameof(l));
        }
        return new ResidueClass(l.Value + r.Value, l.Modulus);
    }

    public static ResidueClass operator *(ResidueClass l, ResidueClass r)
    {
        if (l.Modulus != r.Modulus)
        {
            throw new ArgumentException("Moduli komen niet overen", nameof(l));
        }
        return new ResidueClass(l.Value * r.Value, l.Modulus);
    }

    public static ResidueClass operator -(ResidueClass r)
    {
        return new ResidueClass(r.Modulus - r.Value, r.Modulus);
    }

    public static ResidueClass operator -(ResidueClass l, ResidueClass r)
    {
        if (l.Modulus != r.Modulus)
        {
            throw new ArgumentException("Moduli komen niet overen", nameof(l));
        }
        return new ResidueClass(l.Value -r.Value, l.Modulus);
    }

    public static ResidueClass operator +(ResidueClass l, long r)
    {
        return new ResidueClass(l.Value + (r % l.Modulus), l.Modulus);
    }

    public static ResidueClass operator -(ResidueClass l, long r)
    {
        return new ResidueClass(l.Value - (r % l.Modulus), l.Modulus);
    }
    public static ResidueClass operator *(ResidueClass l, long r)
    {
        return new ResidueClass(l.Value * (r % l.Modulus), l.Modulus);
    }

    public static ResidueClass operator ++(ResidueClass l)
    {
        return new ResidueClass(l.Value + 1, l.Modulus);
    }

    public static ResidueClass operator --(ResidueClass l)
    {
        return new ResidueClass(l.Value - 1, l.Modulus);
    }

    public ResidueClass ToThePower(long n)
    {
        long result = 1;
        long currentPower = Value;
        while (n > 0)
        {
            if (n % 2 == 1)
            {
                result = result * currentPower % Modulus;
            }

            currentPower = currentPower * currentPower % Modulus;
            n /= 2;
        }

        return new ResidueClass(result, Modulus);
    }

    public ResidueClass Inverse()
    {
        long a = Value;
        long m = Modulus;
        long t, q;
        long x0 = 0;
        long x1 = 1;
        while (a > 1)
        {
            q = a / m;
            t = m;
            m = a % m;
            a = t;
            t = x0;
            x0 = x1 - q * x0;
            x1 = t;
        }

        return new ResidueClass(x1 < 0 ? x1 + Modulus : x1, Modulus);
    }

    public ResidueClass Chinese(ResidueClass other)
    {
        var (u, _, gcd) = EulerMath.ExtendedEuclidean(Modulus, other.Modulus);
        var lcm = Modulus / gcd * other.Modulus;
        if (Value % gcd != other.Value % gcd)
        {
            throw new ArgumentException("Geen oplossing");
        }

        var l = (Value - other.Value) / gcd;
        return new ResidueClass(Value - Modulus*u*l, lcm);
    }

    public override string ToString()
    {
        return $"{Value} ({Modulus})";
    }
}