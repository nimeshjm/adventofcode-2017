using System;
using System.Collections.Generic;
using System.Linq;

namespace Tower
{
    public class Programs
    {
        public string FindBase(List<List<string>> testFixture)
        {
            var parentNodes = testFixture.Where(s => s.Count > 2).ToList();
            
            return parentNodes.Select(s => s.First()).Except(parentNodes.SelectMany(GetChildren).Select(RemoveComma)).Single();
        }

        private IEnumerable<string> GetChildren(IEnumerable<string>s)
        {
            return s.Skip(3);
        }

        public int FindWeight(List<List<string>> testFixture)
        {
            var @base = FindBase(testFixture);

            var childrenNames = GetChildrenNames(@base, testFixture);

            var orderByDescending = childrenNames.Select(c => this.CalculateWeight(c, testFixture)).GroupBy(x => x).OrderByDescending(c => c.Count());
            return orderByDescending.First().Key;
        }

        private int CalculateWeight(string arg, IReadOnlyCollection<List<string>> testFixture)
        {
            var childrenNames = GetChildrenNames(arg, testFixture);
            return GetWeight(testFixture.Single(s => s.First().Equals(arg)).ElementAt(1)) + childrenNames.Sum(c => CalculateWeight(c, testFixture));
        }

        private static IEnumerable<string> GetChildrenNames(string arg, IEnumerable<List<string>> testFixture)
        {
            return testFixture.Single(s => s.First().Equals(arg)).Skip(3).Select(RemoveComma).ToList();
        }

        private static string RemoveComma(string s)
        {
            return s.TrimEnd(',');
        }

        private int GetWeight(string weight)
        {
            return Convert.ToInt32(weight.Trim('(', ')'));
        }
    }
}
