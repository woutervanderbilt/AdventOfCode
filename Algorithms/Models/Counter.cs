using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Models;

public class Counter<T>
{
    private readonly IDictionary<T, int> counts = new Dictionary<T, int>();
    private readonly int? mod;

    public Counter(int? mod = null)
    {
        this.mod = mod;
    }
    public int this[T t]
    {
        get => counts.TryGetValue(t, out var value) ? value : 0;
        set => counts[t] = value % mod ?? value;
    }

    public void AddCount(T t, int c)
    {
        if (counts.ContainsKey(t))
        {
            if (mod.HasValue)
            {
                counts[t] = (counts[t] + c) % mod.Value;
            }
            else
            {
                counts[t] += c;
            }
        }
        else
        {
            counts[t] = c % mod ?? c;
        }
    }

    public IEnumerable<T> Keys => counts.Keys;
    public IEnumerable<int> Values => counts.Values;
}

public class CounterLong<T>
{
    private readonly IDictionary<T, long> counts = new Dictionary<T, long>();
    private readonly long? mod;

    public CounterLong(long? mod = null)
    {
        this.mod = mod;
    }

    public long this[T t]
    {
        get => counts.TryGetValue(t, out var value) ? value : 0;
        set => counts[t] = value % mod ?? value;
    }

    public void AddCount(T t, long c)
    {
        if (counts.ContainsKey(t))
        {
            if (mod.HasValue)
            {
                counts[t] = counts[t] + c % mod.Value;
            }
            else
            {
                counts[t] += c;
            }
        }
        else
        {
            counts[t] = c % mod ?? c;
        }
    }

    public IEnumerable<T> Keys => counts.Keys;
    public IEnumerable<long> Values => counts.Values;
}


public class CounterBigInteger<T>
{
    private readonly IDictionary<T, BigInteger> counts = new Dictionary<T, BigInteger>();

    public BigInteger this[T t]
    {
        get => counts.ContainsKey(t) ? counts[t] : 0;
        set => counts[t] = value;
    }

    public void AddCount(T t, int c)
    {
        if (counts.ContainsKey(t))
        {
            counts[t] += c;
        }
        else
        {
            counts[t] = c;
        }
    }

    public IEnumerable<T> Keys => counts.Keys;
    public IEnumerable<BigInteger> Values => counts.Values;
}

public class CounterDouble<T>
{
    private readonly IDictionary<T, double> counts = new Dictionary<T, double>();

    public CounterDouble()
    {
    }

    public double this[T t]
    {
        get => counts.ContainsKey(t) ? counts[t] : 0;
        set => counts[t] = value;
    }

    public void AddCount(T t, double c)
    {
        if (counts.ContainsKey(t))
        {
            counts[t] += c;
        }
        else
        {
            counts[t] = c;
        }
    }

    public ICollection<T> Keys => counts.Keys;
    public ICollection<double> Values => counts.Values;
}

public class CounterDecimal<T>
{
    private readonly IDictionary<T, decimal> counts = new Dictionary<T, decimal>();

    public CounterDecimal()
    {
    }

    public decimal this[T t]
    {
        get => counts.ContainsKey(t) ? counts[t] : 0;
        set => counts[t] = value;
    }

    public void AddCount(T t, decimal c)
    {
        if (counts.ContainsKey(t))
        {
            counts[t] += c;
        }
        else
        {
            counts[t] = c;
        }
    }

    public IEnumerable<T> Keys => counts.Keys;
    public IEnumerable<decimal> Values => counts.Values;
}