using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace advent201903
{
    public static class Function1
    {
        [FunctionName("Advent201903")]
        public static async Task<IActionResult> Run1(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            string[] values = requestBody.Split(';');
            string[] line1 = values[0].Split(',');
            string[] line2 = values[1].Split(',');
            var path = new HashSet<(int,int)>();
            var path2 = new HashSet<(int,int)>();
            var position = (0, 0);

            for (int i = 0; i < line1.Length; i++)
            {
                char segmentDirection = line1[i][0];
                int count = int.Parse(line1[i].Substring(1));
                log.LogInformation($"{segmentDirection} {count}");
                position = Move(path, position, segmentDirection, count);
            }

            position = (0, 0);
            for (int i = 0; i < line2.Length; i++)
            {
                char segmentDirection = line2[i][0];
                int count = int.Parse(line2[i].Substring(1));
                log.LogInformation($"{segmentDirection} {count}");
                position = Move(path2, position, segmentDirection, count);
            }

            path.IntersectWith(path2);


            var distance = path.Skip(1).Min(p => CalculateManhattanDistance((0, 0), p));
            return new OkObjectResult(distance);
        }

        private static (int,int) Move(HashSet<(int,int)> path, (int, int) initialPosition, char segmentDirection, int count)
        {
            if (segmentDirection == 'U')
            {
                for (int i = 0; i < count; i++)
                {
                    path.Add((initialPosition.Item1 + i, initialPosition.Item2));
                }

                return (initialPosition.Item1 + count, initialPosition.Item2);
            }

            if (segmentDirection == 'D')
            {
                for (int i = 0; i < count; i++)
                {
                    path.Add((initialPosition.Item1 - i, initialPosition.Item2));
                }
                return (initialPosition.Item1 - count, initialPosition.Item2);
            }

            if (segmentDirection == 'L')
            {
                for (int i = 0; i < count; i++)
                {
                    path.Add((initialPosition.Item1, initialPosition.Item2 + i));
                }
                return (initialPosition.Item1, initialPosition.Item2 + count);
            }

            if (segmentDirection == 'R')
            {
                for (int i = 0; i < count; i++)
                {
                    path.Add((initialPosition.Item1, initialPosition.Item2 - i));
                }
                return (initialPosition.Item1, initialPosition.Item2 - count);
            }

            throw new Exception();
        }

        private static int CalculateManhattanDistance((int,int) p1, (int, int) p2)
        {
            return Math.Abs(p1.Item1 - p2.Item1) + Math.Abs(p1.Item2 - p2.Item2);
        }
    }
}
