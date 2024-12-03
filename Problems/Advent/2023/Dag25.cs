using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2023;

internal class Dag25 : Problem
{
    public override async Task ExecuteAsync()
    {
        IDictionary<string, HashSet<string>> nodesWithConnectedNodes = new Dictionary<string, HashSet<string>>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var split = line.Split(": ");
            var left = split[0];
            foreach (var right in split[1].Split(' '))
            {
                nodesWithConnectedNodes.AddToList(left, right);
                nodesWithConnectedNodes.AddToList(right, left);
            }
        }

        CounterLong<(string, string)> usageInShortesPaths = new();
        foreach (var (start, i) in nodesWithConnectedNodes.Keys.Indexed())
        {
            foreach (var target in nodesWithConnectedNodes.Keys.Skip(i + 1))
            {
                var path = ShortestPath(start, target);
                foreach (var node in path.Zipper((a,b) => a.CompareTo(b) > 0 ? (a, b) : (b, a)))
                {
                    usageInShortesPaths[node]++;
                }
            }
        }

        var mostUsedEdges = usageInShortesPaths.Keys.OrderByDescending(k => usageInShortesPaths[k]).Take(3).ToList();
        Result = (GroupSize(mostUsedEdges[0].Item1, mostUsedEdges) * GroupSize(mostUsedEdges[0].Item2, mostUsedEdges)).ToString();

        IList<string> ShortestPath(string start, string target)
        {
            HashSet<string> startGrowth = [start];
            HashSet<string> targetGrowth = [target];
            IDictionary<string, string> startPaths = new Dictionary<string, string>();
            IDictionary<string, string> targetPaths = new Dictionary<string, string>();
            bool growStart = true;
            while (!startGrowth.Any(s => targetGrowth.Contains(s)))
            {
                var baseSet = growStart ? startGrowth : targetGrowth;
                var paths = growStart ? startPaths : targetPaths;
                var newGrowth = new HashSet<string>();
                foreach (var baseNode in baseSet)
                {
                    foreach (var nextNode in nodesWithConnectedNodes[baseNode])
                    {
                        if (!paths.ContainsKey(nextNode))
                        {
                            newGrowth.Add(nextNode);
                            paths[nextNode] = baseNode;
                        }
                    }
                }

                if (growStart)
                {
                    startGrowth = newGrowth;
                }
                else
                {
                    targetGrowth = newGrowth;
                }
                growStart = !growStart;
            }

            IList<string> path = new List<string>();
            var midNode = startGrowth.First(s => targetGrowth.Contains(s));
            var currentNode = midNode;
            while (currentNode != start)
            {
                path.Add(currentNode);
                currentNode = startPaths[currentNode];
            }
            path.Add(start);
            path = path.Reverse().ToList();
            currentNode = midNode;
            while(currentNode != target)
            {
                path.Add(currentNode);
                currentNode = targetPaths[currentNode];
            }

            return path;
        }

        long GroupSize(string node, IList<(string, string)> deletedEdges)
        {
            HashSet<string> group = new HashSet<string> { node };
            IList<string> lastAdded = new List<string> { node };
            while (lastAdded.Any())
            {
                IList<string> newLastAdded = new List<string>();
                foreach (var currentNode in lastAdded)
                {
                    foreach (var nextNode in nodesWithConnectedNodes[currentNode])
                    {
                        if (deletedEdges.Contains((currentNode, nextNode)) ||
                            deletedEdges.Contains((nextNode, currentNode)))
                        {
                            continue;
                        }
                        if(!group.Contains(nextNode))
                        {
                            group.Add(nextNode);
                            newLastAdded.Add(nextNode);
                        }
                    }
                }
                lastAdded = newLastAdded;
            }

            return group.Count;
        }

    }

    public override int Nummer => 202325;
}