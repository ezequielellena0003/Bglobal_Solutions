using Fibonacci_api.Dtos;

namespace Fibonacci_api.Interface
{
    public interface IFibonacciService
    {
        public FibonacciDto GetFibonacciNumber(int n);
    }
}
