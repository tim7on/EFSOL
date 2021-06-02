using System;
using System.Collections;
/*Задание 2 
Создайте коллекцию, в которой бы хранились наименования 12 месяцев, порядковый номер и 
количество дней в соответствующем месяце. Реализуйте возможность выбора месяцев, как по 
порядковому номеру, так и количеству дней в месяце, при этом результатом может быть не 
только один месяц*/
namespace pro_1_2
{   
    class Calendar : IEnumerable, IEnumerator
    {
        string[] monthName = { "Январь","Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        int[] month = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        int[] day = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        int position = -1;
        public object Current
        {
            get { return month[position] + " - "+ monthName[position] + " - " + day[position]; }
        }

        public bool MoveNext()
        {
            if (position < month.Length - 1)
            {
                position++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public string GetMonthByDays(int days)
        {
            string result = "";
            for (int i = 0; i < month.Length; i++)
                if (days == day[i])
                {
                    result += month[i] + "-" + monthName[i] + "\t" + day[i] + " дней\n";
                }
            return result;
        }
        public string GetDaysInMonth(int monthInt)
        {
            string result = "";
                if (monthInt <= month.Length)
                {
                    --monthInt;
                    result = month[monthInt] + "-" + monthName[monthInt] + "\t" + day[monthInt] + " дней"; ;
                }
            return result;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Calendar calendar = new Calendar();
            foreach (var element in calendar)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine(new string('-', 5));
            Console.WriteLine(calendar.GetMonthByDays(31));

            Console.WriteLine(new string('-', 5));
            Console.WriteLine(calendar.GetDaysInMonth(10));
        }
    }
}
