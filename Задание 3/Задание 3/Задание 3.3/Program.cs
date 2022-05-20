using System;

namespace Задание_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nПравила игры:" +
               "\nЗагадывается число от 12 до 120, причём случайным образом. " +
               "\nИгроки по очереди выбирают число от одного до четырёх." +
               "\nИгра происходит так же с Компьютером - он первый выбирает число" +
               "\nВведенное игроком число после каждого хода вычитается из Загаданного. " +
               "\nЕсли после хода игрока Разница между введенным и загаданным числом равняется нулю, " +
               "\nто походивший игрок оказывается победителем.");
            int gameNumber;
            int Level;

            //bool whileuserQ = true;
            //int userQ = 2;

            int userTry;

            string user1;
            Console.Write("\nвведите имя 1-го игрока: ");
            user1 = Console.ReadLine();
            string user2;
            Console.Write("\nвведите имя 2-го игрока: ");
            user2 = Console.ReadLine();

            //int Rand = 1;
            //int Rand2 = 2;

            //int userTryRange1;
            //int userTryRange2;

            string Name = "";
            string user0 = "Компьютер ";

            int SWH = 0;

            int rev = 0;

            //int randomNPC = 0;

            





            Random randomize = new Random(); // Генератор случайных чисел
           

           
                for (; ; )

                {
                    gameNumber = randomize.Next(12, 120); // Задаю пределы вывода случайного числа

                    Console.WriteLine($"Исходное значение = {gameNumber}"); // Вывожу на экран в консоле результат
                                                                            // случайной генерации числа в заданном диапазоне.
                                                                            // Задаю имя как в задании.
                    for (rev = 0; rev == 0;)

                    {




                        switch (SWH)

                        {
                            case 0:

                                Name = user0;
                                break;

                            case 1:

                                Name = user1;
                                break;

                            case 2:
                                Name = user2;
                                break;

                        }





                    Random randomNPC = new Random();


                    if (SWH == 0)
                    {
                        userTry = randomNPC.Next(1, 5);
                        Console.WriteLine($"Введите число от 1 до 4 {Name}: " +
                            $"\n{userTry}");
                       
                        gameNumber = gameNumber - userTry;
                    }

                    else
                    {
                        Console.WriteLine($"Введите число от 1 до 4 {Name}: ");
                        userTry = int.Parse(Console.ReadLine());

                        gameNumber = gameNumber - userTry;
                    }

                    if (userTry > 4 | userTry < 1)
                    {
                        Console.WriteLine($"Потрачено! Игрок - {Name} пропускает ход! Введите число от 1до 4!!!");

                    }

                    Console.WriteLine(gameNumber);

                        if (gameNumber == 0)
                        {

                            Console.WriteLine($"\nПоздравляю победителя. Реванш?" +
                                "\n1 - Начать заново" +
                                "\n Любая цифра для выхода");

                            rev = int.Parse(Console.ReadLine());

                            if (rev == 1)
                            {
                                continue;
                            }
                            else
                            {

                                break;
                            }



                        }


                        SWH++;
                        if (SWH > 2) SWH = 0;
                        Console.ReadKey();

                    }

                    if (rev == 1)
                    {
                        continue;
                    }
                    else
                    {

                        break;
                    }
                }
            }


        }



            }
        
