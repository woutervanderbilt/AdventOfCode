using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2015;

internal class Dag22 : Problem
{
    public override Task ExecuteAsync()
    {
        var visitedStates = new HashSet<State>();
        var lastAddedStates = new List<State>();
        var startingState = new State()
        {
            PlayerHitPoints = 50,
            PlayerMana = 500,
            BossHitPoints = 58
        };
        visitedStates.Add(startingState);
        lastAddedStates.Add(startingState);
        int minCost = int.MaxValue;
        while (lastAddedStates.Any())
        {
            var newLastAddedStates = new List<State>();
            foreach (var state in lastAddedStates)
            {
                foreach (var nextState in state.NextStates().Where(s => s != null))
                {
                    if (nextState.BossHitPoints <= 0)
                    {
                        if (nextState.TotalCost < minCost)
                        {
                            Console.WriteLine(nextState.TotalCost);
                            minCost = nextState.TotalCost;
                        }
                    }
                    else if (visitedStates.Add(nextState))
                    {
                        newLastAddedStates.Add(nextState);
                    }
                }
            }

            lastAddedStates = newLastAddedStates;
        }
        return Task.CompletedTask;
    }

    private class State
    {
        private const int BossDamage = 9;
        public int PlayerHitPoints { get; set; }
        public int PlayerMana { get; set; }
        public int PlayerArmor { get; set; }
        public int BossHitPoints { get; set; }
        public int TotalCost { get; set; }

        public int Shield { get; set; }
        public int Poison { get; set; }
        public int Recharge { get; set; }

        public IEnumerable<State> NextStates()
        {
            yield return CastMagicMissile();
            yield return CastDrain();
            yield return CastPoison();
            yield return CastShield();
            yield return CastRecharge();
        }

        public State CastMagicMissile()
        {
            if (PlayerMana < 53)
            {
                return null;
            }

            var state = Copy();
            if (state.PlayerHitPoints == 0)
            {
                return null;
            }
            state.BossHitPoints -= 4;
            state.PlayerMana -= 53;
            state.TotalCost += 53;
            if (state.BossHitPoints <= 0)
            {
                return state;
            }
            state.BossTurn();
            if (state.PlayerHitPoints <= 0)
            {
                return null;
            }

            if (state.BossHitPoints <= 0)
            {
                return state;
            }
            state.ApplyLastingEffects();
            return state;
        }

        public State CastDrain()
        {
            if (PlayerMana < 73)
            {
                return null;
            }
            var state = Copy();
            if (state.PlayerHitPoints == 0)
            {
                return null;
            }
            state.BossHitPoints -= 2;
            state.PlayerHitPoints += 2;
            state.PlayerMana -= 73;
            state.TotalCost += 73;
            state.BossTurn();
            if (state.PlayerHitPoints <= 0)
            {
                return null;
            }

            if (state.BossHitPoints <= 0)
            {
                return state;
            }
            state.ApplyLastingEffects();
            return state;
            return state;
        }

        public State CastShield()
        {
            if (PlayerMana < 113 || Shield > 0)
            {
                return null;
            }
            var state = Copy();
            if (state.PlayerHitPoints == 0)
            {
                return null;
            }
            state.PlayerMana -= 113;
            state.TotalCost += 113;
            state.Shield = 6;
            state.PlayerArmor += 7;
            state.BossTurn();
            if (state.PlayerHitPoints <= 0)
            {
                return null;
            }

            if (state.BossHitPoints <= 0)
            {
                return state;
            }
            state.ApplyLastingEffects();
            return state;
        }

        public State CastPoison()
        {
            if (PlayerMana < 173 || Poison > 0)
            {
                return null;
            }
            var state = Copy();
            if (state.PlayerHitPoints == 0)
            {
                return null;
            }
            state.PlayerMana -= 173;
            state.TotalCost += 173;
            state.Poison = 6;
            state.BossTurn();
            if (state.PlayerHitPoints <= 0)
            {
                return null;
            }

            if (state.BossHitPoints <= 0)
            {
                return state;
            }
            state.ApplyLastingEffects();
            return state;
        }

        public State CastRecharge()
        {
            if (PlayerMana < 229 || Recharge > 0)
            {
                return null;
            }
            var state = Copy();
            if (state.PlayerHitPoints == 0)
            {
                return null;
            }
            state.PlayerMana -= 229;
            state.TotalCost += 229;
            state.Recharge = 5;
            state.BossTurn();
            if (state.PlayerHitPoints <= 0)
            {
                return null;
            }

            if (state.BossHitPoints <= 0)
            {
                return state;
            }
            state.ApplyLastingEffects();
            return state;
        }

        void ApplyLastingEffects()
        {
            if (Shield > 0)
            {
                Shield--;
                if (Shield == 0)
                {
                    PlayerArmor -= 7;
                }
            }

            if (Poison > 0)
            {
                BossHitPoints -= 3;
                Poison--;
            }

            if (Recharge > 0)
            {
                PlayerMana += 101;
                Recharge--;
            }
        }

        State Copy()
        {
            return new State
            {
                BossHitPoints = BossHitPoints,
                PlayerArmor = PlayerArmor,
                PlayerMana = PlayerMana,
                Poison = Poison,
                Shield = Shield,
                Recharge = Recharge,
                PlayerHitPoints = PlayerHitPoints - 1,
                TotalCost = TotalCost
            };
        }

        void BossTurn()
        {
            ApplyLastingEffects();
            if (PlayerHitPoints > 0 && BossHitPoints > 0)
            {
                PlayerHitPoints -= Math.Max(1, BossDamage - PlayerArmor);
            }
        }

        public override bool Equals(object? obj)
        {
            return Equals((State)obj);
        }

        protected bool Equals(State other)
        {
            return PlayerHitPoints == other.PlayerHitPoints && PlayerMana == other.PlayerMana && PlayerArmor == other.PlayerArmor && BossHitPoints == other.BossHitPoints && TotalCost == other.TotalCost && Shield == other.Shield && Poison == other.Poison && Recharge == other.Recharge;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PlayerHitPoints, PlayerMana, PlayerArmor, BossHitPoints, TotalCost, Shield, Poison, Recharge);
        }
    }

    public override int Nummer => 201522;
}