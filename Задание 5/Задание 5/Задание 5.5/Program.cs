using System;


namespace Задание_5._5
{
    class Program
    {
        
            public static int AkerFun(int m, int n)
            {

                // Базовый случай
                if (m == 0)
                {
                    return n + 1;

                } // Шаг рекурсии / рекурсивное условие
                else if (n == 0 && m > 0)
                {
                    return AkerFun(m - 1, 1);

                } // Шаг рекурсии / рекурсивное условие
                else
                {
                    return AkerFun(m - 1, AkerFun(m, n - 1));
                    
                }


            }

        
        static void Main(string[] args)
        {
            AkerFun(2, 5); // вызов рекурсивной функции
            Console.WriteLine(AkerFun(2, 5));
            Console.WriteLine(AkerFun(1, 2));

        }
    }
}
