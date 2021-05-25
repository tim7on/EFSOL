using System;
/*Задание 2
Используя Visual Studio, создайте проект по шаблону Console Application. 
Требуется: Описать структуру с именем Train, содержащую следующие поля: название пункта 
назначения, номер поезда, время отправления. 
Написать программу, выполняющую следующие действия:
-ввод с клавиатуры данных в массив, состоящий из восьми элементов типа Train (записи должны быть 
упорядочены по номерам поездов);
-вывод на экран информации о поезде, номер которого введен с клавиатуры (если таких поездов нет,
вывести соответствующее сообщение).*/

namespace basic_lesson7_2
{
    struct Train
    {
        private string destination;
        private int number;
        private DateTime despatch;

        public Train(string destination, int number, DateTime despatch)
        {
            this.destination = destination;
            this.number = number;
            this.despatch = despatch;
        }
        public string Destination
        {
            get { return destination; }
        }
        public int Number
        {
            get { return number; }
        }
        public DateTime Despatch
        {
            get { return despatch; }
        }
    }
    class TrainClass
    {
        static void Sort(Train[] trains)
        {
            Array.Sort(trains, (x, y) => x.Number.CompareTo(y.Number));
        }
        public static void AddTrainArray(Train[] trains)
        {
            for (int i = 0; i < trains.Length; i++)
            {
                Console.WriteLine("Введите Пункт назначения");
                string destination = Console.ReadLine();
                Console.WriteLine("Введите номер поезда");
                int number = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите время отправки");
                string d = Console.ReadLine();
                DateTime despatch = string.IsNullOrEmpty(d) ? DateTime.Now.AddHours(1) : DateTime.Parse(d);
                trains[i] = new Train(destination, number, despatch);
            }

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var newTrains = new Train[2];
            TrainClass.AddTrainArray(newTrains);
        }
    }
}
