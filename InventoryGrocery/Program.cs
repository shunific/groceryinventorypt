﻿using System;
using System.Windows.Forms;
using InventoryGrocery;

namespace GroceryInventorySystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}