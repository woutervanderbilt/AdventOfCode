﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2017;

internal class Dag11 : Problem
{
    private const string input = @"ne,se,n,n,nw,nw,nw,n,nw,nw,sw,sw,sw,sw,s,se,s,se,s,s,s,nw,s,s,s,se,se,ne,se,se,nw,s,nw,se,se,se,sw,sw,se,se,se,se,se,ne,ne,ne,ne,se,se,ne,ne,ne,ne,ne,ne,ne,nw,sw,ne,ne,ne,n,ne,ne,ne,ne,n,ne,ne,n,n,ne,ne,n,s,ne,ne,ne,n,ne,nw,ne,ne,n,n,n,ne,n,n,n,n,ne,n,nw,n,nw,n,sw,ne,n,sw,n,sw,n,n,n,n,n,n,nw,n,n,nw,nw,n,nw,n,nw,s,n,nw,n,n,n,n,nw,n,nw,nw,n,nw,nw,ne,nw,nw,nw,nw,n,nw,nw,nw,nw,nw,nw,sw,nw,n,nw,nw,nw,nw,s,s,sw,nw,sw,sw,nw,ne,nw,nw,nw,nw,nw,nw,ne,se,nw,sw,s,nw,nw,s,nw,sw,nw,nw,sw,nw,nw,sw,nw,nw,nw,nw,sw,sw,sw,sw,nw,sw,nw,sw,sw,n,sw,nw,sw,ne,se,s,sw,sw,sw,s,sw,sw,sw,ne,sw,sw,nw,sw,sw,sw,s,sw,sw,sw,sw,nw,ne,nw,ne,sw,s,sw,n,s,sw,sw,sw,se,sw,sw,n,sw,nw,sw,sw,nw,sw,nw,sw,ne,sw,sw,s,se,sw,sw,sw,sw,ne,nw,nw,sw,sw,sw,se,sw,se,sw,s,sw,sw,se,s,s,sw,ne,n,sw,sw,n,nw,n,s,s,sw,s,nw,s,s,s,s,sw,sw,s,s,s,s,nw,n,n,s,sw,s,se,s,sw,s,s,nw,s,s,s,s,s,s,s,sw,s,s,s,s,sw,s,s,sw,sw,ne,s,s,sw,s,s,s,s,se,s,s,s,s,s,s,s,ne,se,s,s,s,s,s,s,s,se,s,s,s,se,sw,s,s,n,s,s,s,se,s,ne,s,ne,se,ne,s,se,sw,s,n,s,s,sw,s,s,sw,s,se,s,s,ne,sw,se,se,se,se,se,s,se,s,n,s,s,s,s,s,n,s,s,se,nw,se,se,se,s,se,se,s,se,se,se,se,s,se,se,ne,s,s,s,se,s,sw,se,nw,nw,se,se,se,s,se,se,s,se,se,se,se,s,s,se,s,n,se,se,se,se,se,sw,nw,s,nw,se,se,se,se,se,se,se,se,nw,se,nw,sw,nw,s,nw,se,se,se,sw,se,se,se,se,se,se,se,se,se,sw,se,se,se,se,se,se,se,se,se,se,sw,sw,se,n,s,se,se,se,se,ne,ne,se,n,se,n,se,se,ne,se,ne,ne,ne,se,s,se,se,se,se,se,se,se,ne,ne,ne,se,se,s,n,se,se,ne,sw,se,ne,nw,ne,se,se,n,se,ne,n,se,se,ne,ne,ne,se,se,ne,n,ne,se,se,ne,se,se,ne,nw,ne,se,se,se,ne,se,ne,se,sw,ne,nw,ne,ne,se,ne,ne,ne,se,ne,ne,se,n,s,se,ne,se,ne,ne,ne,se,nw,se,ne,se,ne,ne,ne,ne,ne,se,se,ne,ne,se,se,se,n,sw,se,ne,nw,se,ne,ne,ne,ne,s,ne,nw,ne,s,ne,ne,se,se,ne,ne,ne,nw,ne,se,ne,ne,ne,ne,s,se,se,ne,nw,ne,s,ne,ne,sw,sw,ne,ne,ne,ne,ne,nw,ne,ne,ne,ne,ne,ne,ne,ne,ne,n,ne,ne,ne,sw,sw,ne,ne,sw,ne,n,ne,ne,s,se,sw,s,ne,ne,ne,ne,sw,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,s,ne,n,n,ne,ne,n,ne,ne,se,ne,n,ne,n,ne,ne,ne,ne,n,ne,ne,ne,sw,n,ne,ne,ne,ne,ne,se,ne,sw,se,ne,ne,ne,n,n,ne,sw,ne,ne,n,s,n,nw,se,se,n,ne,n,ne,ne,nw,ne,ne,n,ne,se,n,ne,nw,ne,ne,n,se,n,n,n,ne,ne,n,ne,ne,n,n,se,ne,ne,se,ne,ne,ne,ne,ne,n,ne,n,n,n,ne,n,ne,n,n,ne,n,n,s,ne,nw,ne,ne,ne,ne,n,ne,s,n,sw,ne,ne,ne,ne,n,ne,nw,n,s,ne,sw,n,se,ne,sw,n,sw,ne,n,n,n,n,n,s,ne,ne,ne,ne,n,sw,n,ne,n,ne,ne,ne,nw,n,n,se,ne,n,n,nw,ne,ne,n,n,n,ne,ne,sw,sw,ne,n,n,ne,ne,n,se,n,nw,s,ne,n,s,n,se,ne,ne,n,ne,n,n,ne,n,ne,n,n,n,n,n,sw,ne,n,ne,n,sw,ne,ne,n,n,n,n,n,n,n,n,s,sw,n,n,n,n,ne,ne,s,s,n,n,se,n,n,n,n,n,n,n,ne,ne,sw,n,se,n,sw,n,ne,s,n,ne,n,n,s,n,n,n,n,nw,s,n,ne,n,n,se,n,nw,n,n,n,n,n,n,n,n,se,sw,n,se,n,n,n,ne,n,n,nw,n,sw,n,n,n,s,s,sw,n,n,n,ne,n,n,n,n,n,n,n,n,n,s,n,n,n,n,n,n,se,n,nw,n,n,n,n,ne,se,n,sw,n,n,n,n,se,n,n,n,se,sw,nw,n,n,n,se,n,n,s,n,n,n,n,ne,se,n,n,n,n,nw,n,nw,sw,nw,s,nw,sw,nw,n,n,nw,n,sw,n,sw,nw,ne,se,n,n,nw,se,nw,se,ne,n,s,n,n,n,n,n,n,nw,n,n,n,n,n,se,n,n,ne,nw,n,nw,n,nw,nw,nw,n,n,n,se,n,nw,nw,n,nw,n,n,se,nw,ne,s,s,n,n,n,n,n,n,n,se,n,nw,nw,nw,nw,s,n,n,nw,n,n,n,nw,n,sw,nw,nw,n,n,n,nw,se,n,se,n,ne,n,nw,n,sw,nw,nw,n,nw,n,ne,nw,nw,ne,n,n,n,se,nw,n,n,nw,s,se,n,n,n,se,ne,n,n,nw,n,nw,se,n,n,nw,n,nw,ne,nw,nw,n,nw,nw,nw,n,n,s,se,se,nw,n,n,n,n,nw,nw,nw,nw,nw,nw,n,s,nw,nw,n,nw,nw,n,se,se,nw,n,nw,nw,n,n,nw,sw,nw,n,n,nw,nw,nw,nw,se,nw,n,nw,n,se,n,nw,n,n,nw,n,nw,nw,n,nw,nw,sw,n,n,se,ne,nw,nw,nw,n,nw,nw,nw,nw,ne,se,n,n,nw,nw,nw,s,nw,nw,nw,sw,nw,nw,nw,ne,ne,n,nw,n,nw,ne,s,nw,n,nw,nw,nw,se,nw,nw,nw,s,nw,s,sw,s,nw,nw,n,nw,nw,n,sw,sw,nw,n,nw,nw,nw,nw,nw,nw,ne,nw,nw,n,n,nw,ne,nw,nw,s,n,nw,nw,nw,n,n,nw,nw,n,nw,se,nw,nw,nw,nw,n,n,n,se,nw,nw,nw,nw,n,sw,ne,nw,nw,nw,sw,nw,nw,n,nw,nw,nw,n,nw,nw,nw,nw,nw,s,sw,nw,nw,nw,n,nw,nw,nw,nw,ne,n,ne,nw,ne,nw,nw,nw,nw,nw,nw,nw,nw,n,nw,nw,nw,s,sw,sw,nw,sw,nw,nw,n,s,nw,nw,n,nw,nw,nw,sw,nw,nw,nw,se,nw,nw,sw,nw,s,nw,nw,nw,sw,nw,n,se,nw,nw,ne,se,s,nw,nw,sw,nw,nw,nw,s,s,nw,sw,sw,se,n,nw,ne,se,sw,nw,nw,ne,sw,nw,nw,sw,nw,n,nw,nw,nw,nw,sw,sw,n,nw,n,se,nw,nw,sw,nw,sw,nw,nw,nw,nw,nw,sw,nw,nw,sw,nw,sw,nw,sw,nw,s,sw,nw,nw,nw,nw,ne,nw,nw,nw,nw,nw,nw,se,sw,nw,sw,sw,nw,se,nw,nw,nw,sw,nw,sw,nw,sw,sw,sw,nw,sw,nw,nw,nw,se,nw,nw,sw,s,nw,n,nw,nw,nw,nw,nw,sw,s,ne,nw,nw,nw,sw,sw,nw,sw,nw,nw,s,nw,ne,sw,sw,sw,sw,nw,nw,nw,nw,nw,nw,se,sw,sw,nw,nw,nw,sw,sw,s,sw,ne,nw,sw,ne,nw,nw,nw,ne,nw,sw,nw,nw,nw,sw,sw,sw,nw,nw,sw,nw,nw,nw,sw,sw,sw,nw,s,n,sw,se,nw,nw,nw,nw,n,sw,sw,nw,nw,sw,sw,nw,nw,nw,nw,se,sw,nw,n,nw,nw,s,nw,s,sw,n,nw,nw,nw,sw,nw,n,nw,sw,nw,sw,nw,nw,sw,n,sw,se,nw,ne,nw,nw,sw,sw,n,sw,sw,nw,se,nw,nw,sw,nw,se,sw,sw,sw,sw,nw,nw,nw,sw,nw,nw,n,sw,sw,n,sw,nw,sw,sw,ne,sw,s,sw,s,sw,sw,nw,sw,sw,sw,s,nw,sw,sw,se,nw,nw,nw,sw,nw,sw,nw,nw,nw,nw,nw,sw,sw,nw,nw,n,sw,nw,nw,sw,nw,s,nw,nw,nw,n,nw,nw,nw,sw,sw,sw,sw,nw,sw,sw,nw,nw,nw,sw,nw,sw,sw,nw,sw,sw,nw,se,s,ne,sw,sw,sw,sw,n,sw,sw,sw,nw,se,ne,sw,nw,sw,se,ne,sw,sw,s,se,sw,ne,sw,sw,sw,sw,sw,sw,se,nw,sw,ne,sw,sw,sw,nw,sw,sw,sw,se,s,nw,se,nw,se,se,s,nw,nw,nw,sw,sw,nw,sw,sw,sw,se,nw,nw,nw,sw,ne,sw,s,sw,nw,nw,sw,sw,sw,ne,sw,sw,nw,nw,nw,sw,n,sw,sw,nw,se,sw,sw,sw,nw,s,sw,se,sw,s,s,n,sw,sw,sw,nw,sw,se,sw,s,sw,sw,sw,sw,sw,sw,sw,ne,sw,sw,sw,sw,sw,nw,nw,n,sw,sw,ne,sw,sw,sw,nw,sw,sw,sw,sw,nw,sw,sw,nw,sw,sw,sw,se,ne,sw,sw,nw,sw,nw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,nw,sw,sw,s,sw,sw,sw,sw,sw,sw,nw,nw,ne,nw,nw,nw,sw,n,sw,s,sw,sw,nw,sw,s,nw,se,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,n,sw,sw,sw,se,sw,sw,n,sw,sw,se,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,se,n,sw,ne,sw,nw,n,nw,sw,sw,sw,sw,sw,s,sw,sw,n,se,sw,sw,sw,ne,sw,s,sw,sw,sw,sw,sw,se,se,sw,sw,sw,sw,sw,sw,nw,sw,sw,sw,sw,sw,sw,se,sw,ne,s,sw,s,s,nw,sw,se,sw,s,s,sw,sw,sw,sw,sw,s,sw,sw,sw,sw,se,n,sw,nw,se,sw,sw,sw,sw,sw,sw,sw,s,sw,sw,ne,sw,sw,sw,sw,sw,sw,ne,sw,sw,sw,sw,sw,nw,sw,se,ne,n,sw,s,sw,sw,sw,se,sw,s,sw,sw,sw,sw,se,sw,n,sw,sw,sw,sw,sw,sw,sw,sw,nw,s,se,sw,sw,sw,sw,sw,sw,se,sw,sw,sw,sw,s,nw,s,sw,ne,sw,sw,ne,sw,sw,sw,ne,s,s,ne,se,sw,sw,s,s,sw,sw,sw,n,se,sw,sw,nw,sw,s,sw,se,sw,sw,sw,sw,s,s,sw,sw,sw,sw,sw,sw,sw,sw,sw,nw,sw,n,nw,sw,s,s,sw,sw,sw,nw,sw,se,se,sw,sw,ne,sw,sw,s,sw,sw,s,sw,sw,s,sw,sw,s,s,ne,sw,s,s,sw,sw,sw,s,sw,sw,sw,s,sw,sw,sw,sw,sw,sw,sw,s,sw,sw,sw,sw,s,nw,sw,s,sw,s,sw,nw,se,se,sw,sw,sw,sw,s,sw,sw,sw,sw,s,sw,se,s,sw,s,sw,sw,s,sw,s,sw,n,sw,se,s,s,s,s,ne,s,sw,s,sw,sw,nw,sw,n,s,n,s,sw,sw,s,sw,ne,sw,sw,s,n,nw,ne,sw,sw,se,sw,s,sw,ne,sw,s,sw,s,sw,sw,nw,s,nw,sw,s,sw,s,s,s,s,sw,s,s,sw,sw,nw,sw,s,se,sw,sw,sw,nw,s,sw,sw,sw,s,s,s,sw,sw,s,se,n,sw,sw,s,ne,sw,s,s,s,ne,sw,sw,sw,sw,s,sw,s,s,s,nw,n,sw,sw,ne,sw,s,sw,sw,sw,s,s,s,nw,sw,sw,s,sw,s,sw,s,s,s,s,sw,s,ne,s,sw,s,s,s,s,ne,s,sw,se,sw,n,ne,s,sw,se,s,n,s,s,s,se,s,s,sw,s,s,sw,sw,ne,sw,sw,n,s,ne,s,sw,sw,ne,s,sw,sw,sw,sw,sw,ne,sw,s,s,se,s,s,sw,s,nw,s,s,ne,s,sw,se,s,ne,sw,nw,sw,s,sw,s,s,s,s,ne,se,s,sw,sw,s,sw,sw,sw,nw,s,s,s,s,s,n,ne,s,se,n,s,s,s,sw,s,s,s,s,sw,s,s,n,s,s,sw,sw,s,n,s,se,s,sw,sw,s,s,s,sw,sw,ne,sw,sw,sw,s,s,s,n,s,se,sw,sw,s,s,sw,sw,s,s,nw,s,sw,s,sw,sw,n,n,s,sw,sw,sw,sw,sw,s,n,sw,s,sw,sw,s,s,s,s,sw,nw,sw,s,se,sw,ne,sw,s,sw,sw,ne,s,s,sw,s,sw,s,n,ne,s,s,s,s,s,se,sw,s,sw,se,s,s,s,s,s,s,s,sw,nw,sw,s,s,s,s,nw,s,s,s,s,s,sw,s,n,sw,s,s,nw,sw,sw,s,s,s,s,s,se,s,s,s,nw,s,s,s,s,s,se,s,s,sw,s,n,s,sw,s,sw,sw,sw,s,s,s,se,sw,s,s,se,s,s,n,sw,ne,se,se,n,n,s,s,s,nw,s,s,sw,se,s,ne,sw,s,s,sw,s,s,nw,s,nw,s,s,s,s,sw,s,sw,s,s,sw,s,s,n,s,s,s,s,s,s,ne,s,s,s,sw,ne,s,s,s,s,s,s,sw,ne,s,s,s,s,s,s,n,s,n,se,ne,ne,s,s,ne,s,s,s,s,s,s,s,se,ne,s,s,s,sw,s,s,ne,s,s,s,s,sw,s,s,n,s,s,s,s,s,s,s,s,s,sw,s,s,se,nw,sw,s,s,ne,ne,s,s,s,s,s,s,s,s,s,s,s,se,s,s,s,s,ne,s,nw,s,sw,s,s,ne,s,nw,s,s,s,s,s,s,s,s,s,s,s,s,s,s,nw,s,s,se,s,s,s,s,ne,sw,s,s,s,ne,ne,s,s,sw,se,s,n,s,s,s,ne,s,s,s,s,s,s,s,s,s,ne,s,s,s,s,s,s,s,s,s,nw,s,s,s,s,s,n,s,s,s,s,s,s,nw,nw,s,s,se,s,s,s,nw,s,s,s,s,nw,nw,s,s,s,nw,s,s,s,s,s,s,s,s,s,n,s,s,ne,s,s,sw,se,s,n,s,s,s,n,s,se,s,nw,s,se,s,s,s,s,s,s,s,s,s,s,s,s,s,se,s,s,s,s,s,s,s,s,s,se,s,s,s,s,s,s,s,nw,se,s,s,s,s,se,s,s,n,s,ne,s,nw,s,ne,s,s,s,s,s,s,ne,nw,s,s,se,s,s,s,s,s,s,s,s,s,s,s,s,s,s,s,s,s,s,s,sw,s,s,n,s,s,s,s,s,sw,s,s,s,se,s,s,s,nw,ne,s,se,se,se,s,s,s,s,se,s,n,s,s,s,s,se,n,ne,s,se,s,nw,s,s,s,s,s,s,s,s,s,s,s,s,nw,se,se,sw,s,se,se,s,s,s,s,s,sw,s,s,s,ne,s,s,s,s,s,s,s,s,s,se,se,ne,s,se,s,s,nw,se,s,s,s,s,se,s,nw,s,s,se,s,nw,s,s,s,s,se,s,s,s,s,s,s,s,s,s,s,s,s,sw,s,s,s,s,s,sw,se,s,se,s,n,s,s,s,sw,s,s,se,s,nw,s,s,se,sw,se,s,s,se,s,s,ne,s,s,s,se,nw,s,n,s,s,se,sw,s,se,ne,s,n,s,ne,n,s,se,s,se,s,s,s,ne,s,se,s,se,se,se,s,se,s,s,se,s,s,nw,s,s,s,se,sw,s,se,s,s,nw,se,se,se,ne,se,ne,ne,se,se,s,s,se,se,s,se,s,se,s,sw,s,s,s,s,se,se,n,se,sw,s,s,s,se,se,s,s,ne,sw,se,se,se,n,s,se,se,s,se,s,s,sw,s,s,s,n,se,s,s,s,se,s,s,s,s,s,ne,s,s,se,se,s,se,s,s,s,ne,se,se,se,ne,s,se,nw,s,se,s,sw,se,se,s,s,s,s,nw,se,s,s,s,s,s,s,s,s,s,se,ne,s,s,s,s,se,s,se,s,s,se,s,se,ne,s,nw,se,s,se,s,se,ne,s,se,se,se,s,se,sw,s,se,ne,s,s,s,s,se,se,s,s,se,s,se,s,se,se,s,se,sw,se,s,se,s,ne,se,se,se,ne,s,s,se,nw,s,se,s,ne,s,se,ne,s,se,se,se,s,n,ne,se,se,s,s,s,se,se,se,s,s,s,sw,se,se,se,se,s,se,se,n,s,se,sw,s,n,se,se,se,s,ne,s,se,s,se,se,s,s,se,s,se,se,s,s,s,se,s,se,se,sw,se,n,se,s,se,se,s,s,sw,s,sw,s,s,se,se,s,se,s,se,se,se,se,se,sw,s,sw,s,se,s,se,se,se,se,s,s,ne,s,s,se,se,sw,s,se,se,se,s,s,se,s,s,se,s,se,se,s,se,s,se,s,s,s,se,s,nw,s,se,se,se,s,s,s,s,sw,s,s,ne,se,s,se,s,s,sw,sw,s,se,se,s,se,s,s,se,n,se,s,se,se,s,se,nw,se,s,se,se,se,n,se,s,se,s,s,s,se,se,se,se,s,s,s,s,s,s,se,se,s,se,se,ne,se,se,n,nw,s,se,se,s,se,nw,se,nw,se,s,n,se,se,ne,se,se,se,s,se,s,se,se,n,s,ne,s,nw,se,se,se,se,s,se,se,se,se,se,se,se,se,s,s,s,se,se,se,ne,se,s,se,se,s,se,n,se,se,se,se,s,nw,se,se,se,se,se,ne,se,s,n,se,se,se,se,se,nw,nw,n,s,se,ne,se,se,se,s,se,se,s,s,n,s,se,se,s,nw,ne,se,se,n,s,s,se,se,se,se,se,nw,se,se,se,n,se,nw,se,ne,se,s,sw,se,s,se,se,se,se,se,s,s,se,se,s,s,se,nw,se,ne,se,se,nw,se,se,se,sw,se,s,se,se,n,s,se,nw,ne,se,se,se,se,se,n,se,s,sw,se,se,se,se,s,nw,s,se,se,se,se,se,n,sw,se,se,s,se,se,s,se,se,se,ne,s,se,se,se,se,se,se,nw,s,nw,se,n,se,se,se,s,se,se,n,sw,se,se,se,n,se,se,s,se,se,se,sw,se,ne,ne,se,se,sw,se,se,s,s,se,sw,s,se,sw,nw,sw,se,s,se,s,s,se,se,se,se,se,n,se,se,se,s,se,se,se,se,s,se,se,se,se,se,se,s,s,s,se,se,se,se,se,se,s,se,se,se,sw,se,n,se,se,s,n,se,se,se,se,se,se,se,se,s,se,se,se,se,se,se,se,se,se,se,se,s,se,se,se,n,se,s,se,s,se,se,nw,sw,s,se,se,s,s,se,s,se,n,se,se,se,n,se,s,se,se,se,se,sw,se,s,se,se,se,ne,se,se,se,nw,se,ne,ne,se,se,se,se,se,se,se,ne,nw,se,se,se,se,se,se,se,se,s,sw,ne,se,se,n,n,s,se,se,se,s,s,se,se,se,se,se,se,se,se,se,se,se,se,sw,s,se,se,se,n,s,se,se,se,nw,se,se,se,se,se,se,n,ne,ne,se,s,se,ne,se,se,n,se,se,se,se,s,se,se,s,se,se,se,se,se,se,se,se,se,se,se,n,se,se,se,se,se,se,se,se,se,se,ne,sw,ne,se,se,se,se,se,ne,se,se,ne,n,n,se,sw,ne,se,n,se,se,se,se,se,ne,s,se,se,se,se,sw,se,se,s,se,se,ne,se,se,se,se,ne,se,se,se,n,nw,se,se,se,ne,nw,se,se,se,se,n,nw,se,s,se,se,se,se,se,se,nw,se,nw,se,se,se,se,se,sw,sw,se,se,se,sw,se,s,s,se,se,se,se,ne,n,se,s,se,se,sw,se,se,se,se,se,s,se,ne,se,s,se,se,se,ne,se,ne,n,se,se,se,se,se,n,sw,se,se,se,ne,nw,se,se,nw,se,se,n,se,se,se,se,nw,nw,se,se,se,se,se,se,se,n,se,sw,se,se,se,se,se,n,se,nw,se,se,ne,se,n,se,se,se,se,ne,se,ne,nw,nw,se,sw,ne,se,ne,se,se,se,se,n,ne,s,se,se,se,n,se,sw,se,se,se,s,se,se,se,se,se,s,sw,se,se,ne,se,se,ne,se,ne,ne,sw,se,se,se,se,se,ne,se,se,se,ne,se,ne,se,ne,se,se,se,s,se,se,ne,ne,ne,se,se,nw,se,se,se,se,n,ne,se,se,se,se,ne,ne,se,se,se,se,se,se,nw,ne,se,se,se,se,se,ne,se,se,se,ne,sw,ne,ne,ne,se,ne,se,ne,se,se,ne,ne,se,ne,se,se,se,se,n,se,ne,se,se,sw,ne,nw,se,ne,se,ne,nw,se,se,se,ne,se,se,se,ne,ne,ne,ne,se,ne,se,se,ne,ne,se,ne,se,se,se,ne,se,sw,se,se,ne,se,se,se,se,se,se,se,se,n,se,se,se,ne,se,sw,se,ne,se,se,se,n,se,se,se,se,n,se,se,ne,n,se,se,se,se,se,se,se,se,nw,n,ne,se,se,sw,se,se,se,nw,sw,se,ne,se,se,se,ne,se,ne,se,se,nw,se,se,sw,ne,ne,se,ne,se,nw,ne,n,se,ne,se,nw,nw,se,nw,ne,sw,se,se,se,se,se,se,ne,se,ne,ne,se,s,ne,se,ne,se,ne,se,sw,se,n,se,ne,ne,se,se,sw,se,se,se,ne,ne,ne,se,se,s,se,n,n,nw,se,se,sw,s,se,se,ne,n,se,ne,sw,nw,se,ne,se,ne,se,se,se,se,nw,sw,nw,nw,se,ne,se,ne,ne,se,se,se,se,se,se,ne,se,se,ne,n,ne,se,ne,se,ne,n,n,ne,ne,ne,se,se,ne,s,se,se,se,se,se,se,ne,se,se,sw,se,sw,se,se,nw,se,ne,se,se,ne,ne,sw,se,se,s,ne,s,se,n,ne,ne,ne,se,nw,sw,se,nw,se,ne,se,se,ne,se,n,se,n,ne,ne,n,se,se,ne,nw,ne,se,ne,s,ne,se,se,se,s,se,ne,ne,ne,se,n,s,ne,sw,ne,nw,se,se,sw,ne,ne,ne,se,se,ne,ne,ne,se,s,ne,se,ne,ne,s,se,ne,se,nw,se,se,sw,se,ne,se,se,se,se,se,ne,ne,n,se,se,se,se,se,s,se,ne,se,s,ne,se,se,se,ne,sw,ne,ne,ne,se,ne,ne,ne,ne,ne,ne,se,se,ne,ne,ne,s,ne,n,ne,s,sw,ne,se,ne,ne,ne,ne,ne,ne,se,se,se,sw,se,ne,se,se,s,ne,ne,se,se,ne,se,ne,se,ne,se,s,se,nw,ne,ne,ne,n,ne,se,ne,se,se,s,s,se,se,se,s,n,ne,se,ne,se,se,ne,ne,se,s,se,ne,ne,s,n,ne,se,ne,se,sw,se,sw,n,ne,ne,s,ne,ne,se,se,se,se,ne,ne,ne,se,s,ne,ne,sw,se,se,se,se,se,ne,nw,ne,se,se,ne,ne,se,se,se,se,ne,ne,se,se,se,nw,sw,se,nw,se,sw,se,se,s,n,ne,ne,se,se,se,ne,se,n,se,nw,ne,ne,se,se,s,ne,ne,ne,sw,sw,se,se,se,ne,se,se,se,se,ne,s,nw,se,ne,ne,nw,se,n,se,se,n,se,ne,ne,se,s,s,ne,se,se,s,sw,se,ne,ne,se,nw,ne,n,ne,se,sw,se,s,se,ne,se,n,ne,se,se,se,se,se,ne,se,n,s,ne,ne,se,se,ne,ne,se,ne,nw,se,se,ne,se,ne,s,se,ne,ne,ne,n,se,s,ne,ne,s,ne,ne,se,ne,ne,ne,ne,n,ne,ne,s,se,se,ne,se,ne,se,s,sw,n,ne,ne,ne,sw,se,se,se,ne,ne,se,ne,ne,s,sw,nw,ne,se,se,ne,s,ne,nw,se,ne,se,ne,ne,se,ne,sw,sw,ne,se,se,ne,ne,se,nw,se,ne,sw,ne,ne,ne,se,ne,n,ne,se,ne,ne,ne,ne,se,ne,sw,nw,s,se,se,se,ne,se,nw,se,se,ne,ne,ne,se,ne,ne,n,s,ne,se,ne,ne,n,ne,se,sw,ne,nw,ne,se,ne,sw,se,ne,se,ne,ne,ne,sw,ne,se,ne,se,se,ne,s,nw,ne,se,ne,se,se,ne,se,nw,se,s,se,ne,ne,se,se,ne,nw,ne,ne,s,se,ne,se,ne,n,ne,ne,se,s,n,nw,ne,ne,se,sw,ne,ne,se,ne,ne,ne,ne,ne,ne,n,ne,se,se,ne,ne,se,ne,s,s,se,ne,ne,se,ne,se,ne,se,ne,se,n,ne,ne,ne,se,se,ne,ne,ne,se,s,ne,s,n,ne,ne,se,ne,ne,ne,se,ne,se,se,ne,ne,ne,ne,se,ne,ne,sw,ne,ne,se,se,se,se,ne,sw,n,nw,s,ne,se,ne,ne,sw,ne,ne,n,ne,sw,ne,s,sw,ne,ne,s,nw,ne,ne,se,sw,ne,s,ne,ne,ne,ne,n,se,ne,ne,n,nw,se,se,se,se,se,ne,ne,ne,ne,ne,se,ne,nw,sw,sw,s,ne,se,ne,nw,n,ne,se,ne,ne,se,ne,ne,ne,ne,ne,ne,ne,se,sw,sw,ne,ne,ne,se,n,ne,se,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,se,ne,s,nw,ne,ne,nw,ne,ne,ne,s,se,n,sw,ne,ne,ne,ne,ne,ne,ne,ne,nw,se,ne,ne,ne,ne,ne,s,ne,ne,s,ne,s,se,ne,ne,ne,se,se,ne,nw,nw,ne,n,ne,se,ne,ne,sw,se,ne,se,n,ne,se,se,s,ne,ne,ne,ne,ne,nw,ne,sw,se,ne,ne,ne,ne,ne,n,ne,ne,ne,ne,ne,ne,ne,ne,se,s,se,se,se,ne,s,s,ne,ne,se,ne,ne,ne,ne,ne,sw,ne,sw,sw,ne,sw,ne,ne,ne,ne,ne,ne,se,se,ne,ne,nw,ne,ne,ne,ne,ne,ne,nw,ne,ne,ne,ne,ne,se,ne,se,se,ne,se,ne,se,ne,ne,nw,n,nw,ne,ne,ne,ne,se,ne,s,se,n,ne,ne,se,ne,n,ne,se,ne,se,ne,ne,sw,ne,ne,sw,ne,se,ne,ne,ne,ne,s,ne,ne,ne,se,ne,ne,ne,ne,ne,nw,se,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,se,ne,nw,ne,se,ne,ne,ne,ne,se,se,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,sw,ne,ne,ne,ne,ne,ne,sw,ne,ne,ne,ne,ne,n,ne,ne,ne,ne,ne,se,ne,ne,ne,ne,ne,ne,ne,ne,ne,se,ne,ne,s,ne,ne,ne,ne,ne,sw,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,se,ne,ne,ne,ne,se,ne,ne,ne,ne,ne,nw,ne,s,ne,ne,s,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,sw,ne,nw,ne,sw,sw,ne,ne,ne,ne,ne,s,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,ne,nw,ne,ne,se,ne,ne,sw,ne,ne,ne,nw,ne,n,s,ne,ne,se,s,s,n,sw,nw,sw,nw,sw,nw,ne,se,s,n,s,n,n,n,nw,n,n,nw,n,sw,ne,n,sw,n,ne,sw,n,se,sw,nw,ne,n,ne,nw,s,s,nw,se,ne,se,sw,se,ne,se,n,se,se,se,ne,ne,s,se,se,se,ne,se,se,se,se,s,se,s,n,n,s,se,se,se,s,s,s,se,s,s,s,s,s,se,n,s,se,n,s,s,s,s,se,s,s,s,s,nw,sw,nw,sw,s,n,s,s,sw,ne,s,s,se,sw,s,s,s,sw,se,s,s,n,s,s,sw,s,sw,sw,s,s,s,se,nw,s,sw,sw,sw,sw,sw,sw,s,sw,sw,ne,sw,sw,s,sw,sw,se,se,se,sw,sw,ne,sw,nw,sw,sw,sw,sw,sw,nw,n,ne,sw,sw,sw,sw,n,se,sw,se,nw,sw,nw,nw,sw,sw,se,ne,nw,nw,nw,sw,n,sw,nw,se,sw,sw,nw,nw,sw,s,nw,sw,nw,sw,nw,ne,sw,sw,sw,nw,nw,s,nw,nw,nw,nw,ne,nw,nw,ne,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,sw,nw,nw,nw,se,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,ne,nw,ne,se,nw,nw,nw,se,nw,se,n,nw,s,nw,n,sw,se,n,n,s,ne,s,nw,n,nw,n,nw,nw,n,n,n,n,nw,nw,ne,n,n,se,ne,nw,ne,n,nw,n,se,nw,nw,nw,nw,nw,n,n,n,nw,n,se,se,n,n,n,n,n,nw,n,n,n,n,n,nw,n,nw,n,n,n,se,n,ne,n,n,n,n,s,n,n,n,n,n,n,se,n,n,ne,n,n,se,n,nw,ne,ne,s,n,n,n,n,n,ne,n,n,n,n,n,ne,n,n,n,n,n,s,ne,ne,n,n,s,n,n,sw,n,n,n,n,se,n,n,n,n,ne,sw,ne,ne,sw,n,ne,n,ne,ne,ne,n,nw,n,nw,sw,n,ne,ne,nw,ne,n,nw,n,ne,n,sw,n,n,ne,ne,ne,n,se,n,s,sw,n,ne,nw,nw,ne,n,ne,n,ne,n,ne,nw,n,n,ne,sw,ne,ne,ne,ne,ne,ne,n,sw,n,ne,sw,sw,s,se,ne,ne,nw,ne,ne,s,n,s,ne,n,ne,ne,ne,ne,ne,n,ne,n,ne,ne,ne,ne,ne,ne,se,ne,ne,nw,s,ne,ne,nw,ne,sw,ne,ne,s,ne,ne,ne,ne,ne,se,se,sw,ne,ne,ne,ne,n,se,ne,s,ne,ne,ne,ne,ne,ne,ne,ne,ne,s,ne,sw,ne,ne,nw,ne,ne,ne,ne,s,ne,ne,ne,ne,ne,se,se,se,se,ne,se,ne,ne,ne,nw,nw,ne,nw,ne,se,se,ne,ne,se,se,nw,s,sw,ne,se,se,ne,se,ne,ne,ne,s,se,se,n,se,ne,ne,ne,ne,ne,ne,se,se,sw,ne,se,ne,n,ne,se,se,s,n,n,sw,ne,se,se,se,ne,sw,nw,ne,se,se,ne,se,se,n,nw,ne,ne,se,ne,se,ne,se,se,ne,se,se,se,se,ne,se,sw,ne,se,n,ne,ne,se,ne,se,nw,ne,n,ne,ne,se,ne,ne,se,se,se,ne,se,se,ne,s,se,ne,se,se,n,se,nw,se,se,s,se,se,se,se,se,se,s,nw,se,se,ne,nw,ne,se,se,se,se,se,se,ne,sw,ne,se,ne,se,se,se,se,se,se,se,se,s,ne,se,se,se,n,se,se,se,se,se,se,nw,sw,se,se,se,s,sw,sw,se,se,s,se,ne,ne,se,se,s,n,nw,se,se,se,se,se,ne,se,sw,se,se,se,se,se,se,se,se,se,s,nw,se,se,se,se,se,se,se,se,s,s,se,se,se,se,ne,s,se,se,se,se,se,se,se,se,s,s,se,nw,sw,se,s,se,se,se,s,se,se,se,s,se,s,se,se,se,se,se,se,se,s,s,s,ne,se,n,se,nw,n,se,ne,se,s,s,ne,se,se,se,se,sw,se,se,sw,se,se,s,se,s,s,ne,se,s,s,ne,se,s,se,nw,s,se,se,se,ne,se,s,se,se,n,s,s,s,s,s,n,s,sw,s,s,se,n,s,se,s,s,s,s,s,n,s,s,se,n,s,s,s,s,nw,se,se,s,se,se,s,se,s,s,s,s,se,se,se,ne,s,s,sw,sw,s,s,se,se,s,se,s,s,se,se,s,se,s,ne,s,s,s,s,s,s,se,n,s,nw,s,se,se,s,s,s,s,n,se,s,s,s,s,s,se,ne,s,se,s,s,s,s,s,s,s,s,se,s,s,se,s,s,s,s,n,se,s,s,s,s,sw,s,s,s,s,n,s,s,s,s,s,n,s,s,ne,s,sw,s,s,s,s,s,s,s,s,s,s,s,s,s,s,s,s,s,nw,se,s,s,s,s,s,sw,sw,s,se,s,s,s,s,s,n,s,s,s,s,s,s,s,s,s,sw,n,s,s,s,se,s,s,s,s,se,s,sw,s,s,sw,se,se,s,s,s,s,s,sw,s,s,s,sw,s,nw,s,sw,sw,s,s,s,sw,s,s,s,s,s,sw,s,s,s,s,s,sw,s,nw,sw,s,s,s,s,sw,s,sw,sw,sw,s,s,sw,s,s,s,sw,s,ne,s,s,s,s,s,n,s,sw,se,se,se,sw,s,s,s,n,s,se,s,s,sw,sw,s,sw,n,s,s,s,s,s,s,se,ne,sw,sw,sw,s,s,sw,nw,sw,sw,sw,s,s,s,s,s,s,ne,sw,s,s,s,sw,s,sw,s,sw,s,s,se,s,se,ne,sw,sw,sw,sw,s,s,sw,s,s,sw,sw,nw,ne,sw,sw,sw,s,s,n,s,sw,s,sw,sw,s,s,sw,ne,s,s,nw,s,sw,s,nw,sw,nw,sw,sw,s,nw,s,sw,sw,sw,s,nw,s,sw,sw,nw,ne,sw,se,sw,sw,sw,s,sw,sw,s,sw,s,s,n,s,ne,sw,s,n,sw,s,sw,sw,sw,sw,s,s,sw,sw,s,s,sw,sw,sw,sw,s,sw,s,sw,s,sw,sw,s,s,sw,sw,s,s,s,n,sw,sw,se,n,sw,s,s,sw,sw,s,sw,sw,sw,sw,sw,s,s,s,sw,s,s,s,sw,sw,se,ne,s,sw,sw,sw,se,sw,ne,ne,s,sw,sw,s,s,sw,sw,sw,sw,sw,sw,sw,s,sw,sw,sw,s,sw,s,se,ne,sw,ne,sw,s,se,sw,sw,sw,sw,s,sw,sw,sw,sw,s,se,sw,s,nw,ne,nw,s,nw,sw,nw,sw,n,sw,s,n,sw,sw,sw,s,sw,nw,sw,sw,n,sw,sw,sw,nw,sw,nw,n,sw,s,sw,s,ne,sw,sw,sw,sw,s,sw,sw,s,sw,sw,sw,sw,se,nw,sw,sw,se,sw,nw,sw,n,sw,s,sw,s,sw,ne,sw,sw,sw,sw,s,nw,sw,s,sw,sw,sw,sw,sw,n,se,sw,ne,s,sw,sw,sw,sw,n,sw,sw,ne,sw,sw,sw,s,s,sw,nw,sw,s,sw,se,sw,se,sw,n,nw,sw,s,sw,sw,sw,sw,sw,sw,se,sw,sw,s,sw,nw,sw,sw,nw,sw,sw,sw,nw,sw,sw,sw,sw,sw,sw,sw,s,nw,n,sw,sw,s,sw,sw,sw,sw,sw,sw,sw,nw,ne,nw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,sw,nw,nw,nw,nw,ne,sw,nw,nw,n,sw,sw,sw,n,sw,nw,nw,sw,sw,sw,nw,sw,sw,nw,sw,nw,sw,sw,sw,sw,nw,sw,nw,nw,sw,sw,sw,nw,sw,nw,sw,sw,sw,se,nw,ne,nw,nw,se,sw,sw,n,sw,ne,nw,sw,sw,sw,sw,sw,s,nw,sw,sw,se,n,sw,nw,s,sw,sw,sw,sw,sw,nw,n,sw,sw,nw,sw,s,sw,sw,sw,nw,ne,nw,sw,nw,sw,sw,nw,sw,nw,se,sw,sw,sw,s,n,nw,sw,nw,nw,se,sw,nw,n,ne,sw,nw,sw,sw,n,n,sw,nw,nw,sw,nw,s,nw,s,nw,sw,sw,nw,nw,s,sw,sw,nw,nw,nw,s,sw,nw,nw,sw,nw,sw,sw,sw,nw,nw,sw,sw,nw,nw,nw,sw,s,sw,nw,nw,nw,nw,sw,sw,nw,nw,sw,sw,nw,s,nw,sw,se,sw,nw,s,nw,sw,ne,nw,sw,sw,nw,sw,nw,ne,sw,nw,nw,nw,nw,sw,nw,nw,ne,sw,se,sw,se,sw,n,sw,nw,sw,nw,nw,se,nw,nw,nw,nw,s,nw,nw,nw,nw,sw,sw,nw,nw,ne,sw,n,se,sw,nw,nw,sw,nw,nw,n,sw,sw,sw,nw,nw,sw,ne,se,nw,nw,nw,nw,nw,n,sw,s,nw,nw,sw,nw,nw,ne,nw,nw,nw,nw,se,nw,nw,sw,nw,sw,sw,nw,ne,nw,nw,sw,nw,sw,nw,sw,n,se,se,sw,nw,n,nw,nw,sw,nw,nw,nw,sw,sw,nw,se,nw,nw,ne,nw,sw,se,nw,n,sw,ne,se,sw,sw,sw,nw,sw,se,nw,sw,sw,nw,s,ne,n,nw,nw,s,s,nw,sw,ne,nw,sw,nw,sw,n,nw,n,sw,nw,nw,nw,nw,sw,nw,sw,sw,nw,nw,nw,sw,sw,se,nw,se,ne,sw,nw,nw,sw,nw,sw,sw,se,sw,ne,nw,nw,nw,sw,sw,nw,n,nw,s,sw,nw,nw,nw,nw,sw,nw,nw,nw,nw,nw,sw,sw,s,nw,sw,sw,nw,nw,nw,nw,sw,nw,nw,nw,sw,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,sw,nw,nw,nw,nw,se,nw,nw,nw,nw,se,nw,nw,nw,n,ne,nw,nw,nw,nw,nw,ne,nw,sw,se,nw,sw,nw,nw,ne,nw,nw,nw,nw,nw,nw,nw,nw,ne,sw,nw,nw,nw,s,se,sw,nw,nw,ne,nw,nw,nw,nw,nw,se,nw,nw,nw,nw,ne,sw,ne,nw,nw,se,sw,sw,nw,nw,nw,nw,n,nw,nw,sw,se,nw,se,nw,nw,se,nw,nw,nw,nw,nw,sw,nw,nw,nw,nw,nw,se,s,nw,n,nw,nw,nw,nw,nw,nw,sw,se,nw,ne,nw,se,nw,nw,nw,nw,nw,nw,nw,nw,s,nw,sw,se,nw,nw,n,sw,nw,nw,nw,nw,se,se,nw,sw,nw,n,n,s,ne,nw,nw,nw,n,nw,n,s,n,se,nw,nw,sw,sw,n,nw,nw,nw,sw,se,se,nw,nw,nw,nw,nw,nw,nw,n,nw,nw,nw,nw,nw,nw,nw,nw,nw,nw,s,s,nw,nw,nw,nw,nw,nw,nw,nw,nw,n,nw,nw,nw,nw,nw,nw,nw,n,nw,nw,nw,nw,se,nw,nw,nw,n,nw,n,nw,s,n,nw,ne,nw,nw,nw,nw,n,nw,nw,nw,nw,nw,nw,nw,n,nw,nw,sw,s,nw,nw,nw,s,nw,nw,nw,nw,n,nw,n,nw,nw,nw,sw,s,nw,nw,nw,n,n,nw,nw,nw,se,nw,nw,sw,nw,nw,n,nw,nw,nw,sw,nw,nw,nw,nw,ne,n,nw,nw,nw,nw,nw,ne,nw,sw,nw,n,nw,n,ne,nw,nw,sw,sw,n,n,se,n,se,n,se,n,nw,sw,n,nw,ne,nw,se,n,nw,nw,n,nw,n,n,nw,nw,nw,nw,nw,nw,n,nw,nw,se,nw,n,n,n,ne,se,n,nw,sw,sw,se,nw,nw,nw,n,nw,se,n,nw,nw,nw,nw,nw,n,nw,nw,n,s,se,n,sw,n,nw,s,n,n,nw,n,nw,nw,nw,nw,n,nw,sw,se,nw,n,nw,nw,nw,n,nw,nw,s,n,sw,nw,nw,nw,n,nw,se,n,n,sw,nw,nw,n,se,s,nw,n,n,ne,nw,nw,nw,nw,n,n,n,s,n,nw,nw,nw,n,nw,nw,sw,nw,nw,sw,n,n,nw,n,nw,s,nw,nw,ne,nw,n,sw,nw,nw,nw,nw,s,n,nw,nw,ne,nw,n,n,nw,nw,nw,nw,n,s,n,n,nw,n,nw,n,n,nw,n,nw,nw,n,n,s,nw,s,nw,n,nw,n,ne,n,s,s,n,n,n,nw,n,s,n,se,nw,nw,n,nw,nw,se,n,n,nw,n,n,nw,ne,nw,se,n,nw,n,n,nw,nw,nw,nw,n,nw,n,nw,nw,se,nw,s,n,nw,n,nw,se,nw,n,nw,nw,n,n,s,nw,nw,nw,nw,n,n,n,n,nw,ne,nw,ne,n,nw,s,n,n,n,se,n,n,nw,n,nw,nw,nw,nw,nw,n,nw,n,nw,nw,nw,n,s,nw,nw,nw,n,nw,n,sw,ne,n,nw,nw,nw,nw,n,s,n,nw,se,nw,nw,n,se,n,s,nw,n,nw,n,nw,n,n,nw,se,ne,se,nw,nw,n,nw,n,n,n,n,nw,sw,n,n,n,n,se,sw,sw,nw,nw,n,n,ne,ne,se,sw,se,n,nw,se,n,ne,n,n,n,n,n,s,nw,se,se,n,n,nw,nw,se,nw,sw,n,n,nw,nw,n,n,n,sw,n,n,n,n,n,n,n,n,n,n,se,n,nw,ne,n,se,sw,n,ne,n,s,nw,n,n,nw,n,nw,s,n,n,n,nw,nw,nw,nw,sw,ne,n,n,ne,n,n,n,n,n,n,n,n,nw,nw,s,n,s,n,n,n,n,n,sw,nw,nw,n,n,n,nw,nw,s,n,n,nw,nw,n,nw,nw,n,sw,n,nw,se,nw,n,n,n,n,ne,n,nw,n,s,n,nw,se,nw,s,nw,n,n,n,sw,n,n,n,n,s,n,n,n,n,nw,n,sw,n,n,nw,s,se,n,se,n,ne,n,s,nw,n,n,n,n,n,nw,s,nw,nw,ne,n,n,n,n,n,n,nw,ne,se,sw,n,n,n,n,n,se,n,n,sw,n,n,nw,ne,n,nw,sw,n,n,n,n,ne,n,s,n,n,n,s,n,n,s,n,n,se,n,n,s,se,se,n,n,n,se,nw,n,n,n,n,sw,nw,n,n,n,n,ne,ne,n,n,sw,n,n,n,n,n,n,nw,nw,ne,n,n,n,n,se,n,n,n,ne,n,n,s,n,nw,n,n,n,ne,n,nw,n,n,n,nw,n,n,n,n,n,n,nw,n,n,se,n,nw,nw,n,s,n,ne,s,n,s,n,n,n,n,n,se,n,n,nw,n";
    public override Task ExecuteAsync()
    {
        var location = (0, 0);
        int max = 0;
        foreach (var step in input.Split(','))
        {
            location = step switch
            {
                "n" => (location.Item1 + 1, location.Item2),
                "ne" => (location.Item1 + 1, location.Item2 - 1),
                "se" => (location.Item1, location.Item2 - 1),
                "s" => (location.Item1 - 1, location.Item2),
                "sw" => (location.Item1 - 1, location.Item2 + 1),
                "nw" => (location.Item1, location.Item2 + 1),
                _ => throw new Exception("waarheen?")
            };
            max = Math.Max(max, Math.Abs(location.Item1) + Math.Abs(location.Item2));
        }

        Result = $"{Math.Abs(location.Item1) + Math.Abs(location.Item2)}   {max}";
        return Task.CompletedTask;
    }

    public override int Nummer => 201711;
}