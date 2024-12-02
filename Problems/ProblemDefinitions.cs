using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Problems;

public static class ProblemDefinitions
{
    public static IDictionary<int, Func<Problem>> Problems = new Dictionary<int, Func<Problem>>();

    static ProblemDefinitions()
    {
        var problems = Assembly.GetAssembly(typeof(Problem)).GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Problem)) && t.IsClass && !t.IsAbstract);
        foreach (var problem in problems)
        {
            var instance = (Problem)Activator.CreateInstance(problem);
            if (instance.Nummer != 0)
            {
                Problems.Add(instance.Nummer, () => (Problem)Activator.CreateInstance(problem));
            }
        }
    }
}