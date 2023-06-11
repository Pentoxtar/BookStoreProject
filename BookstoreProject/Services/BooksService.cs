using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BookstoreProject.Models;
using BookstoreProject.Services.Contracts;
using BookstoreProject.ApiModels;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookstoreProject.Services
{
    public class BooksService : IBooksService

	{
		private readonly HttpClient _httpClient;

		public List<Book> Books = new List<Book>();
		public BooksService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

       public async Task<List<Book>> GetBooksFromGoogleBooksAPI()
{
    List<Book> books = new List<Book>();

    int maxResultsPerRequest = 20;
    int numRequests = 5;

    for (int i = 0; i < numRequests; i++)
    {
        int startIndex = i * maxResultsPerRequest;

        string apiUrl = $"https://www.googleapis.com/books/v1/volumes?q=subject:science&startIndex={startIndex}&maxResults={maxResultsPerRequest}";

        var response = await _httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            Root? result = JsonConvert.DeserializeObject<Root>(json);

            if (result != null && result.items != null)
            {
                foreach (var item in result.items)
                {
                    VolumeInfo volumeInfo = item.volumeInfo;
                    volumeInfo.Id = item.id;

                    Book book = new Book()
                    {
                        Id = volumeInfo.Id,
                        Title = volumeInfo.title,
                        Authors = volumeInfo.authors ?? new List<string>(),
                        Publisher = volumeInfo.publisher,
                        DatePublished = volumeInfo.publishedDate,
                        Description = volumeInfo.description,
                        SaleInfo = volumeInfo.saleInfo,
                        industryIdentifiers = volumeInfo.industryIdentifiers,
                        imageLinks = volumeInfo.imageLinks,
                    };
                    books.Add(book);
                }
            }
        }
    }

    return books;
     }
    }
}