using System;
using System.Linq;

namespace Jumps
{
    public class JumpCalculator
    {
        public int CalculateSteps(int[] steps, int part = 1)
        {
            var index = 0;
            var counter = 0;
            while (index < steps.Length)
            {
                index+= part == 2 && steps[index] >= 3 ? steps[index]-- : steps[index]++;
                counter++;
            }

            return counter;
        }
    }
}
