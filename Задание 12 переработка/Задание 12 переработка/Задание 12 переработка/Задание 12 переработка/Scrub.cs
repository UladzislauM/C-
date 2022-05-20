using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_12_переработка
{
    class Scrub : Worker
    {
        public Scrub(string NameScr, uint SalaryScr, string IDScr, string PostScrubs)
        {
            this.FirstName = NameScr;
            this.Salary = SalaryScr;
            this.PeopleId = IDScr;
            this.Post = PostScrubs;
        }
        /// <summary>
        /// Конструктор по умолчанию (в данном случае только для сериализации xml)
        /// </summary>
        public Scrub()
        { }
    }
}
