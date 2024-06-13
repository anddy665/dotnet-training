using ToDoListGraphQL.GraphQL.Type;
using ToDoListGraphQL.Models;
using ToDoListGraphQL.Repositories.Interfaces;

namespace ToDoListGraphQL.GraphQL.Mutations
{
    public static class UserMutationType
    {
        public static void AddUserMutations(this IObjectTypeDescriptor descriptor)
        {
            descriptor
                .Field("addUser")
                .Argument("user", a => a.Type<NonNullType<CreateUserInputType>>())
                .Type<UserType>()
                .Resolve(async ctx =>
                {
                    var userRepository = ctx.Service<IUserRepository>();
                    var userInput = ctx.ArgumentValue<User>("user");
                    var user = new User
                    {
                        Username = userInput.Username,
                        Email = userInput.Email,
                        Password = userInput.Password
                    };
                    return await userRepository.AddUser(user);
                });

            descriptor
                .Field("updateUser")
                .Argument("user", a => a.Type<NonNullType<CreateUserInputType>>())
                .Type<UserType>()
                .Resolve(async ctx =>
                {
                    var userRepository = ctx.Service<IUserRepository>();
                    var userInput = ctx.ArgumentValue<User>("user");
                    var user = await userRepository.GetUserById(userInput.id);
                    if (user != null)
                    {
                        user.Username = userInput.Username;
                        user.Email = userInput.Email;
                        user.Password = userInput.Password;
                        return await userRepository.UpdateUser(user);
                    }
                    return null; 
                });

            descriptor
                .Field("deleteUser")
                .Argument("id", a => a.Type<NonNullType<IdType>>())
                .Type<UserType>()
                .Resolve(async ctx =>
                {
                    var userRepository = ctx.Service<IUserRepository>();
                    var id = ctx.ArgumentValue<int>("id");
                    return await userRepository.DeleteUser(id);
                });
        }
    }
}
