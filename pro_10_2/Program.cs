using System;
using System.Collections.Generic;
/*Задание 2 
Выучите описание шаблона Template method (Шаблонный метод). Обратите внимание на 
применимость шаблона, а также на состав его участников и связи отношения между ними. 
Напишите небольшую программу на языке C#, представляющую собой абстрактную 
реализацию данного шаблона.*/
namespace pro_10_2
{
    abstract class Human
    {
        public void SomeMethods()
        {
            Health();
            Streight();
            Speed();
        }


        public virtual void Health() { Console.Write("\n5/10\t"); }
        public virtual void Streight() { Console.Write("5/10\t"); }
        public virtual void Speed() { Console.Write("5/10"); }
    }
    class Mutant : Human
    {
        public override void Health() { Console.Write("\n8/10\t"); }
        public override void Speed()  { Console.Write("7/10\t"); }
    }
    class Cyborg : Human
    {
        public override void Health() { Console.Write("\n10/10\t"); }
        public override void Streight() { Console.Write("10/10\t"); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Human> humen = new List<Human> { new Mutant(), new Cyborg() };
            foreach (var item in humen)
            {
                item.SomeMethods();
            }
        }
    }
}
