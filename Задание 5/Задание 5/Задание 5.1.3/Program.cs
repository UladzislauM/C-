using System;

namespace Задание_5._1._3
{
    
    class Program
    {
  /// <summary>
  /// Метод Заполняет матрицу случайными цифрами.
  /// </summary>
  /// <param name="matrixPr"></param>
  /// <returns></returns>
        static int[,] GetMatrixRand(int[,] matrixPr)
        {
            Random r = new Random();
            int n = matrixPr.GetLength(0);
            int m = matrixPr.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrixPr[i, j] = r.Next(10);
                }
            }
            return matrixPr;

        }
        /// <summary>
        /// Метод Производит умножение матрицы на матрицу.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <param name="matrix3"></param>
        /// <returns></returns>
        static int[,] GetMatrixSumDif(int[,] matrixA, int[,] matrixB, int[,] matrixC)
        {
            int n = matrixA.GetLength(0);
            int m = matrixB.GetLength(1);
            int u = matrixB.GetLength(0);
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {

                    for (var k = 0; k < u; k++)
                    {
                        matrixC[j, i] += matrixA[i, k] * matrixB[k, j];

                    }
                    
                }
                Console.WriteLine();
            }

            return matrixC;
        }
        /// <summary>
        /// Метод выводит на экран матрицу.
        /// </summary>
        /// <param name="matrixCon"></param>
        /// <returns></returns>
        static int[,] MatrixInConsole(int[,] matrixCon)
        {
            int n = matrixCon.GetLength(0);
            int m = matrixCon.GetLength(1);
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrixCon[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.Write($"\n");
            return matrixCon;

        }
        static void Main(string[] args)
        {
            Console.Write($"Умножение Матриц");
            Console.Write($"\nДля умножения Матриц необходимо чтобы число строк одной было равно числу столбцов другой." +
               $"\nТак же можно узнать произведение квадратных матриц." +
               $"\nЧисло не может быть меньше еденицы.");
            int n = -3;
            int m = -3;
            int u = -4;
            bool success = false;

            while (success == false || m < 0 || n < 0)
            {

                Console.Write($"\nВведите число строк 1 матрицы: ");
                success = int.TryParse(Console.ReadLine(), out n);

                if (success == false)
                {
                    Console.WriteLine($"Вы не ввели чиcло.");
                }
                if (n < 0)
                {
                    Console.WriteLine($"Вы ввели Отрицательное число!");
                }

                Console.Write($"\nВведите число Столбцов 1 матрицы и Строк 2-ой: ");
                success = int.TryParse(Console.ReadLine(), out m);
                if (success == false)
                {
                    Console.WriteLine($"Вы не ввели чиcло.");
                }
                if (m < 0)
                {
                    Console.WriteLine($"Вы ввели Отрицательное число!");
                }

                Console.Write($"\nВведите число Столбцов 2 матрицы: ");
                success = int.TryParse(Console.ReadLine(), out u);
                if (success == false)
                {
                    Console.WriteLine($"Вы не ввели чиcло.");
                }
                if (u < 0)
                {
                    Console.WriteLine($"Вы ввели Отрицательное число!");
                }
            }

            int[,] matrix1 = new int[n, m];
            int[,] matrix2 = new int[m, u];
            int[,] matrix3 = new int[u, n];
            

            matrix1 = GetMatrixRand(matrix1);
            matrix2 = GetMatrixRand(matrix2);

            Console.Write($"\nИсходные матрицы: \n");

            MatrixInConsole(matrix1);
            MatrixInConsole(matrix2);

            matrix3 = GetMatrixSumDif(matrix1, matrix2, matrix3);

            Console.Write($"\nИтог: \n\n");
            MatrixInConsole(matrix3);
        }
    }
}
