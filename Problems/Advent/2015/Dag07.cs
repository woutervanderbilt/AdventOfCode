using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2015;

internal class Dag07 : Problem
{
    private const string input = @"lf AND lq -> ls
iu RSHIFT 1 -> jn
bo OR bu -> bv
gj RSHIFT 1 -> hc
et RSHIFT 2 -> eu
bv AND bx -> by
is OR it -> iu
b OR n -> o
gf OR ge -> gg
NOT kt -> ku
ea AND eb -> ed
kl OR kr -> ks
hi AND hk -> hl
au AND av -> ax
lf RSHIFT 2 -> lg
dd RSHIFT 3 -> df
eu AND fa -> fc
df AND dg -> di
ip LSHIFT 15 -> it
NOT el -> em
et OR fe -> ff
fj LSHIFT 15 -> fn
t OR s -> u
ly OR lz -> ma
ko AND kq -> kr
NOT fx -> fy
et RSHIFT 1 -> fm
eu OR fa -> fb
dd RSHIFT 2 -> de
NOT go -> gp
kb AND kd -> ke
hg OR hh -> hi
jm LSHIFT 1 -> kg
NOT cn -> co
jp RSHIFT 2 -> jq
jp RSHIFT 5 -> js
1 AND io -> ip
eo LSHIFT 15 -> es
1 AND jj -> jk
g AND i -> j
ci RSHIFT 3 -> ck
gn AND gp -> gq
fs AND fu -> fv
lj AND ll -> lm
jk LSHIFT 15 -> jo
iu RSHIFT 3 -> iw
NOT ii -> ij
1 AND cc -> cd
bn RSHIFT 3 -> bp
NOT gw -> gx
NOT ft -> fu
jn OR jo -> jp
iv OR jb -> jc
hv OR hu -> hw
19138 -> b
gj RSHIFT 5 -> gm
hq AND hs -> ht
dy RSHIFT 1 -> er
ao OR an -> ap
ld OR le -> lf
bk LSHIFT 1 -> ce
bz AND cb -> cc
bi LSHIFT 15 -> bm
il AND in -> io
af AND ah -> ai
as RSHIFT 1 -> bl
lf RSHIFT 3 -> lh
er OR es -> et
NOT ax -> ay
ci RSHIFT 1 -> db
et AND fe -> fg
lg OR lm -> ln
k AND m -> n
hz RSHIFT 2 -> ia
kh LSHIFT 1 -> lb
NOT ey -> ez
NOT di -> dj
dz OR ef -> eg
lx -> a
NOT iz -> ja
gz LSHIFT 15 -> hd
ce OR cd -> cf
fq AND fr -> ft
at AND az -> bb
ha OR gz -> hb
fp AND fv -> fx
NOT gb -> gc
ia AND ig -> ii
gl OR gm -> gn
0 -> c
NOT ca -> cb
bn RSHIFT 1 -> cg
c LSHIFT 1 -> t
iw OR ix -> iy
kg OR kf -> kh
dy OR ej -> ek
km AND kn -> kp
NOT fc -> fd
hz RSHIFT 3 -> ib
NOT dq -> dr
NOT fg -> fh
dy RSHIFT 2 -> dz
kk RSHIFT 2 -> kl
1 AND fi -> fj
NOT hr -> hs
jp RSHIFT 1 -> ki
bl OR bm -> bn
1 AND gy -> gz
gr AND gt -> gu
db OR dc -> dd
de OR dk -> dl
as RSHIFT 5 -> av
lf RSHIFT 5 -> li
hm AND ho -> hp
cg OR ch -> ci
gj AND gu -> gw
ge LSHIFT 15 -> gi
e OR f -> g
fp OR fv -> fw
fb AND fd -> fe
cd LSHIFT 15 -> ch
b RSHIFT 1 -> v
at OR az -> ba
bn RSHIFT 2 -> bo
lh AND li -> lk
dl AND dn -> do
eg AND ei -> ej
ex AND ez -> fa
NOT kp -> kq
NOT lk -> ll
x AND ai -> ak
jp OR ka -> kb
NOT jd -> je
iy AND ja -> jb
jp RSHIFT 3 -> jr
fo OR fz -> ga
df OR dg -> dh
gj RSHIFT 2 -> gk
gj OR gu -> gv
NOT jh -> ji
ap LSHIFT 1 -> bj
NOT ls -> lt
ir LSHIFT 1 -> jl
bn AND by -> ca
lv LSHIFT 15 -> lz
ba AND bc -> bd
cy LSHIFT 15 -> dc
ln AND lp -> lq
x RSHIFT 1 -> aq
gk OR gq -> gr
NOT kx -> ky
jg AND ji -> jj
bn OR by -> bz
fl LSHIFT 1 -> gf
bp OR bq -> br
he OR hp -> hq
et RSHIFT 5 -> ew
iu RSHIFT 2 -> iv
gl AND gm -> go
x OR ai -> aj
hc OR hd -> he
lg AND lm -> lo
lh OR li -> lj
da LSHIFT 1 -> du
fo RSHIFT 2 -> fp
gk AND gq -> gs
bj OR bi -> bk
lf OR lq -> lr
cj AND cp -> cr
hu LSHIFT 15 -> hy
1 AND bh -> bi
fo RSHIFT 3 -> fq
NOT lo -> lp
hw LSHIFT 1 -> iq
dd RSHIFT 1 -> dw
dt LSHIFT 15 -> dx
dy AND ej -> el
an LSHIFT 15 -> ar
aq OR ar -> as
1 AND r -> s
fw AND fy -> fz
NOT im -> in
et RSHIFT 3 -> ev
1 AND ds -> dt
ec AND ee -> ef
NOT ak -> al
jl OR jk -> jm
1 AND en -> eo
lb OR la -> lc
iu AND jf -> jh
iu RSHIFT 5 -> ix
bo AND bu -> bw
cz OR cy -> da
iv AND jb -> jd
iw AND ix -> iz
lf RSHIFT 1 -> ly
iu OR jf -> jg
NOT dm -> dn
lw OR lv -> lx
gg LSHIFT 1 -> ha
lr AND lt -> lu
fm OR fn -> fo
he RSHIFT 3 -> hg
aj AND al -> am
1 AND kz -> la
dy RSHIFT 5 -> eb
jc AND je -> jf
cm AND co -> cp
gv AND gx -> gy
ev OR ew -> ex
jp AND ka -> kc
fk OR fj -> fl
dy RSHIFT 3 -> ea
NOT bs -> bt
NOT ag -> ah
dz AND ef -> eh
cf LSHIFT 1 -> cz
NOT cv -> cw
1 AND cx -> cy
de AND dk -> dm
ck AND cl -> cn
x RSHIFT 5 -> aa
dv LSHIFT 1 -> ep
he RSHIFT 2 -> hf
NOT bw -> bx
ck OR cl -> cm
bp AND bq -> bs
as OR bd -> be
he AND hp -> hr
ev AND ew -> ey
1 AND lu -> lv
kk RSHIFT 3 -> km
b AND n -> p
NOT kc -> kd
lc LSHIFT 1 -> lw
km OR kn -> ko
id AND if -> ig
ih AND ij -> ik
jr AND js -> ju
ci RSHIFT 5 -> cl
hz RSHIFT 1 -> is
1 AND ke -> kf
NOT gs -> gt
aw AND ay -> az
x RSHIFT 2 -> y
ab AND ad -> ae
ff AND fh -> fi
ci AND ct -> cv
eq LSHIFT 1 -> fk
gj RSHIFT 3 -> gl
u LSHIFT 1 -> ao
NOT bb -> bc
NOT hj -> hk
kw AND ky -> kz
as AND bd -> bf
dw OR dx -> dy
br AND bt -> bu
kk AND kv -> kx
ep OR eo -> eq
he RSHIFT 1 -> hx
ki OR kj -> kk
NOT ju -> jv
ek AND em -> en
kk RSHIFT 5 -> kn
NOT eh -> ei
hx OR hy -> hz
ea OR eb -> ec
s LSHIFT 15 -> w
fo RSHIFT 1 -> gh
kk OR kv -> kw
bn RSHIFT 5 -> bq
NOT ed -> ee
1 AND ht -> hu
cu AND cw -> cx
b RSHIFT 5 -> f
kl AND kr -> kt
iq OR ip -> ir
ci RSHIFT 2 -> cj
cj OR cp -> cq
o AND q -> r
dd RSHIFT 5 -> dg
b RSHIFT 2 -> d
ks AND ku -> kv
b RSHIFT 3 -> e
d OR j -> k
NOT p -> q
NOT cr -> cs
du OR dt -> dv
kf LSHIFT 15 -> kj
NOT ac -> ad
fo RSHIFT 5 -> fr
hz OR ik -> il
jx AND jz -> ka
gh OR gi -> gj
kk RSHIFT 1 -> ld
hz RSHIFT 5 -> ic
as RSHIFT 2 -> at
NOT jy -> jz
1 AND am -> an
ci OR ct -> cu
hg AND hh -> hj
jq OR jw -> jx
v OR w -> x
la LSHIFT 15 -> le
dh AND dj -> dk
dp AND dr -> ds
jq AND jw -> jy
au OR av -> aw
NOT bf -> bg
z OR aa -> ab
ga AND gc -> gd
hz AND ik -> im
jt AND jv -> jw
z AND aa -> ac
jr OR js -> jt
hb LSHIFT 1 -> hv
hf OR hl -> hm
ib OR ic -> id
fq OR fr -> fs
cq AND cs -> ct
ia OR ig -> ih
dd OR do -> dp
d AND j -> l
ib AND ic -> ie
as RSHIFT 3 -> au
be AND bg -> bh
dd AND do -> dq
NOT l -> m
1 AND gd -> ge
y AND ae -> ag
fo AND fz -> gb
NOT ie -> if
e AND f -> h
x RSHIFT 3 -> z
y OR ae -> af
hf AND hl -> hn
NOT h -> i
NOT hn -> ho
he RSHIFT 5 -> hh";

    public override Task ExecuteAsync()
    {
        IDictionary<string, int> signals = new Dictionary<string, int>();
        IDictionary<string, IList<Instruction>> instructions = new Dictionary<string, IList<Instruction>>();
        foreach (var line in input.Split(Environment.NewLine))
        {
            var split = line.Split(' ');
            var instruction = new Instruction();
            instruction.Output = split.Last();
            if (split[0] == "NOT")
            {
                instruction.Gate = Gate.NOT;
                instruction.Input1 = split[1];
            }
            else if (split.Length == 3)
            {
                instruction.Input1 = split[0];
                if (instruction.Output == "b")
                {
                    instruction.Input1 = "16076";
                }
            }
            else
            {
                if (split[1] == "AND")
                {
                    instruction.Gate = Gate.AND;
                }
                else if (split[1] == "OR")
                {
                    instruction.Gate = Gate.OR;
                }
                else if (split[1] == "LSHIFT")
                {
                    instruction.Gate = Gate.LSHIFT;
                }
                else if (split[1] == "RSHIFT")
                {
                    instruction.Gate = Gate.RSHIFT;
                }

                instruction.Input1 = split[0];
                instruction.Input2 = split[2];
            }

            if (int.TryParse(instruction.Input1, out var input1))
            {
                instruction.InputValue1 = input1;
                if (string.IsNullOrEmpty(instruction.Input2))
                {
                    signals[instruction.Output] = input1;
                    instruction.Complete = true;
                }
            }
            if (int.TryParse(instruction.Input2, out var input2))
            {
                instruction.InputValue2 = input2;
            }

            if (!instructions.ContainsKey(instruction.Input1))
            {
                instructions[instruction.Input1] = new List<Instruction>();
            }
            instructions[instruction.Input1].Add(instruction);
            if (!string.IsNullOrWhiteSpace(instruction.Input2))
            {
                if (!instructions.ContainsKey(instruction.Input2))
                {
                    instructions[instruction.Input2] = new List<Instruction>();
                }
                instructions[instruction.Input2].Add(instruction);
            }
        }

        var signalled = signals.Keys.ToList();
        while (signalled.Any())
        {
            var newSignalled = new List<string>();
            foreach (var wire in signalled)
            {
                if (instructions.ContainsKey(wire))
                {
                    foreach (var instruction in instructions[wire])
                    {
                        if (instruction.Input1 == wire)
                        {
                            instruction.PassInput1(signals[wire]);
                        }

                        if (instruction.Input2 == wire)
                        {
                            instruction.PassInput2(signals[wire]);
                        }

                        if (instruction.Complete)
                        {
                            signals[instruction.Output] = instruction.Value;
                            newSignalled.Add(instruction.Output);
                        }
                    }
                }
            }

            signalled = newSignalled;
        }

        Result = signals["a"].ToString();

        return Task.CompletedTask;
    }

    private class Instruction
    {
        public Gate? Gate { get; set; }
        public string Input1 { get; set; }
        public string Input2 { get; set; }
        public string Output { get; set; }

        public int? InputValue1 { get; set; }
        public int? InputValue2 { get; set; }
        public bool Complete { get; set; }

        public void PassInput1(int value)
        {
            InputValue1 = value;
            if (string.IsNullOrEmpty(Input2) || InputValue2.HasValue)
            {
                ComputeValue();
                Complete = true;
            }
        }

        public void PassInput2(int value)
        {
            InputValue2 = value;
            if (InputValue1.HasValue)
            {
                ComputeValue();
                Complete = true;
            }
        }

        void ComputeValue()
        {
            Value = Gate switch
            {
                Dag07.Gate.AND => InputValue1!.Value & InputValue2!.Value,
                Dag07.Gate.OR => InputValue1!.Value | InputValue2!.Value,
                Dag07.Gate.NOT => 65535 - InputValue1!.Value,
                Dag07.Gate.LSHIFT => (InputValue1!.Value << InputValue2!.Value) % 65536,
                Dag07.Gate.RSHIFT => InputValue1!.Value >> InputValue2!.Value,
                null => InputValue1!.Value
            };
        }

        public int Value { get; private set; }
    }

    private enum Gate
    {
        AND,
        OR,
        NOT,
        RSHIFT,
        LSHIFT
    }

    public override int Nummer => 201507;
}