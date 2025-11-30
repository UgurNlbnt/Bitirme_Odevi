using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesiCarReservation.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStaticticsComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
