using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit.Tests.Generic
{
    [TestClass]
    public abstract class BaseTest<T>
    {
        [TestInitialize]
        public virtual void SetupTest()
        {
            // Setup all the mocks needed for test
            SetupMockingForTests();

            // Generate ItemToTest with all the dependency
            CreateItemToTest();
        }

        protected abstract T CreateItemToTest();

        protected abstract void SetupMockingForTests();
    }
}
