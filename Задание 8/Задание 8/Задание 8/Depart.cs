using System;
using System.Collections.Generic;
using System.Text;

namespace Задание_8
{
    public class Depart
    {
        #region Поля

        /// <summary>
        /// Наименование Отдела
        /// </summary>
        string nameDep;

        /// <summary>
        /// Дата создания Отдела
        /// </summary>
        string dateDep;

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
        /// <param name="DateDep">Дата Создания департамента</param>
        /// <param name="NumOfEmpl">Количество Сотрудников Департамента</param>
        public Depart(string NameDep, string DateDep, int NumDepID)
        {
            this.nameDep = NameDep;
            this.dateDep = DateDep;
            this.numDepID = NumDepID;

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
            return $"\r\t{this.nameDep,9} \t{this.dateDep,11} ";
        }
        #endregion

        #region Свойства
        /// <summary>
        /// Имя Отдела
        /// </summary>
        public string NameDep { get { return this.nameDep; } set { this.nameDep = value; } }

        /// <summary>
        /// Дата создания Отдела
        /// </summary>
        public string DateDep { get { return this.dateDep; } set { this.dateDep = value; } }

        /// <summary>
        /// Номер Отдела
        /// </summary>
        public int NumDepID { get { return this.numDepID; } set { this.numDepID = value; } }

        #endregion
    }
}
