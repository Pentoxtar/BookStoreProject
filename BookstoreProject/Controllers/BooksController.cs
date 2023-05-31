using BookstoreProject.Models;
using BookstoreProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreProject.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService _booksService;


        public BooksController(IBooksService service)
        { 
            _booksService = service;
        }
        public async Task<IActionResult> Index()
        {
            List<Book> books = await _booksService.GetBooksFromGoogleBooksAPI();
            return View(books);
        }
        
        public IActionResult Create()
        {
            return View();
        }
		public async Task<IActionResult> Delete(string id)
		{
			List<Book> books = await _booksService.GetBooksFromGoogleBooksAPI();
			Book book = books.FirstOrDefault(b => b.Id == id);
			if (book == null)
			{
				return NotFound();
			}

			return View(book);
		}
		public async Task<IActionResult> Edit(string id)
		{
			List<Book> books = await _booksService.GetBooksFromGoogleBooksAPI();
			Book book = books.FirstOrDefault(b => b.Id == id);
			if (book == null)
			{
				return NotFound();
			}

			return View(book);
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
