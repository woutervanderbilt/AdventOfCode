using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Algorithms.Models
{
    public struct QuadraticBigInteger
    {
        public QuadraticBigInteger(BigInteger a, BigInteger b, long square)
        {
            RationalPart = a;
            QuadraticPart = b;
            Square = square;
        }

        public BigInteger RationalPart { get; }
        public BigInteger QuadraticPart { get; }
        public long Square { get; }

        public bool IsIntegral => QuadraticPart == 0;

        public double RealValue => (double)RationalPart + (double)QuadraticPart * Math.Sqrt(Square);
        public static QuadraticBigInteger operator +(QuadraticBigInteger x, QuadraticBigInteger y)
        {
            return new QuadraticBigInteger(x.RationalPart + y.RationalPart, x.QuadraticPart + y.QuadraticPart, x.Square);
        }

        public static QuadraticBigInteger operator -(QuadraticBigInteger x, QuadraticBigInteger y)
        {
            return new QuadraticBigInteger(x.RationalPart - y.RationalPart, x.QuadraticPart - y.QuadraticPart, x.Square);
        }

        public static QuadraticBigInteger operator *(QuadraticBigInteger x, QuadraticBigInteger y)
        {
            return new QuadraticBigInteger(x.RationalPart * y.RationalPart + x.Square * x.QuadraticPart * y.QuadraticPart, x.RationalPart * y.QuadraticPart + x.QuadraticPart * y.RationalPart, x.Square);
        }

        public override string ToString()
        {
            return $"{RationalPart} + {QuadraticPart}√{Square}";
        }
    }
}
