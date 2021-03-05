using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
namespace Hw4._1
{
    public class Benchmaker
    {
        public static HashSet<string> hashSet = new HashSet<string>();
        public static string[] randomStringsArray = FillingArray(10000, hashSet);

        public static string[] FillingArray(int count, HashSet<string> hashSet)
        {
            string[] randomArray = new string[count];
            for (int i = 0; i < randomArray.Length; i++)
            {
                string randomString = GetRandomString(11);
                randomArray[i] = randomString;
                hashSet.Add(randomString);
            }
            return randomArray;
        }

        [Benchmark]
        public void SearchStringInArray()
        {
            string searchString = "Hello World";
            for (int i = 0; i < randomStringsArray.Length; i++)
            {
                if (randomStringsArray[i] == searchString)
                {
                    return;
                }
            }
        }
        [Benchmark]
        public void SearchStringInHashset()
        {
            string searchString = "Hello World";
            if (hashSet.Contains(searchString))
                return;
        }
        public static string GetRandomString(int lengthString)
        {
            string randomString = "";
            Random rnd = new Random();
            for (int i = 0; i < lengthString; i++)
            {
                char tmpChar = (char)rnd.Next(0, 255);
                randomString += tmpChar;
            }
            return randomString;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Заполните массив и HashSet случайными строками, не менее 10 000 строк. Строки можно сгенерировать. 
             * Потом выполните замер производительности проверки наличия строки в массиве и HashSet. Выложите код и 
             * результат замеров.*/

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}