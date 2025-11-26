using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesiCarReservation.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptUILayoutComponentPartial : ViewComponent
    {
        // CÜSCRİPT ortak kısımlarını tutan viewcomponent
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
