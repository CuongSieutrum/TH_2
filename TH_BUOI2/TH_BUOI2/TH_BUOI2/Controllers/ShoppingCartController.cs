using Microsoft.AspNetCore.Mvc;

namespace TH_BUOI2.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
