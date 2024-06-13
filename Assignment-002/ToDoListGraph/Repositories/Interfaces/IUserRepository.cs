using ToDoListGraphQL.Models;

namespace ToDoListGraphQL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User?> DeleteUser(int id);
    }
}
