using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtobys_Gr
{
    internal class Gr : Avtobus
    {
        public void Info()
        {
            Console.WriteLine("Чем вы хотите управлять? 1 - Автобус, 2 - Грузовик");
            vibor = Convert.ToInt32(Console.ReadLine());
            B();
            Console.Write("Введите расход на 100км: ");
            rasxod = float.Parse(Console.ReadLine());
            Console.Write("Введите с какой скоростью хотите ехать: ");
            speed = Convert.ToInt32(Console.ReadLine());
            if (vibor == 1)
            {
                Console.WriteLine("Укажите количество людей в автобусе: ");
                kol_p = Convert.ToInt32(Console.ReadLine());
                Challenge();
                Trip();
            }
            else if (vibor == 2)
            {
                Console.WriteLine("Укажите вес груза: ");
                ves_gr = Convert.ToInt32(Console.ReadLine());
                Challenge();
                Trip_2();
            }
        }
        protected void Trip_2()
        {
            do
            {
                Random random = new Random();
                road = random.Next(5, 300);
                Console.WriteLine($"Необходимо проехать: {road}");
                if (speed > 90)
                {
                    x = road * (rasxod * ves_gr) * 2 / 100;
                }
                else if (speed < 60)
                {
                    x = road * (rasxod * ves_gr) / 2 / 100;
                }
                else
                {
                    x = road * (rasxod * ves_gr) / 100;
                }
                Console.WriteLine($"Необходимо: {x} литров бензина");
                Vrem();
                if (x < kol_benz || x == kol_benz)
                {
                    Console.WriteLine("Вам хватает бензина");
                    kol_benz = kol_benz - x;
                    Ostatok();
                    Refill();
                    Mileage();
                }
                else if (x > kol_benz)
                {
                    itog = x - kol_benz;
                    Console.WriteLine($"Вам не хватает: {itog} литров бензина");
                    Refill();
                    if (otvet == "Да")
                    {
                        kol_benz = kol_benz - x;
                        Ostatok();
                        Mileage();
                    }
                }
                if (otvet == "Нет")
                {
                    kol_benz = 0;
                    Ostatok();
                    Mileage();
                }
                Igra();
            } while (otvet_2 == "Да");
        }
    }
}