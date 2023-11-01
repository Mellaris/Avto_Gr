﻿using System;
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
        private int ves = 60;
        private int sum_ves;
        private int ves_p;
        public override void Trip()
        {
            do
            {
                Random random = new Random();
                road = random.Next(5, 300);
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
                ves_p = 1;
            }
        }
    }
}