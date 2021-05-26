using System;
/*Задание 3
Используя Visual Studio, создайте проект по шаблону Console Application. 
Создайте анонимный метод, который принимает в качестве аргумента массив делегатов и возвращает 
среднее арифметическое возвращаемых значений методов, сообщенных с делегатами в массиве. 
Методы, сообщенные с делегатами из массива, возвращают случайное значение типа int.*/
namespace basic_lesson9_3
{
    public delegate int MyDelegate();
    public delegate int InputDelegate(MyDelegate [] x);
    class Program
    {
        static int Rand()
        {
            Random rnd = new Random();
            return rnd.Next(1, 99);
        }
        static void Main(string[] args)
        {
            MyDelegate [] del1 = new MyDelegate[5]; // Массив делегатов
            for (int i = 0; i < del1.Length; i++) // Рандомные числа функций делегата
            {
                del1[i] = Rand;
            }
            InputDelegate average = (x) => 
            {
                int result = 0;
                for (int i = 0; i< x.Length; i++)
                {
                    int number = x[i](); // Чтоб при очередном вызове x[i]() не создавалось другое рандомное число
                    Console.WriteLine($"Delegate №{i+1}: {number}");
                    Console.WriteLine(new string('*', 25));
                    result += number;
                    
                }
                Console.WriteLine($"Sum of Delegate: {result}") ;
                Console.WriteLine(new string('*', 25));
                result /= x.Length;
                return result;
            };
            ;
            Console.WriteLine($"Result of average {average(del1)}");
        }
    }
}
