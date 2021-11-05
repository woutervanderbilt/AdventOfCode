﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2019
{
    public class Dag3 : Problem
    {
        private const string input =
            @"R999,D467,L84,D619,L49,U380,R287,U80,R744,D642,L340,U738,R959,U710,R882,U861,L130,D354,L579,D586,R798,D735,L661,D453,L828,U953,R604,D834,R921,D348,R620,U775,R364,U552,L221,U119,R590,U29,L267,D745,L128,U468,L978,D717,R883,D227,R691,D330,L33,U520,L862,D132,R99,U400,L455,U737,L603,U220,L689,U131,R158,D674,R617,D287,R422,U734,L73,U327,L525,D245,R849,D692,R114,U136,R762,D5,R329,U429,L849,U748,R816,U556,R614,D412,R416,D306,R307,U826,R880,U936,L164,U984,L689,D934,R790,D14,R561,D736,L3,D442,R301,D520,L451,U76,R844,D307,L144,D800,L462,D138,R956,U225,L393,D186,L924,D445,L86,D640,L920,D877,L197,U191,L371,D701,R826,D282,R856,D412,L788,D417,R69,D678,R978,D268,L268,U112,L69,U164,L748,U191,R227,D227,R59,U749,R134,U779,R865,U247,R55,D567,R821,U799,R937,D942,L445,D571,R685,D111,R107,D769,R269,D968,R102,U335,R538,U125,L725,D654,R451,D242,R777,U813,R799,D786,L804,U313,L322,U771,R219,U316,L973,U963,R84,D289,R825,D299,L425,D49,R995,D486,R550,D789,R735,D501,R966,U955,R432,U635,L353,D600,R675,D236,R864,U322,R719,D418,L877,U833,R839,D634,L533,D438,L734,U130,L578,U498,L984,D413,L615,U40,L699,U656,L653,U419,R856,U882,R30,D266,R386,D692,L210,U802,L390,U753,L406,U338,R743,D320,L125,U204,R391,U537,R887,D194,L302,U400,R510,U92,L310,D382,R597,U498,R851,D357,L568,U800,R918,D106,R673,D735,L86,D67,R398,D677,R355,D501,L909,D133,R729,D293,L498,U222,R832,U671,R751,U36,R422,U840,L636,D476,L292,D105,L239,U199,R669,U736,L345,D911,L277,U452,L979,D153,R882,U604,R602,U495,L311,U453,L215,D713,R873
L996,U773,L865,D472,L988,D570,L388,U458,L87,U885,L115,U55,R75,U582,R695,U883,R83,U285,R96,D244,L647,D359,R136,U107,R912,U871,L844,U395,L63,U899,L205,D137,R549,U221,L859,D429,L809,U127,R304,U679,L511,U144,R926,U95,L805,U811,R42,D248,L546,D644,L551,D897,R368,D391,L224,U164,L490,D991,L146,D615,R536,U247,R10,U998,L957,D233,R706,D926,R760,U438,R270,D983,R134,U738,L262,U301,L480,D635,L702,D715,R479,U500,R19,D291,R368,U203,R305,D999,R106,U355,L683,D298,R90,U968,L254,D936,R89,U496,R253,U688,R99,U637,L783,D451,R673,D762,R997,D50,L488,U551,L871,U388,R949,D371,R584,D908,L880,U523,R557,U436,R520,U587,L56,U18,R397,U541,R660,D444,R51,U187,R221,U902,R726,U303,R97,D817,R185,D218,L240,D67,L259,U334,R821,U629,R21,D970,R282,U155,R555,D678,L99,D570,R863,D405,R941,U584,L303,D109,L871,U180,R595,D226,L670,D943,L127,U647,R452,D570,R75,D284,R414,U404,R515,U993,R408,U488,R890,D318,L415,U969,R769,D976,L732,U1,R489,U655,R930,U638,R649,D254,R161,U287,L659,D26,L477,D821,L124,U538,R17,D711,L203,U888,R904,U648,L908,D65,L215,U283,R698,U28,R72,U214,R499,D89,R489,D58,R949,D91,L710,U960,L755,D402,L27,D873,R61,U607,R57,D548,R369,U622,L244,U19,R61,D606,R928,D968,R10,D988,R816,U500,R915,D400,R546,D283,L627,D919,L259,U337,R374,U795,L355,D989,L224,D77,L872,U901,R476,U765,L320,U768,L937,D437,R141,D822,L326,D324,L498,U994,L518,D857,R973,D681,L710,D590,L879,U499,R488,D151,L242,U988,L944,U683,L24,U491,R823,D246,R872,D654,R28,U581,L142,U31,R435,D686,L147,D102,R952,D607,L959,D929,L46";

        public override Task ExecuteAsync()
        {
            var strings = input.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            IList<string> string1 = strings[0].Split(',');
            IList<string> string2 = strings[1].Split(',');
            var path1 = GetPath(string1);
            var path2 = GetPath(string2);
            int min = int.MaxValue;
            foreach (var crossing in path1.Keys.Intersect(path2.Keys))
            {
                if (crossing != (0, 0))
                {
                    var d = path1[crossing] + path2[crossing];
                    if (d < min)
                    {
                        min = d;
                    }
                }
            }

            Result = min.ToString();
            return Task.CompletedTask;
        }

        private static IDictionary<(int, int), int> GetPath(IList<string> string1)
        {
            var path = new Dictionary<(int, int), int>();
            (int X, int Y) current = (0, 0);
            int numberOfSteps = 0;
            foreach (var step in string1)
            {
                int dx = 0;
                int dy = 0;
                switch (step[0])
                {
                    case 'U':
                        dx = 1;
                        break;
                    case 'R':
                        dy = 1;
                        break;
                    case 'D':
                        dx = -1;
                        break;
                    case 'L':
                        dy = -1;
                        break;
                }

                int length = int.Parse(step.Substring(1));
                for (int i = 1; i <= length; i++)
                {
                    numberOfSteps++;
                    current.X += dx;
                    current.Y += dy;
                    if (!path.ContainsKey(current))
                    {
                        path[current] = numberOfSteps;
                    }
                }
            }

            return path;
        }

        public override int Nummer => 201903;
    }
}
