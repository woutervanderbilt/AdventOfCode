using System.Collections.Generic;

namespace Algorithms.Extensions;
public static class DictionaryExtensions
{
    public static void AddToList<TKey, TValue, TList>(this IDictionary<TKey, TList> dict, TKey key, TValue value)
        where TList : ICollection<TValue>, new()
    {
        TList list;
        if (!dict.TryGetValue(key, out list))
        {
            list = new TList();
            dict[key] = list;
        }
        list.Add(value);
    }

    public static void RemoveFromList<TKey, TValue, TList>(this IDictionary<TKey, TList> dict, TKey key, TValue value)
        where TList : ICollection<TValue>, new()
    {
        if (dict.TryGetValue(key, out var list))
        {
            list.Remove(value);
        }
    }
}
