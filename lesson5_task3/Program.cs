using System;

namespace lesson5_task3
{
    /*
     * Задание 3 
    Имеется 3 переменные типа int x = 5, y = 10, и z = 15;
    Выполните и рассчитайте результат следующих операций для этих переменных: 
     x += y >> x++ * z; 
     z = ++x & y * 5; 
     y /= x + 5 | z; 
     z = x++ & y * 5; 
     x = y << x++ ^ z;
    */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n---------------\nПеременные\nЗадание 1\n");
            int x = 5, y = 10, z = 15;
            Console.WriteLine($"\nПеременные до решения: \n x={x}, \t y={y}, \t z={z}\n" +
                $"Решение для {x += y >> x++ * z} = x += y >> x++ * z\n" +
                $"Переменные: \n x={x}, \t y={y}, \t z={z}\n");
            Console.WriteLine($"\nПеременные до решения: \n x={x}, \t y={y}, \t z={z}\n" + 
                $"Решение для {z = ++x & y * 5} = z = ++x & y * 5\n" +
                $"Переменные: \n x={x}, \t y={y}, \t z={z}\n");
            Console.WriteLine($"\nПеременные до решения: \n x={x}, \t y={y}, \t z={z}\n" + 
                $"Решение для {y /= x + 5 | z} = y /= x + 5 | z\n" +
                $"Переменные: \n x={x}, \t y={y}, \t z={z}\n");
            Console.WriteLine($"\nПеременные до решения: \n x={x}, \t y={y}, \t z={z}\n" + 
                $"Решение для {z = x++ & y * 5} = z = x++ & y * 5\n" +
                $"Переменные: \n x={x}, \t y={y}, \t z={z}\n");
            Console.WriteLine($"\nПеременные до решения: \n x={x}, \t y={y}, \t z={z}\n" + 
                $"Решение для {x = y << x++ ^ z} = x = y << x++ ^ z\n" +
                $"Переменные: \n x={x}, \t y={y}, \t z={z}\n");
        }
    }
}
