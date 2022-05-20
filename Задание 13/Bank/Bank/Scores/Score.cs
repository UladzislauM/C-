using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Score
    {
        #region Поля
        /// <summary>
        /// Тип Счета
        /// </summary>
        private uint _typeScore;

        /// <summary>
        /// Колличество денежных средств
        /// </summary>
        private float _money;

        /// <summary>
        /// Id Счета
        /// </summary>
        private int _scoreId;

        /// <summary>
        /// Дата выдачи депозита (Уже +N месяцев)
        /// </summary>
        private DateTime _dateScore;

        /// <summary>
        /// Идентификатор выдачи процентов
        /// </summary>
        private bool _getPerCent;

        /// <summary>
        /// Идентификатор выдачи познаграждения
        /// </summary>
        private bool _getMoney;
        #endregion

        #region Конструкторы
        /// <summary>
        /// Кронструктор
        /// </summary>
        /// <param name="TypeScore"></param>
        /// <param name="Money"></param>
        /// <param name="ScoreId"></param>
        public Score(uint TypeScore, float Money, int ScoreId, DateTime DateScore, bool GetPerCent, bool GetMoney)
        {
            this.TypeScore = TypeScore;
            this.Money = Money;
            this.ScoreId = ScoreId;
            this.DateScore = DateScore;
            this.GetPerCent = GetPerCent;
            this.GetMoney = GetMoney;
        }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Score()
        {}

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void PrChenged(string prName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prName));
        }
        #endregion

        #region Свойства
       
        /// <summary>
        /// Тип Счета
        /// </summary>
        public uint TypeScore
        {
            get { return this._typeScore; }
            set
            {
                if (_typeScore == value)
                    return;
                this._typeScore = value;
                PrChenged("TypeScoreee");
            }
        }
        /// <summary>
        /// Колличество денежных средств
        /// </summary>
        public float Money
        {
            get { return this._money; }
            set
            {
                if (_money == value)
                    return;
                this._money = value;
                PrChenged("Moneyy");
            }
        }
        /// <summary>
        /// Id Счета
        /// </summary>
        public int ScoreId
        {
            get { return this._scoreId; }
            set
            {
                if (_scoreId == value)
                    return;
                this._scoreId = value;
                PrChenged("ScoreIddd");
            }
        }
        /// <summary>
        /// Дата выдачи депозита
        /// </summary>
        public DateTime DateScore
        {
            get { return this._dateScore; }
            set {
                if (_dateScore == value)
                    return;
                this._dateScore = value;
            }
        }
        /// <summary>
        /// Идентификатор выдачи процентов
        /// </summary>
        public bool GetPerCent
        {
            get { return this._getPerCent; }
            set
            {
                if (_getPerCent == value)
                    return;
                this._getPerCent = value;
            }
        }
        /// <summary>
        /// Идентификатор выдачи депозита
        /// </summary>
        public bool GetMoney
        {
            get { return this._getMoney; }
            set
            {
                if (_getMoney == value)
                    return;
                this._getMoney = value;
            }
        }

    public static implicit operator ObservableCollection<object>(Score v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
