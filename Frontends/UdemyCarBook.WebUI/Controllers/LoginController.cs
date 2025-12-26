using CarBook.Domain.Entities;
using CarBook.ViewModel.ViewModels.LoginViewModels;
using CarBook.ViewModel.ViewModels.RegisterViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace UdemyCarBook.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult LoginAppUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAppUser(LoginAppUserViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "AdminDashboard", new { area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LoginAppUser", "Login");
        }
    }
}
