using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Checksums.Domain;
using NUnit.Framework;

namespace Checksums.Tests
{
    [TestFixture]
    public class ChecksumCalculatorTests
    {
        [Test]
        public void TestPart1Problem()
        {
            var sut = new ChecksumCalculator();

            var actual = sut.CalculatePart1(TestFixture("Checksums.Tests.TestData1Problem.txt"));

            Assert.That(actual, Is.EqualTo(18));
        }

        [Test]
        public void TestPart1Solution()
        {
            var sut = new ChecksumCalculator();

            var actual = sut.CalculatePart1(TestFixture("Checksums.Tests.TestData1Solution.txt"));

            Assert.That(actual, Is.EqualTo(45351));
        }

        private static List<List<int>> TestFixture(string inputFileName)
        {
            var lines = ReadLines(() => Assembly.GetExecutingAssembly().GetManifestResourceStream(inputFileName), Encoding.UTF8);

            return lines.Select(line => line.Split(' ').Select(int.Parse).ToList()).ToList();
        }

        private static IEnumerable<string> ReadLines(Func<Stream> streamProvider, Encoding encoding)
        {
            using (var stream = streamProvider())
            using (var reader = new StreamReader(stream, encoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
