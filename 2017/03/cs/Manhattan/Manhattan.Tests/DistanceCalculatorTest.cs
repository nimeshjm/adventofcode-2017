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

        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        [TestCase(6, 10)]
        [TestCase(7, 11)]
        [TestCase(8, 23)]
        [TestCase(9, 25)]
        [TestCase(10, 26)]
        [TestCase(11, 54)]
        public void Test2(int index, int expected)
        {
            var sut = new DistanceCalculator();

            var actual = sut.CalculateSpiralOfSumsOfPrecendingTerms(index);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
