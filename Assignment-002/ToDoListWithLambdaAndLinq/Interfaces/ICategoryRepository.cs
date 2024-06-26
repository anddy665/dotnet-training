﻿using ToDoListWithLambdaAndLinq.Models;

namespace ToDoListWithLambdaAndLinq.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
