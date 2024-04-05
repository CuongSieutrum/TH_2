using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TH_BUOI2.Models;
using TH_BUOI2.Repositories;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TH_BUOI2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IThuongHieuRepository _huongHieuRepository;
        private readonly IReviewRepository _reviewRepository;
        //Ham constractor (khoi tao)
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, 
            IThuongHieuRepository huongHieuRepository, IReviewRepository reviewRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _huongHieuRepository = huongHieuRepository;
            _reviewRepository = reviewRepository;
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

			var reviews = await _reviewRepository.GetByProductIdAsync(id);
			ViewData["Reviews"] = reviews;

			var reviewCount = reviews.Count();
			var averageRating = reviewCount > 0 ? reviews.Average(r => r.Rating) : 0;

			ViewData["ReviewCount"] = reviewCount;
			ViewData["AverageRating"] = averageRating;

			// Lấy thông tin danh mục liên quan
			var category = await _categoryRepository.GetByIdAsync(product.CategoryId);
            var thuonghieu = await _huongHieuRepository.GetByIdAsync(product.ThuongHieuId);
            // Gán thông tin danh mục vào ViewData
            ViewData["CategoryName"] = category?.Name;
            ViewData["ThuongHieuName"] = thuonghieu?.Name;
            return View(product);
        }

        public async Task<IActionResult> Laptops()
        {
            var products = await _productRepository.GetByLapTopsAsync();
            return View(products);
        }

		public async Task<IActionResult> Smartphones()
		{
			var products = await _productRepository.GetBySmartphonesAsync();
			return View(products);
		}

		public async Task<IActionResult> HotDeals()
		{
			var products = await _productRepository.GetHotDealsAsync();
			return View(products);
		}

		public async Task<IActionResult> Cameras()
		{
			var products = await _productRepository.GetCamerasAsync();
			return View(products);
		}

		[HttpPost]
		public async Task<IActionResult> CreateReview(Review review)
		{
			if (ModelState.IsValid)
			{
				await _reviewRepository.AddAsync(review);
				return RedirectToAction("Details", new { id = review.ProductId });
			}

			return View(review);
		}

	}
}
