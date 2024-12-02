using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent;

public class Dag17 : Problem
{
    private const string input = "pslxynzg";

    public override Task ExecuteAsync()
    {
        var provider = new MD5CryptoServiceProvider();
        IDictionary<(int, int), IList<string>> paths = EmptyDictionary();
        paths[(1, 1)].Add("");
        var open = new List<char> { 'b', 'c', 'd', 'e', 'f' };
        while (true)
        {
            var next = EmptyDictionary();
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    foreach (var path in paths[(i, j)])
                    {
                        var hash = provider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input + path));
                        var hexhash = ByteArrayToString(hash);
                        for (int k = 0; k < 4; k++)
                        {
                            if (open.Contains(hexhash[k]))
                            {
                                if (k == 0)
                                {
                                    if (i > 1)
                                    {
                                        next[(i - 1, j)].Add(path + "U");
                                    }
                                }
                                else if (k == 1)
                                {
                                    if (i < 4)
                                    {
                                        next[(i + 1, j)].Add(path + "D");
                                    }
                                }
                                else if (k == 2)
                                {
                                    if (j > 1)
                                    {
                                        next[(i, j - 1)].Add(path + "L");
                                    }
                                }
                                else
                                {
                                    if (j < 4)
                                    {
                                        next[(i, j + 1)].Add(path + "R");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            paths = next;
            if (paths[(4, 4)].Any())
            {
                Console.WriteLine(paths[(4, 4)].FirstOrDefault().Length);
                paths[(4, 4)].Clear();
            }
        }

        Result = paths[(4, 4)].Single();
        return Task.CompletedTask;

        IDictionary<(int, int), IList<string>> EmptyDictionary()
        {
            var dict = new Dictionary<(int, int), IList<string>>();
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    dict[(i, j)] = new List<string>();
                }
            }

            return dict;
        }
    }

    public static string ByteArrayToString(byte[] ba)
    {
        StringBuilder hex = new StringBuilder(ba.Length * 2);
        foreach (byte b in ba)
            hex.AppendFormat("{0:x2}", b);
        return hex.ToString();
    }

    public override int Nummer => 201617;
}