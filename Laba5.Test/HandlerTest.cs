namespace Laba5.Test
{
    [TestClass]
    public class HandlerTest
    {
        private Handler handler;
        private Handler handlerNull;
        private string name;

        [TestInitialize]
        public void InitializeTest()
        {
            name = "Jack";
            handler = new Handler(name);
        }

        [TestMethod]
        public void HandlerCheckOutContainsNameTest() => Assert.AreEqual(name, handler.Name);
    }
}