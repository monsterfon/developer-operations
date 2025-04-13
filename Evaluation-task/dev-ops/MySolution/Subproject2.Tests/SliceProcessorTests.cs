using NUnit.Framework;
using Subproject2;
using System.IO;
using System.Linq;
using Subproject1;
using System;

namespace Subproject2.Tests
{
    [TestFixture]
    public class SliceProcessorTests
    {
        private string _testDir;

        [SetUp]
        public void SetUp()
        {
            _testDir = Path.Combine(Path.GetTempPath(), "SliceProcessorTests");
            Directory.CreateDirectory(_testDir);
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(_testDir, true);
        }

        [Test]
        public void ProcessSlices_ShouldParseAndComputeCorrectly()
        {
            // Create slice1.txt
            File.WriteAllLines(Path.Combine(_testDir, "slice1.txt"), new[]
            {
                "10",    // Z-position
                "2 2",   // width=2, height=2
                "1 2 3 4"
            });

            // Create slice2.txt
            File.WriteAllLines(Path.Combine(_testDir, "slice2.txt"), new[]
            {
                "20",
                "2 2",
                "5 6 7 8"
            });

            var processor = new SliceProcessor();
            var results = processor.ProcessSlices(_testDir);

            Assert.That(results.Count, Is.EqualTo(2), "Should find 2 slices.");
            Console.WriteLine("Assert passed: Found 2 slices.");

            var first = results.First(r => r.ZPosition == 10);
            Assert.That(first.MinValue, Is.EqualTo(1));
            Assert.That(first.MaxValue, Is.EqualTo(4));
            Assert.That(first.AvgValue, Is.EqualTo(2.5));
            Console.WriteLine("Assert passed: First slice computed correctly (min=1, max=4, avg=2.5).");

            var second = results.First(r => r.ZPosition == 20);
            Assert.That(second.MinValue, Is.EqualTo(5));
            Assert.That(second.MaxValue, Is.EqualTo(8));
            Assert.That(second.AvgValue, Is.EqualTo(6.5));
            Console.WriteLine("Assert passed: Second slice computed correctly (min=5, max=8, avg=6.5).");
        }
    }
}
