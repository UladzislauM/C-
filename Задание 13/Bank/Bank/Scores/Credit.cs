using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Credit : Deposit
    {
        ///// <summary>
        ///// Статус клиента
        ///// </summary>
        //int _prestige;

        ///// <summary>
        ///// Колличество месяцев до выдачи процентов
        ///// </summary>
        //int _endDeadline;

        ///// <summary>
        ///// Срок выдачи процентов
        ///// </summary>
        //private DateTime _datePerCent;

        ///// <summary>
        ///// Конструктор для сохранения Дааных в полях класса
        ///// </summary>
        ///// <param name="DatePerCent">Дата Отсчета процентов</param>
        ///// <param name="Prestige">Статус клиента счета</param>
        ///// <param name="EndDeadline">Колличество месяцев до выдачи процентов</param>
        //public Credit(DateTime DatePerCent, int Prestige, int EndDeadline)
        //{
        //    this.DatePerCent = DatePerCent;
        //    this.Prestige = Prestige;
        //    this.EndDeadline = EndDeadline;
        //}
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Credit()
        { }
        ///// <summary>
        ///// Дата выдачи Процентов
        ///// </summary>
        //public DateTime DatePerCent
        //{
        //    get { return this._datePerCent; }
        //    set
        //    {
        //        if (_datePerCent == value)
        //            return;
        //        this._datePerCent = value;
        //    }
        //}

        ///// <summary>
        ///// Статус клиента
        ///// </summary>
        //public int Prestige
        //{
        //    get { return this._prestige; }
        //    set
        //    {
        //        if (_prestige == value)
        //            return;
        //        this._prestige = value;
        //        PrChenged("PeopleIddd");
        //    }
        //}

        ///// <summary>
        ///// Колличество месяцев до выдачи процентов
        ///// </summary>
        //public int EndDeadline
        //{
        //    get { return this._endDeadline; }
        //    set
        //    {
        //        if (_endDeadline == value)
        //            return;
        //        this._endDeadline = value;
        //        PrChenged("PeopleIddd");
        //    }
        //}
    }

}
