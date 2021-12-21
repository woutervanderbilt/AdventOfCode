using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2018
{
    internal class Dag24 : Problem
    {
        private const string input = @"Immune System:
2208 units each with 6238 hit points (immune to slashing) with an attack that does 23 bludgeoning damage at initiative 20
7603 units each with 6395 hit points (weak to radiation) with an attack that does 6 cold damage at initiative 15
4859 units each with 5904 hit points (weak to fire) with an attack that does 12 cold damage at initiative 11
1608 units each with 7045 hit points (weak to fire, cold; immune to bludgeoning, radiation) with an attack that does 31 radiation damage at initiative 10
39 units each with 4208 hit points with an attack that does 903 radiation damage at initiative 7
6969 units each with 9562 hit points (immune to slashing, cold) with an attack that does 13 slashing damage at initiative 3
2483 units each with 6054 hit points (immune to fire) with an attack that does 20 cold damage at initiative 19
506 units each with 3336 hit points with an attack that does 64 radiation damage at initiative 6
2260 units each with 10174 hit points (weak to fire) with an attack that does 34 slashing damage at initiative 5
2817 units each with 9549 hit points (immune to cold, fire; weak to bludgeoning) with an attack that does 31 cold damage at initiative 2

Infection:
3650 units each with 25061 hit points (weak to fire, bludgeoning) with an attack that does 11 slashing damage at initiative 12
508 units each with 48731 hit points (weak to bludgeoning) with an attack that does 172 cold damage at initiative 13
724 units each with 27385 hit points with an attack that does 69 radiation damage at initiative 1
188 units each with 41786 hit points with an attack that does 416 bludgeoning damage at initiative 4
3045 units each with 36947 hit points (weak to slashing; immune to fire, bludgeoning) with an attack that does 24 slashing damage at initiative 9
7006 units each with 42545 hit points (immune to cold, slashing, fire) with an attack that does 9 fire damage at initiative 16
853 units each with 55723 hit points (weak to cold, fire) with an attack that does 114 bludgeoning damage at initiative 17
3268 units each with 43027 hit points (immune to slashing, fire) with an attack that does 25 slashing damage at initiative 8
1630 units each with 47273 hit points (weak to cold, bludgeoning) with an attack that does 57 slashing damage at initiative 14
3383 units each with 12238 hit points with an attack that does 7 radiation damage at initiative 18";

        private const string testinput = @"Immune System:
17 units each with 5390 hit points (weak to radiation, bludgeoning) with an attack that does 4507 fire damage at initiative 2
989 units each with 1274 hit points (immune to fire; weak to bludgeoning, slashing) with an attack that does 25 slashing damage at initiative 3

Infection:
801 units each with 4706 hit points (weak to radiation) with an attack that does 116 bludgeoning damage at initiative 1
4485 units each with 2961 hit points (immune to radiation; weak to fire, cold) with an attack that does 12 slashing damage at initiative 4";
        public override Task ExecuteAsync()
        {
            int boost = 51;
            IList<Group> immuneSystem = new List<Group>();
            IList<Group> infection = new List<Group>();
            var currentList = immuneSystem;
            var isImmune = true;
            foreach (var line in input.Split(Environment.NewLine))
            {
                if (line.StartsWith("Immune") || string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                else if (line.StartsWith("Infection"))
                {
                    currentList = infection;
                    isImmune = false;
                    continue;
                }

                var words = line.Replace("(","").Split(' ').ToList();
                var group = new Group();
                group.IsImmuneGroup = isImmune;
                group.NumberOfUnits = int.Parse(words[0]);
                group.HitPointsPerUnit = int.Parse(words[4]);
                var immuneIndex = words.IndexOf("immune");
                if (immuneIndex >= 0)
                {
                    immuneIndex += 2;
                    var immuneTo = words[immuneIndex];
                    while (!immuneTo.EndsWith(")") && !immuneTo.EndsWith(";"))
                    {
                        group.ImmuneTo.Add(immuneTo.Remove(immuneTo.Length - 1));
                        immuneIndex++;
                        immuneTo = words[immuneIndex];
                    }
                    group.ImmuneTo.Add(immuneTo.Remove(immuneTo.Length - 1));
                }
                var weakIndex = words.IndexOf("weak");
                if (weakIndex >= 0)
                {
                    weakIndex += 2;
                    var weakTo = words[weakIndex];
                    while (!weakTo.EndsWith(")") && !weakTo.EndsWith(";"))
                    {
                        group.WeakTo.Add(weakTo.Remove(weakTo.Length - 1));
                        weakIndex++;
                        weakTo = words[weakIndex];
                    }
                    group.WeakTo.Add(weakTo.Remove(weakTo.Length - 1));
                }

                var damageIndex = words.IndexOf("damage");
                group.DamageType = words[damageIndex - 1];
                group.Damage = int.Parse(words[damageIndex - 2]) + (isImmune ? boost : 0);
                group.Initiative = int.Parse(words.Last());
                currentList.Add(group);
            }

            while (immuneSystem.Any() && infection.Any())
            {
                var allGroups = immuneSystem.Concat(infection).OrderByDescending(g => g.EffectivePower).ThenByDescending(g => g.Initiative).ToList();
                IList<Group> possibleTargets = allGroups.ToList();
                IList<(Group attacker, Group attackee)> attacks = new List<(Group, Group)>();
                foreach (var attackinGroup in allGroups)
                {
                    int maxDamage = 0;
                    Group target = null;
                    foreach (var possibleTarget in possibleTargets)
                    {
                        var potentialDamage = attackinGroup.PotentialDamage(possibleTarget);
                        if (potentialDamage == 0)
                        {
                            continue;
                        }
                        if (potentialDamage > maxDamage || potentialDamage == maxDamage && possibleTarget.AttackBefore(target))
                        {
                            maxDamage = potentialDamage;
                            target = possibleTarget;
                        }
                    }

                    if (target != null)
                    {
                        attacks.Add((attackinGroup, target));
                        possibleTargets.Remove(target);
                    }
                }

                foreach (var attack in attacks.OrderByDescending(a => a.attacker.Initiative))
                {
                    attack.attacker.Attack(attack.attackee);
                    if (attack.attackee.NumberOfUnits == 0)
                    {
                        if (attack.attackee.IsImmuneGroup)
                        {
                            immuneSystem.Remove(attack.attackee);
                        }
                        else
                        {
                            infection.Remove(attack.attackee);
                        }
                    }
                }
            }

            IList<Group> winningSystem = immuneSystem.Any() ? immuneSystem : infection;
            Result = winningSystem.Sum(g => g.NumberOfUnits).ToString();
            if (immuneSystem.Any())
            {
                Console.WriteLine(immuneSystem.Sum(g => g.NumberOfUnits));
            }
            return Task.CompletedTask;
        }

        private class Group
        {
            public int NumberOfUnits { get; set; }
            public int HitPointsPerUnit { get; set; }
            public IList<string> ImmuneTo { get; set; } = new List<string>();
            public IList<string> WeakTo { get; set; } = new List<string>();
            public int Initiative { get; set; }
            public int Damage { get; set; }
            public string DamageType { get; set; }
            public int EffectivePower => NumberOfUnits * Damage;
            public bool IsImmuneGroup { get; set; }

            public int PotentialDamage(Group target)
            {
                if (target.IsImmuneGroup == IsImmuneGroup || target.ImmuneTo.Contains(DamageType))
                {
                    return 0;
                }

                if (target.WeakTo.Contains(DamageType))
                {
                    return 2 * EffectivePower;
                }

                return EffectivePower;
            }

            public bool AttackBefore(Group other)
            {
                if (EffectivePower > other.EffectivePower)
                {
                    return true;
                }

                if (EffectivePower == other.EffectivePower)
                {
                    return Initiative > other.Initiative;
                }

                return false;
            }

            public void Attack(Group target)
            {
                var damage = PotentialDamage(target);
                var unitsKilled = damage / target.HitPointsPerUnit;
                target.NumberOfUnits = Math.Max(0, target.NumberOfUnits - unitsKilled);
            }
        }

        public override int Nummer => 201824;
    }
}
