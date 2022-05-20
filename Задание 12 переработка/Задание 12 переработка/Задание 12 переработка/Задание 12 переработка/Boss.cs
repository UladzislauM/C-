using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_12_переработка
{
    class Boss : Worker
    {
        public Boss(string NameBoss, uint SalaryBoss, string IDBoss, string PostBoss)
        {
            this.FirstName = NameBoss;
            this.Salary = SalaryBoss;
            this.PeopleId = IDBoss;
            this.Post = PostBoss;
        }
        /// <summary>
        /// Конструктор по умолчанию (в данном случае только для сериализации xml)
        /// </summary>
        public Boss()
        { }
    }
}
