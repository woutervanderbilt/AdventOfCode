using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Problems.Advent._2024;

internal class Dag05 : Problem
{
    public override async Task ExecuteAsync()
    {
        IDictionary<int, List<int>> orders = new Dictionary<int, List<int>>();
        IList<IList<int>> updates = [];
        bool parsingFirstPart = true;
        foreach (var line in Input.Split(Environment.NewLine))
        {
            if (string.IsNullOrEmpty(line))
            {
                parsingFirstPart = false;
                continue;
            }

            if (parsingFirstPart)
            {
                var split = line.Split('|');
                orders.AddToList(int.Parse(split[0]), int.Parse(split[1]));
            }
            else
            {
                updates.Add(line.Split(',').Select(int.Parse).ToList());
            }
        }

        long result = 0;
        long result2 = 0;
        foreach (var update in updates)
        {
            bool ok = true;
            foreach (var (item1, index) in update.Indexed())
            {
                foreach (var item2 in update.Take(index))
                {
                    if (orders.ContainsKey(item1) && orders[item1].Contains(item2))
                    {
                        ok = false;
                        break;
                    }
                }

                if (!ok)
                {
                    break;
                }
            }

            if (ok)
            {
                result += update[update.Count / 2];
            }
            else
            {
                while (!ok)
                {
                    ok = true;
                    foreach (var (item1, index) in update.Indexed().ToList())
                    {
                        foreach (var (item2, index2) in update.Take(index).Indexed().ToList())
                        {
                            if (orders.ContainsKey(item1) && orders[item1].Contains(item2))
                            {
                                ok = false;
                                update[index] = item2;
                                update[index2] = item1;
                                break;
                            }
                        }

                        if (!ok)
                        {
                            break;
                        }
                    }
                }
                result2 += update[update.Count / 2];
            }
        }

        Result = (result, result2).ToString();
    }


    protected override bool UseTestInput => false;
    protected override string TestInput => @"47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47";


    public override int Nummer => 202405;
}