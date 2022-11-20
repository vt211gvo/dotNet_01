using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConsoleApp;

namespace WinFormsApp
{

    public partial class Form1 : Form
    {
        OperationsFactory Factory = new OperationsFactory();
        public Form1()
        {
            InitializeComponent();
            List<Account> accountsList = Factory.accountsList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLogin newForm = new FormLogin();
            Hide();
            newForm.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormRegister newForm = new FormRegister();
            Hide();
            newForm.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
