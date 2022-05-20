using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Deposit : Score
    {
        /// <summary>
        /// Статус клиента
        /// </summary>
        int _prestige;

        /// <summary>
        /// Колличество месяцев до выдачи процентов
        /// </summary>
        int _endDeadline;

        /// <summary>
        /// Срок выдачи процентов
        /// </summary>
        private DateTime _datePerCent;

        /// <summary>
        /// Конструктор для сохранения Дааных в полях класса
        /// </summary>
        /// <param name="TypeDeposit">Тип Депозита</param>
        /// <param name="MoneyDeposit">Колличество средств</param>
        /// <param name="DepositId">ID Депозита</param>
        /// <param name="DateScoreDep">Дата открытия счета</param>
        /// <param name="GetPerCentDep">Индикатор выдачи месячных процентов (с капитализацией)</param>
        /// <param name="GetMoneyDep">Индекатор выдачи всех средств</param>
        /// <param name="DatePerCent">Дата Отсчета процентов (с капитализацией)</param>
        /// <param name="Prestige">Статус клиента счета</param>
        /// <param name="EndDeadline">Колличество месяцев до выдачи процентов</param>
        public Deposit(uint TypeDeposit, float MoneyDeposit, int DepositId, DateTime DateScoreDep, 
            bool GetPerCentDep, bool GetMoneyDep, DateTime DatePerCent, int Prestige, int EndDeadline)
        {
            this.TypeScore = TypeDeposit;
            this.Money = MoneyDeposit;
            this.ScoreId = DepositId;
            this.DateScore = DateScoreDep;
            this.GetPerCent = GetPerCentDep;
            this.GetMoney = GetMoneyDep;
            this.DatePerCent = DatePerCent;
            this.Prestige = Prestige;
            this.EndDeadline = EndDeadline;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Deposit()
        {}

        /// <summary>
        /// Дата выдачи Процентов
        /// </summary>
        public DateTime DatePerCent
        {
            get { return this._datePerCent; }
            set
            {
                if (_datePerCent == value)
                    return;
                this._datePerCent = value;
            }
        }

        /// <summary>
        /// Статус клиента
        /// </summary>
        public int Prestige
        {
            get { return this._prestige; }
            set
            {
                if (_prestige == value)
                    return;
                this._prestige = value;
                PrChenged("PeopleIddd");
            }
        }

        /// <summary>
        /// Колличество месяцев до выдачи процентов
        /// </summary>
        public int EndDeadline
        {
            get { return this._endDeadline; }
            set
            {
                if (_endDeadline == value)
                    return;
                this._endDeadline = value;
                PrChenged("PeopleIddd");
            }
        }
    }
}
