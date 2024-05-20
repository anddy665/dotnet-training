using Microsoft.AspNetCore.Mvc;
using Product_Management.Interfaces;

namespace Product_Management.Controllers;

public class AccountController : Controller
{
    private readonly IAuthService _authService;

    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string user, string password)
    {
        if (_authService.ValidateUser(user, password))
        {
            return RedirectToAction("Index", "Product");
        }
        ViewBag.Message = "Usuario o contraseña incorrectos.";
        return View();
    }
}
