using NUnit.Framework;

namespace KnotHash.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(new [] {3, 4, 1, 5}, 5, 12)]
        public void Test1(int[] lengths, int sequenceLength, int expected)
        {
            var sut = new Calculator(sequenceLength);

            var actual = sut.MultiplyFirstTwo(lengths);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
