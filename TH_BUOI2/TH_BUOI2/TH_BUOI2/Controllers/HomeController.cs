using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TH_BUOI2.DataAcess;
using TH_BUOI2.Models;
using TH_BUOI2.Repositories;

namespace TH_BUOI2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		private readonly IProductRepository _productRepository;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IProductRepository productRepository)
        {
            _logger = logger;
			_context = context;
			_productRepository = productRepository;
		}

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

		public IActionResult AboutUs()
		{
			return View();
		}
		public IActionResult ContactUs()
		{
			return View();
		}
	}
}