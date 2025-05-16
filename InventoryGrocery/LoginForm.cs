using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InventoryGrocery
{
    public partial class LoginForm : Form
    {
        Dictionary<string, string> registeredUsers = new Dictionary<string, string>();
        string usersFilePath = "users.txt";

        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;
            this.Paint += LoginForm_Paint;
            this.DoubleBuffered = true;

            textBox1.TextChanged += textBox1_TextChanged;
            textBox2.TextChanged += textBox2_TextChanged;
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox2.PasswordChar = '*';
            LoadUsersFromFile();
            this.Invalidate(); // Force a repaint to ensure gradient shows up
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "admin123")
            {
                MessageBox.Show("Login successful as Admin.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                DashboardForm dashboard = new DashboardForm("Admin");
                dashboard.Show();
                return;
            }

            if (registeredUsers.ContainsKey(username))
            {
                if (registeredUsers[username] == password)
                {
                    MessageBox.Show("Login successful.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    DashboardForm dashboard = new DashboardForm(username);
                    dashboard.Show();
                }
                else
                {
                    label4.Text = "Incorrect password.";
                    label4.ForeColor = Color.Red;
                }
            }
            else
            {
                label4.Text = "Invalid Account";
                label4.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string newUsername = textBox1.Text.Trim();
            string newPassword = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword))
            {
                label4.Text = "Username and password are required.";
                label4.ForeColor = Color.Red;
                return;
            }

            if (newUsername.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                label4.Text = "Cannot register as 'admin'.";
                label4.ForeColor = Color.Red;
                return;
            }

            if (registeredUsers.ContainsKey(newUsername))
            {
                label4.Text = "Username already exists.";
                label4.ForeColor = Color.Red;
                return;
            }

            registeredUsers.Add(newUsername, newPassword);
            SaveUsersToFile();
            MessageBox.Show("User registered successfully!", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBox1.Text = "";
            textBox2.Text = "";
            label4.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ValidateInputs();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ValidateInputs();
        }

        private void ValidateInputs()
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                label4.Text = "Username is required.";
                label4.ForeColor = Color.Red;
                button1.Enabled = true;
            }
            else if (string.IsNullOrEmpty(password))
            {
                label4.Text = "Password is required.";
                label4.ForeColor = Color.Red;
                button1.Enabled = true;
            }
            else
            {
                label4.Text = "";
                button1.Enabled = true;
            }
        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.MediumPurple,
                Color.DeepSkyBlue,
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void LoadUsersFromFile()
        {
            if (File.Exists(usersFilePath))
            {
                var lines = File.ReadAllLines(usersFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2 && !registeredUsers.ContainsKey(parts[0]))
                    {
                        registeredUsers.Add(parts[0], parts[1]);
                    }
                }
            }
        }

        private void SaveUsersToFile()
        {
            var lines = registeredUsers.Select(kvp => $"{kvp.Key},{kvp.Value}");
            File.WriteAllLines(usersFilePath, lines);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Need help? Register a new user with a username and password, then click Register.");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }
    }
}