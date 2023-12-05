using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2020;

public class Dag22 : Problem
{
    #region input

    private const string input = @"Player 1:
1
10
28
29
13
11
35
7
43
8
30
25
4
5
17
32
22
39
50
46
16
26
45
38
21

Player 2:
19
40
2
12
49
23
34
47
9
14
20
24
42
37
48
44
27
6
33
18
15
3
36
41
31";
    #endregion

    private const string testinput = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";
    public override Task ExecuteAsync()
    {
        var game = new Game();
        bool isPlayer1 = true;
        foreach (var s in input.Split(Environment.NewLine))
        {
            if (s.StartsWith("Player"))
            {
                continue;
            }

            if (string.IsNullOrWhiteSpace(s))
            {
                isPlayer1 = false;
                continue;
            }

            if (isPlayer1)
            {
                game.Player1.AddLast(int.Parse(s));
            }
            else
            {
                game.Player2.AddLast(int.Parse(s));
            }
        }

        game.Play();

        Result = game.Value().ToString();

        return Task.CompletedTask;
    }

    private class Game
    {
        public LinkedList<int> Player1 { get; set; } = new LinkedList<int>();
        public LinkedList<int> Player2 { get; set;  } = new LinkedList<int>();

        public bool Player1Won { get; set; }

        IDictionary<long, IList<(IList<int>, IList<int>)>> history = new Dictionary<long, IList<(IList<int>, IList<int>)>>();


        public void Play()
        {
            while (Player1.Any() && Player2.Any())
            {
                long hash = 0;
                unchecked
                {
                    foreach (var i in Player1)
                    {
                        hash = 17 * hash + i;
                    }
                    foreach (var i in Player2)
                    {
                        hash = 19 * hash + i;
                    }
                }

                bool contains = history.ContainsKey(hash);
                if (contains)
                {
                    if (history[hash].Any(h => h.Item1.SequenceEqual(Player1) && h.Item2.SequenceEqual(Player2)))
                    {
                        Player1Won = true;
                        return;
                    }
                }

                if (!contains)
                {
                    history[hash] = new List<(IList<int>, IList<int>)>();
                }
                history[hash].Add((new List<int>(Player1), new List<int>(Player2)));
                var p1 = Player1.First;
                var p2 = Player2.First;
                Player1.RemoveFirst();
                Player2.RemoveFirst();
                if (Player1.Count < p1.Value || Player2.Count < p2.Value)
                {
                    if (p1.Value > p2.Value)
                    {
                        Player1.AddLast(p1);
                        Player1.AddLast(p2);
                    }
                    else
                    {
                        Player2.AddLast(p2);
                        Player2.AddLast(p1);
                    }
                }
                else
                {
                    var subGame = new Game()
                    {
                        Player1 = new LinkedList<int>(Player1.Take(p1.Value)),
                        Player2 = new LinkedList<int>(Player2.Take(p2.Value))
                    };
                    subGame.Play();
                    if (subGame.Player1Won)
                    {
                        Player1.AddLast(p1);
                        Player1.AddLast(p2);
                    }
                    else
                    {
                        Player2.AddLast(p2);
                        Player2.AddLast(p1);
                    }
                }
            }

            Player1Won = Player1.Any();
        }

        public long Value()
        {
            long result = 0;
            var winningPlayer = Player1Won ? Player1 : Player2;
            long factor = winningPlayer.Count;
            foreach (var i in winningPlayer)
            {
                result += factor * i;
                factor--;
            }

            return result;
        }
    }

    public override int Nummer => 202022;
}