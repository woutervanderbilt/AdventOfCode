using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent
{
    public class Dag16 : Problem
    {
        private const int Length = 35651584;
        private const string input = "10001001100000001";

        public override Task ExecuteAsync()
        {
            string state = input;
            while (state.Length < Length)
            {
                var sb = new StringBuilder(state).Append("0");
                foreach (var c in state.Reverse())
                {
                    if (c == '0')
                    {
                        sb.Append('1');
                    }
                    else
                    {
                        sb.Append('0');
                    }
                }

                state = sb.ToString();
            }

            state = state.Substring(0, Length);
            while (state.Length % 2 == 0)
            {
                var sb = new StringBuilder();
                char? prev = null;
                foreach (var c in state)
                {
                    if (prev == null)
                    {
                        prev = c;
                    }
                    else
                    {
                        sb.Append(c == prev ? '1' : '0');
                        prev = null;
                    }
                }

                state = sb.ToString();
            }

            Result = state;

            return Task.CompletedTask;
        }

        public override int Nummer => 201616;
    }
}
