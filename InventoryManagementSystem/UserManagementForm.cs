using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class UserManagementForm : Form
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=InventoryManagementSystem;Integrated Security=True");

        public UserManagementForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                connection.Open();
                string query = "SELECT UserID, Username, FullName, Role, LastLogin FROM Users";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvUsers.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = dgvUsers.SelectedRows[0];
            int userID = Convert.ToInt32(row.Cells["UserID"].Value);

            try
            {
                connection.Open();
                string query = @"UPDATE Users SET 
                                Username = @Username,
                                FullName = @FullName,
                                Role = @Role
                                WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@UserID", userID);

                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    cmd.CommandText += ", Password = @Password";
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                }

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUsers.SelectedRows[0];
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                cmbRole.SelectedItem = row.Cells["Role"].Value.ToString();
                txtPassword.Text = ""; // Don't show password
            }
        }

        private void ClearUserFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            cmbRole.SelectedIndex = 0;
        }

        private void btnAddUser_Click_1(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = dgvUsers.SelectedRows[0];
            int userID = Convert.ToInt32(row.Cells["UserID"].Value);
            string username = row.Cells["Username"].Value.ToString();
            if (username == "admin")
            {
                MessageBox.Show("Cannot delete the default admin user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete user '{username}'?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Users SET IsActive = 0 WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click_2(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                int userCount = (int)checkCmd.ExecuteScalar();

                if (userCount > 0)
                {
                    MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string query = @"INSERT INTO Users (Username, Password, FullName, Role)
                                VALUES (@Username, @Password, @FullName, @Role)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem.ToString());

                cmd.ExecuteNonQuery();

                MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                ClearUserFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}