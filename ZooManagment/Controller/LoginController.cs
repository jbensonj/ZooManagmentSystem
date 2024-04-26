using System;
using System.Collections.Generic;
using ZooManagment.Entity;

namespace ZooManagment.Controller
{
    public static class LoginController
    {
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
        private static bool ValidateInput(string email, string pwd)
        {
            char[] danger = {'\\', '\0', '\n', '\r', '\'', '\"', ';', '='}; //blacklist of values
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
