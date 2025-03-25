using Assignment_19___MVC___shahd_mostafa.Models;
using Demo.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Assignment_19___MVC___shahd_mostafa.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser>userManager)
        {
            _userManager = userManager;
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
    }
}
