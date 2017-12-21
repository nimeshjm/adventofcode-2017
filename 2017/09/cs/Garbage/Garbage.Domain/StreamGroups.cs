namespace Garbage.Domain
{
    public class StreamGroups
    {
        public int Collect(string input)
        {
            var currentCount = 0;
            var score = 0;
            var skipNext = false;
            var skipMultiple = false;

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
                }

                if (skipMultiple)
                {
                    if (element == '>')
                    {
                        skipMultiple = false;
                    }

                    continue;
                }

                if (element == '{')
                {
                    currentCount++;
                }
                else if (element == '}')
                {
                    score += currentCount--;
                }
                else if (element == '<')
                {
                    skipMultiple = true;
                }
            }

            return score;
        }
    }
}
