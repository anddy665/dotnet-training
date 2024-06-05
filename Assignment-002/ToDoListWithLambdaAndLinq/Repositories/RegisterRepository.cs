using Microsoft.EntityFrameworkCore;
using ToDoListWithLambdaAndLinq.Data;
using ToDoListWithLambdaAndLinq.Interfaces;
using ToDoListWithLambdaAndLinq.Models;

namespace ToDoListWithLambdaAndLinq.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly NotesAppContext _context;

        public RegisterRepository(NotesAppContext context)
        {
            _context = context;
        }

        public async Task RegisterUser(RegisterModel model)
        {
            var userExists = await _context.Users.AnyAsync(u => u.Email == model.Email);

            if (userExists)
            {
                throw new Exception("User already exists");
            }

            var user = new User
            {
                Email = model.Email,
                Password = BCrypt.Net.BCrypt.EnhancedHashPassword(model.Password),
                Username = model.Username,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
