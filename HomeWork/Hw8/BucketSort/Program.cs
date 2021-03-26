using System;
using System.Collections.Generic;

namespace BucketSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfList = 80;//количество значений в списке
            List<int> listOfValue = FillInTheList(countOfList);
            int[][] arrayOfValues = BreakIntoLists(listOfValue);
            List<int> finalList = BucketSort(arrayOfValues);
            foreach (int value in finalList)
            {
                Console.Write($"{value} ");
            }
        }
        public static List<int> BucketSort(int[][] arrayOfValues)
        {
            List<int> finalList = new List<int>();
            for (int i = 0; i < arrayOfValues.Length; i++)
            {
                for (int j = 0; j < arrayOfValues[i].Length; j++)
                {
                    finalList.Add(arrayOfValues[i][j]);
                }
            }
            return finalList;
        }
        //заполнение списка рандомными значениями
        public static List<int> FillInTheList(int count)
        {
            List<int> arrayOfValues = new List<int>();
            for (int i = 0; i < count; i++)
            {
                arrayOfValues.Add(new Random().Next(0, 100));
            }
            return arrayOfValues;
        }
        //Разбивка на блоки
        public static int[][] BreakIntoLists(List<int> arrayOfValue)
        {
            List<int> range0_19 = new List<int>();
            List<int> range20_49 = new List<int>();
            List<int> range50_79 = new List<int>();
            List<int> range80_99 = new List<int>();
            for (int i = 0; i < arrayOfValue.Count; i++)
            {
                if (arrayOfValue[i] >= 0 && arrayOfValue[i] < 20)
                {
                    range0_19.Add(arrayOfValue[i]);
                }
                else if (arrayOfValue[i] >= 20 && arrayOfValue[i] < 50) {
                    range20_49.Add(arrayOfValue[i]);
                }
                else if (arrayOfValue[i] >= 50 && arrayOfValue[i] < 80)
                {
                    range50_79.Add(arrayOfValue[i]);
                }
                else if(arrayOfValue[i] >= 80)
                {
                    range80_99.Add(arrayOfValue[i]);
                }
            }
            int[] arrayOfValues0_19 = MoveFromListToArray(range0_19);
            int[] arrayOfValues20_49 = MoveFromListToArray(range20_49);
            int[] arrayOfValues50_79 = MoveFromListToArray(range50_79);
            int[] arrayOfValues80_99 = MoveFromListToArray(range80_99);
            int[][] arrayOfValues = new int[4][];
            arrayOfValues[0] = arrayOfValues0_19;
            arrayOfValues[1] = arrayOfValues20_49;
            arrayOfValues[2] = arrayOfValues50_79;
            arrayOfValues[3] = arrayOfValues80_99;
            return arrayOfValues;
        }
        //Перенос значений из List в Array
        public static int[] MoveFromListToArray(List<int> ListOfValue)
        {
            int[] arrayOfValue = new int[ListOfValue.Count];
            for (int i = 0; i < ListOfValue.Count; i++)
            {
                arrayOfValue[i] = ListOfValue[i];
            }
            Array.Sort(arrayOfValue);
            return arrayOfValue;
        }
    }
}
