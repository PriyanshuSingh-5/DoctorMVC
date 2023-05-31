using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            PrintNumbers(1);

        }
        public static void PrintNumbers(int number)
        {
            if (number <= 100)
            {
                Console.WriteLine(number);
                PrintNumbers(number + 1);
            }
        }
    }
}
