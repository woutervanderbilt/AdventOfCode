using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Extensions
{
    public static class ListExtensions
    {
        public static IEnumerable<IList<T>> PowerSet<T>(this IList<T> source)
        {
            var powerSet = new T[1 << source.Count][];
            powerSet[0] = new T[0]; // starting only with empty set
            for (int i = 0; i < source.Count; i++)
            {
                var cur = source[i];
                int count = 1 << i; // doubling list each time
                for (int j = 0; j < count; j++)
                {
                    var tempSource = powerSet[j];
                    var destination = powerSet[count + j] = new T[tempSource.Length + 1];
                    for (int q = 0; q < tempSource.Length; q++)
                        destination[q] = tempSource[q];
                    destination[tempSource.Length] = cur;
                }
            }
            return powerSet;
        }
    }
}
