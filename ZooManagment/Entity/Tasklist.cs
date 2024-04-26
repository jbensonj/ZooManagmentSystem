using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZooManagment.Entity
{
    public class Tasklist
    {
        private List<Tasks> _tasklist = new List<Tasks>();
        public IReadOnlyList<Tasks> GetTasklist => _tasklist;
        //<Summary>//
        //Allows other classes to add to the tasklist by simply specify the tasklist and then passing a task into the add fuction//
        public void Add(Tasks task)
        {
            _tasklist.Add(task);
        }
    }
}
