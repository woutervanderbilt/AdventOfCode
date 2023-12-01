using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Problems.Advent._2023;

namespace Problems
{
    public abstract class Problem
    {
        public abstract Task ExecuteAsync();

        public async Task<string> GetInputAsync()
        {
            var assembly = Assembly.GetAssembly(typeof(Dag01));
            var resourcePath = assembly.GetManifestResourceNames().Single(s => s.EndsWith($"{Nummer}.txt"));
            using Stream stream = assembly.GetManifestResourceStream(resourcePath)!;
            using StreamReader reader = new(stream);
            return await reader.ReadToEndAsync();
        }

        public virtual async Task Initialize()
        {

        }

        public abstract int Nummer { get; }
        public string Result { get; protected set; }
    }
}
