using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2019;

public class Dag12 : Problem
{
    public override Task ExecuteAsync()
    {
        IList<Moon> moons = new List<Moon>();
        moons.Add(new Moon { X = -16, Y = -1, Z = -12 });
        moons.Add(new Moon { X = 0, Y = -4, Z = -17 });
        moons.Add(new Moon { X = -11, Y = 11, Z = 0 });
        moons.Add(new Moon { X = 2, Y = 2, Z = -6 });

        (long, long, long, long, long, long, long, long) xValues = (-16, 0, 0, 0, -11, 0, 2, 0);
        (long, long, long, long, long, long, long, long) yValues = (-1, 0, -4, 0, 11, 0, 2, 0);
        (long, long, long, long, long, long, long, long) zValues = (-12, 0, -17, 0, 0, 0, -6, 0);

        var constellation = new Constellation { Moons = moons };

        bool xFound = false;
        bool yFound = false;
        bool zFound = false;
        long xIndex = 0;
        long yIndex = 0;
        long zIndex = 0;

        for (int step = 0; step < 1000000000; step++)
        {
            constellation.Step();
            if (!xFound && xValues == constellation.Xvalues)
            {
                xFound = true;
                xIndex = step;
            }
            if (!yFound && yValues == constellation.Yvalues)
            {
                yFound = true;
                yIndex = step;
            }
            if (!zFound && zValues == constellation.Zvalues)
            {
                zFound = true;
                zIndex = step;
            }

            if (xFound && yFound && zFound)
            {
                Result = EulerMath.LCM(xIndex, EulerMath.LCM(yIndex, zIndex)).ToString();
                return Task.CompletedTask;
            }
        }

        Result = constellation.TotalEnergy.ToString();
        return Task.CompletedTask;
    }

    private class Constellation
    {
        public IList<Moon> Moons { get; set; }

        public void Step()
        {
            foreach (var moon1 in Moons)
            {
                foreach (var moon2 in Moons)
                {
                    if (moon1 != moon2)
                    {
                        moon1.ChangeVelocity(moon2);
                    }
                }
            }

            foreach (var moon in Moons)
            {
                moon.ChangePosition();
            }
        }

        public long TotalEnergy => Moons.Sum(m => m.TotalEnergy());

        public (long, long, long, long, long, long, long, long) Xvalues => (Moons[0].X, Moons[0].Vx, Moons[1].X,
            Moons[1].Vx, Moons[2].X, Moons[2].Vx, Moons[3].X, Moons[3].Vx);
        public (long, long, long, long, long, long, long, long) Yvalues => (Moons[0].Y, Moons[0].Vy, Moons[1].Y,
            Moons[1].Vy, Moons[2].Y, Moons[2].Vy, Moons[3].Y, Moons[3].Vy);
        public (long, long, long, long, long, long, long, long) Zvalues => (Moons[0].Z, Moons[0].Vz, Moons[1].Z,
            Moons[1].Vz, Moons[2].Z, Moons[2].Vz, Moons[3].Z, Moons[3].Vz);
    }

    private class Moon
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }
        public long Vx { get; set; }
        public long Vy { get; set; }
        public long Vz { get; set; }

        public long TotalEnergy()
        {
            return (Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z)) * (Math.Abs(Vx) + Math.Abs(Vy) + Math.Abs(Vz));
        }

        public void ChangePosition()
        {
            X += Vx;
            Y += Vy;
            Z += Vz;
        }

        public void ChangeVelocity(Moon other)
        {
            if (other.X > X)
            {
                Vx++;
            }

            if (other.X < X)
            {
                Vx--;
            }
            if (other.Y > Y)
            {
                Vy++;
            }

            if (other.Y < Y)
            {
                Vy--;
            }
            if (other.Z > Z)
            {
                Vz++;
            }

            if (other.Z < Z)
            {
                Vz--;
            }
        }

        public override string ToString()
        {
            return $"{X} {Y} {Z}   {Vx} {Vy} {Vz}";
        }
    }

    public override int Nummer => 201912;
}