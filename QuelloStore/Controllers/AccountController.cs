using QuelloStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuelloStore.ViewModels;
using System.Net.Mail;
using System.Security.Claims;

namespace QuelloStore.Controllers;
public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInManager<Usuario> _signInMananger;
        private readonly UserManager<Usuario> _userManager;
        private readonly IWebHostEnvironment _host;

        public AccountController(
            ILogger<AccountController> logger,
            SignInManager<Usuario> signInmanager,
            UserManager<Usuario> userManager,
            IWebHostEnvironment host
            )
        {
            _logger = logger;
            _signInMananger = signInmanager;
            _userManager = userManager;
            _host = host;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
    {
        LoginVM login = new()
        {
            UrlRetorno = returnUrl ?? Url.Content("~/")
        };
        return View(login);
    }

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Login(LoginVM login)
{
    if (ModelState.IsValid)
    {
        string userName = login.Email;
        if (IsValidEmail(login.Email))
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null)
            userName = user.UserName;
        }
    
    var result = await _signInMananger.PasswordSignInAsync(
        userName, login.Senha, login.Lembrar, lockoutOnFailure: true
    );

    if (result.Succeeded) {
        _logger.LogInformation($"Usuário {login.Email} acessou o sistema");
        return LocalRedirect(login.UrlRetorno);
    }

    if (result.IsLockedOut) {
        _logger.LogWarning($"Usuário {login.Email} está bloqueado");
        ModelState.AddModelError("", "sua conta está bloqueada, aguarde alguns minutos e tente novamente!!");
    }
    else
    if (result.IsNotAllowed) {
        _logger.LogWarning($"Usuário {login.Email} não confirmou sua conta");
        ModelState.AddModelError(string.Empty, "sua conta não está confirmada, verifique seu email!!");
    }
    else 
        ModelState.AddModelError(string.Empty, "Usuário e/ou senha inválidos!!!");
    }
    return View(login);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Logout()
{
    _logger.LogInformation($"Usuário {ClaimTypes.Email} fez logoff");
    await _signInMananger.SignOutAsync();
    return RedirectToAction("Index", "Home");
}

public bool IsValidEmail(string email)
{
    try
    {
        MailAddress m = new(email);
        return true;
    }
    catch (FormatException)
        {
            return false;
        }
    }

}