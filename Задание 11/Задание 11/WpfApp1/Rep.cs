using Newtonsoft.Json;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
//using java.security.cert;

namespace WpfApp1
{
   class Rep
    {
        public BindingList<Depart> departs = new BindingList<Depart>();
       public BindingList<Employees> employees = new BindingList<Employees>();
      

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
        private readonly string PuthJson;
        public Rep (string puth)
        {
            PuthJson = puth;
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
        public void SaveData(object todoDataList)
        {
            using (StreamWriter writer = File.CreateText(PuthJson))
            {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }
           
        }

        /// <summary>
        /// Дисериализация Конторы json
        /// </summary>
        public BindingList<Employees> LoadDataEmpl()
        {
            var fileExist = File.Exists(PuthJson);
            if(!fileExist)
            {
                File.CreateText(PuthJson).Dispose();
                return new BindingList<Employees>();
            }
            using (var reader = File.OpenText(PuthJson))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Employees>>(fileText);
            }
                    
        }

        /// <summary>
        /// Дисериализация Конторы json
        /// </summary>
        public BindingList<Depart> LoadDataDep()
        {
            var fileExist = File.Exists(PuthJson);
            if (!fileExist)
            {
                File.CreateText(PuthJson).Dispose();
                return new BindingList<Depart>();
            }
            using (var reader = File.OpenText(PuthJson))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Depart>>(fileText);
            }

        }
        #endregion
    }
}
