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
        public static void TestInitialize(TestContext testContex)
        {
            name = "Rick";
            min = 2;
            max = 6;
            handlerOne = new HandlerOne(name, min, max);   

        }

        [TestMethod]
        public void HandlerOneCheckOutContainsMin() => Assert.AreEqual(min, handlerOne.MinInterf);

        [TestMethod]
        public void HandlerOneCheckOutContainsMax() => Assert.AreEqual(max, handlerOne.MaxInterf);

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void HandlerOneArgumentException()
        {
            int minEx = 6;
            int maxEx = 2;

            var handlerOneEx = new HandlerOne(name, minEx, maxEx);
        }

        [TestMethod]
        public void HandlerOneRunProcessingCountTest()
        {
            var numbers = new List<double> { 2, 4, 6, 7 };
            int expected = numbers.Count;

            handlerOne.RunProcessing(numbers);

            Assert.AreEqual(expected + 1, numbers.Count);
        }
    }
}
