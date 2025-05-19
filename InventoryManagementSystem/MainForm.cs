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
        private Panel notificationBanner;

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            InitializeUIBasedOnRole();
            InitializeNotificationBanner();
            LoadDashboard();
            DisplayLowStockItems();
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

        private void InitializeNotificationBanner()
        {
            notificationBanner = new Panel();
            notificationBanner.Size = new Size(this.Width, 30);
            notificationBanner.Location = new Point(0, 0);
            notificationBanner.BackColor = Color.Gold;
            notificationBanner.Visible = false;

            Label lblNotification = new Label();
            lblNotification.Text = "⚠ Some items are low on stock!";
            lblNotification.AutoSize = true;
            lblNotification.Location = new Point(10, 7);
            lblNotification.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            notificationBanner.Controls.Add(lblNotification);
            this.Controls.Add(notificationBanner);
            notificationBanner.BringToFront();
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

        private void DisplayLowStockItems()
        {
            connection.Open();
            string query = "SELECT ItemName, Quantity, MinimumThreshold FROM Items WHERE Quantity <= MinimumThreshold ORDER BY Quantity ASC";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            int yPosition = 30; // Start position below header
            bool hasLowStock = false;

            lowStockPanel.Controls.Clear(); // Clear previous labels

            if (reader.HasRows)
            {
                hasLowStock = true;
                while (reader.Read())
                {
                    string itemName = reader["ItemName"].ToString();
                    int quantity = Convert.ToInt32(reader["Quantity"]);
                    int threshold = Convert.ToInt32(reader["MinimumThreshold"]);

                    Label lblItem = new Label();
                    lblItem.Text = $"{itemName} - {quantity}/{threshold}";
                    lblItem.Location = new Point(10, yPosition);
                    lblItem.AutoSize = true;

                    if (quantity < threshold / 2)
                    {
                        lblItem.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblItem.ForeColor = Color.Black;
                    }

                    lowStockPanel.Controls.Add(lblItem);
                    yPosition += 25;
                }
            }
            else
            {
                Label lblNoItems = new Label();
                lblNoItems.Text = "No items are low on stock";
                lblNoItems.Location = new Point(10, yPosition);
                lblNoItems.AutoSize = true;
                lowStockPanel.Controls.Add(lblNoItems);
            }

            reader.Close();
            connection.Close();

            // Show or hide banner based on low stock
            notificationBanner.Visible = hasLowStock;
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
            DisplayLowStockItems();
        }

        private void btnUserManagement_Click_1(object sender, EventArgs e)
        {
            UserManagementForm userForm = new UserManagementForm();
            userForm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void pnlLowStockItems_Paint(object sender, PaintEventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
