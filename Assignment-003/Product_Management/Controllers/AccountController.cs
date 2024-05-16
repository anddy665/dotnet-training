using Microsoft.AspNetCore.Mvc;

namespace Product_Management.Controllers;

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
            return RedirectToAction("Index", "Product");
        }
        ViewBag.Message = "Usuario o contraseña incorrectos.";
        return View();
    }
}
