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

namespace Задание_12_переработка
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Rep rep = new Rep();
        public static int numDepIDstr = 0;
        public static int numDepIDstrPC = 0;
        Random rand = new Random();
        string focusString = "";
        float focusFloat = 0;
        int rowIndex = 1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            numDepIDstr++;
            if (rep.departs.Count == 0)
            {
                dgDeparts.ItemsSource = rep.departs;
                rep.departs.CollectionChanged += Departs_CollectionChanged;
            }
            rep.departs.Add(new Depart(){NumDepID = numDepIDstr});
        }

        private void Departs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                //numDepIDstr++;
            }
          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                       //int selectedColumn = dgDeparts.CurrentCell.Column.DisplayIndex;
            //var selectedCell = dgDeparts.SelectedCells[selectedColumn];
            //var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);



            Depart drv = (Depart)dgDeparts.SelectedItems[0];
            focusFloat = drv.NumDepID;

            if (rep.departs == null)
            {
                rep.departs = new ObservableCollection<Depart>();
                dgDeparts.ItemsSource = rep.departs;
            }

            int indexNumDepID = rep.departs.IndexOf((Depart)dgDeparts.SelectedItems[0]);
            int digitCount = (int)Math.Log10(focusFloat) + 1;

            focusString = focusFloat.ToString();
            int lastFigure = int.Parse(focusString[focusString.Length - 1].ToString());

            if (digitCount == 1 || lastFigure != 0)
                rep.departs.Insert(indexNumDepID + 1,
                    new Depart() { NumDepID = focusFloat + "" });
            else
            {
                //if()
                rep.departs.Insert(indexNumDepID + 1,
                   new Depart() { NumDepID = focusFloat + 1 });
                // Добавлять по выделенной строке каждый раз еденицу(не к ней(выделенной), а к той что далее)
            }
        }
        private void dgDeparts_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
           rowIndex = dgDeparts.SelectedIndex;
          
        }
        
        
        private void dgDeparts_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        {
   
        }

        private void dgDeparts_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {

        }

      
    }
}
