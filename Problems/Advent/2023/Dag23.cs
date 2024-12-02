using Algorithms.Extensions;
using Algorithms.Models;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag23 : Problem
{
    public override async Task ExecuteAsync()
    {

        var grid = Grid<char>.FromInput(Input, c => c);
        grid.Print();
    }

    public override int Nummer => 202323;
}