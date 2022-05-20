using System;

namespace Задание_5
{
    class Program
    {

        /// <summary>
        /// Метод создает переменные вводимые через клавиатуру, также создает заполненные матрицы 
        /// на основании введеных переменных.
        /// </summary>
        /// <returns></returns>
        static int[,] GetMatrix( )
        {
            int n = -3;
            int m = -3;
            bool success = false;

            while (success == false||m < 0 || n < 0)
            {

                Console.Write($"\nВведите число строк: ");
                success = int.TryParse(Console.ReadLine(), out n);

                if (success == false)
                {
                    Console.WriteLine($"Вы не ввели чиcло.");
                }
                if(n < 0)
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

            Random r = new Random();
            int[,] matrix1 = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix1[i, j] = Convert.ToInt32(r.Next(10));
                }

            }
            Console.Write($"\nИсходная матрица: \n");
            MatrixInConsole(matrix1);


            return matrix1;
          
        }
        
        /// <summary>
        /// Метод принимает из консоли (клавиатуры) множитель
        /// </summary>
        /// <returns></returns>
        static int GetMult ()
        {
            int b = 0;
            bool success = false;
            while (success == false)
            {


                Console.Write($"\nВведите число на которое будем умножать: ");
                success = int.TryParse(Console.ReadLine(), out b);

                if (success == false)
                {
                    Console.WriteLine($"Вы не ввели чиcло.");
                }
            }
            return b;
        }

      

        /// <summary>
        /// Метод создает множитель, введенный с клавиатуры, после умножает матрицу на него.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        static int[,] multMatrix(int[,] matrix, int v)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = matrix[i, j] * v;
                }

            }

            return matrix;
        }
        /// <summary>
        /// Метод Выводит в консоль матрицу, полученную после действий над ней.
        /// </summary>
        /// <param name="matrixCon"></param>
        /// <returns></returns>
        static int[,] MatrixInConsole(int[,] matrixCon)
        {

            for (int i = 0; i < matrixCon.GetLength(0); i++)
            {

                for (int j = 0; j < matrixCon.GetLength(1); j++)
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
            Console.Write($"Умножение Матрицы на число");

            int[,] matrix1 = GetMatrix();
            int b = GetMult();
            matrix1 = multMatrix(matrix1, b);
            
            Console.Write($"\nИтог: \n");
            MatrixInConsole(matrix1);




        }
    }
}
