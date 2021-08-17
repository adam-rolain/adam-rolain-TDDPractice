using System;

namespace OddEven
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(OddEven.DisplayEvenOddPrime());
        }
    }

    public class OddEven 
    {
        // STATIC METHODS
        public static string DisplayEvenOddPrime()
        {
            string output = "";

            for (int i = 1; i <= 100; i++)
            {
                output += $"{i}. {CategorizeEvenOddPrime(i)}\n";
            }

            return output;
        }

        public static string CategorizeEvenOddPrime(int _num)
        {
            string conversion = "";

            // Set conversion to EVEN or ODD
            if (IsEven(_num))
            {
                conversion = "EVEN";
            }
            else
            {
                conversion = "ODD";
            }

            // Edit conversion to PRIME if it is a prime number
            if (PrimeNumbers.IsPrimeNumber(_num))
            {
                conversion = "PRIME";
            }

            return conversion;
        }

        public static bool IsEven(int _num)
        {
            if (_num % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    public class PrimeNumbers
    {
        // METHODS
        public static int GetPrime(int n)
        {
            int counter = 0;
            int currentNumber = 2;

            while (counter < n)
            {
                if (IsPrimeNumber(currentNumber))
                {
                    counter++;
                }
                currentNumber++;
            }

            currentNumber--;
            return currentNumber;
        }

        public static bool IsPrimeNumber(int _num)
        {
            bool isPrime = true;

            for (double i = _num - 1; i > 1; i--)
            {
                double result = _num / i;
                if (result % 1 == 0)
                {
                    isPrime = false;
                }
            }

            return isPrime;
        }
    }
}
