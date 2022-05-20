using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.ComponentModel;
using System.Data;
//using System.Windows.Forms;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace WpfApp1
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string puthJson1 = $@"{Environment.CurrentDirectory}\\json1.json";
        private readonly string puthJson2 = $@"{Environment.CurrentDirectory}\\json2.json";

        public MainWindow()
        {
            InitializeComponent();

        }
        Rep rep = new Rep();

        //public ObservableCollection<Depart> depart = new ObservableCollection<Depart>();
        //public List<Depart> depart = new List<Depart>();


        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    string puthJson = puthPeople.Text;
        //    if (puthJson == "")
        //    { puthJson = $@"{Environment.CurrentDirectory}\\jsonOrg1.json"; }

        //    //rep.DeSerialJson(1, puthJson);
        //    //dgList.ItemsSource = rep.departs;
        //}


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            rep = new Rep(puthJson1);

            try
            {
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

        private void Departs_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded ||
              e.ListChangedType == ListChangedType.ItemDeleted ||
              e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    rep.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        private void Employees_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded ||
               e.ListChangedType == ListChangedType.ItemDeleted ||
               e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    rep.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }

        //private void dgList_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    //int repCount = 0;
        //    //if (i >= 0 && i < rep.employees.Count)
        //    //{
        //    //    foreach (var item in rep.departs)
        //    //    {
        //    //        if (item.NumDepID == rep.employees[i].PeopleId) Console.WriteLine($"{rep.employees[repCount].FirstName}, " +
        //    //            $"порядковый номер: {rep.employees[repCount].Number} внутри департамента {item.NameDep}");
        //    //        repCount++;
        //    //    }
        //    //}

          
        //    DataRowView rowView = (DataRowView)dgList.SelectedItem;
        //    DataRow row = rowView.Row;
            
        //    row["NumDepID"] = "New value";

        //    rep = new Rep(puthJson2);

        //    try
        //    {
        //        rep.employees = rep.LoadDataEmpl();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        Close();
        //    }

        //    dgList.ItemsSource = rep.employees;
        //    rep.employees.ListChanged += Employees_ListChanged;
        //}

     



        private void dgList_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //e.Cancel = true;
        }

        private void dList_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //e.Cancel = true;
        }



        private void dgList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            rep = new Rep(puthJson2);


            try
            {
                rep.employees = rep.LoadDataEmpl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            dynamic selIteam = dgList.SelectedItem;
            int selName = 0;
            try
            {
                selName = selIteam.NumDepID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            try
            {
                //var selectedEmplNames = rep.employees.Where(u => u.PeopleId == selName);

                //    foreach (Employees u in selectedEmplNames.ToList())
                //        rep.empl.Add(u);

                //dList.ItemsSource = rep.empl;

                //rep.employees.IndexOf(selIteam.NumDepID);
                if (rep.employees.Equals(selName))
                {
                    dList.ItemsSource = rep.employees;
                }
                rep.employees.ListChanged += Employees_ListChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }


            //dgList.ItemsSource = rep.employees;
            //rep.employees.ListChanged += Employees_ListChanged;
        }


        private void dgList_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rep = new Rep(puthJson2);


            try
            {
                rep.employees = rep.LoadDataEmpl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            dynamic selIteam = dgList.SelectedItem;
            int selName = 0;
            try
            {
                selName = selIteam.NumDepID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            try
            {
                //var selectedEmplNames = rep.employees.Where(u => u.PeopleId == selName);

                //    foreach (Employees u in selectedEmplNames.ToList())
                //        rep.empl.Add(u);

                //dList.ItemsSource = rep.empl;

                //rep.employees.IndexOf(selIteam.NumDepID);
                if (rep.employees.Equals(selName))
                {
                    dList.ItemsSource = rep.employees;
                }
                rep.employees.ListChanged += Employees_ListChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }


            //dgList.ItemsSource = rep.employees;
            //rep.employees.ListChanged += Employees_ListChanged;
        }

        private void dgList_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            rep = new Rep(puthJson2);
            dList.ItemsSource = rep.employees;
            rep.employees.ListChanged += Employees_ListChanged;

            try
            {
                rep.employees = rep.LoadDataEmpl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            dynamic selIteam = dgList.SelectedItem;
            int selName = 0;
            try
            {
                selName = selIteam.NumDepID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            try
            {

                //DataGridRow dataGridRow;
                //foreach (var p in dgList.Columns)
                //{
                //    if (p. == "Mike")
                //    {
                //        dataGridRow = dataGrid.ItemContainerGenerator.ContainerFromItem(people[2]) as DataGridRow;
                //        dataGridRow.Visibility = System.Windows.Visibility.Collapsed;
                //        return;
                //    }
                //}

                //dataGridRow = dataGrid.ItemContainerGenerator.ContainerFromItem(people[2]) as DataGridRow;
                //dataGridRow.Visibility = System.Windows.Visibility.Visible;

                for (int i = 0; i < dgList.Items.Count; i++)
                {
                   DataGridRow row = (DataGridRow)dgList.ItemContainerGenerator.ContainerFromIndex(i);
                    //if (row != selIteam.NumDepID)
                    var COLLECTION = (CollectionView)CollectionViewSource.GetDefaultView(dgList);
                    string SomeText = ((TextBox)row[e.].FindControl("TextBox1")).Text;

                }

                foreach (var y in dgList.Columns)
                {
                    //if (colum.Cells[2].Value != null && (int)row.Cells[2].Value == 0)
                    //{
                    //    row.Visible = false;
                    //}

                }

                //var selectedEmplNames = rep.employees.Where(u => u.PeopleId == selName);

                //    foreach (Employees u in selectedEmplNames.ToList())
                //        rep.empl.Add(u);

                //dList.ItemsSource = rep.empl;

                //rep.employees.IndexOf(selIteam.NumDepID);

            
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }


            //dgList.ItemsSource = rep.employees;
            //rep.employees.ListChanged += Employees_ListChanged;
        
        }
    }
}

