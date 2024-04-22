using System;
using System.Collections.Generic;
using ZooManagment.Entity;
using ZooManagment.Controller;

namespace ZooManagment.Controller
{
    public static class LoginController
    {
        public static bool Login(string email, string pwd)
        {
            if (ValidateInput(email, pwd))
            {
                Account account = DBConnector.GetUser(email, pwd);
                if (AuthenticateAccount(account))
                {
                    MessageBox.Show("Login Successful");
                    return true;
                }
                else
                {
                    MessageBox.Show("Login Failed. Please check your credentials and try again.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please ensure the email and password are correctly formatted.");
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
        private static bool AuthenticateAccount(Account account)
        {
            if (account.Email != null && account.EmployeeID > 0)
            {
                return true;
            }
            return false;
        }
    }
}
