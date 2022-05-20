using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class People
    {
        #region Поля
        /// <summary>
        /// Имя Клиента
        /// </summary>
        string fName;

        /// <summary>
        /// Фамилия Клиента
        /// </summary>
        string lName;

        /// <summary>
        /// Кредитная история
        /// </summary>
        double history;

        /// <summary>
        /// Номер Клиента
        /// </summary>
        int peopleId;

        /// <summary>
        /// Статус клиента
        /// </summary>
        int prestige;
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="FName"></param>
        /// <param name="LName"></param>
        /// <param name="History"></param>
        /// <param name="PeopleId"></param>
        public People (string FName, string LName, double History, int PeopleId, int Prestige)
        {
            this.FName = FName;
            this.LName = LName;
            this.History = History;
            this.PeopleId = PeopleId;
            this.Prestige = Prestige;
        }

        public People()
        { }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void PrChenged(string prName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prName));
        }
        #endregion

        #region Свойства
        /// <summary>
        /// Имя Клиента
        /// </summary>
        public string FName
        {
            get { return this.fName; }
            set
            {
                if (fName == value)
                    return;
                this.fName = value;
                PrChenged("FNamEE");
            }
        }

        /// <summary>
        /// Фамилия Клиента
        /// </summary>
        public string LName
        {
            get { return this.lName; }
            set
            {
                if (lName == value)
                    return;
                this.lName = value;
                PrChenged("LNamEE");
            }
        }
        /// <summary>
        /// Кредитная история
        /// </summary>
        public double History
        {
            get { return this.history; }
            set
            {
                if (history == value)
                    return;
                this.history = value;
                PrChenged("Historyyy");
            }
        }

        /// <summary>
        /// Номер Клиента
        /// </summary>
        public int PeopleId
        {
            get { return this.peopleId; }
            set
            {
                if (peopleId == value)
                    return;
                this.peopleId = value;
                PrChenged("PeopleIddd");
            }
        }

        /// <summary>
        /// Статус клиента
        /// </summary>
        public int Prestige
        {
            get { return this.prestige; }
            set
            {
                if (prestige == value)
                    return;
                this.prestige = value;
                PrChenged("PeopleIddd");
            }
        }
        #endregion
    }
}
