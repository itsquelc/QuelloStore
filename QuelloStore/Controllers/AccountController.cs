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
    }
}

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