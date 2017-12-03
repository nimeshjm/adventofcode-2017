using System;

namespace Manhattan.Domain
{
    public class DistanceCalculator
    {
        public int CalculateShortest(int index)
        {
            var sqrt = Math.Sqrt(index);

            if (sqrt % 1 == 0)
            {
                return (int)sqrt-1;
            }

            var wholeSqrt = (int)Math.Round(sqrt);
            return Math.Abs(index - wholeSqrt*wholeSqrt);
        }
    }
}
