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
    public class HandlerCompositeTest
    {
        static HandlerComposite handlerComposite;
        static HandlerOne handlerOne;
        static HandlerTwo handlerTwo;

        [ClassInitialize]
        public static void TestInitialize(TestContext testContex)
        {
            handlerComposite = new HandlerComposite();
            handlerOne = new HandlerOne("qwerty", 2, 6);
            handlerTwo = new HandlerTwo("12345", 2);

            handlerComposite.AddHandlerAtTheEnd(handlerOne);
            handlerComposite.AddHandlerAtTheEnd(handlerTwo);
        }

        [TestMethod]
        public void AddHandlerOneAtTheEndTest() => CollectionAssert.Contains(handlerComposite.handlers, handlerOne);

        [TestMethod]
        public void AddHandlerTwoAtTheEndTest()
        {
            CollectionAssert.Contains(handlerComposite.handlers, handlerTwo);
        }

        [TestMethod]
        public void AddHandlerOneByName()
        {
            var ho = new HandlerOne("Anthonio", 9, 13);

            handlerComposite.AddHandlerByName(ho, handlerTwo.Name);

            CollectionAssert.Contains(handlerComposite.handlers, ho);
        }

        [TestMethod]
        public void AddHandlerTwoByName()
        {
            var ht = new HandlerTwo("Arsen", 6);

            handlerComposite.AddHandlerByName(ht, handlerOne.Name);

            CollectionAssert.Contains(handlerComposite.handlers, ht);
        }

        [TestMethod]
        public void RemoveHandlerByNameTest()
        {
            string name = "12345";
            int expected = handlerComposite.handlers.Count -1 ;

            handlerComposite.RemoveHandlerByName(name);

            Assert.AreEqual(expected, handlerComposite.handlers.Count);
        }

        [TestMethod]
        public void RemoveHandlerByNameFailTest()
        {
            string name = "cvfsesgsx";
            int expected = handlerComposite.handlers.Count;

            handlerComposite.RemoveHandlerByName(name);

            Assert.AreEqual(expected, handlerComposite.handlers.Count);
        }
    }
}