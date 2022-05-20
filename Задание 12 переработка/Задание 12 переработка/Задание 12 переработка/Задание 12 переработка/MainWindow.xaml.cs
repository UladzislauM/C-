using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using GalaSoft.MvvmLight.Command;
using System.IO;
using Microsoft.Win32;

namespace Задание_12_переработка
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



    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();
            rep = new Rep(this);
        }

        Rep rep;

        public static int numDepIDstr = 0;
        public static int numDepIDstrPC = 0;
        Random rand = new Random();
       
        /// <summary>
        /// Кнопка "Добавить Отдел"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_AddDep(object sender, RoutedEventArgs e)
        {
            if (rep.departs.Count == 0)
            {
                numDepIDstr++;
                if (rep.departs.Count == 0)
                {
                    dgDeparts.ItemsSource = rep.departs;
                }
                rep.departs.Add(new Depart() { NumDepID = $"{numDepIDstr}" });
            }
            else
            {
                int countStrFokus = 0;
                //нахождение количества точек в строке
                foreach (char c in rep.departs[rep.departs.Count - 1].NumDepID)
                    if (c == '.') countStrFokus++;

                if (countStrFokus != 0)
                {
                    //находим все знаки до первой точки
                    string endAddFocusNew = new string(rep.departs[rep.departs.Count - 1].NumDepID.TakeWhile(x => x != '.').ToArray());
                    numDepIDstr = int.Parse(endAddFocusNew);
                }
                else { numDepIDstr = int.Parse(rep.departs[rep.departs.Count - 1].NumDepID); }

                
                numDepIDstr++;
                if (rep.departs.Count == 0)
                {
                    dgDeparts.ItemsSource = rep.departs;
                }
                rep.departs.Add(new Depart() { NumDepID = $"{numDepIDstr}" });
            }

            
        }

        /// <summary>
        /// Для хранения заполнения dgWorker
        /// </summary>
        ObservableCollection<Worker> work2 = new ObservableCollection<Worker>();
      
        /// <summary>
        /// Коллекция для хранения копии заполнения dgWorker
        /// </summary>
        ObservableCollection<Worker> work2Save = new ObservableCollection<Worker>();

        /// <summary>
        /// Переменная показывает нахождение в Маленьком списке (только выделенного отдела)
        /// </summary>
        bool okViewWorkers = false;

        /// <summary>
        /// Кнопка показывает сотрудников только выделенного отдела
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_ViewWorkers(object sender, RoutedEventArgs e)
        {
            okViewWorkers = true;
            work2.CollectionChanged -= Work2_CollectionChanged;
            int check = 0;
            try
            {
                if (rep.workers.Count != 0)
                {
                    work2.Clear();
                    foreach (Worker p in rep.workers)
                    {
                        if (p.PeopleId == focusStrTest)
                        {
                            work2.Add(rep.workers[check]);
                        }
                        check++;
                    }
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            // Добавление данных в таблицу
            dgWorker.ItemsSource = work2;
            // Подписка на изменение таблицы
            work2.CollectionChanged += Work2_CollectionChanged;
        }

        private void Button_Click_ViewAllWorkers(object sender, RoutedEventArgs e)
        {
            okViewWorkers = false;
            dgWorker.ItemsSource = rep.workers;
        }

        /// <summary>
        /// Фокус по клику мыши на табличке с Рабочими
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgWorker_GotMouseCapture(object sender, MouseEventArgs e)
        {
            workerID = (Worker)dgWorker.SelectedItem;
            focusStrWork2 = workerID.PeopleId;
        }

        /// <summary>
        /// Проверка фокуса в табличке рабочих
        /// </summary>
        string focusStrWork2 = "";


        /// <summary>
        /// Коллекция для хранения Выбранного фокусом рабочего
        /// </summary>
        Worker workerID;

        /// <summary>
        /// Кнопка "Уволить сотрудника"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_DellWorker(object sender, RoutedEventArgs e)
        {
            work2Save = work2;
            MessageBoxResult result = MessageBox.Show($"Вы действительно хотите уволить Сотрудника?", "Увольнение", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    rep.workers.Remove(workerID);
                    work2.Remove(workerID);
                    break;
                case MessageBoxResult.No:
                    work2 = work2Save;
                    dgWorker.Items.Refresh();
                    return;
            }
        }

        /// <summary>
        /// Сида попадают все изменения табличка Рабочих
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Work2_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Переменная показывает какое число на выделенной строке выбрано При нажатии на кнопку
        /// </summary>
        public static string focusStrID = "";
        /// <summary>
        /// Переменная-индекс показывает на какое место вставлять новую строку (при первом выделении)
        /// </summary>
        public static int rowIndex = 1;
        /// <summary>
        /// Переменная для добавления индекса с точкой в конце строки с индексом
        /// </summary>
        public static int subclass = 0;
        /// <summary>
        /// Переменная отражает фокусирование на строке (0 нет фокуса, 1 - есть)
        /// </summary>
        int indexButtonOpen = 0;
        /// <summary>
        /// Переменная показывает повторно ли выбран та или иная строка
        /// </summary>
        public static int indexNextID = 0;
        /// <summary>
        /// Переменная для добавления следующей за выбраной строки (false), или остальных (true) после 
        /// </summary>
        public static bool indexOpenClose = false;
        /// <summary>
        /// Показывает нажата ли кнопка мыши на выделенной строке
        /// </summary>
        bool checkClickMause = true;

        /// <summary>
        /// Кнопка "Добавить ПодОтдел"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_AddUnderDep(object sender, RoutedEventArgs e)
        {
            if (focusStrTest != "")
            {
                Depart drv = (Depart)dgDeparts.SelectedItems[0];
                focusStrID = drv.NumDepID;
            }
            else
            {
                MessageBox.Show("Кликните мышью на нужный отдел");
            }

            if (indexButtonOpen != 0)
            {
                if (indexNextID == 1)
                {
                    rep.InsertRepitRow(); // Метод для вставки числа ниже выбранного (повторное нажатие на строку)
                }
                // Метод для первоначального нажатия на строку
                else
                {
                    if (indexOpenClose == false)
                    {
                        rep.InsertNewOneRow();  // Метод для вставки первого числа следующее за выбранным в сфокусированной строке
                    }
                    else
                    {
                        rep.InsertNextOneRow();// Если последующее 
                    }
                }

            }
        }
        
      
        /// <summary>
        /// Переменная показывает какое число на выделенной строке выбрано При наведении фокуса на строку
        /// </summary>
        public static string focusStrTest = "";
        public static string focusStrTestNext = "";
        int numFocusStrTest = 0;
        int numFocusStrTestNext = 0;
        /// <summary>
        /// Индекс элемента выбраной строки в коллекии Департаментов 
        /// </summary>
        public static int indexNumDepID = 0;
        /// <summary>
        /// Cодержит колличество уже созданых строк выбраного элемента (после нажатия "добавить").
        /// ТЕ сколько нужно добавить цифор в конец выбраного элемента для создания следующего (а не нулевого)
        /// </summary>
        public static int addNumFocusRowRealy = 0;
        /// <summary>
        /// Bндекс последнего элемента следующего за выбранной строкой (после него добавить следующий элемент (повторно))
        /// </summary>
        public static int indexEndAdd = 0;
        /// <summary>
        /// Переменная для получения значения Индекса следующей за выбранной строки
        /// </summary>
        public static string endAddFocusNext = "";
        /// <summary>
        /// Переменная "Укороченная" для получения значения Индекса следующей за выбранной строки 
        /// Без последней цифры за точкой
        /// </summary>
        public static string endAddFocusNextTrim = "";
        Depart testColumn;
        /// <summary>
        /// Получение фокуса кнопкой мыши в табличке Отделов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgDeparts_GotMouseCapture(object sender, MouseEventArgs e)
        {
            indexOpenClose = false;
            rowIndex = dgDeparts.SelectedIndex;
            indexButtonOpen = 1;
            addNumFocusRowRealy = 0;
            checkClickMause = true;
            
            if (dgDeparts.SelectedItem != null)
            {
                testColumn = (Depart)dgDeparts.SelectedItems[0];
                focusStrTest = testColumn.NumDepID;

                numFocusStrTest = focusStrTest.Length;
            }
            if (rep.departs.Count != rowIndex + 1)
            {
                Depart testColumnNext = (Depart)dgDeparts.Items[rowIndex + 1];
                focusStrTestNext = testColumnNext.NumDepID;

                numFocusStrTestNext = focusStrTestNext.Length;
            }

            if (numFocusStrTest != numFocusStrTestNext)
            {
                indexNextID = 1;
            }
            else
                indexNextID = 0;

            if (rep.departs.Count == rowIndex+1)
                indexNextID = 0;

            if (!focusStrTestNext.Contains('.'))
                indexNextID = 0;

            if (dgDeparts.SelectedItem != null)
              indexNumDepID = rep.departs.IndexOf((Depart)dgDeparts.SelectedItems[0]);

            if (focusStrTest.Contains('.'))
            {
                rep.FiendElementsToManyNums(); // Метод для получение всех индексов Для Строк с 1 и более точками
            }
            else
            {
                rep.FiendElementsToNullNums();  // Для строк с индексами до первой точки
            }
        }
        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        string numWorkIDStr = "";
        /// <summary>
        /// Кнопка "Добавть рабочего"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_AddWorker(object sender, RoutedEventArgs e)
        {
            numWorkIDStr = focusStrTest;
            if (rep.workers.Count == 0)
            {
                dgWorker.ItemsSource = rep.workers;
            }

            uint salaryPeople = (uint)rand.Next(10, 20);
            salaryPeople = salaryPeople * 8 * 30;
            rep.workers.Add(new Worker() { Post = "Раб.", PeopleId = $"{numWorkIDStr}", Salary = salaryPeople });
            //Вызыв кнопки добавления сотрудников, если нахождение в маленьком списке (только сотрудников выделенного отдела)
            if(okViewWorkers)
            Button_Click_ViewWorkers(sender, e);
        }


        /// <summary>
        /// Зарплата всех стортрудников отдела
        /// </summary>
        public static uint allDepSalary = 0;

        /// <summary>
        /// Считает начальников
        /// </summary>
        public static int bossCheck = 0;
        /// <summary>
        /// Кнопка "Добавть Начальника"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Boss(object sender, RoutedEventArgs e)
        {
            bossCheck++;
            allDepSalary = 0;
            numWorkIDStr = focusStrTest;
            if (rep.workers.Count == 0)
            {
                dgWorker.ItemsSource = rep.workers;
            }
            rep.workers.Add(new Boss() {Post = "Нач.", PeopleId = $"{numWorkIDStr}" });
            rep.AddSalaryBoss();
            //Вызыв кнопки добавления сотрудников, если нахождение в маленьком списке (только сотрудников выделенного отдела)
            if (okViewWorkers)
                Button_Click_ViewWorkers(sender, e);
        }
        /// <summary>
        /// Кнопка "Добавть интерна"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_AddScrub(object sender, RoutedEventArgs e)
        {
            numWorkIDStr = focusStrTest;
            if (rep.workers.Count == 0)
            {
                dgWorker.ItemsSource = rep.workers;
            }
            rep.workers.Add(new Scrub() { Post = "Инт.", PeopleId = $"{numWorkIDStr}", Salary = 500 });
            //Вызыв кнопки добавления сотрудников, если нахождение в маленьком списке (только сотрудников выделенного отдела)
            if (okViewWorkers)
                Button_Click_ViewWorkers(sender, e);
        }
        /// <summary>
        /// Петь Json с Отделами
        /// </summary>
        public string puthJson1 = "";
        /// <summary>
        /// Путь Json с Рабочими
        /// </summary>
        public string puthJson2 = "";
        /// <summary>
        /// Добавление файла Json в Таблицу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_AddJson(object sender, RoutedEventArgs e)
        {
            try
            {
                // Передаем значение строки переменной, хранящей путь
                puthJson1 = puthPeople.Text;
                if (puthJson1 == "")
                { puthJson1 = $@"{Environment.CurrentDirectory}\\json1D.json"; }

                puthJson2 = puthPeople2.Text;
                if (puthJson2 == "")
                { puthJson2 = $@"{Environment.CurrentDirectory}\\json2W.json"; }

                // Передаем конструктору в Классе Rep Данные о пути к файлам
                rep = new Rep(puthJson1, puthJson2);

                rep.departs = rep.LoadDataDep();
                rep.workers = rep.LoadDataWorker();

                string fileEmpty = File.ReadAllText(puthJson1);
                if (fileEmpty == "")
                {
                    MessageBox.Show("Файл пуст, создайте новый, или укажите путь к другому");
                    return;
                }
                dgDeparts.ItemsSource = rep.departs;
                dgWorker.ItemsSource = rep.workers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

           

        }
        /// <summary>
        /// Кнопка"Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
     
            try
            {
                rep.SaveData(rep.departs, puthJson1);
                rep.SaveData(rep.workers, puthJson2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Close();
            }
        }

        /// <summary>
        /// Создание объекта. Выделение памяти в стеке (куче) для Окошка (класса)
        /// </summary>
        SaveFile saveFile;
        /// <summary>
        /// Кнопка "Сохранить как"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_SaveAs(object sender, RoutedEventArgs e)
        {

            
            try
            {
                //saveFile = new SaveFile();
                //if (saveFile.ShowDialog() == true)
                //{
                //    puthJson1 = saveFile.PuthNewFile;
                //    puthJson2 = saveFile.PuthNewFile2;
                //}
                //else
                //{
                //    puthJson1 = puthPeople.Text;
                //    puthJson2 = puthPeople.Text;
                //}
                rep.SaveFileDialog();
                puthJson1 = rep.puth1 + "1D.json";
                puthJson2 = rep.puth1 + "2W.json";

                if (puthJson1 == "")
                { puthJson1 = $@"{Environment.CurrentDirectory}\\json1D.json"; }

                if (puthJson2 == "")
                { puthJson2 = $@"{Environment.CurrentDirectory}\\json2W.json"; }


                rep.SaveData(rep.departs, puthJson1);
                rep.SaveData(rep.workers, puthJson2);
                       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        /// <summary>
        /// Кнопка "Удалить Отдел"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_DellDep(object sender, RoutedEventArgs e)
        {
            /// <summary>
            /// Временная коллекция для восстановления удаленных объектов
            /// </summary>
            ObservableCollection<Depart> departsAddRemove = new ObservableCollection<Depart>();

            if (!checkClickMause)
            {
                MessageBox.Show("Выделите кликом мыши необходимую строку");
            }
            else
            {
                departsAddRemove = rep.departs;
                try
                {

                    MessageBoxResult result = MessageBox.Show($"Удалить Отдел?", "Удаление", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            MessageBoxResult result2 = MessageBox.Show($"Уволить работников?", "Увольнение", MessageBoxButton.YesNo);
                            rep.departs.Remove(testColumn);
                            switch (result2)
                            {
                                case MessageBoxResult.Yes:
                                    try
                                    {
                                        if (checkClickMause)
                                            for (int i = 0; i < rep.workers.Count; i++)
                                            {
                                                if (rep.workers[i].PeopleId == focusStrTest)
                                                {
                                                    for (int j = i; j < rep.workers.Count; j++)
                                                    {
                                                        if (rep.workers[i].PeopleId == focusStrTest)
                                                        {
                                                            rep.workers.RemoveAt(i);
                                                        }
                                                    }
                                                }
                                            }
                                        checkClickMause = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                        Close();
                                    }
                                    return;
                                case MessageBoxResult.No:
                                    App.Current.Resources["rep.dep"] = rep.departs;
                                    App.Current.Resources["rep.work"] = rep.workers;
                                    CutPeople cutPeople = new CutPeople();
                                    cutPeople.ShowDialog();
                                    dgWorker.Items.Refresh();
                                    return;
                            }
                            break;
                        case MessageBoxResult.No:
                            rep.departs = departsAddRemove;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
                dgDeparts.Items.Refresh();

            }
        }


    }
}
