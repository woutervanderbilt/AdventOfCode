using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Extensions;

namespace Problems.Advent._2015
{
    internal class Dag11 : Problem
    {
        private const string input = @"vzbxkghb";
        public override Task ExecuteAsync()
        {
            const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            long pass = NumericValue(input) + 1;
            while (!IsValid(pass))
            {
                pass++;
            }

            pass++;
            while (!IsValid(pass))
            {
                pass++;
            }

            Result = Pass(pass);

            return Task.CompletedTask;

            long NumericValue(string pass)
            {
                long power = 1;
                long result = 0;
                foreach (var c in pass.Reverse())
                {
                    result += power * alphabet.IndexOf(c);
                    power *= 26;
                }

                return result;
            }

            string Pass(long pass)
            {
                var sb = new StringBuilder();
                for (int i = 1; i <= 8; i++)
                {
                    sb.Append(alphabet[(int)(pass % 26)]);
                    pass /= 26;
                }

                return new string(sb.ToString().Reverse().ToArray());
            }

            bool IsValid(long pass)
            {
                int prev = -1;
                bool step = false;
                int chain = 0;
                int repeatCount = 0;
                int firstRepeat = -1;
                for (int i = 1; i <= 8; i++)
                {
                    var d = (int)(pass % 26);
                    if (d == 8 || d == 11 || d == 14)
                    {
                        return false;
                    }
                    if(d == prev && d != firstRepeat)
                    {
                        firstRepeat = d;
                        repeatCount++;
                    }

                    if (d == prev - 1)
                    {
                        chain++;
                        if (chain == 3)
                        {
                            step = true;
                        }
                    }
                    else
                    {
                        chain = 1;
                    }
                    pass /= 26;
                    prev = d;
                }

                if (step && repeatCount >= 2)
                {
                    return true;
                }

                return false;
            }
        }

        public override int Nummer => 201511;
    }
}
