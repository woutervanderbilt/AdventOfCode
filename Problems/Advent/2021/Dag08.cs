﻿using Algorithms.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2021;

internal class Dag08 : Problem
{
    private const string input = @"cg fadegbc ecfadb acdbeg abgfe dcegfb gcad bceag debca bgc | ceafbd gfedcb cabedf dbace
bgeacd ea dfcab fcdgbae ecbgf gbcadf defa cae dcaefb fabce | ea fdae daecgb cea
fb gafbec dcabe ecfdag fagdcb afcdb cbf gdfb agfdc acfgdbe | acdgfb gdcfa bceda bf
fd bcafe afed acbfde fcbde fcbgae fgabdc edbgfca cgebd dfb | dbf becgd bfd efcdb
deacg egfdbac agefd gbedc gebfca ac gadefb ace fadc fcdgae | gabfde cbdgfae ca eca
cfaedb gedfa fbegd dgca ga dfcae agf dfagceb gdfcae ecbgaf | gaecfb cdag gfa gaf
ceg gfdcab dfacge edgf fecagb ecdba ge gceda fcbaged cgdaf | gdaecf gceda fbacge dcagf
caged egbdf edabfg fbad fagde gefbcd fceabg afg fa cfdagbe | bfdge degca fbda af
dac egdacf fcedbg dabcg gdfcb dbaeg ac cfdaebg cafb afdbcg | decagf ebdag bfdgce fdbgec
dbaec edfac bdgae dbcegaf bc cba aecdbf cebf gbacfd facdge | efbc cab ecabfdg cab
gfce acf fecda egfda gbcfda fc gcefda dbcea afdbge dbceagf | bfedgac bfegda fcgdab fecg
edfgb ebf be gdcafe degaf agfbced deba bdafge dgcbf cbeagf | efb dbcgf dgabef be
ebgfd bfcg gf fcgbde dfbagec gefcda fadbce gef febdc edbga | gf dgbefc gfe bedfac
gabfec dcfage febg gcaeb gcf agbcf gf cbafd cabged cebfagd | egbf fg gcdbea dfbac
fgcedb fagbe aecgbd gbcaf bef fade fagdecb aebdg ef feadbg | abdge abfdge abcgf gabedc
dgebfc cebfa dbf acfbdg edbafgc dgfe decbf cdgeb eadbgc df | bgdcefa caebf fbd adfbgc
febgd fgaced bfedacg bfdgae fdcgbe fabed fcbea gdba ad dae | dae agbd gbfdea aegcfd
abdgf adcf bfdeg fa gfecdba fab debcag bcgda bcafdg fecgba | edbfg gcfdeab bgfda dfebg
ecdba bc dcfeba eacgdf cbegfad dbcf begda fcdae cebgaf cab | abc bc ecfdab cab
bc fabcged bcafg debfcg gdfac fgbea acfged bcg cdba dgfabc | baefg fbcag begcfad dabc
egfadb ce fgce bagdc gdafce edabcf gefad febdgca aec aedcg | aefbdg ec ceadg gecad
daegf gebf acdbf be faedbg dbe eabdf fdabgec aebdgc cdefag | be gfdeac bdfac gdbace
bafgc efac gae ecgdba ebgfa ea degbf afebcg fbacdg afedgbc | acfe age dbfecag bafgc
gfb bgacfd efcbd bdfeac bg efgcb gcbfed gcafe begd bfdgaec | cbgef gcfea fbcdae faedgbc
efdbc abd afcbegd dfcba fbedga ceafgd cgab ba agdcbf cdfga | dcafg cabdf ab bcga
fde fgadc fgceb eadcbfg gebd agfcbe ed fgbdce cbeadf egfdc | bdgcfae fde edgb gbde
abdcg gaebfc cfadebg cdfbg cegbf ebcgdf dbf fd cdfe fedagb | dgbca cgfeadb gdfaeb beagdf
fedbc gdeacfb cfbgae ebacdg gafc ca bgdfae geabf eafcb acb | bafge aefcgb cfbae defbc
fdega cefabd fce bfdegac afecbg fecad cfadb debc ec dfagcb | dcbaf gebfcda fce fegad
fab gaedb cagbdf fbce fecgad dcfeba dacfe fb fbgaecd faedb | dbecfa gefcdab bfa efbad
bcega gbacfe aecgdbf gae cabgd ebafc edgcfa ge facebd gefb | baecf efacdb ebagdcf fgeb
fgea acf af edbgca defbc fegbacd bagcfe ecbaf gdcabf gaceb | aebfc abgfec aegf dcfgab
ecfgb cfd dbcgefa fcdbe debaf cdgefa cd cfgdbe acfgbe bcdg | bcgd fdbea dcfgbe fcd
gdfaec fdcabe eb acbgd cbe bfae facbdeg cebda bgfced cfade | be dface eabf cbeda
efbagd ebf fdceba gfdae dfgabec dbgef bf fabg gbcde dgecaf | dgbef gfdeba afgdeb gdefb
gcadbef fgadc cbd cb bcgf bcfad dgfcba edafb gfdeca ebdgac | bc fdgcae ecadgf bdcega
defbg dgbaec gbe eg dabfg fgdaeb badfgc cadgbfe egaf debfc | gbfde fgebd gedbf egfa
caf gcdabe bfag fa edfbgac becafd cbega edcgf afceg faecbg | bafg abgfec ecfbda fbag
egfcba dafgcbe cefga cdbgae acfgde bgcfe ebfdc bg fagb bcg | fcebg dfegabc dgecba defacg
bgcdefa bcfged bf cadbgf edbcf fdb cebgd dfcea gbef gedbac | bf dfecb fb dgceb
bdegc decabgf agbfce bdcfg eagd gebadc dfeacb deb ed ebgca | dgcabe de dgabec bed
eabdf gedbaf afcbedg afcdg bgd gbae gadfb cefdbg bfdcea bg | acdgf dbafg geba gbd
egabdfc dg efdcab bdcef dgecf cfgea dfg cfedbg bagdfc gbde | fadbgc gcfea ebdg gd
fcge cf ecbfad acfedgb agdef fcgda aefbdg afc cagdb cdafeg | cfa gcadf dagfce acf
cbadge gdec efagb ce ecb bagecfd gbcad gabec dfacbe cgbfad | acfgdb gcdba cegbad fecdabg
cegbaf aedcg acgbed fadbe afbcdge gf fge gdeaf dcgf cegdaf | ebadf fagde cdgf baedf
ebdgf dcgbfe cfdabe afdg agbefd ad daebg cbadefg ceabg ade | bagce bfged cbfged gedab
adbf decbgf dbc agcdbf cdeabgf dcagb eacgbf abfgc cgaed bd | cbd dbcgfe abdcg cdaeg
bgcaf fgbae edbcgfa cdfba cbdagf cg cga fgdc edacgb bfcdae | dfabce bdaefc dbfca dgceab
gbe gedc fdgcab bdgaefc eg cageb ebgadf acbfe beagdc dgacb | gedc gbe bcgea gadcbf
dcega abgecf cgeab ab gfedbc adfbgc bcgef bafe dcafebg abc | gabdcf acb ab ab
dfgebc cdgef bc efagb bfceg fgedac cbf gcdb egbacfd cfdaeb | dbaefc agdefc ecgdbaf fecdga
febacg efgba ebfdg aefcb ag gba gacfbed fagc edbafc agbedc | gab ag dgfbe ecdgab
cabf fegacd bf ecabgdf gfb bdefag cbdge dfcbg agdfc gbfcda | dgcfba gfb eadfbg fcedag
dc fcd aecgfd cgfda baefgd cead fgacbed cfbdge eadgf fgabc | fedcga eagcfd gcfda gfdea
fgbaed aebdgcf edabg fdba faecdg fgaed gcbed ab cgebfa gab | edbcg becdg ab edbga
agdcb edfbgc edbca ae aeb aefdgcb eacf facedb agbefd ebdfc | adcbegf fcea acedgbf dcgebf
ecf dgfeb egac dacfeg abcdef ec gfebdac cdgbaf cdegf fcdga | dcabfg efc ec fgdecab
dcega def cfgde aegfcb deabfcg fd defgba egbdfc bfcd cbfeg | bagdecf df fed dcbf
gecbf bcdfaeg cdfga fgdcbe gcfbae eafb fagcb bga daebcg ab | acgfd bfaegc gdafc feagcb
edfbg df dcfbae edf bcegf egfbca acgfbde aegdb dcgf efdgbc | gbcfea beadg dfe cdfbae
gdbfca acebgd cabdf gebaf becdgaf ed fedc bdefa eda ebcfda | bcfdag fcdaeb fcdab ed
eafdgc gbdc efadb cd abfceg daebc dce afegcdb gbace becgda | dgcefa dabce gceba bgefac
bdaf cbgfd fag fgabc fa fcbegd gedfac gcaeb fgdacb eafbdcg | af gebdfc bgdfc fa
bdafec fdag gbfce dgc dfgbca dacbge cfabd fgdbc dg faedgcb | gcdabe cgaefdb gd gdfcaeb
ebdcfga afedcb aegdcf fbeg cbdag fg adfgbe ebafd bdfga afg | adcgef fadcgbe gf edbfag
dgeacbf gdaf bagecd dcefa caedfg dac gcebfa fgace dfbce da | cfegda ad da abcgde
bfadecg ba gab bafecg ecab dfgca cgfba bdcfge fecgb fdabge | ba ebac aebc fabcg
eadcg efd cdbf cfdea cbedaf egdafb cfbaeg fd aebfc adecgfb | aebcf fed abedcf aedfcb
gdb cbdaf cdge cdaebg efgdba egcab gd afebcg gdbca gaedcbf | dgbca begca cbgaef gceba
bdfgac fgadb adbgc fgca cfgdbe adbfe fg dgbace bfg dgabecf | dbafe gacf gdacb fadgb
gedbfa cdg aecgd edfgca fbdcage cd fgdabc fedc dafge cgbea | gafde bgdeaf dc defga
fdceg edfcb gd febgcd dgfb gcd aefcg cafebdg bafdce debgca | gd cfedb defcg cfadegb
adbfe bgcfda gefda gcaed dagbfce dbeagc gaf gf gfdeac cgfe | gfec ebgdac eabdf gcef
fc cdf bcfdeg dfgaeb fcgdea gafc bdeca fcbedag faged dacfe | adfebg ebcda fdega agfc
deagcf ebagfd bgafdec cd cabeg bcedaf dec cfdg gadce adfeg | ebgac cagde dc faedgb
dcgab ac fabegc dcaf acg fadbcg fbgacde cfdgb cbgfde debag | dagbc daegb edbga cag
fgcead edbcg cfaed dcgef dfbgcea gf badcfg fdcbae gfd fgae | dfbagc dfcge gf dfeac
begcf cbf aebf fdgacb gdebac ceabg egabfc gdcfe ebgfacd fb | debcga bgaedc fdabcg abgce
efgbcd febdga bc fbegd befcd dgafebc ebc fgbc dgabce caefd | fbcg ecafd cdbfe cgbf
eafg badgec ecgab gdcfb fca fa cgabef fcbag fbeacd cegfbda | fa cabdge acgbfe cdbega
gdfae fdagbc fecgab eg fadec abgdef abgdcfe dbge eag fgadb | dbafcg befdag ecfdagb aebdfg
aegbcf bfgecad acgfbd dabceg aefbd gcfd bgd gcbfa dg dagfb | cdgf gd dfbga bdafe
bcgdf be gcdeb egadc bagecd ebd cabe gdcfeab badfge egcafd | agbdfe be ecab ecbgd
edbafc fbdgce befgc cge ebdgac eg bdcfe egfd caedgbf bcafg | gabfc eg ceg cdbef
cbadf af afc baef cfbdg dcegfba ebdac dabgec acbdfe afecdg | cdbaef decba bdcaf dbcae
ea eac cbgaed cdbaf adge dgfeacb bdaec ecbgfa dgbce gdbfec | cdfba bcdge ae cabgde
bgecfa abegcfd fgcad fgdcae aedc dfc fbdga cd defgcb cegaf | gbafec egdafc aced acbefg
becfdg abgcdf abgec dafceg gcdbf bfgadec af fac abdf fcgba | fac abgcf afbcdge fgdbc
cbe ec caefgdb cbgeaf ecbdag bcadfg cdae cbgad defbg egdcb | dace ecda aced ebgdf
aecfbg cegdfab fdace ecd cd gadc cgdaef efgca gdfebc badfe | cfdea cd eacfg aecgfbd
bafgdec gcd gacdf gbcaf cd cgfeab dgbeac bcfd abcgfd fdage | bfcd dc cbfd dc
gadfec gfadbce gceba abcdf gd bdeg cebgda cdg afbecg bgdac | dgbe afgdce egabcd gedb
fc defc cdeab bdcgae acebf caf cgefbad efdbca gdfacb bfgea | adfgcb cbead efbcad dcagbe
fecab adfgbe ecad ca adbfec cab cdfegba gcadbf gbfec eadfb | bgdacf dgeabf ca cgbfe
gbaefd cafged feac cegdb eafdbgc ea agfcd dgace bagdfc ead | ea gedcb ea acgde
cbaedf dfbcga cbagd cbfadeg fdbeag bgfad cdgbe ca acb gacf | fabgde fgac acb fcag
efgc fg agbdcf bdfce bacdgef dgfbe gdfceb fbg edfbac eadbg | dgfeb cadgbf egcf dcfbge
bdgea gbcf facegb acdfbeg ebgaf dabecf bf gfeac aegcfd fba | fb gabfe cbfg bgafe
fedcgab fceab cgab egbdfa cgaebf cefdag fca fcebd ac begfa | afc adgfec bfgea bgeacf
bfda gbcadef bgecd dafegb daefg aecdfg bgdfe acbfeg bf ebf | dfabge bf dbaf bcfaeg
bacdfge aegdf ebgdf fcaeg edcgfa fbecga ceda adf fabdgc ad | dbgef fagce edafcg bdgfcae
abdef gaedcf afdgeb becadgf edabc bcdeg bafcde acfb ca cda | dfgbea cda dca adc
efgd fcgbea gbadcef dcabe fe aebdfg fdabgc abfed feb agdfb | egfd fedg fdgeabc eafdb
dcabegf gedac ecgfd cea gfcebd agdbe ac gcfa fbeacd gdecaf | fegdac gedab dgaec bfdeca
bacdgf dgce ec cafdeb fcega eca cdafg ebagf degfca bdfcega | cae fgdabc decgafb cfagdb
gefac egabcfd gfc baecgd eabcgf dafec gf cbage acgfbd egbf | abcgfe bceadgf feacg egbf
gbcaf dcaefb gdec adfeg acefdbg fbdage cdfag acefdg cd dca | gecd cgbfa cafgd dc
fbadge bdcg acb caebfd bgead gbcdea caebg dbgcaef gfeca cb | acdegb gabde gbcae abc
bcd agdce edbagf gfdecb cbfa bc debafc aedfb beacdgf cbead | ebcfgad dfgceb gdaefb bfca
bag ab ebca dabecg agcde dbfagce efgcad gbcdaf egdab egfbd | gabed gaecbd ab eagfcd
gbcadf cdabg bd dbg afgbedc fdgca gacbe adcfge cfbd gedabf | gdb dfgca gfabcd dacgb
cfeabd cabgf gadfeb gbadc dcbgae dgec bdage gbfcade cd dcb | dceg bedcfa edgacb dc
bcdfg gdfeab abecdgf edg gefca ecadgf fedcg deca ed gcbefa | bdacfge fecgbda gbcafe fedcg
acbgfd bdgcf dcfga fbd dfbcgea fb dbgec eafbcd fbga efagcd | gfdca bdcfg dbf afgced
dafecb acedg bc dgafce gbeac fgceabd bce gbefa gdbc dbceag | agfcdeb fagdce afgbe dfecga
fgadce db fbadg deagcfb abd aegbf gcdbfa fgdac gbaedc bdfc | daegcf faegb bd dba
bdga fbagc ceadbf ecgdfba bfgce fga cbfagd ga cfdab gecdaf | fcdaeb ag cegabfd ga
fce fcdg adfgeb cegadf bafdce fecga fc becga dafebcg agfde | efbagcd afged fedgba efcga
cegdba fb bcdeg fecb gdeaf acgfdb fdb fgdbe cbdafeg gecbdf | afedg bf dfegb fbgecad
eg feadcb dgec egf afedc eabgfc gaedf bdgaf acdgbfe egafdc | eagfbc adecf egdc afdge
bg dagfe edfcabg dbgcae fgaedb fbag fdcage dgb bfegd cbdef | dbgef dgfbe bg efbgd
dabgfc acefbd cegad cbeda bac adbef cb bcfe fbgdea cafbegd | fadceb ebfdga ebcad bac
gfbca decbfa ecadbg cga gc cfdg bfcadg bfeadgc cfabd efgba | ebdfca cfagb degacb abdfc
gcbead fadbge befc bgfceda dbcea cbefda bfa gfacd bf facbd | abf cedba fba dgefcab
baedc feag begafc fcagdb eg bagcefd baceg gce bcgdfe cfabg | cgabf egaf ge fage
ecab ce bfcdg fabgce efdcag cgfeb gbaedf dfegbca cef baegf | cefdga gdecfab cfbgd bcaegf
beacfg fg efg ebfcd dbfgcae fbga bgcea cefgad cgbfe ceagbd | bdcafeg baecfdg fecbd gef
cebdfg ba abf bdgfaec aebcfg gfcdb dbga afdcb gcbadf fecad | gbad bgdfcae gfdcb baf
gceaf ebf eadb abdcf adfebc fdbceg cgafdb efcab cefdgab be | ebf dbfcag efb feabc
fgbcda bceag dfabge fbdceg fced bgfdc fabgdce fe gfe cgbef | abgedf cfde efgbc gfabcd
deagcf bdfacg fcbad dca gfdbc ecgbadf febcdg dbafe bcga ac | afdgcb cbga dgafce adegcfb
dbceg bcg gfbeca cgfbaed egfcbd ebgfd gcfd cg bdaegf decab | cg dgfc cbeda dfgeb
cfbed bdae dfcgb ed efbca cde fcbdae gbcfae fbdgaec aefdgc | dfgace becafg cagebf fcdebag
ed dfce dae bedca gfaedb befdac bacgd eabgcf bfcae agdfbec | bcaed edacb cdaeb ed
dagcb cbge daefbc bgadfce bc cfgad abdefg gbdea cab cabegd | badgc ebfcgda bdcfgae abcgd
ac fgdca gfbdca bcgdafe cefdg cgbeda cda gaefdb fbac dgfba | fdegba egadbf ca bfca
fedgc dbcaf ceb adefgc ebdg acgbef cbefdg be befcd dcfaegb | dfecb gbcdef eb fgceab
aefcd fcgaeb eacdgfb fbcg aebdgc gdbeaf agfbe agc cgaef cg | cga gac dabcfeg fbdgcea
af bdeag gfbdace fga bcaedg cdegf feab eafdg gfedab dagcfb | fgacdb faedg ecbdafg fcedg
dgafc adfcebg fagec dacfeg fgd fd gbdac defc fdaegb gafbce | cdagb df fcaebg dfce
bacfdg dgc cg bcaed adcgb cafdeg bgcf dgfab bgfead cbfaged | bdfega dgfeab fdgba agbdc
agfebd cb bafecg efbga edgac gfedcb cedfagb afbc gcb acgeb | bc cgb bc cbg
fgdae edfbca bgdf gceaf eabfdg aebfd gad defbgca gdceab dg | eacgf agecbd gd gcabed
befadcg gdfa afdeb aebfg fg bcfead gadfbe gfe cgeab gfbdce | adebcf dcgfbea deabf abgec
cb cbg gbaedc efbga bcafgd caefdbg efcdga eacgd bcde gbcea | edagc cebd aefbg bdce
cdaebfg edcbg cgedba acbeg fbdgc edg fagebc cdea ed abedfg | ed gcbdefa cgabdef baecgf
eafbg acebgdf dagcb eadc ecg ce cfbgda cegba dgbace bfedgc | edac ce bagcd gfeba
egafcd gdfaceb acegf cgda deg dgfbea gd cdfge feabcg cedfb | fadcegb egd caedgbf febdc
feag eg aebfc efcadb bge cdbgf fgbcead bdegac ebcfg aefbcg | ge adcegb fceagb ecfba
beac bdgea ebagdc bdgafc bcagd age bcgdeaf ae dfaecg defbg | egdacb eag dbcage ecgadbf
ca agdbec abc dbgfca gbfecd cbfgd acgf fbdae fdacb ceafbgd | dgfbca abcdf ac cfgbda
bgadf cdgbefa bagef bfe agfdce cebg ecbadf gbecaf eb egcaf | ebdcgaf cebg faegb fgbae
bfgcea fdgeca cae gbeca abcf cfebagd ca fgdbae cebgd faebg | gfeba ca fedgca gcabe
cage dfgaebc ae gfbed ebgaf decabf afbcg bfacdg aef cbaegf | debagcf bfgca agce bgeaf
bcegdf cgdafb abfd abgcfe fdg gfdac gefbcda dgeac afcgb fd | gdbcfe cafdbge gaecbf dgf
cgdbe decba bfdgcea debfa cfdbae gafedb ac fbca agfdec cea | dgecb dacbe edagfb gfdbea
gacdef bfeda afecd gfbae bdcega bafgcde dab dfceba bcfd db | db eacdgb aedbfcg fcgbdea
abdgcf dafec faedb cf bcfgeda gefbad cabfde cfbe afc aegdc | bdfega afgdecb fgdcba gedafb
aedcb fce bedfc cfbged gefb bgfeacd edgacf ef gcfdb dgfabc | gedfca fabcdg adfcge cfe
dbfagec dabec eda fdcbea ed agdbc gfbcea cbefa efdb gfdeca | ecfgdba ade fcagebd dea
dafbe adfbcg bfeac cbe bagfecd cfge egcdab cgabf ce gfceab | bcagef afgcb fcgabd gcdabf
agc ag gbaecf cagbf fgdcaeb bdgfc cefab ecfagd bega aedfcb | ebcafg fbace cag eacfdbg
ea gfbda eacd bfced eagfbc aeb cbfged befda bgafced dacfeb | gfbad aeb fdabg cedfbg
gcbadf gbead afcbde gad beadf daefgb aecgb dg efagdcb gedf | dgef fegabd afebd dg
dbc fdcge dabeg aceb cgdeb afedbg cdgeba bdagcfe bc gcdbaf | gcadbe dcb abcedg edbgc
bfcd ebfgd cgf egcab bfdcge adfgec gbefad fcbegad gfebc cf | fcdaeg dbegacf dbcf cf
bcfedga df dfa gcaedb fagcbd adecbf ecgaf dgfb gcdaf bdcag | gecaf df gfbdeca df
acf cdfe dcbegaf feabd ecbgfa dbacg aebgfd bfdeac dcfba fc | gfedba fc efdc dfbaecg
ecf bgaecd ecdgfb adgfe egcfa fcbedga bagec gacebf cafb fc | cfgaebd aecbg ecgab dgbeca
beagc aegbdc fcdeb fcgbe gf geaf acgbfd fcg fecgdba fbgeca | bgfadc baedcg gfc gebacf
gedf caebfd fcgea bdcgae age acefd fdcagbe gacfb gcefda eg | bedcaf dgeabc acgfe aeg
gceabfd cdgba cgfdae cfdagb begd ceabg ceafb ge gae gabdce | fcgaed dgfcae acegb ebgd
deg cegdbf dbceg bdgafe baegdfc bcadg de agbecf gfbec ecfd | fdce ed de gedabf
afgced gb dbg gbec badcfg abged baedf eadcg cafgedb gdbeca | fgeadc bg gbd beadg
ad bdegca cgabd bedfgac gda cead bfcaeg gaecb cdbfg edgabf | dfbagec eacgfbd cgedba ad
bacd afgecd ba eadbcf fdgeb bgacef feagcdb bfdae deacf eba | abe fdebg abe dgafec
cdafe dab febdga fcbd fceadb bd fecdag agceb abdcfeg bacde | dab cbdafge dfaec dagefb
ecbgad cbe bdef dfegcb dgbcf agcfe fgebc eb fdgbca ebgadcf | bfdgec be be fcgea
cdg dabfc edbfac gd fegac dfacg gfdb deabcfg dbacge bcadgf | bdcfa efgca cgd aedgcb
adcfe afd deagcf faebc ebfcagd efdg cbeagd gabfcd fd cedga | daf dfcae fd egdabc
dgfc cabfe bcg abegdf gdafb cg afbecgd fcagbd aedgcb bfgac | agefbdc gdfacb cg cafdbg
fbadge bfgca agf dacbfge bdcafe bfeac aegc ga fabgce dfgcb | fdebga fgbcd baefgc geac
abe ebcfga dgabc gfcbe fcadbeg gafe ea gcabe fdgbce aecfbd | gadbc ebcag ecgbf gabefc
gd ebacfd afedcgb cdeabg cabgd gad aecbd ecdg gdbfae bacgf | egdacb agfdeb cbafg gda
ec dgfae gfdcba ced dagebc dcafbe cadfb efacd edgfabc cefb | abdfgce befc edc debgca
ec cfed gbafe gfecdba cfdgae cae gfdac gacbde fdcagb ecfag | dcafeg ce fdbaecg gaefb
acge fgebd fcbeg agfcbe ce bcfga cbe eabgfcd gcdafb edfbca | gbafcd abcgf agbcdf ce
eafgcb bface dcgebfa dbface dc ecadbg acfd fdebg dcefb bdc | dacf bcfega cafbe dc
cdbgae befcg bgade fgbeacd gbdfae fbdacg fd dfg aedf bfgde | daefgbc edfa abegd bfadcg
dcage bcae agdfcb efbagd bdafceg gfecd dae dbecga dgcba ae | cdgea aed afbcgd aed
fbedcag agfe cbeafd efgbc gacbd agefbc af cagbf cedbfg afc | gfaebc dagcb febcg ecgfdab
abecgdf cagbd efbdc ebfg fg gdfcb aecdgf dbgcfe cbafde gdf | decfb gfd fbcgd fdg
ecbafd ba bafdeg fgdba dba fgebd cbefgd bgae dcgfa daegcbf | adb bfadg cbfead ab
egbdc acbfged gae cdaeg ga agbefd acgf decaf cdaegf eafdcb | agcf ga daegcfb cedbg
bafce adcfeg caegfb cefga fb fab bdcagfe dabgef bgcf ebdac | gface bcaef fab fcabe
gcedab facgbd efadg edacg bdafecg fedgb fda af aefc gafcde | dgecfa ebdgac fa bdfeg
gdba gedfb egfbad fegadc ecgfba dfbec gd cbedfga abefg fdg | fcadge gdbef fegbac agbef
fbdec fdbceag feacb fbcgd dcbfge dec efgadc dcbafg ed dbge | cabgdf ceafb afgdec de
cbgaed fbagc cbfd bdaegf bdcag egdbfac afgce bcfadg baf bf | fb baf edgafb cbgda";

    public override Task ExecuteAsync()
    {
        long result = 0;
        long sum = 0;
        foreach (var line in Input.Split(Environment.NewLine))
        {
            sum += Solve(line);
            bool pastPipe = false;
            foreach (var digit in line.Split(' '))
            {
                var count = digit.Length;
                if (digit == "|")
                {
                    pastPipe = true;
                }
                if (pastPipe && (count == 2 || count == 3 || count == 4 || count == 7))
                {
                    result++;
                }
            }
        }

        Result = (result + " " + sum);
        return Task.CompletedTask;
    }

    long Solve(string line)
    {
        var digits = line.Split(' ');

        foreach (var permutation in "abcdefg".Permutations().Select(p => p.ToList()))
        {
            var dict = new Dictionary<char, char>();
            dict[permutation[0]] = 'a';
            dict[permutation[1]] = 'b';
            dict[permutation[2]] = 'c';
            dict[permutation[3]] = 'd';
            dict[permutation[4]] = 'e';
            dict[permutation[5]] = 'f';
            dict[permutation[6]] = 'g';
            bool correct = true;
            foreach (var digit in digits)
            {
                if (digit == "|")
                {
                    break;
                }
                var mappedDigit = new List<char>();
                foreach (var c in digit)
                {
                    mappedDigit.Add(dict[c]);
                }

                var sortedDigit = new string(mappedDigit.OrderBy(c => c).ToArray());

                if (!DigitMappings.Contains(sortedDigit))
                {
                    correct = false;
                    break;
                }
            }

            if (correct)
            {
                long result = 0;
                bool pastPipe = false;
                long t = 1000;
                foreach (var digit in digits)
                {
                    if (digit == "|")
                    {
                        pastPipe = true;
                        continue;
                    }
                    if (!pastPipe)
                    {
                        continue;
                    }

                    var mappedDigit = new List<char>();
                    foreach (var c in digit)
                    {
                        mappedDigit.Add(dict[c]);
                    }

                    var sortedDigit = new string(mappedDigit.OrderBy(c => c).ToArray());

                    result += t * DigitMappings.IndexOf(sortedDigit);
                    t /= 10;
                }
                return result;
            }
        }

        throw new Exception("Geen oplossing :(");
    }

    private static readonly IList<string> DigitMappings = new List<string>
    {
        "abcefg",
        "cf",
        "acdeg",
        "acdfg",
        "bcdf",
        "abdfg",
        "abdefg",
        "acf",
        "abcdefg",
        "abcdfg"
    };

    public override int Nummer => 202108;
}