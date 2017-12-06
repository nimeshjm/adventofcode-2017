using MemoryRedistribution.Domain;
using NUnit.Framework;

namespace MemoryRedistribution.Tests
{
    [TestFixture]
    public class BalancerTests
    {
        [TestCase(new[] { 0, 2, 7, 0 }, 5, 1)]
        [TestCase(new[] { 0, 2, 7, 0 }, 4, 2)]
        [TestCase(new[] { 5, 1, 10, 0, 1, 7, 13, 14, 3, 12, 8, 10, 7, 12, 0, 6 }, 5042, 1)]
        [TestCase(new[] { 5, 1, 10, 0, 1, 7, 13, 14, 3, 12, 8, 10, 7, 12, 0, 6 }, 5042, 2)]
        public void Test1(int[] bankCount, int expected, int part)
        {
            var sut = new Balancer();
            
            var actual = sut.Balance(bankCount, part);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
