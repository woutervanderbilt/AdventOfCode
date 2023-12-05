using System;
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
        Problem problem = null;
        while (problem == null)
        {
            Console.WriteLine("Geef nummer van probleem op:");
            var input = Console.ReadLine();
            int nummer;
            if (int.TryParse(input, out nummer) && ProblemDefinitions.Problems.ContainsKey(nummer))
            {
                problem = ProblemDefinitions.Problems[nummer];
                var sw = new Stopwatch();
                sw.Start();
                await problem.ExecuteAsync();
                sw.Stop();
                Console.WriteLine($"Oplossing: {problem.Result}  ({sw.ElapsedMilliseconds} ms)");
                if (!string.IsNullOrWhiteSpace(problem.Result))
                {
                    File.AppendAllLines(@"C:\temp\Eulerruns.txt",
                        new[]
                        {
                            $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} Problem {input}: {problem.Result}"
                        });
                }

                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Ongeldig nummer");
            }
        }
    }
}