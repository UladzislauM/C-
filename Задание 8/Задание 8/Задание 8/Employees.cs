using System;
using System.Collections.Generic;
using System.Text;

namespace Задание_8
{
    public class Employees
    {

        #region Поля

        /// <summary>
        /// Поле "Имя"
        /// </summary>
        string firstName;

        /// <summary>
        /// Поле "Фамилия"
        /// </summary>
        string lastName;

        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        string age;

        /// <summary>
        /// Поле "Номер"
        /// </summary>
        int number;

        /// <summary>
        /// Поле "Оплата труда"
        /// </summary>
        uint salary;

        /// <summary>
        /// Поле "Количество закрепленных сотрудников"
        /// </summary>
        uint numOfWorkers;

        /// <summary>
        /// id сотрудника
        /// </summary>
        int peopleId;
        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="FirstName">Имя</param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="Number">Номер</param>
        /// <param name="NumOfWorkers">Количество закрепленных сотрудников</param>
        public Employees(string FirstName, string LastName, string Age, uint Salary, int Number, uint NumOfWorkers, int PeopleID)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.age = Age;
            this.number = Number;
            this.salary = Salary;
            this.numOfWorkers = NumOfWorkers;
            this.peopleId = PeopleID;
        }
        /// <summary>
        /// Конструктор по умолчанию (в данном случае только для сериализации xml)
        /// </summary>
        public Employees()
        { }
        #endregion

        #region Методы

        /// <summary>
        /// Вывод нв экран
        /// </summary>
        /// <returns></returns>
        public string PrintEmpl()
        {
            return $"{null,28}\t{this.firstName,12}{null,2} \t{this.lastName,15} \t{this.age,2} \t{this.number,2} \t{this.salary,8}{null,4}\t{this.numOfWorkers}";
        }
        #endregion

        #region Свойства

        /// <summary>
        /// Поле "Имя"
        /// </summary>
        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }

        /// <summary>
        /// Поле "Фамилия"
        /// </summary>
        public string LastName { get { return this.lastName; } set { this.lastName = value; } }

        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        public string Age { get { return this.age; } set { this.age = value; } }

        /// <summary>
        /// Поле "Номер"
        /// </summary>
        public int Number { get { return this.number; } set { this.number = value; } }

        /// <summary>
        /// Поле "Оплата труда"
        /// </summary>
        public uint Salary { get { return this.salary; } set { this.salary = value; } }

        /// <summary>
        /// Поле "Количество закрепленных сотрудников"
        /// </summary>
        public uint NumOfWorkers { get { return this.numOfWorkers; } set { this.numOfWorkers = value; } }

        /// <summary>
        /// id сотрудника
        /// </summary>
        public int PeopleId { get { return this.peopleId; } set { this.peopleId = value; } }

        #endregion
    }
}
