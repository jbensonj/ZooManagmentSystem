using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using ZooManagment.Entity;

namespace ZooManagment.Controller
{
    public static class DBConnector
    {
        private static string connectionString = @"Data Source =..\..\..\Data\ZooManagmentSystem.db;Version=3;"; //C:\Users\Admin\source\repos\ZooManagment\ZooManagment\Data\ZooManagmentSystem.db
        
        public static void InitializeDatabase()
        {
            if (!File.Exists(@"..\..\..\Data\ZooManagmentSystem.db"))
            {
                SQLiteConnection.CreateFile(@"..\..\..\Data\ZooManagmentSystem.db");
            }
            using (var conn = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand cmnd = new SQLiteCommand())
                {
                    conn.Open();
                    cmnd.Connection = conn;
                    string strSql = @"BEGIN TRANSACTION;
                        DROP TABLE IF EXISTS ACCOUNT;
                        DROP TABLE IF EXISTS TASK;
                        DROP TABLE IF EXISTS EVENTLOG;
                    COMMIT;";
                    cmnd.CommandText = strSql;
                    cmnd.ExecuteNonQuery();
                    string table = @"CREATE TABLE [ACCOUNT] 
                    (
                          [employeeID] INTEGER PRIMARY KEY NOT NULL
                        , [email] INTEGER NOT NULL
                        , [password] INTEGER NOT NULL
                        , [type] TEXT NOT NULL
                    );";
                    cmnd.CommandText = table;
                    cmnd.ExecuteNonQuery();
                    table = @"CREATE TABLE [TASK] 
                    (
                          [taskID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
                        , [employeeID] INTEGER FORGIEN KEY
                        , [name] TEXT NOT NULL
                        , [priority] TEXT NOT NULL
                        , [location] TEXT NOT NULL
                        , [comments] MEDIUMTEXT
                        , [status] BOOL NOT NULL
                    );";
                    cmnd.CommandText = table;
                    cmnd.ExecuteNonQuery();
                    table = @"CREATE TABLE [EVENTLOG] 
                    (
                          [eventID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
                        , [employeeID] INTEGER FORGIEN KEY
                        , [event] TEXT NOT NULL
                        , [time] DATETIME NOT NULL
                    );";
                    cmnd.CommandText = table;
                    cmnd.ExecuteNonQuery();
                    strSql = @"BEGIN TRANSACTION;
                        INSERT INTO ACCOUNT (employeeID, email, password, type) VALUES (1, $hashemail1, $hashpwd1, 'keeper');
                        INSERT INTO ACCOUNT (employeeID, email, password, type) VALUES (90000000, $hashemail2, $hashpwd2, 'manager');
                        INSERT INTO TASK (employeeID, name, priority, location, comments, status) VALUES (1, 'anderson', 'Important', 'Building AE1', NULL, FALSE);
                        INSERT INTO TASK (employeeID, name, priority, location, comments, status) VALUES (1, 'anderson', 'Low', 'Building AE2', 'please complete after completing your first task', FALSE);
                    COMMIT;";
                    cmnd.CommandText = strSql;
                    string email1 = "danderson@zoonew.org";
                    string pwd1 = "1qaz";
                    string email2 = "akendra@zoonew.org";
                    string pwd2 = "2wsx";
                    int x1 = email1.GetHashCode();
                    int y1 = pwd1.GetHashCode();
                    int x2 = email2.GetHashCode();
                    int y2 = pwd2.GetHashCode();
                    cmnd.Parameters.AddWithValue("$hashemail1", x1);
                    cmnd.Parameters.AddWithValue("$hashpwd1", y1);
                    cmnd.Parameters.AddWithValue("$hashemail2", x2);
                    cmnd.Parameters.AddWithValue("$hashpwd2", y2);
                    cmnd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
        public static Account GetUser(string email, string pwd)
        {
            if (!File.Exists(@"..\..\..\Data\ZooManagmentSystem.db"))
            {
                throw new Exception("Database not Initialized");
            }
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                int x = email.GetHashCode();
                int y = pwd.GetHashCode();
                string stm = @"SELECT[employeeID]
                    ,[type]
                    ,[email]
                    ,[password]
                    FROM[ACCOUNT]
                    WHERE[email] == ($name)
                    AND[password] == ($pd)
                ;";
                using (SQLiteCommand cmnd = new SQLiteCommand(stm, conn))
                {
                    cmnd.Parameters.AddWithValue("$name", x);
                    cmnd.Parameters.AddWithValue("$pd", y);
                    using (SQLiteDataReader rdr = cmnd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Account acct = new Account(rdr.GetInt32(0), email, pwd);
                            return acct;
                        }
                        Account act = new Account(0, null, null);
                        return act;
                    }
                }
            }
        }
        public static List<Tasks> getTasks(Account account)
        {
            if (!File.Exists(@"..\..\..\Data\ZooManagmentSystem.db"))
            {
                throw new Exception("Database not Initialized");
            }
            List<Tasks> tasklist = new List<Tasks>();
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand cmnd = new SQLiteCommand())
                {
                    conn.Open();
                    cmnd.Connection = conn;
                    cmnd.CommandText = "SELECT * FROM TASK;";
                    using (SQLiteDataReader rdr = cmnd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            tasklist.Add(new Tasks(rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetBoolean(6)));
                        }
                    }
                }
            }
            return tasklist;
        }
        public static void newTask(Tasks task)
        {
            if (!File.Exists(@"..\..\..\Data\ZooManagmentSystem.db"))
            {
                throw new Exception("Database not Initialized");
            }
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand cmnd = new SQLiteCommand())
                {
                    conn.Open();
                    cmnd.Connection = conn;
                    int employeeID = task.KeeperID;
                    string name = task.Name;
                    string priority = task.Priority;
                    string location = task.Location;
                    string comments = task.Comment;
                    bool status = task.Status;
                    string stm = @"BEGIN TRANSACTION;
                                INSERT INTO TASK (employeeID, name, priority, location, comments, status) VALUES ($employeeID, $name, $priority, $location, $comments, $status)
                                COMMIT;";
                    cmnd.CommandText = stm;
                    cmnd.Parameters.AddWithValue("$name", name);
                    cmnd.Parameters.AddWithValue("$priority", priority);
                    cmnd.Parameters.AddWithValue("$location", location);
                    cmnd.Parameters.AddWithValue("$comments", comments);
                    cmnd.Parameters.AddWithValue("$status", status);
                    cmnd.ExecuteNonQuery();
                }
            }
        }
        public static void setTask(Tasks task)
        {
            if (!File.Exists(@"..\..\..\Data\ZooManagmentSystem.db"))
            {
                throw new Exception("Database not Initialized");
            }
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                int taskID = task.TaskID;
                int employeeID = task.KeeperID;
                string name = task.Name;
                string priority = task.Priority;
                string location = task.Location;
                string comments = task.Comment;
                bool status = task.Status;
                string stm = @"UPDATE TASK
                    SET 
                    employeeID = $employeeID
                    ,name = $name
                    ,status = $status
                    ,priority = $priority
                    ,location = $location
                    ,comments = $commments
                    WHERE taskID = $taskID
                ;";
                using (SQLiteCommand cmnd = new SQLiteCommand(stm, conn))
                {
                    cmnd.Parameters.AddWithValue("$taskID", taskID);
                    cmnd.Parameters.AddWithValue("$name", name);
                    cmnd.Parameters.AddWithValue("$priority", priority);
                    cmnd.Parameters.AddWithValue("$location", location);
                    cmnd.Parameters.AddWithValue("$comments", comments);
                    cmnd.Parameters.AddWithValue("$status", status);
                    cmnd.ExecuteNonQuery();
                }
            }
        }
        public static void SaveLogin(Account account)
        {
            if (!File.Exists(@"..\..\..\Data\ZooManagmentSystem.db"))
            {
                throw new Exception("Database not Initialized");
            }
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                DateTime time = DateTime.Now;
                string t = time.ToString("s");
                int eventID = 0;
                string _event = "login";
                int hash = account.Email.GetHashCode();
                string stm = "SELECT [employeeID] FROM ACCOUNT WHERE email = ($email);";
                using (SQLiteCommand cmnd = new SQLiteCommand(stm, conn))
                {
                    cmnd.Parameters.AddWithValue("$email", hash);
                    using (SQLiteDataReader rdr = cmnd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            eventID = rdr.GetInt32(0);
                        }
                    }
                }
                stm = @"INSERT INTO LOGIN VALUES($eventID, $event, $time);";
                using (SQLiteCommand cmnd = new SQLiteCommand())
                {
                    cmnd.Connection = conn;
                    cmnd.CommandText = stm;
                    cmnd.Parameters.AddWithValue("$id", eventID);
                    cmnd.Parameters.AddWithValue("$event", _event);
                    cmnd.Parameters.AddWithValue("$time", t);
                    cmnd.ExecuteNonQuery();
                }
            }
        }
        public static void SaveLogout(Account account)
        {
            if (!File.Exists(@"..\..\..\Data\ZooManagmentSystem.db"))
            {
                throw new Exception("Database not Initialized");
            }
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                DateTime time = DateTime.Now;
                string t = time.ToString("s");
                int eventID = 0;
                string _event = "logout";
                int hash = account.Email.GetHashCode();
                string stm = "SELECT [employeeID] FROM ACCOUNT WHERE email = ($email);";
                using (SQLiteCommand cmnd = new SQLiteCommand(stm, conn))
                {
                    cmnd.Parameters.AddWithValue("$email", hash);
                    using (SQLiteDataReader rdr = cmnd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            eventID = rdr.GetInt32(0);
                        }
                    }
                }
                stm = @"INSERT INTO LOGIN VALUES($eventID, $time);";
                using (SQLiteCommand cmnd = new SQLiteCommand())
                {
                    cmnd.Connection = conn;
                    cmnd.CommandText = stm;
                    cmnd.Parameters.AddWithValue("$id", eventID);
                    cmnd.Parameters.AddWithValue("$event", _event);
                    cmnd.Parameters.AddWithValue("$time", t);
                    cmnd.ExecuteNonQuery();
                }
            }
        }
    }
}

