using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2020;

public class Dag15 : Problem
{
    #region input

    private const string input = @"13,0,10,12,1,5,8";
    private const string testinput = @"3,1,2";
    #endregion
    public override Task ExecuteAsync()
    {
        var values = input.Split(",").Select(int.Parse).ToList();
        //var dictionary = new Dictionary<int, int>();
        int[] blaat = new int[30000000];
        int index = 1;
        foreach (var value in values.Take(values.Count - 1))
        {
            //dictionary[value] = index;
            //Console.WriteLine(value);
            blaat[value] = index;
            index++;
        }

        int last = values.Last();
        for (; index < 30000000; index++)
        {
            //Console.WriteLine(last);
            //if (!dictionary.ContainsKey(last))
            //{
            //    dictionary[last] = index;
            //    last = 0;
            //}
            //else
            //{
            //    var newLast = index - dictionary[last];
            //    dictionary[last] = index;
            //    last = newLast;
            //}
            var blaatLast = blaat[last];
            var newLast = blaatLast == 0 ? 0 : index - blaatLast;
            blaat[last] = index;
            last = newLast;
        }

        Result = last.ToString();
        return Task.CompletedTask;
    }

    public override int Nummer => 202015;
}