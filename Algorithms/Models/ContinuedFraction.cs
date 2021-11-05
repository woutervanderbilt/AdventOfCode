using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Models
{
    public struct ContinuedFraction
    {
        public ContinuedFraction(IList<long> values, int? repeatIndex = null)
        {
            Values = values;
            RepeatIndex = repeatIndex;
        }

        public IList<long> Values { get; private set; }

        public int? RepeatIndex { get; private set; }
        
        public Rational ComputeFraction(int depth)
        {
            List<long> valuesToUse = Values.ToList();
            if (depth > valuesToUse.Count)
            {
                if (!RepeatIndex.HasValue)
                {
                    throw new ArgumentException("Depth too large", nameof(depth));
                }

                IList<long> repeatingPart = Values.Skip(RepeatIndex.Value).ToList();
                while (depth > valuesToUse.Count)
                {
                    valuesToUse.AddRange(repeatingPart);
                }
            }
            Rational result = 0;
            bool first = true;
            foreach (var value in valuesToUse.Take(depth).Reverse())
            {
                if (!first)
                {
                    result = result.Inverse;
                }
                else
                {
                    first = false;
                }

                result += value;
            }

            return result;
        }

        public long Coefficient(int index)
        {
            if (index < Values.Count)
            {
                return Values[index];
            }

            if (!RepeatIndex.HasValue)
            {
                throw new ArgumentException("Index too high", nameof(index));
            }

            int period = Values.Count - RepeatIndex.Value;
            return Values[index - ((index - Values.Count) / period + 1) * period];
        }

        public static ContinuedFraction ContinuedFractionOfSquareRoot(long s)
        {
            IDictionary<(long m, long d, long a), int> triples = new Dictionary<(long m, long d, long a), int>();
            long m = 0;
            long d = 1;
            long a = (long) Math.Sqrt(s);
            long a0 = a;
            int index = 0;
            IList<long> values = new List<long>();
            while (!triples.ContainsKey((m,d,a)))
            {
                values.Add(a);
                triples[(m, d, a)] = index;
                m = d * a - m;
                d = (s - m * m) / d;
                a = (a0 + m) / d;
                index++;
            }
            return new ContinuedFraction(values, triples[(m,d,a)]);
        }
    }
}
