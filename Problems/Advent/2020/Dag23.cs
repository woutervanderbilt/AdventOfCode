using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2020
{
    public class Dag23 : Problem
    {
        #region input

        private const string input = @"135468729";
        private const string testinput = @"389125467";

        private const int NumberOfCups = 1000000;
        private const int NumberOfSteps = 10000000;
        #endregion
        public override Task ExecuteAsync()
        {
            Cup[] cupsByNumber = new Cup[NumberOfCups + 1];
            Cup lastCup = null;
            Cup current = null;
            foreach (var i in input.Select(c => int.Parse(c.ToString())).ToList())
            {
                var newCup = new Cup
                {
                    Number = i, 
                    //Previous = lastCup
                };
                if (lastCup != null)
                {
                    lastCup.Next = newCup;
                }

                lastCup = newCup;
                cupsByNumber[i] = newCup;
                if (current == null)
                {
                    current = newCup;
                }
            }
            for (int i = input.Length + 1; i <= NumberOfCups; i++)
            {
                var newCup = new Cup
                {
                    Number = i, 
                    //Previous = lastCup
                };
                lastCup.Next = newCup;
                lastCup = newCup;
                cupsByNumber[i] = newCup;
            }

            lastCup.Next = current;
            //current.Previous = lastCup;

            var sw = Stopwatch.StartNew();
            for (int i = 1; i <= NumberOfSteps; i++)
            {
                Step();
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Result = ((long) cupsByNumber[1].Next.Number * cupsByNumber[1].Next.Next.Number).ToString();


            return Task.CompletedTask;

            void Step()
            {
                var firstMove = current.Next;
                var secondMove = firstMove.Next;
                var thirdMove = secondMove.Next;
                current.Next = thirdMove.Next;
                //firstMove.Previous.Next = thirdMove.Next;
                //thirdMove.Next.Previous = firstMove.Previous;
                int insertAfter = current.Number - 1;
                if (insertAfter == 0)
                {
                    insertAfter = NumberOfCups;
                }

                while (insertAfter == firstMove.Number || insertAfter == secondMove.Number ||
                       insertAfter == thirdMove.Number)
                {
                    insertAfter--;
                    if (insertAfter == 0)
                    {
                        insertAfter = NumberOfCups;
                    }
                }

                var inserAfterNode = cupsByNumber[insertAfter];
                thirdMove.Next = inserAfterNode.Next;
                //thirdMove.Next.Previous = thirdMove;
                inserAfterNode.Next = firstMove;
                //firstMove.Previous = inserAfterNode;
                current = current.Next;
            }
        }

        private class Cup
        {
            public int Number { get; set; }
            public Cup Next { get; set; }
            //public Cup Previous { get; set; }
        }

        public override int Nummer => 202023;
    }
}
