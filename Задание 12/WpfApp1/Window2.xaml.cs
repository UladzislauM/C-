﻿using System;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
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
            Window window = new Window();
            window.Owner = this;
            this.DialogResult = true;
 
        }
        public string puthNewFileDep = "";
        /// <summary>
        /// Поле передает путь к файлу.
        /// </summary>
        public string PuthNewFile
        {
            
            get {
                  if (puthNewFileDep == "")
                  { 
                    return puthNewFileDep = $@"{Environment.CurrentDirectory}\\json1.json"; 
                  }
                else
                {
                    return puthNewFileDep = puthNewDoc.Text + nameNewDoc.Text + "Dep.json";
                }
            }
        }

    }
}
