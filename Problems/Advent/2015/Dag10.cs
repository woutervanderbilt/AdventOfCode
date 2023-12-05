using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2015;

internal class Dag10 : Problem
{
    private const string input = @"1113122113";
    public override Task ExecuteAsync()
    {
        var n = input;
        for (int i = 1; i <= 50; i++)
        {
            n = Step(n);
        }

        Result = n.Length.ToString();
        return Task.CompletedTask;

        string Step(string s)
        {
            char prev = ' ';
            var sb = new StringBuilder();
            int count = 0;
            bool first = true;
            foreach (var c in s)
            {
                if (c == prev)
                {
                    count++;
                }
                else 
                {
                    if (!first)
                    {
                        sb.Append(count).Append(prev);
                    }

                    count = 1;
                }

                first = false;
                prev = c;
            }

            sb.Append(count).Append(prev);

            return sb.ToString();
        }
    }

    public override int Nummer => 201510;
}