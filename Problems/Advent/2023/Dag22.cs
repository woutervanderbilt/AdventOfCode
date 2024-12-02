using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag22 : Problem
{
    private const string testinput = @"1,0,1~1,2,1
0,0,2~2,0,2
0,2,3~2,2,3
0,0,4~0,2,4
2,0,5~2,2,5
0,1,6~2,1,6
1,1,8~1,1,9";

    public override async Task ExecuteAsync()
    {
        IList<Brick> bricks = new List<Brick>();

        foreach (var (line, index) in Input.Split(Environment.NewLine).Indexed())
        {
            var split = line.Split('~');
            var left = split[0].Split(',');
            var right = split[1].Split(',');
            var minX = int.Parse(left[0]);
            var minY = int.Parse(left[1]);
            var minZ = int.Parse(left[2]);
            var maxX = int.Parse(right[0]);
            var maxY = int.Parse(right[1]);
            var maxZ = int.Parse(right[2]);
            if (minX > maxX)
            {
                (minX, maxX) = (maxX, minX);
            }
            if (minY > maxY)
            {
                (minY, maxY) = (maxY, minY);
            }
            if (minZ > maxZ)
            {
                (minZ, maxZ) = (maxZ, minZ);
            }
            bricks.Add(new Brick(minX, minY, minZ, maxX, maxY, maxZ, index));
        }

        IDictionary<int, IList<Brick>> fixedBricksByLayer = new Dictionary<int, IList<Brick>>();
        IDictionary<int, IList<int>> supportedByDict = new Dictionary<int, IList<int>>();
        IDictionary<int, IList<int>> supportingDict = new Dictionary<int, IList<int>>();

        foreach (var brick in bricks.ToList().OrderBy(b => b.MinZ))
        {
            IList<int> supportedBy = new List<int>();
            IList<int> supporting = new List<int>();
            supportedByDict[brick.Index] = supportedBy;
            supportingDict[brick.Index] = supporting;
            var dz = brick.MaxZ - brick.MinZ;
            int z = brick.MinZ - 1;
            for (; z > 0; z--)
            {
                if (fixedBricksByLayer.TryGetValue(z, out var fixedBricksAtZ))
                {
                    foreach (var supportingBrick in fixedBricksAtZ)
                    {
                        if (brick.MaxX >= supportingBrick.MinX &&
                            brick.MinX <= supportingBrick.MaxX &&
                            brick.MaxY >= supportingBrick.MinY &&
                            brick.MinY <= supportingBrick.MaxY)
                        {
                            supportedBy.Add(supportingBrick.Index);
                            supportingDict[supportingBrick.Index].Add(brick.Index);
                        }
                    }
                }

                if (supportedBy.Any())
                {
                    break;
                }
            }

            var newBrick = brick with { MinZ = z + 1, MaxZ = z + dz + 1 };
            bricks[brick.Index] = newBrick;
            if (fixedBricksByLayer.TryGetValue(z + dz + 1, out var fixedList))
            {
                fixedList.Add(newBrick);
            }
            else
            {
                fixedBricksByLayer[z + dz + 1] = new List<Brick> { newBrick };
            }
        }

        HashSet<int> supportingBricks = new HashSet<int>(supportedByDict.Values.Where(s => s.Count == 1).Select(s => s[0]));

        long result2 = 0;
        foreach (var brick in bricks)
        {
            HashSet<int> falling = new HashSet<int> { brick.Index };
            HashSet<int> fallen = new HashSet<int> { brick.Index };
            while (falling.Any())
            {
                HashSet<int> newFalling = new HashSet<int>();
                foreach (var b in falling)
                {
                    foreach (var c in supportingDict[b])
                    {
                        if (supportedByDict[c].All(s => fallen.Contains(s)))
                        {
                            if (fallen.Add(c))
                            {
                                newFalling.Add(c);
                                result2++;
                            }
                        }
                    }
                }

                falling = newFalling;
            }

        }

        Result = ((bricks.Count - supportingBricks.Count), result2).ToString();
    }

    record Brick(int MinX, int MinY, int MinZ, int MaxX, int MaxY, int MaxZ, int Index);

    public override int Nummer => 202322;
}