using ToDoListWithLambdaAndLinq.Models;

namespace ToDoListWithLambdaAndLinq.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);

    }
}
