using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using Passphrases.Domain;

namespace Passphrases.Tests
{
    [TestFixture]
    public class PassphraseValidatorTests
    {
        [TestCase("Passphrases.Tests.TestData1Problem.txt", 2)]
        [TestCase("Passphrases.Tests.TestData1Solution.txt", 455)]
        public void Test1(string datafile, int expected)
        {
            var sut = new PassphraseValidator();

            var testFixture = TestFixture(datafile);
            var actual = testFixture.Count(sut.IsValid);

            Assert.That(actual, Is.EqualTo(expected));
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
