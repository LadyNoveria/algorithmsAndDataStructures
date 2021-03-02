using System;
using VerificationLibrary;

namespace Hw1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Реализуйте функцию вычисления числа Фибоначчи.
             * Требуется реализовать рекурсивную версию и версию без рекурсии (через цикл).*/
            VerificationClass[] verificationValues = new VerificationClass[7];
            verificationValues = FillingArray(verificationValues);
            Tests(verificationValues);
        }

        static public VerificationClass[] FillingArray(VerificationClass[] verificationValues)
        {
            verificationValues[0] = new VerificationClass("0", "0");
            verificationValues[1] = new VerificationClass("1", "1");
            verificationValues[2] = new VerificationClass("6", "8");
            verificationValues[3] = new VerificationClass("20", "6765");
            verificationValues[4] = new VerificationClass("-1", "Negative value");
            verificationValues[5] = new VerificationClass("five", "Invalid data type");
            verificationValues[6] = new VerificationClass(null, "Invalid data type");
            return verificationValues;
        }
        //Нахождение числа Фибоначчи с помощью рекурсии
        static public int FindFibonacci(int number)
        {
            if (number < 2)
                return number;
            return FindFibonacci(number - 1) + FindFibonacci(number - 2);
        }
        //Нахождение числа Фибоначчи с помощью цикла
        static public int FindFibonacciCicle(int number)
        {
            int fibonacciNumber = 0;
            int secondValue = 1;
            int tmpValue;
            for (int i = 0; i < number; i++)
            {
                tmpValue = fibonacciNumber;
                fibonacciNumber = secondValue;
                secondValue += tmpValue;
            }
            return fibonacciNumber;
        }

        public static void Tests(VerificationClass[] verificationValues)
        {
            for(int i = 0; i < verificationValues.Length; i++)
            {
                if (int.TryParse(verificationValues[i].numberForCheck, out int result))
                {
                    if (result >= 0)
                        Console.WriteLine($"Fibonacci number for {verificationValues[i].numberForCheck} is {FindFibonacciCicle(result)} (cicle) / {FindFibonacci(result)} (recursion). Expected value: {verificationValues[i].expectedValue}");
                    else
                        Console.WriteLine($"Fibonacci number for {verificationValues[i].numberForCheck} is \"Negative value\". Expected value: {verificationValues[i].expectedValue}");
                }
                else
                    Console.WriteLine($"Fibonacci number for {verificationValues[i].numberForCheck} is \"Invalid data type\". Expected value: {verificationValues[i].expectedValue}");
            }
        }
    }
}
