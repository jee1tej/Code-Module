using System;

namespace ReckonCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintBossHog();

            Console.ReadKey();
        }

        private static  void PrintBossHog()
        {
            for (var i = 1; i <= 100; i++)
            {
                var output = string.Empty;

                output += i % 3 == 0 ? "Boss" : string.Empty;
                output += i % 5 == 0 ? "Hog" : string.Empty;

                Console.WriteLine(string.IsNullOrEmpty(output) ? i.ToString() : output);
            }
        }

        
    }
}
