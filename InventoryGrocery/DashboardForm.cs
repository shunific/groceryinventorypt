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
    public partial class DashboardForm : Form
    {
        private string userRole;

        public DashboardForm(string role)
        {
            InitializeComponent();
            userRole = role;
        }
    }
}

