using System.Collections.Generic;
using System.Linq;

namespace Checksums.Domain
{
    public class ChecksumCalculator
    {
        public int CalculatePart1(List<List<int>> matrix)
        {
            return matrix.Select(innerRow => innerRow.Max() - innerRow.Min()).Sum();
        }

        public int CalculatePart2(List<List<int>> matrix)
        {
            return matrix.Sum(
                row => row.Select(
                    (item, index) => row.Skip(index + 1)
                                        .Sum(i => item % i == 0 ? item / i : (i % item == 0 ? i / item : 0)))
                    .Sum());
        }
    }
}
