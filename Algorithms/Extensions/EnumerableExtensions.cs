using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> source)
    {
        var list = source.ToList();
        if (!list.Any())
        {
            yield return Enumerable.Empty<T>();
        }
        else
        {
            var startingElementIndex = 0;

            foreach (var startingElement in list)
            {
                var remainingItems = list.Where((e, i) => i != startingElementIndex);

                foreach (var permutationOfRemainder in remainingItems.Permutations())
                {
                    yield return Concat(permutationOfRemainder);

                    IEnumerable<T> Concat(IEnumerable<T> secondSequence)
                    {
                        yield return startingElement;
                        if (secondSequence == null)
                        {
                            yield break;
                        }

                        foreach (var item in secondSequence)
                        {
                            yield return item;
                        }
                    }
                }

                startingElementIndex++;
            }
        }
    }

    public static IEnumerable<(T, T)> ConsecutivePairs<T>(this IEnumerable<T> source)
    {
        T prev = default;
        bool first = true;
        foreach (var item in source)
        {
            if (!first)
            {
                yield return ((prev, item));
            }

            prev = item;
            first = false;
        }
    }

    public static IEnumerable<(T item, int index)> Indexed<T>(this IEnumerable<T> source)
    {
        return source.Select((item, index) => (item, index));
    }

    public static IEnumerable<IEnumerable<T>> Subsets<T>(this IEnumerable<T> source)
    {
        List<T> list = source.ToList();
        int length = list.Count;
        int max = (int)Math.Pow(2, list.Count);

        for (int count = 0; count < max; count++)
        {
            List<T> subset = new List<T>();
            uint rs = 0;
            while (rs < length)
            {
                if ((count & (1u << (int)rs)) > 0)
                {
                    subset.Add(list[(int)rs]);
                }
                rs++;
            }
            yield return subset;
        }
    }

    public static long Product(this IEnumerable<long> list)
    {
        return list.Aggregate(1l, (a, b) => a * b);
    }

    public static long Product(this IEnumerable<long> list, long modulus)
    {
        return list.Aggregate(1L, (a, b) => a * b % modulus);
    }

    public static IEnumerable<TS> AggregateEnumerable<T, TS>(this IEnumerable<T> source, TS seed,
        Func<TS, T, TS> func)
    {
        var current = seed;
        yield return current;
        foreach (var t in source)
        {
            current = func(current, t);
            yield return current;
        }
    }

    public static IList<TS> AggregateList<T, TS>(this IEnumerable<T> source, TS seed,
        Func<TS, T, TS> func)
    {
        return source.AggregateEnumerable(seed, func).ToList();
    }

    public static IEnumerable<TA> Zipper<TA, TB>(this IEnumerable<TB> source, Func<TB, TB, TA> func)
    {
        bool first = true;
        TB prev = default;
        foreach (var b in source)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                yield return func(prev, b);
            }
            prev = b;
        }
    }
}