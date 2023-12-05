using System;
using System.Numerics;

namespace Algorithms.Models;

public struct RationalBigInteger : IComparable<RationalBigInteger>
{
    public RationalBigInteger(BigInteger numerator, BigInteger denominator)
    {
        var gcd = EulerMath.GCD(numerator, denominator);
        var denominatorNegativeFactor = denominator > 0 ? 1 : -1;
        Numerator = denominatorNegativeFactor * numerator / gcd;
        Denominator = denominatorNegativeFactor * denominator / gcd;
    }

    public BigInteger Numerator { get; }
    public BigInteger Denominator { get; }

    public bool IsInteger => Denominator == 1;

    public RationalBigInteger Inverse => new RationalBigInteger(Denominator, Numerator);

    public static RationalBigInteger operator +(RationalBigInteger l, RationalBigInteger r)
    {
        return new RationalBigInteger(l.Numerator * r.Denominator + l.Denominator * r.Numerator, l.Denominator * r.Denominator);
    }

    public static RationalBigInteger operator *(RationalBigInteger l, RationalBigInteger r)
    {
        return new RationalBigInteger(l.Numerator * r.Numerator, l.Denominator * r.Denominator);
    }

    public static RationalBigInteger operator -(RationalBigInteger l, RationalBigInteger r)
    {
        return new RationalBigInteger(l.Numerator * r.Denominator - l.Denominator * r.Numerator, l.Denominator * r.Denominator);
    }

    public static RationalBigInteger operator /(RationalBigInteger l, RationalBigInteger r)
    {
        if (r.Denominator == 0)
        {
            throw new DivideByZeroException();
        }
        return new RationalBigInteger(l.Numerator * r.Denominator, l.Denominator * r.Numerator);
    }

    public static RationalBigInteger operator -(RationalBigInteger r)
    {
        return new RationalBigInteger(-r.Numerator, r.Denominator);
    }

    public static implicit operator RationalBigInteger(byte i)
    {
        return new RationalBigInteger(i, 1);
    }

    public static implicit operator RationalBigInteger(short i)
    {
        return new RationalBigInteger(i, 1);
    }

    public static implicit operator RationalBigInteger(int i)
    {
        return new RationalBigInteger(i, 1);
    }

    public static implicit operator RationalBigInteger(long i)
    {
        return new RationalBigInteger(i, 1);
    }

    public static implicit operator RationalBigInteger(BigInteger i)
    {
        return new RationalBigInteger(i, 1);
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }

    public override bool Equals(object obj)
    {
        if (obj is RationalBigInteger r)
        {
            return r.Denominator == Denominator && r.Numerator == Numerator;
        }

        return false;
    }

    public bool Equals(RationalBigInteger other)
    {
        return Numerator == other.Numerator && Denominator == other.Denominator;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (Numerator.GetHashCode() * 397) ^ Denominator.GetHashCode();
        }
    }

    public int CompareTo(RationalBigInteger other)
    {
        return (Numerator * other.Denominator).CompareTo(Denominator * other.Numerator);
    }

    public static bool operator <(RationalBigInteger left, RationalBigInteger right)
    {
        return left.CompareTo(right) < 0;
    }

    public static bool operator >(RationalBigInteger left, RationalBigInteger right)
    {
        return left.CompareTo(right) > 0;
    }

    public static bool operator <=(RationalBigInteger left, RationalBigInteger right)
    {
        return left.CompareTo(right) <= 0;
    }

    public static bool operator >=(RationalBigInteger left, RationalBigInteger right)
    {
        return left.CompareTo(right) >= 0;
    }
}