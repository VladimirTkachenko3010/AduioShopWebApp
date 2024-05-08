using AudioShop.Data.Interfaces;
using AudioShop.Data.Models;
using AudioShop.Database;
using AudioShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AudioShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IProductsCategory _categoryService;
        private readonly IAllProducts _allProducts;
        private readonly AudioShopDBContext _audioShopDBContext;
        public AdminController(UserManager<User> userManager, IProductsCategory categoryService,
            IAllProducts allProducts, AudioShopDBContext audioShopDBContext)
        {
            _userManager = userManager;
            _categoryService = categoryService;
            _allProducts = allProducts;
            _audioShopDBContext = audioShopDBContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        //// Действия для управления категориями

        //public IActionResult AllCategories()
        //{
        //    var categories = _categoryService.AllCategories;
        //    return View(categories);
        //}

        //public IActionResult CreateCategory()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateCategory(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _categoryService.AddCategory(category);
        //        return RedirectToAction("AllCategories");
        //    }
        //    return View(category);
        //}

        //public IActionResult EditCategory(int id)
        //{
        //    var category = _categoryService.GetCategoryById(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(category);
        //}

        //[HttpPost]
        //public IActionResult EditCategory(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _categoryService.UpdateCategory(category);
        //        return RedirectToAction("AllCategories");
        //    }
        //    return View(category);
        //}

        //[HttpPost]
        //public IActionResult DeleteCategory(int id)
        //{
        //    _categoryService.DeleteCategory(id);
        //    return RedirectToAction("AllCategories");
        //}




        //[Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> AdminPanel()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            ViewBag.IsAdmin = isAdmin;

            return View();
        }

        // GET: Admin/AddProduct
        public IActionResult AddProduct()
        {
            var categories = _categoryService.AllCategories.ToList();
            var model = new ProductEditViewModel
            {
                Product = new Product(),
                CategoriesList = categories
            };
            return View(model);
        }


        // POST: Admin/AddProduct
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductEditViewModel model)
        {
            ModelState.Remove("CategoriesList");
            ModelState.Remove("Product.Category");
            ModelState.Remove("Product.SearchTerm");

            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductType = model.Product.ProductType,
                    Brand = model.Product.Brand,
                    Name = model.Product.Name,
                    Description = model.Product.Description,
                    ShortDesc = model.Product.ShortDesc,
                    Img = model.Product.Img,
                    Price = model.Product.Price,
                    IsFavorite = model.Product.IsFavorite,
                    IsAvailible = model.Product.IsAvailible,
                    CategoryId = model.Product.CategoryId,
                    Category = model.Product.Category,
                    ImageUrls = model.Product.ImageUrls
                };
                #region ToDo добавление фото для слайдера
                //int i = 1;
                //// Сохраняем фотографии
                //if (model.Images != null && model.Images.Count > 0)
                //{
                //    foreach (var image in model.Images)
                //    {
                //        if (image != null && image.Length > 0)
                //        {
                //            // Генерируем уникальное имя для файла
                //            var fileName = $"{model.Product.Name}-{i}.jpg";

                //            // Путь сохранения файла
                //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Path.Combine("img", model.Product.ProductType), fileName);
                //            model.FilePath = filePath;
                //            ViewBag.FilePath = filePath;
                //            // Сохраняем файл
                //            using (var fileStream = new FileStream(filePath, FileMode.Create))
                //            {
                //                await image.CopyToAsync(fileStream);
                //            }

                //            // Добавляем путь к фото в модель продукта
                //            product.ImageUrls.Add($"/img/{model.Product.ProductType}/{fileName}");
                //        }
                //        i++;
                //    }
                //}
                #endregion
                _allProducts.AddProduct(product);
                return RedirectToAction("Catalog", "Products");
            }
            ViewBag.ErrorMessages = ModelState.Values
        .SelectMany(v => v.Errors)
        .Select(e => e.ErrorMessage)
        .ToList();
            return View(model);
        }

        // GET: Admin/EditProduct/{id}
        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await _allProducts.getObjectProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductEditViewModel
            {
                Product = product,
                CategoriesList = _categoryService.AllCategories.ToList()
            };
            return View(model);
        }

        // POST: Admin/EditProduct
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductEditViewModel model)
        {
            ModelState.Remove("CategoriesList");
            ModelState.Remove("Product.Category");
            ModelState.Remove("Product.SearchTerm");

            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = model.Product.Id, // Important: Include the Id when updating
                    ProductType = model.Product.ProductType,
                    Brand = model.Product.Brand,
                    Name = model.Product.Name,
                    Description = model.Product.Description,
                    ShortDesc = model.Product.ShortDesc,
                    Img = model.Product.Img,
                    Price = model.Product.Price,
                    IsFavorite = model.Product.IsFavorite,
                    IsAvailible = model.Product.IsAvailible,
                    CategoryId = model.Product.CategoryId,
                    Category = model.Product.Category,
                    ImageUrls = model.Product.ImageUrls
                };

                await _allProducts.UpdateProductAsync(product);
                return RedirectToAction("Catalog", "Products");
            }

            ViewBag.ErrorMessages = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return View(model);
        }
        // GET: Admin/DeleteProduct/{id}
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _allProducts.getObjectProductAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new ProductEditViewModel
            {
                Product = product
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(ProductEditViewModel model)
        {
            try
            {
                // Retrieve the product from the database
                var productToDelete = await _allProducts.getObjectProductAsync(model.Product.Id);

                if (productToDelete == null)
                {
                    return NotFound();
                }

                // Delete the product from the database
                await _allProducts.DeleteProductAsync(productToDelete);

                return RedirectToAction("Catalog", "Products");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during deletion
                ViewBag.ErrorMessages = new List<string> { ex.Message };
                return RedirectToAction("Catalog", "Products");
            }
        }
    }
}
