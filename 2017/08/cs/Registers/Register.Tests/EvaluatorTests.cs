using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using Register.Domain;

namespace Register.Tests
{
    [TestFixture]
    public class EvaluatorTests
    {
        [TestCase("Register.Tests.Program1.txt", 1)]
        public void Test1(string program, int expected)
        {
            var sut = new Evaluator();

            var actual = sut.LargestValue("Register.Domain.Program1.txt", TestFixture(program));

            Assert.That(actual, Is.EqualTo(expected));
        }

        private static IEnumerable<string> TestFixture(string inputFileName)
        {
            var lines = ReadLines(() => Assembly.GetExecutingAssembly().GetManifestResourceStream(inputFileName), Encoding.UTF8);

            return lines;
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
