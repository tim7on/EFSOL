using System;
using System.Threading;
// NOT WORK ON THIS PLATFORM
namespace pro_13_2
{
    class program
    {
        public delegate void InvokeDelegate();
        
        static void Method()
        {
            Console.WriteLine("Method starts");
            Thread.Sleep(2000);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            InvokeDelegate test = Method;
            Action myDelegate = new Action(Method);
            myDelegate.BeginInvoke(test, null);
        }
    }
}
