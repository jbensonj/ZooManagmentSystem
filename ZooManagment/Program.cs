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
            Console.WriteLine("Program start");
            ApplicationConfiguration.Initialize();
            DBConnector.InitializeDatabase();
            LoginController.Login("danderson@zoonew.org", "1qaz");
            Console.WriteLine("Progam complete");
        }
    }
}