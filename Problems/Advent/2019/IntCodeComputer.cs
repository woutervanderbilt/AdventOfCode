using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Advent._2019;

public class IntCodeComputer
{
    private readonly string programSource;
    private IDictionary<long, long> Program { get; set; }

    private IDictionary<long, long> originalProgram { get; } = new Dictionary<long, long>();
    private long CurrentPosition { get; set; }
    private int ParameterIndex { get; set; }
    private long RelativeBase { get; set; }
    public bool IsRunning { get; set; }
    private IList<long> Parameters = new List<long>();

    public IntCodeComputer(string programSource)
    {
        this.programSource = programSource;
    }

    public IntCodeComputer Compile()
    {
        Program = new Dictionary<long, long>();
        long c = 0;
        foreach (var b in programSource.Split(',').Select(long.Parse).ToList())
        {
            Program[c] = b;
            originalProgram[c] = b;
            c++;
        }

        return this;
    }

    public IntCodeComputer Reset()
    {
        Program = new Dictionary<long, long>(originalProgram);
        CurrentPosition = 0;
        RelativeBase = 0;
        ParameterIndex = 0;
        Parameters.Clear();
        IsRunning = false;
        return this;
    }

    public void AddParameters(params long[] parameters)
    {
        foreach (var parameter in parameters)
        {
            Parameters.Add(parameter);
        }
    }

    public IEnumerable<long> Run()
    {
        IsRunning = true;
        var instruction = Program[CurrentPosition];
        while (instruction != 99)
        {

            int p1Mode = (int)(instruction / 100) % 10;
            int p2Mode = (int)(instruction / 1000) % 10;
            int p3Mode = (int) (instruction / 10000) % 10;
            switch (instruction % 100)
            {
                case 1:
                    Program[(int)GetParameterForWriting(3,p3Mode)] =
                        GetParameter(1, p1Mode)
                        + GetParameter(2, p2Mode);
                    CurrentPosition += 4;
                    break;
                case 2:
                    Program[(int)GetParameterForWriting(3, p3Mode)] =
                        GetParameter(1, p1Mode)
                        * GetParameter(2, p2Mode);
                    CurrentPosition += 4;
                    break;
                case 3:
                    if (Parameters.Count <= ParameterIndex)
                    {
                        yield break;
                    }
                    Program[(int)GetParameterForWriting(1, p1Mode)] = Parameters[ParameterIndex];
                    ParameterIndex++;
                    CurrentPosition += 2;
                    break;
                case 4:
                    long output = GetParameter(1,p1Mode);
                    CurrentPosition += 2;
                    yield return output;
                    break;
                case 5:
                    if (GetParameter(1, p1Mode) != 0)
                    {
                        CurrentPosition = (int)GetParameter(2, p2Mode);
                    }
                    else
                    {
                        CurrentPosition += 3;
                    }
                    break;
                case 6:
                    if (GetParameter(1, p1Mode) == 0)
                    {
                        CurrentPosition = (int)GetParameter(2, p2Mode);
                    }
                    else
                    {
                        CurrentPosition += 3;
                    }
                    break;
                case 7:
                    if (GetParameter(1, p1Mode) < GetParameter(2, p2Mode))
                    {
                        Program[(int)GetParameterForWriting(3, p3Mode)] = 1;
                    }
                    else
                    {
                        Program[(int)GetParameterForWriting(3, p3Mode)] = 0;
                    }
                    CurrentPosition += 4;
                    break;
                case 8:
                    if (GetParameter(1, p1Mode) == GetParameter(2, p2Mode))
                    {
                        Program[(int)GetParameterForWriting(3, p3Mode)] = 1;
                    }
                    else
                    {
                        Program[(int)GetParameterForWriting(3, p3Mode)] = 0;
                    }
                    CurrentPosition += 4;
                    break;
                case 9:
                    RelativeBase += GetParameter(1, p1Mode);
                    CurrentPosition += 2;
                    break;
            }
            instruction = Program[CurrentPosition];
        }

        IsRunning = false;
    }

    private long GetParameterForWriting(int index, int mode)
    {
        long parameter = 0;
        if (Program.ContainsKey(CurrentPosition + index))
        {
            parameter = Program[CurrentPosition + index];
        }
        switch (mode)
        {
            case 0:
                return parameter;
            case 2:
                return parameter + RelativeBase;
        }

        throw new Exception();
    }


    private long GetParameter(int index, int mode)
    {
        long parameter = 0;
        if (Program.ContainsKey(CurrentPosition + index))
        {
            parameter = Program[CurrentPosition + index];
        }

        switch (mode)
        {
            case 0:
                return Program.ContainsKey(parameter) ? Program[parameter] : 0;
            case 1:
                return parameter;
            case 2:
                return Program.ContainsKey(parameter + RelativeBase) ? Program[parameter + RelativeBase] : 0;
        }

        throw new Exception();
    }
}