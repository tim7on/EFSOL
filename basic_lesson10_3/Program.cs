using System;
using System.Linq;

/*Задание 3 
Используя Visual Studio, создайте проект по шаблону Console Application. 
Создайте класс MyDictionary<TKey,TValue>. Реализуйте в простейшем приближении возможность 
использования его экземпляра аналогично экземпляру класса Dictionary (Урок 6 пример 5). 
Минимально требуемый интерфейс взаимодействия с экземпляром, должен включать метод 
добавления пар элементов, индексатор для получения значения элемента по указанному индексу и 
свойство только для чтения для получения общего количества пар элементов.*/
namespace basic_lesson10_3
{

    class MyDictionary<TKey, TValue>
    {

        private readonly TKey[] key;
        private readonly TValue[] value;
        private readonly int lenght;

        public int Lenght
        {
            get
            {
                return lenght;
            }
        }

        public MyDictionary(int i)
        {
            key = new TKey[i];
            value = new TValue[i];
            lenght = i;
        }

        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < key.Length)
                    return key[index] + " - " + value[index]; 
                return "Попытка обращения за пределы массива.";
            }
        }
        public string this[TKey index]
        {

            get
            {
                for (int i = 0; i < Lenght; i++)
                    if ($"{index}" == $"{key[i]}")
                    {
                        string obj = key[i] + " - " + value[i];
                        return obj;
                    }
                return "Нет";
            }
            set
            {
                for (int i = 0; i < Lenght; i++)
                    if ($"{index}" == $"{key[i]}")
                    {
                        TValue obj = (TValue)Convert.ChangeType(value, typeof(TValue));
                        Add(obj, i);
                    }
            }
        }
        private void Add(TValue k, int i)
        {
            value[i] = k;
        }
        public void Add(int i, TKey k, TValue v)
        {
            key[i] = k;
            value[i] = v;
        }


    }
    class Program
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input lenght of Dictionary:");
            int n = int.Parse(Console.ReadLine());
            var dictionary = new MyDictionary<string, string>(n);
            for(int i = 0; i < n; i++)
            {
                dictionary.Add(i,RandomString(4) , RandomString(5));
                Console.Write($"Element #{i} is {dictionary[i]}\n");
            }
            Console.WriteLine(new string('*', 25));
            Console.WriteLine("Elements in dictionary: {0}",dictionary.Lenght);
            Console.WriteLine(new string('*', 25));
            Console.WriteLine("input ID of element to show");
            Console.WriteLine(new string('-', 25));
            string k = Console.ReadLine();
            /*if (k<= dictionary.Lenght)*/
            {
                Console.WriteLine(new string('*', 25));
                Console.WriteLine($"Element #{k} is {dictionary[k]}");
                Console.WriteLine(new string('*', 25));
            }
        }
    }
}
