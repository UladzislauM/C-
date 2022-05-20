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

namespace Задание_12_переработка
{
    /// <summary>
    /// Логика взаимодействия для SaveFile.xaml
    /// </summary>
    public partial class SaveFile : Window
    {
        public SaveFile()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Действие для кнопки "Создать".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.DialogResult = true;

        }

        /// <summary>
        /// Переменная для хранения Полного пучи к файлу
        /// </summary>
        public string puthNewFileDep = "";
        
        /// <summary>
        /// Поле передает путь к файлу json1.
        /// </summary>
        public string PuthNewFile
        {

            get
            {
                puthNewFileDep = "";
                puthNewFileDep = puthNewDoc.Text + nameNewDoc.Text;
                if (puthNewFileDep == "")
                {
                    puthNewFileDep = $@"{Environment.CurrentDirectory}\\json1D.json";
                }
               
                return puthNewFileDep;
            }
        }
        /// <summary>
        /// Поле передает путь к файлу json2.
        /// </summary>
        public string PuthNewFile2
        {

            get
            {
                puthNewFileDep = "";
                puthNewFileDep = puthNewDoc.Text + nameNewDoc.Text;
                if (puthNewFileDep == "")
                {
                    puthNewFileDep = $@"{Environment.CurrentDirectory}\\json2W.json";
                }

                return puthNewFileDep;
            }
        }
    }
}
