using System.Collections.Generic;
using System.Threading.Tasks;

namespace Problems.Advent._2018;

public class Dag14 : Problem
{
    private const int input = 77201;
    public override Task ExecuteAsync()
    {
        IList<byte> recipes = new List<byte> { 3, 7 };
        int firstElfIndex = 0;
        int secondElfIndex = 1;
        while (true)
        {
            byte firstElfRecipe = recipes[firstElfIndex];
            byte secondElfRecipe = recipes[secondElfIndex];
            if (firstElfRecipe + secondElfRecipe > 9)
            {
                recipes.Add(1);
                if (LastSix(recipes) == input)
                {
                    break;
                }
                recipes.Add((byte)((firstElfRecipe + secondElfRecipe) % 10));
            }
            else
            {
                recipes.Add((byte)(firstElfRecipe + secondElfRecipe));
            }
            if (LastSix(recipes) == input)
            {
                break;
            }
            firstElfIndex = (firstElfIndex + 1 + firstElfRecipe) % recipes.Count;
            secondElfIndex = (secondElfIndex + 1 + secondElfRecipe) % recipes.Count;
        }

        Result = recipes.Count - 6 + "";
        return Task.CompletedTask;
    }

    private int LastSix(IList<byte> recipes)
    {
        if (recipes.Count < 6)
        {
            return 0;
        }
        int result = 0;
        int d = 1;
        for (int i = 1; i <= 6; i++)
        {
            result += d * recipes[recipes.Count - i];
            d *= 10;
        }
        return result;
    }

    public override int Nummer => 201814;
}