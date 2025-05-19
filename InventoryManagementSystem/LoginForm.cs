using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystem
{

    public partial class LoginForm : Form
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=InventoryManagementSystem;Integrated Security=True");

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLugin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();
                string query = "SELECT UserID, Username, FullName, Role FROM Users WHERE Username = @Username AND Password = @Password AND IsActive = 1";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    User user = new User
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        Username = reader["Username"].ToString(),
                        FullName = reader["FullName"].ToString(),
                        Role = reader["Role"].ToString()
                    };

                    reader.Close();
                    query = "UPDATE Users SET LastLogin = GETDATE() WHERE UserID = @UserID";
                    cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    cmd.ExecuteNonQuery();

                    this.Hide();
                    MainForm mainForm = new MainForm(user);
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
    }
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}