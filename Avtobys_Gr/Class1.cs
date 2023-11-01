using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        protected string otvet_2 = "";
        protected int benz = 0;
        protected float itog = 0;
        protected float x;
        protected float y;
        protected float km;
        protected float ostatok;
        protected int road;
        protected float counter = 0;
        protected float hepl;
        public void Info()
        {
            Console.WriteLine("Чем вы хотите управлять? 1 - Автобус, 2 - Грузовик");
            vibor = Convert.ToInt32(Console.ReadLine());
            Benz();
            Console.Write("Введите расход на 100км: ");
            rasxod = float.Parse(Console.ReadLine());
            Console.Write("Введите с какой скоростью хотите ехать: ");
            speed = Convert.ToInt32(Console.ReadLine());
            if (vibor == 1)
            {
                Console.WriteLine("Укажите количество людей в автобусе: ");
                kol_p = Convert.ToInt32(Console.ReadLine());
                Challenge();
            }
            else if (vibor == 2)
            {
                Console.WriteLine("Укажите вес груза: ");
                ves_gr = Convert.ToInt32(Console.ReadLine());
                Challenge();
            }
        }
        protected void Igra()
        {
            Console.WriteLine("Вы хотите продолжить путь?");
            Console.WriteLine("Напишите ниже: 'Да' или 'Нет'.");
            otvet_2 = Console.ReadLine();
        }
        public void Challenge()
        {
            Console.WriteLine($"Номер вашего авто: {vibor}; Количество бензина: {kol_benz}; Расход на 100км: {rasxod}; Ваша скорость: {speed}");
        }
        public void Benz()
        {
            Console.Write("Укажите сколько хотите добавить литров бензина: ");
            benz = Convert.ToInt32(Console.ReadLine());
            kol_benz = kol_benz + benz;
            if (kol_benz > 100)
            {
                Console.WriteLine("Не может быть больше 100 литров. Попробуйте еще раз");
                kol_benz = kol_benz - benz;
                Benz();
            }
        }
        protected void Refill()
        {
            Console.WriteLine("Хотите заправить машину?");
            Console.WriteLine("Напишите ниже: 'Да' или 'Нет'.");
            otvet = Console.ReadLine();
            if (otvet == "Да")
            {
                Benz();
                if (kol_benz < 100)
                {
                    if (x < kol_benz || x == kol_benz)
                    {
                        Console.WriteLine("Вам хватает бензина");                    
                    }
                }
            }
            else if (otvet == "Нет")
            {
                km = 100 / rasxod;
                km = km * kol_benz;
                Console.WriteLine($"Вам хватит на {km} km");
            }
        }
        protected void Probeg()
        {
            if (otvet == "Нет")
            {
                counter = counter + km;
            }
            if (kol_benz > 0)
            {
                counter = counter + road;
            }    
            Console.WriteLine($"Общий пробег: {counter}");
        }
        protected void Ostatok()
        {
            ostatok = kol_benz;
            Console.WriteLine($"У вас осталось: {ostatok} литров бензина");
        }
        protected void Vrem()
        {
            float t = (float)(road / speed);
            t = t * 60;
            Console.WriteLine($"Необходимо: {t} минут");
        }
        public virtual void Trip()
        {
            do
            {
                Random random = new Random();
                road = random.Next(5, 300);
                Console.WriteLine($"Необходимо проехать: {road}");
                if (speed > 90)
                {
                    x = road * rasxod * 2 / 100;
                }
                else if (speed < 60)
                {
                    x = road * rasxod / 2 / 100;
                }
                else
                {
                    x = road * rasxod / 100;
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
    }  
}