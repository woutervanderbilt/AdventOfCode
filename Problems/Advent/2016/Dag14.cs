using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problems.Advent
{
    public class Dag14 : Problem
    {
        private const string input = "jlmsuwbz";

        public override Task ExecuteAsync()
        {
            var provider = new MD5CryptoServiceProvider();
            int i = 0;
            IList<char> chars = new List<char>
                {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'};
            IDictionary<char, IList<int>> triples = new Dictionary<char, IList<int>>();
            IList<int> keys = new List<int>();
            foreach (var c in chars)
            {
                triples[c] = new List<int>();
            }

            while (keys.Count < 100)
            {
                var hash = provider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(input + i));
                var hexhash = ByteArrayToString(hash);
                for (int j = 1; j <= 2016; j++)
                {
                    hexhash = ByteArrayToString(provider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(hexhash)));
                }
                char? prev = null;
                bool two = false;
                foreach (var h in hexhash)
                {
                    if (h == prev)
                    {
                        if (two)
                        {
                            triples[h].Add(i);
                            break;
                        }
                        else
                        {
                            two = true;
                        }
                    }
                    else
                    {
                        two = false;
                    }

                    prev = h;
                }

                foreach (var c in chars)
                {
                    if (hexhash.Contains($"{c}{c}{c}{c}{c}"))
                    {
                        foreach (var t in triples[c])
                        {
                            if (keys.Contains(t))
                            {
                                continue;
                            }

                            if (t < i && t + 1000 > i)
                            {
                                keys.Add(t);
                            }
                        }
                    }
                }


                i++;
            }

            Result = keys.OrderBy(k => k).ToList()[63].ToString();
            return Task.CompletedTask;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }


        public override int Nummer => 201614;
    }
}
