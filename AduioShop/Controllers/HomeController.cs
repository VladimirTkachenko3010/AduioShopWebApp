using AudioShop.Data.Interfaces;
using AudioShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AudioShop.Controllers
{
    public class HomeController : Controller
    {
        private IAllProducts _productRepository;
        public HomeController(IAllProducts productRepository)
        {
            _productRepository = productRepository;
        }
        public ViewResult Index()
        {
            var homeProducts = new HomeViewModel
            {
                favProducts = _productRepository.getFavorite
            };
            return View(homeProducts);
        }
    }
}
