using Banking_Operations.Data;
using Banking_Operations.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Banking_Operations.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Client> _clientManager;
        private readonly SignInManager<Client> _signInManager;
        private readonly ApplicationDBContext _appDBContext;

        public AccountController(UserManager<Client> clientManager, SignInManager<Client> signInManager, ApplicationDBContext appDBContext)
        {
            _clientManager = clientManager;
            _signInManager = signInManager;
            _appDBContext = appDBContext;
        }

        public IActionResult Login()
        {
            var response = new LoginModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid) return View(loginModel);
            var client = await _clientManager.FindByEmailAsync(loginModel.Email);
            if (client != null)
            {
                //Если пользовователь найден ищется пароль
                var passwordCheck = await _clientManager.CheckPasswordAsync(client, loginModel.Password);
                if (passwordCheck)
                {
                    //Пароль найден, передрисация
                    var result = await _signInManager.PasswordSignInAsync(client, loginModel.Password, false, false);
                    if (result.Succeeded)
                    { 
                        return RedirectToAction("Index", "Home");
                    }
                }
                //Пароль не найден
                TempData["Error"] = "Пароль неправильный.";
                return View(loginModel);
            }
            //Пользователь не найден
            TempData["Error"] = "Почта не верна.";
            return View(loginModel);
        }

    }
}
