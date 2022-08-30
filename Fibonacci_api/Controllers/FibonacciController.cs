using Fibonacci_api.Dtos;
using Fibonacci_api.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fibonacci_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FibonacciController : ControllerBase
    {
        
       
        private readonly ILogger<FibonacciController> _logger;
        private readonly IFibonacciService _fibonacciService;
        public FibonacciController(ILogger<FibonacciController> logger, IFibonacciService fibonacciService)
        {
            _logger = logger;
            _fibonacciService = fibonacciService;
        }

        [HttpGet(Name = "GetNFibonacci")]
        public FibonacciDto GetNFibonacci(int n)
        {
            return _fibonacciService.GetFibonacciNumber(n);
        }
    }
}