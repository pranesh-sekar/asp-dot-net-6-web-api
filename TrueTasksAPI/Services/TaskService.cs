using System.Linq;
using System.Net;
using System.Collections.Generic;
using TrueTasksAPI.Properties;
using TrueTasksAPI.Helpers;
using TrueTasksAPI.Models;
using TrueTasksAPI.Data;

namespace TrueTasksAPI.Services
{
    public class TaskService
    {
        private AppDbContext _context;
        public TaskService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public List<Task> GetAllTasks()
        {
            return this._GetAllTasks();
        }

        public Task GetTask(int id)
        {
            var task = this._GetTask(id);
            if (task == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, ErrorConstants.NotFound);
            }
            return task;
        }

        public void addTask(Task obj)
        {
            Task newTask = new Task()
            {
                Name = obj.Name,
                Description = obj.Description,
                Status = obj.Status
            };
            _context.Tasks.Add(newTask);
            _context.SaveChanges();
        }

        public void updateTask(Task obj)
        {
            Task task = this._GetTask(obj.Id);
            if (task == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, ErrorConstants.NotFound);
            }
            task.Name = obj.Name;
            task.Description = obj.Description;
            task.Status = obj.Status;
            
            _context.SaveChanges();
        }

        public void RemoveTask(int id)
        {
            Task task = this._GetTask(id);
            if (task == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, ErrorConstants.NotFound);
            }
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        private List<Task> _GetAllTasks()
        { 
            return _context.Tasks.ToList();
        }

        private Task _GetTask(int id)
        {
            return _context.Tasks.FirstOrDefault(task => task.Id == id);
        }


    }
}
