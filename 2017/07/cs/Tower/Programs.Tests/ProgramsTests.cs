using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Programs.Tests
{
    [TestFixture]
    public class ProgramsTests
    {
        [TestCase("Programs.Tests.TestData1Problem.txt", "tknk")]
        [TestCase("Programs.Tests.TestDataSolution.txt", "uownj")]
        public void Test1(string datafile, string expected)
        {
            var sut = new Tower.Programs();
            var actual = sut.FindBase(TestFixture(datafile));
            Assert.AreEqual(expected, actual);
        }

        private static List<List<string>> TestFixture(string inputFileName)
        {
            var lines = ReadLines(() => Assembly.GetExecutingAssembly().GetManifestResourceStream(inputFileName), Encoding.UTF8);

            return lines.Select(line => line.Split(' ').ToList()).ToList();
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
