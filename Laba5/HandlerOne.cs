using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Laba5
{
    [DataContract]
    public class HandlerOne : Handler
    {
        [DataMember]
        public int MaxInterf { get; protected set; }
        [DataMember]
        public int MinInterf { get; protected set; }

        public HandlerOne (string name, int minInterf, int maxInterf) : base (name)
        {
            MinInterf = minInterf;
            if (minInterf < maxInterf)
                MaxInterf = maxInterf;
            else
                throw new ArgumentException("Максимальное значение должно быть больше минимального.\n");
        }

        public override void RunProcessing(List<double> numbers)
        {           
            var rnd = new Random();
            int noise = rnd.Next(MinInterf, MaxInterf);
            int indexNoise = rnd.Next(0, numbers.Count);

            numbers.Insert(indexNoise, noise);
        }
    }
}
