using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2023;

internal class Dag19 : Problem
{
    private const string testinput = @"px{a<2006:qkq,m>2090:A,rfg}
pv{a>1716:R,A}
lnx{m>1548:A,A}
rfg{s<537:gd,x>2440:R,A}
qs{s>3448:A,lnx}
qkq{x<1416:A,crn}
crn{x>2662:A,R}
in{s<1351:px,qqz}
qqz{s>2770:qs,m<1801:hdj,R}
gd{a>3333:R,R}
hdj{m>838:A,pv}

{x=787,m=2655,a=1222,s=2876}
{x=1679,m=44,a=2067,s=496}
{x=2036,m=264,a=79,s=2244}
{x=2461,m=1339,a=466,s=291}
{x=2127,m=1623,a=2188,s=1013}";
    public override async Task ExecuteAsync()
    {
        var parts = new List<Part>();
        var workflows = new Dictionary<string, Workflow>();
        bool parsingWorkflows = true;

        foreach (var line in Input.Split(Environment.NewLine))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                parsingWorkflows = false;
                continue;
            }

            if (parsingWorkflows)
            {
                var split = line.Replace("}", "").Split('{');
                var workflow = new Workflow();
                workflow.Name = split[0];
                workflows[workflow.Name] = workflow;
                foreach (var i in split[1].Split(','))
                {
                    var instruction = new Instruction();
                    workflow.Instructions.Add(instruction);
                    var splitInstruction = i.Split(':');
                    var last = splitInstruction.Last();
                    if (last == "A")
                    {
                        instruction.Accepted = true;
                    }
                    else if (last == "R")
                    {
                        instruction.Rejected = true;
                    }
                    else
                    {
                        instruction.Target = last;
                    }

                    if (splitInstruction.Length > 1)
                    {
                        var splitCondition = splitInstruction[0].Split('<', '>');
                        instruction.ToCompare = splitCondition[0];
                        instruction.Limit = long.Parse(splitCondition[1]);
                        instruction.GreaterThan = splitInstruction[0].Contains('>');
                    }
                }
            }
            else
            {
                var split = line.Replace("{", "").Replace("}", "").Split(',');
                long x = long.Parse(split[0].Substring(2));
                long m = long.Parse(split[1].Substring(2));
                long a = long.Parse(split[2].Substring(2));
                long s = long.Parse(split[3].Substring(2));
                parts.Add(new Part(x, m, a, s));
            }
        }

        foreach (var workflow in workflows.Values)
        {
            foreach (var instruction in workflow.Instructions)
            {
                if (!string.IsNullOrEmpty(instruction.Target))
                {
                    instruction.TargetWorkflow = workflows[instruction.Target];
                }
            }
        }


        long result = 0;
        foreach (var part in parts)
        {
            var workflow = workflows["in"];
            var inspection = workflow.Inspect(part);
            while (!inspection.accepted && !inspection.rejected)
            {
                workflow = workflows[inspection.nextWorkflow];
                inspection = workflow.Inspect(part);
            }

            if (inspection.accepted)
            {
                result += part.X + part.M + part.A + part.S;
            }
        }

        var hyperCubes = workflows["in"].Inspect(new HyperCube(1, 4000, 1, 4000, 1, 4000, 1, 4000));
        long result2 = 0;
        foreach (var hyperCube in hyperCubes)
        {
            result2 += (hyperCube.MaxX - hyperCube.MinX + 1) * (hyperCube.MaxM - hyperCube.MinM + 1) *
                       (hyperCube.MaxA - hyperCube.MinA + 1) * (hyperCube.MaxS - hyperCube.MinS + 1);
        }
        Result = (result, result2).ToString();
    }

    private record Part(long X, long M, long A, long S);

    private class Workflow
    {
        public string Name { get; set; }
        public IList<Instruction> Instructions { get; set; } = new List<Instruction>();

        public IEnumerable<HyperCube> Inspect(HyperCube hyperCube)
        {
            foreach (var instruction in Instructions)
            {
                if (!string.IsNullOrEmpty(instruction.ToCompare))
                {
                    if (instruction.ToCompare == "x")
                    {
                        if (instruction.GreaterThan)
                        {
                            if (hyperCube.MinX > instruction.Limit)
                            {
                                foreach (var cube in CubesFromInstruction(hyperCube))
                                {
                                    yield return cube;
                                }

                                yield break;
                            }

                            if (hyperCube.MaxX > instruction.Limit)
                            {
                                var cube2 = hyperCube with { MinX = instruction.Limit + 1 };
                                foreach (var cube in CubesFromInstruction(cube2))
                                {
                                    yield return cube;
                                }

                                hyperCube = hyperCube with { MaxX = instruction.Limit };
                            }
                        }
                        else
                        {
                            if (hyperCube.MaxX < instruction.Limit)
                            {
                                foreach (var cube in CubesFromInstruction(hyperCube))
                                {
                                    yield return cube;
                                }

                                yield break;
                            }

                            if (hyperCube.MinX < instruction.Limit)
                            {
                                var cube2 = hyperCube with { MaxX = instruction.Limit - 1 };
                                foreach (var cube in CubesFromInstruction(cube2))
                                {
                                    yield return cube;
                                }

                                hyperCube = hyperCube with { MinX = instruction.Limit };
                            }
                        }
                    }
                    else if (instruction.ToCompare == "m")
                    {
                        if (instruction.GreaterThan)
                        {
                            if (hyperCube.MinM > instruction.Limit)
                            {
                                foreach (var cube in CubesFromInstruction(hyperCube))
                                {
                                    yield return cube;
                                }

                                yield break;
                            }

                            if (hyperCube.MaxM > instruction.Limit)
                            {
                                var cube2 = hyperCube with { MinM = instruction.Limit + 1 };
                                foreach (var cube in CubesFromInstruction(cube2))
                                {
                                    yield return cube;
                                }

                                hyperCube = hyperCube with { MaxM = instruction.Limit };
                            }
                        }
                        else
                        {
                            if (hyperCube.MaxM < instruction.Limit)
                            {
                                foreach (var cube in CubesFromInstruction(hyperCube))
                                {
                                    yield return cube;
                                }

                                yield break;
                            }

                            if (hyperCube.MinM < instruction.Limit)
                            {
                                var cube2 = hyperCube with { MaxM = instruction.Limit - 1 };
                                foreach (var cube in CubesFromInstruction(cube2))
                                {
                                    yield return cube;
                                }

                                hyperCube = hyperCube with { MinM = instruction.Limit };
                            }
                        }
                    }
                    else if (instruction.ToCompare == "a")
                    {
                        if (instruction.GreaterThan)
                        {
                            if (hyperCube.MinA > instruction.Limit)
                            {
                                foreach (var cube in CubesFromInstruction(hyperCube))
                                {
                                    yield return cube;
                                }

                                yield break;
                            }

                            if (hyperCube.MaxA > instruction.Limit)
                            {
                                var cube2 = hyperCube with { MinA = instruction.Limit + 1 };
                                foreach (var cube in CubesFromInstruction(cube2))
                                {
                                    yield return cube;
                                }

                                hyperCube = hyperCube with { MaxA = instruction.Limit };
                            }
                        }
                        else
                        {
                            if (hyperCube.MaxA < instruction.Limit)
                            {
                                foreach (var cube in CubesFromInstruction(hyperCube))
                                {
                                    yield return cube;
                                }

                                yield break;
                            }

                            if (hyperCube.MinA < instruction.Limit)
                            {
                                var cube2 = hyperCube with { MaxA = instruction.Limit - 1 };
                                foreach (var cube in CubesFromInstruction(cube2))
                                {
                                    yield return cube;
                                }

                                hyperCube = hyperCube with { MinA = instruction.Limit };
                            }
                        }
                    }
                    else if (instruction.ToCompare == "s")
                    {
                        if (instruction.GreaterThan)
                        {
                            if (hyperCube.MinS > instruction.Limit)
                            {
                                foreach (var cube in CubesFromInstruction(hyperCube))
                                {
                                    yield return cube;
                                }

                                yield break;
                            }

                            if (hyperCube.MaxS > instruction.Limit)
                            {
                                var cube2 = hyperCube with { MinS = instruction.Limit + 1 };
                                foreach (var cube in CubesFromInstruction(cube2))
                                {
                                    yield return cube;
                                }

                                hyperCube = hyperCube with { MaxS = instruction.Limit };
                            }
                        }
                        else
                        {
                            if (hyperCube.MaxS < instruction.Limit)
                            {
                                foreach (var cube in CubesFromInstruction(hyperCube))
                                {
                                    yield return cube;
                                }

                                yield break;
                            }

                            if (hyperCube.MinS < instruction.Limit)
                            {
                                var cube2 = hyperCube with { MaxS = instruction.Limit - 1 };
                                foreach (var cube in CubesFromInstruction(cube2))
                                {
                                    yield return cube;
                                }

                                hyperCube = hyperCube with { MinS = instruction.Limit };
                            }
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    foreach (var cube in CubesFromInstruction(hyperCube))
                    {
                        yield return cube;
                    }
                }

                IEnumerable<HyperCube> CubesFromInstruction(HyperCube cube)
                {
                    if (instruction.Rejected)
                    {
                    }
                    else if (instruction.Accepted)
                    {
                        yield return cube;
                    }
                    else
                    {
                        foreach (var cube2 in instruction.TargetWorkflow.Inspect(cube))
                        {
                            yield return cube2;
                        }
                    }
                }

            }
        }



        public (bool accepted, bool rejected, string nextWorkflow) Inspect(Part part)
        {
            foreach (var instruction in Instructions)
            {
                if (!string.IsNullOrEmpty(instruction.ToCompare))
                {
                    bool cont = false;
                    if (instruction.ToCompare == "x")
                    {
                        cont = instruction.Limit == part.X || (instruction.Limit < part.X ^ instruction.GreaterThan);
                    }
                    if (instruction.ToCompare == "m")
                    {
                        cont = instruction.Limit == part.M || (instruction.Limit < part.M ^ instruction.GreaterThan);
                    }
                    if (instruction.ToCompare == "a")
                    {
                        cont = instruction.Limit == part.A || (instruction.Limit < part.A ^ instruction.GreaterThan);
                    }
                    if (instruction.ToCompare == "s")
                    {
                        cont = instruction.Limit == part.S || (instruction.Limit < part.S ^ instruction.GreaterThan);
                    }

                    if (cont)
                    {
                        continue;
                    }
                }

                return (instruction.Accepted, instruction.Rejected, instruction.Target);
            }

            throw new Exception();
        }
    }

    private record HyperCube(long MinX, long MaxX, long MinM, long MaxM, long MinA, long MaxA, long MinS, long MaxS);

    private class Instruction
    {
        public string? ToCompare { get; set; }
        public long Limit { get; set; }
        public bool GreaterThan { get; set; }
        public string? Target { get; set; }
        public Workflow TargetWorkflow { get; set; }
        public bool Accepted { get; set; }
        public bool Rejected { get; set; }

    }

    public override int Nummer => 202319;
}