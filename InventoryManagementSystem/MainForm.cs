using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {
        private User currentUser;
        private SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=InventoryManagementSystem;Integrated Security=True");

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            InitializeUIBasedOnRole();
            LoadDashboard();
            CheckLowStockItems();
        }

        private void InitializeUIBasedOnRole()
        {
            lblWelcome.Text = $"Welcome, {currentUser.FullName} ({currentUser.Role})";

            if (currentUser.Role == "Staff")
            {
                btnUserManagement.Enabled = false;
                btnUserManagement.Visible = false;
            }
        }

        private void LoadDashboard()
        {
            try
            {
                connection.Open();
                string query = "SELECT TOP 10 ItemName, Quantity, LastUpdated FROM Items ORDER BY LastUpdated DESC";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvRecentItems.DataSource = dt;

                query = "SELECT COUNT(*) FROM Items";
                SqlCommand cmd = new SqlCommand(query, connection);
                lblTotalItems.Text = cmd.ExecuteScalar().ToString();

                query = "SELECT COUNT(*) FROM Items WHERE Quantity <= MinimumThreshold";
                lblLowStockItems.Text = cmd.ExecuteScalar().ToString();

                query = "SELECT COUNT(*) FROM Categories";
                lblTotalCategories.Text = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void CheckLowStockItems()
        {
            try
            {
                connection.Open();
                string query = "SELECT ItemName FROM Items WHERE Quantity <= MinimumThreshold";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    string lowStockItems = "";
                    while (reader.Read())
                    {
                        lowStockItems += reader["ItemName"].ToString() + "\n";
                    }
                    MessageBox.Show($"The following items are low on stock:\n{lowStockItems}", "Low Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking low stock items: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnLogout_Click_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnInventory_Click_Click(object sender, EventArgs e)
        {
            InventoryForm inventoryForm = new InventoryForm(currentUser);
            inventoryForm.ShowDialog();
            LoadDashboard();
        }

        private void btnUserManagement_Click_1(object sender, EventArgs e)
        {
            UserManagementForm userForm = new UserManagementForm();
            userForm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}