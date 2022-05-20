using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Проверка
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            string[] Ranr = new string [16];
            for (int i = 0; i<15; i++)
            {
                Random r = new Random();
                Ranr[i] = $"{DateTime.Now.ToString("dd, MMMM. HH:m")+r.Next(1, 40)}";
                //Console.WriteLine(Ranr[i]);
                list.Add(Ranr[i]);
            }
            list.Sort();
            foreach (string i in list)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Диапазон");

            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            
            int numSort1 = list.IndexOf(date1);
            int numSort2 = list.LastIndexOf(date2);

            int sizeArr = numSort2 - numSort1;

            Console.WriteLine($"{numSort1}, {numSort2}, {sizeArr}");

            //int[] x = new int[] { 1, 1, 1, 1, 2, 3, 4, 4, 4, 4, 
            //6, 6, 7, 8, 7, 8, 9, 9, 
            //11, 12, 12, 12, 12, 13,
            //15, 15, 15, 15, 16, 16, 16, 17, 17};

            //int[] y = new int[] { 1, 2, 3, 4, 2, 3, 1, 2, 3, 4,
            //2, 3, 1, 1, 4, 4, 2, 3,  
            //1, 1, 2, 3, 4, 1,
            //1, 2, 3, 4, 1, 2, 4, 1, 4};


            //        Console.BackgroundColor = ConsoleColor.Red;
            //        Console.ForegroundColor = ConsoleColor.White;
            //        for (int i = 0; i < x.Length; i++)
            //        {
            //            Console.SetCursorPosition(x[i], y[i]);
            //            Console.Write("#");
            //            Thread.Sleep(50);
            //        }
            //        Console.ReadKey();



        }
    }
}
