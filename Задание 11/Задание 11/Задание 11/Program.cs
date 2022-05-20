using System;
using System.IO;

namespace Task_11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание 1.
            // Спроектировать информационную систему позволяющей работать со следующей структурой:
            // Организация, в которой есть департаменты и сотрудники.
            // Наполнение деталями предлагается реализовать самостоятельно
            // Наполнение сотрудниками и департаментами происходит автоматически из файла *.txt, 
            //                                                           предпочтительнее *.xml или *.json 
            //
            // Сотрудники делятся на несколько групп, разделенных должностями и оплатой труда
            // Есть 
            //   сотрудники - управленцы (например: директор, Первй заместитель директора, начальник ведомства, 
            //                                      начальник департамента)
            // 
            //   ОАО "Лучшие кодеры"
            //       Департамент_1
            //          Департамент_11
            //          Департамент_12
            //       Департамент_2
            //          Департамент_21
            //          Департамент_22
            //          Департамент_23
            //          Департамент_24
            //       Департамент_3
            //          Департамент_31
            //       Департамент_4
            //          Департамент_41
            //          Департамент_42
            //          Департамент_43
            //          Департамент_44
            //          Департамент_45
            //          Департамент_46
            //          Департамент_47
            //          Департамент_48
            //       Департамент_5                Начальник_5
            //          Департамент_51            Начальник_51
            //              Департамент_511       Начальник_511
            //                  Департамент_5111  Начальник_5111
            //                        Департамент_51111      Начальник_51111
            //                              Сотрудник 1
            //                              Сотрудник 2
            //                              Сотрудник 3
            //                              Интерн 1
            //                              Интерн 2
            //                        Департамент_51112
            //                        Департамент_51113
            //                        Департамент_51114
            //                  Департамент_5112
            //                  Департамент_5113
            //              Департамент_512
            //          Департамент_52
            //              Департамент_521
            //              Департамент_522
            //              Департамент_523
            //          Департамент_53
            //              Департамент_531
            //          Департамент_54

            //   сотрудники - рабочие
            //   интерны
            // У интернов оплата труда фиксированная и определяется при приёме (например $500 в месяц)
            // У сотрудников - рабочих оплата труда почасовая и определяется при приёме (например $12 в час)
            // У сотрудников - управленцев оплата труда составляет 15% от общей выплаченной суммы всем сотрудникам 
            // числящихся в его отделе, но не менее $1300. 
            //
            // Структура организации следующая:
            // Организация, состоит из ведомств в которые включены департаменты
            // У каждого ведомства и департамента есть свой начальник.
            // Директор руководит Организацией
            // 
            // Реализовать и продемонстрировать работу информационной системы
            // В консоли или с использованием UI

            // * Задание 2
            //
            // Есть код:
            //
            // Ознакомиться с кодом в файле A.cs
            // Реализовать интерфейсы I1, I2 в классе A
            //
            ////// Реализовать интерфейсы I1, I2 в классе B
            //
            // Задание 3.
            // 
            // Задавать вопросы





            #region Добавление сотрудников в Коллекции классов

            Random r = new Random();

            Rep rep = new Rep();

            int depCheck = 1;
            int podDepCheck = 0;
            int podPodDepCheck = 0;
            uint allSal = 0;
            uint allSalMid = 0;
            uint allSalMiniBig = 0;
            uint allSalBig = 0;

            for (int i = 1; i < r.Next(2, 12); i++)
            {
                rep.departs.Add(new Depart($"Отдел {depCheck}", int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}")));

                int x = r.Next(1, 3);
                if (x != 2)
                {
                    int scrRamd = r.Next(3, 10);
                    for (int j = 0; j < scrRamd; j++)
                    {
                        rep.employees.Add(new Scrubs($"Имя {r.Next(1, 26)}",
                            500,
                        int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}"),
                        "Интерн"));
                        allSal += rep.employees[j].Salary;
                        
                    }
                    int o = r.Next(1, 20);
                    for (int e = 0; e < o; e++)
                    {
                        rep.employees.Add(new Employees($"Имя {r.Next(1, 26)}",
                            ((uint)r.Next(2, 10) * 12) * 22,
                        int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}"),
                        "Раб."));

                        allSal += rep.employees[e].Salary;
                    }
                    uint salBaoss = (uint)(allSal * 0.15);
                    if (salBaoss < 1300)
                        salBaoss = (uint)1300;
                    rep.employees.Add(new Bosses($"Имя {r.Next(1, 26)}",
                       salBaoss,
                               int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}"),
                               "Начальник Депортамента"));
                }
                  if (x == 2)
                  {
                    podDepCheck = 0;

                    int y = r.Next(1, 4);
                    for (int f = 1; f < r.Next(1, 12); f++)
                    {
                        podDepCheck++;
                        rep.departs.Add(new Depart($"    Отдел {depCheck}.{podDepCheck}",
                            int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}")));

                        if (y != 2)
                        {
                            allSal = 0;
                            int scrRamd = r.Next(3, 10);
                            for (int j = 0; j < scrRamd; j++)
                            {
                                rep.employees.Add(new Scrubs($"Имя {r.Next(1, 26)}",
                                    500,
                                int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}"),
                                "Интерн"));
                                allSal += rep.employees[j].Salary;
                            }
                            int o2 = r.Next(1, 12);
                            for (int e = 0; e < o2; e++)
                            {
                                rep.employees.Add(new Employees($"Имя {r.Next(1, 26)}",
                                    (uint)r.Next(2, 10) * 12 * 22,
                                int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}"), 
                                "Раб."));
                                allSal += rep.employees[e].Salary;
                            }
                            uint salBaoss = (uint)(allSal * 0.15);
                            if (salBaoss < 1300)
                                salBaoss = (uint)1300;
                            rep.employees.Add(new Bosses($"Имя {r.Next(1, 26)}",
                               salBaoss,
                                       int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}"), 
                                       "Начальник Депортамента"));

                        }
                        

                        if (y == 2)
                        {
                            podPodDepCheck = 0;
                            for (int t = 1; t < r.Next(1, 12); t++)
                            {
                                podPodDepCheck++;
                                rep.departs.Add(new Depart($"      Отдел {depCheck}.{podDepCheck}.{podPodDepCheck}",
                                    int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}")));
                                allSal = 0;
                                int scrRamd = r.Next(3, 10);
                                for (int j = 0; j < scrRamd; j++)
                                {
                                    rep.employees.Add(new Scrubs($"Имя {r.Next(1, 26)}",
                                        500,
                                    int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}"), 
                                    "Интерн"));
                                    allSal += rep.employees[j].Salary;
                                }
                                int o2 = r.Next(1, 12);
                                for (int e = 0; e < o2; e++)
                                {
                                    rep.employees.Add(new Employees($"Имя {r.Next(1, 26)}",
                                        (uint)r.Next(2, 10) * 12 * 22,
                                    int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}"),
                                    "Раб."));
                                    allSal += rep.employees[e].Salary;
                                }
                                uint salBaoss = (uint)(allSal * 0.15);
                                if (salBaoss < 1300)
                                    salBaoss = (uint)1300;
                                rep.employees.Add(new Bosses($"Имя {r.Next(1, 26)}",
                                   salBaoss,
                                           int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}"), 
                                           "Начальник Депортамента"));
                                allSalMid += allSal;
                            }

                            
                        }
                        

                        uint salBaossMid = (uint)(allSalMid * 0.15);
                        if (salBaossMid < 1300)
                            salBaossMid = (uint)1300;
                        rep.employees.Add(new Bosses($"Имя {r.Next(1, 26)}",
                           salBaossMid,
                                   int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}"), 
                                   "Начальник отдела"));
                        allSalMiniBig += allSalMid;

                    }
                    
                  }
               

                uint salBaossMiniBig = (uint)(allSalMiniBig * 0.15);
                if (salBaossMiniBig < 1300)
                    salBaossMiniBig = (uint)1300;
                rep.employees.Add(new Bosses($"Имя {r.Next(1, 26)}",
                   salBaossMiniBig,
                           int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}"), 
                           "Первый зам"));

                depCheck++;
                allSalBig += allSalMiniBig;
            }
            

            uint salBaossBig = (uint)(allSalBig * 0.15);
            if (salBaossBig < 1300)
                salBaossBig = (uint)1300;
            rep.employees.Add(new Bosses($"Имя {r.Next(1, 26)}",
               salBaossBig,
                       int.Parse($"{depCheck}{podDepCheck}{podPodDepCheck}"), 
                       "Большой Босс"));

            #endregion

            foreach (var i in rep.employees)
            {
                Console.WriteLine($"{i.PrintEmpl()}");
            }
             


            #region Серизация
            //Console.WriteLine("Введите путь для Сериализации в json:");
            //string puthJson = Console.ReadLine();
            string puthJson = @"d:\";
            while (!Directory.Exists(puthJson) || puthJson == null)
            {
                Console.WriteLine("Такого пути не существует!");
                puthJson = Console.ReadLine();
            }
            //Console.WriteLine("Введите имя файла:");
            //string nameJson = Console.ReadLine();
            string nameJson = "jsonOrg";
            while (nameJson == "")
            {
                Console.WriteLine("Введите хоть что-нибудь!");
                nameJson = Console.ReadLine();
            }

            //rep.SerialJson(1, @"d:\Json.Json");

            for (int p = 1; p < 3; p++)
            {
                int numSerial = p;

                string puth = puthJson + $"{nameJson}{p}" + ".Json";
                //string puthJson = @"d:\jsonOrg.json";

                rep.SerialJson(numSerial, puth);
            }
            #endregion

            // Десериализовать в структуру???
            // Реализовать графический интерфейс вывода на экран
            // Делать 2
        }
    }
}
