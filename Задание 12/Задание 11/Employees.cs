using System;
using System.Collections.Generic;
using System.Text;

namespace Task_11
{
    class Employees : BaseCont
    {

        //#region Поля

        ///// <summary>
        ///// Поле "Имя"
        ///// </summary>
        //string firstName;

        ///// <summary>
        ///// Поле "Возраст"
        ///// </summary>
        //string post;

        ///// <summary>
        ///// Поле "Оплата труда"
        ///// </summary>
        //uint salary;

        ///// <summary>
        ///// Поле "Количество закрепленных сотрудников"
        ///// </summary>
        //uint numOfWorkers;

        ///// <summary>
        ///// id сотрудника
        ///// </summary>
        //int peopleId;
        //#endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="FirstName">Имя</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="NumOfWorkers">Количество закрепленных сотрудников</param>
        public Employees(string FirstName, uint Salary, int PeopleID, string PostEmpl)
        {
            this.FirstName = FirstName;
            this.Post = PostEmpl;
            this.Salary = Salary;
            this.PeopleId = PeopleID;
        }
        /// <summary>
        /// Конструктор по умолчанию (в данном случае только для сериализации xml)
        /// </summary>
        public Employees()
        { }
        #endregion

        

        //#region Свойства

        ///// <summary>
        ///// Поле "Имя"
        ///// </summary>
        //public new string FirstName { get { return this.firstName; } set { this.firstName = value; } }

        ///// <summary>
        ///// Поле "Возраст"
        ///// </summary>
        //public string Post { get { return this.post; } set { this.post = value; } }

        ///// <summary>
        ///// Поле "Оплата труда"
        ///// </summary>
        //public uint Salary { get { return this.salary; } set { this.salary = value; } }

        ///// <summary>
        ///// Поле "Количество закрепленных сотрудников"
        ///// </summary>
        //public uint NumOfWorkers { get { return this.numOfWorkers; } set { this.numOfWorkers = value; } }

        ///// <summary>
        ///// id сотрудника
        ///// </summary>
        //public int PeopleId { get { return this.peopleId; } set { this.peopleId = value; } }

        //#endregion
    }
}
