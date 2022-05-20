using System;
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
using System.Windows.Shapes;

namespace Задание_12_переработка
{
    /// <summary>
    /// Логика взаимодействия для CutPeople.xaml
    /// </summary>
    public partial class CutPeople : Window
    {

        MainWindow mainWindow = new MainWindow();
        Rep rep = new Rep();
       
        //internal void AddToCut(ObservableCollection<Depart> departToCut)
        //{
        //    rep.departs = departToCut;
        //}

        public CutPeople()
        {
          
            InitializeComponent();
            cbDep.ItemsSource = (System.Collections.IEnumerable)App.Current.Resources["rep.dep"];
            rep.departs = (ObservableCollection<Depart>)App.Current.Resources["rep.dep"];
            rep.workers = (ObservableCollection<Worker>)App.Current.Resources["rep.work"];
        }
     
        string selDelNum = "";
        private void cbDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic nameDepID = cbDep.SelectedItem;
            selDelNum = nameDepID.NumDepID;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int indexAddDel = 0;
            try
            {
                foreach (Worker p in rep.workers)
                {
                    if (p.PeopleId == MainWindow.focusStrTest)
                    {
                        rep.workers[indexAddDel].PeopleId = selDelNum;
                    }
                    indexAddDel++;
                }
                mainWindow.dgWorker.ItemsSource = rep.workers;
                //mainWindow.dgWorker.);
                
                //App.Current.Resources["rep.work"] = rep.workers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }

            Close();
        }
    }
}

