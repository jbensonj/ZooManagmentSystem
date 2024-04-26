using System;
using System.Collections.Generic;
using ZooManagment.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ZooManagment.Controller
{
    public static class LoginController
    {
        //<Summary>//
        //First Validates input then gets the account from database. Finally authenticate the user and return true or false//
        public static bool Login(string email, string pwd)
        {
            if (ValidateInput(email, pwd))
            {
                Account account = DBConnector.GetUser(email, pwd);
                if (Authenticate(account))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //<Summary>//
        //Validats Input for the login form//
        private static bool ValidateInput(string email, string pwd)
        {
            char[] danger = { '\\', '\0', '\n', '\r', '\'', '\"', ';', '=' }; //blacklist of values
            foreach (char c in email)
            {
                for (int i = 0; i < danger.Length; i++)
                {
                    if (c == danger[i])
                        return false;
                }
            }
            foreach (char c in pwd)
            {
                for (int i = 0; i < danger.Length; i++)
                {
                    if (c == danger[i])
                        return false;
                }
            }
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pwd) || !email.EndsWith("@zoonew.org"))
            {
                return false;
            }
            return true;
        }
        //<Summary>//
        //Authenticates user by showing that they have an email with an associated EmployeeID//
        private static bool Authenticate(Account account)
        {
            if (account.Email != null && account.EmployeeID > 0)
            {
                return true;
            }
            return false;
        }
    }
}
