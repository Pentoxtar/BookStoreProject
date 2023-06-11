using BookstoreProject.Models;
using BookstoreProject.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using X.PagedList;

namespace BookstoreProject.Controllers
{
    public class HomeController : Controller

    {
        private readonly IBooksService _booksService;

        public HomeController(IBooksService service)
        {
            _booksService = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Book> books = await _booksService.GetBooksFromGoogleBooksAPI();


            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}