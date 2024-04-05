using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;  
using TH_BUOI2.DataAcess;
using TH_BUOI2.Helpers;
using TH_BUOI2.Models;  

namespace TH_BUOI2.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

       
        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.GetObjectFromJson<List<CartItem>>("GioHang");
                if (data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }

        public IActionResult Index()
        {
            return View(Carts);
        }
        public IActionResult AddToCart(int id)
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.Id == id);
            if (item == null)
            {
                var product = _context.Products.SingleOrDefault(p => p.Id == id);
                item = new CartItem
                {
                    Id = id,
                    Name = product.Name,
                    Price = product.Price,
                    SoLuong = 1,
                    ImageUrl = product.ImageUrl,
                };
                myCart.Add(item);
            }
            else
            {
                item.SoLuong++;
            }

            // Convert the myCart list to a byte array before storing it in the session
            var cartByteArray = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(myCart);
            HttpContext.Session.Set("GioHang", cartByteArray);

            return RedirectToAction("Index");
        }


        public ActionResult GetCartData()
        {
            var cartItems = HttpContext.Session.GetObjectFromJson<List<CartItem>>("GioHang") ?? new List<CartItem>();

            ViewBag.CartItems = cartItems;

            // Tính tổng số lượng sản phẩm trong giỏ hàng
            int totalQuantity = cartItems.Sum(item => item.SoLuong);
            ViewBag.CartItemCount = totalQuantity;

            ViewBag.CartTotal = cartItems.Sum(item => item.SoLuong * item.Price);

            // Trả về PartialView chứa thông tin giỏ hàng
            return PartialView("_CartDataPartial", cartItems);
        }

    }
}
