using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace RealizationQueue
{
    class Program
    {
        static List<string> result;  

        static MyQueue<string> myQueue;

        static Queue<string> standartQueue;

        static void Main(string[] args)
        {
            result = new List<string>();
            myQueue = new MyQueue<string>();
            standartQueue = new Queue<string>();
            var input = File.ReadAllText("../../../input.txt");

            Run(input, MakeStandartQueue);
        }

        static void Run(string input, Action<string, string> make)
        {
            var operations = input.Split(' ');
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (var i = 0; i < operations.Length; i++)
            {               
                if (operations[i].Contains(','))
                {
                    var put = operations[i].Split(',');
                    if (IsCorrectlyPut(put))
                        make(put[0], put[1]);
                }
                    
                make(operations[i], null);                
            }
            watch.Stop();
            result.Add($"{operations.Length}.{watch.ElapsedTicks}");
        }

        static void MakeMyQueue(string idOp, string input)
        {          
            switch(idOp)
            {
                case "1":
                    myQueue.PutValue(input);
                    break;
                case "2":
                    myQueue.RemoveValue();
                    break;
                case "3":
                    Console.WriteLine(myQueue.PeekValue());
                    break;
                case "4":
                    Console.WriteLine(myQueue.IsEmpry());
                    break;
                case "5":
                    myQueue.Print();
                    break;

            }
        }

        static void MakeStandartQueue(string idOp, string input)
        {
            switch (idOp)
            {
                case "1":
                    standartQueue.Enqueue(input);
                    break;
                case "2":
                    standartQueue.Dequeue();
                    break;
                case "3":
                    Console.WriteLine(standartQueue.Peek());
                    break;
                case "4":
                    Console.WriteLine(standartQueue.Count == 0);
                    break;
                case "5":
                    foreach (var e in standartQueue)
                        Console.WriteLine(e);
                    break;
            }
        }

        static bool IsCorrectlyPut(string[] input)
        {
            return input.Length > 2 || input[0] != "1" ? throw new Exception("Incorrectly input.") : true; 
        }
    }
}
