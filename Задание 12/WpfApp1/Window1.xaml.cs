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
//using static WpfApp1.FullyOC;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Rep rep = new Rep();
        MainWindow mainWindow = new MainWindow();

        public Window1()
        {
            InitializeComponent();
            try
            {
              mainWindow.puthJson1 = mainWindow.puthPeople.Text;
                if (mainWindow.puthJson1 == "")
                {mainWindow.puthJson1 = $@"{Environment.CurrentDirectory}\\json1.json"; }
                rep = new Rep(mainWindow.puthJson1, mainWindow.puthJson2);
                rep.departs = rep.LoadDataDep();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            cbDep.ItemsSource = rep.departs;
        }

        int selDelNum = 0;
        private void cbDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic nameDepID = cbDep.SelectedItem;
            selDelNum = nameDepID.NumDepID;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.puthJson2 = mainWindow.puthPeople2.Text;
                if (mainWindow.puthJson2 == "")
                {mainWindow.puthJson2 = $@"{Environment.CurrentDirectory}\\json2.json"; }
                //rep = new Rep(mainWindow.puthJson2);

                rep.employees = rep.LoadDataEmplCopy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            int indexAddDel = 0;
            try
            {
                foreach (Employees p in rep.employees)
                {
                  if (p.PeopleId == mainWindow.delName2)
                  {
                    rep.employees[indexAddDel].PeopleId = selDelNum;
                  }
                indexAddDel++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

                    rep.SaveData(rep.employees, mainWindow.puthJson2);
            Close();
             }
        }
    }

