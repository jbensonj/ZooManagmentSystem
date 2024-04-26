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

            //Test to show the creation of a task//
            //Tasks taskCreate = new Tasks(1, 1, "Clean Trash", "Important", "Building A1", null, false);
            //DBConnector.AddTask(taskCreate);

            //Test to show the editing of task//
            //Tasks taskEdit = new Tasks(3, 1, "Clean Trash", "Important", "Building A1", "Need to restock trashbags", true);
            //DBConnector.SetTask(taskEdit);

            //Test LoginController interaction with DBConnector by logging in a user//
            //if (!LoginController.Login("danderson@zoonew.org", "1qaz"))
            //{
            //    MessageBox.Show("Username or password are incorrect please try again.");
            //}
            //MessageBox.Show("Login Successful");
        }
    }
}
