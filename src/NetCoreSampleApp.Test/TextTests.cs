using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCoreSampleApp.Framework;

namespace NetCoreSampleApp.Test
{
    [TestClass]
    public class TextTests
    {
        [TestMethod]
        public void TestSlugify()
        {
            var input = "Hello .Net Core!";
            var expected = "hello-net-core";
            var functionResult = Text.Slugify(input);
            Assert.AreEqual(expected, functionResult);
        }
    }
}
