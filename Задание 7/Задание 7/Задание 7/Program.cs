using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DateBook
{
    class Program
    {
              
        static void Main(string[] args)
        {
            int[] x = new int[] { 1, 1, 1, 1, 2, 3, 4, 4, 4, 4,
            6, 6, 7, 8, 7, 8, 9, 9,
            11, 12, 12, 12, 12, 13,
            15, 15, 15, 15, 16, 16, 16, 17, 17};

            int[] y = new int[] { 1, 2, 3, 4, 2, 3, 1, 2, 3, 4,
            2, 3, 1, 1, 4, 4, 2, 3,
            1, 1, 2, 3, 4, 1,
            1, 2, 3, 4, 1, 2, 4, 1, 4};


            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < x.Length; i++)
            {
                Console.SetCursorPosition(x[i], y[i]);
                Console.Write("#");
                Thread.Sleep(50);
            }
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("\nСоздать новый ежедневник нажмите любую кнопку, " +
                "\nЗагрузить ежедневник из файла для просмотра и редактирования - нажмите 2");

            string puth = "";
            char key = '2';
            key = Console.ReadKey(true).KeyChar;

            if (char.ToLower(key) != '2')
            {
                Console.WriteLine("\nВведите Имя файла с расширением (.csv)");
                string NamePuth = Console.ReadLine();

                Console.WriteLine("\nВведите путь для хранения");
                puth = @$"{Console.ReadLine()}\{NamePuth}";
            }
            if (char.ToLower(key) == '2')
            {
                do
                {

                    Console.WriteLine("Введите путь к файлу");
                    puth = @$"{Console.ReadLine()}";

                }
                while (File.Exists(puth) == false || File.ReadAllText(puth) == null);
                {

                    if (File.Exists(puth) == false && File.ReadAllText(puth) == null)
                        Console.WriteLine("Файл не существует или пуст");
                }
            }

            Methods methods = new Methods(); // Обращение к методам программы
            string[] lines;

            if (File.Exists(puth) == false|| File.ReadAllText(puth) == null)
            {
               
                char key2 = 'д';
                do
                {
                    Console.WriteLine("Введите название заметки");
                    string NameNote = Console.ReadLine();

                    string daTa = DateTime.Now.ToString("dd, MMMM. HH:mm");
                    Console.WriteLine($"Время заметки {daTa}");

                    Console.WriteLine($"Введите саму заметку: \n");
                    string Note = Console.ReadLine();

                    File.WriteAllText(puth, $"{NameNote};{daTa};{Note};");

                    Console.WriteLine("Ввести еще? н/д?"); key2 = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key2) == 'д');
            }

            lines = methods.WriteFile(puth);
            
           
            int numKey = 1;
            while (numKey != 9)
            {
                int numNoteInRead = 0;
                string[] lineWr;
                Console.WriteLine($"{"Номер"}{"Имя Заметки",20}{"Дата",15} {"Описание", 17}");
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] != null && lines[i] != "")
                    {

                        lineWr = lines[i].Split(';');

                        Console.WriteLine($"{numNoteInRead,3} {lineWr[0],20}  {lineWr[1],20}  {lineWr[2]}");
                        numNoteInRead++;
                    }

                }

                Console.WriteLine("Создать запись - 1, Удалить запись - 2, Редактировать запись - 3," +
                    "\nДобавить Строки из файла - 4, Добавить Строки из файла сортируя по диапозону дат - 5, " +
                    "\nСохранить как - 6, Упорядочивания записей ежедневника по выбранному полю - 7, " +
                    "\nСохранить - 8 , Выход - 9. ");

                numKey = int.Parse(Console.ReadLine());
                //if (numKey == ConsoleKey.Enter)
                while (numKey > 9 || numKey < 1)
                {
                    Console.WriteLine("Введено не верное значение!");
                    numKey = int.Parse(Console.ReadLine());
                }
                string NameNotE;
                string daTA;
                string NotE;
                while (numKey < 9 || numKey > 1)
                {
                    if (numKey == 1)
                    {
                        char key3;
                        do
                        {
                            Console.WriteLine("Введите название заметки");
                           NameNotE = Console.ReadLine();

                           daTA = DateTime.Now.ToString("dd, MMMM. HH:mm");
                            Console.WriteLine($"Время заметки {daTA}");

                            Console.WriteLine($"Введите саму заметку: \n");
                            NotE = Console.ReadLine();

                            Array.Resize(ref lines, lines.Length+1);
                            
                            lines[lines.Length - 1] = $"{NameNotE};{daTA};{NotE};";
                            Console.WriteLine("Ввести еще? н/д?"); key3 = Console.ReadKey(true).KeyChar;
                        } while (char.ToLower(key3) == 'д');
                        break;
                    }
                    if (numKey == 2)
                    {
                        Console.WriteLine("Какую Заметку хотите удалить?");
                        int nUmNote = int.Parse(Console.ReadLine());

                       
                        if (lines != null)
                        {
                            lines[nUmNote] = null;

                            SkechNote skechNote = new SkechNote();
                            int numLines = 0;
                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (lines[i] != null || lines[i] != "")
                                {
                                    skechNote.Note += $"{lines[i]}\n";
                                    numLines++;
                                }
                            }
                        }
                        
                        Array.Resize(ref lines, lines.Length - 1);
                        break;
                    }
                    if (numKey == 3)
                    {

                        Console.WriteLine("Какую Заметку хотите отредактировать?");
                        int numNoteR = int.Parse(Console.ReadLine());
                        Console.WriteLine("--введите то что будем изменять --" +
                            "-- на что изменить--");
                        string repL1 = Console.ReadLine();
                        string repL2 = Console.ReadLine();
                        
                        SkechNote skechNote = new SkechNote();

                        lines[numNoteR] = lines[numNoteR].Replace($"{repL1}", $"{repL2}");

                        int numLines = 0;
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i] != null || lines[i] != "")
                            {
                                skechNote.Note += $"{lines[i]}\n";
                                numLines++;
                            }
                        }
                        break;
                    }
                    if (numKey == 4)
                    {
                        Console.WriteLine("Введите путь к файлу для доюавления");
                        string newPuth = @$"{Console.ReadLine()}";
                        //string newPuth = @$"d:\DateBookAdd.csv";

                        string[] newLine = methods.WriteFile(newPuth);
                        Array.Resize(ref lines, lines.Length + newLine.Length);
                                               
                        int newLineCh = lines.Length - newLine.Length - 1;
                        for (int i = 0; i < newLine.Length; i++)
                        {
                            if (newLine[i] != null || newLine[i] != "")
                            {
                                lineWr = newLine[i].Split(';');

                                lines[newLineCh] = $"{lineWr[0]};{lineWr[1]};{lineWr[2]};";
                            }
                            newLineCh++;
                        }
                        break;
                    }
                    if (numKey == 5)
                    {
                        Console.WriteLine("Введите путь для выгрузки файла с записями для Ежедневника");
                        string newPuth = @$"{Console.ReadLine()}";
                        //string newPuth = @$"d:\DateBookAdd.csv";

                        string[] newLine = methods.WriteFile(newPuth);
                        int numField = 1;
                        string[] newLine2 = newLine; 
                        newLine = methods.SortNoteByField(newLine, numField, puth);
                        numNoteInRead = 0;
                        
                        Console.WriteLine($"{"Номер"}{"Имя Заметки",20}{"Дата",15} {"Описание",17}");
                        for (int i = 0; i < newLine.Length; i++)
                        {
                            if (newLine[i] != null && newLine[i] != "")
                            {
                               
                                lineWr = newLine[i].Split(';');

                                Console.WriteLine($"{numNoteInRead,3} {lineWr[0],20}  {lineWr[1],20}  {lineWr[2]}");
                                numNoteInRead++;
                            }

                        }
                        //string[] newLines = methods.WriteFile(newPuth);
                        Console.WriteLine("Введите Диапозон дат.(dd, MMMM. HH:mm) От:");
                        string date1 = $"{Console.ReadLine()}";
                        Console.WriteLine("До:");
                        string date2 = $"{Console.ReadLine()}";

                        
                        List<string> listAddDate = new List<string>();
                       
                        for (int i = 0; i < newLine2.Length; i++)
                        {
                            if (newLine2[i] != null || newLine2[i] != "")
                            {
                                lineWr = newLine2[i].Split(';');
                                listAddDate.Add(lineWr[1]);
                            }
                        }

                        listAddDate.Sort();
                        int numSort1 = listAddDate.IndexOf(date1);
                        int numSort2 = listAddDate.LastIndexOf(date2);

                        int sizeArr = numSort2 - numSort1;
                        Array.Resize(ref lines, lines.Length + sizeArr+1);

                        //for (int i = 0; i < newLine.Length; i++)
                        //{
                        //    if (newLine[i] != null || newLine[i] != "")
                        //    {
                        //        lineWr = newLine[i].Split(';');
                        //        listAddDate.Add(lineWr[1]);
                        //    }
                        //}

                        //listAddDate.Sort();
                        //numSort2 = listAddDate.IndexOf(date1);
                        //numSort1 = listAddDate.LastIndexOf(date2);

                        int newLineCh = lines.Length - sizeArr - 1;
                        for (int i = 0; i <= sizeArr; i++)
                        {
                            if (newLine[i] != null || newLine[i] != "" || numSort1 <= numSort2)

                            {

                                lineWr = newLine[numSort2].Split(';');

                                lines[newLineCh] = $"{lineWr[0]};{lineWr[1]};{lineWr[2]};";
                            }
                            numSort2++;
                            newLineCh++;
                        }
                        break;
                    }
                    if (numKey == 6)
                    {
                        Console.WriteLine("Введите путь для выгрузки Ежедневника");
                        string puthNewNote = @$"{Console.ReadLine()}";
                        methods.AddToFile(puthNewNote, lines);
                        break;
                    }
                    if (numKey == 7)
                    {
                        Console.WriteLine("Введите номер столбца по которому Будет производится сортировка:" +
                           "\n0 - Имя Заметки;" +
                           "\n1 - Дата;" +
                           "\n2 - Заметка.");
                        int numField = int.Parse(Console.ReadLine());
                       
                        lines = methods.SortNoteByField(lines, numField, puth);
                        break;
                    }
                    if (numKey == 8)
                    {
                        methods.AddToFile(puth, lines);
                        break;
                    }
                    if (numKey == 9)
                    { break; }
                }
            }
        
        
        }
    }
}
