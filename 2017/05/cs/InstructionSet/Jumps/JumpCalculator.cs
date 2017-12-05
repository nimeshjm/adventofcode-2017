using System;
using System.Linq;

namespace Jumps
{
    public class JumpCalculator
    {
        public int CalculateSteps(int[] steps)
        {
            var index = 0;
            var counter = 0;
            while (index < steps.Length)
            {
                index+= steps[index]++;
                counter++;
            }

            return counter;
        }
    }
}
