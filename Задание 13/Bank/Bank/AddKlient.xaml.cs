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

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для AddKlient.xaml
    /// </summary>
    public partial class AddKlient : Window
    {
        public AddKlient()
        {
            InitializeComponent();
        }
        Rep rep = new Rep();

        /// <summary>
        /// Идентификатор выбора коллекции
        /// </summary>
        int checkComboBox = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(checkComboBox == 1)
            rep.AddToDgPeople(0);
            if (checkComboBox == 2)
                rep.AddToDgPeople(1);
            if (checkComboBox == 3)
                rep.AddToDgPeople(2);
            Close();
        }

        private void ComboBoxItem_Selected_normPeople(object sender, RoutedEventArgs e)
        {
            checkComboBox = 1;
        }

        private void ComboBoxItem_Selected_VIPPeople(object sender, RoutedEventArgs e)
        {
            checkComboBox = 2;
        }

        private void ComboBoxItem_Selected_corpCkients(object sender, RoutedEventArgs e)
        {
            checkComboBox = 3;
        }
    }
}
