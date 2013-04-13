using System;
using System.Drawing;
using NUnit.Framework;

namespace ImageDiff.Tests
{
    [TestFixture]
    public class ProximityHelperTests
    {
        [Test]
        public void Get_point()
        {
            var helper = new ProximityHelper();


            Assert.NotNull(helper);
        }
    }
}
