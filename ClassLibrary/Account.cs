namespace ClassLibrary
{
    public class Account
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get ; set; }
        public string CardNumber { get; set; } // set private
        public int Balance { get; set; } // change UINT

        public Account(string name, string surname, string login, string cardnumber, string password, int balance = 0)
        {
            Login = login;
            Name = name;
            Surname = surname;
            CardNumber = cardnumber;
            Password = password;
            Balance = balance;
        }
        public bool Withdraw(int money)
        {
            if (Balance < money)
                return false; 
            
            Balance -= money;
            return true;
        }
        public bool AddMoney(int money)
        {
            if (money < 0)
                return false;
            
            Balance += money;
            return true;
        }
        public bool SendMoney(int money, string cardNumber, Account recipient)
        {
            if(recipient != null && money > 0 && Balance >= money)
            {
                Balance -= money;
                recipient.Balance += money;
                return true;
            }
            return false;
        }
    }
}
