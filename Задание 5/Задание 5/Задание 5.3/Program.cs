using System;

namespace Задание_5._3
{
    class Program
    {
        /// <summary>
        /// Метод сортирует буквы в предложении и убирает повторяющиеся буквы.
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        static string OKLetter(string text)
        {
            string NewText = "";
            int n = text.Length;

            string[] Letter = new string[n];

            for (int i = 0; i < n; i++)
            {
                
                    Letter[i] = text.Substring(i, 1);
                    if (i == 0)
                    {
                        NewText = Letter[i];
                    }
                    if (i != 0 && Letter[i] != Letter[i - 1])
                    {
                        NewText += Letter[i];
                    }
                
            }
            return NewText;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Введите предложение:  \n");
            string Text = Console.ReadLine();
            Text = Text.ToLower();
            Text = OKLetter(Text);
          
            Console.WriteLine(Text);
           
        }
    }
}
