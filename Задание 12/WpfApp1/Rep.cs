using Newtonsoft.Json;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
//using static WpfApp1.FullyOC;
//using java.security.cert;

namespace WpfApp1
{
    class Rep
    {
        public BindingList<Depart> departs = new BindingList<Depart>();
        public ObservableCollection<Employees> employees = new ObservableCollection<Employees>();

        #region Конструкторы

        /// <summary>
        /// Определение "Кастомного" Конструктора для добавления к Depart
        /// </summary>
        /// <param name="RealDeparts"></param>
        public void AddDep(Depart RealDeparts)
        {
           departs.Add(RealDeparts);
        }

        /// <summary>
        /// Определение "Кастомного" Конструктора для добавления к Employees
        /// </summary>
        /// <param name="RealEmployees"></param>
        public void AddEmpl(Employees RealEmployees)
        {
            employees.Add(RealEmployees);
        }


        private readonly string PuthJson1;
        private readonly string PuthJson2;

        /// <summary>
        /// Определение пути для файла
        /// </summary>
        /// <param name="puth1"></param>
        /// <param name="puth2"></param>
        public Rep (string puth1, string puth2)
        {
            PuthJson1 = puth1;
            PuthJson2 = puth2;
        }

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

        /// <summary>
        /// Дисериализация Конторы json и создание копии Рабочие
        /// </summary>
        public ObservableCollection<Employees> LoadDataEmpl()
        {
            var fileExist = File.Exists(PuthJson2);
            if (!fileExist)
            {
                File.CreateText(PuthJson2).Dispose();
                return new ObservableCollection<Employees>();
            }
            using (var reader = File.OpenText(PuthJson2))
            {
                File.Copy(PuthJson2, PuthJson2 + "copy", true);

                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<Employees>>(fileText);
            }

        }
        /// <summary>
        /// Дисериализация копии Конторы json Рабочие
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Employees> LoadDataEmplCopy()
        {
            var fileExist = File.Exists(PuthJson2 + "copy");
            if (!fileExist)
            {
                File.CreateText(PuthJson2).Dispose();
                return new ObservableCollection<Employees>();
            }
            using (var reader = File.OpenText(PuthJson2 + "copy"))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<Employees>>(fileText);
            }

        }

        /// <summary>
        /// Дисериализация Конторы json и создание копии Отделы
        /// </summary>

        public BindingList<Depart> LoadDataDep()
        {
            var fileExist = File.Exists(PuthJson1);
            if (!fileExist)
            {
                File.CreateText(PuthJson1).Dispose();
                return new BindingList<Depart>();
            }
            using (var reader = File.OpenText(PuthJson1))
            {
                File.Copy(PuthJson1, PuthJson1 + "copy", true);

                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Depart>>(fileText);
            }

        }
        /// <summary>
        /// Дисериализация копии Конторы json Отделы
        /// </summary>
        /// <returns></returns>
        public BindingList<Depart> LoadDataDepCopy()
        {
            var fileExist = File.Exists(PuthJson1 + "copy");
            if (!fileExist)
            {
                File.CreateText(PuthJson1).Dispose();
                return new BindingList<Depart>();
            }
            using (var reader = File.OpenText(PuthJson1 + "copy"))
            {
             
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Depart>>(fileText);
            }

        }
        #endregion
    }
}
