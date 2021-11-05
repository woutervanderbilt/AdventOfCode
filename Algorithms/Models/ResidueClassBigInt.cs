using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models
{
    public class ResidueClassBigInt
    {
        public ResidueClassBigInt(BigInteger value, BigInteger modulus)
        {
            Value = value % modulus + (value < 0 ? modulus : 0);
            Modulus = modulus;
        }
        public BigInteger Value { get; set; }
        public BigInteger Modulus { get; set; }

        public static ResidueClassBigInt operator +(ResidueClassBigInt l, ResidueClassBigInt r)
        {
            if(l.Modulus != r.Modulus)
            {
                throw new ArgumentException("Moduli komen niet overen", nameof(l));
            }
            return new ResidueClassBigInt(l.Value + r.Value, l.Modulus);
        }

        public static ResidueClassBigInt operator *(ResidueClassBigInt l, ResidueClassBigInt r)
        {
            if (l.Modulus != r.Modulus)
            {
                throw new ArgumentException("Moduli komen niet overen", nameof(l));
            }
            return new ResidueClassBigInt(l.Value * r.Value, l.Modulus);
        }

        public static ResidueClassBigInt operator -(ResidueClassBigInt r)
        {
            return new ResidueClassBigInt(r.Modulus - r.Value, r.Modulus);
        }

        public static ResidueClassBigInt operator -(ResidueClassBigInt l, ResidueClassBigInt r)
        {
            if (l.Modulus != r.Modulus)
            {
                throw new ArgumentException("Moduli komen niet overen", nameof(l));
            }
            return new ResidueClassBigInt(l.Value -r.Value, l.Modulus);
        }

        public static ResidueClassBigInt operator +(ResidueClassBigInt l, long r)
        {
            return new ResidueClassBigInt(l.Value + (r % l.Modulus), l.Modulus);
        }

        public static ResidueClassBigInt operator -(ResidueClassBigInt l, long r)
        {
            return new ResidueClassBigInt(l.Value - (r % l.Modulus), l.Modulus);
        }
        public static ResidueClassBigInt operator *(ResidueClassBigInt l, long r)
        {
            return new ResidueClassBigInt(l.Value * (r % l.Modulus), l.Modulus);
        }

        public ResidueClassBigInt ToThePower(BigInteger n)
        {
            BigInteger result = 1;
            BigInteger currentPower = Value;
            while (n > 0)
            {
                if (n % 2 == 1)
                {
                    result = result * currentPower % Modulus;
                }

                currentPower = currentPower * currentPower % Modulus;
                n /= 2;
            }

            return new ResidueClassBigInt(result, Modulus);
        }

        public ResidueClassBigInt Inverse()
        {
            BigInteger a = Value;
            BigInteger m = Modulus;
            BigInteger t, q;
            BigInteger x0 = 0;
            BigInteger x1 = 1;
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

            return new ResidueClassBigInt(x1 < 0 ? x1 + Modulus : x1, Modulus);
        }

        public ResidueClassBigInt Chinese(ResidueClassBigInt other)
        {
            var (u, _, gcd) = EulerMath.ExtendedEuclidean(Modulus, other.Modulus);
            var lcm = Modulus / gcd * other.Modulus;
            if (Value % gcd != other.Value % gcd)
            {
                throw new ArgumentException("Geen oplossing");
            }

            var l = (Value - other.Value) / gcd;
            return new ResidueClassBigInt(Value - Modulus * u * l, lcm);
        }

        public override string ToString()
        {
            return $"{Value} ({Modulus})";
        }
    }
}
