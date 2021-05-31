using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/*Задание 3 
Используя Visual Studio, создайте проект по шаблону Console Application. 
Создайте коллекцию MyDictionary<TKey,TValue>. Реализуйте в простейшем приближении 
возможность использования ее экземпляра аналогично экземпляру класса Dictionary<TKey,TValue>. 
Минимально требуемый интерфейс взаимодействия с экземпляром, должен включать метод 
добавления элемента, индексатор для получения значения элемента по указанному индексу и свойство 
только для чтения для получения общего количества элементов. Реализуйте возможность перебора 
элементов коллекции в цикле foreach.*/
namespace basic_lesson14_3
{
    class MyDictionary<TKey, TValue> : IEnumerable<object>, IEnumerator<object>
    {

        private readonly TKey[] key;
        private readonly TValue[] value;
        private readonly int lenght;
        int position = -1;


        
        public bool MoveNext()
        {
            if (position < key.Length - 1)
            {
                position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get { return key[position] + " " + value[position]; }
        }
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
        public void Add(int i, TKey k, TValue v)
        {
            key[i] = k;
            value[i] = v;
        }
        public IEnumerator<object> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public void Dispose()
        {
            Reset();
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
            var dictionaries = new MyDictionary<string, string>(n);
            for (int i = 0; i < n; i++)
            {
                dictionaries.Add(i, RandomString(4), RandomString(5));
                Console.Write($"Element #{i} is {dictionaries[i]}\n");
            }
            Console.WriteLine(new string('*', 25));
            Console.WriteLine("Elements in dictionary: {0}", dictionaries.Lenght);
            Console.WriteLine(new string('*', 25));
            Console.WriteLine("input ID of element to show");
            Console.WriteLine(new string('-', 25));
            int k = int.Parse(Console.ReadLine());
            if (k <= dictionaries.Lenght)
            {
                Console.WriteLine(new string('*', 25));
                Console.WriteLine($"Element #{k} is {dictionaries[k]}");
                Console.WriteLine(new string('*', 25));
            }
            foreach (var dict in dictionaries)
            {
                Console.WriteLine(dict);
            }
        }
    }
}
