using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Avtobys_Gr
{
    internal class Avtobus : Avto
    {
        protected int road;
        protected float counter = 0;
        private int ves = 60;
        private int sum_ves;
        private int ves_p;
        protected float t;
        protected virtual void Trip()
        {
                do
                {
                    Random random = new Random();
                    road = random.Next(5, 100);
                    Console.WriteLine($"Необходимо проехать: {road}");
                    Ves();
                    if (speed > 90)
                    {
                        x = road * (rasxod * ves_p) * 2 / 100;
                    }
                    else if (speed < 60)
                    {
                        x = road * (rasxod * ves_p) / 2 / 100;
                    }
                    else
                    {
                        x = road * (rasxod * ves_p) / 100;
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
                    itog = x - kol_benz;
                    y = itog;
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
        protected void Mileage()
        {
            counter = counter + road;
            Console.WriteLine($"Общий пробег: {counter}");
        }
        private void Ves()
        {
            sum_ves = kol_p * ves;
            if (sum_ves > 1000)
            {
                ves_p = 4;
            }
            else if (sum_ves <= 1000 && sum_ves > 0)
            {
                ves_p = 2;
            }
            else if (sum_ves == 0)
            {
                ves_p = 0;
            }
        }
        protected virtual void Vrem()
        {
            float t = (float)(road / speed);
            t = t * 60;
            Console.WriteLine($"Необходимо: {t} минут");
        }
    }
}