using Product_Management.Models;

namespace Product_Management.Interfaces
{
    public interface IAuthService
    {
        bool ValidateUser(string username, string password);
        User GetUserByUsername(string username);
        void RegisterUser(User user);
    }
}
