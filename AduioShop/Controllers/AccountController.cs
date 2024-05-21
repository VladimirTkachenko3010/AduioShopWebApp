using AudioShop.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AudioShop.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILogger log;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager,
                                SignInManager<User> signInManager,
                                RoleManager<IdentityRole> roleManager,
                                ILoggerFactory Log)
        {
            this.log = Log.CreateLogger(">>> Мой Logger ");
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            log.LogWarning($" ------- \n >> Login(string returnUrl) сработал, returnUrl = {returnUrl}\n ------- \n ");
            return View(new UserLogin());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.LoginProp,
                    model.Password,
                    false,
                    lockoutOnFailure: false);

                if (loginResult.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.LoginProp);
                    if (user != null)
                    {
                        var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                        ViewBag.IsAdmin = isAdmin;
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
            }
            ModelState.AddModelError("", "Користувач не знайдений");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserRegistration());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.LoginProp,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname
                };

                var createResult = await _userManager.CreateAsync(user, model.Password);
                if (createResult.Succeeded)
                {
                    if ((model.Email == "vladimirtkachenko434@gmail.com") && (model.LoginProp == "vtkachenko"))
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var identityError in createResult.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }
                return View(model);
            }
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
