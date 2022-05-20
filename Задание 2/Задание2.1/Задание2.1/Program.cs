using System;

namespace Задание2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string Firstname = "Маршалов"; //Использовал string так как это строчный текстовый тип
            string Lastname = "Владислав";
            string Patronymic = "Владимирович";
            byte age = 26; // Хотел использовать int, но задумался над размерам, ведь byte в больших
                           // приложениях будет иметь меньший размер. Да и жить более 255 лет невозможно
            string email = "marshal25@yandex.by"; 
            double markprogramming = 9.8; // float  не подошел (хотя и разрядность у него ниже), так что использовал double
            double markmath = 9.5;
            double markphisics = 8.8;

            // Далее сделал все как было рассказано. И даже кое-то стало выресовываться в голове.

            string pattern = "Имя: {0} \nФамилия:{1} \nОтчество: {2} \nВозраст: {3} \nemail: {4} \nБаллы по програмированию: {5} \nБаллы по математике: {6} \nБаллы по физике: {7}";

            Console.WriteLine(pattern,
                Firstname,
                Lastname,
                Patronymic,
                age,
                email,
                markprogramming,
                markmath,
                markphisics);

            Console.ReadKey();
              



        }
    }
}
