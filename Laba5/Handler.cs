using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    public class Handler
    {
        public string Name { get; set; }
        public virtual void RunProcessing(List<double> numbers) { }

        public Handler() { }

        public Handler(string name) { Name = name; }
    }
}
