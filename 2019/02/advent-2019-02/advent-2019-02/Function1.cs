using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace advent_2019_02
{
    public static class Function1
    {
        [FunctionName("part1")]
        public static async Task<IActionResult> Run1(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            long[] values = requestBody.Split(',').Select(long.Parse).ToArray();

            Part1(values);

            return new OkObjectResult($"{values[0]}");
        }

        [FunctionName("part2")]
        public static async Task<IActionResult> Run2(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            long result = 0;
            long output = 0;
            int i = 0;
            int k = 0;
            do
            {
                long[] values = requestBody.Split(',').Select(long.Parse).ToArray();
                values[1] = i;
                values[2] = k;
                Part1(values);
                result = values[0];
                output = 100 * values[1] + values[2];
                i++;
                if (i==100)
                {
                    i = 0;
                    k++;
                }
                log.LogInformation($"{i}:{k} - {result} - {output}");
            } while (result != 19690720);

            return new OkObjectResult($"{output}");
        }




        private static void Part1(long[] values)
        {
            long i = 0;
            while (i < values.Length && values[i] != 99)
            {

                values[values[i + 3]] = values[i] == 1
                    ? values[values[i + 1]] + values[values[i + 2]]
                    : values[values[i + 1]] * values[values[i + 2]];

                i += 4;
            }
        }


    }
}
