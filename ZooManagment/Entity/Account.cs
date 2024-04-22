using System;
using System.Collections.Generic;

namespace ZooManagment.Entity
{
    public class Account
    {
        private int _employeeID;
        private string _email, _password;
        private readonly string _type;
        public int EmployeeID
        {
            get => _employeeID;
            set
            {
                if (value > 0 && value < int.MaxValue)
                    _employeeID = value;
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (value.EndsWith("@zoonew.org"))
                    _email = value;
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        }
        public string Type
        {
            get { return _type; }
        }
        public Account(int employeeID, string email, string pwd)
        {
            EmployeeID = employeeID;
            Email = email;
            Password = pwd;
            _type = EmployeeID >= 90000000 ?
                "Manager" : "Keeper";
        }
    }
}
