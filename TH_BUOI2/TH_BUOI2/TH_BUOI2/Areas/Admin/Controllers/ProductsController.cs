using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using TH_BUOI2.Models;
using TH_BUOI2.Repositories;

namespace TH_BUOI2.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IThuongHieuRepository _huongHieuRepository;
        //Ham constractor (khoi tao)
        public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository, IThuongHieuRepository huongHieuRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _huongHieuRepository = huongHieuRepository;
        }
		public async Task<IActionResult> Add()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var thuongHieus = await _huongHieuRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ViewBag.ThuongHieus = new SelectList(thuongHieus, "Id", "Name");
            return View();
        }
		[HttpPost]
        public async Task<IActionResult> Add(Product product, IFormFile ImageUrl)
        {

            if (ModelState.IsValid)
            {
                if (ImageUrl != null)
                {
                    // Luu anh dai dien
                    product.ImageUrl = await SaveImage(ImageUrl);
                }

                // Use AddAsync or a similar method to add a new product
                await _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            foreach (var modelStateKey in ModelState.Keys)
            {
                var modelStateVal = ModelState[modelStateKey];
                foreach (ModelError error in modelStateVal.Errors)
                {
                    var errorMessage = error.ErrorMessage;
                    var propertyName = modelStateKey;
                }
            }

            var categories = await _categoryRepository.GetAllAsync();
            var thuongHieus = await _huongHieuRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ViewBag.ThuongHieus = new SelectList(thuongHieus, "Id", "Name");
            return View(product);
        }


        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName;
        }

        private async Task<IEnumerable<SelectListItem>> GetCategoriesSelectList()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
        }

		public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }


        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // Lấy thông tin danh mục liên quan
            var category = await _categoryRepository.GetByIdAsync(product.CategoryId);
            var thuonghieu = await _huongHieuRepository.GetByIdAsync(product.ThuongHieuId);
            // Gán thông tin danh mục vào ViewData
            ViewData["CategoryName"] = category?.Name;
            ViewData["ThuongHieuName"] = thuonghieu?.Name;
            return View(product);
        }

        // Show the product update form
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var categories = await _categoryRepository.GetAllAsync();
            var thuongHieus = await _huongHieuRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            ViewBag.ThuongHieus = new SelectList(thuongHieus, "Id", "Name");
            return View(product);
        }

		[HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile newImageUrl)
        {
            if (ModelState.IsValid)
            {
                if (newImageUrl != null)
                {
                    product.ImageUrl = await SaveImage(newImageUrl);
                }
                await _productRepository.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // Lấy thông tin danh mục liên quan
            var category = await _categoryRepository.GetByIdAsync(product.CategoryId);
            var thuonghieu = await _huongHieuRepository.GetByIdAsync(product.ThuongHieuId);
            // Gán thông tin danh mục vào ViewData
            ViewData["CategoryName"] = category.Name;
            ViewData["ThuongHieuName"] = thuonghieu.Name;

            return View(product);
        }


		[HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
