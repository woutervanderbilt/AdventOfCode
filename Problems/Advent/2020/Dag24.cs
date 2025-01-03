using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2020;

public class Dag24 : Problem
{
    #region input

    private const string input = @"nwwnwnwnwsenwnwenwenwnwnwnwnwwneswwnw
nenewsesweeeeeeeeeeeeneeee
swswswseseneswseswnwseseseseswnewseswsesw
swseseseeswsesesesesesesesesesenw
wnenenwnenenenenenenesenwnenesenenenene
esesenwseewseseseseseeseseeesweseese
eseeeneeeeeeeeeweeeswewe
seeseeswnweeneswwswneweeseenwsee
nenwneswneneeenenewneneeneneswnwnene
enwnwwnewnwnewwsewnwnwnwnwswnwewnw
neneneneswnenenwnwnwnenene
seseswesenwnweenwseseseeneeesewsesw
eeseswsenweneeeswneseenwseeewse
nenwneseeeneneene
eeneswnweseeeeeeneenwee
nwnenenesewnwseswwenwnwnwnwnwnwswwnwnw
swwswwwnwswwwswwwwwwewewsww
wwsewnewwwwwwwswwwwwwww
nwwnwwnwswneswwsewwnewsesenewnwe
eneeswseeeeeeesweenewewene
swewswnwnwswwwswsewwwwwswswwsww
swwneseseneswseseweswnweswwswesese
eneneneeeneneeeesweeewenenee
wseeseseseseseeseeseseseseewsesene
sesenwswswnwswseeswsweswnwswwswswnwse
eeenwseeenweeseeeeeseeeswsee
eseewseneswseeewsewswnwnweenee
seeeseesenwseseeeeweseesesesee
neseenwneneneneneeewneweneswnenww
wnewseswswswseswseesewseswneswswseswsw
wswenwsenenweseswnwewnwe
swwswseswnwswnenesesewenesenesewneswsw
nwnenwnewnwnwnwnesenwnwswnwnenwnwsenwnw
nwnwnwenwnwnwnwnwnwswnwnwnw
eeeeseseswseseeeeeneswseeeneee
ewwwwwsewwnewwwswwwwwwsww
wswwwwwnwseewwnwenwnwnwnwnwne
wwwenwwnewswewwwnwwswwwww
senwnwseesenenwnwesw
sewswwwwwwwwwwwwwwsenwwnew
neneeeewneeeneeeseeneeeenee
neeeeeseeeseswenweseeeenwee
eeeeeeneeneneswweeeeeene
seswwswswneswswswswswswswswswsw
nenwsenenesenenwnwnenenwneswsewsenewnenene
seswnwsenwswswswswswswwseswswswnewswsww
senenwnenenenenenewneenenenwnwnewnenwnwnw
wnwnwnwnwnwnwwnwnwenwwswnwnwnwnwnwnw
ewswwwswswwswswwswswsw
nwnwnwnwnwnwnwsenwnwnwnwnwnwnwnwnew
nenenenenenenenenenwnenenenenenwswswnenene
nwnwswwseneseswweswswswswswwnewewe
eneeeswseswneswenewnwwee
neswnwnenenwesewnesenwnwnwnwswneneneenw
seseswesesesesewneswsesesesesesewsese
wwwwswwsewwwswswnenewwww
wwwwsewwswsewnenwww
sewswseswseswseswswnwswnwswswwnwwswnww
esenwnwenwnwnwwnwnenwnenewnenwnwnwne
nwnwwnenwseenenwnwnwewnwnwnwnwnwnwnwne
swnwnwnwnwnwnwnwwnwnwswwwenwnwnesenw
swswswswnwseswswswswwswswneswswswswwesw
wsewenenwswnwnweewswwneswenesww
swwwswwswwswswnewswwsewwwwww
nweesweeeewseneeenee
wwwwnewsewwwswewwwwwnwww
seseseseseswsesewnenwswnwswswswnwswsesese
swseswseseswswsewseswswswneneswnwesesese
wneswnwneneneneseneneneneneneneneneenenwnw
neseseesenwseseeseseswsenwseesewsee
wwwnewewwwwwwwswwwwwswe
weeenwweneswneseneeeseeneneee
nwnwseseweswswswswseswseswneseswswsenese
seswenewneswseewnwww
eseswneseswseswswwnwse
nesweeneneseweeseeeeweenwwee
seewseenwwnesenesewswwwwnwwnwseene
nwnwwnwnwnwnwswwnwnwnwnwnenwnwnwnwesw
wnwwwnwnwnewnwnwnewnenwnwsesewsesw
nwswswsesweswwewwswnwwsewswnewnesw
swseewseseseneeseseneeeseseseseew
seswswseseseneswsewseseneswseswswwswsw
wwwnwwwewnwwwwwswwwwwnww
nenwnenewnenenenwwnwneneeneneenenenenw
nenwnwnenenwnwneneswnwswnenenenenenwnwnwne
nwnenenwneswneneeswnwnenewenwnwneene
nwewnwnwseenesenenwwswnenenwnwnenwnw
wnwwnwsewnwnewwwwewwwwwnwww
wwwewnewwwwwewnwswwnwwwwwse
senweesweseseseeeseeswenweeeese
swnenenwnwnenwnwnwnwswnwnwnenwnwnwnwnenw
nwenwnewwnwnwenwnw
swnwnenwswneneeneeneee
seseseswseseseseseswseneswswwesesesesese
seseseesenwsesenweseeseweeseseseswse
eeneeeeeeseeseseseswseeee
swswwswseneseseswseswseswnwwswswnwswsene
wesewwewwwwwneswswnw
nweewnwwsenwnwnwwnwwnwswwnwswnenw
eeeweeewseseeseseeeeesenwne
wsenewwwwwwwwnwwsewwwnwne
seewswnwnweeenesweseswseneesewe
swnewnewseneswweewenwwweswswnw
swweswnwswwnenwwswwwsenewnenewew
nwnwwwewnwsesewnwsww
neweswwnwnewswnwwewswneseewnwnw
swnwnwnwsewnenwnwnewsenwnwew
neseesesesesesesesesesesesesesewwsesewne
swwwnewnweeneswswseeswenwseswneswne
swnewsesenenwswsewsewnwwewnwwnwe
neseewseseseeswswsesenesenwsesenwseswse
swswswswswwswswseswswswswneswsweswsww
swwsweneswseseseneesesenwnwseeesesee
sesesesesenwseseseswnwswseseseesesesesesw
wwenwwsenwwwenenw
nenenwnenenenenenenesenenenenenenenene
swseseseseenesesenwsese
swsweswsesesesesesesesesesenwwse
seeeswswnweseneneswwnwsweneweenee
nenenenwnenenwnwnenwsenwnenenenenwsww
enewsesewseswsesewseeweseneenenesee
eseswswseneswwswnwseseseewswwwneseswe
eeeneseseeseeseweeeeewese
nwswwwwwwnwnwwnwewwwnwwwnwnwe
swswseswsesweswneswwswwnwswnweneswswne
sweeeneeeeneeeesweeeneneee
neneeneneneneswnenenewneneneeneeneene
swwnwnwnwwnwnwnwnwnwsenwnwnwnewsenwnw
eeeeenwseeseseeewseseseswseeee
wwnwwwswwwnwwwnenwewnwnwwwww
enenwseneneneneneeneneneeeneene
eseswwswwsewswswswwwswwwnwwwnewne
eeeneswnewswsesenwwsenenesesenwee
senweseeseswseseseseseseseseseseseese
swneswwwswswswswwwwswwswswseswswnwsw
swswswsewswneswwswswwwswswnwwwwesw
eweewnesenwnwwswswnweseseeneese
swsenewnewneneneseneneneneneenenenewene
nwnwweswwwswwwwnwwswwweswesw
neneneswwnweeeweswneeswneswwsenwnww
nwswsweswnwnesenwnwwswneeswswwesese
nenwnesesenewesewnwnenenwwsweeww
swswswswswswwswnwnesweswswswesw
wwwnwenwnwnwewwwnweswenwnwneew
nwwwnwnwnwnwnwwwsenesenwnwnwnwwnwwnwnw
eneneseseeesewenwsesesesweswsesese
seswwswseseseseswswseneswseswswsesw
swewswswwsweswswswswswswswwswswswsww
wnewneenesenenenwnewnenwnenenesenwnenenw
seswseseswwwsesenesesesewseewseswnene
eeneswneneneeneneeneneeneenene
swswswswswswwswswwesw
wwwswswswswswewswnwswwwewwsenwsw
eseeeesenweeeeesewseeeseee
swswwswwwswswwneswsweswswswswswswsww
seseenwseseswswsesesesw
newsweeewnwenewnesewsewnewnene
nwnwnwnwnwnwnwswnwnwsenwnwwnwnwnwnwne
sesesesesenesesesesewswseseseseswsesese
seseseseseseeseswsesesesewsesese
wwseswnwseswswnewwswwnwswwswwew
sewweswseseseseseseswseseseweneseswsw
nwnweneewnwnenwswswnwnenwneswnwwenenw
swnwnwnenwsenwnwsenenwnenenweswswnwnenee
seswseneneswsewewwnewnewwnwwwnesw
seswswsenwswswswswswswseseswseswsenesesewsw
senwseeseneseseseewseseseswweesesew
seweswsesesesewnwnweseseeswseneseswse
eeseeseeeeweeesee
swwswwnwwwnwwwwwnewsewwewwswe
nesenwneswenenenwnwwnenenwsenenesesenew
wenwswseseseseswseeseswwneseesenwse
nwneenwneseswenewsweseseneswenwee
seeseseseseneseseseseseseenwsesesesesew
wnenewneneneeenwenweneswswswseswnwse
wwwswwsweswswwwswswswsww
eeeweeseseeeeeeeenweeene
eswwwswsewnwwswnwewwswwwwwwsw
enenenwneneeeneweneeneeneseswee
wswwsesweswwenwewwswnenwnwswnewew
seseenwwwseswswneswneswsewneseeswnee
swneeeeneneswnwesweeeneeenwene
neneswnwwseeswseswseneesenwswswwnwswese
seseseswseseseseseseenwsenwseenewnwsewe
wneswweseswseswsesesesesesesese
seseeeseswseseseseseseseseseesenw
nwnwsenwsenweeseewesesweseswseswe
wneweswwwwwwwwwwwwwswwwsw
ewwswseesenweenwnwneneeese
sesesesesesesesesewseneesesese
swswswswnwewswwswswswswswswsw
nenenewwnesewneneneeneeneneeeeenee
senenwewnenenenenenenenenenenenwnwnenesw
swwsewswwswenwswnwsweswswewswnenw
swswswwnwswswswwswwwswwwswwswesw
seweeeeneeweeswseewnweeeeese
nwneeseeweenwswswseeeenwseenesw
wwnenesenwnwsenwnwnwnenwwenwnwnenene
eseeeenweneswesesw
swsenwwwnenwwswsenenenewwneswnweww
newnwnwnwnwnenenwsenenwnenwnenwnenwsewnw
eeseneenwsweeneenwnwnwnwsewnesese
eneseneneenweseneweneeeesewnenee
wswswswneswswswseswswswswswswswswswswsw
swswswenwneswswwswswswswseswswswnwswse
wesewseseeseseeeeseeseseeeesee
senwswsesesesweweenewswswswnenwsenwese
eseeeeeeeeewneeseeeewseeese
wwwwewswwwnewwwwwwswnwww
nwseseseswseseseseseswnwseseswswsesesesene
enweenewneseeewneeseeenwesenew
nenenewenweswnwneeneweseseneswneee
ewwwnwwwwwsewwnwwwwnwwwsww
neneneseswnewnenwnwneneswnweswwsenwswne
nwnwnwswnwwwnwnwwswnwwnwnwnewwwe
nenenewneewneeseseneenenenenenenw
nwnwsenwwwnwenwnenwnwwwsewwwnwsw
nwnwwwnwenwwwnwsewnwnwwnwnwnwnwnww
sewswswswswseswswseseswswswseswswswsene
wsenwnweswnwswewswnwnwewwsenwwnwww
swswneswneswwswwwwswswnewsw
wnenwnwnweneneswwnwenwneneneseseswwnw
nwnwsenwnwwnwsweswnwenwwnwwnwwnww
sweeeeneseeesewenweesweeee
nesewneneneneswneenewnesewsenenenewne
ewwwwwwenewenwwwwsweseww
nwewnwwswwwnwnwsewwwnwnwwwwwnw
seseeeneswsewseeseeeseneswsesenenw
senweswnwnenenenwnwswnwnenenw
nwswnwswnwnwnwwnwwnwwnewnewwnw
swswseweswwswswswneswewwwwswwsww
eeeneneeeeswnenwneesweeneeeeee
swswswswsweseeseswsewswswnwseswswseswsw
neseseseseseseseseweswseswsewswsese
nwwseswwnwnwwnenwwnwswwenwwne
ewsweseneeewneeeeweeeseneeese
seeswneseneenwnwewswnweseseswnwesese
eswswseswswswseseseswswnwsw
nwesesenweseeeseseseeseseswseswee
nwnwswnwwnenewnwnenwswnwswnwwwwnwnwnw
enweeswneeswweenwewseeseswsese
wwnwswswwwwwwwswwwneswwseswwe
nweeeeeeeeeeseeeeeeeesw
eseenwsenwseeseseenwwseswsese
neeeeseeseswewsenweseseeeeseesee
wwswswneseswswesweswswswnwseswswswesw
neeneneeeeeweeeeeneswwe
seswseseseseswseswswswneseseswsese
newwnwnwswnwwesewnenwwweswwwnw
nenwneneneneneneswnewesee
wswwwwwwwwswswswwwnewwwsw
nwswswseseswewseseswseswswswswsesesw
eeeeseseswsesesesesenesewewsesesenw
nwnenwseswnwnwnenenwnwewnwnenwseenwwnw
seswwwwwswseneenwneswswnenwsewswe
seswsenwseswseseseseeseseswneswwswwsese
swneneneneesenwnenwnenenenewseswnenenee
nwswnwwnwnwnwswnwsenesenenwnwnwnwnenwsenw
nenenwnwwnwnwnwnwnenwnwnwnwenwnwnwnwsw
neswwsewneneneeneneneeneeneneenee
seseneseswswswnwswswswswseswswswswwesw
nwnwnwenwnwnwnwswswenwnesenwnwnwneneswnw
enweeneeesweeeneeeeeeeee
seseseneseseswsesesesesewseseswsesenesese
seseswswnwneswswwswswseswseswswseneswswesw
seseseseseseswseeeeeeeeseseenw
eseenweseeenwesweeeeeeeese
seewneeneeeeneenesweenenwneeene
nenwnweenenwswsewnwwwsewnweneewnw
eseseseseswseenwesesesenwseseesesesese
wswswswneswswsweneswwswwswnwswsw
wwwwwwswwwwswwseenewsewnwnw
seseeesweenwseseswseeseeseesesesenwse
nenwnwnwneswnenenwswseeeswswneneneseww
swwwswsewwswswwneesenwswsewnenww
wnwseseseseseenwsewneenweseseeswsw
enwnwnwnesenwnwwsewwsesewnewwwswe
nwnwwnwsenwwnwnwwewnw
seseneswseswwseswswseseswswseseseseswsw
nwnenenwnwnwnwnwnenenwnwnwnwwsenenwnwnw
weseeneneneneneswneeenenesenewenewe
wwwwnwnwnwnwenw
nwnwsenwseseseswsesenwsesweswswneseeswe
seseswsewseseneesesenwnwse
wswwseswswwwswswswwwswnwwwwwene
eneswnwwnenwwenweewsweeswnwnwswne
wwwwnwnwsweswwenwnweswnwnwwnwe
nwseswswnewsesewnweswneseenesenewew
swnesweewwswwwswswnwswsewwwwnw
neeswneswnwsesenewneneswnwnewnwnenwne
swswswswseswswswswneseswseswswswsewsesw
swseneswswswneswseseswswswseseseswswsese
swswswswswwnwswnesweseneseswnweswswsesw
wnwwwwnewsenwswsenwwwwwnww
seseneswswswswsenwswswseswseswswwsweswswse
enwweeeseeeseneeneeeneneenee
seeeswseeesenwesesewseseeseesee
sewwnwwwwwswswnwswseewwewswwnew
swwsweneneswswwswneswwwwswseswswswsw
nwswseseseseseseseseseseseneseswsesesesese
wswwwnwnwwswwsesesweneneneswwswwsww
newswwswsewwnenwwweseswsewnwswsenenw
swswswseseseseswseswnw
nenenenenweswneneneneneewneenenenesene
seeseneswseseseseseswsesewswswswswsese
ewwwnwswwnwwwnwenwsenwewwsesenw
nwswnenwnwnwnwnwnweenwnwswnewnwnenesenw
nwwswwwwswwswnesewwwswwwwwww
sewwswwnwwwwwwwewwwwwwwnew
wswnwwwwnesewnewwnewwwswseew
nwnewwewneswnwwsenwwesenwwnww
neneneweesweeneneenenenese
wnwwsewwwnwwwwnwww
nwswenwnwswwnwnwwnwenwnwnwnwwsewww
seseswesenwseseeesenwseseeeseswsew
enweeeseenesewsenesesewseeesew
ewnwnwseneneneswneneneneswneeneswnenee
seseseseseseewseseseseeneseseseesese
nenwswsenenenewwnwnesenenenwnenwneese
swenwnwwswwwswswwesenwwnewswsw
seewswseeesenweeweeneneewneeww
eseseseesenwseeseseseesesesewnwsee
neseneeseswseseswseseseese
swnewnwsenwnenwneenesee
nwnwnwnwnwnwnwnwnwnenwsenwnwnw
nwwseeswenwnenwwwswsenewnweewesw
swswswwswswswswswswswswwswwnwwneeswwsw
nwnwnwsenwnwnesewnwswenwnwnwwnwnwwnw
nenwnwseeneneswswswsese
eeneseneeneneenenwnesweeeeneenw
neneneswnwswneeeneeeneneneneneneenwne
nesweeeneneeeweweeneeneenene
eseneneeenwsenewnenenewseswnenenenwne
swnenwneenenenenenesenwenewnenenenenene
wwwnwnwwenwwwnwwsewwnwwnwnwnww
ewwwwnwwwewsewnewnwwswsewwnww
esenenwseeseseseseseswsewswe
weswswswswwswnewwwwwwwesewswswnw
wwswwswsweneewswswnwnewswwwwwww
nwneneneneneneeneneneneswwneneenenenese
neenwnenenwnwswnwnenenenwseneswnwswswnww
nwnwewnwnwwewwenwwswsesenewww
wwwwwsewwwwwwwwwwwwwne
wseseseseseseswseseseesesesese
nwnwswwnenenenenwnenenwnenwnesenwnwnwnenw
nwsesenwwwnwnwnwnwnwnwwwnwnwnwnwnww
nwwwwwnwwwnwswwnwewww
eseneeseeseseeenwseeseeneseswseesw
swsewswswseswswneswswwswswnwswsweswsw
wwnwwwswwnwwnewsewwwnwne
swswswsenwswswswwswswswswswsesweswswsw
swseswneswnwswswsweseswnewsweneswnwswsw
seeseseeeweewseseneseewseseee
eeswneeeneeeneenenenw
nwnwnwnwnwnwnenwnewsenwnwnwnwnwsesenwnenw
nesenenwswneeswseseneswswnwnwswnenwswnew
wwnwnwwwswwwsenwwwwwnwewwswne
nwnwnenwnwnwswnwsesewnwsenenwswnenwnenwnw
nesesewewneswswsenwnwseenwwnesweenwe
seswweweseeeeeenwneeswenesewe
sewwswwnwswswwswswswneswswwweswswwsw
seseneeseseseseeseswseseesenwesesese
nwnenwnwenwwnwnwnwnwnwnwwnwnwnwsewe
wwnweswsenewsweswwswswwnwwswwww
nenwnwneneneneneneswnenenewnenwnenesenenene
swnwnenwswenwneswnwnwwnwnwseneenwwnesw
sesesweswnwnwswsesesweswseswsewswswsw
enenwneneeeeneeneseeneneneeneswnwe
wnewwwwwwwsewswwnewwsewwnw
seswnesesesenesesenesesewswsesesewsese
wwwsewwneswwswwnewne
sesesesesesesesesesesesenwswseneswseese
eneneneneneseenenenwenwswneneneswnee
wnwwwsesenwnwnwnewwnwnenww
nwswnwwseewwwwwewswenwswnwswsw
swsesesenwseswswseswswsesenwswseswsesw
wwwwnewwswswwwwwswwww
sesesesesesewsesesesewneseneesesewse
esweeeenweeeeeeeeeeeee
wsewesesewseenwnwneeswswnesenesee
wswwnwweswswswwswswswswsenwswswsw
swnenwswnwsweseswenwnwwweswweewse
swnenwwwneswwwswwneswseswwswwsesw
neeeeneenwseeseeeenenewewee
nwnwnwnwnwnenwswnwnenwnwnwnwwnwnwenwnwnw
swneswswswseswswenwneseswswseswswswswsw
seeseseneneswsesesewneeseeeswseseeswne
nwnwnewsenwenwswnenwnwnwnenwnenenenwe
swneswneneneenwneneneswenenenwnenwnene
neswseswnwnenwswnenwnewneswwswnwnwnenwnw
neneneseswneseenwnenenewwwneneneenwne
newsweswnwswneswsweswwwswswwsewsww
ewenweseeeweeneeeneneseswee
wswseswswnenenewswswsewswswewseew
nweneeenwwswsweeeseneseneeewne
senwwsweswnwswswsenwsewseswnwneeswe
swseswwewwnenewswswwnwwswwswsenew
eenenenenenenwnenwswswnwsweeeenee
neneneeneneeneneeneneneneesewneene
swnwwnwswswweswswswswswswswwseswswwsw
wwwnwnwnwwwwwswwwwnwnwnwsenwwne
wwswnenwwnenwwwewwwwwesesew
eeeeewseeseneseseweseeeeese
nwseeeseseeneeeeseeseeseeewe
eswneeneeeneneweseeneeneneeee
wnwswswwswsesweswswswswnwswswswwswsw
enwneneneswneneneneneenwsenenwnesenewsw
swnwnwwswnwwnwwwwnwnwwwsenenenww
wnweseswnwnwwnwwswnwnwnweeenwenwse
nwnwswnwswnenwnenwnenwenwnwnenwnwnenwnw
seseeseseseneseenwswneseseswnwsweneswwe
swwwwwwnwnwwwnwswnwwwnewewwne
eneneneswneneneneenenwnenenene
nesewsesewneswnwwwnwwwwwwnewwnenw
enenenwnenenenenenenesenenee
seswseswswswesenwseseswnenwswneswswswsw
nenenenenenewwneneenenenenenenesenenene
swneswnewswwwwswswswwwswswseswwsw
nwnwewnwnwseeneswwswnwnwwnwwwnwnwnww
eeeswnweeeweweweee
enwwnwwenwwsww
wneswsewswwwwwswwswwwswwww
swwwwewnwwweweswewwenwww
wwseswenewwwwwwwwwwsewnwwww
nwsewseseneswesweseswnwwswnew
swneseswswswswswswswswseswswswswswswsene
nwneneneneswneneswnenenewnenenenwswenene
wwswwewswswswswswwwswnwwwwseswsw
nweeseeeeseseeseesweseenwsesene
wneswswneneneenenenesesenewenww
seswneeneenewseeneenenenweneeene
neswewsewnwnenwnwnenwnwesewneneeswe
eeeeenwseeseseeeseeee
ewnwseeseseseeesenweseneseseseseese
swwneswewwnwwewwwwsewswnewww
swwswnenwesewneseenwswenewnwenww
nwnwwnwnwnwwwnenwnenwwnwsewnwnwnwsw
swnwswswswwswwswwnweswswswwswswswwe
wnwneeeeneneeesesweeeeeenee
ewnwneenwnenwnwnenenenwneneneneswneswnene
wwwenwswwnewwwweswwwww
swseenwwswswnwnwswsewseswswseneeesw
swneseseswswswseseseswswseseseswsw
neneneenwneneswwnwnenwnesewnenewnwnee
swnwswswseswseseswseswswswswnwseswswsesese
wswwswwwwswswwswsweswwswswnwww
nwnwwneseseneenenenenenwwneswnwsenewne
wnwsenwwwwwnwwwneswwwwwnwnwnwe
swswseswneseswswsewswswswswswswswseswnee
swsesewswnewnenwsenwneswneswwwswwsw
swseswswswsesesesewswseeseswseeswsenwsw
seswswwseeswswenwswseswenwswwswsesw
neneneneneneneneneneneswneweneneneneene
swsweneenwnwsweeeeenweeeeee
neswnesenwwswwnweeswsweswnesewsww
nwesewnwseewswswnwwswneeenw
eeseenesewsweseswnweseesenwnesesee
wneswswswnwswweswnwwsweswnweswswesew
senwnenenenenenenewnewnenenwnesenwneswse
nesenweswnwnenwenenwnwnwswswnwnwnwsenene
seswsweswswwwswwswwwwwwwswnewsw
enwwwswswswswswswswswwswwseswswnenwswsw
nwewwenwwwewwswswwwwwwww
sewseneswesweweeweenwneeesee
nwnwwwewnwwnwnww
seseseeenwswwenwswswseenwseseeseeee
seseswseesenesenwsesenwsesewsesesesesese
wwswwsesewswswwswwwenewswwswsenene
nenwnwesenwnweswnwnwnwwnwnwnwswnwsee
seswswswswswseseseenesewwsesenwsesesenw
wswsweswsenwwwwswewneswsew
swneneweswenwswswseswswseswnwsesewswesw
nwnenwsweesenwwseswenwwwseswwswnw
wwnwenwnwnwnwswnwnwnwnwwnwnwnwwnw
swswswneneenwnenwnwnwsenwenwnwwwnweenw
nwnwwnenwenwswnwnwnwswwenwnwneneswnwnwsw
enwnweewenesesweeneneeeeeene
nwenwweeeeeenwneeeswseeeswse
nwseneeneneeeeneeeneeeneenenenesw
wwneswswswewswsesenewwseswswnwswsw
swseswswswswseswsesweswswswswswnwswswswnw
nwweswwseseeseseneswnesenweseesenewe
wnenwnwnwnwnwwnwnwnwsesenwnwnwnewnwsenwnw
nenenenwnwsenenwnwnwnwnenwnwnwnwnwnwnwsw
ewsweenwnweneeeseneweseeesew
wnwnwnwswswswswswseeswswwswswseswswe
nwwswnwneeeeswewwnwswnwenwswswenwnw
swswswneswsewswswnewne
swsesesenesewswseseseseswseswsesesesese
nenewneneneneneneneeeneweneneeenese
wwwwnwwwwwwwwwwwwsewnew
wwswswnwswwweswwwwwswwwwsww
nwnwnwnwnwnwsenwenenwneswnwsenwnwnenwnwnwse
neneneneneneenenwneseneeenee
eeneeeeneenwswnesenenweeeeenesw
swnenenwseewnesweseseenwsesewseswnwse
seseswnwsesesweseneswsesesenwseseseseswse
nesenenwnwnwnwnenenwnewnwnwnwnwnwnwnwne
nenwnwwswnenwenwsenwnwsewnwnwnwwww
neswswseswseswswsesenwswswseswnwsweswswne
nweneseswnwnwnewnwneenenewnwnwnenwnenenw
eeseneeswswnweswseesesenwnesesesesee
eseseswswswswneswwswswneseswswwswwsw
seseseneswewsesesesesenesesesesesesesese
swsweewnwsewwenwsenenewnwsenenee
wnwwwnwnwswwwenwseeenwnew
swnenwneseseswswswseswswseeswnwseswswswswe
nwnenwwwnenwwsenwnwsenenwnwnenwnwnwnwse
swnwnwnwnenenenwnwnwnwseneenewnwnwnwnwnene
wnwewnwwswwwnwnewwwnwnwwswwwnww
nwsenenwnenwnenenwnenwnewnwseswenenwnwne
neneseeeneneenewneneneneswnene
sweeenweeseweseseesewseeee
nwswseneeeneenwneneeeswseneswenwene
nwnwwnwnenwnwnwwnwnwswwwnw
wwnwwnwwwnwwnwwwewnwnwswnwenww
wwwwwswwwwwwwswwnwwswswswe
seswneswsenwweenwswnwseeneneswseseese
nwswsenwwseswseswswsenwewenwnenwnwew
swnenwnenwneneneneneneswnenenwnenenesene
weenenenwneeneneeneseese
nwnwnenwswnwseesewneenenenewnwne
eenweswenwseeneeeeseeeeeeew
seswsewseseseswseseseswsenwseseswnesesese
seseswseseseswnesesesewseseseswswswsese
wswswwswneseswwswnwswswwswswwwwsw
swswswseeswwswswswseswseneswswswseswsw
nwnwnwnwnwnwnwswenwnwnenwnwenew
nwnwnwnwnwenwnwnwnwwwnwnwwnwnwnwnw
nwesweenweeeeseesweeeeeeene
nwwwnwnwwnenwnwnwsw
nwnwswwnwnwnwnenwwsenwnweswnwnwenwnw
seseseesweseeenwseneeeee
nweeswswesenenweneswnwenwneweneesw
eeseswswseswwneswwneseseswwsenwseswe
neeneeneneeeweeseneneneneseneneew
nwsewnwnwnwwnwnwwnwsewwnwnwnwnwnwwnw
wswswneswwnwswwswweswwwswwsww
sesenwswseswseswseseeswseswnwsesesesese
nwenwnenwnwwnwnwnenwwenwnwnwnenwnene
sewseewswnwenwswneenenwnwnenewsww
nenwnwnwnwnwnwnwnwneswnwswsenwnenwnenwnwnw
seseseseseswseswwseseseeswseswswewsw
neseneenwwwsenesesenenwwe
wwswswneneswnwsewswswswsewswswseww
sewewswwwnwnwsenwnwsewnwwnwsewwnw
wnwnwwwwwnwewnwwnwnenwsww
wwswswswewwnewswnwwwwnesw
swwwwewnewnewswnwwnwnwsewnesenw
swnwnwnwnenenweswenwnwnwnwnwnwnwswsenwsw
eneneneswneeeneenene
swswnwswswswsweswswswswswswswswswswnwswnee
wwswwwswnweswwwnwwwweweew
wnwnenenenenenenwnenwnenwnesenenenenwnesenw
nenweenwnwsewenwneseswsenwnwnwsesesese
wwneeseswseesenenesweneswneswnenwnenw
swswswwswwwwswswnwswwwnewwwwswse
seeseswswsenwwswswsesenwswswesenwese";

    private const string testinput = @"sesenwnenenewseeswwswswwnenewsewsw
neeenesenwnwwswnenewnwwsewnenwseswesw
seswneswswsenwwnwse
nwnwneseeswswnenewneswwnewseswneseene
swweswneswnenwsewnwneneseenw
eesenwseswswnenwswnwnwsewwnwsene
sewnenenenesenwsewnenwwwse
wenwwweseeeweswwwnwwe
wsweesenenewnwwnwsenewsenwwsesesenwne
neeswseenwwswnwswswnw
nenwswwsewswnenenewsenwsenwnesesenew
enewnwewneswsewnwswenweswnenwsenwsw
sweneswneswneneenwnewenewwneswswnese
swwesenesewenwneswnwwneseswwne
enesenwswwswneneswsenwnewswseenwsese
wnwnesenesenenwwnenwsewesewsesesew
nenewswnwewswnenesenwnesewesw
eneswnwswnwsenenwnwnwwseeswneewsenese
neswnwewnwnwseenwseesewsenwsweewe
wseweeenwnesenwwwswnew";
    #endregion
    public override Task ExecuteAsync()
    {
        Counter<(int, int)> flipped = new Counter<(int, int)>();

        foreach (var line in Input.Split(Environment.NewLine))
        {
            (int x, int y) current = (1000, 1000);
            int dy = 0;
            foreach (var d in line)
            {
                if (d == 'n')
                {
                    dy = 1;
                }
                else if (d == 's')
                {
                    dy = -1;
                }
                else if (d == 'e')
                {
                    int dx = (dy == 0 || current.y % 2 == 1) ? 1 : 0;
                    current = (current.x + dx, current.y + dy);
                    dy = 0;
                }
                else if (d == 'w')
                {
                    int dx = (dy == 0 || current.y % 2 == 0) ? -1 : 0;
                    current = (current.x + dx, current.y + dy);
                    dy = 0;
                }
            }

            flipped[current]++;
        }

        Console.WriteLine("part 1: " + flipped.Values.Count(v => v % 2 == 1).ToString());

        HashSet<(int x, int y)> blackTiles = new HashSet<(int x, int y)>();
        foreach (var tile in flipped.Keys.Where(v => flipped[v] % 2 == 1))
        {
            blackTiles.Add(tile);
        }

        for (int i = 1; i <= 100; i++)
        {
            Step();
        }


        Result = blackTiles.Count.ToString();
        return Task.CompletedTask;


        void Step()
        {
            HashSet<(int x, int y)> newBlackTiles = new HashSet<(int x, int y)>();
            foreach (var blackTile in blackTiles)
            {
                var neighbours = Neighbours(blackTile).ToList();
                var count = neighbours.Count(n => blackTiles.Contains(n));
                if (count == 1 || count == 2)
                {
                    newBlackTiles.Add(blackTile);
                }

                foreach (var neighbour in neighbours)
                {
                    if (!blackTiles.Contains(neighbour))
                    {
                        var nextNeighbours = Neighbours(neighbour).ToList();
                        var nncount = nextNeighbours.Count(n => blackTiles.Contains(n));
                        if (nncount == 2)
                        {
                            newBlackTiles.Add(neighbour);
                        }
                    }
                }
            }
            blackTiles = newBlackTiles;
        }

        IEnumerable<(int, int)> Neighbours((int x, int y) blackTile)
        {
            yield return (blackTile.x - 1, blackTile.y);
            yield return (blackTile.x + 1, blackTile.y);
            var even = blackTile.y % 2 == 0;
            yield return (blackTile.x + (even ? -1 : 0), blackTile.y - 1);
            yield return (blackTile.x + (even ? 0 : 1), blackTile.y - 1);
            yield return (blackTile.x + (even ? -1 : 0), blackTile.y + 1);
            yield return (blackTile.x + (even ? 0 : 1), blackTile.y + 1);
        }
    }

    public override int Nummer => 202024;
}