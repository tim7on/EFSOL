using System;
/*Задание 3 
Создайте класс MyClass и структуру MyStruct, которые содержат в себе поля public string change. 
В классе Program создайте два метода: 
- static void ClassTaker(MyClass myClass), который присваивает полю change экземпляра 
myClass значение «изменено». 
- static void StruktTaker(MyStruct myStruct), который присваивает полю change экземпляра 
myStruct значение «изменено». 
Продемонстрируйте разницу в использовании классов и структур, создав в методе Main() экземпляры 
структуры и класса. Измените, значения полей экземпляров на «не изменено», а затем вызовите методы 
ClassTaker и StruktTaker. Выведите на экран значения полей экземпляров. Проанализируйте 
полученные результаты.*/
namespace basic_lesson7_3
{
    class MyClass
    {
        public string change;
    }
    struct MyStruct
    {
        public string change;
    }
    class Program
    {
        static void ClassTaker(MyClass myClass)
        {
            myClass.change = "Измененно";
        }
        static void StruktTaker(MyStruct myStruct)
        {
            myStruct.change = "Измененно";
        }
        static void Main(string[] args)
        {
            MyClass newClass = new MyClass();
            newClass.change = "Не измененно";    
            ClassTaker(newClass);
            Console.WriteLine($"After ClassTaker(newClass) \n{newClass.change}");

            Console.WriteLine(new string('-', 35));
            var newStruct = new MyStruct();
            newStruct.change = "Не измененно";
            StruktTaker(newStruct);
            Console.WriteLine($"After StruktTaker(newStruct) \n{newStruct.change}");

        }
    }
}
