using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    public class HandlerOne : Handler
    {
        public int MaxInterf { get; set; }
        public int MinInterf { get; set; }

        public HandlerOne (string name, int minInterf, int maxInterf) : base (name)
        {
            MinInterf = minInterf;
            if (minInterf < maxInterf)
                MaxInterf = maxInterf;
            else
                throw new ArgumentException("Максимальное значение должно быть больше минимального.\n", maxInterf.ToString());
        }

        public override void RunProcessing(List<double>  numbers)
        {           
            var rnd = new Random();
            int noise = rnd.Next(MinInterf, MaxInterf);
            int indexNoise = rnd.Next(0, numbers.Count-1);

            numbers.Insert(indexNoise, noise);
        }
    }
}
