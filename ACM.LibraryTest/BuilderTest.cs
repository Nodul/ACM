using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.Library;

namespace ACM.LibraryTest
{
    [TestClass]
    public class BuilderTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestMethod]
        public void BuildIntegerSequenceTest()
        {
            // Arrange
            Builder listBuilder = new Builder();

            // Act
            var result = listBuilder.BuildIntegerSequence();

            // Analyze
            foreach (var item in result)
            {
                // This is currently bugged https://github.com/Microsoft/testfx/issues/120 [as of 2017-04-02]
                // TestContext.WriteLine(item.ToString());

                // workaround
                Console.WriteLine(item.ToString());
            }

            // Assert 
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuildStringSequenceTest()
        {
            // Arrange
            Builder listBuilder = new Builder();

            // Act
            var result = listBuilder.BuildStringSequence();

            // Analyze
            foreach (var item in result)
            {
                // This is currently bugged https://github.com/Microsoft/testfx/issues/120 [as of 2017-04-02]
                // TestContext.WriteLine(item.ToString());

                // workaround
                Console.WriteLine(item);
            }

            // Assert 
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CompareSequencesTest()
        {
            // Arrange
            Builder listBuilder = new Builder();

            // Act
            var result = listBuilder.CompareSequence();

            // Analyze
            foreach (var item in result)
            {
                // This is currently bugged https://github.com/Microsoft/testfx/issues/120 [as of 2017-04-02]
                // TestContext.WriteLine(item.ToString());

                // workaround
                Console.WriteLine(item.ToString());
            }

            // Assert 
            Assert.IsNotNull(result);
        }

    }
}
