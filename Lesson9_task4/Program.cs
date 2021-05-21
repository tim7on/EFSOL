using System;

namespace Lesson9_task4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Задание 4
Используя Visual Studio, создайте проект по шаблону ConsoleApplication.
Требуется:
            Создать метод, который будет выполнять увеличение длины массива переданного в качестве аргумента,
на 1 элемент. Элементы массива, должны сохранить свое значение и порядок индексов.
Создайте метод, который принимает два аргумента, первый аргумент - типа int [] array, второй
аргумент - типа int value. В теле метода реализуйте возможность добавления второго аргумента
метода в массив по индексу – 0, при этом длина нового массива, должна увеличиться на 1 элемент, а
элементы получаемого массива в качестве первого аргумента должны скопироваться в новый массив
начиная с индекса - 1.
            */
            int[] arr = { 0, 5, 6, 8, 7 };
            Console.WriteLine("\nначальный массив \"arr\"\n");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"позиция {i} \t число {arr[i]}");
            }

            ArrayExpand(arr, 5);

            static int ArrayExpand(int [] arr, int value)
            {
                int[] newarr = new int[arr.Length + 1];
                for (int i = 0; i < newarr.Length; i++)
                    {
                        if (i == 0)
                            {
                                newarr[0] = value;
                            }
                        else
                            {
                        newarr[i] = arr[i-1];
                    }
                    }
                Console.WriteLine("\nНовый массив \"newarr\"\n");
                for (int i = 0; i < newarr.Length; i++)
                {
                    Console.WriteLine($"позиция {i} \t число {newarr[i]}");
                }
                return 1;
            }
           
        }
    }
}
