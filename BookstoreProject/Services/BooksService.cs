using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BookstoreProject.Models;
namespace BookstoreProject.Services
{
    public class BooksService
    {
        private readonly HttpClient _httpClient;

        public BooksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Books>> GetBooksFromGoogleBooksAPI()
        {
            var apiUrl = "https://www.googleapis.com/books/v1/volumes?q=programming";

            
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

               
                var books = JsonConvert.DeserializeObject<List<Books>>(json);

                
                return books ?? new List<Books>();
            }

            
            return new List<Books>();
        }
    }
}
