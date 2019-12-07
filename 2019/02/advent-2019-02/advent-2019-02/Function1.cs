using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;

namespace advent_2019_02
{
    public static class Function1
    {
        [FunctionName("part1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            long[] values = requestBody.Split(',').Select(long.Parse).ToArray();

            long i = 0;
            while(i < values.Length && values[i] != 99) {
            
                values[values[i + 3]] = values[i] == 1 ? values[values[i + 1]] + values[values[i + 2]] : values[values[i + 1]] * values[values[i + 2]];

                log.LogInformation($"opcode: {values[i]}");

                i += 4;
            }


            return (ActionResult)new OkObjectResult($"{values[0]}");
        }
    }
}
