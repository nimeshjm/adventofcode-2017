using System.Collections.Generic;
using System.Linq;

namespace KnotHash
{
    public class Calculator
    {
        private readonly int sequenceLength;

        public Calculator(int sequenceLength)
        {
            this.sequenceLength = sequenceLength;
        }

        public int MultiplyFirstTwo(int[] lengths)
        {
            var sequence = new LinkedList<int>(Enumerable.Range(0, sequenceLength));
            var position = 0;
            var skip = 0;

            foreach (var reverseLength in lengths)
            {
                sequence.rev
            }

            return 0;
        }
    }
}
