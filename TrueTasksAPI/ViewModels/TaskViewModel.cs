using TrueTasksAPI.Models;

using System.ComponentModel.DataAnnotations;

namespace TrueTasksAPI.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(TaskStatus))]
        public TaskStatus Status { get; set; }

        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
