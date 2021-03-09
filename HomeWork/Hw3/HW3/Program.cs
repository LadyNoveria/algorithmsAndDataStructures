using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
namespace Hw3
{
    public class PointClass
    {
        public float X { get; set; }
        public float Y { get; set; }
        public PointClass(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    public class PointStruct
    {
        public float X { get; set; }
        public float Y { get; set; }
        public PointStruct(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
    public class PointStructDouble
    {
        public double X { get; set; }
        public double Y { get; set; }
        public PointStructDouble(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
    public class Benchmaker
    {
        public static PointClass[] ArrayPointsClassX = FillingArray(10);
        public static PointClass[] ArrayPointsClassY = FillingArray(10);
        public static PointStruct[] ArrayPointsStructX = FillingArrayStruct(10);
        public static PointStruct[] ArrayPointsStructY = FillingArrayStruct(10);
        public static PointStructDouble[] ArrayPointsStructDoubleX = FillingArrayStructDouble(10);
        public static PointStructDouble[] ArrayPointsStructDoubleY = FillingArrayStructDouble(10);

        [Benchmark]
        public void PointDistanceClass()
        {
            for (int i = 0; i < ArrayPointsClassX.Length; i++)
            {
                if (i % 2 == 0)
                {
                    float x = ArrayPointsClassX[i].X - ArrayPointsClassX[i + 1].X;
                    float y = ArrayPointsClassY[i].Y - ArrayPointsClassY[i + 1].Y;
                    GetDistance(x, y);
                }
            }
        }

        [Benchmark]
        public void PointDistanceStructFloat()
        {
            for (int i = 0; i < ArrayPointsStructX.Length; i++)
            {
                if (i % 2 == 0)
                {
                    float x = ArrayPointsStructX[i].X - ArrayPointsStructX[i + 1].X;
                    float y = ArrayPointsStructY[i].Y - ArrayPointsStructY[i + 1].Y;
                    GetDistance(x, y);
                }
            }
        }
        public float GetDistance(float x, float y)
        {
            return MathF.Sqrt((x * x) + (y * y));
        }

        [Benchmark]
        public void PointDistanceDouble()
        {
            for (int i = 0; i < ArrayPointsStructDoubleX.Length; i++)
            {
                if (i % 2 == 0)
                {
                    double x = ArrayPointsStructDoubleX[i].X - ArrayPointsStructDoubleX[i + 1].X;
                    double y = ArrayPointsStructDoubleX[i].Y - ArrayPointsStructDoubleY[i + 1].Y;
                    GetPointDistanceDouble(x, y);
                }
            }
        }
        public double GetPointDistanceDouble(double x, double y)
        {
            return Math.Sqrt((x * x) + (y * y));
        }

        [Benchmark]
        public void PointDistanceWithoutSqrt()
        {
            for (int i = 0; i < ArrayPointsStructX.Length; i++)
            {
                if (i % 2 == 0)
                {
                    float x = ArrayPointsStructX[i].X - ArrayPointsStructX[i + 1].X;
                    float y = ArrayPointsStructY[i].Y - ArrayPointsStructY[i + 1].Y;
                    GetPointDistanceWithotSqrt(x, y);
                }
            }
        }
        public float GetPointDistanceWithotSqrt(float x, float y)
        {
            return (x * x) + (y * y);
        }
        //Заполнение массива рандомными тестовыми значениями типа PointClass (тип данных float)
        static public PointClass[] FillingArray(int length)
        {
            PointClass[] arrayValues = new PointClass[length];
            Random rnd = new Random();
            for (int i = 0; i < arrayValues.Length; i++)
            {
                arrayValues[i] = new PointClass((float)rnd.NextDouble(), (float)rnd.NextDouble());
            }
            return arrayValues;
        }

        //Заполнение массива рандомными тестовыми значениями типа PointStruct (тип данных float)
        static public PointStruct[] FillingArrayStruct(int length)
        {
            PointStruct[] arrayValues = new PointStruct[length];
            Random rnd = new Random();
            for (int i = 0; i < arrayValues.Length; i++)
            {
                arrayValues[i] = new PointStruct((float)rnd.NextDouble(), (float)rnd.NextDouble());
            }
            return arrayValues;
        }

        //Заполнение массива рандомными тестовыми значениями типа PointStructDouble (тип данных double)
        static public PointStructDouble[] FillingArrayStructDouble(int length)
        {
            PointStructDouble[] arrayValues = new PointStructDouble[length];
            Random rnd = new Random();
            for (int i = 0; i < arrayValues.Length; i++)
            {
                arrayValues[i] = new PointStructDouble(rnd.NextDouble(), rnd.NextDouble());
            }
            return arrayValues;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Напишите тесты производительности для расчёта дистанции между точками с помощью BenchmarkDotNet.
            * Рекомендуем сгенерировать заранее массив данных, чтобы расчёт шёл с различными значениями, но сам
            * код генерации должен происходить вне участка кода, время которого будет тестироваться.
            Для каких методов потребуется написать тест:
            Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).
            Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).
            Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).
            Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты 
            типа float).*/

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        }
    }
}