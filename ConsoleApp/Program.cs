using System;
using System.Text;
using ClassLibrary;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.Title = "Банкомат";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t------------");
            Console.WriteLine("\t\t\t| Банкомат |");
            Console.WriteLine("\t\t\t------------");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Gray;

            string separator;

            OperationsFactory Factory = new OperationsFactory();
            var accountsList = Factory.accountsList;
            OperationManager MainMenu = new OperationManager(new List<Operation>
            {
                Factory.Exit(),
                Factory.Authentication(),
                Factory.Registration()

            });

            int choice;
            bool endLoop = true;
            Account CurrentAccount = null;

            separator = "--------------------------------------------------------";

            do
            {
                Console.WriteLine(separator);
                Console.WriteLine("Ласкаво просимо дорогий клієнт!\n\n" +
                    "Будь ласка увійдіть щоб продовжити,\nякщо ж у вас ще немає акаунту, спочатку зареєструйтесь!\n");
                choice = MainMenu.Run();
                Console.WriteLine(separator);

                switch (choice)
                {
                    case 0:
                        {
                            Factory.Exit().BoolImplementation();
                            break;
                        }
                    case 1:
                        {
                            CurrentAccount = Factory.Authentication().AccountImplementation();
                            if (CurrentAccount != null) endLoop = false;
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine("Помилка! Неправильний логін або пароль");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.ReadLine();
                            }
                            break;
                        }
                    case 2:
                        {
                            Factory.Registration().BoolImplementation();
                            break;
                        }
                }

            } while (endLoop);

            MainMenu = new OperationManager(new List<Operation>
            {
                Factory.AuthGetBalanace(CurrentAccount),
                Factory.AuthWidhdraw(CurrentAccount),
                Factory.AuthAddMoney(CurrentAccount),
                Factory.AuthSendMoney(CurrentAccount),
                Factory.Exit()
            }) ;

            endLoop = true;

            separator = "------------------------------------";
            Console.Clear();
            do
            {
                Console.WriteLine();
                Console.WriteLine(separator);
                choice = MainMenu.Run();

                switch (choice)
                {
                    case 0:
                        {
                            Factory.AuthGetBalanace(CurrentAccount).BoolImplementation();
                            break ;
                        }
                    case 1:
                        {
                            Factory.AuthWidhdraw(CurrentAccount).BoolImplementation();
                            break;
                        }
                    case 2:
                        {
                            Factory.AuthAddMoney(CurrentAccount).BoolImplementation();
                            break;
                        }
                    case 3:
                        {
                            Factory.AuthSendMoney(CurrentAccount).BoolImplementation();
                            break;
                        }
                    case 4:
                        {
                            Factory.Exit();
                            endLoop = false;

                            Console.WriteLine("--------- Робота завершена ---------");
                            Console.WriteLine(separator);
                            break;
                        }
                }

                Console.ReadKey();
                Console.Clear() ;

            } while (endLoop);
        }
    }
}
