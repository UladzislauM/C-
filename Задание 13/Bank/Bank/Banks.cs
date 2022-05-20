using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Banks<T>
    {


        private ObservableCollection<T> normPeople;
        private ObservableCollection<T> vipPeople;
        private ObservableCollection<T> corpPeople;


        public Banks(ObservableCollection<T> NormPeople, ObservableCollection<T> VIPPiple, ObservableCollection<T> CorpPeople)
        {
           this.normPeople = NormPeople;
            this.vipPeople = VIPPiple;
            this.corpPeople = CorpPeople;
        }
        public Banks()
            {}
            

        public ObservableCollection<T> NormPeople { get;  set; }
        public ObservableCollection<T> VIPPeople { get; set; }
        public ObservableCollection<T> CorpPeople { get; set; }
    }
}
