using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Algorithms.Models
{
    public class QuadraticBigIntegerResidueClass
    {
        public QuadraticBigIntegerResidueClass(QuadraticBigInteger value, BigInteger modulus)
        {
            Value = new QuadraticBigInteger(value.RationalPart % modulus + (value.RationalPart < 0 ? modulus : 0),
                value.QuadraticPart % modulus + (value.QuadraticPart < 0 ? modulus : 0), value.Square);
            Modulus = modulus;
            Square = value.Square;
        }
        public QuadraticBigInteger Value { get; set; }
        public BigInteger Modulus { get; }
        public long Square { get; }

        public static QuadraticBigIntegerResidueClass operator +(QuadraticBigIntegerResidueClass l, QuadraticBigIntegerResidueClass r)
        {
            if (l.Modulus != r.Modulus)
            {
                throw new ArgumentException("Moduli komen niet overen", nameof(l));
            }
            return new QuadraticBigIntegerResidueClass(l.Value + r.Value, l.Modulus);
        }

        public static QuadraticBigIntegerResidueClass operator *(QuadraticBigIntegerResidueClass l, QuadraticBigIntegerResidueClass r)
        {
            if (l.Modulus != r.Modulus)
            {
                throw new ArgumentException("Moduli komen niet overen", nameof(l));
            }
            return new QuadraticBigIntegerResidueClass(l.Value * r.Value, l.Modulus);
        }

        public static QuadraticBigIntegerResidueClass operator -(QuadraticBigIntegerResidueClass l, QuadraticBigIntegerResidueClass r)
        {
            if (l.Modulus != r.Modulus)
            {
                throw new ArgumentException("Moduli komen niet overen", nameof(l));
            }
            return new QuadraticBigIntegerResidueClass(l.Value - r.Value, l.Modulus);
        }

        public QuadraticBigIntegerResidueClass ToThePower(long n)
        {
            var result = new QuadraticBigIntegerResidueClass(new QuadraticBigInteger(1, 0, Square), Modulus);
            var currentPower = this;
            while (n > 0)
            {
                if (n % 2 == 1)
                {
                    result = result * currentPower;
                }

                currentPower = currentPower * currentPower;
                n /= 2;
            }

            return result;
        }

        public override string ToString()
        {
            return $"{Value} ({Modulus})";
        }
    }
}
