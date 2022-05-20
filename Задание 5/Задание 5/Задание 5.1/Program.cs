using System;
//using System.Linq;
//using System.Collections;

namespace Задание_5._1
{
    class Program
    {
        /// <summary>
        /// Метод Сортирует за ранее введенные в метод слова по количеству символов.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string[] sort(string[] s)
        {
            int n = s.Length;
            for (int i = 1; i < n; i++)
            {
                string temp = s[i];
                // Вставляем s [j] в правильное положение
                int j = i - 1;

                while (j >= 0 && temp.Length < s[j].Length)
                {
                    s[j + 1] = s[j];
                    j--;
                }
                s[j + 1] = temp;
            }
            return s;
        }

        /// <summary>
        /// Метод выводит на экран консоли первую в массиве переменную.
        /// </summary>
        /// <param name="str"></param>
        static void printArraystring(string[] str)
        {
            for (int i = 0; i < 1; i++)
                Console.Write(str[i] + " ");
        }


        static void Main(string[] args)
        {
            Console.WriteLine($"Введите предложение:  \n");

            string text = Console.ReadLine();
            text = text.Replace(", ", " "); // Убираем запятые
            text = text.Replace(". ", " "); // Убираем точки
            string[] arr = text.Split(' ', '\t', StringSplitOptions.RemoveEmptyEntries);

           // Функция для сортировки

            string[] SortArr = sort(arr);

           // Вызываем функцию для печати результата
            Console.WriteLine($"Самое маленькое слово:  \n");

            printArraystring(SortArr);



        }
    }
}
