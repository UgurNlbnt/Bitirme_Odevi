using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesiCarReservation.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _MainConverUILayoutComponentPartial : ViewComponent
    {
        //arka plan resmi ve ana sayfa ortak kısımlarını tutan viewcomponent
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
