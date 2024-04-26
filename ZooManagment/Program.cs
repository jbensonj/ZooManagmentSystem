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
        //<summary>//
        //Initialize application and Database//
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            DBConnector.InitializeDatabase();
            if (!LoginController.Login("danderson@zoonew.org", "1qaz")) //Test LoginController interaction with DBConnector by logging in a user//
            {
                MessageBox.Show("Username or password are incorrect please try again.");
            }
            MessageBox.Show("Login Successful");
        }
    }
}
