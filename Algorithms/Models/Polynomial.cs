using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Models
{
    public class Polynomial
    {
        private long Mod { get; }
        public int? MaxPower { get; }

        private IList<long> coefficients;

        public Polynomial(IList<long> coefficients, long mod, int? maxPower = null)
        {
            this.coefficients = coefficients;
            Mod = mod;
            MaxPower = maxPower;
        }

        public int Degree => coefficients.Count - 1;
        public long CoefficientOfXToTheN(int n) => coefficients[n];

        public Polynomial TimesXToTheN(int n)
        {
            var newCoefficients = new List<long>();
            for (int i = 1; i <= n; i++)
            {
                newCoefficients.Add(0);
            }
            newCoefficients.AddRange(coefficients);
            if (MaxPower.HasValue)
            {
                newCoefficients = newCoefficients.Take(MaxPower.Value + 1).ToList();
            }
            return new Polynomial(newCoefficients, Mod, MaxPower);
        }

        public static Polynomial operator +(Polynomial l, Polynomial r)
        {
            var sum = new List<long>();
            var lEnumerator = l.coefficients.GetEnumerator();
            var rEnumerator = r.coefficients.GetEnumerator();
            bool lBeforeEnd = lEnumerator.MoveNext();
            bool rBeforeEnd = rEnumerator.MoveNext();
            IList<long> partialSum = new List<long>();
            while (lBeforeEnd || rBeforeEnd)
            {
                long coefficient = 0;
                if (lBeforeEnd)
                {
                    coefficient += lEnumerator.Current;
                    lBeforeEnd = lEnumerator.MoveNext();
                }
                if (rBeforeEnd)
                {
                    coefficient += rEnumerator.Current;
                    rBeforeEnd = rEnumerator.MoveNext();
                }

                coefficient = coefficient % l.Mod;
                if (coefficient != 0 || !sum.Any())
                {
                    sum.AddRange(partialSum);
                    sum.Add(coefficient);
                    partialSum = new List<long>();
                }
                else
                {
                    partialSum.Add(coefficient);
                }
            }

            return new Polynomial(sum, l.Mod);
        }

        public static Polynomial operator *(Polynomial l, Polynomial r)
        {
            var product = new List<long>();
            var partialProduct = new List<long>();
            for (int d = 0; d <= l.Degree + r.Degree; d++)
            {
                long coefficient = 0;
                for (int d1 = 0; d1 <= d && d1 <= l.Degree; d1++)
                {
                    var d2 = d - d1;
                    if (d2 <= r.Degree)
                    {
                        coefficient = (coefficient + l.CoefficientOfXToTheN(d1) * r.CoefficientOfXToTheN(d2)) % l.Mod;
                    }
                }
                if (coefficient != 0 || !product.Any())
                {
                    product.AddRange(partialProduct);
                    product.Add(coefficient);
                    partialProduct = new List<long>();
                }
                else
                {
                    partialProduct.Add(coefficient);
                }
            }

            if (l.MaxPower.HasValue)
            {
                product = product.Take(l.MaxPower.Value + 1).ToList();
            }

            return new Polynomial(product, l.Mod, l.MaxPower);
        }

        public static Polynomial operator *(long l, Polynomial p)
        {
            return p * new Polynomial(new List<long> { l }, p.Mod);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            int power = Degree;
            bool first = true;
            foreach (var l in coefficients.Reverse())
            {
                if (l != 0)
                {
                    if (!first)
                    {
                        sb.Append("+");
                    }

                    if (l != 1 || power == 0)
                    {
                        sb.Append(l);
                    }

                    if (power != 0)
                    {
                        sb.Append("x");
                        if (power != 1)
                        {
                            sb.Append($"^{power}");
                        }
                    }
                }

                first = false;
                power--;
            }

            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            return Equals((Polynomial)obj);
        }

        protected bool Equals(Polynomial other)
        {
            return coefficients.SequenceEqual(other.coefficients);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                foreach (var coefficient in coefficients)
                {
                    hash = hash * 33 + coefficient.GetHashCode();
                }

                return hash;
            }
        }
    }
}
