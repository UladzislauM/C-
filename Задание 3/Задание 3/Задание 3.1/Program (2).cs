using System;

namespace Задание_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nПравила игры:" +
                "\n- Выберите сложность игры:" +
                "\n Легкий - игра на 2-х с заданным диапозоном игровых значений;" +
                "\n Средний - Необходимо ввести Диапозон чисел в котором компьютер будет загадывать число, " +
                "\n Сложный - С вами будет играть компьютер (NPC), и, " +
                "\n  необходимо ввести Диапозон чисел в котором компьютер будет загадывать число," +
                "\nпричём случайным образом. " +
                "\n- Игроки вводят любой диапозон значений в котором будетут играть." +
                "\n- Введенное игроком число после каждого хода вычитается из Загаданного (кто загадывает зависит от уровня сложности). " +
                "\n- Если после хода игрока Разница между введенным и загаданным числом равняется нулю, " +
                "\nто походивший игрок оказывается победителем.");

            int Level;

            bool whileuserQ = true;
            bool whileRand = true;
            bool whileUserRange1 = true;
            bool whileUserRange2 = true;
            int userQ = 2;

            int userTry;

            int Rand = 1;
            int Rand2 = 2;

            int userTryRange1;
            int userTryRange2;

            string user0 = "компьютер";

            string Name = "";

            string user1 = "";

            string user2 = "";

            string user3 = "";

            string user4 = "";

            string user5 = "";

            int rev = 0;

            int SWH = 1;





            Random randomize = new Random(); // Генератор случайных чисел
            int gameNumber;

            for (; ; )
            {
                Console.Write("\nВведите уровень сложности. Легкий - 1, Средний - 2, Сложный - 3:  ");
                Level = int.Parse(Console.ReadLine());

                if (Level == 3)
                {
                    SWH = 0;

                }
                else
                {
                    SWH = 1;
                }

                if (Level == 1)
                {
                    whileuserQ = false;
                    userQ = 2;
                    user1 = "1-ый игрок";
                    user2 = "2-ой игрок";
                    whileRand = false;
                    Rand = 12;
                    Rand2 = 120;
                    whileUserRange1 = false;
                    whileUserRange2 = false;
                    SWH = 1;
                }


                while (whileuserQ)
                {
                    Console.Write("Введите количество игроков от 2 до 5: ");
                    userQ = int.Parse(Console.ReadLine());
                    if (userQ <= 1 || userQ >= 6) Console.WriteLine("Количество игроков не может быть меньше 2 и больше 5!");
                    else
                    {
                        Console.Write("Введите имя первого игрока: ");
                        user1 = Console.ReadLine();


                        Console.Write("Введите имя второго игрока: ");
                        user2 = Console.ReadLine();



                        if (userQ > 2)
                        {
                            Console.Write("Введите имя третьего игрока: ");
                            user3 = Console.ReadLine();


                        }
                        if (userQ > 3)
                        {
                            Console.Write("Введите имя четвертого игрока: ");
                            user4 = Console.ReadLine();


                        }
                        if (userQ > 4)
                        {
                            Console.Write("Введите имя пятого игрока: ");
                            user5 = Console.ReadLine();


                        }
                        break;
                    }

                }

                while (whileRand)
                {

                    Console.Write("\nВведите диапозон загадываемого компьютером значения:" +
                          "\nПервое число - ");
                    Rand = int.Parse(Console.ReadLine());



                    Console.Write("\nВторое число - ");
                    Rand2 = int.Parse(Console.ReadLine());

                    if (Rand < Rand2)
                    {
                        break;
                    }
                    

                }

                userTryRange1 = 1;
                userTryRange2 = 4;

                while (whileUserRange1)
                {

                    Console.Write("\nВведите Диапозон Игровых значений. " +
                        "Предел значений от 1 до 10: ");


                    Console.Write("\nПервое число: ");
                    userTryRange1 = int.Parse(Console.ReadLine());

                    if (userTryRange1 < 11 && userTryRange1 > 0)
                       
                          
                        break;
                 }

                while (whileUserRange2)
                { 
                        Console.Write("\nВторое число: ");
                    userTryRange2 = int.Parse(Console.ReadLine());

                    if (userTryRange2 > 0 && userTryRange2 < 11 && userTryRange2 > userTryRange1)
                        break;               
                }

               
                gameNumber = randomize.Next(Rand, Rand2); // Задаю пределы вывода случайного числа

                Console.WriteLine($"Исходное значение = {gameNumber}"); // Вывожу на экран в консоле результат
                                                                        // случайной генерации числа в заданном диапазоне.
                                                                        // Задаю имя как в задании.
                Console.ReadKey();

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
                        case 3:

                            Name = user3;
                            break;

                        case 4:
                            Name = user4;
                            break;
                        case 5:

                            Name = user5;
                            break;


                    }

                    

                    if (SWH == 0)
                    {
                        userTry = randomize.Next(userTryRange1,
                       userTryRange2);
                        Console.WriteLine($"Введите число от {userTryRange1} до {userTryRange2} {Name}: " +
                            $"\n{userTry}");

                       
                    }

                    else
                    {
                        Console.WriteLine($"Введите число от от {userTryRange1} до {userTryRange2} {Name}: ");
                        userTry = int.Parse(Console.ReadLine());

                    }



                    SWH++;
                    if (Level == 3)
                    { if (SWH > userQ) SWH = 0; }
                    else
                    if (SWH > userQ) SWH = 1;


                    gameNumber -= userTry;


                    if (userTry > userTryRange2 | userTry < userTryRange1)
                    {
                        Console.WriteLine($"Потрачено! Игрок - {Name} пропускает ход! Введите число от {userTryRange1} до {userTryRange2}!!!");
                        gameNumber += userTry;
                        Console.WriteLine(gameNumber);

                    }
                    else



                    if (gameNumber < 0)
                    {
                        Console.WriteLine($"Потрачено! Игрок - {Name} пропускает ход! Число не может быть менее 0");
                        gameNumber += userTry;
                        Console.WriteLine(gameNumber);

                    }

                    else

                        Console.WriteLine(gameNumber);

                    Console.ReadKey();

                    if (gameNumber == 0)
                    {

                        Console.WriteLine($"\nПоздравляю победителя. Реванш?" +
                            "\n1 - Начать заново" +
                            "\n Любая цифра для выхода");

                        rev = int.Parse(Console.ReadLine());

                        Console.ReadKey();

                        if (rev != 1)
                        
                            break;
                        



                    }


                   

                }
                if (rev != 1)

                    break;
            }
        }
    }
}




    
