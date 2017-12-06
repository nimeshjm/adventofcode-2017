using System.Collections.Generic;
using System.Linq;

namespace MemoryRedistribution.Domain
{
    public class Balancer
    {
        public int Balance(int[] bankCount, int part)
        {
            var state = new List<int[]> ();

            while (!state.Any(s => s.SequenceEqual(bankCount)))
            {
                state.Add(bankCount.ToArray());

                var item = bankCount.Max();
                var index = bankCount.ToList().IndexOf(item);

                bankCount[index++ % bankCount.Length] = 0;

                for (var i=0; i<item;i++)
                {
                    bankCount[index++ % bankCount.Length]++;
                }
            }

            return part==1 ? state.Count : state.Count - state.IndexOf(state.First(s=>s.SequenceEqual(bankCount)));
        }
    }
}
