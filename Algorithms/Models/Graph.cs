using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Algorithms.Models;
public class Graph<T> where T : notnull
{
    public Dictionary<T, List<(T to, long weight)>> Edges { get; set; } = [];
    public IEnumerable<T> Vertices => Edges.Keys;

    public Graph()
    {
    }

    public Graph(IEnumerable<(T from, T to, long weight)> vertices, bool bidirectional)
    {
        foreach (var vertex in vertices)
        {
            AddEdge(vertex.from, vertex.to, vertex.weight, bidirectional);
        }
    }

    public void AddEdge(T from, T to, long weight, bool bidirectional)
    {
        if (!Edges.ContainsKey(from))
        {
            Edges[from] = new List<(T to, long weight)>();
        }

        Edges.AddToList(from, (to, weight));

        if (!Edges.ContainsKey(to))
        {
            Edges[to] = new List<(T to, long weight)>();
        }

        if (bidirectional)
        {
            Edges.AddToList(to, (from, weight));
        }
    }

    public IEnumerable<T> Neighbours(T from)
    {
        return Edges[from].Select(e => e.to);
    }

    public IEnumerable<HashSet<T>> Cliques()
    {
        return CliquesInternal([], [..Vertices], []).ToList();

        IEnumerable<HashSet<T>> CliquesInternal(HashSet<T> r, HashSet<T> p, HashSet<T> x)
        {
            if (!p.Any() && !x.Any())
            {
                yield return r;
            }


            foreach (var v in p.ToList())
            {
                var newR = new HashSet<T>(r) { v };
                var newP = new HashSet<T>();
                var newX = new HashSet<T>();
                foreach (var n in Edges[v].Select(e => e.to))
                {
                    if (p.Contains(n))
                    {
                        newP.Add(n);
                    }

                    if (x.Contains(n))
                    {
                        newX.Add(n);
                    }
                }

                var res = CliquesInternal(newR, newP, newX);
                foreach (var c in res)
                {
                    yield return c;
                }

                p.Remove(v);
                x.Add(v);
            }
        }
    }

    public (IEnumerable<T> path, long cost, bool pathFound) ShortestPath(T from, T to)
    {
        IDictionary<T, long> costs = new Dictionary<T, long> { [from] = 0 };
        IDictionary<T, T> comingFrom = new Dictionary<T, T>();
        var queue = new PriorityQueue<T, long>();
        queue.Enqueue(from, 0);
        while (queue.TryDequeue(out var vertex, out long cost))
        {
            if (costs.TryGetValue(vertex, out var vCost) &&  vCost < cost)
            {
                continue;
            }
            foreach (var neighbour in Edges[vertex])
            {
                var newCost = cost + neighbour.weight;
                if (!costs.TryGetValue(neighbour.to, out var prevCost) || prevCost > newCost)
                {
                    costs[neighbour.to] = newCost;
                    comingFrom[neighbour.to] = vertex;
                    queue.Enqueue(neighbour.to, newCost);
                }
            }

            if (vertex.Equals(to))
            {
                break;
            }
        }

        if (!costs.TryGetValue(to, out var result))
        {
            return ([], 0, false);
        }

        IList<T> path = [to];
        while(comingFrom.TryGetValue(to, out to))
        {
            path.Add(to);
        }

        return (path.Reverse(), result, true);
    }
}
