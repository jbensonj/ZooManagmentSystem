using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ZooManagment.Entity
{
    public class Tasks
    {
        private int _taskID, _keeperID;
        private string _name, _priority, _location, _comment;
        private bool _status;

        public int TaskID
        {
            get => _taskID;
            set
            {
                if (value > 0)
                    _taskID = value;
            }
        }
        public int KeeperID
        {
            get => _keeperID;
            set
            {
                if (value > 0 && value < 90000000)
                    _keeperID = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }
        public string Priority
        {
            get => _priority;
            set
            {
                switch (value)
                {
                    case "Important":
                        break;

                    case "Medium":
                        break;

                    case "Low":
                        break;

                    default:
                        throw new Exception("Incorrect Priority Setting");
                }
                _priority = value;
            }
        }
        public string Location
        {
            get => _location;
            set
            {
                _location = value;
            }
        }
        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;
            }
        }
        public bool Status
        {
            get => _status;
            set
            {
                _status = value;
            }
        }
        public Tasks(int keeperID, int id, string name, string priority, string location, string comment, bool status)
        {
            KeeperID = keeperID;
            TaskID = id;
            Name = name;
            Priority = priority;
            Location = location;
            Comment = comment;
            Status = status;
        }
    }
}
