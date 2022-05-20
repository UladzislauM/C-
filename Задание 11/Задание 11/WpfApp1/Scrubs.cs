using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Scrubs : Employees
    {
        public Scrubs(string NameScr, uint SalaryScr, int IDScr, string PostScrubs)
        {
            this.FirstName = NameScr;
            this.Salary = SalaryScr;
            this.PeopleId = IDScr;
            this.Post = PostScrubs;
        }
        /// <summary>
        /// Конструктор по умолчанию (в данном случае только для сериализации xml)
        /// </summary>
        public Scrubs()
        { }
    }
}
