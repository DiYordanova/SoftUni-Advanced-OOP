using System;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            try
            {
                n = int.Parse(Console.ReadLine());
                if (n < 0)
                {
                    throw new Exception();
                }
                Console.WriteLine(Math.Sqrt(n));
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number.");
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
