using Newtonsoft.Json;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using java.security.cert;

namespace Задание_8
{
   public class Rep
    {
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

        /// <summary>
        /// Определение "Кастомного" Конструктора для Depart
        /// </summary>
        /// <returns></returns>
        public List<Depart> PrintDepRep()
        {
            return departs;

        }

        /// <summary>
        /// Определение "Кастомного" Конструктора для Employees
        /// </summary>
        /// <returns></returns>
        public List<Employees> PrintEmplRep()
        {
            return employees;
        }

        /// <summary>
        /// Определение конструктора по умолчанию
        /// </summary>
        public Rep()
        { }
        #endregion

        #region Методы
        /// <summary>
        /// Создание и заподнение Конторы
        /// </summary>
        /// <param name="rasEmpl"></param>
        public void ContoreCreate(int rasEmpl)
        {
            Random rand = new Random();
            int numOfNumber = 1;
            for (int j = 0; j < rasEmpl; j++)
            {
                int numOfName = rand.Next(1, rasEmpl);
                int numOfLastName = rand.Next(1, rasEmpl);
                int numOfAge = rand.Next(18, 58);
                
                uint salar = Convert.ToUInt16(rand.Next(250, 900));
                uint numOfWork = Convert.ToUInt16(rand.Next(1, 20));
                int peopleID = rand.Next(0, rasEmpl);
                string daTa = DateTime.Now.ToString("dd,MM|HH:mm");


                AddEmpl(
                  new Employees(
                $"Имя_{numOfName}",
                $"Фамилия_{numOfLastName}",
                $"{numOfAge}",
                salar,
                numOfNumber,
                numOfWork,
                peopleID));
                AddDep(
            new Depart(
            $"Отдел_{peopleID}",
            $"{daTa}",
            peopleID));

                numOfNumber++;
            }
        }

        /// <summary>
        /// Добавить новую строку к существующей Конторе
        /// </summary>
        public void ContoraAdd(string FName, string LName, int AgeEmpl, uint Sal, uint Work, int NumOfNumber, int IDpeople, string Data)
        {
                AddEmpl(
                new Employees(
                $"{FName}",
                $"{LName}",
                $"{AgeEmpl}",
                Sal,
                NumOfNumber,
                Work,
                IDpeople));
                AddDep(
            new Depart(
            $"Отдел_{IDpeople}",
            $"{Data}",
            IDpeople));
            
        }

        /// <summary>
        /// Редактирует Контору
        /// </summary>
        public void ContoraRed(int NumChoice , int NumRem, string RepL1, string RepL2)
        {
            

            if (NumChoice == 1)
            {
                string stringDep = departs[NumRem].PrintDep().Replace($"{RepL1}", $"{RepL2}");
                string[] stringDepArr = stringDep.Split("\t");

                departs[NumRem].NameDep = stringDepArr[1];
                departs[NumRem].DateDep = stringDepArr[2];
            }
            if (NumChoice == 2)
            {
                
                string stringEmpl = employees[NumRem].PrintEmpl().Replace($"{RepL1}", $"{RepL2}");
                string[] stringEmplArr = stringEmpl.Split("\t");

                employees[NumRem].FirstName = stringEmplArr[1];
                employees[NumRem].LastName = stringEmplArr[2];
                employees[NumRem].Age = stringEmplArr[3];
                employees[NumRem].Number = int.Parse(stringEmplArr[4]);
                employees[NumRem].Salary = uint.Parse(stringEmplArr[5]);
                employees[NumRem].NumOfWorkers = uint.Parse(stringEmplArr[6]);
            }
        }

        /// <summary>
        /// Сортирует Контору Сотрудник
        /// </summary>
        public IOrderedEnumerable<Employees> ContoraSort(int NumSort)
        {
                if (NumSort == 1)
                {
                  var  sortedNameDep = employees.OrderBy(y => y.Age).ThenBy(y => y.Number);

                return sortedNameDep;
                }
               
                if (NumSort == 2)
                {
                   var sortedNameDep = employees.OrderBy(y => y.FirstName).ThenBy(y => y.Salary);

                return sortedNameDep;
                }
               
                if (NumSort == 3)
                {
                  var sortedNameDep = employees.OrderBy(y => y.LastName).ThenBy(y => y.Age);

                return sortedNameDep;
                }
              
                if (NumSort == 4)
                {
                  var sortedNameDep = employees.OrderBy(y => y.LastName).ThenBy(y => y.NumOfWorkers);

                return sortedNameDep;
                }

            var SortedNameDep = employees.OrderBy(y => y.LastName).ThenBy(y => y.NumOfWorkers);
            return SortedNameDep;
           

        }

        /// <summary>
        /// Сортировка Конторы Отдел
        /// </summary>
        /// <returns></returns>
        public IOrderedEnumerable<Depart> ContoraSort()
        {
                var soRtedNameDep = departs.OrderBy(y => y.NameDep).ThenBy(y => y.DateDep);

            return soRtedNameDep;
        }

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


        /// <summary>
        /// Сериализация Конторы xml
        /// </summary>
        public void Serialxml(string PuthXml, int NumSerial)
        {
            using (Stream fstream = new FileStream(PuthXml, FileMode.Create, FileAccess.Write))
            {
                if (NumSerial == 1)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Depart>));
                    xmlSerializer.Serialize(fstream, departs);
                }
                if (NumSerial == 2)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employees>));
                    xmlSerializer.Serialize(fstream, employees);
                }
            }
        }

        /// <summary>
        /// Дисериализация Конторыxml
        /// </summary>
        public void DeSerialxml(string PuthXml, int NumDeSerial)
        {
           
            using (Stream fstream = new FileStream(PuthXml, FileMode.Open, FileAccess.Read))
            //using (Stream fstream = new FileStream($@"{puthXml2}", FileMode.Open, FileAccess.Read))
            {
                if (NumDeSerial == 1)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Depart>));
                    departs = xmlSerializer.Deserialize(fstream) as List<Depart>;
                }
                if (NumDeSerial == 2)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employees>));
                    employees = xmlSerializer.Deserialize(fstream) as List<Employees>;
                }
            }
        }

        #endregion
    }
}
