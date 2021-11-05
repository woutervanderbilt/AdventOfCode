using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Models
{
    public class QuadraticIntegerResidueClass
    {
        public QuadraticIntegerResidueClass(QuadraticInteger value, long modulus)
        {
            Value = new QuadraticInteger(value.RationalPart % modulus + (value.RationalPart < 0 ? modulus : 0),
                value.QuadraticPart % modulus + (value.QuadraticPart < 0 ? modulus : 0), value.Square);
            Modulus = modulus;
            Square = value.Square;
        }
        public QuadraticInteger Value { get; set; }
        public long Modulus { get; }
        public long Square { get; }

        public static QuadraticIntegerResidueClass operator +(QuadraticIntegerResidueClass l, QuadraticIntegerResidueClass r)
        {
            if (l.Modulus != r.Modulus)
            {
                throw new ArgumentException("Moduli komen niet overen", nameof(l));
            }
            return new QuadraticIntegerResidueClass(l.Value + r.Value, l.Modulus);
        }

        public static QuadraticIntegerResidueClass operator *(QuadraticIntegerResidueClass l, QuadraticIntegerResidueClass r)
        {
            if (l.Modulus != r.Modulus)
            {
                throw new ArgumentException("Moduli komen niet overen", nameof(l));
            }
            return new QuadraticIntegerResidueClass(l.Value * r.Value, l.Modulus);
        }
        
        public static QuadraticIntegerResidueClass operator -(QuadraticIntegerResidueClass l, QuadraticIntegerResidueClass r)
        {
            if (l.Modulus != r.Modulus)
            {
                throw new ArgumentException("Moduli komen niet overen", nameof(l));
            }
            return new QuadraticIntegerResidueClass(l.Value - r.Value, l.Modulus);
        }

        public QuadraticIntegerResidueClass ToThePower(long n)
        {
            var result = new QuadraticIntegerResidueClass(new QuadraticInteger(1,0, Square), Modulus);
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
