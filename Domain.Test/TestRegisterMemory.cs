namespace DomainTest
{
    using Domain;
    using NUnit.Framework;

    public class TestRegisterMemory
    {
        [Test]
        public void TestGetterSetter()
        {
            RegisterMemory.Reset();
            RegisterMemory.Set(0, 10);
            RegisterMemory.Set(42, 15);

            Assert.AreEqual(10, RegisterMemory.Get(0));
            Assert.AreEqual(15, RegisterMemory.Get(42));
        }

        [Test]
        public void TestReset()
        {
            RegisterMemory.Reset();
            RegisterMemory.Set(0, 10);
            RegisterMemory.Set(42, 15);
            RegisterMemory.Reset();

            Assert.Zero(RegisterMemory.Get(0));
            Assert.Zero(RegisterMemory.Get(42));
        }
    }
}