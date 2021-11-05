using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public struct Rational : IComparable<Rational>
    {
        public static readonly Rational Zero = new Rational(0,1);

        public Rational(long numerator, long denominator)
        {
            var gcd = EulerMath.GCD(numerator, denominator);
            var denominatorNegativeFactor = denominator > 0 ? 1 : -1;
            Numerator = denominatorNegativeFactor*numerator / gcd;
            Denominator = denominatorNegativeFactor*denominator / gcd;
        }

        public long Numerator { get; }
        public long Denominator { get; }

        public bool IsInteger => Denominator == 1;

        public Rational Inverse => new Rational(Denominator, Numerator);

        public static Rational operator +(Rational l, Rational r)
        {
            return new Rational(l.Numerator * r.Denominator + l.Denominator * r.Numerator, l.Denominator * r.Denominator);
        }

        public static Rational operator *(Rational l, Rational r)
        {
            return new Rational(l.Numerator * r.Numerator, l.Denominator * r.Denominator);
        }

        public static Rational operator -(Rational l, Rational r)
        {
            return new Rational(l.Numerator * r.Denominator - l.Denominator * r.Numerator, l.Denominator * r.Denominator);
        }

        public static Rational operator /(Rational l, Rational r)
        {
            if (r.Denominator == 0)
            {
                throw new DivideByZeroException();
            }
            return new Rational(l.Numerator * r.Denominator, l.Denominator * r.Numerator);
        }

        public static Rational operator -(Rational r)
        {
            return new Rational(-r.Numerator, r.Denominator);
        }

        public static implicit operator Rational(byte i)
        {
            return new Rational(i, 1);
        }

        public static implicit operator Rational(short i)
        {
            return new Rational(i, 1);
        }

        public static implicit operator Rational(int i)
        {
            return new Rational(i, 1);
        }

        public static implicit operator Rational(long i)
        {
            return new Rational(i, 1);
        }

        public static explicit operator double(Rational r)
        {
            return (double) r.Numerator / r.Denominator;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Rational r)
            {
                return r.Denominator == Denominator && r.Numerator == Numerator;
            }

            return false;
        }

        public bool Equals(Rational other)
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

        public int CompareTo(Rational other)
        {
            return (Numerator * other.Denominator).CompareTo(Denominator * other.Numerator);
        }

        public static bool operator <(Rational left, Rational right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Rational left, Rational right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Rational left, Rational right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Rational left, Rational right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
