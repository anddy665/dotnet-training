using ToDoListWithLambdaAndLinq.Models;
using System.Collections.Generic;

namespace ToDoListWithLambdaAndLinq.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);

    }
}
