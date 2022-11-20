using System;
using System.Xml;
using System.Collections.Generic;


namespace ClassLibrary
{
    public class XMLStorage
    {
        public void SaveAccountListToXML(List<Account> accountList)
        {
            try
            {
                XmlDocument accountsSave = new XmlDocument();

                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "\t"
                };
                using (XmlWriter writer = XmlWriter.Create("C:\\Users\\vika7\\OneDrive\\Рабочий стол\\DotNet-labs\\DotNetLab1\\ClassLibrary\\accounts.xml", settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("accounts");

                    foreach (Account p in accountList)
                    {
                        writer.WriteStartElement("account");
                        writer.WriteStartElement("name");
                        writer.WriteString(p.Name);
                        writer.WriteEndElement();
                        writer.WriteStartElement("surname");
                        writer.WriteString(p.Surname);
                        writer.WriteEndElement();
                        writer.WriteStartElement("login");
                        writer.WriteString(p.Login);
                        writer.WriteEndElement();
                        writer.WriteStartElement("password");
                        writer.WriteString(p.Password);
                        writer.WriteEndElement();
                        writer.WriteStartElement("cardnumber");
                        writer.WriteString(p.CardNumber);
                        writer.WriteEndElement();
                        writer.WriteStartElement("balance");
                        writer.WriteString(Convert.ToString(p.Balance));
                        writer.WriteEndElement();
                        writer.WriteEndElement();
                    }
                    writer.WriteEndDocument();
                } // dispose closing
                // send XMLStorage class !
                accountsSave.Save("C:\\Users\\vika7\\OneDrive\\Рабочий стол\\DotNet-labs\\DotNetLab1\\ClassLibrary\\accounts.xml");
            }
            catch { } //solve exep

        }

        public  List<Account> GetAccountListFromXML()
        {
            // читаемо аккаунти з ХМЛ файлу
            List<Account> accountList = new List<Account>();
            XmlDocument accountsXML = new XmlDocument();
            accountsXML.Load("C:\\Users\\vika7\\OneDrive\\Рабочий стол\\DotNet-labs\\DotNetLab1\\ClassLibrary\\accounts.xml");
            foreach (XmlNode xNode in accountsXML.SelectNodes("accounts/account"))
            {
                string name = xNode.SelectSingleNode("name").InnerText;
                string surname = xNode.SelectSingleNode("surname").InnerText;
                string login = xNode.SelectSingleNode("login").InnerText;
                string cardnumber = xNode.SelectSingleNode("cardnumber").InnerText;
                string password = xNode.SelectSingleNode("password").InnerText;
                int balance = Convert.ToInt32(xNode.SelectSingleNode("balance").InnerText);

                Account acc = new Account(name, surname, login, cardnumber, password, balance);
                accountList.Add(acc);
            }
            return accountList;
        }
    }
}
