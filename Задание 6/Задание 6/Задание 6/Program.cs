using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
namespace Задание_6
{
    class Program
    {
        /// <summary>
        /// Возвращает значение если нужно только колличество групп
        /// </summary>
        /// <param name="num">Максимально число последовательности</param>
        /// <returns></returns>
        static int GroupsNumbers(int num)
        {
            int goNumber = 0;
            /// Если переданное число ноль, то возвращается M=0
            if (num == 0)
                return goNumber;

            /// Если переданное число единица, то возвращается M=1
            if (num == 1)
                return goNumber = 1;

            /// M = ...
            goNumber = (int)Math.Log(num, 2) + 1;
            return goNumber;
        }
        /// <summary>
        /// Основной метод сортировки чисел в группы
        /// </summary>
        /// <param name="number">Максимально число последовательности</param>
        /// <param name="Puth">Путь к файлу</param>
        public static void GroupsNumbersArr(int number, string Puth)
        {
            StreamWriter streamWriter = new StreamWriter(Puth + "New.txt");
            /// Если переданное число ноль, то возвращается пустой список групп
            if (number == 0)
            {
               streamWriter.Write($"0");
                streamWriter.Flush();
                streamWriter.Close(); 
            }
            /// Если переданное число единица, то возвращается список групп с одной группой - единицей
            if (number == 1)
            {
                streamWriter.Write($"Группа 1: 1 ") ;
                streamWriter.Flush();
                streamWriter.Close();
            }
      
            int n = 2;
         

            for (int i = 1; i < number/2; i++)
            {
                streamWriter.Write($"\nГруппа {i}: ");
                for (int j = n; j< n*2; j++)
                {

                    streamWriter.Write(j); 
                    
                }
                n *= 2;
                
             
            }
            streamWriter.Flush();
            streamWriter.Close();


        }

        /// <summary>
        /// Выводит на экран число строк
        /// </summary>
        /// <param name="m">Значение М (число групп)</param>
        static void mInConsole(int m)
        {
            Console.WriteLine($"Число Групп в последовательности: М = {m}");
        }
        /// <summary>
        /// Метод Создает архв
        /// </summary>
        /// <param name="Puth">Путь к файлу с данными</param>
        static void Gzip (string Puth)
        {
            string source = Puth + "New.txt";
            string compressed = Puth + "New.zip";
            using (FileStream ss = new FileStream(source, FileMode.OpenOrCreate))
            {
                using (FileStream tss = File.Create(compressed))   // поток для записи сжатого файла
                {
                    // поток архивации
                    using (GZipStream cs = new GZipStream(tss, CompressionMode.Compress))
                    {
                        ss.CopyTo(cs); // копируем байты из одного потока в другой
                        Console.WriteLine("Сжатие файла {0} завершено. Было: {1}  стало: {2}.",
                                          source,
                                          ss.Length,
                                          tss.Length);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            newPuth:
            string puth = @"d:\sequence.txt";
            Console.WriteLine($"Введите путь к файлу - ");
            puth = Console.ReadLine();

            string text = File.ReadAllText($@"{puth}"); // Открывает текстовый файл, считывает все строки файла и затем закрывает файл.
            string str = Console.ReadLine();
            int num;
            bool isNum = int.TryParse(text, out num);
            if (isNum == false)
            {
                Console.WriteLine("В файле должно храниться положительное число от 1 до 1 000 000 000!");
                goto newPuth;
            }
            int N = int.Parse(text);
            if (N <= 0)
            {
                Console.WriteLine("В файле должно храниться положительное число от 1 до 1 000 000 000!");
                goto newPuth;
            }

            Console.WriteLine($"Получено число из файла {puth}\n Выберите дальнейший вариант работы" +
              $"\n Нажать 1 для создания файла с группами " +
              $"\n Нажать 2 для вывода в консоль количества групп");

            //int[][] groupFinish;
            //int groupNum;

            bool Var = Console.ReadKey().KeyChar == '2';
            Stopwatch stopwatch = new Stopwatch();
            if (Var)
            {
                stopwatch.Start(); //Начело отсчета таймера

                GroupsNumbersArr(N, puth);
                
                stopwatch.Stop(); //Конец отсчета таймера
                Console.WriteLine("Хотите создать архив? 1.Да, 2.Нет.");
                bool GzipYes = Console.ReadKey().KeyChar == '1';
                if (GzipYes)
                {
                    Gzip(puth);
                }
                else { Console.ReadKey(); }
            }
            else
            {
                stopwatch.Start();

                mInConsole(GroupsNumbers(N));

                stopwatch.Stop();
            }
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
           ts.Hours, ts.Minutes, ts.Seconds,
           ts.Milliseconds / 10);
            Console.WriteLine("Время выполнения " + elapsedTime);


        }
    }
}
