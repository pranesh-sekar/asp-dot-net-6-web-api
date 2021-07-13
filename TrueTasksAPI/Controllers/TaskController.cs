using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TrueTasksAPI.Properties;
using TrueTasksAPI.Models;
using TrueTasksAPI.ViewModels;
using TrueTasksAPI.Services;
using AutoMapper;

namespace TrueTasksAPI.Controllers
{
    [ApiController]
    [Route(ROUTES.TASKS)]
    public class TaskController : ControllerBase
    {

        private TaskService _taskService;
        private IMapper _mapper;

        public TaskController
            (
                IMapper mapper, 
                TaskService taskService
            )
        {
            _mapper = mapper;
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Task> allTasks = _taskService.GetAllTasks();
            IEnumerable<TaskViewModel> data = _mapper.Map<IEnumerable<TaskViewModel>>(allTasks);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Task task = _taskService.GetTask(id);
            TaskViewModel data = _mapper.Map<TaskViewModel>(task);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(TaskViewModel taskViewModel) 
        {
            Task task = _mapper.Map<Task>(taskViewModel);
            _taskService.AddTask(task);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(TaskViewModel taskViewModel)
        {
            Task task = _mapper.Map<Task>(taskViewModel);
            _taskService.UpdateTask(task);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.RemoveTask(id);
            return Ok();
        }
    }

    
}
