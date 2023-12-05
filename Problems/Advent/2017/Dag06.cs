using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2017;

internal class Dag06 : Problem
{
    private const string input = @"10	3	15	10	5	15	5	15	9	2	5	8	5	2	3	6";
    public override Task ExecuteAsync()
    {
        IList<int> numbers = input.Split("\t").Select(int.Parse).ToList();
        HashSet<string> visitedStates = new HashSet<string>();
        var state = string.Join(',', numbers);
        while (!visitedStates.Contains(state))
        {
            visitedStates.Add(state);
            var index = numbers.IndexOf(numbers.Max());
            IList<int> newNumbers = numbers.ToList();
            var div = newNumbers[index] / newNumbers.Count;
            var rem = newNumbers[index] % newNumbers.Count;
            newNumbers[index] = div;
            for (int i = 1; i < newNumbers.Count; i++)
            {
                newNumbers[(index + i) % newNumbers.Count] += div + (i <= rem ? 1 : 0);
            }

            numbers = newNumbers;
            state = string.Join(',', numbers);
        }

        Result = (visitedStates.Count - visitedStates.ToList().IndexOf(state)).ToString();
        return Task.CompletedTask;
    }

    public override int Nummer => 201706;
}