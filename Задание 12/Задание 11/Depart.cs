using System;
using System.Collections.Generic;
using System.Text;

namespace Task_11
{
    class Depart
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
        #endregion

        #region Свойства
        /// <summary>
        /// Имя Отдела
        /// </summary>
        public string NameDep { get { return this.nameDep; } set { this.nameDep = value; } }

        /// <summary>
        /// Номер Отдела
        /// </summary>
        public int NumDepID { get { return this.numDepID; } set { this.numDepID = value; } }

        #endregion
    }
}
