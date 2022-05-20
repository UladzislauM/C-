using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_12_переработка
{
    class Worker : INotifyPropertyChanged
    {
        #region Поля

        /// <summary>
        /// Поле "Имя"
        /// </summary>
        string firstName;

        /// <summary>
        /// Поле "Должность"
        /// </summary>
        string post;

        /// <summary>
        /// Поле "Оплата труда"
        /// </summary>
        uint salary;

        /// <summary>
        /// id сотрудника
        /// </summary>
        string peopleId;
        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="Salary"></param>
        /// <param name="PeopleID"></param>
        /// <param name="Post"></param>
        public Worker(string FirstName, uint Salary, string PeopleID, string Post)
        {
            this.FirstName = FirstName;
            this.Post = Post;
            this.Salary = Salary;
            this.PeopleId = PeopleID;
        }
        /// <summary>
        /// Конструктор по умолчанию (в данном случае только для сериализации xml)
        /// </summary>
        public Worker()
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
        /// ID
        /// </summary>
        public string PeopleId
        {
            get { return this.peopleId; }
            set
            {
                if (peopleId == value)
                    return;
                this.peopleId = value;
                PrChenged("PeopleIDDD");
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

        //public class SortByName : IComparer<Worker>
        //{
        //    public int Compare(Worker x, Worker y)
        //    {
        //        Worker X = (Worker)x;
        //        Worker Y = (Worker)y;

        //        return String.Compare(X.FirstName, Y.FirstName);
        //    }
        //}

        #endregion
    }
}
