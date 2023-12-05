using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent;

public class Dag18 : Problem
{
    private const string input = ".^^..^...^..^^.^^^.^^^.^^^^^^.^.^^^^.^^.^^^^^^.^...^......^...^^^..^^^.....^^^^^^^^^....^^...^^^^..^";

    public override Task ExecuteAsync()
    {
        IList<string> maze = new List<string>();
        var row = input;
        maze.Add(row);
        //Console.WriteLine(row);
        while (maze.Count < 400000)
        {
            row = Next(row);
            //Console.WriteLine(row);
            maze.Add(row);
        }

        Result = maze.Sum(l => l.Count(c => c == '.')).ToString();

        string Next(string current)
        {
            string extendedRow = $".{current}.";
            var sb = new StringBuilder();
            char a = 'x';
            char b = 'x';
            foreach (var c in extendedRow)
            {
                if (a != 'x')
                {
                    var s = $"{a}{b}{c}";
                    if (s == "^^." || s == ".^^" || s == "^.." || s == "..^")
                    {
                        sb.Append('^');
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }

                (a, b) = (b, c);
            }

            return sb.ToString();
        }
        return Task.CompletedTask;
    }

    public override int Nummer => 201618;
}