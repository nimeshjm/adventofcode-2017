using System;
using System.Linq;

namespace Garbage.Domain
{
    public class StreamGroups
    {
        public int Collect(string input, out int removed)
        {
            var currentCount = 0;
            var score = 0;
            var skipNext = false;
            var skipMultiple = false;
            removed = 0;

            foreach (var element in input)
            {
                if (skipNext)
                {
                    skipNext = false;
                    continue;
                }

                if (element == '!')
                {
                    skipNext = true;
                    removed--;
                }

                if (skipMultiple)
                {
                    if (element == '>')
                    {
                        skipMultiple = false;
                        removed--;
                    }

                    removed++;
                    continue;
                }

                switch (element)
                {
                    case '{':
                        currentCount++;
                        break;
                    case '}':
                        score += currentCount--;
                        break;
                    case '<':
                        skipMultiple = true;
                        break;
                }
            }

            return score;
        }
    }
}
