using ToDoListGraphQL.GraphQL.Type;
using ToDoListGraphQL.Repositories.Interfaces;

namespace ToDoListGraphQL.GraphQL.Queries
{
    public static class UserQueryType
    {
        public static IObjectFieldDescriptor AddUserQueries(this IObjectTypeDescriptor descriptor)
        {
            return descriptor
            .Field("users")
                .Type<ListType<UserType>>()
                .Resolve(async ctx =>
                {
                    var userRepository = ctx.Service<IUserRepository>();
                    return await userRepository.GetAllUsers();
                });

        }
    }
}
