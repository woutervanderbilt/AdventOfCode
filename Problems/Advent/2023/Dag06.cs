using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problems;

namespace Problems.Advent._2023;

internal class Dag06 : Problem
{
    public override async Task ExecuteAsync()
    {
        int[] a = [1,2,3];
        IList<int> b = [2,3,4];
        ICollection<int> c= [..b,2,3,455,..b,..b];




        string input = await GetInputAsync();
        foreach (var line in input.Split(Environment.NewLine))
        {
            
        }
    }

    public override int Nummer => 202306;
}

