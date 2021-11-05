using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public struct PhiNumber
    {
        public PhiNumber(Rational a, Rational b)
        {
            RationalPart = a;
            PhiPart = b;
        }

        public Rational RationalPart { get; }
        public Rational PhiPart { get; }

        public PhiNumber Inverse => new PhiNumber(RationalPart/(RationalPart * RationalPart - 5 * PhiPart * PhiPart), -PhiPart/(RationalPart * RationalPart - 5 * PhiPart * PhiPart));

        public bool IsRational => PhiPart.Numerator == 0;

        public bool IsInteger => IsRational && RationalPart.Denominator == 1;

        public double RealValue => (double)RationalPart + (double)PhiPart * Math.Sqrt(5);
        public static PhiNumber operator +(PhiNumber x, PhiNumber y)
        {
            return new PhiNumber(x.RationalPart + y.RationalPart, x.PhiPart + y.PhiPart);
        }

        public static PhiNumber operator -(PhiNumber x, PhiNumber y)
        {
            return new PhiNumber(x.RationalPart - y.RationalPart, x.PhiPart - y.PhiPart);
        }

        public static PhiNumber operator *(PhiNumber x, PhiNumber y)
        {
            return new PhiNumber(x.RationalPart * y.RationalPart + 5 * x.PhiPart * y.PhiPart, x.RationalPart * y.PhiPart + x.PhiPart * y.RationalPart);
        }

        public static PhiNumber operator /(PhiNumber x, PhiNumber y)
        {
            if (y.RationalPart.Numerator == 0 && y.PhiPart.Numerator == 0)
            {
                throw new DivideByZeroException();
            }

            return x * y.Inverse;
        }

        public static implicit operator PhiNumber(byte i)
        {
            return new PhiNumber(i,0);
        }

        public static implicit operator PhiNumber(short i)
        {
            return new PhiNumber(i, 0);
        }

        public static implicit operator PhiNumber(int i)
        {
            return new PhiNumber(i, 0);
        }

        public static implicit operator PhiNumber(long i)
        {
            return new PhiNumber(i, 0);
        }

        public override string ToString()
        {
            return $"{RationalPart} + {PhiPart}√5";
        }
    }
}
