using System;
using NUnit.Framework;
using Subproject1;

namespace Subproject1.Tests
{
    [TestFixture]
    public class SliceInfoTests
    {
        [Test]
        public void DummyTest()
        {
            Assert.Pass();
            Console.WriteLine("Assert passed: DummyTest executed successfully.");
        }

        [Test]
        public void SliceInfo_PropertiesAreAssignedCorrectly()
        {
            var sliceInfo = new SliceInfo();
            sliceInfo.ZPosition = 12.34;
            sliceInfo.Width = 256;
            sliceInfo.Height = 512;
            sliceInfo.MinValue = -100.5;
            sliceInfo.MaxValue = 200.75;
            sliceInfo.AvgValue = 50.25;
            sliceInfo.MinRow = 1;
            sliceInfo.MinCol = 2;
            sliceInfo.MaxRow = 3;
            sliceInfo.MaxCol = 4;

            Assert.That(sliceInfo.ZPosition, Is.EqualTo(12.34));
            Assert.That(sliceInfo.Width, Is.EqualTo(256));
            Assert.That(sliceInfo.Height, Is.EqualTo(512));
            Assert.That(sliceInfo.MinValue, Is.EqualTo(-100.5));
            Assert.That(sliceInfo.MaxValue, Is.EqualTo(200.75));
            Assert.That(sliceInfo.AvgValue, Is.EqualTo(50.25));
            Assert.That(sliceInfo.MinRow, Is.EqualTo(1));
            Assert.That(sliceInfo.MinCol, Is.EqualTo(2));
            Assert.That(sliceInfo.MaxRow, Is.EqualTo(3));
            Assert.That(sliceInfo.MaxCol, Is.EqualTo(4));

            Console.WriteLine("Assert passed: All SliceInfo properties validated correctly.");
        }
    }
}
