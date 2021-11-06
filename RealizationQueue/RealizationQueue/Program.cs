using System;
using System.IO;

namespace RealizationQueue
{
    class Program
    {
        static MyQueue<string> myQueue;

        static void Main(string[] args)
        {
            myQueue = new MyQueue<string>();
            var input = File.ReadAllText("../../../input.txt");
            Run(input);
        }

        static void Run(string input)
        {
            var operations = input.Split(' ');
            for(var i = 0; i < operations.Length; i++)
            {
                if (operations[i].Contains(','))
                {
                    var put = operations[i].Split(',');
                    if (IsCorrectlyPut(put))
                        Make(put[0], put[1]);
                }
                    
                Make(operations[i], null);
            }
        }

        static void Make(string idOp, string input)
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
                    Console.WriteLine(myQueue.GetValue());
                    break;
                case "4":
                    Console.WriteLine(myQueue.IsEmpry());
                    break;
                case "5":
                    myQueue.Print();
                    break;

            }
        }

        static bool IsCorrectlyPut(string[] input)
        {
            return input.Length > 2 || input[0] != "1" ? throw new Exception("Incorrectly input.") : true; 
        }
    }
}
