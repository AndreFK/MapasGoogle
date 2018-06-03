using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapasGoogle
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            passwordTxtBox.PasswordChar = '*';
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if((userTxtBox.Text == "Admin" && passwordTxtBox.Text == "p")||(userTxtBox.Text == "admin" && passwordTxtBox.Text == "p"))
            {
                this.Hide();
                Form1 ss = new Form1();
                ss.Show();
            }
           
            else
            {
                MessageBox.Show("Incorrect username and/or password");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {

        }

        private void loginLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
