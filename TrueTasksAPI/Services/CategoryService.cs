using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

using TrueTasksAPI.Data;
using TrueTasksAPI.Models;
using TrueTasksAPI.Helpers;
using TrueTasksAPI.Properties;

namespace TrueTasksAPI.Services
{
    public class CategoryService
    {
        private AppDbContext _context;
        public CategoryService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public List<Category> GetAllCategories()
        {
            return this._GetAllCategories();
        }

        public Category GetCategory(int id)
        {
            Category category = this._GetCategory(id);
            if (category == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, ErrorConstants.NotFound);
            }
            return category;
        }

        public void AddCategory(Category data)
        {
            this._AddCategory(data);
            this._CommitChanges();
        }

        public void UpdateCategory(Category data)
        {
            Category category = this._GetCategory(data.Id);
            if (category == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, ErrorConstants.NotFound);
            }
            this._UpdateCategory(category, data);
            this._CommitChanges();
        }

        public void RemoveCategory(int id)
        {
            Category category = this._GetCategory(id);
            if (category == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, ErrorConstants.NotFound);
            }
            this._RemoveCategory(category);
            this._CommitChanges();
        }



        private List<Category> _GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        private Category _GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(category => category.Id == id);
        }

        private void _AddCategory(Category data)
        {
            Category newCategory = new Category()
            {
                Name = data.Name,
                OrderNumber = data.OrderNumber
            };
            _context.Categories.Add(newCategory);
        }

        private void _UpdateCategory(Category category, Category data)
        {
            category.Name = data.Name;
            category.OrderNumber = data.OrderNumber;
        }

        private void _RemoveCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        private void _CommitChanges()
        {
            _context.SaveChanges();
        }
    }
}
