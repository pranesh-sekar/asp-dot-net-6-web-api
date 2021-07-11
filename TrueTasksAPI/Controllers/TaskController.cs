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
            var  allTasks = _taskService.GetAllTasks();
            var data = _mapper.Map<IEnumerable<TaskViewModel>>(allTasks);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var task = _taskService.GetTask(id);
            if (task == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<TaskViewModel>(task);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(TaskViewModel taskViewModel) 
        {
            var task = _mapper.Map<Task>(taskViewModel);
            _taskService.addTask(task);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(TaskViewModel taskViewModel)
        {
            var task = _mapper.Map<Task>(taskViewModel);
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
