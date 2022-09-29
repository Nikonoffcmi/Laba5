using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5
{
    public class HandlerTwo : Handler
    {
        public int Average { get; set; }

        public HandlerTwo (string name, int average) : base (name)
        {
            if (average > 0)
                Average = average;
            else
                throw new ArgumentOutOfRangeException(average.ToString(), "Коэффициент усреденеия должен быть больше 0.\n");
        }

        public override void RunProcessing(List<double> numbers)
        {
            double sumNumbers = 0.0;
            int count = 0;
            var result = new List<double>();
            foreach (var number in numbers)
            {
                sumNumbers += number;
                count++;

                if (count == Average)
                {
                    result.Add((double)sumNumbers / Average);
                    count = 0;
                    sumNumbers = 0;
                }
            }

            if (count != 0)
                result.Add(sumNumbers / count);

            numbers.Clear();
            foreach (var number in result)
                numbers.Add(number);
        }
    }
}
