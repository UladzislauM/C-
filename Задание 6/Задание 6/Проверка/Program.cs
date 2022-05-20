using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

namespace Проверка
{
    class Program
    {
        /// <summary>
        /// Возвращает значение если нужно только колличество групп
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        static int GroupsNumbers (int num)
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
        /// <param name="number"></param>
        /// <returns></returns>
        public static int[][] GroupsNumbersArr(int number)
        {

            /// Если переданное число ноль, то возвращается пустой список групп
            if (number == 0)
                return Array.Empty<int[]>();

            /// Если переданное число единица, то возвращается список групп с одной группой - единицей
            if (number == 1)
                return new int[][] { new int[] { 1 } };

            /// Создание массива для групп
            int[][] groups = new int[ (int)Math.Log(number, 2)+ 1][];
            groups[0] = new int[] { 1 };
            int indexGroup = 1; // Индекс добавляемой группы

            /// Создание массива чисел содержащего все числа от 1 до заданного
            /// Единица используется как маркер
            /// Вместо удаления элеменов их значение будет приравниваться нулю
            /// После сортировки 1 будет разделять удалённые элементы и оставшиеся
            int[] numbers = new int[number];
            for (int i = 0; i < number; i++)
                numbers[i] = i + 1;

            /// Массив с промежуточными данными
            int[] group = new int[number];

            /// Цикл пока в массиве индекс единицы не последений
            int index1;
            while ((index1 = Array.BinarySearch(numbers, 1)) != number - 1) /// Проверка индекса единицы
            {
                /// Копия элементов в массив группы
                Array.Copy(numbers, group, number);

                int countGroup = 0; /// Количество элементов в группе
                                    /// Перебор элементов группы. i - индекс проверяемого элемента
                for (int i = index1 + 1; i < number; i++)
                {
                    if (group[i] != 0) /// Пропуск удалённых элементов
                    {
                        /// Удаление из группы всех элементов кратных проверяемому, кроме его самого
                        for (int j = i + 1; j < number; j++)
                            if (group[j] % group[i] == 0)
                                group[j] = 0;
                      

                        /// Удаление элемента из массива чисел
                        numbers[i] = 0;
                        /// Счётчик группы увеличивется
                        countGroup++;
                    }

                }
                /// Сортировка массивов после удаления элементов
                Array.Sort(group);
                Array.Sort(numbers);

                /// Создание массива для добавления в группы
                /// и копирование в него значений старше 1
                int[] _gr = new int[countGroup];
                Array.Copy(group, Array.BinarySearch(group, 1) + 1, _gr, 0, countGroup);

                /// Добавление группы в массив групп
                groups[indexGroup] = _gr;
                indexGroup++;

            }
            
            /// Возврат списка групп
            return groups;
        }
        /// <summary>
        /// Перезапись файла. Из цифры в массив с группами.
        /// </summary>
        /// <param name="grupsInConsole"></param>
        /// <param name="Puth"></param>
        static void matrixInStrim (int [][]grupsInConsole, string Puth)
        {
            //int k;
            int grLeni = grupsInConsole.Length;
            //int grLenj = grupsInConsole[k].Length;
            StreamWriter streamWriter = new StreamWriter(Puth + "New.txt");
            for (int i = 0; i < grLeni; i++)
            {
                streamWriter.Write($"\nГруппа {i}: ");
                for (int j = 0; j < grupsInConsole[i].Length; j++)
                {
                    streamWriter.Write($"\t{grupsInConsole[i][j]}");
                }
            }
            Console.ReadKey();
            streamWriter.Flush();
            streamWriter.Close();
        }
        /// <summary>
        /// Выводит на экран число строк
        /// </summary>
        /// <param name="m"></param>
        static void mInConsole (int m)
        {
            Console.WriteLine($"Число Групп в последовательности: М = {m}");
        }
        static void Main(string[] args)
        {
            string puth = @"d:\sequence.txt";
            Console.WriteLine($"Введите путь к файлу - ");
            //puth = Console.ReadLine();
            string text = File.ReadAllText($@"{puth}"); // Открывает текстовый файл, считывает все строки файла и затем закрывает файл.
            int N = int.Parse(text);

            Console.WriteLine($"Получено число из файла {puth}\n Выберите дальнейший вариант работы" +
              $"\n Нажать 1 для создания файла с группами " +
              $"\n Нажать 2 для вывода в консоль количества групп");

            int[][]groupFinish;
            int groupNum;

            bool Var = Console.ReadKey().KeyChar == '2';
            Stopwatch stopwatch = new Stopwatch();
            if (Var)
            {
                stopwatch.Start();
                groupFinish = GroupsNumbersArr(N);
                matrixInStrim(groupFinish, puth);
                stopwatch.Stop();
                Console.WriteLine("Хотите создать архив? 1.Да, 2.Нет.");
                bool GzipYes = Console.ReadKey().KeyChar == '1';
                if (GzipYes)
                {
                    string source = puth + "New.txt";
                    string compressed = puth + "New.zip";
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
                else { Console.ReadKey(); }
            }
            else 
            {
                stopwatch.Start();
                groupNum = GroupsNumbers(N);
                mInConsole(groupNum);
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

