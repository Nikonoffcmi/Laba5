using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Laba5
{
    [DataContract]
    public class Handler
    {
        [DataMember]
        public string Name { get; set; }
        public virtual void RunProcessing(List<double> numbers) { }

        public Handler() { }

        public Handler(string name) { Name = name; }
    }
}
