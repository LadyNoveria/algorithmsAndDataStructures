using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{

    class Program
    {

        static void Main(string[] args)
        {
            string finalFile = "finalFile.txt";
            int countOfValues = 200000;
            FillInFile(finalFile, countOfValues);
            List<string> listOfPaths = BreakIntoLists(finalFile, countOfValues);
            SortValues(listOfPaths);
            UnionBlocks(listOfPaths, finalFile);
        }
        public static void UnionBlocks(List<string> listOfPaths, string finalFile)
        {
            string[] arrayValues = File.ReadAllLines(listOfPaths[0]);
            File.WriteAllLines(finalFile, arrayValues);
            for (int i = 1; i < listOfPaths.Count; i++)
            {
                arrayValues = File.ReadAllLines(listOfPaths[i]);
                File.AppendAllLines(finalFile, arrayValues);
            }
        }
        public static void SortValues(List<string> listOfPaths)
        {
            for (int i = 0; i < listOfPaths.Count; i++)
            {
                string[] arrayOfValuesString = File.ReadAllLines(listOfPaths[i]);
                int[] arrayOfValuesInt = new int[arrayOfValuesString.Length];
                for (int j = 0; j < arrayOfValuesString.Length; j++)
                {
                    arrayOfValuesInt[j] = Convert.ToInt32(arrayOfValuesString[j]);
                }
                Array.Sort(arrayOfValuesInt);
                for (int j = 0; j < arrayOfValuesInt.Length; j++)
                {
                    arrayOfValuesString[j] = arrayOfValuesInt[j].ToString();
                }
                File.WriteAllLines(listOfPaths[i], arrayOfValuesString);
            }
        }
        public static List<string> BreakIntoLists(string path, int count)
        {
            List<string> listOfPaths = new List<string>();
            StreamReader streamReader = new StreamReader(path, System.Text.Encoding.Default);
            string fileName1 = $"block_1.txt";
            string fileName2 = $"block_2.txt";
            string fileName3 = $"block_3.txt";
            string fileName4 = $"block_4.txt";
            string fileName5 = $"block_5.txt";
            listOfPaths.Add(fileName1);
            listOfPaths.Add(fileName2);
            listOfPaths.Add(fileName3);
            listOfPaths.Add(fileName4);
            listOfPaths.Add(fileName5);
            List<string> range0_199 = new List<string>();
            List<string> range200_399 = new List<string>();
            List<string> range400_599 = new List<string>();
            List<string> range600_799 = new List<string>();
            List<string> range800_999 = new List<string>();
            for (int i = 0; i < count; i++)
            {
                int value = Convert.ToInt32(streamReader.ReadLine());
                if (value > 0 && value < 200)
                {
                    range0_199.Add(value.ToString());
                }
                else if (value >= 200 && value < 400)
                {
                    range200_399.Add(value.ToString());
                }
                else if (value >= 400 && value < 600)
                {
                    range400_599.Add(value.ToString());
                }
                else if (value >= 600 && value < 800)
                {
                    range600_799.Add(value.ToString());
                }
                else if (value >= 800)
                {
                    range800_999.Add(value.ToString());
                }
            }
            File.WriteAllLines(fileName1, range0_199);
            File.WriteAllLines(fileName2, range200_399);
            File.WriteAllLines(fileName3, range400_599);
            File.WriteAllLines(fileName4, range600_799);
            File.WriteAllLines(fileName5, range800_999);
            streamReader.Close();
            return listOfPaths;
        }

        public static void FillInFile(string fileName, int countOfValues)
        {
            int amountOfelements = countOfValues / 5;
            List<string> arrayOfValues = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < amountOfelements; j++)
                {
                    arrayOfValues.Add(new Random().Next(0, 1000).ToString());
                }
            }
            File.AppendAllLines(fileName, arrayOfValues);
        }
    }

}