using BookstoreProject.Models;
using BookstoreProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreProject.Controllers
{
    public class StoreController : Controller
    {
        private readonly IBooksService _booksService;
        public StoreController(IBooksService service)
        {
            _booksService = service;
        }
        public async Task<IActionResult> Index()
        {
            List<Book> books = await _booksService.GetBooksFromGoogleBooksAPI();
            return View(books);
        }
		public async Task<IActionResult> Details(string id)
		{
			List<Book> books = await _booksService.GetBooksFromGoogleBooksAPI();
			Book book = books.FirstOrDefault(b => b.Id == id);
			if (book == null)
			{
				return NotFound();
			}

			return View(book);
		}

	}
}
