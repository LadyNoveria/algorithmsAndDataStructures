using System;
using VerificaionLibrary;
namespace HW2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Требуется написать функцию бинарного поиска, посчитать его асимптотическую сложность 
             * и проверить работоспособность функции*/

            int[] arrayValues = {-15, 52, 2, 0, -78, -6, -1, 636, 54, 1, 23, 10, -20, 66, 84, -36, -877, 4, 40, -5};
            Array.Sort(arrayValues);

            //блок проверок
            VerificationClass[] arrayCheck = new VerificationClass[8];
            arrayCheck = FillingArray(arrayCheck);
            for (int i = 0; i < arrayCheck.Length; i++)
            {
                Console.WriteLine($"Value {arrayCheck[i].NumberForCheck} is: {BinarySearch(arrayValues, arrayCheck[i].NumberForCheck)}. Expected value: {arrayCheck[i].ExpectedValue}");
            }
            
        }
        public static VerificationClass[] FillingArray(VerificationClass[] verificationValues)
        {
            verificationValues[0] = new VerificationClass("-877", "Found");
            verificationValues[1] = new VerificationClass("636", "Found");
            verificationValues[2] = new VerificationClass("-878", "Not Found");
            verificationValues[3] = new VerificationClass("637", "Not Found");
            verificationValues[4] = new VerificationClass("-1", "Found");
            verificationValues[5] = new VerificationClass("66", "Found");
            verificationValues[6] = new VerificationClass(null, "Invalid data type");
            verificationValues[7] = new VerificationClass("ten", "Invalid data type");
            return verificationValues;
        }
        public static string BinarySearch(int[] arrayValues, string verificationValue)
        {
            //асимптотическая сложность алгоритма O(log(N))
            int min = 0; 
            int max = arrayValues.Length - 1; 

            if (int.TryParse(verificationValue, out int result)) 
            {
                while (min <= max) 
                {
                    int mid = (min + max) / 2; 
                    if (arrayValues[mid] == result)
                    {
                        return "Found";
                    }
                    else if (arrayValues[mid] > result)
                    {
                        max = mid - 1;
                    }
                    else
                    {
                        min = mid + 1;
                    }
                }
            }
            else if(!int.TryParse(verificationValue, out int result1)){
                return "Invalid data type";
            }

            return "Not Found";
        }
    }
}
