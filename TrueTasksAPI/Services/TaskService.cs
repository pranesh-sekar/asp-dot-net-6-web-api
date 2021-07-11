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

        public void addTask(Task data)
        {
            this._AddTask(data);
            this._CommitChanges();
        }

        public void UpdateTask(Task data)
        {
            Task task = this._GetTask(data.Id);
            if (task == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, ErrorConstants.NotFound);
            }
            this._UpdateTask(task, data);
            this._CommitChanges();
        }

        public void RemoveTask(int id)
        {
            Task task = this._GetTask(id);
            if (task == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, ErrorConstants.NotFound);
            }
            this._RemoveTask(task);
            this._CommitChanges();
        }

        private List<Task> _GetAllTasks()
        { 
            return _context.Tasks.ToList();
        }

        private Task _GetTask(int id)
        {
            return _context.Tasks.FirstOrDefault(task => task.Id == id);
        }

        private void _AddTask(Task data)
        {
            Task newTask = new Task()
            {
                Name = data.Name,
                Description = data.Description,
                Status = data.Status
            };
            _context.Tasks.Add(newTask);
        }

        private void _UpdateTask(Task task, Task data)
        {
            task.Name = data.Name;
            task.Description = data.Description;
            task.Status = data.Status;
        }

        private void _RemoveTask(Task task)
        {
            _context.Tasks.Remove(task);
        }

        private void _CommitChanges()
        {
            _context.SaveChanges();
        }
    }
}
