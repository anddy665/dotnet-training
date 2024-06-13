using ToDoListGraphQL.Models;

namespace ToDoListGraphQL.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category?> GetCategoryById(int id);
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category?> DeleteCategory(int id);
    }
}
