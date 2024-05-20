using Product_Management.Interfaces;

namespace Product_Management.Services
{
    public class AuthService : IAuthService
    {
        private const string UsuarioCorrecto = "admin";
        private const string ContraseñaCorrecta = "admin123";

        public bool ValidateUser(string username, string password)
        {
            return username == UsuarioCorrecto && password == ContraseñaCorrecta;
        }
    }
}
