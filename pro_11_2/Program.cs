using System;
using System.IO;
using System.Threading;
using System.Text;
/*Задание 2 
Создайте консольное приложение, которое в различных потоках сможет получить доступ к 2-м 
файлам. Считайте из этих файлов содержимое и попытайтесь записать полученную 
информацию в третий файл. Чтение/запись должны осуществляться одновременно в каждом 
из дочерних потоков. Используйте блокировку потоков для того, чтобы добиться корректной 
записи в конечный файл. */
namespace pro_11_2
{
/*    class MyThread
    {
        public string Filename { get; set; }
        public string Input { get; set; }
        public void Read()
        {
            string result = File.ReadAllText(Filename, Encoding.Default);
            this.Input = result;
        }
        public MyThread(string name)
        {
            this.Filename = name;

        }

        public void Write()
        {
            File.AppendAllTextAsync("result.txt", Input);
        }

    }*/
    class Program
    {
        static StreamReader stFirst = File.OpenText("first.txt");
        static StreamReader stSecond = File.OpenText("second.txt");
        static StreamWriter stResult = File.CreateText("result.txt");

        static object locker = new object();
        static void ReadnWrite(StreamReader x)
        {
            string str = x.ReadToEnd();
            x.Close();

            lock (locker)
            {
                stResult.WriteLine(str);
            }
        }
            static void Main(string[] args)

        {
             
            Thread[] threads = new Thread[] { new Thread(() => ReadnWrite(stFirst)), new Thread(() => ReadnWrite(stSecond)) };
            
            foreach (Thread ithread in threads)
            {
                ithread.Start();
            }
            foreach (Thread ithread in threads)
            {
                ithread.Join();
            }

            stResult.Close();

        }
    }
}
