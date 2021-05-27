using System;
/*Задание 2
Используя Visual Studio, создайте проект по шаблону Console Application.
Создайте четыре метода для выполнения арифметических операций, с именами: Add – сложение, Sub –
вычитание, Mul – умножение, Div – деление. Каждый метод должен принимать два целочисленных
аргумента и выводить на экран результат выполнения арифметической операции соответствующей
имени метода. Метод деления Div, должен выполнять проверку попытки деления на ноль.
Требуется предоставить пользователю возможность вводить с клавиатуры значения операндов и знак
арифметической операции, для выполнения вычислений.*/
namespace Lesson7_task2
{
    class Program
    {
        
        static void Main(string[] args)
        {
        Numbers:
            Console.WriteLine("Введите первое число.");
            bool numcheck = double.TryParse(Console.ReadLine(), out double num1);
            Console.WriteLine("Введите Второе число.");
            numcheck = double.TryParse(Console.ReadLine(), out double num2);
            if (numcheck)
            {
                goto Start;
            }
            else
            {
                Console.WriteLine("Ошибка при вводе числа");
                goto Numbers;
            }
        Start:
            Console.WriteLine("Выберите действие: +, -, /, *");
            char sign = char.Parse(Console.ReadLine().Trim());
            double result = 0;
            if (sign == '+')
            {
                result = Add(num1, num2);
            }
            else if (sign == '-')
            {
                result = Sub(num1, num2);
            }
            else if (sign == '/')
            {
                result = Div(num1, num2);
            }
            else if (sign == '*')
            {
                result = Mul(num1, num2);
            }
            else
            {
                Console.WriteLine("Выбран неверный знак");
                goto Start;
            }

            Console.WriteLine($"Результат действий {result}");


            static double Add(double num1, double num2)
            {
                return num1 + num2;
            }
            static double Sub(double num1, double num2)
            {
                return num1 - num2;
            }
            static double Div(double num1, double num2)
            {
                double res = 0;
                if (num2 != 0)
                {
                    res = num1 / num2;
                }
                else
                {
                    Console.WriteLine("Невозможно поделить на ноль");
                }
                return res;
            }
            static double Mul(double num1, double num2)
            {
                return num1 * num2;
            }

        }
    }
}
