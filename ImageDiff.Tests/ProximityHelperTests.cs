using System;
using System.Drawing;
using NUnit.Framework;

namespace ImageDiff.Tests
{
    [TestFixture]
    public class ProximityHelperTests
    {
        private IProximityHelper _proximityHelper;

        [SetUp]
        public void Before_each_tests()
        {
            _proximityHelper = new ProximityHelper();
        }

        [Test]
        public void GetNearest()
        {
            var first = new Bitmap(@"..\..\..\ImageDiff\CleanTarget.PNG");
            var second = new Bitmap(@"..\..\..\ImageDiff\DirtyTarget.PNG");
            var reference = new Point(first.Width / 2, first.Height / 2);

            var result = _proximityHelper.GetNearest(reference, first, second);

            Assert.AreEqual(420, result.X);
            Assert.AreEqual(194, result.Y);
        }
    }
}
