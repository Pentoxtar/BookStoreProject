using BookstoreProject.Models;
using BookstoreProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;

namespace BookstoreProject.Services

{
    public class CartService : ICartService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IBooksService _bookService;
        public CartService(IMemoryCache memoryCache, IBooksService bookService)
        {
            _memoryCache = memoryCache;
            _bookService = bookService;
        }

		public void AddToCart(string id)
		{
			var books = _bookService.GetBooksFromGoogleBooksAPI();
			var book = books.Result.FirstOrDefault(b => b.Id == id);
			if (book != null)
			{
				Cart cart = GetCart();
				cart.Items.Add(book);
				SaveCart(cart);
			}

		}
		public Cart GetCart()
        {
            Cart cart;
            if (!_memoryCache.TryGetValue("Cart", out cart))
            {
                cart = new Cart();
                SaveCart(cart);
            }
            return cart;
        }

        public void SaveCart(Cart cart)
        {
            _memoryCache.Set("Cart", cart);
        }

        public Cart ViewCart()
        {
            Cart cart = GetCart();
            return cart;
        }
		public void RemoveFromCart(string id)
		{
			Cart cart = GetCart();
			var bookToRemove = cart.Items.FirstOrDefault(item => item.Id == id);

			if (bookToRemove != null)
			{
				cart.Items.Remove(bookToRemove);
				SaveCart(cart);
			}
		}
		public void ClearCart()
		{
			Cart cart = GetCart();
			cart.Items.Clear();
			SaveCart(cart);
		}
	}
}
