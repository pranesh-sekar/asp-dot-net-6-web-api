using AutoMapper;
using TrueTasksAPI.Models;
using TrueTasksAPI.ViewModels;

namespace TrueTasksAPI.Profiles
{
    public class TaskProfile: Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskViewModel>()
                  .ReverseMap();
        }
    }
}
