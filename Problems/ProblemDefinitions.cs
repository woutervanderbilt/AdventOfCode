﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public static class ProblemDefinitions
    {
        public static IDictionary<int, Problem> Problems = new Dictionary<int, Problem>();

        static ProblemDefinitions()
        {
            var problems = Assembly.GetAssembly(typeof(Problem)).GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Problem)) && t.IsClass && !t.IsAbstract);
            foreach (var problem in problems)
            {
                var instance = (Problem) Activator.CreateInstance(problem);
                if (instance.Nummer != 0)
                {
                    Problems.Add(instance.Nummer, instance);
                }
            }
        }
    }
}
