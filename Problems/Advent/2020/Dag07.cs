using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problems.Advent._2020;

public class Dag07 : Problem
{
    #region input
    const string input = @"light gold bags contain 2 light lime bags, 1 faded green bag, 3 clear olive bags, 2 dim bronze bags.
muted beige bags contain 3 clear lime bags, 5 dark salmon bags, 1 pale olive bag.
vibrant violet bags contain 3 dark tomato bags, 3 muted indigo bags, 3 plaid turquoise bags, 3 light silver bags.
dull purple bags contain 2 wavy turquoise bags.
posh purple bags contain 4 bright lavender bags, 2 wavy chartreuse bags, 3 vibrant aqua bags.
striped gold bags contain 4 light magenta bags.
dark lime bags contain 3 plaid brown bags.
shiny salmon bags contain 5 light olive bags.
dull gold bags contain 2 dim plum bags.
dim olive bags contain 3 faded cyan bags.
faded white bags contain 2 clear brown bags, 1 mirrored green bag, 3 plaid bronze bags.
dull salmon bags contain 1 plaid gray bag, 4 vibrant aqua bags, 5 mirrored cyan bags.
striped orange bags contain 4 vibrant maroon bags, 2 dark orange bags.
dotted silver bags contain 2 posh red bags, 1 muted yellow bag, 5 light aqua bags, 3 pale red bags.
light orange bags contain 1 striped coral bag, 3 dim lime bags, 4 muted yellow bags.
wavy lime bags contain 5 light silver bags, 1 bright coral bag, 5 drab silver bags, 1 dark plum bag.
bright tan bags contain 3 clear magenta bags, 2 muted white bags, 2 drab beige bags, 5 plaid green bags.
dim violet bags contain 1 striped fuchsia bag, 2 mirrored green bags, 1 bright teal bag.
mirrored gold bags contain 1 pale aqua bag.
bright plum bags contain 1 faded fuchsia bag.
muted aqua bags contain 2 muted red bags.
plaid bronze bags contain 2 dim lime bags, 2 wavy coral bags, 1 vibrant lime bag, 1 dotted beige bag.
dim chartreuse bags contain 5 mirrored lime bags, 2 dotted tomato bags, 1 plaid turquoise bag.
muted lavender bags contain 4 faded salmon bags, 3 bright white bags, 3 posh fuchsia bags, 1 dotted green bag.
mirrored yellow bags contain 1 wavy purple bag, 5 shiny teal bags, 5 shiny cyan bags, 1 shiny crimson bag.
striped magenta bags contain 4 dim white bags, 2 pale white bags.
dull crimson bags contain 3 muted black bags, 4 dull lavender bags.
mirrored beige bags contain 2 posh indigo bags, 3 shiny gray bags.
bright blue bags contain 5 mirrored fuchsia bags.
plaid beige bags contain 3 mirrored cyan bags, 1 vibrant tan bag, 5 muted purple bags, 1 wavy red bag.
dotted indigo bags contain 5 pale fuchsia bags, 5 posh tomato bags.
muted coral bags contain 4 dim crimson bags, 3 dark brown bags, 2 drab fuchsia bags.
drab tomato bags contain 1 muted tan bag, 2 dark salmon bags, 4 faded red bags, 5 shiny olive bags.
dark tomato bags contain 5 mirrored salmon bags.
bright yellow bags contain 4 light teal bags, 1 posh white bag, 2 shiny blue bags.
dotted salmon bags contain 3 drab olive bags.
vibrant olive bags contain 2 posh teal bags, 1 clear aqua bag.
dotted gold bags contain 4 striped violet bags.
light tan bags contain 2 plaid fuchsia bags, 1 faded turquoise bag, 2 muted tomato bags.
drab orange bags contain 3 wavy violet bags, 1 dark fuchsia bag, 2 mirrored green bags.
dull coral bags contain 1 dark crimson bag.
light purple bags contain 4 dark gold bags, 3 plaid purple bags, 4 clear chartreuse bags.
wavy yellow bags contain 3 striped silver bags, 2 dull chartreuse bags.
dull tan bags contain 1 dim gold bag.
vibrant plum bags contain 4 dotted turquoise bags, 1 faded gray bag.
wavy tan bags contain 4 shiny plum bags, 5 faded white bags, 1 plaid plum bag.
dim indigo bags contain 2 clear blue bags.
muted teal bags contain 4 mirrored fuchsia bags, 5 faded black bags.
dark maroon bags contain 5 mirrored gold bags, 5 bright red bags, 1 faded gray bag.
mirrored aqua bags contain 4 faded turquoise bags, 1 mirrored tan bag.
muted violet bags contain 4 mirrored lavender bags, 3 faded salmon bags.
wavy orange bags contain 3 drab crimson bags, 5 posh indigo bags, 2 faded cyan bags, 5 light blue bags.
mirrored blue bags contain 1 dark teal bag, 4 pale orange bags.
muted silver bags contain 2 dim orange bags, 1 posh plum bag, 2 wavy fuchsia bags.
plaid magenta bags contain 3 faded blue bags, 5 vibrant lime bags, 2 faded beige bags.
dark lavender bags contain 3 clear olive bags.
posh salmon bags contain 4 dark orange bags.
dim silver bags contain 3 plaid blue bags, 1 posh brown bag, 1 striped white bag.
posh chartreuse bags contain 3 drab plum bags, 3 mirrored brown bags.
shiny cyan bags contain 4 faded plum bags, 5 wavy yellow bags, 2 drab maroon bags.
drab bronze bags contain 2 shiny turquoise bags, 4 faded white bags, 4 drab white bags.
dotted cyan bags contain 1 posh brown bag, 2 dark orange bags, 4 plaid bronze bags.
shiny beige bags contain 5 dotted cyan bags, 2 pale indigo bags.
drab violet bags contain 4 posh chartreuse bags, 1 drab fuchsia bag.
muted tomato bags contain 2 posh aqua bags.
drab plum bags contain 5 drab gold bags, 4 dark fuchsia bags, 5 pale gold bags, 3 dim olive bags.
dim brown bags contain 1 drab indigo bag, 2 pale gold bags, 5 posh fuchsia bags.
plaid cyan bags contain 1 light orange bag, 2 bright violet bags.
striped silver bags contain 2 shiny silver bags.
plaid tomato bags contain 3 drab cyan bags, 4 clear chartreuse bags, 3 dim coral bags, 4 shiny gray bags.
posh tomato bags contain 1 plaid bronze bag, 1 dim lime bag.
vibrant orange bags contain 5 bright aqua bags, 2 drab coral bags, 4 dull aqua bags, 3 vibrant lavender bags.
drab brown bags contain 1 bright orange bag, 3 drab salmon bags.
plaid crimson bags contain 3 dull red bags, 3 posh maroon bags, 2 dull beige bags.
clear aqua bags contain 5 muted cyan bags, 1 dotted teal bag.
pale magenta bags contain 2 light brown bags.
mirrored chartreuse bags contain 3 striped gold bags, 3 light silver bags, 3 dim red bags, 3 dim chartreuse bags.
mirrored plum bags contain 2 striped tomato bags, 1 posh aqua bag, 1 muted teal bag, 2 faded indigo bags.
posh teal bags contain 5 clear indigo bags, 5 plaid purple bags, 4 pale white bags, 3 drab gray bags.
wavy aqua bags contain 4 drab beige bags, 5 plaid black bags.
drab coral bags contain 3 striped tomato bags, 1 dotted cyan bag.
shiny chartreuse bags contain 2 mirrored cyan bags.
striped gray bags contain 5 striped tomato bags.
shiny orange bags contain 4 muted purple bags, 4 dim silver bags, 5 shiny gold bags, 3 pale orange bags.
dark teal bags contain no other bags.
dark magenta bags contain 4 pale gray bags, 1 dim purple bag, 4 drab coral bags.
vibrant fuchsia bags contain 4 dull olive bags.
light bronze bags contain 2 plaid gold bags, 2 dark white bags.
dotted yellow bags contain 5 bright indigo bags, 2 light silver bags, 3 wavy red bags.
muted purple bags contain 1 shiny blue bag, 5 faded red bags, 1 dim olive bag.
faded cyan bags contain 1 dark teal bag.
dull brown bags contain 5 vibrant aqua bags.
shiny white bags contain 2 dull red bags, 1 plaid orange bag, 5 muted turquoise bags.
light brown bags contain 4 dim coral bags, 3 faded red bags.
bright orange bags contain 5 dull olive bags.
light lime bags contain 4 light magenta bags, 5 muted violet bags.
shiny indigo bags contain 2 bright blue bags, 1 dotted turquoise bag, 2 clear bronze bags.
faded teal bags contain 4 bright brown bags, 1 light silver bag.
posh bronze bags contain 3 dark salmon bags, 2 plaid fuchsia bags, 1 dim white bag, 5 faded maroon bags.
shiny yellow bags contain 1 posh lime bag.
dotted beige bags contain no other bags.
vibrant blue bags contain 2 posh green bags, 1 faded white bag, 2 plaid red bags, 4 posh violet bags.
posh lime bags contain 4 bright aqua bags.
posh coral bags contain 5 plaid white bags, 3 faded coral bags.
dark yellow bags contain 3 wavy violet bags, 5 clear chartreuse bags, 5 light turquoise bags.
wavy bronze bags contain 2 clear brown bags, 2 muted cyan bags.
faded brown bags contain 5 dim lime bags, 4 dotted beige bags, 3 wavy coral bags, 1 faded gray bag.
vibrant gold bags contain 2 dotted maroon bags.
vibrant red bags contain 4 dull black bags.
clear beige bags contain 4 dim olive bags, 3 plaid bronze bags, 3 clear brown bags, 5 vibrant lime bags.
dim teal bags contain 4 plaid bronze bags, 5 striped tan bags, 1 muted olive bag.
dim aqua bags contain 1 faded lime bag, 4 faded gray bags, 1 posh coral bag.
faded tan bags contain 5 clear lime bags, 4 shiny violet bags, 2 dull aqua bags.
mirrored green bags contain no other bags.
light magenta bags contain 5 plaid gold bags.
striped white bags contain 1 wavy coral bag, 1 faded gray bag, 3 vibrant lime bags, 2 mirrored fuchsia bags.
plaid violet bags contain 3 faded indigo bags, 1 striped fuchsia bag, 5 drab salmon bags, 4 mirrored cyan bags.
dull cyan bags contain 4 dark chartreuse bags, 3 light gray bags.
light salmon bags contain 2 dark teal bags.
drab crimson bags contain 3 vibrant tan bags.
striped yellow bags contain 5 faded brown bags, 4 posh olive bags.
pale orange bags contain no other bags.
faded gold bags contain 5 light magenta bags.
faded beige bags contain 1 faded indigo bag, 5 wavy green bags, 5 faded crimson bags.
striped crimson bags contain 2 posh brown bags.
dark black bags contain 4 plaid lavender bags, 5 mirrored salmon bags.
bright beige bags contain 1 bright brown bag, 5 posh aqua bags.
bright gold bags contain 3 light lime bags, 2 shiny white bags.
bright tomato bags contain 4 dull orange bags, 4 dull blue bags.
light olive bags contain 4 dull blue bags, 4 plaid gray bags, 4 faded gray bags.
vibrant lavender bags contain 1 clear salmon bag, 2 bright lavender bags.
drab yellow bags contain 1 plaid black bag.
faded green bags contain 1 clear brown bag, 4 mirrored orange bags, 1 striped tan bag.
vibrant black bags contain 4 mirrored fuchsia bags.
bright indigo bags contain 5 plaid red bags, 1 striped chartreuse bag, 3 vibrant plum bags, 5 dark lavender bags.
dull plum bags contain 2 mirrored plum bags, 2 light silver bags, 1 pale indigo bag.
striped bronze bags contain 2 dotted blue bags.
muted magenta bags contain 2 dim silver bags, 5 clear purple bags.
striped teal bags contain 5 vibrant white bags.
dim bronze bags contain 2 dim crimson bags, 4 vibrant beige bags, 2 wavy turquoise bags.
shiny lavender bags contain 4 dim purple bags.
vibrant silver bags contain 1 dotted crimson bag, 2 dotted maroon bags.
posh yellow bags contain 4 bright salmon bags, 4 shiny lavender bags, 5 mirrored aqua bags.
faded bronze bags contain 2 posh brown bags, 3 clear lime bags, 4 dotted red bags, 2 striped white bags.
posh maroon bags contain 5 striped salmon bags, 1 light black bag.
pale aqua bags contain 2 shiny orange bags, 1 shiny silver bag, 2 dim violet bags.
plaid chartreuse bags contain 2 muted black bags, 4 muted magenta bags, 1 mirrored bronze bag, 1 posh beige bag.
dotted orange bags contain 2 drab indigo bags.
plaid gold bags contain 3 drab beige bags.
shiny silver bags contain 2 dull teal bags, 5 drab gray bags, 4 bright blue bags, 2 dotted cyan bags.
mirrored crimson bags contain 2 shiny gold bags, 5 plaid black bags, 3 drab beige bags, 1 pale beige bag.
pale gold bags contain 1 striped tomato bag, 5 striped white bags, 2 mirrored bronze bags, 5 dim orange bags.
vibrant crimson bags contain 5 faded white bags, 2 wavy coral bags.
dim yellow bags contain 1 vibrant coral bag, 5 faded red bags, 4 mirrored magenta bags, 4 posh indigo bags.
dull teal bags contain 1 plaid fuchsia bag, 3 striped blue bags.
striped red bags contain 4 dull lime bags.
muted chartreuse bags contain 5 bright crimson bags.
dim lavender bags contain 2 posh maroon bags.
wavy crimson bags contain 1 dim magenta bag, 4 dim crimson bags, 1 dull lavender bag, 3 muted fuchsia bags.
dull green bags contain 5 dull olive bags, 1 clear blue bag, 5 shiny salmon bags.
wavy red bags contain 1 dull chartreuse bag, 3 dim black bags.
pale blue bags contain 4 light olive bags, 3 vibrant chartreuse bags.
dull fuchsia bags contain 2 posh chartreuse bags.
dotted violet bags contain 1 shiny olive bag, 3 bright blue bags, 5 posh beige bags, 4 vibrant black bags.
drab white bags contain 1 plaid gold bag, 5 clear olive bags.
drab blue bags contain 3 muted bronze bags, 5 shiny gold bags, 4 dim olive bags.
plaid salmon bags contain 5 pale gold bags.
pale coral bags contain 3 plaid orange bags, 3 plaid fuchsia bags, 5 drab teal bags.
vibrant maroon bags contain 3 dim lime bags, 2 pale beige bags, 5 mirrored green bags.
mirrored magenta bags contain 2 striped blue bags.
faded blue bags contain 3 vibrant bronze bags, 2 clear maroon bags, 1 faded white bag, 3 dark cyan bags.
drab olive bags contain 5 wavy teal bags, 3 mirrored black bags, 5 dark gray bags, 5 dull lime bags.
posh white bags contain 1 plaid purple bag, 4 dark turquoise bags, 3 clear salmon bags, 1 dim orange bag.
dull red bags contain 4 vibrant plum bags, 3 plaid black bags, 4 dull orange bags.
striped tan bags contain no other bags.
posh blue bags contain 3 mirrored magenta bags, 1 dark plum bag, 4 wavy turquoise bags, 1 shiny coral bag.
drab salmon bags contain 2 bright aqua bags, 4 posh gold bags, 5 plaid blue bags.
striped green bags contain 5 dim black bags.
wavy salmon bags contain 5 pale purple bags.
vibrant cyan bags contain 1 dark gray bag, 1 vibrant beige bag, 5 drab violet bags, 5 dull coral bags.
wavy lavender bags contain 1 light magenta bag, 2 striped cyan bags.
faded maroon bags contain 5 light gray bags.
vibrant yellow bags contain 2 bright beige bags, 5 dim brown bags, 2 posh silver bags, 2 pale cyan bags.
dotted tomato bags contain 3 mirrored magenta bags, 3 wavy chartreuse bags, 2 wavy maroon bags.
striped lavender bags contain 4 shiny coral bags, 2 dim white bags, 3 faded red bags.
faded red bags contain 2 mirrored fuchsia bags, 1 light cyan bag, 2 vibrant lime bags, 1 mirrored green bag.
clear black bags contain 3 drab purple bags, 2 bright yellow bags, 2 wavy brown bags.
faded indigo bags contain 1 dim lime bag, 1 clear brown bag.
shiny tan bags contain 1 dull brown bag, 2 striped tomato bags.
drab teal bags contain 1 dotted turquoise bag, 4 posh fuchsia bags.
wavy magenta bags contain 1 dim yellow bag, 3 drab indigo bags.
mirrored turquoise bags contain no other bags.
faded lime bags contain 4 drab cyan bags, 1 clear orange bag, 5 vibrant salmon bags, 5 faded crimson bags.
vibrant coral bags contain 5 pale gray bags, 2 clear salmon bags.
muted turquoise bags contain 1 clear brown bag.
plaid aqua bags contain 3 dull coral bags.
pale indigo bags contain 1 striped brown bag, 2 bright cyan bags, 5 plaid silver bags.
faded tomato bags contain 1 pale red bag, 2 dotted tan bags.
mirrored white bags contain 4 drab fuchsia bags, 3 plaid orange bags, 4 dotted lavender bags.
shiny aqua bags contain 1 wavy silver bag, 4 drab green bags, 1 bright tomato bag.
pale cyan bags contain 1 pale gold bag, 5 dark turquoise bags.
mirrored salmon bags contain 5 light crimson bags, 5 muted bronze bags, 2 vibrant beige bags, 1 striped lavender bag.
dark gold bags contain 1 shiny olive bag.
muted blue bags contain 2 vibrant maroon bags, 5 wavy chartreuse bags.
bright fuchsia bags contain 1 posh white bag.
light blue bags contain 5 muted beige bags, 1 dark crimson bag, 5 mirrored brown bags, 1 posh orange bag.
clear salmon bags contain 1 faded brown bag, 5 dotted beige bags, 4 faded gray bags, 4 dark orange bags.
plaid red bags contain 3 drab silver bags, 2 dim green bags.
faded plum bags contain 2 posh orange bags, 5 dotted lime bags.
bright coral bags contain 3 plaid plum bags, 1 dark green bag, 2 striped crimson bags, 5 vibrant coral bags.
shiny crimson bags contain 5 bright teal bags, 4 muted magenta bags, 4 vibrant maroon bags, 3 faded cyan bags.
dim magenta bags contain 1 muted olive bag, 1 bright blue bag, 4 muted white bags, 5 posh gray bags.
pale brown bags contain 4 dotted cyan bags, 5 bright coral bags.
striped olive bags contain 2 bright brown bags, 4 pale gray bags, 5 dotted teal bags, 3 pale white bags.
posh gray bags contain 1 dark chartreuse bag.
dotted brown bags contain 3 plaid gold bags, 5 dim bronze bags.
dim lime bags contain no other bags.
clear crimson bags contain 2 posh orange bags, 2 plaid plum bags, 1 dark orange bag.
shiny turquoise bags contain 1 faded indigo bag, 3 light red bags.
striped plum bags contain 1 muted white bag.
muted crimson bags contain 1 bright teal bag.
plaid blue bags contain 3 dotted beige bags, 5 vibrant lime bags, 1 vibrant tan bag, 2 striped blue bags.
light teal bags contain 2 dotted cyan bags.
faded salmon bags contain 5 mirrored crimson bags.
shiny blue bags contain 4 posh gold bags, 3 light cyan bags, 1 clear teal bag.
plaid brown bags contain 2 dull lavender bags.
muted bronze bags contain 3 faded purple bags.
posh fuchsia bags contain 5 striped coral bags.
clear orange bags contain 1 bright blue bag, 5 posh gold bags, 5 striped crimson bags, 1 dark teal bag.
plaid plum bags contain 5 faded brown bags.
clear gray bags contain 4 mirrored fuchsia bags, 2 dim cyan bags, 3 pale gold bags, 1 dim violet bag.
bright lavender bags contain 1 mirrored purple bag, 4 wavy magenta bags, 2 dull black bags, 3 light silver bags.
pale purple bags contain 3 striped tan bags, 1 dull olive bag.
pale bronze bags contain 2 plaid aqua bags, 2 pale fuchsia bags, 4 bright lime bags.
clear blue bags contain 3 plaid beige bags.
drab silver bags contain 3 dim violet bags, 1 muted yellow bag, 1 pale beige bag.
dark silver bags contain 4 dark fuchsia bags, 4 bright green bags, 5 dim beige bags, 1 light tomato bag.
mirrored gray bags contain 2 striped black bags.
posh black bags contain 3 dull indigo bags, 3 striped beige bags, 3 dim blue bags, 2 wavy lime bags.
clear teal bags contain 2 dark orange bags, 4 pale beige bags, 5 clear beige bags, 4 dark teal bags.
pale white bags contain 2 drab gray bags, 1 muted olive bag.
muted fuchsia bags contain 2 clear brown bags, 4 mirrored green bags, 2 striped tan bags.
bright cyan bags contain 1 dotted plum bag.
light tomato bags contain 2 dim violet bags, 1 pale green bag, 4 dim orange bags, 1 dotted tomato bag.
pale turquoise bags contain 2 plaid black bags, 2 clear brown bags.
dim orange bags contain 1 plaid plum bag, 2 clear indigo bags, 1 dotted blue bag, 1 drab beige bag.
posh red bags contain 5 faded brown bags, 4 clear gray bags, 5 bright teal bags.
bright teal bags contain 4 clear beige bags.
posh lavender bags contain 1 drab beige bag, 5 dim salmon bags, 3 light crimson bags.
drab green bags contain 1 striped brown bag, 1 dull blue bag, 1 plaid coral bag.
clear coral bags contain 1 faded crimson bag, 4 light silver bags, 1 posh violet bag.
dark tan bags contain 5 faded brown bags.
vibrant aqua bags contain 1 light cyan bag, 5 bright brown bags.
dark blue bags contain 1 dark silver bag.
drab lime bags contain 3 faded white bags, 5 clear tomato bags, 1 dark turquoise bag.
faded lavender bags contain 1 bright violet bag, 4 posh gold bags.
dark orange bags contain 2 striped tan bags.
plaid orange bags contain 4 dark beige bags, 5 dull lavender bags, 4 striped white bags.
vibrant chartreuse bags contain 1 faded indigo bag, 4 clear magenta bags, 2 shiny blue bags, 2 dull teal bags.
dim white bags contain 3 faded white bags, 2 clear teal bags.
dim cyan bags contain 4 clear olive bags, 4 pale gray bags, 5 plaid bronze bags.
dotted chartreuse bags contain 1 bright magenta bag, 5 shiny maroon bags.
dull aqua bags contain 2 drab beige bags.
clear violet bags contain 3 pale teal bags, 3 posh tomato bags, 1 light silver bag, 2 faded coral bags.
pale lavender bags contain 1 drab beige bag, 2 dark teal bags.
clear tomato bags contain 5 muted beige bags, 1 plaid gold bag, 3 vibrant coral bags, 3 shiny silver bags.
clear cyan bags contain 4 faded lime bags, 2 drab tomato bags.
striped salmon bags contain 3 dim silver bags.
wavy silver bags contain 2 drab blue bags, 4 shiny green bags, 3 muted yellow bags.
dull indigo bags contain 5 mirrored plum bags.
faded coral bags contain 2 muted olive bags, 4 dark salmon bags.
muted olive bags contain 5 faded red bags, 1 dim lime bag, 1 striped white bag, 4 dark teal bags.
dotted plum bags contain 5 plaid blue bags.
striped cyan bags contain 4 mirrored plum bags, 2 wavy beige bags.
dotted olive bags contain 3 mirrored gold bags, 4 bright lavender bags, 2 dim turquoise bags.
plaid green bags contain 5 dark chartreuse bags, 5 mirrored bronze bags, 5 dark beige bags.
clear chartreuse bags contain 5 posh olive bags, 3 plaid violet bags, 3 mirrored fuchsia bags, 2 light orange bags.
wavy indigo bags contain 2 shiny teal bags, 3 clear olive bags.
shiny fuchsia bags contain 5 striped chartreuse bags, 1 light chartreuse bag.
shiny coral bags contain 4 dotted plum bags, 4 dull orange bags, 3 posh olive bags, 2 dark salmon bags.
bright black bags contain 5 drab gray bags, 1 vibrant black bag, 3 vibrant salmon bags, 3 dim silver bags.
bright salmon bags contain 1 shiny plum bag, 4 bright brown bags, 5 pale gray bags, 3 mirrored maroon bags.
faded yellow bags contain 1 light blue bag, 2 striped white bags, 3 dim lime bags, 4 wavy cyan bags.
plaid fuchsia bags contain 1 striped blue bag.
plaid lime bags contain 3 clear bronze bags, 4 dull orange bags, 1 pale aqua bag.
clear turquoise bags contain 1 posh aqua bag, 5 plaid black bags, 4 vibrant brown bags.
dull lime bags contain 3 mirrored crimson bags, 1 dotted crimson bag, 2 light lime bags, 2 light gray bags.
dull gray bags contain 5 bright lavender bags, 3 muted olive bags.
dotted turquoise bags contain 2 dim olive bags, 1 striped blue bag, 4 clear indigo bags.
vibrant purple bags contain 4 light olive bags, 4 mirrored salmon bags, 4 muted red bags.
dark cyan bags contain 2 dim lime bags, 5 light olive bags, 4 muted red bags, 3 drab indigo bags.
vibrant turquoise bags contain 4 light indigo bags.
bright bronze bags contain 2 pale green bags, 5 faded gray bags.
clear maroon bags contain 3 faded coral bags.
faded purple bags contain 5 plaid plum bags, 3 striped blue bags, 2 vibrant tan bags, 3 dark orange bags.
light indigo bags contain 2 wavy bronze bags, 5 bright lime bags, 4 drab lime bags, 2 dotted chartreuse bags.
dotted bronze bags contain 5 faded brown bags, 4 drab silver bags, 3 drab chartreuse bags.
mirrored lavender bags contain 3 dim salmon bags.
clear gold bags contain 1 dull plum bag.
vibrant beige bags contain 5 drab crimson bags.
dull yellow bags contain 5 mirrored green bags, 4 plaid bronze bags, 5 plaid blue bags, 4 dull orange bags.
dotted black bags contain 2 dull fuchsia bags, 2 light fuchsia bags, 3 mirrored lavender bags, 1 muted coral bag.
dotted maroon bags contain 3 plaid coral bags, 5 dotted cyan bags.
dim tomato bags contain 4 pale tomato bags, 3 striped beige bags.
wavy violet bags contain 4 mirrored crimson bags, 4 plaid bronze bags, 4 faded turquoise bags, 4 drab chartreuse bags.
shiny bronze bags contain 3 muted chartreuse bags, 3 drab gold bags.
faded fuchsia bags contain 1 bright blue bag, 1 dim purple bag, 1 dim magenta bag.
plaid turquoise bags contain 2 shiny olive bags, 5 dull orange bags, 2 dark fuchsia bags, 3 clear purple bags.
mirrored teal bags contain 4 drab cyan bags, 2 striped green bags.
clear purple bags contain 3 dull teal bags, 2 vibrant tan bags, 5 vibrant maroon bags.
dotted blue bags contain 2 muted white bags, 2 dark green bags, 2 faded purple bags, 2 plaid blue bags.
light violet bags contain 5 dark salmon bags, 5 striped orange bags.
light beige bags contain 2 muted chartreuse bags, 4 striped brown bags, 3 wavy maroon bags.
wavy purple bags contain 4 dark violet bags, 3 drab fuchsia bags, 4 dull lavender bags, 3 drab lime bags.
light silver bags contain 4 posh brown bags, 3 vibrant crimson bags.
wavy white bags contain 5 mirrored fuchsia bags, 2 dotted turquoise bags, 5 striped tomato bags.
striped purple bags contain 4 dull chartreuse bags.
wavy teal bags contain 1 light chartreuse bag, 3 dark green bags.
vibrant indigo bags contain 2 dim coral bags.
pale red bags contain 3 drab cyan bags, 1 muted tan bag.
dark aqua bags contain 2 faded brown bags, 1 shiny gold bag, 3 light cyan bags, 2 light green bags.
dotted tan bags contain 2 drab beige bags, 2 faded gray bags.
faded aqua bags contain 5 faded brown bags.
drab turquoise bags contain 5 drab teal bags.
dark turquoise bags contain 2 dim teal bags, 1 dim coral bag, 1 clear beige bag.
wavy maroon bags contain 1 dim violet bag, 4 clear bronze bags.
dark gray bags contain 2 bright blue bags.
mirrored coral bags contain 1 clear lime bag, 1 posh gray bag.
dim red bags contain 3 plaid aqua bags, 4 plaid salmon bags, 3 pale gray bags, 4 wavy indigo bags.
dull maroon bags contain 3 light silver bags, 1 dim lime bag, 2 striped silver bags.
vibrant salmon bags contain 1 dark gray bag, 2 dotted cyan bags, 2 drab gray bags, 3 muted tan bags.
vibrant lime bags contain no other bags.
wavy blue bags contain 5 bright maroon bags, 2 dull plum bags, 4 pale magenta bags.
dim purple bags contain 3 dull indigo bags.
muted indigo bags contain 5 posh orange bags, 4 dim yellow bags.
posh gold bags contain 2 clear beige bags, 3 vibrant lime bags.
plaid purple bags contain 4 faded brown bags, 3 shiny blue bags, 1 faded white bag.
clear lime bags contain 5 posh aqua bags, 2 posh fuchsia bags, 1 clear teal bag, 4 faded cyan bags.
bright brown bags contain 5 plaid bronze bags, 4 faded indigo bags.
striped maroon bags contain 1 faded turquoise bag, 3 drab cyan bags, 5 dark gray bags, 2 pale black bags.
faded violet bags contain 4 drab crimson bags.
muted brown bags contain 2 bright tomato bags, 3 dim gold bags, 5 dull blue bags.
posh magenta bags contain 2 dark fuchsia bags.
vibrant green bags contain 3 dark fuchsia bags.
shiny tomato bags contain 2 light turquoise bags, 5 drab green bags, 1 posh gold bag.
faded olive bags contain 1 shiny purple bag, 4 wavy tan bags, 4 wavy violet bags, 1 muted fuchsia bag.
mirrored fuchsia bags contain 1 clear brown bag.
faded magenta bags contain 3 striped white bags, 3 posh tomato bags, 3 striped lime bags.
dim crimson bags contain 5 mirrored brown bags, 1 faded black bag, 1 dark orange bag.
dark green bags contain 2 dotted beige bags, 5 plaid blue bags.
dotted purple bags contain 4 shiny black bags, 1 muted violet bag, 1 drab green bag, 3 faded yellow bags.
posh turquoise bags contain 3 shiny plum bags.
muted gray bags contain 4 dull gray bags, 4 posh teal bags, 5 plaid gray bags.
shiny teal bags contain 2 pale beige bags.
shiny olive bags contain 1 striped tan bag, 3 mirrored turquoise bags.
dull white bags contain 2 pale orange bags, 1 dim magenta bag, 4 drab maroon bags.
drab aqua bags contain 1 wavy red bag.
dotted teal bags contain 3 shiny green bags, 3 drab beige bags, 1 drab crimson bag.
light cyan bags contain 2 mirrored green bags, 5 dotted beige bags, 5 faded white bags, 3 mirrored fuchsia bags.
dim maroon bags contain 1 drab fuchsia bag, 1 mirrored salmon bag.
mirrored maroon bags contain 4 muted white bags, 2 striped tan bags, 2 dark teal bags.
dark brown bags contain 1 striped bronze bag, 5 striped plum bags, 3 muted bronze bags, 2 striped lime bags.
plaid gray bags contain 1 clear brown bag, 5 shiny orange bags, 4 posh bronze bags, 5 light cyan bags.
dim gold bags contain 4 striped tomato bags, 5 striped fuchsia bags, 4 striped white bags, 1 clear brown bag.
drab tan bags contain 5 plaid fuchsia bags, 1 dim teal bag, 4 plaid gold bags.
bright aqua bags contain 4 faded indigo bags, 3 shiny blue bags, 4 posh aqua bags, 5 wavy tan bags.
pale lime bags contain 4 muted blue bags, 5 wavy purple bags.
plaid maroon bags contain 2 dim black bags, 1 drab indigo bag.
wavy gray bags contain 4 drab orange bags.
drab gold bags contain 1 dark gray bag, 4 pale gold bags.
plaid teal bags contain 2 dim teal bags, 1 vibrant lavender bag.
dark salmon bags contain 4 plaid black bags, 2 dim lime bags, 4 pale orange bags, 3 pale beige bags.
plaid lavender bags contain 3 faded red bags, 2 plaid aqua bags.
light fuchsia bags contain 3 dim violet bags.
faded chartreuse bags contain 2 mirrored gold bags, 5 drab gold bags, 3 mirrored salmon bags.
wavy beige bags contain 2 dotted salmon bags, 4 muted white bags.
striped tomato bags contain 4 drab cyan bags.
dotted white bags contain 4 bright green bags, 1 light brown bag.
muted yellow bags contain 3 dim violet bags, 1 posh aqua bag, 2 muted teal bags.
light chartreuse bags contain 4 posh aqua bags, 2 dim coral bags.
muted maroon bags contain 1 mirrored cyan bag, 4 dim olive bags.
pale yellow bags contain 3 bright olive bags.
dull bronze bags contain 2 plaid maroon bags, 2 vibrant bronze bags.
shiny gold bags contain 5 clear brown bags, 5 plaid fuchsia bags, 4 bright teal bags, 1 striped white bag.
posh crimson bags contain 4 vibrant plum bags.
clear silver bags contain 5 dim beige bags, 1 dark olive bag.
striped violet bags contain 5 posh orange bags, 1 vibrant crimson bag.
muted green bags contain 1 bright crimson bag.
shiny gray bags contain 4 striped maroon bags, 5 muted plum bags, 2 light chartreuse bags.
wavy turquoise bags contain 1 pale gold bag.
clear olive bags contain 4 plaid fuchsia bags.
drab indigo bags contain 1 clear purple bag, 4 light silver bags, 2 mirrored cyan bags, 2 clear lime bags.
dim salmon bags contain 1 pale aqua bag, 5 posh fuchsia bags, 4 plaid coral bags, 1 pale orange bag.
light black bags contain 3 muted chartreuse bags.
plaid indigo bags contain 3 plaid fuchsia bags, 2 muted tomato bags, 3 muted bronze bags, 1 drab white bag.
light crimson bags contain 2 striped chartreuse bags, 4 bright teal bags, 3 striped fuchsia bags.
bright purple bags contain 2 shiny violet bags.
dark bronze bags contain 3 striped violet bags, 4 clear beige bags.
dark white bags contain 5 faded white bags, 5 striped fuchsia bags, 2 vibrant lime bags, 5 striped tan bags.
mirrored orange bags contain 4 wavy aqua bags.
mirrored cyan bags contain 5 bright bronze bags.
dull blue bags contain 2 bright brown bags, 2 dim plum bags.
posh indigo bags contain 1 posh lime bag.
vibrant brown bags contain 1 bright indigo bag, 2 striped purple bags, 5 mirrored lime bags, 2 plaid plum bags.
wavy coral bags contain no other bags.
posh cyan bags contain 1 plaid plum bag, 2 plaid gold bags, 3 shiny plum bags.
vibrant tan bags contain 5 mirrored turquoise bags, 3 faded gray bags, 5 posh brown bags, 3 clear brown bags.
mirrored black bags contain 5 striped fuchsia bags, 1 striped tan bag, 3 pale green bags.
bright olive bags contain 1 bright orange bag, 4 drab gold bags, 3 dim cyan bags, 2 drab plum bags.
striped blue bags contain 3 dark white bags, 1 clear beige bag, 3 dim olive bags.
dim turquoise bags contain 4 muted turquoise bags, 1 dotted tomato bag, 4 muted brown bags.
posh green bags contain 4 dim gray bags, 4 clear brown bags.
dull magenta bags contain 3 bright plum bags.
dark red bags contain 2 muted magenta bags, 2 dark beige bags, 2 shiny black bags.
pale black bags contain 2 striped bronze bags.
dotted red bags contain 2 striped blue bags, 3 dim violet bags, 3 faded maroon bags.
dark chartreuse bags contain 5 striped orange bags, 5 dark white bags.
clear lavender bags contain 2 faded crimson bags, 5 clear purple bags, 3 vibrant tan bags.
vibrant white bags contain 1 drab crimson bag, 5 dim violet bags.
drab lavender bags contain 3 clear yellow bags, 5 shiny tan bags.
wavy cyan bags contain 5 shiny violet bags.
faded black bags contain 2 posh aqua bags, 5 bright teal bags, 1 posh orange bag, 4 vibrant coral bags.
mirrored tomato bags contain 3 muted cyan bags, 3 drab brown bags, 1 striped orange bag.
faded orange bags contain 3 plaid fuchsia bags, 5 mirrored crimson bags, 2 pale aqua bags, 2 dull lavender bags.
muted salmon bags contain 1 wavy tan bag, 2 muted chartreuse bags, 2 posh green bags, 5 shiny magenta bags.
pale plum bags contain 4 dull teal bags, 1 striped violet bag, 2 wavy crimson bags, 2 posh violet bags.
shiny magenta bags contain 3 muted yellow bags, 5 light beige bags, 1 dull white bag, 4 striped lavender bags.
plaid black bags contain 4 mirrored green bags.
clear plum bags contain 5 posh violet bags.
bright silver bags contain 2 dull yellow bags, 3 striped red bags, 3 dotted olive bags, 5 bright salmon bags.
muted gold bags contain 1 dull olive bag.
vibrant tomato bags contain 4 shiny blue bags, 1 bright indigo bag.
dim black bags contain 1 plaid gold bag, 2 muted white bags.
plaid white bags contain 2 muted cyan bags, 1 mirrored magenta bag, 3 striped red bags, 2 striped violet bags.
drab maroon bags contain 1 dotted cyan bag, 3 shiny orange bags.
shiny purple bags contain 3 posh purple bags.
shiny violet bags contain 3 dark teal bags, 3 shiny olive bags, 4 dull cyan bags, 1 dim plum bag.
dull chartreuse bags contain 2 bright tan bags, 2 wavy fuchsia bags, 4 bright teal bags, 1 posh violet bag.
striped fuchsia bags contain 5 dotted beige bags.
muted lime bags contain 1 vibrant tan bag.
dotted coral bags contain 5 mirrored magenta bags, 4 wavy blue bags.
bright turquoise bags contain 5 pale indigo bags.
bright maroon bags contain 4 plaid salmon bags, 3 wavy coral bags, 4 dull orange bags, 1 pale green bag.
dim green bags contain 4 posh olive bags, 4 dim white bags, 3 clear orange bags.
mirrored bronze bags contain 4 mirrored fuchsia bags.
shiny maroon bags contain 1 wavy maroon bag, 1 drab gray bag, 1 posh white bag.
wavy olive bags contain 1 muted purple bag, 1 shiny brown bag, 5 faded tomato bags.
dotted crimson bags contain 2 shiny blue bags, 4 dotted blue bags, 5 vibrant crimson bags.
mirrored olive bags contain 3 muted bronze bags, 1 drab tomato bag, 3 drab violet bags.
light aqua bags contain 3 faded cyan bags, 4 shiny white bags.
clear fuchsia bags contain 3 bright blue bags.
light green bags contain 2 dim brown bags, 4 drab green bags.
bright magenta bags contain 1 mirrored turquoise bag, 2 dark fuchsia bags, 5 shiny plum bags.
pale fuchsia bags contain 4 wavy purple bags, 2 striped salmon bags, 4 pale black bags, 3 dotted teal bags.
posh tan bags contain 3 plaid purple bags.
dull tomato bags contain 2 clear salmon bags, 2 striped yellow bags, 5 pale indigo bags.
bright white bags contain 1 drab white bag, 4 dim violet bags.
bright gray bags contain 5 muted yellow bags, 5 vibrant crimson bags.
dull silver bags contain 2 muted purple bags.
dotted gray bags contain 2 mirrored magenta bags, 1 dark lavender bag, 1 clear blue bag, 4 faded magenta bags.
wavy gold bags contain 3 mirrored green bags, 5 pale aqua bags.
shiny plum bags contain 5 plaid blue bags, 2 muted white bags, 5 pale gray bags, 2 faded indigo bags.
posh plum bags contain 4 wavy magenta bags, 3 mirrored plum bags.
clear bronze bags contain 4 bright aqua bags, 4 dim white bags, 4 plaid blue bags, 5 plaid black bags.
vibrant teal bags contain 2 light violet bags, 4 clear orange bags, 1 shiny plum bag, 1 light cyan bag.
clear red bags contain 2 drab tan bags.
striped coral bags contain 1 shiny olive bag, 1 dark teal bag, 3 dark white bags.
striped aqua bags contain 4 wavy teal bags, 2 dull chartreuse bags, 3 mirrored cyan bags, 5 plaid gray bags.
drab purple bags contain 1 faded fuchsia bag, 5 dull chartreuse bags, 1 light white bag, 5 posh gold bags.
mirrored brown bags contain 5 bright aqua bags, 5 shiny blue bags, 5 dotted blue bags, 1 posh fuchsia bag.
dim gray bags contain 4 vibrant chartreuse bags, 5 clear beige bags, 1 shiny orange bag, 5 light chartreuse bags.
mirrored purple bags contain 3 shiny gold bags, 4 plaid aqua bags, 4 wavy gold bags.
drab black bags contain 4 faded aqua bags.
pale tomato bags contain 3 vibrant gold bags, 2 dotted cyan bags, 3 wavy brown bags, 5 bright violet bags.
muted plum bags contain 5 dull white bags, 5 drab chartreuse bags, 4 clear gray bags.
bright lime bags contain 1 light chartreuse bag.
light yellow bags contain 1 vibrant teal bag, 1 dull teal bag.
dark fuchsia bags contain 3 dim plum bags, 5 faded purple bags.
dim blue bags contain 5 striped coral bags, 3 drab fuchsia bags, 5 drab salmon bags.
posh orange bags contain 2 pale gray bags, 4 plaid bronze bags, 5 vibrant tan bags.
striped beige bags contain 3 mirrored crimson bags, 3 muted fuchsia bags.
dim fuchsia bags contain 5 clear white bags.
dull orange bags contain 2 striped crimson bags, 2 dark white bags, 1 dark turquoise bag, 3 shiny olive bags.
drab fuchsia bags contain 3 dark crimson bags, 5 clear magenta bags, 5 faded brown bags.
dim tan bags contain 3 dull indigo bags, 3 clear magenta bags.
clear green bags contain 3 bright blue bags, 4 clear teal bags, 2 pale indigo bags.
shiny black bags contain 1 mirrored brown bag.
pale maroon bags contain 2 faded lime bags, 2 wavy red bags, 1 dark orange bag.
faded crimson bags contain 1 posh aqua bag, 5 bright brown bags, 4 dull teal bags, 4 striped orange bags.
muted tan bags contain 2 pale gold bags, 3 striped magenta bags, 5 plaid gold bags, 5 striped fuchsia bags.
light turquoise bags contain 2 dull plum bags.
dull lavender bags contain 3 dark green bags, 3 light brown bags, 2 posh fuchsia bags, 5 posh bronze bags.
pale olive bags contain 5 striped blue bags, 1 striped coral bag, 2 muted white bags.
dark crimson bags contain 1 bright red bag.
vibrant gray bags contain 1 clear coral bag, 4 posh aqua bags, 5 clear brown bags, 5 dull chartreuse bags.
plaid tan bags contain 2 bright coral bags, 3 wavy salmon bags.
bright crimson bags contain 4 clear indigo bags, 3 dim plum bags, 4 posh brown bags.
dotted magenta bags contain 5 bright lime bags, 2 dotted coral bags.
posh aqua bags contain 5 vibrant lime bags, 5 plaid fuchsia bags.
striped turquoise bags contain 5 pale lavender bags.
pale chartreuse bags contain 4 mirrored tan bags, 5 mirrored black bags.
pale tan bags contain 4 plaid beige bags, 3 light tomato bags, 1 dark tan bag, 4 faded lime bags.
wavy plum bags contain 5 dark crimson bags, 4 dim black bags.
posh brown bags contain 3 dark teal bags, 5 striped white bags.
mirrored tan bags contain 3 clear maroon bags, 4 mirrored green bags, 1 dotted red bag, 1 wavy aqua bag.
dotted fuchsia bags contain 3 clear lime bags, 2 dim plum bags, 2 bright salmon bags, 5 faded violet bags.
drab cyan bags contain 4 striped coral bags, 5 faded gray bags, 2 posh orange bags.
light red bags contain 5 faded black bags.
plaid yellow bags contain 3 striped green bags, 4 striped olive bags, 1 mirrored lavender bag.
muted black bags contain 2 muted turquoise bags, 3 wavy bronze bags, 5 wavy teal bags.
plaid silver bags contain 2 drab maroon bags, 2 wavy maroon bags, 5 dark tan bags.
dark coral bags contain 1 posh bronze bag, 5 bright coral bags.
bright violet bags contain 3 posh brown bags, 4 pale orange bags, 2 muted olive bags, 2 posh orange bags.
pale silver bags contain 3 pale fuchsia bags, 4 bright cyan bags.
dim plum bags contain 1 faded brown bag.
mirrored red bags contain 3 dull magenta bags, 2 light gold bags.
posh beige bags contain 5 plaid turquoise bags, 3 clear bronze bags, 5 plaid silver bags.
faded silver bags contain 4 muted violet bags, 3 muted tomato bags, 1 bright yellow bag.
dim coral bags contain 1 faded brown bag, 4 drab cyan bags, 1 shiny olive bag.
drab beige bags contain 5 mirrored fuchsia bags, 1 faded brown bag.
dark purple bags contain 1 striped tan bag, 2 light maroon bags.
drab magenta bags contain 4 dim silver bags, 4 mirrored silver bags, 5 muted tomato bags.
muted orange bags contain 5 dim olive bags, 5 pale brown bags, 2 mirrored black bags, 3 posh green bags.
dotted aqua bags contain 2 faded turquoise bags, 4 light yellow bags, 4 dotted lavender bags.
pale salmon bags contain 4 light cyan bags, 4 bright plum bags.
bright red bags contain 3 bright coral bags, 4 clear brown bags, 1 bright teal bag.
striped lime bags contain 5 bright yellow bags, 1 drab maroon bag, 5 muted silver bags.
clear magenta bags contain 5 light teal bags, 5 dotted cyan bags, 1 pale orange bag.
dull beige bags contain 1 posh cyan bag, 5 dark orange bags, 3 pale cyan bags, 5 drab salmon bags.
striped chartreuse bags contain 4 wavy maroon bags.
pale gray bags contain 1 plaid black bag.
dull black bags contain 3 dull brown bags.
dotted green bags contain 3 shiny maroon bags.
faded turquoise bags contain 2 dark violet bags.
wavy green bags contain 5 light gray bags, 5 vibrant lime bags.
light maroon bags contain 2 dotted teal bags, 3 striped fuchsia bags.
striped indigo bags contain 2 dim crimson bags.
shiny green bags contain 5 mirrored cyan bags, 5 faded red bags, 1 light silver bag, 4 mirrored black bags.
clear indigo bags contain 2 faded gray bags, 2 mirrored green bags.
vibrant magenta bags contain 4 muted silver bags, 3 bright crimson bags.
mirrored violet bags contain 1 dull blue bag.
clear yellow bags contain 1 plaid purple bag, 2 vibrant crimson bags, 3 faded white bags, 4 plaid gold bags.
light white bags contain 4 clear magenta bags, 4 drab green bags, 2 clear chartreuse bags.
striped brown bags contain 4 drab gold bags, 4 plaid red bags, 2 dim coral bags, 4 dim teal bags.
pale crimson bags contain 4 dim green bags, 2 striped crimson bags, 1 striped coral bag, 3 dark salmon bags.
dull olive bags contain 1 striped yellow bag, 2 bright aqua bags.
dark olive bags contain 2 faded indigo bags, 4 dim orange bags, 5 shiny silver bags, 5 dotted turquoise bags.
drab chartreuse bags contain 1 shiny olive bag, 1 posh tomato bag, 1 dark turquoise bag.
pale green bags contain 3 pale gray bags, 1 dim violet bag, 3 striped crimson bags, 3 faded cyan bags.
light gray bags contain 2 pale white bags, 1 dark beige bag, 1 clear purple bag.
plaid olive bags contain 5 drab aqua bags, 1 plaid bronze bag, 4 clear brown bags.
mirrored indigo bags contain 3 striped bronze bags, 3 faded green bags, 2 dotted green bags, 3 dull olive bags.
wavy brown bags contain 4 pale maroon bags.
shiny lime bags contain 2 posh gold bags, 5 posh black bags.
mirrored silver bags contain 4 pale cyan bags, 1 bright bronze bag, 1 mirrored blue bag.
shiny red bags contain 2 wavy purple bags, 5 drab yellow bags.
light coral bags contain 2 pale gold bags.
posh olive bags contain 2 bright aqua bags.
striped black bags contain 3 bright blue bags, 1 light salmon bag, 1 mirrored salmon bag.
dotted lime bags contain 5 muted indigo bags, 2 striped coral bags, 1 shiny orange bag, 4 dim black bags.
wavy fuchsia bags contain 4 clear magenta bags.
light plum bags contain 3 shiny maroon bags.
shiny brown bags contain 1 faded brown bag, 5 light teal bags.
clear tan bags contain 3 dark teal bags, 2 bright plum bags.
pale violet bags contain 1 clear turquoise bag, 4 dark tan bags, 3 muted green bags, 3 posh magenta bags.
plaid coral bags contain 2 faded red bags, 1 faded indigo bag, 4 striped blue bags, 5 vibrant maroon bags.
drab red bags contain 3 mirrored white bags, 5 drab tomato bags, 3 vibrant chartreuse bags, 2 faded crimson bags.
wavy chartreuse bags contain 1 bright brown bag, 2 vibrant aqua bags, 2 drab teal bags.
dull turquoise bags contain 1 dotted chartreuse bag, 1 wavy lime bag, 1 faded gold bag.
wavy tomato bags contain 4 bright orange bags, 4 shiny fuchsia bags, 1 bright gray bag, 1 posh violet bag.
mirrored lime bags contain 1 vibrant salmon bag, 5 dull white bags, 5 dotted lavender bags, 1 dull yellow bag.
muted white bags contain 4 muted olive bags, 3 mirrored green bags, 2 striped coral bags.
muted red bags contain 3 pale indigo bags, 2 dim violet bags, 2 bright red bags.
dotted lavender bags contain 1 clear indigo bag, 5 muted cyan bags, 5 plaid gray bags, 2 plaid aqua bags.
light lavender bags contain 3 drab tomato bags, 1 wavy tan bag, 1 muted magenta bag, 1 striped magenta bag.
faded gray bags contain 4 faded cyan bags.
dark plum bags contain 5 dim violet bags, 1 light teal bag, 3 faded brown bags, 1 plaid gold bag.
vibrant bronze bags contain 1 drab gray bag, 2 faded gray bags.
clear white bags contain 2 dark fuchsia bags, 2 dark gray bags.
pale beige bags contain 1 mirrored fuchsia bag.
bright chartreuse bags contain 3 clear crimson bags.
drab gray bags contain 2 faded gray bags, 4 posh orange bags, 3 dull teal bags, 4 shiny plum bags.
wavy black bags contain 1 pale maroon bag.
dark beige bags contain 1 faded gray bag.
dark violet bags contain 1 muted tan bag, 5 faded brown bags, 3 plaid black bags.
dim beige bags contain 1 dotted turquoise bag, 5 dim teal bags, 3 mirrored crimson bags.
posh silver bags contain 3 striped orange bags, 4 posh teal bags.
muted cyan bags contain 2 drab salmon bags, 1 pale olive bag, 2 dark plum bags.
dark indigo bags contain 2 dim magenta bags, 3 bright orange bags, 4 clear white bags.
dull violet bags contain 2 pale bronze bags, 2 mirrored blue bags.
pale teal bags contain 5 striped maroon bags, 3 pale gray bags.
bright green bags contain 4 drab green bags, 3 drab indigo bags, 5 dull blue bags.
posh violet bags contain 5 wavy white bags.
clear brown bags contain no other bags.";
    #endregion
    public override Task ExecuteAsync()
    {
        IDictionary<string, Bag> bags = new Dictionary<string, Bag>();
        foreach (var rule in input.Split(Environment.NewLine))
        {
            var containingBagColour = rule.Substring(rule.IndexOf(" bags contain"));
            Bag bag = GetBag(containingBagColour);
            foreach (var containedBagColour in rule.Substring(rule.IndexOf(" bags contain") + 14).Split(',').Select(s => s.TrimStart()))
            {
                if (!containedBagColour.Contains("no other bag"))
                {
                    var number = int.Parse(new Regex(@"\d+(?= )").Match(containedBagColour).Value);
                    var colour = new Regex(@"(?<=\d ).*(?= bags?\.?$)").Match(containedBagColour).Value;
                    var containedBag = GetBag(colour);
                    bag.MustContain.Add((containedBag, number));
                    if (!containedBag.CanBeContainedIn.Contains(bag))
                    {
                        containedBag.CanBeContainedIn.Add(bag);
                    }
                }
            }
        }

        var leaves = bags.Values.Where(b => !b.MustContain.Any()).ToList();
        IList<Bag> faded = new List<Bag>();
        while (leaves.Any())
        {
            var newLeaves = new List<Bag>();
            foreach (var leaf in leaves)
            {
                faded.Add(leaf);
                foreach (var bag in leaf.CanBeContainedIn)
                {
                    bag.ContentSize += bag.MustContain.Single(c => c.Item1 == leaf).Item2 * (leaf.ContentSize + 1);
                    if (bag.MustContain.All(m => faded.Contains(m.Item1)))
                    {
                        newLeaves.Add(bag);
                    }
                }

                leaves = newLeaves;
            }
        }

        Result = GetBag("shiny gold").ContentSize.ToString();
        return Task.CompletedTask;


        var currentBags = new List<Bag> { GetBag("shiny gold") };











        IList<Bag> endBags = currentBags.ToList();
        long result = 0;
        while (currentBags.Any())
        {
            var newBags = new List<Bag>();
            foreach (var currentBag in currentBags)
            {
                foreach (var bag in currentBag.CanBeContainedIn)
                {
                    if (!endBags.Contains(bag))
                    {
                        endBags.Add(bag);
                        newBags.Add(bag);
                    }
                }
            }

            currentBags = newBags;
            result += currentBags.Count;
        }

        Result = result.ToString();
        return Task.CompletedTask;

        Bag GetBag(string colour)
        {
            Bag bag;
            if (bags.ContainsKey(colour))
            {
                bag = bags[colour];
            }
            else
            {
                bag = new Bag { Colour = colour };
                bags[colour] = bag;
            }

            return bag;
        }
    }

    private class Bag
    {
        public string Colour { get; set; }
        public IList<(Bag, int)> MustContain { get; set; } = new List<(Bag, int)>();
        public IList<Bag> CanBeContainedIn { get; set; } = new List<Bag>();
        public long ContentSize { get; set; }
    }

    public override int Nummer => 202007;
}