using System;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;

            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    arr[i] = int.Parse(Console.ReadLine());

                    if (arr[i] <= start || arr[i] > end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                    i--;
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Your number is not in range {start} - 100!");
                    i--;
                    continue;
                }

                start = arr[i];
            }
            Console.Write(string.Join(", ", arr));
        }
    }
}
