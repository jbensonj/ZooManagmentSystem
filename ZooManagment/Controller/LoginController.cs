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
