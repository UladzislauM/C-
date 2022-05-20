using System;

namespace Задание_4_._2
{
    class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();

            int[] birthdayCollection = new int[8];
            birthdayCollection[0] = 1;
            birthdayCollection[1] = 12;

            for (int i = 0; i < 4; i++)
            {
                birthdayCollection[i] = random.Next(-5, 6);
                Console.Write($"{ birthdayCollection[i]} ");
            }

            //    var a = new[] { 1, 10, 100, 1000 }; // int[]
            //    var b = new[] { "hello", null, "world" }; // string[]

            //    // single-dimension jagged array
            //    var c = new[]
            //    {
            //    new[]{1,2,3,4},
            //    new[]{5,6,7,8}
            //};

            //    // jagged array of strings
            //    var d = new[]
            //    {
            //    new[]{"Luca", "Mads", "Luke", "Dinesh"},
            //    new[]{"Karen", "Suma", "Frances"}
            //            };
            //    Console.Write($"{d}");
        }
    }
}
