﻿using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2017;

internal class Dag07 : Problem
{
    private const string input = @"xsddbi (61)
nqtowev (11)
xwohr (82)
flejt (36)
idwpug (54)
uoxzkp (51)
choeijs (54)
gmsjkn (65)
txszqu (687) -> mvjqmad, lwqlyjq, jlgnsu
zhlfdac (15)
htouwcr (74)
vlbsr (56)
titbn (9)
bvrpb (86)
wuwjp (54)
umnqkb (160) -> nbrvl, bcmbao, vfimqtl
uwnml (29)
cdvhmy (42)
xghhu (306) -> molth, atqewc
vcvayah (71)
fujwb (187) -> tyjyc, xyemll
zqnjd (91) -> jxsmuey, uelnii, vcwezm, uxnwtp
wphtnvm (72)
xgihtsx (15)
fwvvidu (80)
lonwb (1656) -> rydrp, mgyixhn, cjhtxo
qyasuw (41)
vbvug (6)
mkrjamh (154) -> ecbog, owaebx
ghvpg (98)
eazvkxv (66)
jguufio (61)
udpcyt (71)
xerbuu (38)
sxzpils (70)
looigzn (10)
znmumx (77)
uxzwwe (67)
wuegrv (99)
owttcz (91)
vkhazkn (37) -> oactn, ftxif, rxlbou, bkfav
rddnfg (10) -> mvgmbru, zlazoqs
zzsqfm (99)
fhjzpjw (19)
zwxwfin (50)
ocdzc (26)
cohps (52)
dxhrpq (46)
yeheld (55)
ekxczvo (81)
pxlzcx (589) -> vjvit, cnblx, bwiqe, pjsbxvk, ipqjxa, zkikz
offkzc (95) -> wymlvix, felrwte, bzublv
bavyg (22) -> szszezd, lurhq, ltncvl, fmwvok, frikrv, tumwln, xjtujzp
awjwff (18)
sjhwgq (8316) -> ydqgvnf, oztasey, qkmkwgl
vmyrdkl (53)
mzrwaa (48)
njqemt (30)
objssr (91) -> xujmi, oqihtt
bcpbvya (75)
fqayb (69)
vwksn (19) -> zwxxii, owttcz
czmzol (145) -> qzayss, ufrrrzi
inija (25)
eppufdw (555) -> brwsjee, laoouso, jgfcyze
mmtzk (39) -> utispep, onkhx
zoofu (129) -> cyczt, qargs
msryw (260)
etvpko (18)
wxudgdd (84)
ymkax (45) -> znmumx, hnjuqgw
uxbjym (87)
msskm (69)
nmtia (75)
jawbtmo (46)
bpelccj (187) -> ctzhawr, qhldpg
dbexmj (365) -> bijprk, iotkxfd
bxcdldt (16)
fhdqcbx (25) -> gefut, mulybo
iunkpe (15)
yzvqo (80)
fbgguv (57) -> bkomu, tynxlau, sfruur, zxvbb, khupkt, xkntkvz
yaripcu (8)
acfmyv (79)
sohuv (18)
aahhxau (233) -> rbauxvx, neliq
yuhmnjs (98)
xpzpv (206) -> mxtxm, kgzyk, yzpaxlz, vfxqcbq, lcgtwj
ovhhkoc (52)
stwubkv (70) -> uzzeydh, zknpmnc
otbxl (54)
bfroq (39)
nkbmoin (341) -> vgqmfj, weygson, knbems, gdmlk, ecfrqpl, tbaai, sfohocq
twazofk (258) -> dntwqr, vugavk
venvbai (32)
pcqpqjk (38)
apqby (37) -> xkzlyvh, vlsjsgg
tgsicj (59)
rsvixyg (32)
whjcp (245)
rmnkgss (22)
zbmwego (55)
lptmne (17) -> fkjlcz, jinwsas, qnevjto, wfjks
rtyegs (76) -> nhbbd, yqqun
cavlg (1148) -> lsaroxx, evkau, gldgrng
kqswas (504) -> ntcddy, bwqmns, vtvsd, oxoqy
tmvfp (46)
dlhyzjw (79)
xsfwcgq (657) -> inknun, seihhya, qrlhp, bchtcht, rswqvx
ekleund (68)
rihlj (72)
oldrtya (66)
yiqnfd (62)
sgpiiir (14)
vbojbp (66)
qnscqms (197) -> mernsee, ubjuhxp, mlfxnna
vfxzkq (660) -> ukrqfm, pnsvthy, qdcos
kkeuh (273) -> urfhlf, hjtkb
sakhif (30)
yrdhq (71)
ckcjr (50) -> owgsk, vdnphf
ndvdj (10)
zzcqptv (87)
aemyrqj (23)
vbauj (49)
rcumpgx (18)
ijyhvsj (25)
gazaoty (83)
lugwl (228)
msrrlv (90)
enxbya (19)
wlyzbz (99)
gmrqpdk (40)
gefut (75)
bafnaij (57)
jgfcyze (166) -> ziqyhi, wrwgm, hdikur, bmqhrtg
rcmyfr (281)
pohdy (87) -> frcqooy, idhvksi
wkfjzs (81)
dcgphc (16)
bgqvm (38)
ltgnnr (87)
xjtujzp (1565) -> soryrk, zkvopb, xufneyr
idhvksi (69)
yjnrjde (65)
lfykdub (61)
dnjydir (41)
ifgfg (197) -> jcbgta, aemyrqj
grlofut (23)
tjaqrw (96)
gjgcvyp (85)
kwavcf (254) -> vmpmig, djeee
mdnqs (101) -> tpmhs, essvr
gqlyhql (159) -> uwrhuw, ypanow
vjzfc (25)
guauivo (42) -> puvhc, bjcsjrr, ccjtpv, ibwve, evbvdgl, stwubkv, kwxpnrs
pbohgz (74) -> sbfiv, igbhyk, rhxcyd
bkomu (42437) -> krbpgmk, ekgbf, yqlxeb, ogyiesm, poypmax
yjoyyvl (55) -> sjioze, nigkvxl, itjxq
efobdsd (218) -> yqnso, glqspl
zxvbb (56366) -> fvkxwt, xlanm, gxitq
cvrga (47) -> vagjk, ghvpg
mwrnosj (52)
dxffr (15)
dcsxekv (41)
kbmse (68)
tqyldbt (59)
nvtyg (31)
jnzqvia (67) -> divak, cmgvs
rhxcyd (44)
hnjuqgw (77)
vdnphf (89)
qqnywdg (160) -> lrjnzf, luhxcq, whgpim
sfizdf (1053) -> aahhxau, shiiodm, cvnfak, whjcp
zdawjkr (34)
tracdgp (27)
tcvgl (305) -> ljfvbjd, bafnaij
iuwwa (42)
iekwfia (52)
odoxr (72)
uravet (102) -> hzzxjxa, mvdzfo
jvnuwap (66)
kjdjdr (76) -> kpdmptf, hsqhwef
vycgaoz (82) -> jqulm, ziwlgdb
ifdkle (202)
gtpyffj (812) -> kcpwmyz, emkzxk, hwuabde, efgqua
oxoqy (17) -> lktbqq, zukio, bcpbvya
kfngejn (49)
anhjp (75)
xwwzp (14358) -> lonfrp, eppufdw, nmxqs
wcpyi (205)
wzxqipp (88)
ekgbf (6702) -> bckbud, fzzlnwi, cvprip
ziwlgdb (63)
bxqjg (70)
bverp (49)
rlgbvvj (13)
sqvxf (37)
ltncvl (977) -> sktewq, hydeeqe, ibdjxl
fxqng (90)
jcdmhvd (157) -> twgrfm, dxhrpq
kpgatn (41)
znpvlac (97) -> vmyrdkl, aideelj
vifbi (634) -> rkwkwd, onqax, cfrcco, onamlmy, zoofu, vwosnfn
gezqw (12)
hagrq (97) -> fhecgzf, mefajk, uyrxc, gdclwzu
gdclwzu (60)
sczyp (19)
cvlkltp (151) -> guiej, vffqp
fimqsn (125) -> ehvxt, xyoiv, mikast
lktbqq (75)
tyjyc (55)
xoqvvx (18) -> xawfk, ojrjqv
bcmbao (89)
qntpdh (93)
iieico (12)
modms (37)
xwwfi (82) -> cpjkea, hsexbak, dxaemlq, wlyzbz
xxoil (23)
uelnii (82)
shiiodm (53) -> hclea, nrduy
hqwkq (42)
twgrfm (46)
yrozpm (246) -> btukw, fbyju
onqax (301) -> vtlvs, ccnpjdf
klhfca (81)
lvcsn (95)
jpcseag (92)
tgwgno (202) -> yyyub, ofcyw
ztjquwi (545) -> ptawnqq, ziprwty, yzfzbw, hpqux, baaqr, bwugxhi
ealyedu (71)
debir (48)
ppossv (51)
kzxyyd (62)
bchtcht (185) -> rsvixyg, cppdkv
ndeop (9)
htujh (695) -> nzhnurq, btbnj, ghsxqq
lkwogh (53)
ofyuao (159) -> llhiw, nbjpcc
vxlypal (9)
dvipr (67) -> udnmqte, osnjzpt, swujbg
ybnehoi (50) -> hatmr, alkizae
xkntkvz (44502) -> lwugjj, cstmu, rsjffj, pxlzcx, jtmuv
fhvyhk (252) -> boqgjn, rzzezfx
krmbsc (47)
jkymeqw (26)
xjypx (70)
jytapdu (15) -> vqvwkm, jpcseag, kgkpfg
btrepl (15)
umnkslz (13)
lxbsif (72)
adunt (71)
cupeghk (67)
xcckt (7)
mutwmaa (39)
qmpncds (39)
ypanow (88)
zhhhntj (51)
tcqnso (85)
uakcbox (68)
sckgsn (38)
bgpjb (136) -> aqaems, jkymeqw
gxitq (83) -> wshlljj, krpda, aasxby, ywhjz, stnnf, nfkmi
ulehitr (187) -> knrtys, mnfep
galojia (25)
pjxauhw (61)
wvhvw (229) -> xcckt, duzgl
cpjkea (99)
jqulm (63)
gpqhjv (20) -> wzxqipp, ykxnd, dhsopiv
ipqjxa (51) -> gsmcgor, inlcow, hdmcpq, xhmornc, lisfhnn
ofwtjhw (38)
pkceuqw (62) -> isqxwp, evkrnfo, pcqpqjk
hmnvh (97)
cxcah (75)
fkjof (90)
iinxvw (14)
ckypedd (61)
vxwobup (543) -> sejkvk, olrdlw, hfxsib
hpqux (196) -> ocdzc, xlvjz
gyuyu (173) -> xfurlrr, etlce
rffwau (96)
bfulyh (154) -> tjuqz, tzqdwe, ayeqoz
llhiw (88)
vmsmdqx (72)
aasxby (832) -> lvcdsgp, dhejgd, nzvpgv
qlkjhsi (25)
chhhge (34)
rveuz (18)
cmbnwse (112) -> jphmpr, tlkhxww
ppqdnd (175)
szvty (18)
crbcsqt (382) -> oakbrw, dswjpxm
xqxgd (76)
dxddn (12)
usitmiz (81)
vqrtnp (44)
axkhzf (94)
tzszs (299) -> jieijuo, ndeop
frjtwx (94)
tzqdwe (32)
sjioze (46)
yzpaxlz (216) -> heqbpd, dphmg
lewbxa (43)
knbems (173) -> looigzn, qdkrr
bwqmns (210) -> dcgphc, wwzli
vtwdqkd (61) -> vcvayah, wyhnmbs
owgsk (89)
dpfvy (54)
qongfb (48)
qilhudr (125) -> qbcar, wuwjp, umxurvd
aahqtsf (1755) -> hfhswyd, znpvlac, bruqu
dxaemlq (99)
gybikf (185) -> uwnml, noqjuo
vjvit (194) -> jdhewio, wwhlo, crbcsqt
zkikz (194) -> ttqpi, ifdkle, qdyzunw, wkcrce, jcezw, qeiijk
wphgd (7)
nmxqs (180) -> sftqzaf, gyuyu, tkvmtol, vwksn, doppnr
bpgdb (190) -> jxpixqi, kygcziz
tmigcw (151) -> gmsjkn, njmlk
lodcj (54)
loxjzpo (59)
fxfznc (32)
hwuabde (207) -> mvamo, bverp
ixroc (98)
wdzhfmw (126) -> galojia, ibyrsdo
bznst (20)
dkoike (123) -> wuckr, mfbnys, gmrqpdk
atyaqz (112) -> asmysiq, paoitb, okpdcz
bsfsayz (13)
ffhxi (15)
rgkrl (85)
fhecgzf (60)
lwugjj (361) -> hykxm, hechfb, edtkfvv, lonwb
qtraszq (13)
qargs (95)
adwir (18)
bnmshvm (145) -> vfmlyg, ychjmik
isqxwp (38)
yblsbf (83)
azzysl (36) -> anhjp, ixnlvyo, mmndzs, alaug
ysdqkw (87)
olevfy (158) -> wuipwl, etvpko, bavaf
tvcxl (25) -> vlmzodk, vbojbp, oldrtya
fhyvz (40)
hzfwtzf (75)
gdmlk (5) -> bgavnd, iqpcu
utojr (82) -> nuytv, frjtwx, guurpo
kcpwmyz (97) -> oykqvif, ukrjos, mwrnosj, bdjlzf
qvndh (115) -> fyeuhqh, kmbrqv, kgqgct, qtraszq
fvjcbib (98)
ziiijv (85)
lbnenyf (75) -> tdhxy, ozlqcn
nbwkld (54)
blpjnzf (123) -> gapzarg, syxkp
jhruwih (84)
ecbog (27)
ccqldu (46)
izyxppl (58)
lfwru (177) -> smiucuf, libtrl
cvnfak (123) -> lfykdub, yxqaa
jwjrj (89)
ytbyct (73) -> yaehsu, cxcah
oqihtt (68)
mvjqmad (359) -> swaxyxe, perbvgz
vahnoue (42)
egrimlf (42)
uewchd (1998) -> oqqme, vaeeqvi
hbtur (295) -> mgqkhic, jkvgvz
qekpce (78)
anehvd (75) -> frezf, wvdoa
laeaf (38)
hipfszh (149) -> dxavaum, qkapxbc, adwir
parvx (15)
ayeqoz (32)
weunegg (85)
cbbtbz (85)
fkjwn (67)
takxgz (49)
heqbpd (6)
yxpnzkn (212) -> dxavw, nxpozme, wdjcb
vkwsodp (38)
asmysiq (51)
ilvblzm (85)
laohhtn (86)
onoyb (86)
sfwaimh (24)
grtrt (96)
oekhu (40)
jxqzmuv (7)
vtlvs (9)
jjdmu (84)
qzobjfo (158) -> vetsll, utsfqn, dcsxekv
uwrfay (60)
guurpo (94)
kpnxkyy (32)
aqugisv (965) -> rddnfg, qozmho, pbohgz, lupyc
dswjpxm (11)
smiucuf (53)
mfamq (74)
agfnncm (95)
qshoazt (1737) -> ockzlpp, yeheld, judfhye
wngzh (9094) -> guauivo, aiwvi, vxruziw, ikqijv
hawmd (40)
kxkwxoj (32) -> pyvwl, akdffhk
qdpoyl (4734) -> aahqtsf, lnontej, lfiteup, oaopxo
ftkflbo (27)
ukrjos (52)
fdzqz (70)
dvncmy (1046) -> hzfwtzf, nmtia, ygiyze, zuquy
gsfnr (96)
cprbzvp (28)
tyywgp (57)
gsmocx (118) -> krmbsc, ywmif
laoouso (122) -> xvdkt, eogzpga
yzfzbw (178) -> vjevs, paqihg
cxhuwiw (46)
vfimqtl (89)
dkcqdx (132) -> wemjk, kyuneoo
dszip (73) -> vzbpn, xqxgd
chljtta (157) -> dpfvy, nbwkld
zzcagx (165) -> wuvmf, nrvsqf
xfglmz (740) -> nrlhen, rfkcylj, ymkax
pnsvthy (103) -> cadasac, rpxmv, azkmt
xokmont (84)
divak (77)
lonfrp (60) -> pohdy, bnmshvm, oheank, qwlze, dszip
yngqiv (236) -> cayigxg, ixomyeb
lfiteup (1188) -> qnsqwm, qdpnnex, cmbnwse, onaatvy
mefajk (60)
eqbwx (23)
zuoczei (64) -> ismrc, dbexmj, oeqqj
kygcziz (14)
nwxyrtn (87) -> kpgatn, egcjfjo
loljfo (10)
bruqu (17) -> uwylbft, qntpdh
wohvpbn (67)
qgvqg (315) -> iekwfia, qhrxvzj
wwhlo (36) -> hcyjfzz, dbuqsj, latmzh, geztlsi
oheank (225)
ujpgmwm (50)
ndgzf (37)
rgzrnnl (52)
vgjgz (24)
fvwll (147) -> axkhzf, mqpbpgq
iqtemv (69)
yfrmup (6)
rzzezfx (56)
qkpaxtt (76) -> wohvpbn, fkjwn
tjuqz (32)
ztfhz (8)
wayftw (17)
qbcar (54)
neliq (6)
yxqaa (61)
lupyc (114) -> rsqihar, moivx, xxoil, vggstn
dlkhb (56)
uctlk (36)
ssyfvrj (56)
ibwve (36) -> zfmas, sddvn
brwsjee (46) -> uqpprye, ejovcx
wgcgdvt (13)
ndhitxf (141) -> uoxzkp, ppossv
seblnmz (31)
osnjzpt (36)
cihzh (85)
dtkdwp (42)
xmogef (10)
btbnj (186) -> jxqzmuv, tycgm, xewbn, rjayavy
gcrbrn (90)
jiaho (7)
czuwoe (325) -> hxzjg, cfiyqh
hxzjg (6)
zfshwt (80)
frycrnj (44)
owcwvug (85)
cnsbonb (64)
gwudp (77)
xsjbc (89)
fvkxwt (7466) -> zuoczei, gjwzw, qsyocuq
whgpim (68)
tzhoqw (84)
bbbms (56)
ubhlb (350)
zzbzwdm (34)
cwixiq (35) -> jvnuwap, hkweu
ecytwe (249)
ckombz (80)
bzbfpkb (156) -> zhrsp, rgzrnnl
vfkjif (42)
oinyx (42)
necqpdx (48)
qpden (7)
ruabtb (88) -> xvwio, lhbwbik
btukw (52)
rkofvt (1150) -> gkqgru, xoqvvx, iqler, dhaxwd
utyrttu (89) -> wjaocmd, xwohr, rxflxr
nnnkplx (23)
kgzyk (90) -> iqymm, asrwh
ukrqfm (96) -> yuiicxp, qjnhwpq
aulgwyb (852) -> rhjxbx, weguko, ppqdnd, csmul, srscbv, kriwb
jppsaym (95)
vfmlyg (40)
weygson (129) -> kpnxkyy, wdcltyl
vzbpn (76)
foibc (12)
hsqhwef (48)
hpgwq (18)
crothf (108) -> pwfdn, hawmd
nfmicyi (65)
cjeauo (97)
ptawnqq (65) -> kcjwb, bvknwgq, xsddbi
oicysoz (33) -> awgjkiv, ndszsz
rdvtzr (11)
swqym (72)
cppdkv (32)
uuapl (38)
yriibfp (27)
nfklqi (22)
xhmornc (148) -> dnjydir, icnav, qyasuw
lhbwbik (72)
wshlljj (1198) -> ojqqw, olevfy, iwiaa
mjtuzfr (23) -> ukaflr, zzsqfm
zxavxe (34) -> swqym, yreenth, ubvheu
pxhwr (7)
wyhnmbs (71)
nigkvxl (46)
perbvgz (23)
kyuneoo (64)
djeee (15)
lkfdr (85)
evkau (63)
tridq (59)
eepdcje (37) -> cxhuwiw, damyp, tmvfp
nzdbs (50)
ejnqcb (74)
dfzwcc (74)
efgqua (62) -> klhfca, usitmiz, aceqrlu
mqpbpgq (94)
boqgjn (56)
bxkxp (81)
vbzwk (48)
gldgrng (63)
kgkpfg (92)
jutgp (84)
zouxmz (48)
uktpcar (155) -> ebwgi, pozpmyh
dhaxwd (167) -> pxhwr, qxyramq, wphgd
yreenth (72)
iciuuh (63) -> gslii, fqaefy, hwuwj
xifaq (38)
oqdukh (56)
hasyyr (24)
khzbxke (174) -> ftkflbo, tracdgp
zoryb (73) -> eusnn, exqkey
ebnqn (9)
pncxkcd (156) -> izpxjp, myckhlw
qqmlvk (96)
qpxgye (93)
qybit (79)
stbgj (10)
smsoi (53)
zlpxr (136) -> iuauic, dznlyl
wfwbq (42)
frcqooy (69)
zxrmy (70)
mxvaxl (60)
wwzli (16)
jpnhog (8)
pablb (107) -> muopf, oekhu, thzqscd
mxgyt (51)
xkzlyvh (80)
fkrog (46)
qcntm (13) -> lvcsn, kpqwup, gosgwz, moiqr
wzybp (73)
urkya (70)
lqbnqnl (91)
sycbr (76) -> mutwmaa, qmpncds, bfroq, khsdxn
alzvh (2766) -> gtpyffj, fzgto, uewchd
bwaye (245) -> rveuz, rcumpgx
wfdkce (50)
xmbujw (94) -> jguufio, shyxzeh, pjxauhw, ytirlv
jrkbay (75)
knrtys (63)
ubjuhxp (51)
urbkrn (416) -> seblnmz, kgfhvte
urfhlf (9)
wyohotq (145) -> vlbsr, oqdukh, ssyfvrj
lurhq (1328) -> cibzqvo, sycbr, ruabtb
aqaems (26)
ysakcag (82)
hydeeqe (97) -> jutgp, wxudgdd, bqtxl
ecanv (17) -> dxloi, whaax
bmyahis (55) -> qpxgye, ajkztpj, ywkpvle
qlxgnl (7)
tdwxgv (22)
qdyzunw (182) -> stbgj, loljfo
ftxif (57)
xminmbj (69)
cvwsj (86) -> stdfrj, fvjcbib, ixroc, ksqrqx
vfxqcbq (84) -> vlgiuef, dojviv
cpmpyvq (19)
frikrv (36) -> yngqiv, wsoahhs, pncxkcd, gpqhjv, zlpxr, fdumfc, kwavcf
ikqijv (429) -> jcqhl, nwxyrtn, vjxldb, mmtzk, gnffg
wuipwl (18)
latmzh (92)
uyrxc (60)
pyoma (1498) -> oicysoz, qsbcfm, eepdcje, fhdqcbx, zzcagx, dvipr
sttus (85)
essvr (61)
pibqmuz (19) -> kgvbcq, wuegrv
xfurlrr (14)
cmgvs (77)
qkluh (73) -> weunegg, ziiijv
nqylf (225) -> bvenb, njozyy, amxjb, stujlz
hfymm (14) -> uakcbox, kbmse, qvyrm
mernsee (51)
nnyago (76) -> mxvaxl, uwrfay
brlzr (15)
jpwwg (65)
muopf (40)
oxzmr (360) -> ydowp, nnnkplx, grlofut
xpvukx (86)
erbssqe (66)
irhslmm (33)
yiteow (83)
kthnd (77) -> zbmwego, pvliyn, svsjobu, bzfew
uzzeydh (53)
stdfrj (98)
fblafmm (11)
qpjzx (27)
gjqwe (313)
uizop (48)
tzvld (393)
iqler (88) -> vnelda, ujpgmwm
xljycl (41)
rdomgf (10) -> sggimr, jegoty, owcwvug, tcqnso
fnzskbi (42)
vkleczw (93) -> uxzwwe, cupeghk
tdhxy (95)
iiiof (38)
qvyrm (68)
eogzpga (44)
naxce (126) -> inija, cvvegrx
hxfvc (18) -> lqbnqnl, qguphyk
vwosnfn (293) -> umnkslz, rlgbvvj
khuess (49)
akdffhk (78)
kriwb (19) -> ziayhmx, zouujb, kcqgcgl
bmqhrtg (11)
dbuqsj (92)
aftzw (81)
nrvsqf (5)
emhxtcg (534) -> uktpcar, yjoyyvl, blwhz, bvbtxh, jkoyyzg, cdnwq
kcqgcgl (52)
fzgto (67) -> qcntm, tzvld, yohxzv, ttmnf, hbtur
ymxwlpc (92) -> ngjngv, jcdmhvd, nqylf, ecytwe, iciuuh
alkizae (61)
emkzxk (257) -> krfqcf, sybpjci
sejkvk (203) -> kojry, tdwxgv
yunpioi (33)
qmnji (89)
dpyxxkv (162) -> dtkdwp, rehst
vsfgg (12529) -> mtrde, xpzpv, etwpt, dvncmy
ttmnf (239) -> qrzjlw, gwudp
qdkrr (10)
okpdcz (51)
zsigmj (69) -> eazvkxv, ticdma
oaopxo (2220) -> jeopf, wphtnvm
uxnwtp (82)
kodrhj (90)
tflwng (93)
jzpdbe (29)
spgwj (172)
wmukud (34)
geztlsi (92)
kpqwup (95)
jcbgta (23)
ksfss (18)
zuquy (75)
qozmho (146) -> btrepl, gljkci, parvx, onwgja
vlsjsgg (80)
bdwbjzh (38)
lvdff (191) -> wqokqz, zyaab
mvgmbru (98)
krolgpf (27)
ixreefh (108) -> auqyep, jgnklq
ivlac (48)
nhteaei (70)
pwhmf (204) -> iujytuv, iieico
dpoat (79)
ubvheu (72)
ygiyze (75)
atqewc (16)
sawpop (92) -> piyqfs, wfamtnm
uwylbft (93)
yqnso (27)
ccjtpv (158) -> oipqc, vxlypal
hkweu (66)
gfasdd (11)
jsuak (24)
vugavk (38)
duzgl (7)
odxyfb (686) -> biglt, irjov, pibqmuz
umxurvd (54)
qgcvk (881) -> oizmgt, apqby, ecanv
jphmpr (91)
cvrqij (84)
blwhz (23) -> cihzh, sttus
guiej (70)
wjaocmd (82)
ruvfo (50) -> dlhyzjw, skdylgb
ksqrqx (98)
pwhplm (61)
nfhaii (6)
wfamtnm (58)
qbzeji (317)
okxucaz (54)
nzvpgv (290) -> kwmao, ofgeu
jlwzgg (61)
bsqilyq (82)
gosgwz (95)
syxkp (79)
epydl (42)
fhhrji (186) -> faudqy, bxcdldt
evkrnfo (38)
mulybo (75)
xvdkt (44)
qdpnnex (120) -> nwyulno, uxbjym
nnxqmb (297)
urqox (57)
dphmg (6)
wymlvix (64)
yfnlhlh (57)
oykqvif (52)
wexhnbh (196)
gzctkm (40)
vcwezm (82)
vjxldb (169)
ufrrrzi (31)
gatjls (152) -> gkxebo, xmogef
zujrs (72)
qidmgsc (301) -> hpgwq, szvty
oboju (147) -> cprbzvp, xbytmo
wdcltyl (32)
xsmcfs (95)
mnfep (63)
ajxsrs (296) -> vwslb, wmukud
vksnzty (97)
ccnpjdf (9)
cciwr (22)
inknun (149) -> mfutay, nzdbs
ckzuyha (85)
nkdxy (225) -> ccqldu, fkrog
sfohocq (13) -> fkjof, gcrbrn
aefqoq (84)
pknqf (246)
xujmi (68)
olofh (164) -> uqtiwgu, xsmcfs
fqaefy (62)
thneux (88) -> choeijs, lodcj
swujbg (36)
zfmas (70)
dojviv (72)
stujlz (6)
shyxzeh (61)
bzublv (64)
jubtls (68)
aideelj (53)
jieijuo (9)
iqpcu (94)
xiwnu (12)
grrxl (84)
sftqzaf (43) -> qybit, dpoat
bqoptf (74)
alaug (75)
sawkpue (271) -> modms, ssrqm, ndgzf, sqvxf
bnjwfrz (63)
xklrgp (149) -> yfrmup, nfhaii, uspmxw
jbarvch (275) -> qtqcv, prvldv
pmgngjy (74)
qitnlrh (70)
sbfiv (44)
bijprk (8)
sktewq (253) -> fxfznc, venvbai, rxgry
gcdzhfy (70)
zyzet (19)
zffpxgw (217) -> hpcmne, ajiubh
ajiubh (37)
ywmif (47)
egzpjym (202) -> hasyyr, vgjgz
jopcvyb (448) -> tgwgno, uyhlbf, rdomgf, yrozpm, qnscqms, ubhlb
jkoyyzg (79) -> urqox, yfnlhlh
auciw (18)
prlhyb (7)
jtqijee (171) -> auciw, awqgdfk, uceyfx, awjwff
dxloi (90)
gxpuofv (65) -> cxptwu, zrwnma, mxgyt
moiqr (95)
rfkcylj (16) -> ckypedd, xjufehm, nbkzvz
rkwkwd (97) -> dfzwcc, pmgngjy, ejnqcb
fkjlcz (177) -> mjrog, qmnji
cider (27)
cfiyqh (6)
ywkpvle (93)
nbkzvz (61)
ndszsz (71)
kwzgwt (83)
rgxwwc (27)
prvldv (6)
iotkxfd (8)
mfutay (50)
vgkltqq (16) -> wzxyc, uodhr, xsjbc
dehjjod (82)
yyyub (74)
dfwpczh (16) -> bkjppqe, yuhmnjs
zejjjo (109) -> aoipta, bbbms
zrwnma (51)
bwiqe (98) -> dtburx, bpgdb, fhhrji, hfymm, tgqwgb, gxpuofv
ktcdxoo (973) -> efobdsd, jtmps, zmjqiv
tvinpl (220) -> iglmzsi, zujrs
dkkkntv (78)
qwlze (163) -> nvtyg, hzywspw
bzbvwgh (7) -> kbwpk, czuwoe, tpekc, qidmgsc, hagrq
brghw (48)
kojry (22)
cstmu (8193) -> mkrjamh, vycgaoz, ruvfo, sawpop
kjmse (87)
umutl (36) -> grtrt, tjaqrw
olrdlw (67) -> fxqng, irvolb
emrbwzz (7)
iyxsjhc (80)
ueasp (94)
jdhewio (390) -> qpden, olspso
szszezd (909) -> tvcxl, mdnqs, waxkga, gyjvtjm, ytbyct
egdrn (74) -> fdzqz, urkya, nhteaei, xjypx
eoaoxqm (753) -> khzbxke, pwhmf, kapxuq
uyhlbf (350)
qkmkwgl (68) -> tyywgp, xjhvuc
hbwec (56)
mfbnys (40)
jegoty (85)
ukaflr (99)
fmwvok (1044) -> cksiby, uravet, wexhnbh, nnyago, thneux
rjayavy (7)
xybiuiq (53) -> egrimlf, cdvhmy, hqwkq, wfwbq
xlanm (10383) -> bwmrksn, fimqsn, naxce, zjtjt
tumwln (348) -> qgvqg, sawkpue, tcvgl, zqnjd
onamlmy (195) -> kzxyyd, yiqnfd
gljkci (15)
vjevs (35)
vuzxr (82)
ccuehkp (93)
jtmps (56) -> wixoky, vmsmdqx, lxbsif
xvwio (72)
thzqscd (40)
yuiicxp (56)
xrkqv (137) -> xgihtsx, iunkpe
yacmhtk (19)
mcjlm (575) -> qkluh, bsfgu, ndhitxf, jtqijee, ifgfg, wvhvw
bmfhjo (170) -> bznst, xcgwl
wrwgm (11)
kwxpnrs (132) -> rmnkgss, cciwr
mmndzs (75)
dkjlges (80)
mpnnffx (142) -> wayftw, epaaasn
xsfefyb (674) -> xybiuiq, jnzqvia, eywfmfs
zukio (75)
npjcdl (68)
mikast (17)
rbauxvx (6)
ipxns (75)
frezf (95)
rxflxr (82)
ejzsbli (237) -> djsss, rkhyewd
ullvx (79)
cxetjr (1657) -> fujwb, nnxqmb, kthnd
vmpmig (15)
kgqgct (13)
fupwuk (49)
mctsts (17)
pozpmyh (19)
dfrcge (27)
ywhjz (482) -> exesam, odbyxq, xghhu, xmbujw
ytirlv (61)
eajmafa (81)
dxavw (16)
rswqvx (249)
pwfdn (40)
cayigxg (24)
doppnr (201)
rehst (42)
rxezd (318) -> sohuv, ksfss
hfhswyd (85) -> tqyldbt, tridq
aoipta (56)
tpmhs (61)
zkvopb (23) -> nxqzuy, jpwwg
aceqrlu (81)
utispep (65)
zmtfcll (70)
sfruur (62) -> twbxgv, evows, xwwzp, vsfgg, zsasjr
utsfqn (41)
tdknh (69)
fwocscd (158) -> krolgpf, gbmfzzu
zouujb (52)
mvdzfo (47)
wfjks (83) -> ekleund, kikntw, jubtls, npjcdl
bvbtxh (136) -> zyzet, pflvdx, ontrln
obzomb (23) -> ullvx, acfmyv, mzywzs
khupkt (63041) -> alzvh, sjhwgq, lyxzfqz
zhrsp (52)
vxruziw (439) -> tpvzavf, xrkqv, qvndh, xklrgp, cwixiq
svcafxb (423) -> jbarvch, mawwtx, stkcndh
dhejgd (82) -> tzhoqw, cvrqij, xokmont
erfldtn (82)
predg (84)
waxkga (169) -> rgxwwc, yriibfp
kvpsfgk (17)
tlmxygb (70) -> rvyqbq, olofh, egdrn, pkudedc, rxezd, csnhv, jrgougl
nzhnurq (114) -> zwxwfin, lwvcp
fzvdchs (59)
rsqihar (23)
vtvsd (114) -> cnsbonb, ajhizdz
zykcrir (60)
ockzlpp (43) -> chxsxbr, vbvug
fdumfc (134) -> lninq, ykowao
nqjuj (19)
akzcjd (63)
qhrxvzj (52)
kpdmptf (48)
gtpew (23) -> iyxsjhc, fwvvidu, mdshsxt, yzvqo
stkcndh (183) -> cohps, legrbb
nbrfpbr (872) -> iedrlkp, rtyegs, hxfvc
nxqzuy (65)
ojrjqv (85)
egcjfjo (41)
mlfxnna (51)
nhbbd (62)
ykxnd (88)
bwfqr (89)
wuvmf (5)
kmbrqv (13)
uwrhuw (88)
oaqvt (50)
wqzic (42)
yxsaf (80)
cvvegrx (25)
faudqy (16)
qeiijk (188) -> jiaho, qlxgnl
moqped (94)
zmjqiv (94) -> jwjrj, bwfqr
jdxfsa (1869) -> lugwl, ckcjr, umutl
wsmmlrl (70)
hjtkb (9)
wdjcb (16)
jlgnsu (65) -> wxvuup, ilvblzm, ckzuyha, cbbtbz
pjsbxvk (770) -> dfwpczh, gsmocx, fwocscd
iiwwr (284) -> hmnvh, vksnzty
sysvory (145) -> udpcyt, yrdhq, ealyedu, kmufvuk
wvdoa (95)
dcqinx (36)
rugnh (52)
uspmxw (6)
ajhizdz (64)
onkhx (65)
gbmfzzu (27)
zjtjt (14) -> xqshwdz, khjag
pzlhzky (48)
vonesxw (19)
aiwvi (242) -> walkm, ixreefh, gatjls, spgwj, kjdjdr, ybnehoi
pflvdx (19)
rvyqbq (214) -> bxqjg, sxzpils
bdmah (57)
tgqwgb (78) -> zxrmy, qvmbysw
dbnoug (31) -> xnvdqbe, mtowovz, bzbncmc
hclea (96)
sggimr (85)
weithhz (56)
mzywzs (79)
vfykuuv (87)
zwxxii (91)
etlce (14)
ixomyeb (24)
xqshwdz (81)
exesam (300) -> fhjzpjw, qxjknv
djimr (1615) -> ltgnnr, kjmse
cadasac (35)
pyvwl (78)
hdikur (11)
bkfav (57)
nrduy (96)
uqpprye (82)
kmrmxw (29)
xjhvuc (57)
aflcmu (407) -> ezycquw, kaecmob
utamsb (75) -> llrrzrn, erbssqe
bavaf (18)
umhjck (87) -> zepjndx, bdmah
ngjngv (123) -> jqnnot, bnjwfrz
kcjwb (61)
cibzqvo (178) -> dfrcge, uuixxr
gjgwki (78)
rgelh (66) -> tmigcw, jmzvi, tjslk, blpjnzf, qzobjfo, rcmyfr, bwaye
uceyfx (18)
epaaasn (17)
biglt (73) -> rihlj, odoxr
bsfgu (215) -> iinxvw, sgpiiir
hatmr (61)
txtdw (8)
fdaqst (25)
dxavaum (18)
ticdma (66)
plkmpm (78) -> bieok, grrxl
ywzai (152) -> khuess, vbauj
mdshsxt (80)
weguko (91) -> iuwwa, epydl
kaecmob (10)
psmztc (11)
qzayss (31)
tbdhh (104) -> sfwaimh, orihc, jsuak
wxvuup (85)
mhpxyvm (734) -> xdkya, zsigmj, umhjck
oqqme (17)
judfhye (25) -> brlzr, dxffr
qsbcfm (37) -> fqayb, xminmbj
bvknwgq (61)
hwuwj (62)
zgoinf (345) -> xljycl, ghfcfj
vbvxs (31) -> akzcjd, vnynj, eanoucd, txxfz
mqlgoq (86)
csmul (75) -> wfdkce, oaqvt
fzzlnwi (63) -> vgkltqq, vbvxs, lfwru
ywegjjk (6058) -> rgelh, sfizdf, mcjlm, ztjquwi
gyjvtjm (179) -> paynlu, nfklqi
ecfrqpl (133) -> okniwp, njqemt
xcgwl (20)
nsxrvpg (313) -> nqtowev, fblafmm
iwiaa (188) -> ztfhz, txtdw, jpnhog
nxpozme (16)
dxpxept (36)
tbaai (25) -> vrqbi, jjdmu
imxro (58)
onwgja (15)
gnqwwbt (75)
nbjpcc (88)
ontrln (19)
jxpixqi (14)
llrrzrn (66)
hdmcpq (131) -> qitnlrh, wsmmlrl
vlgiuef (72)
bieok (84)
hpcmne (37)
qxjknv (19)
qguphyk (91)
aukjf (179) -> okxucaz, otbxl
vggstn (23)
vlmzodk (66)
bqtxl (84)
vilskw (181) -> vahnoue, wqzic
wzxyc (89)
upsmxqn (470) -> bmyahis, xanbjlw, twazofk
fwohcn (30)
zknpmnc (53)
afelswv (52)
kapxuq (82) -> wzybp, tdstv
awgjkiv (71)
vaeeqvi (17)
ydqgvnf (110) -> flejt, dxpxept
cdcvlb (27)
uqtiwgu (95)
jaerxmv (38)
mxtxm (90) -> tdknh, pjbwq
wvtac (60)
ziprwty (71) -> pshwly, jwojmds, tgsicj
rhjxbx (9) -> mhdkdt, kwzgwt
pqlwekx (87)
rpxmv (35)
yenln (12) -> wklmops, ulehitr, dbnoug, wyohotq, gjqwe
skdylgb (79)
brnhg (94)
qhldpg (74)
srsenpj (84)
whaax (90)
etjste (205)
ntcddy (8) -> qekpce, gjgwki, dkkkntv
ljfvbjd (57)
irjov (61) -> bzdgxs, zkbeehu
bvenb (6)
tlkhxww (91)
icnav (41)
myckhlw (64)
iglmzsi (72)
oztasey (158) -> dxddn, foibc
oakbrw (11)
hawtu (54)
zkbeehu (78)
hzzxjxa (47)
felrwte (64)
ogyiesm (5127) -> eoaoxqm, lptmne, titze
ojqqw (52) -> yxsaf, zfshwt
odbyxq (338)
gkxebo (10)
bvcghhs (29)
mvamo (49)
wemjk (64)
olspso (7)
uasqon (97)
liwlcz (728) -> fhvyhk, qqnywdg, ajxsrs, utojr, tvinpl
rkhyewd (49)
wuckr (40)
hzywspw (31)
ofgeu (22)
hcyjfzz (92)
ieebfpb (71)
aclihvm (8)
xyoiv (17)
okniwp (30)
jfchk (1360) -> hbwec, weithhz
kwmao (22)
piqids (229) -> fbusld, xifaq, vkwsodp
ryctwjl (19)
sybpjci (24)
klnxfd (1174) -> zoryb, wcpyi, etjste
mjrog (89)
zyaab (50)
xanbjlw (258) -> uuapl, sckgsn
xdkya (143) -> bvcghhs, jzpdbe
dznlyl (74)
lcgtwj (160) -> pxsokyl, chhhge
cvprip (282) -> qkpaxtt, bmfhjo, tqimh
paynlu (22)
ixnlvyo (75)
qjnhwpq (56)
qnsqwm (106) -> brnhg, trcyfi
jeopf (72)
vnelda (50)
nwyulno (87)
njozyy (6)
yjrar (13) -> jppsaym, agfnncm
gyzorus (49)
pjbwq (69)
hechfb (31) -> aflcmu, sjdpe, ofdehn, zgoinf, umnqkb
jrgougl (54) -> jrkbay, elpwvoy, gnqwwbt, ipxns
wsoahhs (188) -> zouxmz, brghw
rhlepi (85)
qopkhc (69) -> cvrga, ujtej, gybikf, dkoike, guhjkd
lvcdsgp (178) -> afelswv, ovhhkoc, rugnh
dhsopiv (88)
jwojmds (59)
auqyep (32)
jkodco (46) -> adunt, ztook
pxsokyl (34)
ieohkpr (10)
velhob (109) -> gyzorus, kfngejn
cfrcco (217) -> zhhhntj, jcvimc
xlvjz (26)
tnhet (78) -> onoyb, laohhtn, mqlgoq
ejovcx (82)
yaehsu (75)
kqueox (7)
evows (4599) -> xsfwcgq, txszqu, uypxc, aulgwyb, qshoazt, dyfnpt, rkofvt
dtburx (130) -> frycrnj, vqrtnp
qtqcv (6)
mgyixhn (32) -> msskm, iqtemv
bckbud (249) -> iqjbdok, mjtuzfr, zejjjo
njmlk (65)
ebwgi (19)
lsaroxx (63)
xjufehm (61)
htbmh (29)
molth (16)
lninq (75)
lwqlyjq (309) -> qongfb, pzlhzky
yqlxeb (79) -> ymxwlpc, cavlg, odxyfb, xsfefyb, mhpxyvm, htujh, xfglmz
vagjk (98)
ssrqm (37)
damyp (46)
svsjobu (55)
djsss (49)
udnmqte (36)
lzeihwp (83)
oplzouv (74) -> fqfnocq, ntftmt, piqids, dbpkf, gtpew
puvhc (137) -> bsfsayz, ssxuat, brlbdjx
nxmksiq (40)
amxjb (6)
gnffg (119) -> vjzfc, ijyhvsj
inlcow (271)
tfqxv (1437) -> zmtfcll, gcdzhfy
lnontej (19) -> bpelccj, utyrttu, gqlyhql, fvwll, ejzsbli, nsxrvpg, ofyuao
gjwzw (207) -> egzpjym, ywzai, bfulyh, zxavxe
oactn (57)
bwugxhi (56) -> vbzwk, krrvyl, ivlac, mzrwaa
legrbb (52)
vetsll (41)
iujytuv (12)
qkapxbc (18)
kgfhvte (31)
uypxc (82) -> bpzjm, dkcqdx, msryw, aqlqmq, yxpnzkn, obzomb, bzbfpkb
gslii (62)
fyeuhqh (13)
wxbao (84)
nfkmi (894) -> drzge, bgpjb, jkodco, kxkwxoj, crothf
fqfnocq (305) -> yacmhtk, vonesxw
ykowao (75)
jxsmuey (82)
cejnfcx (89) -> rhlepi, rgkrl, gjgcvyp, lkfdr
wattsr (23)
bzfew (55)
guhjkd (162) -> cdcvlb, cider, qpjzx
ayhdd (184) -> laeaf, udiio, bgqvm, ofwtjhw
onaatvy (51) -> aftzw, ekxczvo, wkfjzs
uodhr (89)
cnblx (498) -> vkleczw, pablb, objssr, pzjvq
bdjlzf (52)
tynxlau (32867) -> ywegjjk, bavyg, qdpoyl, wngzh
soryrk (69) -> fnzskbi, oovqoi
nrlhen (153) -> wattsr, eqbwx
kgvbcq (99)
zsasjr (77) -> jopcvyb, pyoma, jdxfsa, liwlcz, cxetjr, vifbi, tlmxygb
orihc (24)
titze (609) -> czmzol, velhob, truximz, utamsb
igbhyk (44)
jgnklq (32)
bjcsjrr (138) -> bpemyk, nqjuj
ismrc (90) -> cjeauo, uasqon, prxmxv
fbusld (38)
kikntw (68)
cksiby (128) -> zzbzwdm, zdawjkr
rgkapf (77) -> dkjlges, ckombz, vpnjbha
oovqoi (42)
ujtej (57) -> ccuehkp, tflwng
yanvh (44)
mawwtx (29) -> bvrpb, xpvukx, jhbqc
jinwsas (235) -> gzctkm, nxmksiq, fhyvz
gapzarg (79)
sjdpe (263) -> erfldtn, vuzxr
vnynj (63)
jqnnot (63)
rxlbou (57)
xewbn (7)
tiwkyz (117) -> lewbxa, btnnorn
kbwpk (307) -> ffhxi, polumk
gkqgru (14) -> pqlwekx, ysdqkw
baaqr (94) -> btnyx, fdszkhp
jmzvi (89) -> rzwjli, uizop, necqpdx, debir
mtowovz (94)
wklmops (201) -> mbkbmql, dlkhb
xnvdqbe (94)
ofdehn (95) -> yiteow, yblsbf, gazaoty, lzeihwp
brlbdjx (13)
xawfk (85)
krfqcf (24)
khsdxn (39)
qrlhp (61) -> moqped, ueasp
rzwjli (48)
polumk (15)
bwmrksn (14) -> bxkxp, eajmafa
vwslb (34)
qdcos (132) -> ryctwjl, sczyp, enxbya, cpmpyvq
uuixxr (27)
yqqun (62)
bpemyk (19)
trcyfi (94)
ttqpi (72) -> nfmicyi, yjnrjde
zepjndx (57)
fbyju (52)
nbrvl (89)
pshwly (59)
uskfp (84)
cdnwq (41) -> xerbuu, iiiof, jaerxmv, bdwbjzh
dntwqr (38)
welvrkn (74)
krpda (826) -> azzysl, ayhdd, tnhet
jhbqc (86)
zlazoqs (98)
seihhya (81) -> jhruwih, aefqoq
jcqhl (5) -> glxogmc, bsqilyq
hsexbak (99)
wixoky (72)
awqgdfk (18)
walkm (84) -> cxuijad, yanvh
jcezw (34) -> wxbao, predg
iqjbdok (41) -> msrrlv, kodrhj
krrvyl (48)
bkjppqe (98)
srscbv (83) -> jawbtmo, wmvniap
nuytv (94)
glxogmc (82)
iuauic (74)
jtmuv (2257) -> terkw, bzbvwgh, emhxtcg, nkbmoin
noqjuo (29)
xbytmo (28)
khjag (81)
mhdkdt (83)
elpwvoy (75)
edtkfvv (1462) -> tbdhh, mpnnffx, wdzhfmw, pkceuqw
qxyramq (7)
swaxyxe (23)
pvliyn (55)
ztook (71)
ofcyw (74)
txxfz (63)
tqimh (196) -> prlhyb, kqueox
ezycquw (10)
lyxzfqz (30) -> qgcvk, jfchk, upsmxqn, nbrfpbr, jmbueky, kqswas
poypmax (7848) -> atyaqz, vkhazkn, chljtta, anehvd, vilskw, lbnenyf
xyemll (55)
pkudedc (256) -> takxgz, fupwuk
sxvig (60)
jkvgvz (49)
ssxuat (13)
vrqbi (84)
tjslk (281)
moivx (23)
oizmgt (137) -> sakhif, fwohcn
vpnjbha (80)
izpxjp (64)
pzjvq (85) -> ieebfpb, yprusb
tycgm (7)
lrjnzf (68)
yprusb (71)
oeqqj (259) -> pwhplm, jlwzgg
libtrl (53)
ozlqcn (95)
jmbueky (38) -> iiwwr, cvwsj, yvwecfs
eywfmfs (73) -> mfamq, bqoptf
udiio (38)
plsep (96)
ghsxqq (46) -> srsenpj, uskfp
qnevjto (283) -> dcqinx, uctlk
lwvcp (50)
chxsxbr (6)
hfxsib (247)
fdszkhp (77)
tkvmtol (117) -> vfkjif, oinyx
xycva (275) -> aclihvm, yaripcu
mtrde (1154) -> gsfnr, plsep
jcvimc (51)
vqvwkm (92)
asrwh (69)
hykxm (1428) -> dpyxxkv, plkmpm, pknqf
twbxgv (13182) -> yenln, qrgqcd, tfqxv
ziayhmx (52)
oipqc (9)
cjhtxo (137) -> gfasdd, psmztc, rdvtzr
iqymm (69)
ehvxt (17)
bzbncmc (94)
irvolb (90)
cxuijad (44)
bgavnd (94)
dhuof (39) -> ysakcag, dehjjod
wkcrce (182) -> ndvdj, ieohkpr
qvmbysw (70)
prxmxv (97)
evbvdgl (158) -> titbn, ebnqn
glqspl (27)
azkmt (35)
eanoucd (63)
rydrp (156) -> mbniyi, emrbwzz
vffqp (70)
tpvzavf (117) -> fdaqst, qlkjhsi
ajkztpj (93)
krbpgmk (4302) -> svcafxb, vfxzkq, vxwobup, qopkhc
mgqkhic (49)
bpzjm (142) -> loxjzpo, fzvdchs
ntftmt (195) -> welvrkn, htouwcr
etwpt (59) -> cejnfcx, oxzmr, sysvory
owaebx (27)
ctzhawr (74)
btnnorn (43)
vbmqrqx (13)
csnhv (248) -> smsoi, lkwogh
lisfhnn (91) -> zykcrir, sxvig, wvtac
drzge (162) -> vbmqrqx, wgcgdvt
ibyrsdo (25)
kkmidak (15)
sddvn (70)
gsmcgor (79) -> rffwau, qqmlvk
rsjffj (80) -> klnxfd, oplzouv, djimr, ktcdxoo, aqugisv
dyfnpt (468) -> xwwfi, urbkrn, kryczad
exqkey (66)
ydowp (23)
truximz (91) -> imxro, izyxppl
qrgqcd (309) -> rgkapf, tzszs, qbzeji, nkdxy
btnyx (77)
qsyocuq (346) -> qilhudr, aukjf, offkzc
wmvniap (46)
eusnn (66)
terkw (474) -> yjrar, hipfszh, oboju, tiwkyz, vtwdqkd, dhuof
aqlqmq (230) -> zhlfdac, kkmidak
ziqyhi (11)
piyqfs (58)
kryczad (478)
paoitb (51)
tpekc (271) -> irhslmm, yunpioi
qrzjlw (77)
aslvy (29)
yvwecfs (478)
paqihg (35)
itjxq (46)
ibdjxl (262) -> kmrmxw, htbmh, aslvy
cxptwu (51)
ghfcfj (41)
yohxzv (359) -> kvpsfgk, mctsts
kmufvuk (71)
mbniyi (7)
rxgry (32)
stnnf (88) -> jytapdu, kkeuh, xycva, zffpxgw, cvlkltp, lvdff
ychjmik (40)
bzdgxs (78)
cyczt (95)
luhxcq (68)
iedrlkp (176) -> xiwnu, gezqw
vgqmfj (85) -> idwpug, hawtu
tdstv (73)
mbkbmql (56)
dbpkf (169) -> zzcqptv, vfykuuv
wqokqz (50)
xufneyr (153)";

    public override Task ExecuteAsync()
    {
        IDictionary<string, Program> programs = new Dictionary<string, Program>();
        foreach (var line in Input.Split(Environment.NewLine))
        {
            var words = line.Split(' ');
            Program program = programs.ContainsKey(words[0]) ? programs[words[0]] : new Program();
            program.Name = words[0];
            program.Weight = int.Parse(words[1].Replace("(", "").Replace(")", ""));
            if (words.Length > 2)
            {
                for (int i = 3; i < words.Length; i++)
                {
                    var name = words[i].Replace(",", "");
                    var heldProgram = programs.ContainsKey(name) ? programs[name] : new Program();
                    heldProgram.HeldBy = program;
                    program.Holding.Add(heldProgram);
                    programs[name] = heldProgram;
                }
            }

            programs[program.Name] = program;
        }

        var p = programs.Values.First();
        while (p.HeldBy != null)
        {
            p = p.HeldBy;
        }

        int diff = 0;
        while (p.Holding.Any())
        {
            var counter = new Counter<int>();
            foreach (var program in p.Holding)
            {
                counter[program.TotalWeight()]++;
            }

            if (counter.Keys.Count() == 1)
            {
                Result = (p.Weight - diff).ToString();
                return Task.CompletedTask;
            }
            else
            {
                var wrongWeight = counter.Keys.Single(w => counter[w] == 1);
                p = p.Holding.Single(p => p.TotalWeight() == wrongWeight);
                diff = wrongWeight - counter.Keys.Single(w => w != wrongWeight);
            }
        }

        Result = p.Name;
        return Task.CompletedTask;
    }

    public override int Nummer => 201707;

    private class Program
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public IList<Program> Holding { get; set; } = new List<Program>();
        public Program HeldBy { get; set; }
        public int TotalWeight()
        {
            return Weight + Holding.Sum(h => h.TotalWeight());
        }
    }
}