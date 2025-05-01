using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryGrocery
{
    public partial class LoginForm : Form
    {
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Label userLabel;
        private Label passLabel;

        public LoginForm()
        {
            InitializeComponent();
        }
       private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "admin" && password == "admin123")
            {
                MessageBox.Show("Login successful.");
                this.Hide();
                DashboardForm dashboard = new DashboardForm("Admin");
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Invalid admin credentials.");
            }
        }
    }
}