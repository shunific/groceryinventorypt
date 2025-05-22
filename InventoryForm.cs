using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class InventoryForm : Form
    {
        private readonly string connectionString = (@"Server=DESKTOP-FTSC3HG\SQLEXPRESS;Database=InventoryManagementSystem;Trusted_Connection=True;");
        private readonly User currentUser;

        public InventoryForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            InitializeUIBasedOnRole();
            LoadCategories();
            LoadItems();
        }

        private void InitializeUIBasedOnRole()
        {
            if (currentUser.Role == "Staff")
            {
                btnDeleteItem.Enabled = false;
                btnDeleteCategory.Enabled = false;
            }
        }

        private void LoadCategories()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT CategoryID, CategoryName, Description FROM Categories";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    cmbCategories.DataSource = dt;
                    cmbCategories.DisplayMember = "CategoryName";
                    cmbCategories.ValueMember = "CategoryID";

                    dgvCategories.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        private void LoadItems()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT i.ItemID, i.ItemName, i.Description, c.CategoryName, 
                                 i.Quantity, i.MinimumThreshold, i.Price, i.LastUpdated
                                 FROM Items i
                                 JOIN Categories c ON i.CategoryID = c.CategoryID";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvItems.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = dgvItems.SelectedRows[0];
            int itemID = Convert.ToInt32(row.Cells["ItemID"].Value);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE Items SET 
                                    ItemName = @Name,
                                    Description = @Desc,
                                    CategoryID = @CatID,
                                    Quantity = @Qty,
                                    MinimumThreshold = @Threshold,
                                    Price = @Price,
                                    LastUpdated = GETDATE()
                                    WHERE ItemID = @ItemID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Name", txtItemName.Text);
                    cmd.Parameters.AddWithValue("@Desc", txtItemDesc.Text);
                    cmd.Parameters.AddWithValue("@CatID", cmbCategories.SelectedValue);
                    cmd.Parameters.AddWithValue("@Qty", (int)nudQuantity.Value);
                    cmd.Parameters.AddWithValue("@Threshold", (int)nudMinThreshold.Value);
                    cmd.Parameters.AddWithValue("@Price", nudPrice.Value);
                    cmd.Parameters.AddWithValue("@ItemID", itemID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Item updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadItems();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvItems.SelectedRows[0];
                txtItemName.Text = row.Cells["ItemName"].Value.ToString();
                txtItemDesc.Text = row.Cells["Description"].Value.ToString();
                cmbCategories.Text = row.Cells["CategoryName"].Value.ToString();
                nudQuantity.Value = Convert.ToInt32(row.Cells["Quantity"].Value);
                nudMinThreshold.Value = Convert.ToInt32(row.Cells["MinimumThreshold"].Value);
                nudPrice.Value = Convert.ToDecimal(row.Cells["Price"].Value);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadItems();
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT i.ItemID, i.ItemName, i.Description, c.CategoryName, 
                                   i.Quantity, i.MinimumThreshold, i.Price, i.LastUpdated
                                   FROM Items i
                                   JOIN Categories c ON i.CategoryID = c.CategoryID
                                   WHERE i.ItemName LIKE @Search OR i.Description LIKE @Search OR c.CategoryName LIKE @Search";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Search", "%" + searchTerm + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvItems.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching items: " + ex.Message);
            }
        }

        /*private void LogAction(string action)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO AuditLog (UserID, Action, Details) VALUES (@UserID, @Action, @Details)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UserID", currentUser.UserID);
                    cmd.Parameters.AddWithValue("@Action", "Inventory Update");
                    cmd.Parameters.AddWithValue("@Details", action);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Log the exception somewhere or just silently ignore
                // Consider adding a logging mechanism here
            }
        } */

        private void ClearItemFields()
        {
            txtItemName.Text = "";
            txtItemDesc.Text = "";
            nudQuantity.Value = 0;
            nudMinThreshold.Value = 5;
            nudPrice.Value = 0;
        }

        private void ClearCategoryFields()
        {
            txtCategoryName.Text = "";
            txtCategoryDesc.Text = "";
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("Please enter category name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Categories (CategoryName, Description) VALUES (@Name, @Desc)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Name", txtCategoryName.Text);
                    cmd.Parameters.AddWithValue("@Desc", txtCategoryDesc.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                    ClearCategoryFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteItem_Click_1(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataGridViewRow row = dgvItems.SelectedRows[0];
                int itemID = Convert.ToInt32(row.Cells["ItemID"].Value);

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM Items WHERE ItemID = @ItemID";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@ItemID", itemID);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Item deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadItems();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0) return;

            var row = dgvCategories.SelectedRows[0];
            int id = (int)row.Cells["CategoryID"].Value;
            string name = row.Cells["CategoryName"].Value.ToString();

            if (MessageBox.Show($"Delete '{name}'?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (var checkCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Items WHERE CategoryID = @id", connection))
                    {
                        checkCmd.Parameters.AddWithValue("@id", id);
                        if ((int)checkCmd.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("Cannot delete - category contains items");
                            return;
                        }
                    }

                    using (var deleteCmd = new SqlCommand(
                        "DELETE FROM Categories WHERE CategoryID = @id", connection))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", id);
                        deleteCmd.ExecuteNonQuery();
                    }

                    LoadCategories();
                    MessageBox.Show("Deleted successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting category: {ex.Message}");
            }
        }

        private void btnAddItem_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemName.Text) || cmbCategories.SelectedValue == null)
            {
                MessageBox.Show("Please enter item name and select category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO Items (ItemName, Description, CategoryID, Quantity, 
                                    MinimumThreshold, Price, LastUpdated) 
                                    VALUES (@Name, @Desc, @CatID, @Qty, @Threshold, @Price, GETDATE())";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Name", txtItemName.Text);
                    cmd.Parameters.AddWithValue("@Desc", txtItemDesc.Text);
                    cmd.Parameters.AddWithValue("@CatID", cmbCategories.SelectedValue);
                    cmd.Parameters.AddWithValue("@Qty", (int)nudQuantity.Value);
                    cmd.Parameters.AddWithValue("@Threshold", (int)nudMinThreshold.Value);
                    cmd.Parameters.AddWithValue("@Price", nudPrice.Value);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Item added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadItems();
                    ClearItemFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnItemUpd_Click(object sender, EventArgs e)
        {
            btnUpdateItem_Click(sender, e);
        }

        private void btnUpdCat_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a category to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = dgvCategories.SelectedRows[0];
            int categoryID = Convert.ToInt32(row.Cells["CategoryID"].Value);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE Categories SET 
                            CategoryName = @Name,
                            Description = @Desc
                            WHERE CategoryID = @CategoryID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Name", txtCategoryName.Text);
                    cmd.Parameters.AddWithValue("@Desc", txtCategoryDesc.Text);
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Category updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategories();
                        ClearCategoryFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating category: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}