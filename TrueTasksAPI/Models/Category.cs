using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrueTasksAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
