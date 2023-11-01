using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtobys_Gr
{
    internal class Gr : Avto
    {
        public override void Trip()
        {        
            do
            {
                Random random = new Random();
                road = random.Next(5, 300);
                Console.WriteLine($"Необходимо проехать: {road}");
                Ves_2();
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
                    Probeg();
                }
                Igra();
            } while (otvet_2 == "Да");
        }
        private void Ves_2()
        {
            if (ves_gr > 3000)
            {
                ves_gr = 5;
            }
            else if (ves_gr <= 3000 && ves_gr > 0)
            {
                ves_gr = 3;
            }
            else if (ves_gr == 0)
            {
                ves_gr = 1;
            }
        }
    }
}