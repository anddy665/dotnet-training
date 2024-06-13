using HotChocolate.Types;
using ToDoListGraphQL.Models;
using ToDoListGraphQL.Repositories.Interfaces;
using ToDoListGraphQL.GraphQL.Type;

namespace ToDoListGraphQL.GraphQL.Mutations
{
    public static class CategoryMutationType
    {
        public static void AddCategoryMutations(this IObjectTypeDescriptor descriptor)
        {
            descriptor
                .Field("addCategory")
                .Argument("category", a => a.Type<NonNullType<CreateCategoryInputType>>())
                .Type<CategoryType>()
                .Resolve(async ctx =>
                {
                    var categoryRepository = ctx.Service<ICategoryRepository>();
                    var categoryInput = ctx.ArgumentValue<Category>("category");
                    var category = new Category
                    {
                        Name = categoryInput.Name
                    };
                    return await categoryRepository.AddCategory(category);
                });

            descriptor
                .Field("updateCategory")
                .Argument("category", a => a.Type<NonNullType<CreateCategoryInputType>>())
                .Type<CategoryType>()
                .Resolve(async ctx =>
                {
                    var categoryRepository = ctx.Service<ICategoryRepository>();
                    var categoryInput = ctx.ArgumentValue<Category>("category");
                    var category = await categoryRepository.GetCategoryById(categoryInput.id);
                    if (category != null)
                    {
                        category.Name = categoryInput.Name;
                        return await categoryRepository.UpdateCategory(category);
                    }
                    return null;
                });

            descriptor
                .Field("deleteCategory")
                .Argument("id", a => a.Type<NonNullType<IdType>>())
                .Type<CategoryType>()
                .Resolve(async ctx =>
                {
                    var categoryRepository = ctx.Service<ICategoryRepository>();
                    var id = ctx.ArgumentValue<int>("id");
                    return await categoryRepository.DeleteCategory(id);
                });
        }
    }
}
