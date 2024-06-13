using Microsoft.EntityFrameworkCore;
using ToDoListGraphQL.Data;
using ToDoListGraphQL.Models;
using ToDoListGraphQL.Repositories.Interfaces;

namespace ToDoListGraphQL.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ToDoListContext _context;

        public CategoryRepository(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> AddCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            return category;
        }
    }
}
