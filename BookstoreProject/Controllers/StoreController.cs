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

            // Номер на текущата страница (подразбиране: 1)
            int pageNumber = page ?? 1;

            // Брой елементи на страница (в случая: 20)
            int pageSize = 20;

            // Създаване на пагиниран списък от книги
            IPagedList<Book> pagedBooks = books.ToPagedList(pageNumber, pageSize);

            // Предаване на пагинираните данни на изгледа
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
