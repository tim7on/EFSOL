using System;

namespace lesson7_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Задание 2
Используя Visual Studio, создайте проект по шаблону Console Application.
Создайте четыре метода для выполнения арифметических операций, с именами: Add – сложение, Sub –
вычитание, Mul – умножение, Div – деление. Каждый метод должен принимать два целочисленных
аргумента и выводить на экран результат выполнения арифметической операции соответствующей
имени метода. Метод деления Div, должен выполнять проверку попытки деления на ноль.
Требуется предоставить пользователю возможность вводить с клавиатуры значения операндов и знак
арифметической операции, для выполнения вычислений.*/
            Console.WriteLine("Введите первое число.");
            double num1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите Второе число.");
            double num2 = double.Parse(Console.ReadLine());
            Start:
                Console.WriteLine("Выберите действие: +, -, /, *");
                char sign = char.Parse(Console.ReadLine());
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
                    res = num1 - num2;
                }
                else
                {
                    Console.WriteLine("Не возмжно поделить на ноль");
                }
                return  res;
            }
            static double Mul(double num1, double num2)
            {
                return num1 * num2;
            }

        }
    }
}
