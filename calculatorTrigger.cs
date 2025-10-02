using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function;

public class calculatorTrigger
{
    private readonly ILogger<calculatorTrigger> _logger;

    public calculatorTrigger(ILogger<calculatorTrigger> logger)
    {
        _logger = logger;
    }

    [Function("calculatorTrigger")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "calculator/{a:int}/{b:int}")] HttpRequest req, int a,int b)
    {
        int result = a + b;
        return new OkObjectResult("$The result of adding {a} and {b} is: {result}");
    }
}