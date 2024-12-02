﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;
using Algorithms.Models;

namespace Problems.Advent._2023;

internal class Dag23 : Problem
{
    public override async Task ExecuteAsync()
    {
        string input = await GetInputAsync();
        var grid = Grid<char>.FromInput(input, c => c);
        grid.Print();
    }

    public override int Nummer => 202323;
}