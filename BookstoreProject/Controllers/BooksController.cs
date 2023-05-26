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
        public IActionResult Delete()
        {
            return View();
        }
        public async Task<IActionResult> Edit()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
