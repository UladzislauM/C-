using Newtonsoft.Json;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using java.security.cert;
//using System.Text;
//using System.Threading.Tasks;


namespace Задание_8
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Создать прототип информационной системы, в которой есть возможност работать со структурой организации
            /// В структуре присутствуют департаменты и сотрудники
            /// Каждый департамент может содержать не более 1_000_000 сотрудников.
            /// У каждого департамента есть поля: наименование, дата создания,
            /// количество сотрудников числящихся в нём 
            /// (можно добавить свои пожелания)
            /// 
            /// У каждого сотрудника есть поля: Фамилия, Имя, Возраст, департамент в котором он числится, 
            /// уникальный номер, размер оплаты труда, количество закрепленным за ним.
            ///
            /// В данной информаиционной системе должна быть возможность 
            /// - импорта и экспорта всей информации в xml и json
            /// Добавление, удаление, редактирование сотрудников и департаментов
            /// 
            /// * Реализовать возможность упорядочивания сотрудников в рамках одно департамента 
            /// по нескольким полям, например возрасту и оплате труда
            /// 
            ///  №     Имя       Фамилия     Возраст     Департамент     Оплата труда    Количество проектов
            ///  1   Имя_1     Фамилия_1          23         Отдел_1            10000                      3 
            ///  2   Имя_2     Фамилия_2          21         Отдел_2            20000                      3 
            ///  3   Имя_3     Фамилия_3          22         Отдел_1            20000                      3 
            ///  4   Имя_4     Фамилия_4          24         Отдел_1            10000                      3 
            ///  5   Имя_5     Фамилия_5          22         Отдел_2            20000                      3 
            ///  6   Имя_6     Фамилия_6          22         Отдел_1            10000                      3 
            ///  7   Имя_7     Фамилия_7          23         Отдел_1            20000                      3 
            ///  8   Имя_8     Фамилия_8          23         Отдел_1            30000                      3 
            ///  9   Имя_9     Фамилия_9          21         Отдел_1            30000                      3 
            /// 10  Имя_10    Фамилия_10          21         Отдел_2            10000                      3 



            Console.WriteLine("Структура организации");
            Random rand = new Random();
            int RasEmpl = rand.Next(4, 20); //колличество сотрудников
          
            Rep rep = new Rep();

            rep.ContoreCreate(RasEmpl);
               

            int numKey = 1;
            while (numKey != 9)
            {
                Console.WriteLine($"\t{"Имя Депа."}\t{"Дата"} \t{"Имя",12} " +
              $"\t{"Фамилия",16}\t{"Возраст",2}\t{"Л/Н",2}" +
              $"\t{"Зарплата"}\t{"Кол-во закр. сотр."}");
 
                foreach (var j in rep.PrintDepRep())
                {
                    Console.WriteLine($"{j.PrintDep()}");
                }
                foreach (var O in rep.PrintEmplRep())
                {
                     Console.WriteLine($"{O.PrintEmpl()}");
                }
               
                    Console.WriteLine("Создать запись - 1, Удалить запись - 2, Редактировать запись - 3," +
                        "\n Сортировка по выбраным полям - 4, Экспорт в json (сериализация) - 5, Импорт из json (десериализация) - 6," +
                        "\n Экспорт в Xml (сериализация) - 7, Импорт из Xml (десериализация) - 8, " +
                        "\n Посмотеть за каким отделом закреплен сотрудник - 9, Выход - 10. ");
                numKey = int.Parse(Console.ReadLine());
                //if (numKey == ConsoleKey.Enter)
                while (numKey > 9 || numKey < 1)
                {
                    Console.WriteLine("Введено не верное значение!");
                    numKey = int.Parse(Console.ReadLine());
                }

                while (numKey < 9 || numKey > 1)
                {
                    if (numKey == 1)
                    {
                        char key3;
                        do
                        {
                            Console.WriteLine("Введите Имя Сотрудника:");
                        string fName = (Console.ReadLine());
                        Console.WriteLine("Введите Фамилию Сотрудника:");
                        string lName = (Console.ReadLine());
                        Console.WriteLine("Введите возраст сотрудника:");
                        int ageEmpl = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите заработную плату:");
                        uint sal = uint.Parse(Console.ReadLine());
                        Console.WriteLine("Введите количество закрепленных за ним сотрудников:");
                        uint work = uint.Parse(Console.ReadLine());
                        int numOfNumber = 1;
                        numOfNumber++;
                        Console.WriteLine("Введите отдел к которому пренадлежит сотрудник:");
                        int iDpeople = int.Parse(Console.ReadLine());
                        string daTa = DateTime.Now.ToString("dd,MM|HH:mm");

                        rep.ContoraAdd(fName,lName,ageEmpl,sal,work,numOfNumber,iDpeople,daTa);
                        Console.WriteLine("Ввести еще? н/д?"); key3 = Console.ReadKey(true).KeyChar;
                        } while (char.ToLower(key3) == 'д') ;
                    }
                    if (numKey == 2)
                    {
                        Console.WriteLine("Что хотите удалить?" +
                           "\n Отдел - 1;" +
                           "\n Сотрудник - 2" +
                           "\n Выход - 3.");

                        int numChoice = int.Parse(Console.ReadLine());
                        while (numChoice > 3 || numChoice < 1)
                        {
                            Console.WriteLine("Введено не верное значение!");
                            numChoice = int.Parse(Console.ReadLine());
                        }

                        if (numChoice == 1)
                        {
                            int checkDep = 1;
                            foreach (var j in rep.PrintDepRep())
                            {
                                Console.WriteLine($"[{checkDep}] {j.PrintDep()}");
                                checkDep++;

                            }
                            Console.WriteLine("Какой отдел хотите удалить?:");
                            int numRemDep = int.Parse(Console.ReadLine());

                            while (numRemDep > rep.departs.Count || numRemDep < 1)
                            {
                                Console.WriteLine("Введено не верное значение!");
                                numRemDep = int.Parse(Console.ReadLine());
                            }

                            rep.departs.RemoveAt(numRemDep - 1);
                        }
                        if (numChoice == 2)
                        {
                            int checkEmpl = 1;
                            foreach (var j in rep.PrintEmplRep())
                            {
                                Console.WriteLine($"[{checkEmpl}] {j.PrintEmpl()}");
                                checkEmpl++;
                            }
                            Console.WriteLine("Какой отдел хотите удалить?:");
                            int numRemEmpl = int.Parse(Console.ReadLine());

                            while (numRemEmpl > rep.employees.Count || numRemEmpl < 1)
                            {
                                Console.WriteLine("Введено не верное значение!");
                                numRemEmpl = int.Parse(Console.ReadLine());
                            }

                            rep.employees.RemoveAt(numRemEmpl - 1);
                        }
                            
                    }
                    if (numKey == 3)
                    {
                        Console.WriteLine("Что хотите Отредактировать?" +
                           "\n Отдел - 1;" +
                           "\n Сотрудник - 2;" +
                           "\n Выход - 3.");

                        int numChoice = int.Parse(Console.ReadLine());
                        while (numChoice > 3 || numChoice < 1)
                        {
                            Console.WriteLine("Введено не верное значение!");
                            numChoice = int.Parse(Console.ReadLine());
                        }
                        int numRem = 0;
                        if (numChoice == 1)
                        {
                            int checkDep = 1;
                            foreach (var j in rep.PrintDepRep())
                            {
                                Console.WriteLine($"[{checkDep}] {j.PrintDep()}");
                                checkDep++;

                            }

                            Console.WriteLine("\nКакой отдел хотите Отредактировать?:");
                            numRem = int.Parse(Console.ReadLine());

                            while (numRem > rep.departs.Count || numRem < 1)
                            {
                                Console.WriteLine("Введено не верное значение!");
                                numRem = int.Parse(Console.ReadLine());
                            }
                            numRem -= 1;
                        }
                        if (numChoice == 2)
                        {
                            int checkEmpl = 1;
                            foreach (var j in rep.PrintEmplRep())
                            {
                                Console.WriteLine($"[{checkEmpl}] {j.PrintEmpl()}");
                                checkEmpl++;

                            }

                            Console.WriteLine("\nКакого Сотрудника хотите Отредактировать?:");
                            numRem = int.Parse(Console.ReadLine());

                            while (numRem > rep.employees.Count || numRem < 1)
                            {
                                Console.WriteLine("Введено не верное значение!");
                                numRem = int.Parse(Console.ReadLine());
                            }
                            numRem -= 1;
                        }

                    
                        
                            Console.WriteLine("--введите то что будем изменять --" +
                   "-- на что изменить--");
                        string repL1 = Console.ReadLine();
                        string repL2 = Console.ReadLine();
                        rep.ContoraRed(numChoice, numRem, repL1, repL2);
                    }
                    if (numKey == 4)
                    {
                        Console.WriteLine("Что хотите Отсортировать?" +
                       "\n Отдел - 1;" +
                       "\n Сотрудник - 2;" +
                       "\n Выход - 3.");

                        int numChoice = int.Parse(Console.ReadLine());
                        while (numChoice > 3 || numChoice < 1)
                        {
                            Console.WriteLine("Введено не верное значение!");
                            numChoice = int.Parse(Console.ReadLine());
                        }
                   
                        if (numChoice == 1)
                        {
                            var sortedNameDep = rep.ContoraSort();
                            foreach (Depart y in sortedNameDep) Console.WriteLine($"{y.PrintDep()}");
                           
                            Console.ReadKey();
                        }
                        if (numChoice == 2)
                        {
                            Console.WriteLine("Выберите варианты сортировки:" +
                                "\n по Возрасту и Номеру - 1" +
                                "\n по Имени и Зарплате - 2" +
                                "\n по Фамилии и Возрасту - 3" +
                                "\n по Фамилии и колличеству закрепленных сотрудников - 4");
                            int numSort = int.Parse(Console.ReadLine());
                            while (numSort > 4 || numSort < 1)
                            {
                                Console.WriteLine("Введено не верное значение!");
                                numSort = int.Parse(Console.ReadLine());
                            }
                            var sOrtedNameEmpl = rep.ContoraSort(numSort);
                            foreach (Employees y in sOrtedNameEmpl) Console.WriteLine($"{y.PrintEmpl()}");
                            
                            Console.ReadKey();
                        }
                    }
                    if (numKey == 5)
                    {
                        Console.WriteLine("Выберите что будем сериализовывать:" +
                              "\n по Отделы - 1" +
                              "\n по Сотрудников - 2;" +
                              "\n Выход - 3.");

                        int numSerial = int.Parse(Console.ReadLine());
                        while (numSerial > 3 || numSerial < 1)
                        {
                            Console.WriteLine("Введено не верное значение!");
                            numSerial = int.Parse(Console.ReadLine());
                        }
                     
                        Console.WriteLine("Введите путь для Сериализации в json:");
                        string puthJson = Console.ReadLine();
                        while (!Directory.Exists(puthJson) || puthJson == null)
                        {
                            Console.WriteLine("Такого пути не существует!");
                            puthJson = Console.ReadLine();
                        }
                        Console.WriteLine("Введите имя файла:");
                        string nameJson = Console.ReadLine();
                        while (nameJson == "")
                        {
                            Console.WriteLine("Введите хоть что-нибудь!");
                            nameJson = Console.ReadLine();
                        }
                        string puth = puthJson + nameJson + ".Json";
                        //string puthJson = @"d:\jsonOrg.json";

                        rep.SerialJson(numSerial, puth);
                    }
                    if (numKey == 6)
                    {
                        Console.WriteLine("Выберите что будем Десериализовывать:" +
                            "\n по Отделы - 1" +
                            "\n по Сотрудников - 2;" +
                            "\n Выход - 3.");

                        int numDeSerial = int.Parse(Console.ReadLine());
                        while (numDeSerial > 3 || numDeSerial < 1)
                        {
                            Console.WriteLine("Введено не верное значение!");
                            numDeSerial = int.Parse(Console.ReadLine());
                        }
                        
                        Console.WriteLine("Введите путь для Десериализации в json (с расширением файла):");
                        //string puthJson = Console.ReadLine();
                        //while (!File.Exists(puthJson) || puthJson == null)
                        //{
                        //    Console.WriteLine("По такому пути фала нет!");
                        //    puthJson = Console.ReadLine();
                        //}
                        string puthJson = @"d:\jsonOrg.json";

                        rep.DeSerialJson(numDeSerial, puthJson);

                        Console.WriteLine("После диссериализации Json");
                    }
                    if (numKey == 7)
                    {
                        Console.WriteLine("Выберите что будем сериализовывать:" +
                              "\n по Отделы - 1" +
                              "\n по Сотрудников - 2;" +
                               "\n Выход - 3.");

                        int numSerial = int.Parse(Console.ReadLine());
                        while (numSerial > 3 || numSerial < 1)
                        {
                            Console.WriteLine("Введено не верное значение!");
                            numSerial = int.Parse(Console.ReadLine());
                        }
                        
                        Console.WriteLine("Введите путь для Сериализации в Xml:");
                        string puthXml = Console.ReadLine();
                        while (!Directory.Exists(puthXml) || puthXml == null)
                        {
                            Console.WriteLine("Такого пути не существует!");
                            puthXml = Console.ReadLine();
                        }
                        Console.WriteLine("Введите имя файла:");
                        string nameXml = Console.ReadLine();
                        while (nameXml == "")
                        {
                            Console.WriteLine("Введите хоть что-нибудь!");
                            nameXml = Console.ReadLine();
                        }
                        string puth = puthXml + nameXml + ".xml";
                        //string puthXml = @"d:\XmlOrg.xml";

                        rep.Serialxml(puth, numSerial);
                    }
                    if (numKey == 8)
                    {
                        Console.WriteLine("Выберите что будем Десериализовывать:" +
                             "\n по Отделы - 1" +
                             "\n по Сотрудников - 2;" +
                             "\n Выход - 3.");

                        int numDeSerial = int.Parse(Console.ReadLine());
                        while (numDeSerial > 3 || numDeSerial < 1)
                        {
                            Console.WriteLine("Введено не верное значение!");
                            numDeSerial = int.Parse(Console.ReadLine());
                        }

                        Console.WriteLine("Введите путь для Десериализации Xml (С расширением файла):");
                        string puthXml = Console.ReadLine();
                        while (!File.Exists(puthXml) || puthXml == null)
                        {
                            Console.WriteLine("По такому пути фала нет!");
                            puthXml = Console.ReadLine();
                        }
                        //string puthXml = @"d:\XmlOrg.xml";

                        rep.DeSerialxml(puthXml, numDeSerial);

                        Console.WriteLine("После диссериализации Xml");
                    }
                    if (numKey == 9)
                    {
                        int checkDep = 1;
                        foreach (var j in rep.PrintDepRep())
                        {
                            Console.WriteLine($"[{checkDep}] {j.PrintDep()}");
                            checkDep++;
                        }
                        Console.WriteLine("Выберите Департамент:");
                        int i = int.Parse(Console.ReadLine());
                        while (i > rep.departs.Count || i < 1)
                        {
                            Console.WriteLine("Введено не верное значение!");
                            i = int.Parse(Console.ReadLine());
                        }
                        i -= 1;

                        int repCount = 0;
                        if (i >= 0 && i < rep.employees.Count)
                        {
                            foreach (var item in rep.departs)
                            {
                                if (item.NumDepID == rep.employees[i].PeopleId) Console.WriteLine($"{rep.employees[repCount].FirstName}, " +
                                    $"порядковый номер: {rep.employees[repCount].Number} внутри департамента {item.NameDep}");
                                repCount++;
                            }
                        }
                    }
                    break;
                }
            }
        }
    }
}
