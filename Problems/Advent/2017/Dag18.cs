using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2017;

internal class Dag18 : Problem
{
    const string input = @"set i 31
set a 1
mul p 17
jgz p p
mul a 2
add i -1
jgz i -2
add a -1
set i 127
set p 622
mul p 8505
mod p a
mul p 129749
add p 12345
mod p a
set b p
mod b 10000
snd b
add i -1
jgz i -9
jgz a 3
rcv b
jgz b -1
set f 0
set i 126
rcv a
rcv b
set p a
mul p -1
add p b
jgz p 4
snd a
set a b
jgz 1 3
snd b
set f 1
add i -1
jgz i -11
snd a
jgz f -16
jgz a -19";
    public override Task ExecuteAsync()
    {
        int totalSends = 0;
        CounterLong<string> register1 = new CounterLong<string>();
        CounterLong<string> register2 = new CounterLong<string>();
        register2["p"] = 1;
        bool terminated1 = false;
        bool terminated2 = false;
        IList<string> instructions = input.Split(Environment.NewLine);
        var pointer1 = 0;
        var pointer2 = 0;
        Queue<long> sentTo1 = new Queue<long>();
        Queue<long> sentTo2 = new Queue<long>();
        while(!(terminated1 && terminated2))
        {
            bool dl1 = false;
            bool dl2 = false;
            if (!terminated1)
            {
                dl1 = Step(false, register1, sentTo2, sentTo1, ref pointer1, ref terminated1);
            }

            if (!terminated2)
            {
                dl2 = Step(true, register2, sentTo1, sentTo2, ref pointer2, ref terminated2);
            }

            if (dl1 && dl2)
            {
                break;
            }
        }

        Result = totalSends.ToString();

        bool Step(bool isCountDevice, CounterLong<string> register, Queue<long> sendTo, Queue<long> receiveFrom, ref int pointer, ref bool terminated)
        {
            if (pointer < 0 || pointer >= instructions.Count)
            {
                terminated = true;
                return false;
            }
            var instruction = instructions[pointer];
            pointer++;
            var words = instruction.Split(' ');
            switch (words[0])
            {
                case "snd":
                    sendTo.Enqueue(Value(words[1]));
                    if (isCountDevice)
                    {
                        totalSends++;
                    }
                    break;
                case "set":
                    register[words[1]] = Value(words[2]);
                    break;
                case "add":
                    register[words[1]] += Value(words[2]);
                    break;
                case "mul":
                    register[words[1]] *= Value(words[2]);
                    break;
                case "mod":
                    register[words[1]] %= Value(words[2]);
                    break;
                case "rcv":
                    if (receiveFrom.TryDequeue(out var v))
                    {
                        register[words[1]] = v;
                    }
                    else
                    {
                        pointer--;
                        return true;
                    }
                    break;
                case "jgz":
                    if (Value(words[1]) > 0)
                    {
                        pointer--;
                        pointer += (int)Value(words[2]);
                    }
                    break;
            }

            return false;

            long Value(string r)
            {
                if (long.TryParse(r, out var v))
                {
                    return v;
                }

                return register[r];
            }
        }

        return Task.CompletedTask;
    }

    public override int Nummer => 201718;
}