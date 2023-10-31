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
                    road = random.Next(5, 100);
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
                        otvet = "Да";
                        Refill();
                        Mileage();
                    }
                if (x > kol_benz)
                {
                    do
                    {
                            itog = x - kol_benz;
                            Console.WriteLine($"Вам не хватает: {itog} литров бензина");
                            Refill();
                            y = itog;
                            if (y < kol_benz)
                            {
                                Mileage();
                            }
                            if (otvet == "Нет")
                            {
                                break;
                            }
                        
                    } while (y >= kol_benz);
                    kol_benz = kol_benz - x;
                }    
                    
                } while (otvet == "Да");           
        }
    }
}