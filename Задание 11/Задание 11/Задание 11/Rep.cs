using Newtonsoft.Json;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using java.security.cert;

namespace Task_11
{
   class Rep
    {
        //public List<BaseCont> baseConts = new List<BaseCont>();
        public List<Depart> departs = new List<Depart>(); //Коллекция с данными 
        public List<Employees> employees = new List<Employees>();


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

        ///// <summary>
        ///// Определение "Кастомного" Конструктора для Depart
        ///// </summary>
        ///// <returns></returns>
        //public List<Depart> PrintDepRep()
        //{
        //    return departs;

        //}

        ///// <summary>
        ///// Определение "Кастомного" Конструктора для Employees
        ///// </summary>
        ///// <returns></returns>
        //public List<Employees> PrintEmplRep()
        //{
        //    return employees;
        //}

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
        public void SerialJson(int NumSerial, string PuthJson)
        {
            

            string json = "";
            if (NumSerial == 1)
                json = JsonConvert.SerializeObject(departs);
            if (NumSerial == 2)
                json = JsonConvert.SerializeObject(employees);



            File.WriteAllText($@"{PuthJson}", json);
        }

        /// <summary>
        /// Дисериализация Конторы json
        /// </summary>
        public void DeSerialJson(int NumDeSerial, string PuthJson)
        {

            string json = File.ReadAllText($@"{PuthJson}");

            if (NumDeSerial == 1)
                departs = JsonConvert.DeserializeObject<List<Depart>>(json);
            if (NumDeSerial == 2)
                employees = JsonConvert.DeserializeObject<List<Employees>>(json);

        }

        #endregion
    }
}
