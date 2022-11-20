using System.Collections.Generic;

namespace ClassLibrary
{
    internal class Bank
    {
        public string Name;
        public List<ATM> BankList;
        public string Address;

        public Bank(string name, List<ATM> banklist, string address)
        {
            Name = name;
            BankList = banklist;
            Address = address;
        }
    }
}
