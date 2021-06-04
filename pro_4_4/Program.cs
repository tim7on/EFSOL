using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
/*Задание 4 
Создайте текстовый файл-чек по типу «Наименование товара – 0.00 (цена) грн.» с 
определенным количеством наименований товаров и датой совершения покупки. Выведите на 
экран информацию из чека в формате текущей локали пользователя и в формате локали enUS
 */
namespace pro_4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = File.ReadAllText("products.txt", Encoding.Default);

            DateTime date = DateTime.Now;
            var american = new CultureInfo("en-US");
            var russian = new CultureInfo("ru-RU");
            string lines = new string('-', 5);
            Console.WriteLine("FILE");
            Console.WriteLine(lines);
            Console.WriteLine(sentence);
            string moneyPattern = @"([0-9]+[\.\,][0-9]+)|([0-9]+)";

            string sentenceMy = Regex.Replace(sentence, moneyPattern, (m) => double.Parse(m.Value.Replace('.', ',')).ToString("C", russian));
            string localData = date.ToString("d", russian);
            sentenceMy += $"\nDate: {localData}";
            
            string sentenceUs = Regex.Replace(sentence, moneyPattern, (m) => double.Parse(m.Value.Replace('.', ',')).ToString("C", american));
            localData = date.ToString("d", american);
            sentenceUs += $"\nDate: {localData}";
            
            Console.WriteLine(lines);
            Console.WriteLine("LOCAL locale");
            Console.WriteLine(sentenceMy);
            Console.WriteLine(lines);
            
            Console.WriteLine("LOCAL USA");
            Console.WriteLine(sentenceUs);
            Console.WriteLine(lines);


        }
    }
}
