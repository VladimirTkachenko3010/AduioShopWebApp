﻿using AudioShop.Data.Interfaces;
using AudioShop.Data.Models;
using AudioShop.Database;
using AudioShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AudioShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IProductsCategory _categoryService;
        private readonly IAllProducts _allProducts;
        private readonly AudioShopDBContext _audioShopDBContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ProductImagesRepository _productImagesRepository;


        public AdminController(UserManager<User> userManager, IProductsCategory categoryService,
            IAllProducts allProducts, AudioShopDBContext audioShopDBContext, IWebHostEnvironment webHostEnvironment, ProductImagesRepository productImagesRepository)
        {
            _userManager = userManager;
            _categoryService = categoryService;
            _allProducts = allProducts;
            _audioShopDBContext = audioShopDBContext;
            _webHostEnvironment = webHostEnvironment;
            _productImagesRepository = productImagesRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region ToDo create category funcs

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

        #endregion


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
            ModelState.Remove("Product.ImageUrls");

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
                    //ImageUrls = model.Product.ImageUrls
                };

                _allProducts.AddProduct(product);

                #region img test

                int i = 1;
                if (model.Images != null && model.Images.Count > 0)
                {
                    var productImages = new List<ProductImages>();
                    foreach (var image in model.Images)
                    {
                        if (image != null && image.Length > 0)
                        {
                            var fileName = $"{model.Product.Name}-{model.Images.IndexOf(image) + 1}.jpg";

                            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "img", $"{model.Product.ProductType}", model.Product.Name);
                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            var filePath = Path.Combine(folderPath, fileName);


                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await image.CopyToAsync(fileStream);
                            }

                            productImages.Add(new ProductImages()
                            {
                                ImageUrls = $"/img/{model.Product.ProductType}/{model.Product.Name}/{fileName}",
                                ProductId = product.Id,
                                Name = $"{product.Name}-{i}.jpg",
                            });
                            i++;
                        }
                    }
                    _productImagesRepository.AddListProductImages(productImages);

                }

                #endregion

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
            var productImages = _productImagesRepository.GetProductImagesByProductId(id);

            product.ImageUrls = productImages.Select(pi => new ProductImages
            {
                Name = pi.Name,
                ImageUrls = $"/{Path.Combine("img", product.ProductType, product.Name)}/{Path.GetFileName(pi.Name)}"
            }).ToList();
            var model = new ProductEditViewModel
            {
                Product = product,
                DeletedImageUrls = new List<bool>(),
                CategoriesList = _categoryService.AllCategories.ToList()
            };

            return View(model);
        }

        // POST: Admin/EditProduct
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductEditViewModel model, [FromForm] List<string> DeletedImageUrls)
        {
            #region removes
            ModelState.Remove("DeletedImageUrls");
            ModelState.Remove("CategoriesList");
            ModelState.Remove("Product.Category");
            ModelState.Remove("Product.SearchTerm");
            ModelState.Remove("Product.SearchTerm");
            ModelState.Remove("Product.ImageUrls");
            ModelState.Remove("Images");

            #endregion

            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = model.Product.Id,
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

                if (DeletedImageUrls != null)
                {

                    DeletedImageUrls = DeletedImageUrls.Select(url => url.Replace("\\", "/")).ToList();
                    Console.WriteLine("DeletedImageUrls:");
                    foreach (var url in DeletedImageUrls)
                    {
                        Console.WriteLine(url);
                    }
                    await DeleteSelectedImages(model, product, DeletedImageUrls);
                }

                if (model.Images != null && model.Images.Count > 0)
                {
                    await SaveProductImagesAsync(model, product, DeletedImageUrls);
                }

                await _allProducts.UpdateProductAsync(product);

                return RedirectToAction("Catalog", "Products");
            }

            ViewBag.ErrorMessages = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return View(model);
        }


        private async Task SaveProductImagesAsync(ProductEditViewModel model, Product product, List<string> deletedImageUrls)
        {
            var productImages = new List<ProductImages>();
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "img", model.Product.ProductType, model.Product.Name);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            int deletedIndex = 0;
            foreach (var image in model.Images)
            {
                if (image != null && image.Length > 0)
                {
                    string fileName;
                    if (deletedIndex < deletedImageUrls.Count)
                    {
                        var deletedUrl = deletedImageUrls[deletedIndex];
                        fileName = Path.GetFileName(deletedUrl);
                        deletedIndex++;
                    }
                    else
                    {
                        fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    }
                    var filePath = Path.Combine(folderPath, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                    var imageUrl = $"/img/{model.Product.ProductType}/{model.Product.Name}/{fileName}".Replace("\\", "/");

                    productImages.Add(new ProductImages
                    {
                        ImageUrls = imageUrl,
                        ProductId = product.Id,
                        Name = fileName,
                    });
                }
            }

            _productImagesRepository.AddListProductImages(productImages);
        }

        private async Task DeleteSelectedImages(ProductEditViewModel productViewModel, Product product, List<string> deletedImageUrls)
        {
            if (deletedImageUrls == null || !deletedImageUrls.Any())
                return;

            var productImages = _productImagesRepository.GetProductImagesByProductId(productViewModel.Product.Id);

            var imagesToDelete = productImages
               .Where(img => deletedImageUrls.Contains(img.ImageUrls.Replace("\\", "/")))
               .ToList();

            foreach (var imageToDelete in imagesToDelete)
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, imageToDelete.ImageUrls.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                _productImagesRepository.DeleteProductImage(imageToDelete);
                //product.ImageUrls.Remove(imageToDelete);
            }

            var updatedProductImages = _productImagesRepository.GetProductImagesByProductId(productViewModel.Product.Id);
            product.ImageUrls = updatedProductImages.Select(pi => new ProductImages
            {
                Name = pi.Name,
                ImageUrls = $"/img/{product.ProductType}/{product.Name}/{pi.Name}".Replace("\\", "/"),
                ProductId = product.Id
            }).ToList();

            _productImagesRepository.UpdateProductImages(product, product.ImageUrls);
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
