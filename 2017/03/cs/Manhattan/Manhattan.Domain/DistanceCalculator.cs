using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// https://oeis.org/A141481
        /// </summary>
        /// <param name="index"></param>
        public int CalculateSpiralOfSumsOfPrecendingTerms(int index)
        {
            var items = new List<int>();
            for (int i = 0; i < index; i++)
            {
                if (i==0) items.Add(1);
                if (i==1) items.Add(items[items.Count-1]);
                if (i == 2)
                {
                    items.Add(items[items.Count - 2] + items[items.Count - 1]);
                }

                if (i == 3)
                {
                    items.Add(items[items.Count - 3] + items[items.Count - 2] + items[items.Count - 1]);
                }

                if (i == 4)
                {
                    items.Add(items[items.Count - 4] + items[items.Count - 1]);
                }

                if (i == 5)
                {
                    items.Add(items[items.Count - 5] + items[items.Count - 2] + items[items.Count - 1]);
                }

                if (i == 6)
                {
                    items.Add(items[items.Count - 6] + items[items.Count - 1]);
                }

                if (i == 7)
                {
                    items.Add(items[items.Count - 7] + items[items.Count - 6] + items[items.Count - 2] + items[items.Count - 1]);
                }

                if (i == 8)
                {
                    items.Add(items[items.Count - 8] + items[items.Count - 7] + items[items.Count - 1]);
                }

                if (i == 9)
                {
                    items.Add(items[items.Count - 9] + items[items.Count - 1]);
                }

                if (i == 10)
                {
                    items.Add(items[items.Count - 9] + items[items.Count - 8] + items[items.Count - 2] + items[items.Count - 1]);
                }


            }

            return items.Last();
            //const int m = 5;
            //var h = 2 * m - 1;
            //var a = new int[h, h];
            //var T = new[,] {{1, 0}, {1, -1}, {0, -1}, { -1, -1}, { -1, 0}, { -1, 1}, {0, 1}, {1, 1}};

            //for (n = 1, (h - 2) ^ 2 - 1, g = sqrtint(n); r = (g + g % 2)\2; q = 4 * r ^ 2; d = n - q; if (n <= q - 2 * r, j = d + 3 * r; k = r, if (n <= q, j = r; k = -d - r, if (n <= q + 2 * r, j = r - d; k = -r, j = -r; k = d - 3 * r))); j = j + m; k = k + m; s = 0;

            //for (var c = 1, 8, v =[j, k]; v += T[c]; s = s + A[v[1], v[2]])
            //{
            //    A[j, k] = s;
            //}
        }
    }
}
