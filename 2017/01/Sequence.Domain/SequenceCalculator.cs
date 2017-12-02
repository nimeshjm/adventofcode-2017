using System;
using System.Collections.Generic;
using System.Linq;

namespace Sequence.Domain
{
    public class SequenceCalculator
    {
        public int Calculate(string sequence)
        {
            var ints = new List<int>();
            
            var enumerable = sequence.ToCharArray().Select(char.GetNumericValue).Select(Convert.ToInt32).ToList();
            enumerable.Add(enumerable.First());

            enumerable.Aggregate(
                (current, next) =>
                    {
                        if (current == next) ints.Add(current);
                        return next;
                    });

            return ints.Sum();
        }

        public int CalculateHalfway(string sequence)
        {
            var enumerable = sequence.ToCharArray().Select(char.GetNumericValue).Select(Convert.ToInt32).ToList();
            var delta = sequence.Length / 2;
            var count = enumerable.Count;

            var ints = enumerable.Where((t, i) => t == enumerable[(delta + i) % count]).ToList();

            return ints.Sum();
        }
    }
}
