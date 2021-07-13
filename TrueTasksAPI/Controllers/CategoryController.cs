using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using TrueTasksAPI.Properties;
using TrueTasksAPI.Models;
using TrueTasksAPI.ViewModels;
using TrueTasksAPI.Services;

namespace TrueTasksAPI.Controllers
{
    [ApiController]
    [Route(ROUTES.CATEGORIES)]
    public class CategoryController : ControllerBase
    {
        private CategoryService _categoryService;
        private IMapper _mapper;

        public CategoryController
            (
                IMapper mapper,
                CategoryService categoryService
            )
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Category> allCategories = _categoryService.GetAllCategories();
            IEnumerable<CategoryViewModel> data = _mapper.Map<IEnumerable<CategoryViewModel>>(allCategories);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Category category = _categoryService.GetCategory(id);
            CategoryViewModel data = _mapper.Map<CategoryViewModel>(category);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(CategoryViewModel categoryViewModel)
        {
            Category category = _mapper.Map<Category>(categoryViewModel);
            _categoryService.AddCategory(category);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(CategoryViewModel categoryViewModel)
        {
            Category category = _mapper.Map<Category>(categoryViewModel);
            _categoryService.UpdateCategory(category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.RemoveCategory(id);
            return Ok();
        }
    }
}
