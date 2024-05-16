using Microsoft.AspNetCore.Mvc;

namespace ProductManagementApp.Controllers
{
    public class AccountController : Controller
    {
        private const string UsuarioCorrecto = "admin";
        private const string ContraseñaCorrecta = "admin123";

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string contraseña)
        {
            if (usuario == UsuarioCorrecto && contraseña == ContraseñaCorrecta)
            {
                // Simulamos un login exitoso
                return RedirectToAction("Index", "Product");
            }
            ViewBag.Message = "Usuario o contraseña incorrectos.";
            return View();
        }
    }
}
