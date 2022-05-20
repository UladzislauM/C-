using System;

namespace Задание_5._1._2
{
    class Program
    {
      /// <summary>
      /// Метод вводит с клавиатуры размерность матриц.
      /// </summary>
      /// <returns></returns>
        static int[,] intMatrix ()
        {
            int n = -3;
            int m = -3;
            bool success = false;

            while (success == false || m < 0 || n < 0)
            {

                Console.Write($"\nВведите число строк: ");
                success = int.TryParse(Console.ReadLine(), out n);

                if (success == false)
                {
                    Console.WriteLine($"Вы не ввели чиcло.");
                }
                if (n < 0)
                {
                    Console.WriteLine($"Вы ввели Отрицательное число!");
                }

                Console.Write($"\nВведите число Столбцов: ");
                success = int.TryParse(Console.ReadLine(), out m);
                if (success == false)
                {
                    Console.WriteLine($"Вы не ввели чиcло.");
                }
                if (m < 0)
                {
                    Console.WriteLine($"Вы ввели Отрицательное число!");
                }

            }
            int[,] matrix1 = new int[n, m];
            return matrix1;
        }
        /// <summary>
        /// Метод Заполняет матрицу случайными числами.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        static int[,] GetMatrixRand(int[,] matrix)
        {

            Random r = new Random();
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = r.Next(10);
                }
            }
            return matrix;
            
        }
        /// <summary>
        /// Метод производит вычетание матриц.
        /// </summary>
        /// <param name="matrixSum"></param>
        /// <param name="matrixDif"></param>
        /// <returns></returns>
        static int[,] GetMatrixSumDif(int[,] matrixSum, int[,] matrixDif)
        {
            bool success = false;
            int b = 0;
           while (success == false||b > 2 || b < 1)
            {
                Console.Write($"\nВыберите Сложение 1, или Вычетание 2: ");
                success = int.TryParse(Console.ReadLine(), out b);
                if (success == false)
                {
                    Console.WriteLine($"Вы не ввели чиcло.");
                }
                
           }
            int n = matrixSum.GetLength(0);
            int m = matrixSum.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (b == 1)
                    {
                        matrixSum[i, j] = matrixSum[i, j] - matrixDif[i, j];
                    }
                    if (b == 2)
                    {
                        matrixSum[i, j] = matrixSum[i, j] + matrixDif[i, j];
                    }
                }
            }
               
            
            return matrixSum;
        }
        /// <summary>
        /// Метод выводит матрицу на экран.
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
            Console.Write($"Сложение и Вычитание Матриц\n");

            int[,] matrix1 = intMatrix();
            int[,] matrix2 = matrix1;

            matrix1 = GetMatrixRand(matrix1);
            matrix2 = GetMatrixRand(matrix2);


            Console.Write($"\nИсходные матрицы: \n");

            MatrixInConsole(matrix1);
           MatrixInConsole(matrix2);

            matrix1 = GetMatrixSumDif(matrix1, matrix2);
            
            Console.Write($"\nИтог: \n\n");
            MatrixInConsole(matrix1);

        }
         
    }
    }

