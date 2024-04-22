using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZooManagment.Entity
{
    public class Tasklist
    {
        private List<Task> _tasklist = new List<Task>();
        public IReadOnlyList<Task> GetTasklist => _tasklist;
        public void Add(Task task)
        {
            _tasklist.Add(task);
        }
    }
}
