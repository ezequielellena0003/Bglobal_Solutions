using Fibonacci_api.Dtos;
using Fibonacci_api.Interface;

namespace Fibonacci_api.Service
{
    public class FibonacciService : IFibonacciService
    {
        public FibonacciDto GetFibonacciNumber(int n)
        {
            var fibonacciDto = new FibonacciDto();
            if (n == 0) {
                fibonacciDto.number = n;
                return fibonacciDto;
            }
            int[] Fib = new int[n + 1];
            Fib[0] = 0;
            Fib[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                Fib[i] = Fib[i - 2] + Fib[i - 1];
            }

            fibonacciDto.number = Fib[n];
            return fibonacciDto;
        }
    }
}
