using System;
using ClassLibrary;
using System.Collections.Generic;


namespace ConsoleApp
{
    public class Operation
    {
        public string label;
        public Func<bool> BoolImplementation;
        public Func<Account> AccountImplementation;
    }


    public class OperationManager
    {
        private readonly List<Operation> operations;
        public OperationManager(List<Operation> operations)
        {
            this.operations = operations;
        }
        public int Run()
        {
            var k = 0;
            foreach (var operation in operations)
            {
                Console.WriteLine($"{k}. {operation.label}");
                k++;
            }
            do
            {
                string str = Console.ReadLine();
                if (int.TryParse(str, out var i) && i >= 0 && i < operations.Count)
                {
                    return i;
                }
                Console.WriteLine("Неправильний вибір, повторіть операцію !!!");
            } while (true);
        }
    }
}