using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    class Program
    {
        static void Main(string[] args)
        {

            //Заказчик проекта ― крупная компания. Её руководство хочет иметь возможность проводить анализ финансов за последние 12 месяцев.

            //Финансы компании должны отображаться в виде таблицы, столбцы которой включают:

            //            номер месяца,
            //            доход,
            //            расход,
            //            прибыль.
            //Самый важный показатель для руководства компании ― количество месяцев с положительной прибылью.Важно определить три месяца с наименьшей прибылью, при этом месяцы с одинаковой прибылью считаются за один.Само собой, компания не хочет делиться своими финансовыми показателями, поэтому для демонстрации приложения доходы и расходы вас попросили заполнить случайными значениями.

            //Выведите на экран треугольник Паскаля.
            //Реализуйте:
            //умножение матрицы на число,
            //сложение и вычитание матриц, 
            //умножение двух матриц.


            //Советы и рекомендации
            //При поиске месяцев с наименьшей прибылью вам может понадобиться Array.Sort.



            //Что оценивается
            //На экран выводится таблица с финансовыми показателями.
            //Происходит расчёт и вывод трёх худших месяцев(месяцы с одинаковой прибылью считаются за один).
            //На экран выводится количество месяцев с положительной прибылью.



            int[,] array2 = new int[12, 4];
            int[] temp = new int[12];

            Random r = new Random();

            Console.WriteLine($"{"Месяц",9}{"Доход",9}{"Расход",9}{"Прибыль",9}");

            for (int b = 0; b < 12; b++)
            {

                array2[b, 0] = b + 1;
                array2[b, 1] =  r.Next(0,2);
                array2[b, 2] = r.Next(0,2);
                array2[b, 3] = array2[b, 2] - array2[b, 1];


                Console.Write($"\n{array2[b, 0],9}{array2[b, 1],9}{array2[b, 2],9}{array2[b, 3],9}");

            }
            Console.ReadKey();

            int[] profit = new int[12];

            for (int i = 0; i < 12; i++)

            {
                profit[i] = array2[i, 3];
            }

            int[] month = new int[12];

            for (int i = 0; i < 12; i++)

            {
                month[i] = array2[i, 0];
            }
           

            Array.Sort(profit, month);
         
            int numPLmonth = 0;

           

            for (int i = 0; i < 12; i++)
                
            {
                if (profit[0] == profit[11])
                {
                    break;
                }

                if (profit[i] > 0)
                {
                    numPLmonth++;
                }

            }


            Console.WriteLine($"\nМесяцев с положительной прибылью: {numPLmonth}");

            ////for (int i = 0; i < 12; i++)
            ////{
            ////    if (profit[i] > 0)
            ////    {
            ////        Console.Write($"\n{ month[i],3}{profit[i],9}");
            ////    }

            ////}

            Console.ReadKey();

            Console.WriteLine($"Месяцы с З Худшими прибылями: ");

        //for (int i = 0; i < 12; i++)
        //{

        //    {
        //        Console.Write($"\n{ month[i],3}{profit[i],9}");
        //    }

        //}
        //Console.WriteLine($"\nХудшая прибыль в месяцах: ");
        //Месяц: { month[l]}:

      
           
            int check = 0;
                Console.Write($"Прибыль: {profit[0]}  Месяц: {month[0]}");
            for (int l = 1; l < month.Length; l++)
            {
             
                if (profit[0] == profit[11])
                { Console.WriteLine($"\nПрибыль: {profit[l]}  Месяц: { month[l]} "); }

                if (profit[l] != profit[l - 1] && profit[0] != profit[l])
                {
                    Console.Write($"\nПрибыль: {profit[l]}  Месяц: { month[l]}");
                    check++;

                }
               
                    if (profit[l] == profit[l-1])
                    {
                        Console.Write($", { month[l]}");
                    }
                


                if (check == 2) 
                {
                    for (int i = l+1; i < month.Length; i++)
                    {
                        if (profit[i] == profit[l])
                        {
                            Console.Write($", { month[i]}");
                        }
                    }
                    break;
                }
            }

        }

       

    }  

}



    
        
    


