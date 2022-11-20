using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibrary;
using ConsoleApp;

namespace WinFormsApp
{
    public partial class AuthMenu : Form
    {
        public Account Account;
        XMLStorage xMLStorage = new XMLStorage();
        OperationsFactory Factory = new OperationsFactory();
        List<Account> accountsList;
        public AuthMenu()
        {
            InitializeComponent();
            accountsList = Factory.accountsList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
               "Ваш баланс " + Account.Balance,
               "Баланс",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information,
               MessageBoxDefaultButton.Button1,
               MessageBoxOptions.DefaultDesktopOnly);
            this.BringToFront();
            this.Activate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int money = Convert.ToInt32(textBox1.Text);
            if (Account.Withdraw(money) == false)
                MessageBox.Show(
                "Недостатньо коштів на картці",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            else
            {
                MessageBox.Show(
                  "Успішно ",
                  "Повідомлення",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information,
                  MessageBoxDefaultButton.Button1,
                  MessageBoxOptions.DefaultDesktopOnly);
                xMLStorage.SaveAccountListToXML(accountsList);
            }
            this.BringToFront();
            this.Activate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cardnumber = textBox3.Text;
            int money = Convert.ToInt32(textBox4.Text);
            Account recipient = accountsList.Find(acc => acc.CardNumber == cardnumber);
            if (Account.SendMoney(money, cardnumber, recipient) == false)
                MessageBox.Show(
                "Недостатньо коштів на картці, або картки не існує",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            else MessageBox.Show(
                  "Успішно ",
                  "Повідомлення",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information,
                  MessageBoxDefaultButton.Button1,
                  MessageBoxOptions.DefaultDesktopOnly);
            xMLStorage.SaveAccountListToXML(accountsList);
            this.BringToFront();
            this.Activate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int money = Convert.ToInt32(textBox2.Text);
            if (Account.AddMoney(money) == false)
            {
                MessageBox.Show(
                "Помилка",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            }
            else MessageBox.Show(
                  "Успішно ",
                  "Повідомлення",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Information,
                  MessageBoxDefaultButton.Button1,
                  MessageBoxOptions.DefaultDesktopOnly);
            xMLStorage.SaveAccountListToXML(accountsList);
            this.BringToFront();
            this.Activate();
        }

        private void AuthMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
