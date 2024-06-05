using ToDoListWithLambdaAndLinq.Data;
using ToDoListWithLambdaAndLinq.Interfaces;
using ToDoListWithLambdaAndLinq.Models;

namespace ToDoListWithLambdaAndLinq.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NotesAppContext _context;

        public CategoryRepository(NotesAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            var category = (from c in _context.Categories
                            where c.Id == categoryId
                            select c).FirstOrDefault();

            if (category == null)
            {
                throw new Exception($"Category with ID {categoryId} not found.");
            }

            return category;
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
