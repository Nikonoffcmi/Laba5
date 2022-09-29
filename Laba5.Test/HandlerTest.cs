namespace Laba5.Test
{
    [TestClass]
    public class HandlerTest
    {
        private Handler handler;
        private Handler handlerNull;
        private string name;

        [TestInitialize]
        public void TestInitialize()
        {
            name = "Jack";
            handler = new Handler(name);
            handlerNull = new Handler();
        }

        [TestMethod]
        public void HandlerCheckOutContainsName() => Assert.AreEqual(name, handler.Name);

        [TestMethod]
        public void HandlerContainsNullName() => Assert.IsNull(handlerNull.Name);
    }
}