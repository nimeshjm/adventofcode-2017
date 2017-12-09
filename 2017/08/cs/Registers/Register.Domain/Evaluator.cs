using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Register.Domain
{
    public class Evaluator
    {
        public static void Main(string[] args)
        {
            var evaluator = new Evaluator();
            evaluator.LargestValue("Register.Domain.Program1.txt");
            evaluator.LargestValue("Register.Domain.Solution.txt");
        }

        public int LargestValue(string fileName)
        {
            var source = ReadLines(fileName, Encoding.UTF8).ToList();
            var variables = source.Select(s => s.First()).Distinct().Aggregate("", (accum, next) => $"{accum}{next}, ", s => s.Remove(s.Length - 2));
            var conditions = source.Select(s => "if (" + string.Join(" ", s.Skip(4)) + ")").ToList();
            var statements = source.Select(x => $"{x.First()} {GetOperator(x.ElementAt(1))} {x.ElementAt(2)}; max = Math.Max(max, {x.First()});").ToList();

            var code = @"
            using System;
            using System.Linq;

            public class Advent
            {
                int " + variables + @";
                int max = 0;

                public int Part1() 
                {
                    " + string.Join(string.Empty, conditions.Zip(statements, (x, y) => $"{x} {y}{Environment.NewLine}\t\t\t")) + @"
                    return new [] { " + variables + @" }.Max();
                }
 
                public int Part2() 
                {
                    " + string.Join(string.Empty, conditions.Zip(statements, (x, y) => $"{x} {y}{Environment.NewLine}\t\t\t")) + @"
                    return max;
                }

            }";

            // Console.WriteLine(code);
            CSharpScriptEngine.Execute(code);
            CSharpScriptEngine.Execute("var advent = new Advent();");
            CSharpScriptEngine.Execute("Console.WriteLine(advent.Part1());");
            CSharpScriptEngine.Execute("Console.WriteLine(advent.Part2());");

            return 0;
        }

        private string GetOperator(string s)
        {
            return s == "inc" ? "+=" : "-=";
        }

        private static IEnumerable<List<string>> ReadLines(string inputFileName, Encoding encoding)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(inputFileName))
            using (var reader = new StreamReader(stream, encoding))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line.Split(' ').ToList();
                }
            }
        }
    }
}
