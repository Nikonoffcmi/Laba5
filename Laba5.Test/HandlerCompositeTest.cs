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
        public static void InitializeTest(TestContext testContex)
        {
            handlerComposite = new HandlerComposite();
            handlerOne = new HandlerOne("qwerty", 2, 6);
            handlerTwo = new HandlerTwo("12345", 2);

            handlerComposite.AddHandlerAtTheEnd(handlerOne);
            handlerComposite.AddHandlerAtTheEnd(handlerTwo);
        }

        [TestMethod]
        public void AddHandlerOneAtTheEndTest() => CollectionAssert.Contains(handlerComposite.GetHandlerOne(), handlerOne);

        [TestMethod]
        public void AddHandlerTwoAtTheEndTest()
        {
            CollectionAssert.Contains(handlerComposite.GetHandlerTwo(), handlerTwo);
        }

        [TestMethod]
        public void AddHandlerOneByNameTest()
        {
            var ho = new HandlerOne("Anthonio", 9, 13);

            handlerComposite.AddHandlerByName(ho, handlerTwo.Name);

            CollectionAssert.Contains(handlerComposite.GetHandlerOne(), ho);
        }

        [TestMethod]
        public void AddHandlerTwoByNameTest()
        {
            var ht = new HandlerTwo("Arsen", 6);

            handlerComposite.AddHandlerByName(ht, handlerOne.Name);

            CollectionAssert.Contains(handlerComposite.GetHandlerTwo(), ht);
        }

        [TestMethod]
        public void RemoveHandlerByNameTest()
        {
            string name = "12345";
            int expected = handlerComposite.GetNames().Count - 1;

            handlerComposite.RemoveHandlerByName(name);

            Assert.AreEqual(expected, handlerComposite.GetNames().Count);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void RemoveHandlerByNameFailTest()
        {
            string name = "cvfsesgsx";
            int expected = handlerComposite.GetNames().Count;

            handlerComposite.RemoveHandlerByName(name);

            Assert.AreEqual(expected, handlerComposite.GetNames().Count);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddHandlerTwoExistNameTest()
        {
            string name = "cvfsesgsx";
            handlerTwo = new HandlerTwo("cvfsesgsx", 9);
            int expected = handlerComposite.GetNames().Count;

            handlerComposite.AddHandlerByName(handlerTwo, name);

            Assert.AreEqual(expected, handlerComposite.GetNames().Count);
        }
    }
}