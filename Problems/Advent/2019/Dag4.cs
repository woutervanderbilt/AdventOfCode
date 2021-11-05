using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2019
{
    public class Dag4 : Problem
    {
        public override Task ExecuteAsync()
        {
            Console.WriteLine(IsValidPass(667777));
            Result = Enumerable.Range(264360, 746325 - 264360).Count(IsValidPass).ToString();

            bool IsValidPass(int q)
            {
                int p = q;
                bool same = false;
                int sameCount = 0;
                int c = 10;
                while (p > 0)
                {
                    if(p%10 > c)
                    {
                        return false;
                    }

                    if (p % 10 == c)
                    {
                        sameCount++;
                    }
                    else
                    {
                        if (sameCount == 1)
                        {
                            same = true;
                        }
                        sameCount = 0;
                    }
                    

                    c = p % 10;
                    p /= 10;
                }
                return same || sameCount == 1;
            }
            return Task.CompletedTask;
        }

        public override int Nummer => 201904;
    }
}
