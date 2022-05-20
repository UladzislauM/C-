using System;

namespace Задание_5._2._2
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
            Array.Reverse(s);
            return s;
        }

        /// <summary>
        /// Метод Выбирает несколько максимально возможных слов
        /// </summary>
        /// <param name="Value1"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        static int MaxArray(string[] Value1, int m)
        {
            int n = Value1.Length;
            for (int i = 1; i < n; i++)

            {
                string temp = Value1[0];


                int j = i - 1;

                if (temp.Length == Value1[i].Length)

                {

                    m++;
                }

            }
            return m;
        }

        /// <summary>
        /// Метод для Вывода на экран отсортированного массива
        /// </summary>
        /// <param name="str"></param>
        /// <param name="m"></param>
        static void printArraystring(string[] str, int m)

        {

            for (int i = 0; i < m; i++)

                Console.Write(str[i] + " ");

        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Введите предложение:  \n");
            string text = Console.ReadLine();
            text = text.Replace(",", " "); // Убираем запятые
            text = text.Replace(".", " "); // Убираем точки
            string[] arr = text.Split(' ', '\t',StringSplitOptions.RemoveEmptyEntries); // Дробим предложение на слова в массив

             // Добавляем Аргумет для нумерации строк в массиве
            int m = 1;

            // Функция для сортировки
            string[] SortArr = sort(arr);

            // Вызываем функцию для печати результата
           m = MaxArray(arr, m);
            Console.WriteLine($"\nСамые длинные слова:  ");
            printArraystring(SortArr,m);
        }
    }
}
