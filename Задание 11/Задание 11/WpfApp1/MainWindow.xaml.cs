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
        public string puthJson1 = $@"{Environment.CurrentDirectory}\\json1.json";
        public string puthJson2 = $@"{Environment.CurrentDirectory}\\json2.json";

        public MainWindow()
        {
            InitializeComponent();

        }
        Rep rep = new Rep();

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            rep = new Rep(puthJson1);

            try
            {
                puthJson1 = puthPeople.Text;
                if (puthJson1 == "")
                { puthJson1 = $@"{Environment.CurrentDirectory}\\json1.json"; }
                puthJson2 = puthPeople2.Text;
                if (puthJson2 == "")
                { puthJson2 = $@"{Environment.CurrentDirectory}\\json2.json"; }
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

        private void dgList_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
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

            int check = 0;
            BindingList<Employees> empl2 = new BindingList<Employees>();
            try
            {
                foreach (Employees p in rep.employees)
                {
                    if (p.PeopleId == selName)
                    {
                        empl2.Add(rep.employees[check]);
                    }
                    check++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            dList.ItemsSource = empl2;
            rep.employees.ListChanged += Employees_ListChanged;
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

    }
}

