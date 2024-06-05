using Microsoft.AspNetCore.Mvc;
using ToDoListWithLambdaAndLinq.Interfaces;
using ToDoListWithLambdaAndLinq.Models;

namespace ToDoListWithLambdaAndLinq.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IRegisterRepository _registerRepository;

        public LoginController(ILoginRepository login, IRegisterRepository registerService)
        {
            _loginRepository = login;
            _registerRepository = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login, object exception)
        {
            try
            {

                var token = await _loginRepository.Login(login);
                return Ok(token);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
