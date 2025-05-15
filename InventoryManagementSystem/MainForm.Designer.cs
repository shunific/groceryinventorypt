namespace InventoryManagementSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.dgvRecentItems = new System.Windows.Forms.DataGridView();
            this.lblTotalItems = new System.Windows.Forms.Label();
            this.lblLowStockItems = new System.Windows.Forms.Label();
            this.lblTotalCategories = new System.Windows.Forms.Label();
            this.btnInventory_Click = new System.Windows.Forms.Button();
            this.btnLogout_Click = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lowStockPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(12, 37);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(60, 24);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "label1";
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.Location = new System.Drawing.Point(16, 219);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(106, 32);
            this.btnUserManagement.TabIndex = 1;
            this.btnUserManagement.Text = "Manage Users";
            this.btnUserManagement.UseVisualStyleBackColor = true;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click_1);
            // 
            // dgvRecentItems
            // 
            this.dgvRecentItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentItems.Location = new System.Drawing.Point(170, 129);
            this.dgvRecentItems.Name = "dgvRecentItems";
            this.dgvRecentItems.Size = new System.Drawing.Size(398, 178);
            this.dgvRecentItems.TabIndex = 2;
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItems.Location = new System.Drawing.Point(166, 102);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(60, 24);
            this.lblTotalItems.TabIndex = 3;
            this.lblTotalItems.Text = "label1";
            // 
            // lblLowStockItems
            // 
            this.lblLowStockItems.AutoSize = true;
            this.lblLowStockItems.Location = new System.Drawing.Point(13, 89);
            this.lblLowStockItems.Name = "lblLowStockItems";
            this.lblLowStockItems.Size = new System.Drawing.Size(79, 13);
            this.lblLowStockItems.TabIndex = 4;
            this.lblLowStockItems.Text = "low stock items";
            // 
            // lblTotalCategories
            // 
            this.lblTotalCategories.AutoSize = true;
            this.lblTotalCategories.Location = new System.Drawing.Point(13, 151);
            this.lblTotalCategories.Name = "lblTotalCategories";
            this.lblTotalCategories.Size = new System.Drawing.Size(79, 13);
            this.lblTotalCategories.TabIndex = 5;
            this.lblTotalCategories.Text = "total categories";
            // 
            // btnInventory_Click
            // 
            this.btnInventory_Click.Location = new System.Drawing.Point(16, 182);
            this.btnInventory_Click.Name = "btnInventory_Click";
            this.btnInventory_Click.Size = new System.Drawing.Size(106, 31);
            this.btnInventory_Click.TabIndex = 6;
            this.btnInventory_Click.Text = "Manage Inventory";
            this.btnInventory_Click.UseVisualStyleBackColor = true;
            this.btnInventory_Click.Click += new System.EventHandler(this.btnInventory_Click_Click);
            // 
            // btnLogout_Click
            // 
            this.btnLogout_Click.Location = new System.Drawing.Point(16, 257);
            this.btnLogout_Click.Name = "btnLogout_Click";
            this.btnLogout_Click.Size = new System.Drawing.Size(106, 33);
            this.btnLogout_Click.TabIndex = 7;
            this.btnLogout_Click.Text = "Log Out";
            this.btnLogout_Click.UseVisualStyleBackColor = true;
            this.btnLogout_Click.Click += new System.EventHandler(this.btnLogout_Click_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Items Low in Stock:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Total Categories:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(166, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total Items:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lowStockPanel
            // 
            this.lowStockPanel.Location = new System.Drawing.Point(503, 67);
            this.lowStockPanel.Name = "lowStockPanel";
            this.lowStockPanel.Size = new System.Drawing.Size(10, 10);
            this.lowStockPanel.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 687);
            this.Controls.Add(this.lowStockPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout_Click);
            this.Controls.Add(this.btnInventory_Click);
            this.Controls.Add(this.lblTotalCategories);
            this.Controls.Add(this.lblLowStockItems);
            this.Controls.Add(this.lblTotalItems);
            this.Controls.Add(this.dgvRecentItems);
            this.Controls.Add(this.btnUserManagement);
            this.Controls.Add(this.lblWelcome);
            this.Name = "MainForm";
            this.Text = "Welcome Screen (Main Form)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnUserManagement;
        private System.Windows.Forms.DataGridView dgvRecentItems;
        private System.Windows.Forms.Label lblTotalItems;
        private System.Windows.Forms.Label lblLowStockItems;
        private System.Windows.Forms.Label lblTotalCategories;
        private System.Windows.Forms.Button btnInventory_Click;
        private System.Windows.Forms.Button btnLogout_Click;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel lowStockPanel;
    }
}

