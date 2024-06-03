using ToDoListWithLambdaAndLinq.Data;
using ToDoListWithLambdaAndLinq.Interfaces;
using ToDoListWithLambdaAndLinq.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoListWithLambdaAndLinq.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly NotesAppContext _context;

        public CategoryService(NotesAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return (from category in _context.Categories
                    where category.Id == categoryId
                    select category).FirstOrDefault();
        }

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
