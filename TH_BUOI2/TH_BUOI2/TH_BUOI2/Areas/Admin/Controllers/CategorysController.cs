using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TH_BUOI2.Models;
using TH_BUOI2.Repositories;

namespace TH_BUOI2.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "admin")]
	public class CategorysController : Controller
	{
		private readonly ICategoryRepository _categoryRepository;
		public CategorysController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
		public async Task<IActionResult> Index()
		{
			var category = await _categoryRepository.GetAllAsync();
			return View(category);
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(Category category)
		{

			if (ModelState.IsValid)
			{
				await _categoryRepository.AddAsync(category);
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
			return View(category);
		}

		public async Task<IActionResult> Details(int id)
		{
			var category = await _categoryRepository.GetByIdAsync(id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var category = await _categoryRepository.GetByIdAsync(id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _categoryRepository.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int id)
		{
			var category = await _categoryRepository.GetByIdAsync(id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				await _categoryRepository.UpdateAsync(category);
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}
	}
}
