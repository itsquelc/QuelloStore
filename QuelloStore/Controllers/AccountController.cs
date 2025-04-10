using QuelloStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace QuelloStore.Controllers;

    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly SignInmanager<Usuario> _signInMananger;
        private readonly UserManager<Usuario> _userManager;
        private readonly IWebHostEnvironment _host;

        public AccountController(
            ILogger<AccountController> logger,
            SignInmanager<Usuario> signInmanager,
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

    }
