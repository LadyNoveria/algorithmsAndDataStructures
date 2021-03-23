using System;

namespace HW7
{
    class Program
    {
        const int M = 7;
        const int N = 9;
        static int[] closedCage1 = { 5, 2 };
        static int[] closedCage2 = { 3, 6 };
        static void Main(string[] args)
        {
            /*Для прямоугольного поля размера M на N клеток, подсчитать количество путей из 
             * верхней левой клетки в правую нижнюю. Известно что ходить можно только на одну 
             * клетку вправо или вниз. */
            int[,] board = new int[M, N];
            
            for (int i = 0; i < N; i++)
            {
                board[0, i] = 1;
            }
            for (int j = 1; j < M; j++)
            {
                board[j, 0] = 1;
                for (int k = 1; k < N; k++)
                {
                    if (RouteCheck(j, k)) {
                        board[j, k] = board[j, k - 1] + board[j - 1, k];
                    }
                }
            }
            Print(board);
            Console.WriteLine($"Количество путей в точку board[{M},{N}] = {board[M - 1, N - 1]}");
            Console.ReadLine();
        }
        static public bool RouteCheck(int i, int j)
        {
            if (i == closedCage1[0] && j == closedCage1[1] || i == closedCage2[0] && j == closedCage2[1])
            {
                return false;
            }
            return true;
        }
        static public void Print(int[,] board)
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"{board[i, j]}\t");
                }
                Console.WriteLine();
            }
        }
    }
}
