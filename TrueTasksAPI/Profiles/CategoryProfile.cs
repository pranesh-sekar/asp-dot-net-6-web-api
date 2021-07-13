using AutoMapper;
using TrueTasksAPI.Models;
using TrueTasksAPI.ViewModels;

namespace TrueTasksAPI.Profiles
{
    public class CategoryProfile: Profile
    {

        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>()
                  .ReverseMap();
        }
    }
}
