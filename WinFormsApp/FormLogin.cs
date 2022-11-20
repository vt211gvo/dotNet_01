using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClassLibrary;
using ConsoleApp;

namespace WinFormsApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            XMLStorage xMLStorage = new XMLStorage();
            OperationsFactory Factory = new OperationsFactory();
            List<Account> accountsList = Factory.accountsList;
            string login = textBox1.Text;
            string password = textBox2.Text;
            Account acc = accountsList.Find(acc => acc.Login == login || acc.Password == password);
            if (acc != null)
            {
                AuthMenu authMenu = new AuthMenu();
                authMenu.Owner = this;
                authMenu.Account = acc;
                authMenu.Show();
                Hide();
               

            }
            else MessageBox.Show("Неправильний логін або пароль", "Error", MessageBoxButtons.OK);
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}