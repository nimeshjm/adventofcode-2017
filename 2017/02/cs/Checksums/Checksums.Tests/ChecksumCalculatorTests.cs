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
        [TestCase("Checksums.Tests.TestData1Problem.txt", 18)]
        [TestCase("Checksums.Tests.TestDataSolution.txt", 45351)]
        public void TestPart1Problem(string dataFile, int expected)
        {
            var sut = new ChecksumCalculator();

            var actual = sut.CalculatePart1(TestFixture(dataFile));

            Assert.That(actual, Is.EqualTo(expected));
        }
        
        [TestCase("Checksums.Tests.TestData2Problem.txt", 9)]
        [TestCase("Checksums.Tests.TestDataSolution.txt", 275)]
        public void TestPart2Problem(string dataFile, int expected)
        {
            var sut = new ChecksumCalculator();

            var actual = sut.CalculatePart2(TestFixture(dataFile));

            Assert.That(actual, Is.EqualTo(expected));
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
