using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problems.Advent._2020;

public class Dag04 : Problem
{
    #region input

    private const string input = @"byr:1983 iyr:2017
pid:796082981 cid:129 eyr:2030
ecl:oth hgt:182cm

iyr:2019
cid:314
eyr:2039 hcl:#cfa07d hgt:171cm ecl:#0180ce byr:2006 pid:8204115568

byr:1991 eyr:2022 hcl:#341e13 iyr:2016 pid:729933757 hgt:167cm ecl:gry

hcl:231d64 cid:124 ecl:gmt eyr:2039
hgt:189in
pid:#9c3ea1

ecl:#1f58f9
pid:#758e59
iyr:2022
hcl:z
byr:2016 hgt:68 eyr:1933

hcl:#fffffd ecl:gry eyr:2022
hgt:172cm pid:781914826 byr:1930 iyr:2018

hcl:#08df7e ecl:grn byr:1942
eyr:2028 iyr:2011 cid:141 pid:319110455
hgt:186cm

pid:991343040 hgt:179cm
hcl:#a97842 iyr:2020
eyr:2024
byr:1984 cid:181

pid:188cm byr:2005
hgt:170cm cid:163 ecl:#a08502 hcl:2964fb eyr:1994
iyr:2005

ecl:grn hcl:#fffffd iyr:2013
pid:705547886
byr:1928 hgt:168cm eyr:2030

cid:219
pid:016251942 hcl:#602927 hgt:163cm
byr:1943 eyr:2029 ecl:oth iyr:2019

ecl:gry hgt:184cm eyr:2026
iyr:2010
pid:117647952 hcl:#efcc98
byr:1942

cid:243 hcl:#888785 ecl:blu eyr:2027 pid:362697676
iyr:2011 byr:1962 hgt:154cm

hgt:154cm byr:1965 ecl:blu eyr:2030
pid:779104554 iyr:2016 hcl:#435634

hcl:z eyr:1996 iyr:1993
pid:#50f768
ecl:zzz hgt:62cm byr:2017

ecl:grn byr:1988 iyr:2016
hgt:167cm
hcl:#cfa07d
eyr:2030 pid:951967790

pid:320348494 iyr:2018 cid:281
byr:2004
hcl:#06a58b
eyr:2033
ecl:zzz
hgt:76cm

cid:83 ecl:brn eyr:2028
byr:1941 iyr:2016
hcl:#341e13 pid:806979833
hgt:179cm

ecl:brn
byr:1982 iyr:2010 eyr:2029 pid:535752324 hcl:#efcc98

ecl:oth
hgt:70in hcl:#866857 eyr:2025 pid:203320330 iyr:2018 byr:2000

hgt:70cm byr:2015 pid:#218eb5 hcl:#0ec4fe iyr:2014 cid:228 ecl:#c8533a
eyr:2035

hcl:#6b5442
eyr:2020 ecl:hzl iyr:2017 hgt:173cm
cid:330 byr:1988 pid:173148327

iyr:2011 byr:1964 hgt:83 ecl:grn hcl:#c0946f pid:931162400 eyr:2028

cid:239
byr:1960 ecl:hzl
hgt:164cm
hcl:#51040b iyr:2018 eyr:2025

cid:163 hgt:154cm
iyr:2015 eyr:2027 pid:838964596
byr:1972 ecl:oth hcl:#efcc98

hgt:181cm
eyr:2028 ecl:blu
pid:853714682 hcl:#623a2f byr:1976 iyr:2020

cid:225 byr:1957
hcl:#a97842 iyr:2013 eyr:2025
pid:511588647 hgt:173cm ecl:blu

hcl:#efcc98
byr:1993
ecl:oth
pid:871652492 eyr:2028 hgt:177cm iyr:2016
cid:220

ecl:hzl
hgt:165cm
hcl:#733820 eyr:2028 cid:57 byr:1973 iyr:2018 pid:018982018

pid:491710153 iyr:2012 ecl:#c85046 hcl:#b6652a
eyr:2040 hgt:175cm byr:1981

pid:917105765 eyr:2021 hgt:181cm iyr:2019 cid:159 byr:1995
ecl:gry

hcl:#9d2ec4 iyr:2011
eyr:2028 pid:149288934 hgt:63in ecl:blu byr:1960

byr:1923 pid:705818464 eyr:2024 cid:221 ecl:oth hcl:#7d3b0c hgt:193cm iyr:2014

pid:117111015 eyr:2030
byr:1967 hcl:#ceb3a1 ecl:blu
hgt:157cm
iyr:2011

iyr:2019 ecl:oth
hcl:#fffffd hgt:172cm pid:215010680
eyr:2025

pid:157cm cid:277
iyr:1976 hgt:159in hcl:#341e13 ecl:#6c7644 eyr:2029 byr:1965

pid:787186482 ecl:brn
byr:1980 hcl:#f5dfb9 eyr:2020
iyr:2018 hgt:188cm

cid:168
eyr:2023 hcl:#07c809
iyr:2013
hgt:169cm pid:250679100 byr:1945 ecl:gry

hcl:#6b5442 pid:683134187 iyr:2013 eyr:2023 byr:1965 hgt:171cm ecl:hzl

eyr:2028 hgt:180cm ecl:blu byr:1952 cid:314 iyr:2016
pid:720794393 hcl:#602927

byr:1982 iyr:2016
ecl:brn eyr:2027
hgt:156cm pid:185583837 hcl:#ddbf30

hcl:#ceb3a1 pid:987624973
eyr:2026
iyr:2013 byr:1988 hgt:175cm ecl:grn

eyr:2028 byr:1974 pid:350988773 hcl:#a97842 iyr:2015
ecl:oth
hgt:160cm

hcl:#b6652a
eyr:2028
pid:717504683 byr:1970
iyr:2013
ecl:gry
hgt:156cm

pid:453874703 iyr:2015 hcl:#a97842 ecl:hzl byr:1986 hgt:175cm cid:132 eyr:2025

hcl:#7d3b0c
eyr:2026
ecl:brn hgt:154cm
byr:1959 pid:580659686 iyr:2015

ecl:amb hgt:191cm iyr:2018
pid:681417707 byr:1994 eyr:2023 hcl:#c0946f

eyr:2022 pid:302326561 iyr:2018 ecl:blu byr:1987 cid:89 hcl:#a97842 hgt:184cm

eyr:2020 pid:457081226
ecl:blu hcl:#866857 iyr:2011
hgt:159cm byr:1959

eyr:2024 cid:322 byr:1991 pid:210415503
hgt:69in ecl:grn
hcl:#623a2f

ecl:blu iyr:2012 pid:524745721 hcl:#c0946f eyr:2026 hgt:176cm byr:1964

hgt:189cm iyr:2014 pid:679155617 hcl:#efcc98 eyr:2027
cid:88 byr:1974
ecl:blu

byr:1935 eyr:2029
iyr:2020
hcl:#733820 ecl:blu hgt:190cm pid:509009432

hcl:#fffffd pid:446558583 byr:1931 ecl:brn iyr:2019
hgt:159cm cid:146
eyr:2024

eyr:2028 hcl:#efcc98 pid:330588516 hgt:65cm
byr:1972 iyr:2014 ecl:oth

ecl:blu hgt:175cm cid:197 pid:068138358 eyr:2023 iyr:2017 hcl:#0441c6 byr:1999

byr:1992 hgt:193cm
ecl:brn iyr:2018 hcl:#866857 pid:905992465
eyr:2022

hgt:95 byr:1965
pid:810311252 eyr:2034 hcl:z iyr:1985 cid:254

hcl:#c0946f byr:1985 eyr:2030 hgt:161cm iyr:2010 ecl:gry pid:616639221

iyr:2011 eyr:2023 hgt:172cm cid:260 ecl:hzl
pid:594747312
hcl:#a97842 byr:1937

eyr:2028 pid:134536806 cid:83
ecl:brn byr:1928
iyr:2015
hcl:#fffffd hgt:157cm

iyr:2016
pid:035433923 hgt:180cm ecl:amb eyr:2027 byr:1934
cid:195 hcl:#583d02

eyr:1936 cid:130 byr:1969 hgt:74cm hcl:50e1a7 ecl:gmt iyr:2010 pid:82008848

hcl:#733820
eyr:2020
hgt:174cm iyr:2018 ecl:hzl byr:1983 pid:087167304

byr:1972 hcl:#888785 eyr:2020 pid:593301831 iyr:2013 ecl:hzl hgt:188cm

cid:282 hcl:#888785 hgt:170cm ecl:oth eyr:2029
byr:1942 pid:014356555 iyr:2020

byr:1966 hcl:#623a2f ecl:oth hgt:165cm
eyr:2028 iyr:2012 pid:558908746

pid:#4f5b92
hcl:#6b5442 hgt:188cm
byr:1994 iyr:2014 cid:127 eyr:2020
ecl:oth

hgt:153cm
ecl:brn iyr:2020
eyr:2026 hcl:#18171d
pid:101990935
byr:1932

iyr:2011 byr:1981 hgt:157cm hcl:#c0946f
eyr:2029 pid:545992967
ecl:utc

byr:1929 hcl:#602927 iyr:2018 ecl:grn
eyr:2027
pid:256056759
hgt:178cm

iyr:2016 pid:813526512 eyr:2027 hcl:#20799c
ecl:blu
byr:1971 hgt:185cm

iyr:2021 eyr:2040
pid:5135078781 byr:2013 hcl:#7d3b0c hgt:62cm ecl:#dedf53

iyr:2013
byr:1979 cid:269 hgt:179cm pid:871628606 eyr:2026 hcl:#53b66c
ecl:grn

eyr:2020
hcl:#ceb3a1 byr:1988 ecl:oth iyr:2012
pid:558371571

pid:908462345 byr:1972 hgt:183cm ecl:gry cid:51 hcl:#af82df eyr:2023 iyr:2019

pid:106942710 ecl:hzl
hgt:157cm hcl:z eyr:2025 iyr:2016
byr:1998 cid:271

iyr:2011 ecl:oth pid:191542220
byr:1951 eyr:2027 hcl:#c0946f hgt:190cm

eyr:2028 hgt:193cm pid:235913726 iyr:2012 hcl:#325350
ecl:amb

iyr:2018 hcl:#a97842 ecl:hzl byr:1988 pid:481250123
cid:328 hgt:165cm eyr:2028

ecl:#a51d9c hcl:91236c pid:2538922220 byr:2017 eyr:2004
iyr:2026 hgt:174

pid:959660262 eyr:2022 cid:339 hgt:170cm iyr:2012
hcl:#cfa07d ecl:brn

hcl:#866857
ecl:dne hgt:70cm eyr:2013 iyr:1980 pid:780067045
byr:1950

iyr:2011
byr:1981
pid:902964474 ecl:gry eyr:2021
hgt:154cm
hcl:#602927 cid:156

iyr:2016
hgt:156cm ecl:brn cid:315 eyr:2023 byr:1997
hcl:#623a2f pid:339892714

ecl:brn hgt:73in cid:184 byr:1960 eyr:2024 iyr:2014 hcl:#888785
pid:561655785

pid:579663338
eyr:1977
hcl:#ceb3a1 ecl:grt hgt:188cm
byr:2017
iyr:2018

byr:1941 eyr:2029 pid:252436521
hgt:170cm ecl:hzl

hcl:#888785
pid:378073052
hgt:185cm
cid:343 byr:2001
ecl:oth iyr:1988 eyr:2029

pid:286459107 byr:1973 eyr:2023 ecl:oth cid:273
hgt:184cm

pid:406853460 eyr:2028 hcl:#b6652a
hgt:179cm
iyr:2020 cid:346
ecl:brn byr:1973

hcl:#ceb3a1 eyr:2026 pid:001798001 ecl:gry hgt:157cm
cid:235
byr:1968
iyr:2013

hcl:#b6652a hgt:151cm pid:504383643 iyr:2018
ecl:brn byr:1990
eyr:2021

hgt:164cm iyr:2015 hcl:#888785 byr:1998 pid:045813631 cid:237
ecl:grn
eyr:2026

hcl:#733820 hgt:172cm
eyr:2030 iyr:2015 ecl:gry pid:507769390 byr:1979 cid:212

cid:138 hgt:176cm hcl:#efcc98
eyr:2024 byr:1984
ecl:brn iyr:2015 pid:968062470

hcl:#733820 iyr:2015 ecl:oth
eyr:2028 pid:431922630 hgt:160cm byr:1941

iyr:2017
eyr:2023 ecl:grn cid:294 byr:1969
hcl:#602927 pid:720065302
hgt:67in

ecl:gry byr:2002 eyr:2024 hcl:#7d3b0c
hgt:174cm
iyr:2012 pid:296913847

pid:42057861 hcl:bb7ace eyr:2023 byr:2013 hgt:188 ecl:#312118 iyr:2024

eyr:2021
byr:1958
hgt:170cm ecl:brn iyr:2012
pid:064919306 cid:349 hcl:#602927

eyr:2022
pid:248168906
iyr:2013 byr:1996 hcl:#cfa07d
hgt:151cm ecl:hzl

cid:301 ecl:brn hcl:#fffffd
hgt:183cm
pid:806659387
eyr:2021
byr:1970 iyr:2013

cid:192
iyr:2013
ecl:#5ad460 hgt:64cm
pid:001255475 byr:1984 eyr:2027 hcl:#cfa07d

iyr:2012 pid:194936105 eyr:2028 byr:2000 ecl:oth hcl:#733820 hgt:158cm

cid:323
hcl:#a97842 eyr:2027 pid:625573908
iyr:2019 byr:1987 ecl:grn
hgt:191cm

pid:997956152 hgt:193cm ecl:hzl eyr:2024 byr:1983
cid:113 hcl:#888785
iyr:2013

iyr:2017 hgt:153cm hcl:#733820 byr:1984 eyr:2025 pid:138608494 ecl:blu

ecl:brn
byr:1987 hgt:174cm
iyr:2013 pid:459148475 eyr:2023 hcl:#623a2f cid:266

byr:2000 iyr:2017 ecl:brn pid:469155516 hcl:#b6652a
eyr:2027 hgt:193cm

byr:1967 eyr:2028 pid:064940030
iyr:2016
ecl:gry hcl:#18171d hgt:74in

iyr:2020 hcl:#efcc98
byr:1968 hgt:164cm ecl:hzl pid:834180009 eyr:2022

pid:021397352
iyr:2018 hcl:#341e13 byr:1978 eyr:2022 ecl:oth hgt:67in

hgt:160cm cid:213 ecl:#a46ef7 pid:157cm eyr:2020 iyr:2020 byr:1923

iyr:2016
cid:235 pid:454188395 eyr:2022 hgt:73in ecl:hzl
hcl:#7d3b0c byr:1964

iyr:1930 eyr:2033 hgt:76cm pid:41117341 byr:2028 ecl:utc
hcl:#6b5442

pid:41316572
hcl:#cfa07d byr:1965 eyr:2027 hgt:179cm iyr:2010
ecl:grn

hgt:152cm pid:886168412 iyr:2027
eyr:1989 hcl:9993d6 byr:2005 ecl:zzz

pid:661569613 hgt:166cm
hcl:#18171d iyr:2010 byr:1922 eyr:2030 ecl:brn

byr:1958
ecl:blu pid:978855125
eyr:2020 iyr:2019
hgt:190cm hcl:#18171d

hgt:68in iyr:2012 hcl:#ceb3a1 eyr:2028 ecl:oth pid:067088299
byr:1975

eyr:2020
pid:507464869 hcl:#fffffd hgt:156cm iyr:2016
byr:1957 ecl:blu

cid:259 eyr:2025 byr:1954
ecl:gry hgt:167cm pid:832017347 iyr:2020 hcl:#623a2f

hgt:69in hcl:#a97842
pid:426496916 byr:1947 eyr:2021 iyr:2015 ecl:oth

eyr:2025 ecl:blu pid:543125976 cid:192 iyr:2017
byr:1920 hgt:154cm hcl:#a7ecdc

hgt:69in iyr:2017
byr:1932 hcl:#6b5442
ecl:hzl cid:349 pid:494399909 eyr:2029

eyr:2030 ecl:gry hcl:#6b5442
iyr:2010 byr:1938 cid:100 pid:477259022 hgt:67in

hgt:145 byr:2009 hcl:#b6652a iyr:2015
pid:180cm ecl:dne cid:315 eyr:1920

byr:1930 hgt:65in
eyr:2022 ecl:blu
pid:671271699
iyr:2010
hcl:#b6652a

byr:1989 eyr:2020
ecl:hzl
hcl:#341e13
pid:625435489
hgt:189cm cid:72
iyr:2013

hgt:184
byr:2025 ecl:#a1368a eyr:2038 cid:111
iyr:2025 hcl:z pid:7952164402

pid:165478949
hcl:453b30 ecl:amb hgt:75cm eyr:1987 iyr:2015
byr:1960

eyr:2022 ecl:blu
cid:100
hcl:ead803 iyr:2025 byr:2018

eyr:2024
ecl:gry hgt:167cm
hcl:#623a2f cid:259
byr:1932 iyr:2014 pid:360279704

hgt:191cm
ecl:oth pid:070592110 cid:275 eyr:2027
iyr:2011 hcl:#4a4252 byr:1937

ecl:blu cid:256 iyr:2017 eyr:2027 hcl:#341e13 hgt:150cm
pid:152140902 byr:1923

eyr:1972 iyr:2020 ecl:gry hcl:#888098 byr:1974 hgt:188cm
pid:586853292

iyr:2014
ecl:brn hcl:#866857 eyr:2020
hgt:184cm pid:422142863 byr:1999

iyr:2025 ecl:amb eyr:1928 hcl:#18171d byr:2008 hgt:62cm pid:42120034

byr:1923 cid:85 iyr:2017
hcl:#602927 eyr:2026 pid:922322363
hgt:68in ecl:amb

cid:97 hcl:#602927
pid:436567964
eyr:2028 iyr:2016
byr:1994

hcl:#9c166d
eyr:2025 pid:834335216 iyr:2011 ecl:blu byr:1946 hgt:174cm

byr:2018 iyr:2027 hgt:187in
cid:118 eyr:2038
ecl:lzr hcl:z

ecl:blu
byr:1998 pid:186cm eyr:2026 hcl:z iyr:2027 hgt:70in

hcl:#623a2f eyr:2020 ecl:amb iyr:2010 pid:743059641 cid:240 hgt:169cm byr:1957

ecl:oth pid:089778639 cid:305 eyr:2027 iyr:2012 byr:1935
hcl:#efcc98

hgt:151cm hcl:#602927 cid:97 byr:1968 iyr:2014 pid:447599233
ecl:oth
eyr:2030

pid:621084188 byr:1941 ecl:gry cid:188 iyr:2012 hgt:75in eyr:2028 hcl:#6b5442

hcl:#c0946f
ecl:amb
hgt:66cm
pid:185cm byr:2022 eyr:2039 iyr:2024
cid:321

hgt:177cm byr:1954 ecl:amb pid:445374119 cid:137 hcl:#341e13 iyr:2010
eyr:2020

hgt:160cm
byr:1923
ecl:grn
eyr:2021 iyr:2012
pid:286304911
hcl:#18171d

hgt:153cm byr:1933
iyr:2015
ecl:gry
pid:365430749 eyr:2029

cid:294 pid:817081355 byr:1969
eyr:2030 ecl:oth iyr:2014 hgt:181cm hcl:#623a2f

iyr:2011
ecl:gry hgt:177cm eyr:2025 pid:446342686 hcl:#b6652a byr:1991
cid:241

byr:1999
iyr:2018
cid:306 hcl:#18171d eyr:2021
hgt:188cm ecl:gry pid:473752814

byr:2002 hcl:#733820
pid:867697169
ecl:gry hgt:165cm eyr:2020
cid:316

eyr:2026 cid:59 hgt:175cm byr:1993 pid:531385722
ecl:hzl hcl:#733820

eyr:2027
cid:50 pid:433963708
byr:1969
iyr:2011 ecl:hzl hgt:164cm
hcl:#b6652a

eyr:2020 ecl:gry hgt:186cm pid:917147781 hcl:#341e13
iyr:2016 cid:68

pid:857547233 hgt:64in
cid:274
eyr:2020 ecl:hzl iyr:2019 hcl:#866857 byr:1948

eyr:2022 hgt:183cm pid:557280094
byr:1936 hcl:#602927 iyr:2019 ecl:oth

byr:1933 eyr:2023
iyr:2020
ecl:blu hgt:72in

pid:682285472
ecl:blu hgt:166cm eyr:2021
byr:1993
hcl:#ceb3a1 iyr:2011 cid:266

iyr:2012 cid:172 ecl:#04ce29 eyr:2021 hgt:160cm byr:1926 pid:2235389773

eyr:2029 hcl:#cfa07d pid:387564370 cid:276 hgt:74in
ecl:amb
byr:1926 iyr:2019

eyr:2026
hcl:#733820
pid:230583200 byr:1997
ecl:brn
iyr:2010
hgt:179cm

byr:1946 hcl:#866857 ecl:#87b6f4 hgt:150cm pid:298537901
eyr:2024 iyr:2011

hcl:#cfa07d
byr:1961
eyr:2022
hgt:167cm
pid:230816154 ecl:oth iyr:2018
cid:164

pid:167899852 hcl:#18171d eyr:2023 hgt:173cm ecl:amb byr:1960 iyr:2010

hcl:#866857
hgt:165cm
ecl:hzl pid:325078465 byr:2002
cid:61 eyr:2025 iyr:2020

cid:268
hcl:#a97842 iyr:2011 byr:1966 pid:450468785
eyr:2030 hgt:173cm
ecl:gry

hgt:181cm
eyr:2026 cid:77 pid:229016136 ecl:grn byr:1929

ecl:#ad9ae9 hcl:z iyr:2012
byr:2029
cid:77 pid:#b1f685 eyr:2015

ecl:amb byr:1920
eyr:2026 hcl:#92e796 iyr:2011 pid:503853254 hgt:186cm
cid:101

hcl:#7d3b0c eyr:2022 ecl:amb pid:536474715 hgt:64in
iyr:2026 byr:1924

hgt:72in ecl:hzl hcl:#888785 eyr:2030 pid:048654766 byr:1977 iyr:2016

hgt:171cm ecl:brn byr:1976 pid:844553043
eyr:2024
cid:241

cid:243 eyr:2023 pid:998276626 iyr:2011 hcl:#623a2f ecl:oth hgt:183cm byr:1920

eyr:2030
ecl:amb pid:896953299
hgt:157cm byr:1934 hcl:#9c12d8 iyr:2015

hcl:#cfa07d iyr:2011 byr:1974 pid:451819357 hgt:168cm ecl:grn eyr:2024

iyr:2018
pid:908304519 hcl:#fffffd byr:1936 cid:203
ecl:amb hgt:76in
eyr:2029

byr:1967
hgt:186cm
eyr:2026
hcl:#ceb3a1 ecl:grn
pid:594830518 iyr:2017

pid:20921789 iyr:2024 hcl:z byr:2026 ecl:zzz hgt:153cm eyr:2037

hcl:#888785 iyr:2016 cid:323 byr:1958 ecl:gry pid:118638859 eyr:2029
hgt:163cm

hgt:167cm ecl:brn eyr:2020
pid:557999801
byr:1988
cid:273 iyr:2011
hcl:#fffffd

ecl:gry pid:206008517 eyr:2022
hcl:#ceb3a1
byr:1983 hgt:187cm

eyr:2020
byr:1931 cid:78
hcl:#6b5442 ecl:oth hgt:170cm pid:039713280 iyr:2015

eyr:2024 ecl:amb
byr:2002 hgt:162cm hcl:#866857
iyr:2012 pid:696390563 cid:184

hgt:189cm byr:1992 pid:712592503 iyr:2012 ecl:oth hcl:#602927
eyr:2029

ecl:hzl
byr:1965 hgt:182cm eyr:2023
iyr:2014 hcl:#a97842

byr:1927 ecl:gry
hcl:#d91aa0 pid:082227536 eyr:2021
iyr:2011

eyr:2003 iyr:1953 byr:1954
cid:327 hgt:62in ecl:utc
hcl:z pid:#97c11a

cid:252 pid:98689392
iyr:2020 hgt:103
hcl:298df8 byr:1934
ecl:oth eyr:2012

hcl:#fffffd eyr:2020
byr:1993 ecl:brn
pid:338398225 iyr:2015 hgt:159cm

iyr:2017 pid:624798709 hgt:151cm eyr:2029
ecl:gry cid:111
hcl:#866857

byr:2010
ecl:hzl eyr:1975 hgt:150cm iyr:1930 hcl:159a9a

iyr:2010
hcl:#7d3b0c eyr:2024 cid:224 hgt:163cm byr:1971 pid:631469024 ecl:grn

ecl:hzl iyr:2017 hgt:167cm
hcl:#623a2f pid:417970460 byr:1949 eyr:2020

eyr:2030
hgt:84 byr:2007 ecl:xry cid:153 pid:9655548750 iyr:1957

ecl:oth hcl:#733820 cid:336 byr:1996 iyr:2014 pid:736143470 eyr:2025 hgt:182cm

hgt:69in hcl:#623a2f
cid:126 iyr:2019 pid:638479310 eyr:2022 ecl:grn byr:1935

cid:240
pid:804066884 byr:1987 hcl:#049f0e
eyr:2023
hgt:174cm
ecl:brn
iyr:2020

ecl:amb iyr:2010
pid:200411701
cid:70 eyr:2023
hcl:#341e13 byr:1974 hgt:61in

eyr:2022 hgt:186cm hcl:#18171d ecl:hzl pid:613033358
iyr:2014

hgt:189cm
iyr:2020 pid:874302209 byr:1928 ecl:blu
hcl:#1c52f4
eyr:2029

byr:2026
eyr:2007 pid:166cm iyr:2030 ecl:utc
hgt:137 hcl:8e8916

pid:781251989
eyr:2029 hgt:178cm iyr:2010 byr:1942 hcl:#cfa07d

pid:671017167 eyr:2030 ecl:amb byr:2002 hgt:166cm
iyr:2011 hcl:#7d3b0c

pid:369327568 byr:1955 ecl:hzl iyr:2013 hcl:#341e13 eyr:2020 cid:90 hgt:154cm

pid:169149205 iyr:1947 ecl:amb eyr:1977
byr:2003
hcl:z
hgt:75cm

hcl:#cfa07d iyr:2016
eyr:2022 pid:941218673 byr:1999 cid:186
ecl:brn hgt:173cm

hgt:159cm eyr:2021 byr:1962 hcl:#efcc98
pid:792538993 iyr:2011 ecl:blu
cid:222

pid:#994231 byr:2024 iyr:1977 hcl:b98ff6 eyr:2010 hgt:71
ecl:#875a67

byr:2007
iyr:2023 hgt:141
eyr:2021 ecl:grt pid:22002588

hgt:190cm
pid:524515058
cid:217
ecl:grn byr:1999
eyr:2027
iyr:2019

ecl:dne byr:2019 eyr:1942 hgt:62cm pid:5866040917
iyr:2018 hcl:z

pid:754032301 byr:1985 eyr:2029 hgt:185cm iyr:2016
ecl:oth

ecl:amb byr:1948 iyr:2010 hgt:157cm pid:153547581 eyr:2027 hcl:#cfa07d

eyr:2026 byr:1942 pid:368975422
hcl:#733820
cid:322 hgt:188cm
iyr:2019
ecl:blu

ecl:brn
pid:535822939 byr:1994
eyr:2027 iyr:2020 hcl:#18171d hgt:193cm

pid:706755664
hcl:#7d3b0c
ecl:grn cid:304
hgt:152cm byr:1972 iyr:2013 eyr:2021

hgt:163cm
byr:1922 iyr:2014 eyr:2028 pid:852815945 cid:324
ecl:brn hcl:53b08b

hcl:#888785
eyr:2023
iyr:2020 byr:1962 ecl:blu
pid:407158186
cid:269

ecl:blu
eyr:2027 pid:567155642 hcl:#a97842 hgt:74in byr:1995
iyr:2016

iyr:2017 eyr:2020
pid:782403650
byr:1952 ecl:gry hgt:193cm cid:273 hcl:#efcc98

byr:1963 eyr:2021
pid:639445576 hcl:#c0946f iyr:2013
cid:306 ecl:blu hgt:154cm

hgt:68in cid:191
hcl:#7d3b0c
iyr:2017 byr:1935 ecl:gry

ecl:brn iyr:2019
eyr:2021
hcl:#733820
byr:2017
pid:714110829 hgt:155cm cid:178

cid:203 pid:455383907
ecl:grn byr:1965
hcl:#866857 eyr:2024 hgt:172cm iyr:2012

iyr:2018 eyr:2033
pid:462538213 byr:1974 hcl:#c0946f
ecl:amb hgt:160cm

hcl:#623a2f
pid:116799148 cid:336
ecl:grn eyr:2027
iyr:2020
byr:1976

pid:654088396
ecl:utc eyr:2021
byr:2016
hcl:#866857
iyr:2030 hgt:191cm

byr:1939
eyr:2023
iyr:2011 hgt:168cm
cid:141 ecl:brn
hcl:#6b5442

eyr:2025 hgt:61in
byr:1977
ecl:brn iyr:2016 cid:198 pid:401742648

ecl:brn
iyr:2012 eyr:2027
byr:1990 hcl:#6b5442
pid:476691172
hgt:72in

cid:176 ecl:oth iyr:2011 hcl:#c0946f
eyr:2028
byr:1957 pid:959615191

byr:2027
iyr:2021 hcl:#733820 hgt:165cm pid:6155507056

iyr:2012 ecl:blu
pid:397461435 eyr:2022 byr:1993 hgt:170cm
hcl:#b59662 cid:185

ecl:hzl byr:2015
hcl:z hgt:185cm eyr:2036 iyr:2017
pid:172cm

ecl:oth
hgt:181cm iyr:2019
cid:113 byr:2000
hcl:#866857 pid:045077916 eyr:2029

iyr:2013 ecl:grn
pid:717028913 byr:1953 eyr:2025
hgt:191cm hcl:#6b5442

pid:825834003 eyr:2027 byr:1941
hgt:163cm iyr:2010 hcl:#6b5442 ecl:amb

eyr:2026 hgt:59in
hcl:#e9ebf8 byr:1966
iyr:2018 pid:677886127 ecl:grn

hcl:#888785 pid:771218458 ecl:hzl eyr:2029
cid:153 byr:1991 iyr:2011
hgt:76in

hgt:161cm hcl:#888785
ecl:brn byr:1928 pid:913959218 eyr:2020 iyr:2013

hgt:188cm eyr:2026
byr:1964 ecl:blu hcl:#733820 iyr:2017 pid:874400552

ecl:hzl iyr:2017
cid:59 pid:130750853 byr:1964 eyr:2028 hgt:177cm hcl:#602927

pid:200888672 ecl:oth iyr:2016 eyr:2020 hcl:#efcc98 hgt:163cm

eyr:2026
ecl:gry
hgt:189cm
hcl:#c0946f iyr:2019 pid:741121671 byr:1971

ecl:amb eyr:2028 hcl:#888785 iyr:2017 pid:060053163 byr:1952 hgt:191cm

hcl:#55c45a
eyr:2022 ecl:blu
iyr:2019 pid:326991534
hgt:158cm
cid:149

hcl:#a97842 iyr:2013 ecl:hzl byr:1941 hgt:179cm

hgt:68in hcl:#18171d
eyr:2021 byr:1938 ecl:oth iyr:2015
pid:888616887

eyr:2026 iyr:2018 ecl:oth byr:1990
hcl:#efcc98
pid:472330538
hgt:192cm

byr:1933 ecl:grn hcl:#7d3b0c hgt:74in iyr:2011
eyr:2028 cid:55

iyr:2014 hgt:165cm ecl:blu hcl:#18171d byr:1998 pid:601177268 cid:64 eyr:2027

iyr:2011 ecl:grn cid:188 pid:440822084 eyr:2028
hcl:#c0946f byr:1987 hgt:154cm

hcl:#f29c57
cid:114 iyr:2010
byr:1989 eyr:2023 hgt:61in
pid:166071094

hgt:71cm
iyr:2022 byr:1965
ecl:#bb3dce pid:88829820 eyr:2040 hcl:z

hgt:62in hcl:#7d3b0c pid:585528668
eyr:2028 ecl:oth
byr:1941

ecl:oth eyr:2030
byr:1952
iyr:2018 pid:422437243 hgt:185cm

pid:054717793 byr:1989 hcl:#18171d
iyr:2014
ecl:grn
eyr:2025 hgt:151cm

eyr:2027
hcl:#cfa07d pid:071196833
cid:297 byr:1932 hgt:173in
ecl:grn iyr:2016

hcl:#6b1c3d eyr:2026 pid:963034490 iyr:2011
hgt:175cm byr:1961 ecl:oth

hgt:69in
hcl:#b6652a ecl:oth
pid:771661551 iyr:2016 eyr:2023 byr:1960

cid:63
pid:190cm byr:2021 ecl:#252d02 eyr:1931
iyr:1966 hgt:101 hcl:dc9531

byr:1976 eyr:1925
ecl:grt cid:203
iyr:2019
pid:170cm hgt:181in

iyr:2014 ecl:amb
hgt:182cm cid:283 byr:1983
pid:307867769 eyr:2024 hcl:#cfa07d

hgt:157cm hcl:#ceb3a1 eyr:2026 pid:109243500
byr:1926
iyr:2015 ecl:oth cid:330

hcl:#602927 byr:1940 pid:389818848
iyr:2016 ecl:brn
hgt:68in eyr:2023

ecl:brn pid:340990019
eyr:2020 iyr:2011
hcl:#fffffd hgt:175cm byr:2001

cid:264
hgt:154cm pid:128094068
hcl:#888785 iyr:2013 eyr:2027
byr:1929 ecl:amb

cid:270 hcl:#602927 hgt:156cm iyr:2018
byr:1983
eyr:2020 pid:621875145
ecl:gry

cid:345 pid:68093057 ecl:grt
iyr:2019 byr:1992 hgt:109 hcl:35d6e4 eyr:1976

pid:714839913 ecl:grn hcl:#733820 iyr:2020 hgt:153cm
byr:1996 eyr:2027

pid:820650878 eyr:2027
hcl:#866857 byr:1957
iyr:2015 ecl:grn hgt:167cm

pid:600488426
hcl:#ceb3a1 hgt:151cm
ecl:amb eyr:2021 byr:1936 iyr:2015 cid:326

cid:256 hgt:169cm
iyr:2014
pid:261369952 eyr:2028 byr:1982
ecl:brn
hcl:#733820

eyr:2021 iyr:2011
pid:745066100 hcl:#3bbbd5 byr:1998 ecl:amb hgt:166cm
cid:257

ecl:#a38be3 cid:256 hgt:154 eyr:2033
byr:2006 pid:5154675209 hcl:z

hgt:160cm cid:103 ecl:gry byr:2000 hcl:#a97842 eyr:2026 pid:528503931
iyr:2010

eyr:2025 cid:131 iyr:2011
byr:2001
pid:346722892
hcl:#cc0362
hgt:168cm
ecl:brn

hcl:#ceb3a1 iyr:2012
hgt:188cm pid:760916817 byr:1985
eyr:2020 ecl:oth

hgt:179cm
cid:317
ecl:amb pid:411265118 iyr:2018
byr:1982 hcl:#733820 eyr:2028

byr:1927 hcl:#7d3b0c iyr:2020 ecl:gry
hgt:155cm pid:937138356 eyr:2021

hcl:#efcc98 pid:793804751 eyr:2022 byr:1961 hgt:193cm iyr:2016 cid:222

pid:715207875 hcl:#18171d eyr:2030 byr:1974 hgt:157cm ecl:blu
iyr:2019

eyr:2022 pid:134624402 hgt:159cm cid:154
byr:1938 hcl:#cfa07d
iyr:2018 ecl:gry

ecl:oth eyr:2021
cid:259 pid:0484880795 hcl:#cfa07d hgt:189cm iyr:2019 byr:1958

byr:1960
pid:752967111 iyr:2010 hcl:#52a9af
hgt:151cm ecl:amb eyr:2025

eyr:2028 byr:1974 ecl:oth cid:348
hcl:#b6652a hgt:164cm iyr:2018

eyr:2029
byr:1942 cid:232 iyr:2016 hgt:193cm
hcl:#733820 pid:175cm ecl:oth

byr:1990 hcl:#b6652a eyr:2028 iyr:2011 pid:054326137 hgt:153cm ecl:blu

byr:1933
pid:659875882 hgt:181cm
eyr:2023 iyr:2012
ecl:grn hcl:#18171d

ecl:grn iyr:2019 hcl:#866857 byr:1946
eyr:2023 hgt:193cm pid:494553757

cid:331
ecl:blu eyr:2021 hcl:#733820 hgt:174cm
iyr:2010 byr:1950 pid:405416908";
    #endregion
    public override Task ExecuteAsync()
    {
        IList<Passport> passports = new List<Passport>();
        Passport current = new Passport();
        passports.Add(current);
        foreach (var s in input.Split(Environment.NewLine))
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                current = new Passport();
                passports.Add(current);
            }
            else
            {
                foreach (var kvp in s.Split(' '))
                {
                    var split = kvp.Split(':');
                    switch (split[0])
                    {
                        case "byr":
                            current.Byr = split[1];
                            break;
                        case "iyr":
                            current.Iyr = split[1];
                            break;
                        case "eyr":
                            current.Eyr = split[1];
                            break;
                        case "hgt":
                            current.Hgt = split[1];
                            break;
                        case "hcl":
                            current.Hcl = split[1];
                            break;
                        case "ecl":
                            current.Ecl = split[1];
                            break;
                        case "pid":
                            current.Pid = split[1];
                            break;
                        case "cid":
                            current.Cid = split[1];
                            break;
                    }
                }
            }
        }

        Result = passports.Count(p => p.IsValid()).ToString();
        return Task.CompletedTask;
    }

    private class Passport
    {
        public string Byr { get; set; }
        public string Iyr { get; set; }
        public string Eyr { get; set; }
        public string Hgt { get; set; }
        public string Hcl { get; set; }
        public string Ecl { get; set; }
        public string Pid { get; set; }
        public string Cid { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Byr) ||
                string.IsNullOrEmpty(Iyr) ||
                string.IsNullOrEmpty(Eyr) ||
                string.IsNullOrEmpty(Hgt) ||
                string.IsNullOrEmpty(Hcl) ||
                string.IsNullOrEmpty(Ecl) ||
                string.IsNullOrEmpty(Pid))
            {
                return false;
            }

            if (!int.TryParse(Byr, out int birthyear) || birthyear < 1920 || birthyear > 2002)
            {
                return false;
            }
            if (!int.TryParse(Iyr, out int issueyear) || issueyear < 2010 || issueyear > 2020)
            {
                return false;
            }
            if (!int.TryParse(Eyr, out int expyear) || expyear < 2020 || expyear > 2030)
            {
                return false;
            }

            if (Hgt.EndsWith("cm"))
            {
                if (!int.TryParse(Hgt.Substring(0, Hgt.Length - 2), out var height) || height < 150 || height > 193)
                {
                    return false;
                }
            }
            else if (Hgt.EndsWith("in"))
            {
                if (!int.TryParse(Hgt.Substring(0, Hgt.Length - 2), out var height) || height < 59 || height > 76)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (!new Regex("^#[0-9a-f]{6}$").IsMatch(Hcl))
            {
                return false;
            }

            if (!new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(Ecl))
            {
                return false;
            }

            if (!int.TryParse(Pid, out _) || !(Pid.Length == 9))
            {
                return false;
            }
            return true;
        }
    }

    public override int Nummer => 202004;
}