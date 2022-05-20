using System;

namespace Задание_4._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int w = 1;

            Console.Write($"Выберите Действие с Матрицами: " +
                $"\n1. Умножение матрицы на число." +
                $"\n2. Вычетание или сложение матриц." +
                $"\n3. умножение матриц. \n");

            w = int.Parse(Console.ReadLine());
            for (; w < 4 || w > 0;)
            {
                if (w < 4 || w > 0)
                {
                    if (w == 1)
                    {

                        Console.Write($"Умножение Матрицы на число");


                        int n = 3;
                        int m = 3;
                        int b = 2;

                        Random r = new Random();

                        Console.Write($"\nВведите число строк: ");
                        n = Convert.ToInt32(Console.ReadLine());


                        Console.Write($"\nВведите число Столбцов: ");
                        m = int.Parse(Console.ReadLine());
                        while (m < 0 || n < 0)
                        {

                            Console.Write($"\nЧисло строк и столбцов матрицы не может быть отрицательным!.");
                            Console.Write($"\nВведите число строк матриц: ");
                            n = int.Parse(Console.ReadLine());

                            Console.Write($"\nВведите число Столбцов матриц: ");
                            m = int.Parse(Console.ReadLine());
                        }

                        Console.Write($"\nВведите число на которое будем умножать: ");
                        b = int.Parse(Console.ReadLine());

                        int[,] matrix1 = new int[n, m];

                        Console.Write($"\nВывод на экран первоначальной матрицы:  \n\n");

                        for (int i = 0; i < n; i++)
                        {

                            for (int j = 0; j < m; j++)
                            {
                                matrix1[i, j] = r.Next(100);

                                Console.Write($"{matrix1[i, j]}\t");
                            }
                            Console.WriteLine();
                        }

                        Console.Write($"\nИтог: \n\n");

                        if (b == 0)
                        {
                            Console.Write("0");
                        }
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < m; j++)
                            {

                                matrix1[i, j] = matrix1[i, j] * b;

                                Console.Write($"{matrix1[i, j]}\t");
                            }
                            Console.WriteLine();
                        }
                        Console.ReadKey();
                        break;
                    }

                    if (w == 2)
                    {
                        Console.Write($"Сложение и Вычитание Матриц");


                        int n = 3;
                        int m = 3;
                        int b = 2;


                        Random r = new Random();
                        do
                        {
                            Console.Write($"\nВведите число строк матриц: ");

                            n = Convert.ToInt32(Console.ReadLine());


                            Console.Write($"\nВведите число Столбцов матриц: ");
                            m = int.Parse(Console.ReadLine());
                        }
                        while (m < 0 || n < 0);
                        {
                            Console.Write($"\nЧисло строк и столбцов матрицы не может быть отрицательным!.");
                        }
                                            

                            Console.Write($"\nВыберите действие: 1. Вычетаение; 2. Сложение.");
                            b = int.Parse(Console.ReadLine());
                        
                        while (b > 2 || b < 1)
                        {

                            Console.Write($"\nВыберите 1 или 2!!!.");
                            b = int.Parse(Console.ReadLine());
                        }


                        int[,] matrix1 = new int[n, m];
                        int[,] matrix2 = new int[n, m];

                        Console.Write($"\nВывод на экран первоначальных матриц:  \n\n");

                        for (int i = 0; i < n; i++)
                        {

                            for (int j = 0; j < m; j++)
                            {
                                matrix1[i, j] = r.Next(100);

                                Console.Write($"{matrix1[i, j]}\t");
                            }
                            Console.WriteLine();
                        }
                        Console.Write($"\n\n");

                        for (int i = 0; i < n; i++)
                        {

                            for (int j = 0; j < m; j++)
                            {
                                matrix2[i, j] = r.Next(100);

                                Console.Write($"{matrix2[i, j]}\t");
                            }
                            Console.WriteLine();
                        }

                        Console.Write($"\nИтог: \n\n");
                        if (b == 1)
                        {

                            for (int i = 0; i < n; i++)
                            {
                                for (int j = 0; j < m; j++)
                                {

                                    matrix1[i, j] = matrix1[i, j] - matrix2[i, j];

                                    Console.Write($"{matrix1[i, j]}\t");
                                }
                                Console.WriteLine();
                            }
                            Console.ReadKey();
                        }

                        if (b == 2)
                        {

                            for (int i = 0; i < n; i++)
                            {
                                for (int j = 0; j < m; j++)
                                {

                                    matrix1[i, j] = matrix1[i, j] + matrix2[i, j];

                                    Console.Write($"{matrix1[i, j]}\t");
                                }
                                Console.WriteLine();
                            }
                            Console.ReadKey();
                        }
                        break;
                    }
                    if (w == 3)
                    {
                        Console.Write($"Умножение Матриц");


                        int n = 3;
                        int m = 4;

                        int y = 3;
                        int u = 4;


                        Random r = new Random();


                        
                                Console.Write($"\nДля умножения Матриц необходимо чтобы число строк одной было равно числу столбцов другой." +
                             $"\nТак же можно узнать произведение квадратных матриц." +
                             $"\nЧисло не может быть меньше еденицы.");
                        do
                        {
                            Console.Write($"\nВведите число строк 1 матрицы: ");
                            n = Convert.ToInt32(Console.ReadLine());


                            Console.Write($"\nВведите число Столбцов 1 и строк 2 матрицы: ");
                            m = int.Parse(Console.ReadLine());

                            y = m;

                            //Console.Write($"\nВведите число строк 2 матрицы: ");
                            //y = Convert.ToInt32(Console.ReadLine());


                            Console.Write($"\nВведите число Столбцов 2 матрицы: ");
                            u = int.Parse(Console.ReadLine());
                        }
                        while (n <= 0|| m<=0|| u<=0);
                        {
                            Console.WriteLine("число не может быть меньше еденицы.");
                        }


                        int[,] matrix1 = new int[n, m];
                        int[,] matrix2 = new int[m, u];
                        int[,] matrix3 = new int[u, n];
                        int[,] matrix4 = new int[u, n];
                        Console.Write($"\nВывод на экран первоначальных матриц:  \n\n");

                        for (int i = 0; i < n; i++)
                        {

                            for (int j = 0; j < m; j++)
                            {
                                matrix1[i, j] = r.Next(10);

                                Console.Write($"{matrix1[i, j]}\t");
                            }
                            Console.WriteLine();
                        }
                        Console.Write($"\n\n");

                        for (int i = 0; i < y; i++)
                        {

                            for (int j = 0; j < u; j++)
                            {
                                matrix2[i, j] = r.Next(10);

                                Console.Write($"{matrix2[i, j]}\t");
                            }
                            Console.WriteLine();
                        }

                        Console.Write($"\nИтог: \n\n");

                        for (var i = 0; i < n; i++)
                        {
                            for (var j = 0; j < u; j++)
                            {
                                

                                for (var k = 0; k < m; k++)
                                {
                                    matrix3[j, i] += matrix1[i, k] * matrix2[k, j];
                                   
                                }
                                Console.Write($"{matrix3[j, i]}\t");
                            }
                            Console.WriteLine();
                        }
                      
                    }
                    Console.ReadKey();
                    break;

                }


                Console.Write($"\nВыберите 1 или 3!!!.\n");
                w = int.Parse(Console.ReadLine());

            }

            


        }
        }
    }
