using System;
using VerificationLibrary;

namespace Hw1._1
{
    class Program
    {
        /*Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм 
         * проверки, простое число или нет.
            Написать консольное приложение.
            Алгоритм реализовать отдельно в функции согласно блок-схеме.
            Написать проверочный код в main функции .*/
        static void Main(string[] args)
        {
            VerificationClass[] verificationValues = new VerificationClass[6];
            verificationValues = FillingArray(verificationValues);
            Tests(verificationValues);
            Console.ReadKey();
        }
        //Проверка числа на Простое/Не простое
        static public string CheckNumber(int number) {
            int d = 0;
            int i = 2;
            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }
                i++;
            }

            if (d == 0)
            {
                return "Prime number";
            }
            else
                return "Not a prime number";
        }
        //Заполнение массива значениями для тестов
        static public VerificationClass[] FillingArray(VerificationClass[] verificationValues)
        {
            verificationValues[0] = new VerificationClass("3","Prime number");
            verificationValues[1] = new VerificationClass("1999", "Prime number");
            verificationValues[2] = new VerificationClass("25", "Not a prime number");
            verificationValues[3] = new VerificationClass("-7", "Negative number");
            verificationValues[4] = new VerificationClass("three", "Invalid data type.");
            verificationValues[5] = new VerificationClass("Invalid data type");
            return verificationValues;
        }
        //Тестирование
        static public void Tests(VerificationClass[] verificationValues)
        {
            for (int i = 0; i < verificationValues.Length; i++)
            {
                if (int.TryParse(verificationValues[i].numberForCheck, out int result))
                {
                    if (result > 0)
                        Console.WriteLine($"Result of check for value {verificationValues[i].numberForCheck} is {CheckNumber(result)}. Expexted value: {verificationValues[i].expectedValue}");
                    else
                        Console.WriteLine($"Result of check for value {verificationValues[i].numberForCheck} is \"Negative number\". Expected value: {verificationValues[i].expectedValue}");
                }
                else
                    Console.WriteLine($"Result of check for value { verificationValues[i].numberForCheck} is \"Invalid data type\". Expected value: {verificationValues[i].expectedValue}");
            }
        }
    }
}
