using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Controls;
using Microsoft.Win32;

namespace Задание_12_переработка
{
    class Rep
    {
        public ObservableCollection<Depart> departs = new ObservableCollection<Depart>();
        public ObservableCollection<Worker> workers = new ObservableCollection<Worker>();
        public Rep(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }
        MainWindow mainWindow;

       
        #region Конструкторы

        /// <summary>
        /// Определение "Кастомного" Конструктора для добавления к Depart
        /// </summary>
        /// <param name="RealDeparts"></param>
        public void AddDep(Depart RealDeparts)
        {
            departs.Add(RealDeparts);
        }

        /// <summary>
        /// Определение "Кастомного" Конструктора для добавления к Employees
        /// </summary>
        /// <param name="RealEmployees"></param>
        public void AddWorker(Worker RealEmployees)
        {
            workers.Add(RealEmployees);
        }


        private readonly string PuthJson1;
        private readonly string PuthJson2;

        /// <summary>
        /// Определение пути для файла
        /// </summary>
        /// <param name="puth1"></param>
        /// <param name="puth2"></param>
        public Rep(string puth1, string puth2)
        {
            PuthJson1 = puth1;
            PuthJson2 = puth2;
        }
        public string puth1
        { get; set; }
        public string puth2
        { get; set; }

       
        /// <summary>
        /// Определение конструктора по умолчанию
        /// </summary>
        public Rep()
        { }
        #endregion

        #region Методы


        /// <summary>
        /// Сериализация Конторы json
        /// </summary>
        public void SaveData(object todoDataList, string puthSave)
        {
            using (StreamWriter writer = File.CreateText(puthSave))
            {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }

        }

        /// <summary>
        /// Дисериализация Конторы json и создание копии Рабочие
        /// </summary>
        public ObservableCollection<Worker> LoadDataWorker()
        {
            var fileExist = File.Exists(PuthJson2);
            if (!fileExist)
            {
                File.CreateText(PuthJson2).Dispose();
                return new ObservableCollection<Worker>();
            }
            using (var reader = File.OpenText(PuthJson2))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<Worker>>(fileText);
            }

        }

        /// <summary>
        /// Дисериализация Конторы json и создание копии Отделы
        /// </summary>

        public ObservableCollection<Depart> LoadDataDep()
        {
            var fileExist = File.Exists(PuthJson1);
            if (!fileExist)
            {
                File.CreateText(PuthJson1).Dispose();
                return new ObservableCollection<Depart>();
            }
            using (var reader = File.OpenText(PuthJson1))
            {
                //File.Copy(PuthJson1, PuthJson1 + "copy", true);

                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<Depart>>(fileText);
            }

        }

        /// <summary>
        /// Метод для вставки первого числа следующего за выбранным в сфокусированной строке
        /// </summary>
        public void InsertNewOneRow()
        {
            MainWindow.subclass = 0;
            departs.Insert(MainWindow.rowIndex + 1,
            new Depart() { NumDepID = MainWindow.focusStrID + $".{MainWindow.subclass}" });
            MainWindow.indexOpenClose = true;
        }

        /// <summary>
        /// Метод для вставки следующего за первым выбранным числом (вторым от фокусной строки) в сфокусированной строке
        /// </summary>
        public void InsertNextOneRow()
        {
            MainWindow.rowIndex++;
            MainWindow.subclass++;
            departs.Insert(MainWindow.rowIndex + 1,
            new Depart() { NumDepID = MainWindow.focusStrID + $".{MainWindow.subclass}" });
        }

        /// <summary>
        /// Метод для вставки числа ниже выбранного (повторное нажатие на строку)
        /// </summary>
        public void InsertRepitRow ()
        {
           MainWindow.indexEndAdd++;

            departs.Insert(MainWindow.indexEndAdd,
             new Depart() { NumDepID = MainWindow.focusStrID + $".{MainWindow.addNumFocusRowRealy}" });

            MainWindow.addNumFocusRowRealy++;
        }
        /// <summary>
        /// Метод для получение всех индексов Для Строк с 1 и более точками
        /// </summary>
        public void FiendElementsToManyNums()
        {
            mainWindow = new MainWindow();
            //передаю значения Табличным Коллекциям
            mainWindow.dgDeparts.ItemsSource = departs;
            mainWindow.dgWorker.ItemsSource = workers;

            for (int i = MainWindow.indexNumDepID; i < departs.Count - 1; i++)
            {
   
                // получаем колличество знаков следующей за выбранной строкой
                int endAddFocusNextLenth = MainWindow.focusStrTestNext.Length;

                if (endAddFocusNextLenth != 1)
                {
                    // удаление 2-х знаков в конце следующей за выбраной строкой
                    MainWindow.endAddFocusNextTrim = MainWindow.focusStrTestNext.Substring(0, MainWindow.focusStrTestNext.Length - 2);
                }

                //сравнение текущего выделения стоки со всеми последующими
                if (MainWindow.focusStrTest == MainWindow.endAddFocusNextTrim)
                {
                    // Добавление еденицы к индексу строки. Происходит при попадании в нужный существующий индекс.
                    // цифра следующего элемента для вставки (после повторного фокусирования на нем)
                    MainWindow.addNumFocusRowRealy++;

                    // индекс для нахождения места вставки элемента (повторно)
                    MainWindow.indexEndAdd = departs.IndexOf((Depart)mainWindow.dgDeparts.Items[i + 1]);
                }
            }
        }

        /// <summary>
        /// Метод для получение всех индексов Для Строк до 1-ой точки
        /// </summary>
        public void FiendElementsToNullNums()
        {
            mainWindow = new MainWindow();
            //передаю значения Табличным Коллекциям
            mainWindow.dgDeparts.ItemsSource = departs;
            mainWindow.dgWorker.ItemsSource = workers;

            for (int i = MainWindow.indexNumDepID; i < departs.Count - 1; i++)
            {
                bool test2NumAddNext = false;

                //находим все знаки до первой точки
                string endAddFocusNextNew = new string(MainWindow.endAddFocusNext.TakeWhile(x => x != '.').ToArray());
                // проверка на идентичные знаки до первой точки (чтобы не считать уже вставленные элементы с другими первыми знаками)
                if (MainWindow.focusStrTest == endAddFocusNextNew)
                    test2NumAddNext = true;

                int countStrFokusNext = 0;

                //нахождение количества точек в строке
                foreach (char c in MainWindow.endAddFocusNext)
                    if (c == '.') countStrFokusNext++;

                //сравнение текущего выделения стоки со всеми последующими. Проверка на наличие точки
                if (countStrFokusNext == 1 && test2NumAddNext == true)
                {
                    // Добавление еденицы к индексу строки. Происходит при попадании в нужный существующий индекс.
                    // цифра следующего элемента для вставки (после повторного фокусирования на нем).
                    MainWindow.addNumFocusRowRealy++;

                    // индекс для нахождения места вставки элемента (повторно)
                    MainWindow.indexEndAdd = departs.IndexOf((Depart)mainWindow.dgDeparts.Items[i + 1]);

                }
            }
        }
        /// <summary>
        /// Добавляет зарплату начальника отдела
        /// </summary>
        public void AddSalaryBoss ()
        {
            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].Post == "Нач." && workers[i].PeopleId == MainWindow.focusStrTest)
                {
                    for( int j = 0; j < workers.Count; j++)
                    {
                        if (MainWindow.focusStrTest == workers[j].PeopleId)
                        {
                            MainWindow.allDepSalary += workers[j].Salary;
                        }
                    }
                    workers[i].Salary = (uint)(MainWindow.allDepSalary * 0.15);
                    if (workers[i].Salary < 1300)
                    {
                        workers[i].Salary = 1300;
                    }
                }
            }
            MainWindow.allDepSalary = 0;
            }

        
        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                puth1 = openFileDialog.FileName;
                ;
                return true;
            }
            return false;
        }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                puth1 = saveFileDialog.FileName;
                
                return true;
            }
            return false;
        }
        #endregion
    }
}
