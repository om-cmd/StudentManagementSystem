using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.Controllers
{
    public class UserController : Controller
    {
        //private readonly StudentDbContext _db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        //private readonly RoleManager<IdentityRole> roleManager;

        public UserController(/*StudentDbContext db,*/ UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager/*, RoleManager<IdentityRole> roleManager*/)
        {
            //_db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            //this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = register.UserName,
                    Email = register.Email
                };

                var result = await userManager.CreateAsync(user, register.Password);
                

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Login", "User");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(register);
        }

        //private static string HashPassword(string password)
        //{
        //    using (SHA256 sha256 = SHA256.Create())
        //    {
        //        byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

        //        StringBuilder builder = new StringBuilder();
        //        for (int i = 0; i < hashedBytes.Length; i++)
        //        {
        //            builder.Append(hashedBytes[i].ToString("x2"));
        //        }
        //        return builder.ToString();
        //    }
        //}

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
