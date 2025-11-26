using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesiCarReservation.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial : ViewComponent
    {
        //header ve footer ortak kısımlarını tutan viewcomponent
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
