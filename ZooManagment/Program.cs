using System;
using System.IO;
using System.Collections.Generic;
using ZooManagment.Controller;
using ZooManagment.Entity;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Policy;

namespace ZooManagment
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            DBConnector.InitializeDatabase();
            if(!LoginController.Login("danderson@zoonew.org", "1qaz"))
            {
                MessageBox.Show("Login Failed. Please check your credentials and try again.");
            }
            MessageBox.Show("Login Successful");
            if(!LoginController.Login("asdf", "asdf"))
            {
                MessageBox.Show("Login Failed. Please check your credentials and try again.");
            }
            MessageBox.Show("Login Successful");
        }
    }
}
