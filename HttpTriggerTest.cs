using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Test.Function
{
    public class HttpTriggerTest
    {
        private readonly ILogger<HttpTriggerTest> _logger;

        public HttpTriggerTest(ILogger<HttpTriggerTest> logger)
        {
            _logger = logger;
        }

        [Function("HttpTriggerTest")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            //return new OkObjectResult("Welcome to Azure Functions!");
            if (req.Method == HttpMethods.Get)
            {
                var dummyData = new
                {
                    Id = 1,
                    Name = "Sample Item",
                    Description = "This is a sample item.",
                    Price = 19.99,
                    InStock = true
                };

                return new OkObjectResult(dummyData);
            }
            return new OkObjectResult("Welcome to Azure Functions!!");
        }
    }
}
