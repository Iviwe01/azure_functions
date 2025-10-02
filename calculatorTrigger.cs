using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Company.Function.Models;

namespace Company.Function;

public class calculatorTrigger
{
    private readonly ILogger<calculatorTrigger> _logger;

    public calculatorTrigger(ILogger<calculatorTrigger> logger)
    {
        _logger = logger;
    }

    [Function("calculatorTrigger")]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "calculator/{a:int}/{b:int}")] HttpRequest req,
        int a,
        int b)
    {
        var result = new CalculationResults
        {
            A = a,
            B = b,
            Result = a + b,
            Operation = "add"
        };
        return new OkObjectResult(result);
    }
}