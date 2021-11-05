using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public abstract class Problem
    {
        public abstract Task ExecuteAsync();

        public virtual async Task Initialize()
        {

        }

        public abstract int Nummer { get; }
        public string Result { get; protected set; }
    }
}
