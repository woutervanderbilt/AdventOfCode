using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models;

public struct GaussianInteger
{
    public static readonly GaussianInteger I = new GaussianInteger(0, 1);

    public GaussianInteger(long realPart, long imaginaryPart)
    {
        RealPart = realPart;
        ImaginaryPart = imaginaryPart;
    }

    public long RealPart { get; }
    public long ImaginaryPart { get; }

    public static GaussianInteger operator +(GaussianInteger l, GaussianInteger r) => new GaussianInteger(l.RealPart + r.RealPart, l.ImaginaryPart + r.ImaginaryPart);

    public static GaussianInteger operator -(GaussianInteger l, GaussianInteger r) => new GaussianInteger(l.RealPart - r.RealPart, l.ImaginaryPart - r.ImaginaryPart);

    public static GaussianInteger operator *(GaussianInteger l, GaussianInteger r) => new GaussianInteger(l.RealPart * r.RealPart - l.ImaginaryPart * r.ImaginaryPart, l.RealPart * r.ImaginaryPart + l.ImaginaryPart * r.RealPart);

    public static GaussianInteger operator -(GaussianInteger c) => new GaussianInteger(-c.RealPart, c.ImaginaryPart);

    public static implicit operator GaussianInteger(long r)
    {
        return new GaussianInteger(r, 0);
    }
    public GaussianInteger Conjugate() => new GaussianInteger(RealPart, -ImaginaryPart);

    public GaussianInteger ToThePower(int e)
    {
        var power = this;
        var result = new GaussianInteger(1, 0);
        while (e > 0)
        {
            if (e % 2 == 1)
            {
                result = result * power;
            }

            power = power * power;
            e /= 2;
        }

        return result;
    }

    public override string ToString() => $"{RealPart} {(ImaginaryPart < 0 ? "-" : "+")} {(ImaginaryPart < 0 ? -ImaginaryPart : ImaginaryPart)}i";

    public override bool Equals(object? obj)
    {
        if (obj is GaussianInteger gaussianInteger)
        {
            return Equals(gaussianInteger);
        }

        return false;
    }

    public bool Equals(GaussianInteger other)
    {
        return RealPart == other.RealPart && ImaginaryPart == other.ImaginaryPart;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RealPart, ImaginaryPart);
    }
}