﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problems;

namespace Euler;

class Program
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Geef nummer van probleem op:");
            var input = Console.ReadLine();
            int nummer;
            if (int.TryParse(input, out nummer) && ProblemDefinitions.Problems.ContainsKey(nummer))
            {
                var problem = ProblemDefinitions.Problems[nummer]();
                await problem.Initialize();
                var sw = new Stopwatch();
                sw.Start();
                await problem.ExecuteAsync();
                sw.Stop();
                Console.WriteLine($"Oplossing: {problem.Result}  ({sw.ElapsedMilliseconds} ms)");
                if (!string.IsNullOrWhiteSpace(problem.Result))
                {
                    File.AppendAllLines(@"C:\temp\AdventOfOCodeRuns.txt",
                        new[]
                        {
                            $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Problem {input}: {problem.Result} ({sw.ElapsedMilliseconds}ms)"
                        });
                }
            }
            else
            {
                Console.WriteLine("Ongeldig nummer");
            }
        }
    }
}