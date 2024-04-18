using Microsoft.AspNetCore.Mvc;

namespace AudioShop.ViewModels
{
    [ViewComponent]
    public class LogoutViewModel: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
