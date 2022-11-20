using System;
using ClassLibrary;
using System.Collections.Generic;


namespace ConsoleApp
{
    public class OperationsFactory
    {
        public XMLStorage XMLStorage = new XMLStorage();
        public List<Account> accountsList;
        public OperationsFactory() { 
            accountsList = XMLStorage.GetAccountListFromXML();
        }
       

        public Operation Exit()
        {
            return new Operation()
            {
                label = "Вихід",
                BoolImplementation = ()=>
                {
                    XMLStorage.SaveAccountListToXML(accountsList); //immediately save in XML
                    Environment.Exit(0);
                    return true;
                },
                AccountImplementation = ()=> { return null; }
            };
        }

        public Operation Registration()
        {
            return new Operation()
            {
                label = "Реєстрація",
                BoolImplementation = ()=>
                {
                    Console.Clear();
                    Console.WriteLine("------Реєстрація------");

                    Console.Write("Ім'я: ");
                    string name = Console.ReadLine();

                    Console.Write("Прізвище: ");
                    string surname = Console.ReadLine();

                    Console.Write("Логін: ");
                    string login = Console.ReadLine();

                    Console.Write("Номер вашої картки: ");
                    string cardnumber = Console.ReadLine();

                    Console.Write("Пароль: ");
                    string password = Console.ReadLine();

                    Account tryacc = accountsList.Find(acc => acc.Login == login || acc.CardNumber == cardnumber);
                    if(tryacc != null)
                    {
                        Console.WriteLine("Такий користувач або карта вже існує");
                        return false;
                    }
                    Account acc = new Account(name, surname, login, cardnumber, password);

                    accountsList.Add(acc); 
                    XMLStorage.SaveAccountListToXML(accountsList); //immediately save in XML
                    return true;
                },
                AccountImplementation = ()=> { return null; }
            };
        } 

        // AUTH Actions
        public Operation Authentication()
        {
            return new Operation()
            {
                label = "Увійти в акаунт",

                BoolImplementation = ()=> { return true; },
       
                AccountImplementation = ()=>
                {
                    Console.Clear();
                    Console.WriteLine("------Увійти------");

                    Console.Write("Логін: ");
                    string login = Console.ReadLine();

                    Console.Write("Пароль: ");
                    string password = Console.ReadLine();

                    Account account = accountsList.Find(acc => acc.Login == login && acc.Password == password);
                    if(account != null)
                    {
                        return account;
                    }
                    return null;
                }
            };
        }

        public Operation AuthGetBalanace(Account account)
        {
            return new Operation()
            {
                label = "Переглянути баланс",
                BoolImplementation = ()=>
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Ваш баланс: " + account.Balance);
                    return true;
                },
                AccountImplementation = ()=> { return null; }
            };
        }

        public Operation AuthWidhdraw(Account account)
        {
            return new Operation()
            {
                label = "Зняття коштів",
                BoolImplementation = ()=>
                {
                    Console.WriteLine("----------Зняття коштів-------------");
                    Console.Write("Введіть суму для зняття: ");
                    int money = Convert.ToInt32(Console.ReadLine());

                    if (account.Withdraw(money) == false)
                    {
                        Console.WriteLine("Недостатньо коштів на картці");
                        return false;
                    }
                    Console.WriteLine("Успішно");

                    XMLStorage.SaveAccountListToXML(accountsList);
                    return true;
                },
                AccountImplementation = ()=> { return null; }
            };
        }

        public Operation AuthAddMoney(Account account)
        {
            return new Operation()
            {
                label = "Поповнити картку",
                BoolImplementation = ()=>
                {
                    Console.WriteLine("-----------------------");
                    Console.Write("Введіть суму для поповнення Вашої картки: ");
                    int money = Convert.ToInt32(Console.ReadLine());

                    if (account.AddMoney(money) == false)
                    {
                        Console.WriteLine("Спробуйте знову, некоректна сума");
                        return false;
                    }
                    else Console.WriteLine("Успішно");

                    XMLStorage.SaveAccountListToXML(accountsList);
                    return true;
                },
                AccountImplementation = ()=> { return null; }
            };
        }

        public Operation AuthSendMoney(Account account)
        {
            return new Operation()
            {
                label = "Переказати кошти",
                BoolImplementation = ()=>
                {
                    Console.Clear();

                    Console.Write("Введіть номер карти отримувача: ");
                    string cardNumber = Console.ReadLine();

                    Console.Write("Введіть суму для поповнення іншої картки: ");
                    int money = Convert.ToInt32(Console.ReadLine());

                    Account recipient = accountsList.Find(acc => acc.CardNumber == cardNumber);
                    if (account.SendMoney(money, cardNumber, recipient) == false)
                    {
                        Console.WriteLine("Щось трапилось, уведіть корректну суму або корректний номер карти отримувача");
                        return false;
                    }
                    else Console.WriteLine("Успішно");

                    XMLStorage.SaveAccountListToXML(accountsList);
                    return true;
                },
                AccountImplementation = ()=> { return null; }
            };
        }
    }

}