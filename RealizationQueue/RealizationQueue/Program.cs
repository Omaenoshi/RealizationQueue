using System;

namespace RealizationQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> test = new MyQueue<int>();
            Console.WriteLine(test.IsEmpry());
            test.PutValue(1);
            test.PutValue(2);
            test.PutValue(3);
            test.RemoveValue();
            test.Print();
        }
    }
}
