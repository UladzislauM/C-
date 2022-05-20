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
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для EntDeadline.xaml
    /// </summary>
    public partial class EntDeadline : Window
    {
        public EntDeadline()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Число месяцев выдачи
        /// </summary>
        public static int deadline = 0;

        /// <summary>
        /// Сумма
        /// </summary>
        public static int sum = 0;
        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (entDeadline != null
                && int.TryParse($"{entDeadline.Text}", out deadline)
                && int.TryParse($"{entSum.Text}", out sum))
            {
                deadline = int.Parse($"{entDeadline.Text}");
                
                sum = int.Parse($"{entSum.Text}");
                Close();
            }
            else
            {
                MessageBox.Show("Введите число (не букву)");
            }
        }

    }
}
