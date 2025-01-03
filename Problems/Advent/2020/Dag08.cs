using System.Collections.Generic;
using System.Threading.Tasks;

namespace Problems.Advent._2020;

public class Dag08 : Problem
{
    #region input

    private const string input = @"acc +42
acc -12
nop +112
acc +47
jmp +600
acc +21
jmp +1
acc +0
acc +50
jmp +16
acc +10
jmp +56
acc -5
nop +179
nop +36
jmp +341
acc -12
nop +580
acc -9
jmp +112
acc +12
acc +6
acc +40
acc +1
jmp +237
acc +50
jmp +61
nop +542
jmp +644
nop +598
nop +280
acc +34
acc +10
jmp +486
acc +34
nop +152
acc +35
jmp +629
acc +37
jmp +447
acc +50
nop +522
acc +43
jmp +271
jmp +451
acc +27
jmp +1
acc +24
nop +532
jmp +494
acc +39
acc -10
acc +42
acc -9
jmp +54
acc +36
jmp +236
acc +34
acc +47
nop +613
acc +27
jmp +561
acc +3
acc -5
acc +11
acc +19
jmp +111
acc +32
nop -52
jmp +108
acc -16
acc +40
jmp +207
nop -44
acc +47
jmp +159
nop +150
acc +43
acc +7
jmp +200
nop +141
acc +2
jmp +487
acc +27
nop +122
nop +519
jmp +22
nop +27
nop +251
acc -2
jmp +171
acc -11
jmp +242
acc +14
acc -11
jmp +540
acc -5
acc +47
acc +14
jmp +252
acc +34
acc +28
acc +1
jmp +311
jmp +1
acc +28
acc +0
jmp +321
acc +23
acc +8
acc +26
acc +0
jmp +202
jmp +541
acc +21
acc -9
acc +7
jmp +81
acc +5
acc +31
acc -16
jmp +56
acc -1
acc +21
acc +45
acc -7
jmp +278
acc +0
acc +2
acc -4
jmp +514
acc -1
acc -16
acc +32
jmp +248
acc +25
jmp +333
acc -18
acc +0
acc +25
acc +43
jmp +416
acc +18
nop -127
acc +37
acc -4
jmp +495
nop +16
jmp +1
jmp +320
acc +22
jmp +453
acc -3
nop +519
nop +49
jmp +32
jmp -89
acc +11
acc +31
jmp +454
acc +12
acc +32
jmp +283
acc -2
nop +411
jmp -65
acc +0
nop +25
acc +5
acc +0
jmp +284
acc -15
jmp +1
jmp +166
acc +27
acc +50
jmp +91
jmp -104
nop +71
jmp +358
acc +15
acc +1
jmp -60
acc +20
acc +6
acc +10
jmp +228
acc -3
jmp +316
acc +5
acc +11
jmp +254
acc -3
acc +20
jmp +194
acc +9
acc -8
jmp +6
acc +30
jmp +376
acc -19
acc -8
jmp -122
jmp +3
nop -41
jmp -68
jmp -119
nop +434
acc -16
nop -199
acc +37
jmp +68
acc +3
acc +18
acc +38
acc -8
jmp +327
nop +110
acc +9
acc +31
jmp -8
jmp +130
acc +20
acc -1
nop +16
jmp +24
nop +14
nop -40
nop -57
acc +10
jmp +239
nop +164
nop +196
jmp -208
acc -12
jmp +284
acc +10
acc +27
jmp +1
jmp -195
acc +1
acc +10
acc +25
acc -17
jmp +25
acc +42
acc +1
acc -3
jmp -148
jmp -28
acc +34
nop -222
acc +3
acc +15
jmp +115
acc +26
acc +36
acc +33
jmp -248
acc -14
jmp -89
acc +19
acc -14
acc +34
jmp +380
jmp +1
jmp -5
jmp +187
jmp +236
acc -4
acc +47
jmp +2
jmp +232
jmp +1
acc -8
jmp +397
acc +7
acc +2
jmp +136
jmp +325
acc +11
acc -17
acc -4
jmp -43
acc +20
acc -9
jmp +60
acc +36
acc +49
nop +333
acc +38
jmp -169
acc +2
acc +8
jmp +82
acc +6
jmp -159
acc +25
acc +23
acc +18
acc +41
jmp -138
jmp -145
acc +49
acc +37
jmp +123
acc +2
nop +179
acc -19
jmp -152
jmp -294
acc +50
acc +50
jmp -46
acc +17
jmp -158
acc -11
acc +5
acc -6
jmp +278
acc +3
acc +26
acc +27
acc +24
jmp -69
acc +22
jmp +204
acc +15
acc +49
acc +1
acc +22
jmp +149
acc +31
jmp +131
jmp -309
acc +40
acc +39
acc +44
jmp -216
acc +15
acc +17
jmp +54
nop +157
acc +24
acc +18
jmp -111
acc -6
jmp +22
acc +17
acc -3
jmp -228
acc -2
acc +41
jmp +235
nop +234
jmp -82
nop -83
acc +44
acc +39
nop +216
jmp -180
jmp -163
acc +13
acc +0
jmp +1
jmp +301
acc +14
nop -187
jmp -181
acc +48
nop +169
acc +27
jmp -334
nop -226
acc +3
jmp -61
jmp +1
acc -15
jmp -175
acc +9
acc +19
jmp +223
acc +20
acc +39
acc +50
acc +13
jmp -119
jmp +240
acc +50
acc +40
acc -14
jmp +236
acc +0
acc +0
jmp +34
acc +20
acc -3
nop -136
acc +4
jmp -370
acc +38
acc +25
acc +9
jmp -240
jmp +1
acc -10
acc +21
acc +46
jmp +118
acc -8
acc +12
nop +64
acc +0
jmp +253
acc +32
acc -6
acc +44
jmp +115
acc +36
acc +23
acc +21
nop +88
jmp -275
acc +8
jmp -127
acc +5
acc +42
jmp +82
acc +41
acc +31
acc +45
acc +20
jmp +131
acc +21
acc +7
jmp +97
acc +12
acc +0
nop +61
acc +36
jmp -106
acc +20
acc -1
acc -14
jmp -210
acc -12
acc -19
acc -19
jmp -25
acc -11
nop -247
acc +0
acc +7
jmp -290
acc +36
acc +43
acc +8
nop -154
jmp -102
acc +8
acc +31
acc +44
acc -5
jmp -184
jmp -252
acc +50
acc +18
acc +5
jmp -141
jmp -159
acc -4
acc +8
acc +4
acc -5
jmp +56
acc +19
acc +46
jmp +53
acc +45
jmp -316
acc -5
acc -1
nop +98
jmp +195
jmp +1
jmp +58
acc +15
nop -471
acc +14
jmp +48
nop -269
nop +8
nop -223
acc +24
jmp -288
jmp +85
nop -1
jmp +1
jmp +45
acc +48
nop -490
acc +0
jmp +37
jmp +132
acc +5
jmp -256
acc +12
acc +22
jmp -479
acc +15
nop -56
acc -18
acc -6
jmp -157
nop +16
acc +5
acc +26
acc +42
jmp -172
acc -13
acc -2
jmp -237
acc +9
acc -10
acc -16
jmp +32
acc +11
acc +3
jmp -208
jmp -449
jmp -383
jmp +96
acc -9
acc -14
jmp -30
nop -36
jmp +21
jmp +117
jmp -169
jmp -387
acc -5
acc -9
jmp -344
acc +13
acc +4
acc +45
jmp -219
acc +9
acc +44
acc +31
acc +16
jmp -71
jmp -77
acc -1
acc +40
acc +31
jmp -385
acc +1
jmp -255
nop -20
acc +0
acc +29
jmp -180
acc +13
acc +5
nop -292
jmp -204
acc +30
jmp -265
acc +19
acc +31
jmp -457
acc +16
acc +27
jmp +67
jmp +88
acc +20
acc +44
acc +27
jmp -40
acc +26
acc +48
acc +28
acc -12
jmp -120
acc -9
acc +42
jmp -543
acc +4
nop +83
acc +41
jmp -28
acc +40
acc -17
acc +14
acc -6
jmp -70
nop -294
acc -10
acc +9
acc +7
jmp -322
jmp +1
jmp -46
acc +0
acc +38
acc +6
jmp -381
acc +49
acc -16
acc +35
acc +45
jmp -184
acc -6
acc -13
acc +9
jmp -180
acc +18
acc +49
acc -4
nop -197
jmp -395
nop -266
jmp -530
acc +16
acc +9
jmp -117
acc -4
acc -7
acc +44
acc +35
jmp -122
acc +31
acc -5
jmp -503
jmp -555
acc +19
acc +25
acc -10
acc +50
jmp -493
jmp -591
acc +40
jmp -491
nop +28
nop -48
acc +11
nop -25
jmp -591
jmp +1
acc -15
acc +21
acc +46
jmp -199
jmp +1
acc +42
acc +10
acc -11
jmp -213
acc -8
acc +2
acc +36
jmp -470
acc +37
jmp -195
jmp -38
acc +17
jmp -26
nop -376
acc +27
acc +11
jmp -185
acc +44
acc +12
acc +9
acc +14
jmp -626
jmp -89
acc +45
acc +23
acc +13
acc +19
jmp +1";
    #endregion  
    public override Task ExecuteAsync()
    {
        int index = -1;
        while (true)
        {
            index++;
            var console = new GameConsole(input) { IsRunning = true };
            if (console.Instructions[index].Operation == GameConsole.InstructionType.Nop)
            {
                console.Instructions[index].Operation = GameConsole.InstructionType.Jmp;
            }
            else if (console.Instructions[index].Operation == GameConsole.InstructionType.Jmp)
            {
                console.Instructions[index].Operation = GameConsole.InstructionType.Nop;
            }
            else
            {
                continue;
            }
            HashSet<int> pointers = new HashSet<int>();
            while (!pointers.Contains(console.Pointer) && console.IsRunning)
            {
                pointers.Add(console.Pointer);
                console.Step();
            }

            if (!console.IsRunning)
            {
                Result = console.Accumulator.ToString();
                return Task.CompletedTask;
            }
        }

        return Task.CompletedTask;
    }

    public override int Nummer => 202008;
}