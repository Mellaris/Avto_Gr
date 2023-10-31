using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtobys_Gr
{
    internal class Avto
    {
        protected int vibor;
        protected float kol_benz;
        protected float rasxod;
        protected float speed;
        protected int kol_p;
        protected int ves_gr;
        protected string otvet = "";
        protected int benz = 0;
        protected float itog = 0;
        protected float x;
        protected float y;
        protected float km;
        protected float ostatok;
        public void Challenge()
        {
            Console.WriteLine($"Номер вашего авто: {vibor}; Количество бензина: {kol_benz}; Расход на 100км: {rasxod}; Ваша скорость: {speed}");
        }
        protected void B()
        {
            Console.Write("Укажите сколько хотите добавить литров бензина: ");
            benz = Convert.ToInt32(Console.ReadLine());
            kol_benz = kol_benz + benz;
            if (kol_benz > 100)
            {
                Console.WriteLine("Не может быть больше 100 литров. Попробуйте еще раз");
                kol_benz = kol_benz - benz;
                B();
            }
        }
        protected void Refill()
        {
            Console.WriteLine("Хотите заправить машину?");
            Console.WriteLine("Напишите ниже: 'Да' или 'Нет'.");
            otvet = Console.ReadLine();
            if (otvet == "Да")
            {
                B();
                if (kol_benz < 100)
                {
                    Console.WriteLine($"Количество вашего бензина: {kol_benz}");
                    if (x > kol_benz)
                    {
                        if (benz < itog)
                        {
                            itog = itog - benz;
                        }
                        else
                        {
                            y = itog - benz;
                            kol_benz = kol_benz - x;
                            Ostatok();
                        }
                    }        
                }
                Console.Clear();
            }
            else if (otvet == "Нет")
            {
                km = rasxod / 100;
                km = km * kol_benz;
                Console.WriteLine($"Вам хватит на {km} km");
                Ostatok();
            }
        }
        protected void Ostatok()
        {
            ostatok = kol_benz;
            Console.WriteLine($"У вас осталось: {ostatok} литров бензина");
        }
    }  
}