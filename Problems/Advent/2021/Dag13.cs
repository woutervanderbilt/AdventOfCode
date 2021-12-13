﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Models;

namespace Problems.Advent._2021
{
    internal class Dag13 : Problem
    {
        const string input = @"241,142
57,889
1131,239
1076,828
495,612
656,775
977,665
65,627
1004,401
1245,627
567,750
1197,194
654,822
214,644
25,738
256,784
1044,485
957,102
291,673
271,715
400,182
415,245
1083,777
995,486
932,695
951,590
376,184
1200,879
234,156
276,807
1019,221
1110,171
764,54
594,317
706,711
348,485
567,751
835,360
239,425
169,634
1205,131
628,159
363,682
664,124
1096,26
1126,849
309,217
341,509
612,365
787,878
1096,560
378,599
956,112
1222,178
947,682
514,750
542,876
706,560
514,144
721,175
355,511
736,513
1260,560
20,746
28,211
721,681
604,199
589,715
140,555
967,550
877,565
1004,605
157,649
797,514
157,612
376,262
726,336
239,701
1126,798
1197,700
1290,596
390,607
226,791
254,182
1059,565
195,464
95,462
1064,494
656,248
1201,159
1191,843
157,359
105,439
1125,346
470,350
840,361
475,655
1159,486
982,241
515,301
415,469
557,175
179,534
850,632
1310,653
25,828
469,794
768,196
179,140
776,528
1265,348
1049,136
82,494
1103,639
57,5
706,199
1131,140
1010,782
956,782
1069,752
1135,178
760,109
30,400
214,71
221,539
915,880
105,91
751,432
1131,886
803,803
194,794
668,386
475,136
738,809
485,604
900,520
1305,306
1258,186
490,184
276,711
1140,198
1155,556
393,345
349,156
74,682
716,409
835,463
537,585
343,550
642,386
264,607
445,809
353,102
147,136
654,72
1159,408
716,317
1153,535
1153,649
1246,523
1201,761
77,599
214,876
85,711
882,551
594,577
17,117
808,464
102,485
181,117
930,193
485,148
522,411
88,548
82,641
415,873
430,261
850,140
841,346
661,761
1066,465
80,381
612,529
604,830
922,633
557,271
982,38
105,117
773,757
1064,752
1228,641
176,50
682,159
947,660
278,126
1071,425
1282,379
1083,565
75,730
830,883
1215,350
989,540
50,707
30,259
888,11
1201,180
632,773
897,752
1096,868
1039,715
841,548
604,560
1228,361
604,407
542,606
781,614
716,45
321,164
1305,588
378,466
1262,38
523,430
1015,142
1250,577
321,87
455,451
301,794
1201,831
87,751
1078,459
227,777
818,870
708,260
1207,44
967,136
1071,693
1230,694
554,287
937,285
1275,862
1096,879
868,40
728,264
1255,120
1258,193
898,31
485,232
493,432
8,882
244,353
50,560
649,596
914,211
1009,550
162,248
765,266
1029,197
999,662
1116,262
922,200
1258,813
549,551
132,754
1004,289
1228,494
1148,248
266,409
507,310
87,591
1148,465
1282,211
676,298
1213,773
1076,724
192,95
586,871
813,130
422,883
1203,395
994,435
835,136
835,239
408,513
321,535
1026,814
278,38
721,715
684,543
1210,103
1062,129
795,301
80,246
547,296
266,697
109,133
1260,793
433,565
1288,121
31,128
422,11
343,214
537,137
113,418
663,786
584,269
428,551
821,880
475,491
773,533
1236,660
396,211
589,213
848,543
900,429
818,24
109,581
105,791
880,261
1096,242
602,81
151,520
363,221
7,338
840,466
507,214
316,710
1101,796
639,662
565,502
934,574
803,584
922,493
261,758
1091,395
766,879
1245,267
1124,681
654,418
1245,696
266,493
1207,626
646,124
1076,211
1277,712
1054,784
5,456
594,409
103,268
929,210
1211,329
731,255
181,777
647,556
572,494
962,401
788,698
1052,423
363,212
633,380
801,565
856,378
1208,25
1245,715
348,849
760,561
731,117
502,235
266,485
691,227
523,878
1310,241
877,833
363,225
221,61
903,73
656,822
1019,212
1011,623
55,774
1283,271
962,267
687,80
408,142
1223,751
691,480
716,401
1289,828
1206,675
1131,360
967,214
566,794
214,375
162,86
1148,86
301,290
681,290
396,683
268,101
455,443
1284,560
1236,234
199,443
490,486
869,700
684,473
768,197
1021,726
311,680
803,399
856,516
467,334
1066,30
92,514
184,849
572,137
574,513
1235,117
870,252
769,194
661,92
97,719
525,294
328,241
95,350
470,361
1230,246
972,177
1205,803
373,285
142,25
475,534
502,883
1011,63
594,401
594,849
1253,889
1096,625
162,808
708,708
807,374
1071,21
621,854
432,449
761,509
1268,529
619,862
185,346
989,140
333,730
1287,789
167,730
430,633
378,295
315,486
1143,612
266,633
619,480
237,54
1034,183
768,249
321,428
284,814
53,12
492,248
773,85
803,455
989,428
1260,606
266,381
447,502
890,66
807,626
826,646
721,719
1298,386
1260,334
639,232
984,241
761,131
75,164
1036,641
1216,883
333,665
888,256
388,872
549,385
1146,520
522,262
408,400
843,334
194,100
151,486
151,626
65,719
972,688
407,73
475,808
353,100
788,632
917,345
740,98
1071,193
1153,282
420,549
1044,513
129,600
604,549
545,628
258,311
251,565
590,523
584,558
1116,885
75,117
924,793
985,350
336,98
412,31
803,758
929,628
972,733
604,194
415,425
1277,40
1101,85
545,266
1215,462
798,86
661,298
1049,399
1235,526
855,451
604,269
840,533
1129,117
412,191
945,278
246,374
1293,117
698,365
378,428
623,80
276,421
411,381
1248,567
489,14
50,101
351,105
661,596
634,596
1078,11
187,782
52,365
1103,502
21,290
261,399
70,522
768,700
547,395
1168,18
1170,144
1131,207
1034,635
224,633
1198,697
1123,334
74,234
1034,259
132,632
460,754
179,8
142,186
157,805
169,164
26,560
363,669
1257,882
234,828
1084,607
219,403
788,483
475,86
738,757
551,268
999,214
720,371
731,777
184,798
1305,802
1056,264
1062,765
1287,341
300,782
589,457
194,306
351,119
879,44
1158,435
333,754
686,35
807,38
1201,628
604,569
179,136
513,514
264,119
207,502
918,75
386,793
103,626
281,53
416,614
557,623
678,121
898,191
562,784
291,3
23,229
112,698
83,513
1091,499
604,625
929,511
917,121
306,858
567,303
60,409
284,80
1038,168
1290,298
417,840
475,239
365,278
10,357
460,710
1273,278
914,722
276,635
107,395
326,38
232,11
274,813
52,36
761,551
105,803
97,47
837,777
1134,760
142,96
738,400
922,175
1032,768
646,434
877,329
179,758
378,487
1034,421
162,429
60,241
460,306
1246,371
689,854
349,548
289,616
175,178
1233,599
1257,133
574,648
1159,520
1086,633
914,683
691,526
706,700
239,245
1287,229
175,716
276,183
820,856
837,117
1103,703
1170,555
1260,288
1034,199
1260,707
410,80
1141,306
567,591
348,401
169,306
276,259
251,789
1302,460
706,382
807,520
989,164
1021,840
989,730
435,296
1115,464
1110,826
816,415
736,246
507,584
776,366
299,271
1289,290
894,614
813,425
325,350
321,354
1001,217
957,100
1285,828
764,840
392,819
529,614
1200,431
1049,267
1280,259
316,206
580,660
207,639
5,306
137,603
706,247
184,45
550,333
50,869
289,168
1043,492
10,296
1303,108
184,533
303,105
679,889
934,618
649,438
462,351
23,553
894,728
1201,714
1004,858
880,421
1250,689
666,849
272,726
214,652
316,733
485,341
1258,529
42,813
484,198
763,403
306,401
381,658
863,278
763,499
28,351
388,633
1287,889
35,227
929,658
232,435
773,585
721,457
343,758
671,232
922,694
1088,667
661,754
803,491
1032,38
567,865
494,415
507,491
1148,696
1116,588
1223,469
869,28
5,140
667,38
195,528

fold along x=655
fold along y=447
fold along x=327
fold along y=223
fold along x=163
fold along y=111
fold along x=81
fold along y=55
fold along x=40
fold along y=27
fold along y=13
fold along y=6";
        public override Task ExecuteAsync()
        {
            var grid = new Grid<bool>();
            IList<(bool, int)> folds = new List<(bool, int)>();
            bool inputFoldPart = false;
            foreach (var line in input.Split(Environment.NewLine))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    inputFoldPart = true;
                }
                else if(inputFoldPart)
                {
                    var fold = line.Split(' ').Last().Split('=');
                    folds.Add((fold[0] == "x", int.Parse(fold[1])));
                }
                else
                {
                    var parts = line.Split(',');
                    grid[int.Parse(parts[0]), int.Parse(parts[1])] = true;
                }
            }

            foreach (var fold in folds)
            {
                grid = Fold(fold.Item1, fold.Item2);
            }

            for (int y = grid.MinY; y <= grid.MaxY; y++)
            {
                var sb = new StringBuilder();
                for (int x = grid.MinX; x <= grid.MaxX; x++)
                {
                    sb.Append(grid[x, y].Found ? "*" : " ");
                }
                Console.WriteLine(sb);
            }


            Result = grid.AllMembers().Count().ToString();


            Grid<bool> Fold(bool foldOnX, int index)
            {
                var result = new Grid<bool>();
                foreach (var location in grid.AllMembers())
                {
                    if (foldOnX)
                    {
                        if (location.x < index)
                        {
                            result[location.x, location.y] = true;
                        }
                        else
                        {
                            result[2 * index - location.x, location.y] = true;
                        }
                    }
                    else
                    {
                        if (location.y < index)
                        {
                            result[location.x, location.y] = true;
                        }
                        else
                        {
                            result[location.x, 2 * index - location.y] = true;
                        }
                    }
                }

                return result;
            }

            return Task.CompletedTask;
        }

        public override int Nummer => 202113;
    }
}
