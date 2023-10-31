using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtobys_Gr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Avto car_1 = new Avto();
            Avtobus car_2 = new Avtobus();
            Gr car_3 = new Gr();
            car_3.Info();
        }
    }
}
