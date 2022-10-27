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
    public class HandlerTwoTest
    {
        static HandlerTwo handlerTwo;
        static string Name;
        static int Average;

        [ClassInitialize]
        public static void InitializeTest(TestContext testContex)
        {
            Name = "Morty";
            Average = 2;
            handlerTwo = new HandlerTwo(Name, Average);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void HandlerTwoAverageArgumentOutOfRangeExceptionTest()
        {
            int AverageEx = -1;

            var handlerTwoEx = new HandlerTwo(Name, AverageEx);
        }

        [TestMethod]
        public void HandlerTwoEvenRunProcessingTest()
        {
            var numbers = new List<double> { 1, 2, 3, 4 };
            var expected = new List<double> { 1.5, 3.5 };

            handlerTwo.RunProcessing(numbers);

            CollectionAssert.AreEquivalent(expected, numbers);
        }

        [TestMethod]
        public void HandlerTwoUnevenRunProcessingTest()
        {
            handlerTwo = new HandlerTwo(Name, 2);
            var numbers = new List<double> { 2, 4, 3, 5, 1};
            var expected = new List<double> { 3, 4, 1};

            handlerTwo.RunProcessing(numbers);

            CollectionAssert.AreEquivalent(expected, numbers);
        }

        [TestMethod]
        public void HandlerTwoRunProcessingDifferentAverageTest()
        {
            handlerTwo = new HandlerTwo(Name, 5);
            var numbers = new List<double> { 14, 3, 4, 1, 54, -9, -12, 18 };
            var expected = new List<double> { 15.2, -1};

            handlerTwo.RunProcessing(numbers);

            CollectionAssert.AreEquivalent(expected, numbers);
        }

        [TestMethod]
        public void HandlerTwoNullListRunProcessingdTest()
        {
            var numbers = new List<double>();
            var expected = new List<double>();

            handlerTwo.RunProcessing(numbers);

            CollectionAssert.AreEquivalent(expected, numbers);
        }
    }
}