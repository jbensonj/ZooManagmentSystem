using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZooManagment.Entity
{
    public class Tasklist
    {
        private List<Tasks> _tasklist = new List<Tasks>();
        public IReadOnlyList<Tasks> GetTasklist => _tasklist;
        public void Add(Tasks task)
        {
            _tasklist.Add(task);
        }
    }
}
