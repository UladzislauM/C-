using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_11
{
    class Bosses : Employees
    {
        public Bosses(string NameBoss, uint SalaryBoss, int IDBoss, string PostBoss)
        {
            this.FirstName = NameBoss;
            this.Salary = SalaryBoss;
            this.PeopleId = IDBoss;
            this.Post = PostBoss;
        }
        /// <summary>
        /// Конструктор по умолчанию (в данном случае только для сериализации xml)
        /// </summary>
        public Bosses()
        { }

       
    }

}
