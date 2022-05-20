using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApp1
{
    class Depart : INotifyPropertyChanged
    {
        #region Поля

        /// <summary>
        /// Наименование Отдела
        /// </summary>
        string nameDep;


        /// <summary>
        /// Номер Отдела
        /// </summary>
        int numDepID;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="NameDep">Имя департамента</param>
        /// <param name="NumOfEmpl">Количество Сотрудников Департамента</param>
        public Depart(string NameDep, int NumDepID)
        {
            this.NameDep = NameDep;
            this.NumDepID = NumDepID;

        }

        /// <summary>
        /// Конструктор по умолчанию (в данном случае только для сериализации xml)
        /// </summary>
        public Depart()
        { }
        #endregion

        #region Методы

        /// <summary>
        /// Вывод нв экран
        /// </summary>
        /// <returns></returns>
        public string PrintDep()
        {
            return $"\r\t{this.nameDep,9}";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void PrChenged(string prName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prName));
        }
        #endregion

        #region Свойства
        /// <summary>
        /// Имя Отдела
        /// </summary>
        public string NameDep { get { return this.nameDep; }
            set
            {
                if (nameDep == value)
                    return;
                this.nameDep = value;
                PrChenged("NameDepp");
            }
        }

        /// <summary>
        /// Номер Отдела
        /// </summary>
        public int NumDepID { get { return this.numDepID; }
            set
            {
                if (numDepID == value)
                    return;
                this.numDepID = value;
                PrChenged("NumDepIDD");
            }
        }

        #endregion
    }
}
