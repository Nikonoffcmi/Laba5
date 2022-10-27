using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laba5.Test
{
    [TestClass]
    public class HandlerOneTest
    {
        static HandlerOne handlerOne;
        static string name;
        static int min;
        static int max;

        [ClassInitialize]
        public static void InitializeTest(TestContext testContex)
        {
            name = "Rick";
            min = 2;
            max = 6;
            handlerOne = new HandlerOne(name, min, max);   

        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void HandlerOneArgumentExceptionTest()
        {
            int minEx = 6;
            int maxEx = 2;

            var handlerOneEx = new HandlerOne(name, minEx, maxEx);
        }

        [TestMethod]
        public void HandlerOneRunProcessingCountTest()
        {
            var numbers = new List<double> { 2, 4, 6, 7 };
            int expected = numbers.Count + 1;

            handlerOne.RunProcessing(numbers);

            Assert.AreEqual(expected, numbers.Count);
        }

        [TestMethod]
        public void HandlerOneRunProcessingNullListTest()
        {
            var numbers = new List<double>();
            int expected = 1;

            handlerOne.RunProcessing(numbers);

            Assert.AreEqual(expected, numbers.Count);
        }
    }
}
