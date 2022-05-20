using System;

namespace Задание_2._2_
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

            Console.WriteLine($"Имя: {Firstname} Фамилия:{Lastname} Отчество: {Patronymic} Возраст: {age} email: {email} Баллы по програмированию: {markprogramming} Баллы по математике: {markmath} Баллы по физике: {markphisics}");  //Интерполяция строк. Я так понимаю можно сделать и с начала строки каждый аргумент, однако для чистоты задания нет стал (просто поставить \n).

            Console.ReadKey();

            Console.WriteLine(Firstname + " " + Lastname + " " + Patronymic + " " + age + " " + email + " " + markprogramming + " " + markmath + " " + markmath); // Не совсем понял что означает "Обычным способом". Сделал так. Это составное форматирование, наверняка обычный способ.

            Console.ReadKey();



            var a = markprogramming; // Создаю переменные по каждому из предметов.
            var b = markmath;
            var c = markphisics;

            var d = a + b + c; // Подсчитываю сумму балов
            Console.WriteLine(d); // Вывод на экран только суммы балов

            var e = (a + b + c) / 3; // Подсчитываю средний бал
            string eFormated = e.ToString("#.##"); // Захотел отформатировать число для меньшего количества знаков после запятой.
                                                   // Для этого пришлось число перевести в строковый формат.
           
            Console.WriteLine(eFormated);
            
            Console.ReadKey();


             

            Console.SetCursorPosition(Console.WindowWidth / 2 - Lastname.Length / 2, Console.WindowHeight / 2); // Вывод по центру консоли
            Console.WriteLine(Firstname); // то что нужно вывести по центру
           
            Console.ReadKey();

        }
    }
}
