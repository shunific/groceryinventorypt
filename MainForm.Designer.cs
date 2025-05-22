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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ToDoList = new System.Windows.Forms.Label();
            this.txtNewTask = new System.Windows.Forms.TextBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnRemoveCompleted = new System.Windows.Forms.Button();
            this.clbTasks = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("Impact", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Tomato;
            this.lblWelcome.Location = new System.Drawing.Point(460, 120);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(143, 60);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "label1";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.BackColor = System.Drawing.Color.LightCyan;
            this.btnUserManagement.Font = new System.Drawing.Font("Impact", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManagement.ForeColor = System.Drawing.Color.Tomato;
            this.btnUserManagement.Location = new System.Drawing.Point(55, 586);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(271, 75);
            this.btnUserManagement.TabIndex = 1;
            this.btnUserManagement.Text = "Manage Users";
            this.btnUserManagement.UseVisualStyleBackColor = false;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click_1);
            // 
            // dgvRecentItems
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Impact", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvRecentItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRecentItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRecentItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentItems.GridColor = System.Drawing.Color.Tomato;
            this.dgvRecentItems.Location = new System.Drawing.Point(1456, 76);
            this.dgvRecentItems.Name = "dgvRecentItems";
            this.dgvRecentItems.Size = new System.Drawing.Size(342, 903);
            this.dgvRecentItems.TabIndex = 2;
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.AutoSize = true;
            this.lblTotalItems.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalItems.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItems.ForeColor = System.Drawing.Color.Tomato;
            this.lblTotalItems.Location = new System.Drawing.Point(483, 809);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(104, 43);
            this.lblTotalItems.TabIndex = 3;
            this.lblTotalItems.Text = "label1";
            // 
            // lblLowStockItems
            // 
            this.lblLowStockItems.AutoSize = true;
            this.lblLowStockItems.BackColor = System.Drawing.Color.Transparent;
            this.lblLowStockItems.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockItems.ForeColor = System.Drawing.Color.Tomato;
            this.lblLowStockItems.Location = new System.Drawing.Point(967, 820);
            this.lblLowStockItems.Name = "lblLowStockItems";
            this.lblLowStockItems.Size = new System.Drawing.Size(240, 43);
            this.lblLowStockItems.TabIndex = 4;
            this.lblLowStockItems.Text = "low stock items";
            // 
            // lblTotalCategories
            // 
            this.lblTotalCategories.AutoSize = true;
            this.lblTotalCategories.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCategories.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCategories.ForeColor = System.Drawing.Color.Tomato;
            this.lblTotalCategories.Location = new System.Drawing.Point(482, 936);
            this.lblTotalCategories.Name = "lblTotalCategories";
            this.lblTotalCategories.Size = new System.Drawing.Size(248, 43);
            this.lblTotalCategories.TabIndex = 5;
            this.lblTotalCategories.Text = "total categories";
            // 
            // btnInventory_Click
            // 
            this.btnInventory_Click.BackColor = System.Drawing.Color.LightCyan;
            this.btnInventory_Click.Font = new System.Drawing.Font("Impact", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory_Click.ForeColor = System.Drawing.Color.Tomato;
            this.btnInventory_Click.Location = new System.Drawing.Point(55, 494);
            this.btnInventory_Click.Name = "btnInventory_Click";
            this.btnInventory_Click.Size = new System.Drawing.Size(271, 69);
            this.btnInventory_Click.TabIndex = 6;
            this.btnInventory_Click.Text = "Manage Inventory";
            this.btnInventory_Click.UseVisualStyleBackColor = false;
            this.btnInventory_Click.Click += new System.EventHandler(this.btnInventory_Click_Click);
            // 
            // btnLogout_Click
            // 
            this.btnLogout_Click.BackColor = System.Drawing.Color.LightCyan;
            this.btnLogout_Click.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout_Click.ForeColor = System.Drawing.Color.Tomato;
            this.btnLogout_Click.Location = new System.Drawing.Point(55, 952);
            this.btnLogout_Click.Name = "btnLogout_Click";
            this.btnLogout_Click.Size = new System.Drawing.Size(271, 41);
            this.btnLogout_Click.TabIndex = 7;
            this.btnLogout_Click.Text = "Log Out";
            this.btnLogout_Click.UseVisualStyleBackColor = false;
            this.btnLogout_Click.Click += new System.EventHandler(this.btnLogout_Click_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(967, 766);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 43);
            this.label1.TabIndex = 8;
            this.label1.Text = "Items Low in Stock:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Tomato;
            this.label2.Location = new System.Drawing.Point(482, 893);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 43);
            this.label2.TabIndex = 9;
            this.label2.Text = "Total Categories:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Tomato;
            this.label3.Location = new System.Drawing.Point(482, 766);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 43);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total Items:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightCyan;
            this.label4.Location = new System.Drawing.Point(91, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 45);
            this.label4.TabIndex = 12;
            this.label4.Text = "DASHBOARD";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::InventoryManagementSystem.Properties.Resources.Untitled__320_x_320_px___5_;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(55, 81);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(271, 276);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // ToDoList
            // 
            this.ToDoList.AutoSize = true;
            this.ToDoList.BackColor = System.Drawing.Color.Transparent;
            this.ToDoList.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDoList.ForeColor = System.Drawing.Color.Tomato;
            this.ToDoList.Location = new System.Drawing.Point(482, 314);
            this.ToDoList.Name = "ToDoList";
            this.ToDoList.Size = new System.Drawing.Size(102, 43);
            this.ToDoList.TabIndex = 15;
            this.ToDoList.Text = "To do:";
            // 
            // txtNewTask
            // 
            this.txtNewTask.Font = new System.Drawing.Font("Impact", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewTask.Location = new System.Drawing.Point(490, 360);
            this.txtNewTask.Name = "txtNewTask";
            this.txtNewTask.Size = new System.Drawing.Size(455, 43);
            this.txtNewTask.TabIndex = 16;
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackColor = System.Drawing.Color.White;
            this.btnAddTask.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTask.ForeColor = System.Drawing.Color.Tomato;
            this.btnAddTask.Location = new System.Drawing.Point(961, 360);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(146, 43);
            this.btnAddTask.TabIndex = 17;
            this.btnAddTask.Text = "Add task";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnRemoveCompleted
            // 
            this.btnRemoveCompleted.BackColor = System.Drawing.Color.White;
            this.btnRemoveCompleted.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveCompleted.ForeColor = System.Drawing.Color.Tomato;
            this.btnRemoveCompleted.Location = new System.Drawing.Point(708, 643);
            this.btnRemoveCompleted.Name = "btnRemoveCompleted";
            this.btnRemoveCompleted.Size = new System.Drawing.Size(338, 43);
            this.btnRemoveCompleted.TabIndex = 19;
            this.btnRemoveCompleted.Text = "Remove completed";
            this.btnRemoveCompleted.UseVisualStyleBackColor = false;
            this.btnRemoveCompleted.Click += new System.EventHandler(this.btnRemoveCompleted_Click);
            // 
            // clbTasks
            // 
            this.clbTasks.BackColor = System.Drawing.Color.White;
            this.clbTasks.Font = new System.Drawing.Font("Impact", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbTasks.ForeColor = System.Drawing.Color.Tomato;
            this.clbTasks.FormattingEnabled = true;
            this.clbTasks.Location = new System.Drawing.Point(491, 419);
            this.clbTasks.Name = "clbTasks";
            this.clbTasks.Size = new System.Drawing.Size(763, 200);
            this.clbTasks.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightCyan;
            this.label7.Location = new System.Drawing.Point(1, 437);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(379, 43);
            this.label7.TabIndex = 21;
            this.label7.Text = "------------------------------------";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InventoryManagementSystem.Properties.Resources.Untitled_design__11_;
            this.ClientSize = new System.Drawing.Size(1904, 1021);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.clbTasks);
            this.Controls.Add(this.btnRemoveCompleted);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.txtNewTask);
            this.Controls.Add(this.ToDoList);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogout_Click);
            this.Controls.Add(this.lblTotalCategories);
            this.Controls.Add(this.lblLowStockItems);
            this.Controls.Add(this.lblTotalItems);
            this.Controls.Add(this.dgvRecentItems);
            this.Controls.Add(this.btnUserManagement);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInventory_Click);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Welcome Screen (Main Form)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label ToDoList;
        private System.Windows.Forms.TextBox txtNewTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnRemoveCompleted;
        private System.Windows.Forms.CheckedListBox clbTasks;
        private System.Windows.Forms.Label label7;
    }
}

