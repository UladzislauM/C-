using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApp1
{
    public class Employees : INotifyPropertyChanged
    {

        #region Поля

        /// <summary>
        /// Поле "Имя"
        /// </summary>
        string firstName;

        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        string post;

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
        /// <param name="Age">Возраст</param>
        /// <param name="Salary">Зарплата</param>
        /// <param name="NumOfWorkers">Количество закрепленных сотрудников</param>
        public Employees(string FirstName, uint Salary, int PeopleID, string PostEmpl)
        {
            this.FirstName = FirstName;
            this.Post = PostEmpl;
            this.Salary = Salary;
            this.NumOfWorkers = NumOfWorkers;
            this.PeopleId = PeopleID;
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
        public virtual string PrintEmpl()
        {
            return $"{null,28}\t{this.FirstName,12}\t{this.Salary,8}\t{this.PeopleId}";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void PrChenged(string prName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prName));
        }
        #endregion

        #region Свойства


        /// <summary>
        /// Поле "Имя"
        /// </summary>
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (firstName == value)
                    return;
                this.firstName = value;
                PrChenged("FirstNamEE");
            }
        }

        /// <summary>
        /// Поле "Возраст"
        /// </summary>
        public string Post
        {
            get { return this.post; }
            set
            {
                if (post == value)
                    return;
                this.post = value;
                PrChenged("PosTT");
            }
        }

        /// <summary>
        /// Поле "Оплата труда"
        /// </summary>
        public uint Salary
        {
            get { return this.salary; }
            set
            {
                if (salary == value)
                    return;
                this.salary = value;
                PrChenged("SalarYY");
            }
        }

        /// <summary>
        /// Поле "Количество закрепленных сотрудников"
        /// </summary>
        public uint NumOfWorkers { get { return this.numOfWorkers; } set { this.numOfWorkers = value; } }
        //public static int chechToMainWin = 0;
        /// <summary>
        /// id сотрудника
        /// </summary>
        public int PeopleId
        {
            get { return this.peopleId; }
            set
            {
                if (peopleId == value)
                    return;
                this.peopleId = value;
                PrChenged("PeopleIDDD");
                //chechToMainWin++;
            }
        }

        #endregion

        #region Подклассы

        //public class SortBySalary : IComparer<Employees>
        //{
        //    public int Compare(Worker x, Worker y)
        //    {
        //        Worker X = (Worker)x;
        //        Worker Y = (Worker)y;

        //        if (X.Salary == Y.Salary) return 0;
        //        else if (X.Salary > Y.Salary) return 0;
        //        else return -1;
        //    }
        //}

        public class SortByName : IComparer<Employees>
        {
            public int Compare(Employees x, Employees y)
            {
                Employees X = (Employees)x;
                Employees Y = (Employees)y;

                return String.Compare(X.FirstName, Y.FirstName);
            }
        }

        #endregion
    }
}
