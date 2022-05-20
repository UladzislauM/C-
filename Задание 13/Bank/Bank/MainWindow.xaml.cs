using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Bank
{
    // Создать прототип банковской системы, позвляющей управлять клиентами и клиентскими счетами.
    // В информационной системе есть возможность перевода денежных средств между счетами пользователей
    // Открывать вклады, с капитализацией и без
    // 100 12%
    // 12 ме - 112
    // 100 12%
    // 101 12%
    // 102.01 12%

    //     100
    // 1   101
    // 2   102,01
    // 3   103,0301
    // 4   104,060401
    // 5   105,101005
    // 6   106,1520151
    // 7   107,2135352
    // 8   108,2856706
    // 9   109,3685273
    // 10  110,4622125
    // 11  111,5668347
    // 12  112,682503

    // * Продумать возможность выдачи кредитов
    // Продумать использование обобщений

    // Продемонстрировать работу созданной системы

    // Банк
    // ├── Отдел работы с обычными клиентами
    // ├── Отдел работы с VIP клиентами
    // └── Отдел работы с юридическими лицами

    // Дополнительно: клиентам с хорошей кредитной историей предлагать пониженую ставку по кредиту и 
    // повышенную ставку по вкладам
    class FileSystemEntry
    {
        public string Name { get; }
        public IEnumerable<FileSystemEntry> Children { get; }
        public FileSystemEntry Parent { get; private set; }

        public FileSystemEntry(string name, params FileSystemEntry[] children)
        {
            Name = name;
            Children = children;

            foreach (var c in Children)
                c.Parent = this;
        }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Дата проверки. Для выдачи Суммы
        /// </summary>
        public DateTime dateTest = DateTime.Now;

        public static string ToCamelCase(string str)
        {
            char[] MyChar = { '*', '.', '-', '_', ' ' };
            string NewString = str.TrimStart(MyChar);

            return NewString;
           
        }

        public MainWindow()
        {
            InitializeComponent();
            buttonTest.Click += delegate { DoWork(); };

            rep = new Rep(this);
        }

        Rep rep;

        private void DoWork()
        {
             Thread t = new Thread(new ThreadStart(rep.RunThread));
            t.IsBackground = true;
            t.Start();
        }

        /// <summary>
        /// Коллекция для хранения данных в Name.
        /// </summary>
        ObservableCollection<People> peoplesName = new ObservableCollection<People>();

        /// <summary>
        /// Действие при выборе строки с Обычными клиентами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Selected_Klients(object sender, RoutedEventArgs e)
        {

            peoplesName.Clear();
            for(int i = 0; i < rep.peoples.Count;i++)
            {
                if (rep.peoples[i].Prestige == 0)
                    peoplesName.Add(rep.peoples[i]);
            }
            dgNameList.ItemsSource = peoplesName;

            nameSave.Clear();

            for (int i = 0; i< peoplesName.Count;i++)
            {
                if (rep.scores[i].ScoreId == peoplesName[i].PeopleId)
                {
                    nameSave.Add(rep.scores[i]);
                }
            }
            dgViewList.ItemsSource = nameSave;
        }

        /// <summary>
        /// Действие при выборе строки с VIP клиентами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Selected_VIPKlients(object sender, RoutedEventArgs e)
        {
            peoplesName.Clear();
            for (int i = 0; i < rep.peoples.Count; i++)
            {
                if (rep.peoples[i].Prestige == 1)
                    peoplesName.Add(rep.peoples[i]);
            }
            dgNameList.ItemsSource = peoplesName;

            nameSave.Clear();

            for (int i = 0; i < peoplesName.Count; i++)
            {
                if (rep.scores[i].ScoreId == peoplesName[i].PeopleId)
                {
                    nameSave.Add(rep.scores[i]);
                }
            }
            dgViewList.ItemsSource = nameSave;
        }

        /// <summary>
        /// Действие при выборе строки с Юридическими клиентами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Selected_CorpKlients(object sender, RoutedEventArgs e)
        {
            peoplesName.Clear();
            for (int i = 0; i < rep.peoples.Count; i++)
            {
                if (rep.peoples[i].Prestige == 2)
                    peoplesName.Add(rep.peoples[i]);
            }
            dgNameList.ItemsSource = peoplesName;

            nameSave.Clear();

            for (int i = 0; i < peoplesName.Count; i++)
            {
                if (rep.scores[i].ScoreId == peoplesName[i].PeopleId)
                {
                    nameSave.Add(rep.scores[i]);
                }
            }
            dgViewList.ItemsSource = nameSave;
        }

        /// <summary>
        /// Действие при клике на строку со Счетами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Selected_Score(object sender, RoutedEventArgs e)
        {
            nameSave.Clear();

            for (int i = 0; i < peoplesName.Count; i++)
            {
                if (rep.scores[i].ScoreId == peoplesName[i].PeopleId)
                {
                    nameSave.Add(rep.scores[i]);
                }
            }
            dgViewList.ItemsSource = nameSave;
        }

        /// <summary>
        /// Действие при клике на строку с VIP Счетами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Selected_VIPScore(object sender, RoutedEventArgs e)
        {
            nameSave.Clear();

            for (int i = 0; i < peoplesName.Count; i++)
            {
                if (rep.scores[i].ScoreId == peoplesName[i].PeopleId)
                {
                    nameSave.Add(rep.scores[i]);
                }
            }
            dgViewList.ItemsSource = nameSave;
        }

        /// <summary>
        /// Действие при клике на строку с Юридическими Счетами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Selected_CorpScore(object sender, RoutedEventArgs e)
        {
            nameSave.Clear();

            for (int i = 0; i < peoplesName.Count; i++)
            {
                if (rep.scores[i].ScoreId == peoplesName[i].PeopleId)
                {
                    nameSave.Add(rep.scores[i]);
                }
            }
            dgViewList.ItemsSource = nameSave;
        }

        /// <summary>
        /// Действие при клике на строку с Депозитами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Selected_Deposit(object sender, RoutedEventArgs e)
        {
            nameSave.Clear();

            if (rep.deposits.Count != 0)
            {
                for (int i = 0; i < rep.deposits.Count; i++)
                {
                    if (rep.deposits[i].Prestige == 0)
                    {
                        nameSave.Add(rep.deposits[i]);
                    }
                }
                dgViewList.ItemsSource = nameSave;
            }
        }

        /// <summary>
        /// Действие при клике на строку с VIP Депозитами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Selected_VIPDeposit(object sender, RoutedEventArgs e)
        {
            nameSave.Clear();

            if (rep.deposits.Count != 0)
            {
                for (int i = 0; i < rep.deposits.Count; i++)
                {
                    if (rep.deposits[i].Prestige == 1)
                    {
                        nameSave.Add(rep.deposits[i]);
                    }
                }
                dgViewList.ItemsSource = nameSave;
            }
        }

        /// <summary>
        /// Действие при клике на строку с Юридическими Депозитами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Selected_CorpDeposit(object sender, RoutedEventArgs e)
        {
            nameSave.Clear();

            if (rep.deposits.Count != 0)
            {
                for (int i = 0; i < rep.deposits.Count; i++)
                {
                    if (rep.deposits[i].Prestige == 2)
                    {
                        nameSave.Add(rep.deposits[i]);
                    }
                }
                dgViewList.ItemsSource = nameSave;
            }
        }

        /// <summary>
        /// Действие при клике на строку с Кредитами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Selected_Credit(object sender, RoutedEventArgs e)
        {
            nameSave.Clear();
            if (rep.credits.Count != 0)
            {
                for (int i = 0; i < rep.credits.Count; i++)
                {
                    if (rep.credits[i].Prestige == 0)
                    {
                        nameSave.Add(rep.credits[i]);
                    }
                }
                dgViewList.ItemsSource = nameSave;
            }
        }

        /// <summary>
        /// Действие при клике на строку с VIP Кредитами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Selected_VIPCredit(object sender, RoutedEventArgs e)
        {
            nameSave.Clear();
            if (rep.credits.Count != 0)
            {
                for (int i = 0; i < rep.credits.Count; i++)
                {
                    if (rep.credits[i].Prestige == 1)
                    {
                        nameSave.Add(rep.credits[i]);
                    }
                }
                dgViewList.ItemsSource = nameSave;
            }
        }

        /// <summary>
        /// Действие при клике на строку с VIP Кредитами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Selected_CorpCredit(object sender, RoutedEventArgs e)
        {
            nameSave.Clear();
            if (rep.credits.Count != 0)
            {
                for (int i = 0; i < rep.credits.Count; i++)
                {
                    if (rep.credits[i].Prestige == 2)
                    {
                        nameSave.Add(rep.credits[i]);
                    }
                }
                dgViewList.ItemsSource = nameSave;
            }
        }

        /// <summary>
        /// Счетчик текущего положения в таблице
        /// </summary>
        int numID = 0;

        /// <summary>
        /// Кнопка "Добавить Клиента"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_AddKlient(object sender, RoutedEventArgs e)
        {
            AddKlient addKlient = new AddKlient();
            //Сохраняю коллекции в ресурсы
            App.Current.Resources["Score"] = rep.scores;
            App.Current.Resources["people"] = rep.peoples;

            //Вызываю окошко с выбором клиентов
            addKlient.ShowDialog();

            //Выгружаю из ресурсв колекции
            rep.scores = (ObservableCollection<Score>)App.Current.Resources["Score"];
            rep.peoples = (ObservableCollection<People>)App.Current.Resources["people"];
           
            dgViewList.ItemsSource = rep.scores;
            dgNameList.ItemsSource = rep.peoples;

            // добавить вызовы клиентов (норм, ВИП, ЮР)
        }
        /// <summary>
        /// Получение ID выбранного имени Клиента
        /// </summary>
        public int focusNameID = 0;

        /// <summary>
        /// Коллекция для хранения данных dgViewList
        /// </summary>
        ObservableCollection<Score> nameSave = new ObservableCollection<Score>();

        /// <summary>
        /// ВЫбор (фокус) строки в табличке сименем Клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgNameList_GotMouseCapture_Name(object sender, MouseEventArgs e)
        {

            People peopleFocus = (People)dgNameList.SelectedItem;
            focusNameID = peopleFocus.PeopleId;

            /// <summary>
            /// Переменная - счетчик
            /// </summary>
            int check = 0;
            try
            {
                if (rep.scores.Count != 0)
                {
                    nameSave.Clear();
                    foreach (Score p in rep.scores)
                    {
                        if (p.ScoreId == focusNameID)
                        {
                            nameSave.Add(rep.scores[check]);
                        }
                        check++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Close();
            }
            // Добавление данных в таблицу View
            dgViewList.ItemsSource =  nameSave;
        }

        EntDeadline entDeadline = new EntDeadline();

        /// <summary>
        /// Кнопка"Добавить Депозит"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_AddDeposit(object sender, RoutedEventArgs e)
        {
            entDeadline = new EntDeadline();
            MessageBoxResult result = MessageBox.Show($"Создать Депозит с капитализацией?",
                "Создание Депозита",
                MessageBoxButton.YesNoCancel);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    entDeadline.ShowDialog();

                    if (focusNameID != 0)
                        rep.AddToDgDeposit(rep.deposits,
                        focusNameID,
                        true,
                        EntDeadline.deadline,
                        EntDeadline.sum,
                        rep.peoples[focusNameID-1].Prestige);
                   
                    dgViewList.Items.Refresh();
                    break;
                case MessageBoxResult.No:
                    entDeadline.ShowDialog();

                    if(focusNameID!=0)
                    rep.AddToDgDeposit(rep.deposits,
                        focusNameID,
                        false,
                        EntDeadline.deadline,
                        EntDeadline.sum,
                        rep.peoples[focusNameID-1].Prestige);

                    // Добавить разные типы клиентов при добавлении (тип клиента выбирать (0,1,2)
                    dgViewList.Items.Refresh();
                    return;
            }
        }

        private void Button_Click_AddCreit(object sender, RoutedEventArgs e)
        {
            entDeadline = new EntDeadline();
            entDeadline.ShowDialog();

            if (focusNameID != 0)
                rep.AddToDgCredit(rep.credits,
                    focusNameID,
                    false,
                    EntDeadline.deadline,
                    EntDeadline.sum,
                    rep.peoples[focusNameID - 1].Prestige);

           dgViewList.Items.Refresh();
        }
    
        /// <summary>
        /// Путь файла
        /// </summary>
        string puthJson1 = "";
        /// <summary>
        /// Кнопка "Сохранить json"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_SaveJson(object sender, RoutedEventArgs e)
        {
            rep.SaveFileDialog();
            puthJson1 = rep.puth1;
            if (puthJson1 == "")
            { puthJson1 = $@"{Environment.CurrentDirectory}\\json1P.json"; }
            try
            {
                rep.SaveData(rep, puthJson1);
                //rep.SaveData(rep.workers, puthJson2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Close();
            }
        }
        /// <summary>
        /// Кнопка "Добавить json"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_AddJson(object sender, RoutedEventArgs e)
        {
            try
            {
                //Передаем значение строки переменной, хранящей путь
               rep.OpenFileDialog();
                puthJson1 = rep.puth1;
                if (puthJson1 == "")
                { puthJson1 = $@"{Environment.CurrentDirectory}\\json1P.json"; }

                // Передаем конструктору в Классе Rep Данные о пути к файлам
                rep = new Rep(puthJson1);

                rep = rep.LoadDataAll<Rep>();
                //rep.scores = rep.LoadDataAll<Score>();

                string fileEmpty = File.ReadAllText(puthJson1);
                if (fileEmpty == "")
                {
                    MessageBox.Show("Файл пуст, создайте новый, или укажите путь к другому");
                    return;
                }
                dgViewList.ItemsSource = rep.normPeoples;
                dgViewList.ItemsSource = rep.scores;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void Button_Click_TestDep(object sender, RoutedEventArgs e)
        {

        }

        private void dgViewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Действие при выборе строки "Все клиенты"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_Selected_AllKlients(object sender, RoutedEventArgs e)
        {
           dgNameList.ItemsSource = rep.peoples;
        }
    }
}
