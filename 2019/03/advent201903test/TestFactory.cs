using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging.Abstractions;
using System.IO;

namespace Tests
{
    public class TestFactory
    {
        public static DefaultHttpRequest CreateHttpRequest(string body)
        {
            var request = new DefaultHttpRequest(new DefaultHttpContext())
            {
                Body = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(body))
            };

            return request;
        }

        public static Microsoft.Extensions.Logging.ILogger CreateLogger()
        {
            return NullLoggerFactory.Instance.CreateLogger("Null Logger");
        }
    }
}