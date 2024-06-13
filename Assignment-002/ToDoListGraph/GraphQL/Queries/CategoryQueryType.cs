using HotChocolate.Types;
using ToDoListGraphQL.GraphQL.Type;
using ToDoListGraphQL.Models;
using ToDoListGraphQL.Repositories.Interfaces;

namespace ToDoListGraphQL.GraphQL.Queries
{
    public static class CategoryQueryType
    {
        public static IObjectFieldDescriptor AddCategoryQueries(this IObjectTypeDescriptor descriptor)
        {
            return descriptor
            .Field("categories")
                .Type<ListType<CategoryType>>()
                .Resolve(async ctx =>
                {
                    var categoryRepository = ctx.Service<ICategoryRepository>();
                    return await categoryRepository.GetAllCategories();
                });

        }
    }
}
