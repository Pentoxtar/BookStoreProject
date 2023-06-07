using BookstoreProject.ApiModels;
using Microsoft.JSInterop.Implementation;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.ComponentModel.DataAnnotations;

namespace BookstoreProject.Models
{
    public class Book : BaseModel
    {

        [Required]
        //[StringLength(80)]
        [Display(Name ="Title")]
        public string? Title { get; set; }

        //[StringLength(50)]
        [Required]
		[Display(Name = "Author")]
		public List<string>? Authors { get; set; }

		public string? Description { get; set; }
		[Display(Name = "Publisher")]
		public string? Publisher { get; set; }

        [Required]
		[Display(Name = "ISBN")]
		public List<IndustryIdentifier>? industryIdentifiers { get; set; }

		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public string? DatePublished { get; set;}

        [Required]
		public SaleInfo? SaleInfo { get; set; }
		[Display(Name = "BookPictureURL")]
		public ImageLinks? imageLinks { get; set; }
		public double Price { get; set; }
	}
}
