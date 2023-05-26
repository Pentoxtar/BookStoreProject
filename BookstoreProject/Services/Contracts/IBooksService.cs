using BookstoreProject.Models;

namespace BookstoreProject.Services.Contracts
{
    public interface IBooksService
    {
        public Task<List<Book>> GetBooksFromGoogleBooksAPI();
       
    }
}
