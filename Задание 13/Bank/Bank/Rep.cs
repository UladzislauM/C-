using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bank
{
    class Rep
    {

        public ObservableCollection<Score> scores = new ObservableCollection<Score>();
        public ObservableCollection<Deposit> deposits = new ObservableCollection<Deposit>();
        public ObservableCollection<Credit> credits = new ObservableCollection<Credit>();
        public ObservableCollection<People> peoples = new ObservableCollection<People>();
        public ObservableCollection<NormPeople> normPeoples = new ObservableCollection<NormPeople>();
        public ObservableCollection<VIPPeople> vipPeoples = new ObservableCollection<VIPPeople>();
        public ObservableCollection<CorpPeople> corpPeoples = new ObservableCollection<CorpPeople>();
        public Rep(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }
        MainWindow mainWindow;
        #region Конструкторы

        /// <summary>
        /// Определение "Кастомного" Конструктора для добавления к People
        /// </summary>
        /// <param name="RealDeparts"></param>
        public void AddDep(NormPeople RealDeparts)
        {
            normPeoples.Add(RealDeparts);
        }

        /// <summary>
        /// Определение "Кастомного" Конструктора для добавления к Score
        /// </summary>
        /// <param name="RealEmployees"></param>
        public void AddScore(Score RealScore)
        {
            scores.Add(RealScore);
        }


        private readonly string PuthJson1;
        //private readonly string PuthJson2;

        /// <summary>
        /// Определение пути для файла
        /// </summary>
        /// <param name="puth1"></param>
        public Rep(string puth1)
        {
            PuthJson1 = puth1;
        }
        public string puth1
        { get; set; }



        /// <summary>
        /// Определение конструктора по умолчанию
        /// </summary>
        public Rep()
        { }
        #endregion
        #region Методы


        /// <summary>
        /// Сериализация Конторы json
        /// </summary>
        public void SaveData(object todoDataList, string puthSave)
        {
            using (StreamWriter writer = File.CreateText(puthSave))
            {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }

        }
        #region Старые Загрузки файла
        ///// <summary>
        ///// Дисериализация json для People
        ///// </summary>
        //public ObservableCollection<People> LoadDataWorker()
        //{
        //    var fileExist = File.Exists(PuthJson2);
        //    if (!fileExist)
        //    {
        //        File.CreateText(PuthJson2).Dispose();
        //        return new ObservableCollection<People>();
        //    }
        //    using (var reader = File.OpenText(PuthJson2))
        //    {
        //        var fileText = reader.ReadToEnd();
        //        return JsonConvert.DeserializeObject<ObservableCollection<People>>(fileText);
        //    }

        //}

        ///// <summary>
        ///// Дисериализация json для Score
        ///// </summary>

        //public ObservableCollection<Score> LoadDataDep()
        //{
        //    var fileExist = File.Exists(PuthJson1);
        //    if (!fileExist)
        //    {
        //        File.CreateText(PuthJson1).Dispose();
        //        return new ObservableCollection<Score>();
        //    }
        //    using (var reader = File.OpenText(PuthJson1))
        //    {
        //        var fileText = reader.ReadToEnd();
        //        return JsonConvert.DeserializeObject<ObservableCollection<Score>>(fileText);
        //    }

        //}
        #endregion
        /// <summary>
        /// Загрузка коллекции из файла в Общем виде
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Rep LoadDataAll<T>()
        {
            var fileExist = File.Exists(PuthJson1);
            if (!fileExist)
            {
                File.CreateText(PuthJson1).Dispose();
                return new Rep();
            }
            using (var reader = File.OpenText(PuthJson1))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Rep>(fileText);

                //Разобраться с диссеризацией нескольких классов (сохраняет нормально)
            }

        }

        public void AddToClass<T>()
        {
            //<T>.Add(new Depart() { NumDepID = $"{numDepIDstr}" });
        }
        /// <summary>
        /// Открыть файл с помощью файловой системы Win
        /// </summary>
        /// <returns></returns>
        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                puth1 = openFileDialog.FileName;

                return true;
            }
            return false;
        }
        /// <summary>
        /// Сохранить файл с помощью файловой системы Win
        /// </summary>
        /// <returns></returns>
        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                puth1 = saveFileDialog.FileName;

                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод для добавления в таблицу класса People
        /// </summary>
        /// <param name="numScoreID"></param>
        public void AddToDgPeople(int numScoreID)
        {
            int numIDPeop = 0;
            MainWindow mainWindow = new MainWindow();
            // Выгружаю коллекции из ресурсов
            scores = (ObservableCollection<Score>)App.Current.Resources["Score"];
            peoples = (ObservableCollection<People>)App.Current.Resources["people"];
            //vipPeoples = (ObservableCollection<VIPPeople>)App.Current.Resources["vipPeople"];
            //corpPeoples = (ObservableCollection<CorpPeople>)App.Current.Resources["corpPeople"];

            if (peoples.Count == 0)
            {
                //numIDPeop = 0;
                numIDPeop++;

                if (numScoreID == 0)
                {
                    scores.Add(new Score() { ScoreId = numIDPeop, TypeScore = 0 });
                    peoples.Add(new People() { PeopleId = numIDPeop, Prestige = 0 });
                }
                if (numScoreID == 1)
                {
                    scores.Add(new Score() { ScoreId = numIDPeop, TypeScore = 1 });
                    peoples.Add(new People() { PeopleId = numIDPeop, Prestige = 1 });
                }
                if (numScoreID == 2)
                {
                    scores.Add(new Score() { ScoreId = numIDPeop, TypeScore = 2 });
                    peoples.Add(new People() { PeopleId = numIDPeop, Prestige = 2 });
                }
            }
            else
            {
                numIDPeop = peoples[peoples.Count - 1].PeopleId;
                numIDPeop++;
                if (peoples.Count == 0)
                {
                    mainWindow.dgViewList.ItemsSource = peoples;
                    mainWindow.dgViewList.ItemsSource = scores;
                }
                if (numScoreID == 0)
                {
                    scores.Add(new Score() { ScoreId = numIDPeop, TypeScore = 0 });
                    peoples.Add(new People() { PeopleId = numIDPeop, Prestige = 0 });
                }
                if (numScoreID == 1)
                {
                    scores.Add(new Score() { ScoreId = numIDPeop, TypeScore = 1 });
                    peoples.Add(new People() { PeopleId = numIDPeop, Prestige = 1 });
                }
                if (numScoreID == 2)
                {
                    scores.Add(new Score() { ScoreId = numIDPeop, TypeScore = 2 });
                    peoples.Add(new People() { PeopleId = numIDPeop, Prestige = 2 });
                }

            }


            //if (numScoreID == 1)
            //{

            //    if (normPeoples.Count == 0)
            //    {
            //        numIDPeop = 0;
            //        numIDPeop++;
            //        if (normPeoples.Count == 0)
            //        {
            //            mainWindow.dgViewList.ItemsSource = normPeoples;
            //        }
            //        scores.Add(new Score() { ScoreId = numIDPeop, TypeScore = 1 });
            //        vipPeoples.Add(new VIPPeople() { PeopleId = numIDPeop });

            //    }
            //    else
            //    {
            //        numIDPeop = normPeoples[normPeoples.Count - 1].PeopleId;
            //        numIDPeop++;
            //        if (normPeoples.Count == 0)
            //        {
            //            mainWindow.dgViewList.ItemsSource = normPeoples;
            //        }
            //        scores.Add(new Score() { ScoreId = numIDPeop, TypeScore = 1 });
            //        vipPeoples.Add(new VIPPeople() { PeopleId = numIDPeop });
            //    }
            //}
            //if (numScoreID == 2)
            //{

            //    if (normPeoples.Count == 0)
            //    {
            //        numIDPeop = 0;
            //        numIDPeop++;
            //        if (normPeoples.Count == 0)
            //        {
            //            mainWindow.dgViewList.ItemsSource = normPeoples;
            //        }
            //        scores.Add(new Score() { ScoreId = numIDPeop, TypeScore = 2 });
            //        corpPeoples.Add(new CorpPeople() { PeopleId = numIDPeop });
            //    }
            //    else
            //    {
            //        numIDPeop = normPeoples[normPeoples.Count - 1].PeopleId;
            //        numIDPeop++;
            //        if (normPeoples.Count == 0)
            //        {
            //            mainWindow.dgViewList.ItemsSource = normPeoples;
            //        }
            //        scores.Add(new Score() { ScoreId = numIDPeop, TypeScore = 2 });
            //        corpPeoples.Add(new CorpPeople() { PeopleId = numIDPeop });
            //    }
            //}
            ////Сохраняю коллекции в ресурсы
            App.Current.Resources["Score"] = scores;
            App.Current.Resources["people"] = peoples;

        }

        /// <summary>
        /// Метод для добавления в таблицу класса Score 
        /// </summary>
        /// <param name="skore"></param>
        public void AddToDgScore(ObservableCollection<Score> skore)
        {
            int numIDSC = 0;
            if (skore.Count == 0)
            {
                numIDSC++;
                if (skore.Count == 0)
                {
                    mainWindow.dgViewList.ItemsSource = skore;
                }
                skore.Add(new Score() { ScoreId = numIDSC });
            }
            else
            {
                numIDSC = skore[skore.Count - 1].ScoreId;
                numIDSC++;
                if (skore.Count == 0)
                {
                    mainWindow.dgViewList.ItemsSource = skore;
                }
                skore.Add(new Score() { ScoreId = numIDSC });
            }
        }

        /// <summary>
        /// Метод для добавления в таблицу класса Deposit
        /// </summary>
        /// <param name="deposit">Сам класс</param>
        /// <param name="focus">Номер попордку</param>
        /// <param name="capitl">С капитализацией или без</param>
        /// <param name="addMonth">Число месяцев до выдачи</param>
        /// <param name="sumDep">Сумма на счету</param>
        public void AddToDgDeposit(ObservableCollection<Deposit> deposit,
            int focus,
            bool capitl,
            int addMonth,
            int sumDep,
            int prestige)
        {
            DateTime dateDeposit = DateTime.Now;
            dateDeposit.AddMonths(addMonth);
            mainWindow = new MainWindow();

            if (!capitl)
            {

                deposit.Add(new Deposit()
                {
                    Money = sumDep,
                    DateScore = dateDeposit,
                    DatePerCent = DateTime.Now.AddMonths(1),
                    ScoreId = focus,
                    TypeScore = 0,
                    Prestige = prestige,
                    EndDeadline = addMonth
                });
                if (deposit.Count == 0)
                {
                    mainWindow.dgViewList.ItemsSource = deposit;
                }
            }
            else
            {
                if (deposit.Count == 0)
                {
                    mainWindow.dgViewList.ItemsSource = deposit;
                }
                deposit.Add(new Deposit()
                {
                    ScoreId = focus,
                    Money = sumDep,
                    DateScore = dateDeposit,
                    TypeScore = 1,
                    GetPerCent = false,
                    DatePerCent = DateTime.Now.AddMonths(1),
                    Prestige = prestige,
                    EndDeadline = addMonth
                });
            }
        }

        public void RunThread()
        {
            for (int i = 0; i < deposits.Count; i++)
            {
                if (deposits[i].DateScore == mainWindow.dateTest)
                {
                    deposits[i].GetMoney = true;
                }
            }
            for (int i = 0; i < deposits.Count; i++)
            {
                if (deposits[i].DatePerCent == mainWindow.dateTest && deposits[i].TypeScore == 1)
                {
                    deposits[i].Money = deposits[i].Money + (deposits[i].Money
                        * (EntDeadline.deadline / 100));
                    deposits[i].DatePerCent.AddMonths(1);
                }
            }
        }

        /// <summary>
        /// Метод для добавления в таблицу класса Deposit
        /// </summary>
        /// <param name="deposit"></param>
        public void AddToDgCredit(ObservableCollection<Credit> credit,
            int focus,
            bool capitl,
            int addMonth,
            int sumDep,
            int prestige)
        {

            DateTime dateCredit = DateTime.Now;
            dateCredit.AddMonths(addMonth);
            mainWindow = new MainWindow();

            if (credit.Count == 0)
            {
                mainWindow.dgViewList.ItemsSource = credit;
            }
            credit.Add(new Credit()
            {
                ScoreId = focus,
                Money = sumDep,
                DateScore = dateCredit,
                TypeScore = 1,
                GetPerCent = false,
                DatePerCent = DateTime.Now.AddMonths(1),
                Prestige = prestige,
                EndDeadline = addMonth
            });
        }
    }
    #endregion
}