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
            int vibor;
            Avto car_1 = new Avto();
            Avtobus car_2 = new Avtobus();
            Gr car_3 = new Gr();
            Console.WriteLine("Чем вы хотите управлять? 1 - Автобус, 2 - Грузовик");
            vibor = Convert.ToInt32(Console.ReadLine());
            if (vibor == 1)
            {
                car_2.Info(vibor);
                car_2.Challenge();
                car_2.Vivod_In();
            }
            else if (vibor == 2)
            {
                car_3.Info(vibor);
                car_3.Challenge();
                car_3.Vivod_Inf();
            }
        }
    }
}
