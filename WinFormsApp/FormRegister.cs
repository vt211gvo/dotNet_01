using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConsoleApp;
using ClassLibrary;

namespace WinFormsApp
{
    public partial class FormRegister : Form
    {
        XMLStorage xMLStorage = new XMLStorage();
        OperationsFactory Factory = new OperationsFactory();
        List<Account> accountsList;
        public FormRegister()
        {
            InitializeComponent();
            accountsList = Factory.accountsList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string login = textBox3.Text;
            string cardnumber = textBox4.Text;
            string password = textBox5.Text;
            Account account = new Account(name, surname, login, cardnumber, password);
            accountsList.Add(account);
            xMLStorage.SaveAccountListToXML(accountsList);
            Form1 form = new Form1();
            form.Show();
            Close();

        }
    }
}
