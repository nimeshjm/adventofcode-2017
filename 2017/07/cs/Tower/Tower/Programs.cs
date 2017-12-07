using System.Collections.Generic;
using System.Linq;

namespace Tower
{
    public class Programs
    {
        public string FindBase(List<List<string>> testFixture)
        {
            var parentNodes = testFixture.Where(s => s.Count > 2).ToList();
            
            return parentNodes.Select(s => s.First()).Except(parentNodes.SelectMany(s => s.Skip(3)).Select(s => s.TrimEnd(','))).Single();
        }
    }
}
