using System;

namespace Задание_5._4
{
    class Program
    {
        /// <summary>
    /// Проверка на букву в строке
    /// </summary>
    /// <param name="Str"></param>
    /// <returns></returns>
        static int testKey(string Str)
        {
            int argReturn;
            bool numbOrText = false;
            char chReturn;
            foreach (char ch in Str)
            {
                chReturn = (char)char.GetUnicodeCategory(ch);
                Console.WriteLine(ch + " - " + char.GetUnicodeCategory(ch));
                numbOrText = char.IsLetter(ch);//Проверка на букву
                if (numbOrText == true)  
                {
                    argReturn = 1;
                    return argReturn;
                    
                }
            }
            return argReturn = 0;

           
        }

    /// <summary>
    /// Метод переводит текстовую последовательность в числовую.
    /// </summary>
    /// <param name="str"></param>
    /// <param name="arrSize"></param>
    /// <returns></returns>
        static int[] fromStrToInt(string str, int arrSize)
        {
            int[] arr = new int[arrSize];

            int previousWhiteSpaceIndex = 0;
            for (int i = 0, j = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    var word = str.Substring(previousWhiteSpaceIndex, i - previousWhiteSpaceIndex);
                    if (word.Length != 0)
                    {
                        arr[j] = int.Parse(word);
                        j++;
                    }
                    previousWhiteSpaceIndex = i + 1;
                }
            }
            return arr;
        }
        /// <summary>
        /// Метод Переставляет 3 аргумента всей последовательности пока не убедится что вся она является прогрессией.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        static int checkPr(string str, int[] arr)
        {
            int check = 2;
            int flCheck = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr.Length != (i+1)&&arr[i-1]!=arr[i])
                {
                    if (Math.DivRem((arr[i + 1] + arr[i - 1]), 2, out int Ost) == arr[i] && Ost == 0)
                    {
                        check = 0;
                    }
                    else if (Math.Sqrt(arr[i + 1] * arr[i - 1]) == arr[i] && Math.Sqrt(arr[i + 1] * arr[i - 1]) != 0)
                    {
                        check = 1;
                    }
                    else
                    { 
                        check = 2;
                        flCheck++;
                    }
                 
                }
                else
                { break; }
            }
            if (flCheck > 0)
            {
                return check = 2;
            }
            return check;
        }
        /// <summary>
        /// Метод Забирает значение переменной и выводит на экран условие заданное этой переменной.
        /// </summary>
        /// <param name="check"></param>
        static void intCansole (int check)
        {
            if (check == 0)
            {
                Console.Write($"\nПоследовательность являестся Арифметической прогрессией");
            }
            if (check == 1)
            {
                Console.Write($"\nПоследовательность являестся Геометрической прогрессией");
            }
            if (check == 2)
            {
                Console.Write($"\nПоследовательность не являестся прогрессией");
            }
        }
        static void Main(string[] args)
        {
            int arrSize = 0;
            string str = "";
           Start:

                Console.Write("Введите Постедовательность чисел разделенную пробелами.");
                str = Console.ReadLine() + " ";

                str = str.Replace(",", " "); // Убираем запятые
                str = str.Replace(".", " "); // Убираем точки
                int chKey = testKey(str);
            if (chKey == 1)
            { goto Start; }
            


                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ' ')
                    {
                        arrSize++;
                    }
                }
           int[] arr = fromStrToInt(str, arrSize);
                     
            int check = checkPr(str, arr);

            intCansole(check);
            Console.ReadKey();



        }
    }
}
