using BookstoreProject.Models;
using BookstoreProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BookstoreProject.Controllers
{
	public class CartController : Controller
	{
        private readonly ICartService _cartService;
        
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

		public async Task<IActionResult> Index()
		{
            Cart cart = _cartService.ViewCart();
			return View(cart);
		}

        public IActionResult AddToCart(string id)
        {
            _cartService.AddToCart(id);
            return RedirectToAction("Index");
        }

        


    }
}
