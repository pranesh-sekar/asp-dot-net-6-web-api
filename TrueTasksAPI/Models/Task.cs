namespace TrueTasksAPI.Models
{

    public enum TaskStatus
    {
        NOT_COMPLETED,
        COMPLETED
    }

    public class Task
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public TaskStatus Status { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
