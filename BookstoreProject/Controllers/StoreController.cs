using BookstoreProject.Models;
using BookstoreProject.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace BookstoreProject.Controllers
{
    public class StoreController : Controller
    {

        private readonly IBooksService _booksService;
        public StoreController(IBooksService service)
        {
            _booksService = service;
        }
        public async Task<IActionResult> Index(string search,int? page)
        {
            List<Book> books = await _booksService.GetBooksFromGoogleBooksAPI();

            if (!string.IsNullOrEmpty(search))
            {
                books = books.Where(b => b.Title.Contains(search) || b.Authors.Contains(search)).ToList();
            }
            int pageNumber = page ?? 1;  
            int pageSize = 20;            
            IPagedList<Book> pagedBooks = books.ToPagedList(pageNumber, pageSize);     
            return View(pagedBooks);
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
