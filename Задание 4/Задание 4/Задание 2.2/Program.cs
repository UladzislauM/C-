using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк : ");
            int n = int.Parse(Console.ReadLine());


            int[][] triangle = new int[n][];
            // первая строка
            triangle[0] = new int[] { 1 };

            for (int i = 1; i < triangle.Length; i++)
            {
                triangle[i] = new int[i + 1];
                for (int j = 1; j <= i; j++)
                {
                    if (j == 1 || j == i)
                        triangle[i][j] = 1;
                    else
                    {
                        triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    }
                }
            }
            //int val = 1;
            for (int i = 1; i < triangle.Length; i++)
            {
                for (int j = 1; j < triangle[i].Length; j++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - (j * 8) + (i * 4), i + 1);  
                    // Если нужен вывод до 10 строк - можно использовать формулу (- (j * 4) + (i * 2))
                    // А если более чем 30 -( - (j * 12) + (i * 6)), но результат уже хуже.
                    Console.Write($"{triangle[i][j]}");
                    

                }
                

            }

            Console.ReadKey();

           // Вариант хуже, но так же работает)))

            //////Console.Write("Введите количество строк : ");
            //////int n = Convert.ToInt32(Console.ReadLine());

            //////for (int i = 0; i<n;i++)
            //////{
            //////    for(int j=n; j>i; j--)
            //////    {
            //////        Console.Write(" ");
            //////    }
            //////    int val = 1;
            //////    for(int j=0;j<=i;j++)
            //////    {
            //////        Console.Write(val + " ");
            //////        val = val * (i - j) / (j + 1);
            //////    }
            //////    Console.WriteLine();
            //////}
            //////Console.ReadLine();

        }


    }
}


