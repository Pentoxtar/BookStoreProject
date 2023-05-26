using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BookstoreProject.Models;
using BookstoreProject.Services.Contracts;
using BookstoreProject.ApiModels;

namespace BookstoreProject.Services
{
    public class BooksService : IBooksService
	{
		private readonly HttpClient _httpClient;

		public BooksService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<Book>> GetBooksFromGoogleBooksAPI()
		{
			List<VolumeInfo> volumeInfos = new List<VolumeInfo>();
			List<Book> books = new List<Book>();
			//string apiKey = "AIzaSyCQnwVpMZ5DqKI5JuwAwJ98vj2sV7Ihivs";

            string apiUrl = $"https://www.googleapis.com/books/v1/volumes?q=best+sellers&maxResults=40";

			var response = await _httpClient.GetAsync(apiUrl);

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				Root result = JsonConvert.DeserializeObject<Root>(json);
				foreach (var item in result.items)
				{
					volumeInfos.Add(item.volumeInfo);
				}
				
			}
			foreach (var item in volumeInfos)
			{
				Book book = new Book()
				{
					Title = item.title,
					Authors=item.authors,
					Publisher = item.publisher,
					DatePublished = item.publishedDate,
					Description = item.description,
					saleInfo=item.saleInfo
					//BookPictureURL = item.

				};
				books.Add(book);
			}
			

			return books;
		}
	}
}