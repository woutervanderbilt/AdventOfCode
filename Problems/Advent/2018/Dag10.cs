﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2018;

public class Dag10 : Problem
{
    private const string input = @"position=<-54217, -21587> velocity=< 5,  2>
position=<-54233, -10693> velocity=< 5,  1>
position=<-54217, -43356> velocity=< 5,  4>
position=<-32441, -43354> velocity=< 3,  4>
position=<-43345, -10690> velocity=< 4,  1>
position=< 21983,  54631> velocity=<-2, -5>
position=<-21566,  32857> velocity=< 2, -3>
position=< 43767, -54245> velocity=<-4,  5>
position=<-32473,  54631> velocity=< 3, -5>
position=< 11071, -21580> velocity=<-1,  2>
position=< 32903, -54247> velocity=<-3,  5>
position=<-43361,  54632> velocity=< 4, -5>
position=< 32857, -32472> velocity=<-3,  3>
position=< 32900,  21968> velocity=<-3, -2>
position=<-10688, -43354> velocity=< 1,  4>
position=<-43317,  11082> velocity=< 4, -1>
position=< 11079, -32469> velocity=<-1,  3>
position=< 11121,  21965> velocity=<-1, -2>
position=<-10669, -54246> velocity=< 1,  5>
position=< 43759,  32860> velocity=<-4, -3>
position=<-32441,  54630> velocity=< 3, -5>
position=< 21972, -21578> velocity=<-2,  2>
position=< 32847, -43355> velocity=<-3,  4>
position=< 11111, -21586> velocity=<-1,  2>
position=<-21585,  32859> velocity=< 2, -3>
position=< 32871,  54637> velocity=<-3, -5>
position=<-10671, -10699> velocity=< 1,  1>
position=<-10676, -43363> velocity=< 1,  4>
position=<-43333, -43358> velocity=< 4,  4>
position=< 21983, -54244> velocity=<-2,  5>
position=<-54217,  11081> velocity=< 5, -1>
position=<-43332, -21581> velocity=< 4,  2>
position=<-21581, -54250> velocity=< 2,  5>
position=<-43313,  21969> velocity=< 4, -2>
position=< 54643,  21965> velocity=<-5, -2>
position=<-32452,  11077> velocity=< 3, -1>
position=<-43343,  43741> velocity=< 4, -4>
position=< 32871, -54243> velocity=<-3,  5>
position=<-54204,  43750> velocity=< 5, -4>
position=< 54631,  32861> velocity=<-5, -3>
position=< 11103,  11079> velocity=<-1, -1>
position=< 54643, -32474> velocity=<-5,  3>
position=< 43767,  11084> velocity=<-4, -1>
position=< 32850,  11081> velocity=<-3, -1>
position=< 32855,  32861> velocity=<-3, -3>
position=< 54663, -43357> velocity=<-5,  4>
position=<-54252, -10690> velocity=< 5,  1>
position=< 11076,  21973> velocity=<-1, -2>
position=<-32447, -43363> velocity=< 3,  4>
position=<-21534, -32471> velocity=< 2,  3>
position=<-32461, -54245> velocity=< 3,  5>
position=< 54681,  43745> velocity=<-5, -4>
position=<-10694, -10697> velocity=< 1,  1>
position=< 32847, -32475> velocity=<-3,  3>
position=< 43776, -21583> velocity=<-4,  2>
position=<-43313, -43359> velocity=< 4,  4>
position=< 32865, -32466> velocity=<-3,  3>
position=<-54214,  11079> velocity=< 5, -1>
position=<-54239, -54242> velocity=< 5,  5>
position=<-10686,  21974> velocity=< 1, -2>
position=<-21593, -21578> velocity=< 2,  2>
position=<-43309, -10699> velocity=< 4,  1>
position=<-21561, -43354> velocity=< 2,  4>
position=<-10686, -21587> velocity=< 1,  2>
position=<-43364, -54243> velocity=< 4,  5>
position=<-43332, -10693> velocity=< 4,  1>
position=<-54204, -32469> velocity=< 5,  3>
position=<-54249, -43360> velocity=< 5,  4>
position=< 11076,  32853> velocity=<-1, -3>
position=< 21961,  11081> velocity=<-2, -1>
position=< 21996, -10695> velocity=<-2,  1>
position=<-21593,  32854> velocity=< 2, -3>
position=< 54668, -10690> velocity=<-5,  1>
position=< 32895,  43747> velocity=<-3, -4>
position=< 32875, -21583> velocity=<-3,  2>
position=< 11082, -10697> velocity=<-1,  1>
position=<-21589,  32857> velocity=< 2, -3>
position=< 11129,  54629> velocity=<-1, -5>
position=<-54209,  21967> velocity=< 5, -2>
position=< 32891,  21966> velocity=<-3, -2>
position=< 54655,  54631> velocity=<-5, -5>
position=< 11095,  32858> velocity=<-1, -3>
position=<-54233, -54244> velocity=< 5,  5>
position=< 54672,  54634> velocity=<-5, -5>
position=<-32481, -54247> velocity=< 3,  5>
position=< 11071, -21586> velocity=<-1,  2>
position=< 54643,  32861> velocity=<-5, -3>
position=< 43735, -54245> velocity=<-4,  5>
position=< 54647,  43744> velocity=<-5, -4>
position=<-32428,  32862> velocity=< 3, -3>
position=<-21561,  32862> velocity=< 2, -3>
position=< 22007, -54248> velocity=<-2,  5>
position=< 43783, -21580> velocity=<-4,  2>
position=< 43745, -43357> velocity=<-4,  4>
position=< 32847, -10693> velocity=<-3,  1>
position=< 11124,  11084> velocity=<-1, -1>
position=<-10700, -54245> velocity=< 1,  5>
position=<-21556,  54636> velocity=< 2, -5>
position=<-10700,  21966> velocity=< 1, -2>
position=< 22015, -43358> velocity=<-2,  4>
position=< 22015, -32475> velocity=<-2,  3>
position=< 21984,  54633> velocity=<-2, -5>
position=<-21545, -32471> velocity=< 2,  3>
position=< 21992,  54634> velocity=<-2, -5>
position=< 43762, -10699> velocity=<-4,  1>
position=<-32431, -43358> velocity=< 3,  4>
position=<-10656,  11078> velocity=< 1, -1>
position=<-32455,  11081> velocity=< 3, -1>
position=<-32455, -54247> velocity=< 3,  5>
position=< 43783,  43743> velocity=<-4, -4>
position=<-32428,  43743> velocity=< 3, -4>
position=< 11108, -10690> velocity=<-1,  1>
position=<-32428, -43357> velocity=< 3,  4>
position=<-54237, -21587> velocity=< 5,  2>
position=<-43360,  43745> velocity=< 4, -4>
position=< 21964,  32860> velocity=<-2, -3>
position=< 54641,  54638> velocity=<-5, -5>
position=< 11127, -32469> velocity=<-1,  3>
position=<-54200,  21969> velocity=< 5, -2>
position=<-43332, -43360> velocity=< 4,  4>
position=<-32452,  43741> velocity=< 3, -4>
position=< 32879,  21967> velocity=<-3, -2>
position=< 54663,  21966> velocity=<-5, -2>
position=<-21561,  21968> velocity=< 2, -2>
position=< 21972,  54629> velocity=<-2, -5>
position=< 32867,  21966> velocity=<-3, -2>
position=<-21573, -10696> velocity=< 2,  1>
position=<-43321, -54246> velocity=< 4,  5>
position=<-10705, -43358> velocity=< 1,  4>
position=<-10661, -54250> velocity=< 1,  5>
position=<-54205, -54246> velocity=< 5,  5>
position=< 21961, -32471> velocity=<-2,  3>
position=< 54651,  43745> velocity=<-5, -4>
position=<-21548,  54629> velocity=< 2, -5>
position=< 11111,  32855> velocity=<-1, -3>
position=<-54256, -10695> velocity=< 5,  1>
position=< 43791,  32861> velocity=<-4, -3>
position=< 11083,  43742> velocity=<-1, -4>
position=< 32895, -32469> velocity=<-3,  3>
position=<-21560,  43742> velocity=< 2, -4>
position=<-10670,  21970> velocity=< 1, -2>
position=< 54643,  32858> velocity=<-5, -3>
position=< 21967, -21578> velocity=<-2,  2>
position=< 43755,  54633> velocity=<-4, -5>
position=<-10693, -21579> velocity=< 1,  2>
position=<-43350,  54629> velocity=< 4, -5>
position=< 11124, -21580> velocity=<-1,  2>
position=<-43324,  11077> velocity=< 4, -1>
position=< 21979, -54246> velocity=<-2,  5>
position=<-43332,  21969> velocity=< 4, -2>
position=< 21991, -21580> velocity=<-2,  2>
position=<-54238, -43363> velocity=< 5,  4>
position=<-21569,  21970> velocity=< 2, -2>
position=< 43795,  21969> velocity=<-4, -2>
position=< 54647, -21585> velocity=<-5,  2>
position=< 43762, -43363> velocity=<-4,  4>
position=< 43743, -21587> velocity=<-4,  2>
position=< 11076, -21580> velocity=<-1,  2>
position=<-32461, -43355> velocity=< 3,  4>
position=< 54648,  11081> velocity=<-5, -1>
position=< 32904, -10699> velocity=<-3,  1>
position=< 54647, -43362> velocity=<-5,  4>
position=< 21993,  11077> velocity=<-2, -1>
position=<-10652, -54248> velocity=< 1,  5>
position=< 22007,  21970> velocity=<-2, -2>
position=<-54216,  21970> velocity=< 5, -2>
position=<-32425, -10692> velocity=< 3,  1>
position=< 54623, -43360> velocity=<-5,  4>
position=<-21573, -32469> velocity=< 2,  3>
position=<-43327,  11083> velocity=< 4, -1>
position=< 43775,  32862> velocity=<-4, -3>
position=<-21584,  54634> velocity=< 2, -5>
position=< 43740, -54251> velocity=<-4,  5>
position=<-21553,  21968> velocity=< 2, -2>
position=<-32461, -54244> velocity=< 3,  5>
position=<-10697, -21582> velocity=< 1,  2>
position=< 54625, -54247> velocity=<-5,  5>
position=<-43316, -32467> velocity=< 4,  3>
position=< 54663, -43354> velocity=<-5,  4>
position=< 32884, -54242> velocity=<-3,  5>
position=<-54220, -10697> velocity=< 5,  1>
position=< 11128,  43745> velocity=<-1, -4>
position=< 54647,  43742> velocity=<-5, -4>
position=< 54647,  43744> velocity=<-5, -4>
position=< 43740,  54632> velocity=<-4, -5>
position=< 43783,  54637> velocity=<-4, -5>
position=< 11075,  54633> velocity=<-1, -5>
position=< 43791,  54631> velocity=<-4, -5>
position=< 11074,  11081> velocity=<-1, -1>
position=< 54679, -10699> velocity=<-5,  1>
position=< 54651,  21965> velocity=<-5, -2>
position=< 43735, -43361> velocity=<-4,  4>
position=< 43785, -43358> velocity=<-4,  4>
position=<-32456, -32471> velocity=< 3,  3>
position=<-32441,  32861> velocity=< 3, -3>
position=< 54655, -10694> velocity=<-5,  1>
position=< 22010, -10699> velocity=<-2,  1>
position=< 11124, -43361> velocity=<-1,  4>
position=<-32461, -54250> velocity=< 3,  5>
position=<-54204, -43359> velocity=< 5,  4>
position=< 43778, -10692> velocity=<-4,  1>
position=<-43328, -21583> velocity=< 4,  2>
position=< 43755,  54632> velocity=<-4, -5>
position=<-10646, -43363> velocity=< 1,  4>
position=< 21979,  11080> velocity=<-2, -1>
position=< 43786,  43746> velocity=<-4, -4>
position=<-32425,  43744> velocity=< 3, -4>
position=<-10652, -43358> velocity=< 1,  4>
position=<-21537,  54632> velocity=< 2, -5>
position=< 11071,  21965> velocity=<-1, -2>
position=< 11115,  32854> velocity=<-1, -3>
position=< 11116,  11077> velocity=<-1, -1>
position=<-32441,  54637> velocity=< 3, -5>
position=< 43746, -10692> velocity=<-4,  1>
position=< 21964, -32470> velocity=<-2,  3>
position=<-32473, -43356> velocity=< 3,  4>
position=<-10697, -54246> velocity=< 1,  5>
position=<-21569,  54637> velocity=< 2, -5>
position=< 54656, -10698> velocity=<-5,  1>
position=<-54217,  54632> velocity=< 5, -5>
position=<-32439,  21971> velocity=< 3, -2>
position=< 11107,  32854> velocity=<-1, -3>
position=<-54215, -10696> velocity=< 5,  1>
position=<-10646,  32857> velocity=< 1, -3>
position=<-32444,  32862> velocity=< 3, -3>
position=<-21593,  11084> velocity=< 2, -1>
position=< 32882, -32475> velocity=<-3,  3>
position=<-54248, -43358> velocity=< 5,  4>
position=< 32851,  11081> velocity=<-3, -1>
position=<-10700,  43743> velocity=< 1, -4>
position=<-21565,  32853> velocity=< 2, -3>
position=<-32447, -21582> velocity=< 3,  2>
position=<-43349,  54636> velocity=< 4, -5>
position=< 54676, -54249> velocity=<-5,  5>
position=< 32897, -10699> velocity=<-3,  1>
position=<-43316, -54247> velocity=< 4,  5>
position=<-21593, -32471> velocity=< 2,  3>
position=< 43740, -10695> velocity=<-4,  1>
position=<-43312,  43745> velocity=< 4, -4>
position=< 21999, -43356> velocity=<-2,  4>
position=<-54220,  32860> velocity=< 5, -3>
position=< 22015, -32469> velocity=<-2,  3>
position=< 21980,  43741> velocity=<-2, -4>
position=< 32884,  11080> velocity=<-3, -1>
position=< 43760, -21587> velocity=<-4,  2>
position=<-43349,  32858> velocity=< 4, -3>
position=< 21991, -21579> velocity=<-2,  2>
position=<-43353, -43355> velocity=< 4,  4>
position=<-32421, -21583> velocity=< 3,  2>
position=< 43788, -21578> velocity=<-4,  2>
position=<-54233, -21587> velocity=< 5,  2>
position=< 43788, -43355> velocity=<-4,  4>
position=<-54225,  54636> velocity=< 5, -5>
position=<-54225, -32471> velocity=< 5,  3>
position=< 54631, -32473> velocity=<-5,  3>
position=< 11111,  21970> velocity=<-1, -2>
position=<-21550, -21580> velocity=< 2,  2>
position=<-32456,  32853> velocity=< 3, -3>
position=<-43327, -43360> velocity=< 4,  4>
position=<-10685, -10691> velocity=< 1,  1>
position=< 43759,  32856> velocity=<-4, -3>
position=< 32887,  21969> velocity=<-3, -2>
position=< 43743, -32473> velocity=<-4,  3>
position=< 32847,  54635> velocity=<-3, -5>
position=<-54198, -32475> velocity=< 5,  3>
position=<-21545, -43359> velocity=< 2,  4>
position=< 22007, -32471> velocity=<-2,  3>
position=<-21537, -43363> velocity=< 2,  4>
position=< 21994, -21587> velocity=<-2,  2>
position=< 54623, -54250> velocity=<-5,  5>
position=< 21983, -21583> velocity=<-2,  2>
position=<-21556, -10692> velocity=< 2,  1>
position=< 54628,  11080> velocity=<-5, -1>
position=< 11127, -54242> velocity=<-1,  5>
position=< 11079, -54250> velocity=<-1,  5>
position=< 43767, -43354> velocity=<-4,  4>
position=< 32884,  21969> velocity=<-3, -2>
position=< 54631,  21966> velocity=<-5, -2>
position=< 11132, -32475> velocity=<-1,  3>
position=<-10645,  21965> velocity=< 1, -2>
position=<-10697,  54629> velocity=< 1, -5>
position=< 11115,  43749> velocity=<-1, -4>
position=< 54676,  32857> velocity=<-5, -3>
position=<-21533, -10695> velocity=< 2,  1>
position=<-32455, -10699> velocity=< 3,  1>
position=<-10649, -32474> velocity=< 1,  3>
position=<-21569, -21581> velocity=< 2,  2>
position=< 32863, -54244> velocity=<-3,  5>
position=<-32425, -43362> velocity=< 3,  4>
position=<-10652,  54632> velocity=< 1, -5>
position=< 43792,  11077> velocity=<-4, -1>
position=< 21996,  21973> velocity=<-2, -2>
position=<-21556, -10696> velocity=< 2,  1>
position=<-10700, -54242> velocity=< 1,  5>
position=< 54672, -43358> velocity=<-5,  4>
position=<-10660,  54638> velocity=< 1, -5>
position=<-21560,  54634> velocity=< 2, -5>
position=<-10697, -10695> velocity=< 1,  1>
position=< 11079,  32854> velocity=<-1, -3>
position=<-54220, -10694> velocity=< 5,  1>
position=<-54252, -10694> velocity=< 5,  1>
position=< 43759,  54631> velocity=<-4, -5>
position=<-54249,  11083> velocity=< 5, -1>
position=< 21979,  11079> velocity=<-2, -1>
position=< 21983,  54629> velocity=<-2, -5>
position=<-54257,  43750> velocity=< 5, -4>
position=< 32852,  11084> velocity=<-3, -1>
position=< 32852,  32853> velocity=<-3, -3>
position=<-21585, -43358> velocity=< 2,  4>
position=<-54244, -32475> velocity=< 5,  3>
position=< 21983,  21974> velocity=<-2, -2>
position=< 32871, -54242> velocity=<-3,  5>
position=< 21991, -43357> velocity=<-2,  4>
position=<-54248,  54634> velocity=< 5, -5>
position=< 32882, -21587> velocity=<-3,  2>
position=< 43796, -10699> velocity=<-4,  1>
position=< 11114, -21580> velocity=<-1,  2>
position=<-10688, -21578> velocity=< 1,  2>
position=<-10700,  11082> velocity=< 1, -1>
position=<-43327,  11080> velocity=< 4, -1>
position=< 54660, -43357> velocity=<-5,  4>
position=< 11099,  21969> velocity=<-1, -2>
position=<-43353, -54244> velocity=< 4,  5>
position=<-10653,  43742> velocity=< 1, -4>
position=< 21994, -10694> velocity=<-2,  1>
position=< 43740, -10691> velocity=<-4,  1>
position=< 32871, -10695> velocity=<-3,  1>
position=< 32900,  54635> velocity=<-3, -5>
position=<-21545, -21578> velocity=< 2,  2>
position=< 43767,  11081> velocity=<-4, -1>
position=<-54244, -32475> velocity=< 5,  3>
position=<-32454, -21587> velocity=< 3,  2>
position=<-32422, -21587> velocity=< 3,  2>
position=<-43361, -32468> velocity=< 4,  3>";
    public override Task ExecuteAsync()
    {
        var stars = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
            .Select(s => new Star(int.Parse(s.Substring(10, 6)),
                int.Parse(s.Substring(18, 6)), int.Parse(s.Substring(36, 2)), int.Parse(s.Substring(40, 2)))).ToList();

        int count = 0;
        int previousDy = 100;
        while (true)
        {
            count++;
            Step(stars);
            var minY = stars.Min(s => s.Y);

            var dy = stars.Max(s => s.Y) - minY;
            if (dy < 40)
            {
                if (dy > previousDy)
                {
                    break;
                }
                previousDy = dy;
                var minX = stars.Min(s => s.X);
                var dx = stars.Max(s => s.X) - minX;
                StringBuilder sb = new StringBuilder();
                for (int y = 0; y <= dy; y++)
                {
                    sb.Append(Environment.NewLine);
                    for (int x = 0; x <= dx; x++)
                    {
                        if (stars.Any(s => s.X - minX == x && s.Y - minY == y))
                        {
                            sb.Append("X");
                        }
                        else
                        {
                            sb.Append(" ");
                        }
                    }
                }
                Result = sb.AppendLine(count.ToString()).ToString();
            }
        }
        return Task.CompletedTask;
    }

    private void Step(IList<Star> stars)
    {
        foreach (var star in stars)
        {
            star.X += star.Vx;
            star.Y += star.Vy;
        }
    }

    public override int Nummer => 201810;

    private class Star
    {
        public Star(int x, int y, int vx, int vy)
        {
            X = x;
            Y = y;
            Vx = vx;
            Vy = vy;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Vx { get; set; }
        public int Vy { get; set; }
    }
}