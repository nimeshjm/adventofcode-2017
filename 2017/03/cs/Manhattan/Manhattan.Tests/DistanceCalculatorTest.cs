using Manhattan.Domain;
using NUnit.Framework;

namespace Manhattan.Tests
{
    [TestFixture]
    public class DistanceCalculatorTest 
    {
        [TestCase(1, 0)]
        [TestCase(12, 3)]
        [TestCase(23, 2)]
        [TestCase(1024, 31)]
        [TestCase(312051, 430)]
        public void Test1(int index, int expected)
        {
            var sut = new DistanceCalculator();

            var actual = sut.CalculateShortest(index);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
