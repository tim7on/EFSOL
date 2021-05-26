using System;
/*Задание 2 
Используя Visual Studio, создайте проект по шаблону Console Application. 
Создайте статический класс с методом void Print (string stroka, int color), который выводит на 
экран строку заданным цветом. Используя перечисление, создайте набор цветов, доступных 
пользователю. Ввод строки и выбор цвета предоставьте пользователю.*/
namespace basic_lesson8_2
{   static class MyClass{
        enum Colors //создание перечисления целого типа
        {
            Yellow = 0,
            Magenta = 1,
            DarkRed = 2,
            DarkCyan = 3,

        }
        public static void Print(string stroka, int color)
        {
            switch (color)
            {
                case (int)Colors.Yellow:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case (int)Colors.Magenta:
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                case (int)Colors.DarkRed:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case (int)Colors.DarkCyan:
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    break;
                default:
                    Console.WriteLine("Default");
                    break;
            }
            Console.WriteLine(stroka);
            Console.ResetColor();


        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose color for your text 0-Yellow, 1-Magenta, 2-DarkRed, 3-DarkCyan");
            int color = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input your text");
            string stroka = Console.ReadLine();
            MyClass.Print(stroka, color);
        }
    }
}
