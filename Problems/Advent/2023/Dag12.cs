using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag12 : Problem
{
    private const string testinput = @"???.### 1,1,3
.??..??...?##. 1,1,3
?#?#?#?#?#?#?#? 1,3,1,6
????.#...#... 4,1,1
????.######..#####. 1,6,5
?###???????? 3,2,1";


    public override async Task ExecuteAsync()
    {
        string input = await GetInputAsync();
        IList<SpringSet> springSets = new List<SpringSet>();
        foreach (var line in input.Split(Environment.NewLine))
        {
            var split = line.Split(' ');
            springSets.Add(new SpringSet
            {
                Layout = split[0],
                Springs = split[1].Split(',').Select(int.Parse).ToList()
            });
        }

        long result = springSets.Sum(s => s.Solve());
        long result2 = springSets.Sum(s => s.TimesFive().Solve());

        Result = (result, result2).ToString();
        SpringSet.cache.Clear();
    }

    private class SpringSet
    {
        public static IDictionary<SpringSet, long> cache = new Dictionary<SpringSet, long>();
  
        public string Layout { get; set; }
        public IList<int> Springs { get; set; }

        public SpringSet TimesFive()
        {
            Layout = $"{Layout}?{Layout}?{Layout}?{Layout}?{Layout}";
            Springs = Springs.Concat(Springs).Concat(Springs).Concat(Springs).Concat(Springs).ToList();
            return this;
        }

        public long Solve()
        {
            if (cache.TryGetValue(this, out var r))
            {
                return r;
            }

            if (Springs.Count == 0)
            {
                var result = Layout.Any(c => c == '#') ? 0 : 1;
                cache[this] = result;
                return result;
            }

            long res = 0;
            if (Springs.Count == 1)
            {
                var spring = Springs[0];
                for (int i = 0; i + spring <= Layout.Length; i++)
                {
                    if (Layout.Substring(i, spring).All(c => c != '.') && Layout.Substring(i + spring).All(c => c != '#') && Layout.Substring(0, i).All(c => c != '#'))
                    {
                        res++;
                    }
                }
                cache[this] = res;
                return res;
            }
            var middle = Springs.Count / 2;
            var middleSpring = Springs[middle];
            var leftSprings = Springs.Take(middle).ToList();
            var rightSprings = Springs.Skip(middle + 1).ToList();
            var leftSum = leftSprings.Sum() + leftSprings.Count;
            var rightSum = rightSprings.Sum() + rightSprings.Count;
            for (int index = leftSum; index + middleSpring + rightSum <= Layout.Length; index++)
            {
                if (Layout.Substring(index, middleSpring).All(c => c != '.'))
                {
                    if (index > 1 && Layout[index - 1] == '#' || index + middleSpring < Layout.Length && Layout[index + middleSpring] == '#')
                    {
                        continue;
                    }
                    var leftLayout = Layout.Substring(0, Math.Max(0,index - 1));
                    var rightLayout = index + middleSpring >= Layout.Length ? String.Empty : Layout.Substring(index + middleSpring + 1);

                    if (leftLayout.Length < rightLayout.Length)
                    {
                        var left = new SpringSet
                        {
                            Layout = leftLayout,
                            Springs = leftSprings
                        }.Solve();
                        if (left != 0)
                        {
                            res += left * new SpringSet
                            {
                                Layout = rightLayout,
                                Springs = rightSprings
                            }.Solve();
                        }
                    }
                    else
                    {
                        var right = new SpringSet
                        {
                            Layout = rightLayout,
                            Springs = rightSprings
                        }.Solve();
                        if (right != 0)
                        {
                            res += right * new SpringSet
                            {
                                Layout = leftLayout,
                                Springs = leftSprings
                            }.Solve();
                        }
                    }
                }
            }
            cache[this] = res;
            return res;
        }

        public override bool Equals(object obj)
        {
            return Equals((SpringSet)obj);
        }

        protected bool Equals(SpringSet other)
        {
            return Layout == other.Layout && Springs.SequenceEqual(other.Springs);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(Layout);
            foreach (var spring in Springs)
            {
                hash.Add(spring);
            }

            return hash.ToHashCode();
        }
    }

    public override int Nummer => 202312;
}