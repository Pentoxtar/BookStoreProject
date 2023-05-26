using BookstoreProject.ApiModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.ComponentModel.DataAnnotations;

namespace BookstoreProject.Models
{
    public class Book : BaseModel
    {

        [Required]
        [StringLength(80)]
        [Display(Name ="Title")]
        public string? Title { get; set; }

        [StringLength(50)]
        [Required]
		[Display(Name = "Author")]
		public List<string> Authors { get; set; }

		public string? Description { get; set; }
		[Display(Name = "Publisher")]
		public string? Publisher { get; set; }

        [Required]
		[Display(Name = "ISBN")]
		public string? ISBN { get; set;}

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public string? DatePublished { get; set;}

        [Required]
		public SaleInfo saleInfo { get; set; }
		[Display(Name = "BookPictureURL")]
		public string? BookPictureURL { get; set;}
    }
}
