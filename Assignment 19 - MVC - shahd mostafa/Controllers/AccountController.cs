using Assignment_19___MVC___shahd_mostafa.Models;
using Demo.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace Assignment_19___MVC___shahd_mostafa.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser>userManager , SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new AppUser
            {
                Email = model.Email,
                UserName = model.UserName,
                FirstName=model.FirstName,
                LastName=model.LastName,
            };
            var result= await _userManager.CreateAsync(user,model.Password);

            if(result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var validEmail = new EmailAddressAttribute().IsValid(model.Email);
            var user = validEmail ? await _userManager.FindByEmailAsync(model.Email) :
                await _userManager.FindByNameAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Email or Password");
                return View(model);
            }

            var IsValidPassword=await _userManager.CheckPasswordAsync(user, model.Password);
            if (!IsValidPassword)
            {
                ModelState.AddModelError("", "Invalid Password");
                return View(model);

            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password,model.RememberMe,false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid Email Or Password");
            return View(model);

        }
    }
}
