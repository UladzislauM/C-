using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_12_переработка
{
    class Interfase_A
    {
        interface I1
        {
            void M();
        }

        interface I2
        {
            void M();
        }

        class A : I1, I2
        {
            public void M() { Console.WriteLine("A.M()"); }
        }

        class B : A, I1, I2
        {
            public new void M() { Console.WriteLine("A.M()"); }
        }
    }
}
