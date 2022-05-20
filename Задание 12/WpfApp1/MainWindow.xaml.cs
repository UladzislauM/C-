using System;
using System.IO;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Controls;
//using static WpfApp1.FullyOC;

namespace WpfApp1
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string puthJson1 ="";
        public string puthJson2 = "";
        
        public MainWindow()
        {
            InitializeComponent();
        }

        Rep rep = new Rep();
        Window2 window2 = new Window2();
           /// <summary>
           /// Действие по нажатию кнопки "Добавить json"
           /// </summary>
           /// <param name="sender"></param>
           /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                dgList.Items.Clear();
                    puthJson1 = puthPeople.Text;
                    if (puthJson1 == "")
                    { puthJson1 = $@"{Environment.CurrentDirectory}\\json1.json"; }
                    puthJson2 = puthPeople2.Text;
                    if (puthJson2 == "")
                    { puthJson2 = $@"{Environment.CurrentDirectory}\\json2.json"; }

                    rep = new Rep(puthJson1, puthJson2);
                    rep.departs = rep.LoadDataDep();

                string fileEmpty = File.ReadAllText(puthJson1);
                if (fileEmpty == "")
                {
                    MessageBox.Show("Файл пуст, создайте новый, или укажите путь к другому");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            
            dgList.ItemsSource = rep.departs;
            rep.departs.ListChanged += Departs_ListChanged;
        }

        /// <summary>
        /// Действие по нажатию кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dgList.Items.Clear();
                if (window2.ShowDialog() == true)
                {
                    puthJson1 = window2.PuthNewFile;
                }
                else
                {
                    puthJson1 = puthPeople.Text;
                }
                if (puthJson1 == "")
                { puthJson1 = $@"{Environment.CurrentDirectory}\\json1.json"; }
                puthJson2 = puthPeople2.Text;
                if (puthJson2 == "")
                { puthJson2 = $@"{Environment.CurrentDirectory}\\json2.json"; }
                rep = new Rep(puthJson1, puthJson2);
                rep.departs = rep.LoadDataDep();

              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

          
            dgList.ItemsSource = rep.departs;
            rep.departs.ListChanged += Departs_ListChanged;

        }

        public static int delName = 0;
        BindingList<Depart> depp = new BindingList<Depart>();
        /// <summary>
        /// Сюда попадают все изменения таблицы. (Отделы)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Departs_ListChanged(object sender, ListChangedEventArgs e)
        {
           
          
            if (e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    rep.SaveData(sender, puthJson1);
                    rep.departs = (BindingList<Depart>)dgList.ItemsSource;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
            if(e.ListChangedType == ListChangedType.ItemDeleted)
            {
                depp = rep.LoadDataDepCopy();
                delName = depp[e.NewIndex].NumDepID;
                rep.employees = rep.LoadDataEmpl();
                try
                {
                    
                    MessageBoxResult result = MessageBox.Show($"Удалить Отдел?", "Удаление", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            MessageBoxResult result2 = MessageBox.Show($"Уволить работников?", "Увольнение", MessageBoxButton.YesNo);
                            switch (result2)
                            {
                                case MessageBoxResult.Yes:
                                    //rep = new Rep(puthJson1);
                                    rep.SaveData(sender, puthJson1);
                                    break;
                                case MessageBoxResult.No:
                                    //rep = new Rep(puthJson1);
                                    rep.SaveData(sender, puthJson1);
                                    Window1 window1 = new Window1();
                                    window1.Show();
                                    return;
                            }
                            break;
                        case MessageBoxResult.No:
                            //rep = new Rep(puthJson1);
                            rep.departs = rep.LoadDataDepCopy();
                            rep.SaveData(rep.departs, puthJson1);
                            dgList.ItemsSource = rep.departs;
                            return;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
       public int delName2 = delName;
      
        ObservableCollection<Employees> empl2 = new ObservableCollection<Employees>();
        public int indexCheckChenged = 0;
        static int selName = 0;
        int checkAdd = 0;
        public int checkAdd2 = 0;
        /// <summary>
        /// Действие Двойномой клик по любому отделу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgList_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            empl2.CollectionChanged -= Empl2_CollectionChanged;
            if (indexCheckChenged != 0)
            {
                MessageBoxResult result = MessageBox.Show($"Желаете сохранить?", "Переход на другой отдел", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        indexCheckChenged = 0;

                        rep.SaveData(rep.employees, puthJson2);
                        break;
                    case MessageBoxResult.No:
                        indexCheckChenged = 0;
                        rep.employees = rep.LoadDataEmplCopy();
                        break;
                }
            }

            if (indexCheckChenged == 0 && checkAdd == 0)
            {
                try
                {
                    rep.employees = rep.LoadDataEmpl();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
            dynamic selIteam = dgList.SelectedItem;

            try
            {
                selName = selIteam.NumDepID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            int check = 0;
            
            try
            {
                if (rep.employees.Count != 0)
                {
                    empl2.Clear();
                    foreach (Employees p in rep.employees)
                    {
                        if (p.PeopleId == selName)
                        {
                            empl2.Add(rep.employees[check]);
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


            dList.ItemsSource = empl2;
            empl2.CollectionChanged += Empl2_CollectionChanged;
            checkAdd2 = 0;
            checkAdd++;
           }

        /// <summary>
        /// Сюда попадают все изменения таблицы. (Рабочие)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Empl2_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            if (checkChengeCollom == 0)
            {
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    MessageBoxResult result = MessageBox.Show($"Вы действительно хотите удалить?", "Удаление", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            break;
                        case MessageBoxResult.No:
                            return;
                    }
 
                    int indexEditEmpl = 0;

                    for (int i = 0; i < rep.employees.Count; i++)
                    {
                        if (empl2[0].PeopleId == rep.employees[i].PeopleId)
                        {
                            if (empl2[indexEditEmpl] != rep.employees[i])
                            {
                                rep.employees.RemoveAt(i);

                            }
                            indexEditEmpl++;
                        }
                    }

                    rep.SaveData(rep.employees, puthJson2);
                    indexCheckChenged++;
                }
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    checkAdd2++;
                    if (rep.employees.Count == 0)
                    {
                        rep.employees = empl2;
                    }
                    else
                    {
                             rep.employees.Add(empl2[empl2.Count - 1]);
                    }
                    rep.SaveData(rep.employees, puthJson2);
                    indexCheckChenged++;
                }



            }
        }
        int checkChengeCollom = 0;
        /// <summary>
        /// Событие при выходе из любого отдела (добавлено для редактирования строк в OK).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dList_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            
            checkChengeCollom++;
            if (rep.employees.Count != 0 || checkAdd2 != 0)
            {
                ObservableCollection<Employees> emplo = new ObservableCollection<Employees>();
                object editCollom2 = e.Row.Item;
                emplo.Add((Employees)editCollom2);

                rep.employees[indexEditEmpl2] = emplo[0];
                rep.SaveData(rep.employees, puthJson2);
                indexCheckChenged++;

            }
          
            checkChengeCollom = 0;
            checkAdd = 0;
        }
        public static int indexEditEmpl2 = 0;
        /// <summary>
        /// Действие при выборе строки в Рабочих (добавлено для редактирования строк в OK).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dList_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            dynamic editCollom1 = dList.SelectedItem;
            indexEditEmpl2 = rep.employees.IndexOf(editCollom1);
        }

        public int selNamePub = selName;
        public static int checkDell = 0; 
        /// <summary>
        /// Действие для кнопки "Сохранение".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(puthJson1 != "")
            try
            {
                rep.SaveData(rep.departs, puthJson1);
                rep.SaveData(rep.employees, puthJson2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

     }
}

