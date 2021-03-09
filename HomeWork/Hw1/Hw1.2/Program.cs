using System;

namespace Hw1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Вычислите асимптотическую сложность функции из примера ниже. */
            int[] inputArray = {1, 2, 3, 4, 5, 6, 7, 9, 0};
            Console.WriteLine(StangerSum(inputArray));
            Console.ReadKey();
        }

        public static int StangerSum(int[] inputArray)
        {
            int sum = 0; //O(1)
            for (int i = 0; i < inputArray.Length; i++) //O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) //O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) //O(N)
                    {
                        int y = 0; //O(1)
                        if (j != 0) //О(1)
                        {
                            y = k / j; 
                        }
                        sum += inputArray[i] + i + k + j + y; //O(1)
                    }
                }
            }
            return sum; //O(1)
            //Асимптотическая сложность: O(1 + (N * N * ((1 + 1 + 1) * N) + 1) = 2 + 3N^3
        }
    }
}
