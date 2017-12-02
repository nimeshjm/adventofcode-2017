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
    }
}
