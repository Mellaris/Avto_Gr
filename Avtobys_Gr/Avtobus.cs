using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Avtobys_Gr
{
    internal class Avtobus : Avto
    {
        public void Vivod_In()
        {
            Trip();
        }
        protected override void Trip()
        {
            do
            {
                Console.WriteLine("Укажите количество людей в автобусе: ");
                kol_p = Convert.ToInt32(Console.ReadLine());
                Random random = new Random();
                road = random.Next(5, 100);
                Console.WriteLine($"Необходимо проехать: {road}");
                Ves();
                Neobxodimo(ves_p);
                if (x > 100)
                {
                    Vrem();
                    Probeg();
                    while (road > 0)
                    {
                        Xvatit();
                        road = road - km;
                        if (road > 0)
                        {
                            Console.WriteLine($"Осталось проехать: {road}");
                            kol_benz = 0;
                            Neobxodimo(ves_p);
                            Refill();
                            x = x - kol_benz;
                        }                                             
                    }
                }
                else
                {
                    Vrem();
                    if (x < kol_benz || x == kol_benz)
                    {
                        Console.WriteLine("Вам хватает бензина");
                        kol_benz = kol_benz - x;
                        Ostatok();
                        Refill();
                        Probeg();
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
                            Probeg();
                        }
                    }
                    if (otvet == "Нет")
                    {
                        kol_benz = 0;
                        Ostatok();
                    }
                }
                Console.WriteLine($"Общий пробег: {counter}");
                Igra();
            } while (otvet_2 == "Да");
        }
    }
}