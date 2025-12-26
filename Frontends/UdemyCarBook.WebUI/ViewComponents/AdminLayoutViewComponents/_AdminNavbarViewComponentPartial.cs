using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminNavbarViewComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AdminNavbarViewComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user != null)
            {
                ViewBag.Name = $"{user.Name} {user.Surname}";
            }
            else
            {
                ViewBag.Name = "Admin";
            }
            return View();
        }
    }
}
