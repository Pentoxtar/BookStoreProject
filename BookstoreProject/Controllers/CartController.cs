using BookstoreProject.Models;
using BookstoreProject.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BookstoreProject.Controllers
{
	[Authorize]
	public class CartController : Controller
	{
        private readonly ICartService _cartService;
        
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

		public IActionResult Index()
		{
			Cart cart = _cartService.ViewCart();
			return View(cart);
		}

		public IActionResult AddToCart(string id)
        {
            _cartService.AddToCart(id);
            return RedirectToAction("Index");
        }
		public IActionResult RemoveFromCart(string id)
		{
			_cartService.RemoveFromCart(id);
			return RedirectToAction("Index");
		}

		public IActionResult ClearCart()
		{
			_cartService.ClearCart();
			return RedirectToAction("Index");
		}

	}
}
