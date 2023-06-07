using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BookstoreProject.Models;
using BookstoreProject.Services.Contracts;
using BookstoreProject.ApiModels;
using Microsoft.EntityFrameworkCore;

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
			
				List<VolumeInfo> volumeInfos = new List<VolumeInfo>();
			//string apiKey = "AIzaSyCQnwVpMZ5DqKI5JuwAwJ98vj2sV7Ihivs";
			List<Book> books = new List<Book>();
				string apiUrl = "https://www.googleapis.com/books/v1/volumes?q=subject:science&maxResults=40";

				var response = await _httpClient.GetAsync(apiUrl);

				if (response.IsSuccessStatusCode)
				{
					var json = await response.Content.ReadAsStringAsync();
					Root? result = JsonConvert.DeserializeObject<Root>(json);
					foreach (var item in result.items)
				{
					VolumeInfo volumeInfo = item.volumeInfo;
					volumeInfo.Id = item.id;
					volumeInfos.Add(volumeInfo);
				}

			}
				foreach (var item in volumeInfos)
				{
				Book book = new Book()
				{
					Id = item.Id,
					Title = item.title,
					Authors = item.authors,
					Publisher = item.publisher,
					DatePublished = item.publishedDate,
					Description = item.description,
					SaleInfo = item.saleInfo,
					industryIdentifiers = item.industryIdentifiers,
					imageLinks = item.imageLinks,
					};
					books.Add(book);
				}


			
            return books;
        }

		public async Task<List<CartItem>> GetCartItemsById(string id)
		{
			List<CartItem> cartItems = new List<CartItem>();
			var apiUrl = $"https://example.com/api/cartItems?id={id}";
			var response = await _httpClient.GetAsync(apiUrl);

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				cartItems = JsonConvert.DeserializeObject<List<CartItem>>(json);
			}

			return cartItems;
		}

	}
}