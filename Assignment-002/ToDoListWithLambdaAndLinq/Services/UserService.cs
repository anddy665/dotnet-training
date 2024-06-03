using ToDoListWithLambdaAndLinq.Interfaces;
using ToDoListWithLambdaAndLinq.Models;
using ToDoListWithLambdaAndLinq.Data;

namespace ToDoListWithLambdaAndLinq.Services
{
    public class UserService : IUserService
    {
        private readonly NotesAppContext _context;

        public UserService(NotesAppContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return (from user in _context.Users
                    select user).ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
