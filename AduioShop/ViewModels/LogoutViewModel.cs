using Microsoft.AspNetCore.Mvc;

namespace AudioShop.ViewModels
{
    public class LogoutViewModel : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
