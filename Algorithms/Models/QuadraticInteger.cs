using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public struct QuadraticInteger
    {
        public QuadraticInteger(long a, long b, long square)
        {
            RationalPart = a;
            QuadraticPart = b;
            Square = square;
        }

        public long RationalPart { get; }
        public long QuadraticPart { get; }
        public long Square { get; }

        public bool IsIntegral => QuadraticPart == 0;
        
        public double RealValue => (double)RationalPart + (double)QuadraticPart * Math.Sqrt(Square);
        public static QuadraticInteger operator +(QuadraticInteger x, QuadraticInteger y)
        {
            return new QuadraticInteger(x.RationalPart + y.RationalPart, x.QuadraticPart + y.QuadraticPart, x.Square);
        }

        public static QuadraticInteger operator -(QuadraticInteger x, QuadraticInteger y)
        {
            return new QuadraticInteger(x.RationalPart - y.RationalPart, x.QuadraticPart - y.QuadraticPart, x.Square);
        }

        public static QuadraticInteger operator *(QuadraticInteger x, QuadraticInteger y)
        {
            return new QuadraticInteger(x.RationalPart * y.RationalPart + x.Square * x.QuadraticPart * y.QuadraticPart, x.RationalPart * y.QuadraticPart + x.QuadraticPart * y.RationalPart, x.Square);
        }

        public override string ToString()
        {
            return $"{RationalPart} + {QuadraticPart}√{Square}";
        }
    }
}
