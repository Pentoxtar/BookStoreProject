using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BookstoreProject.Models
{
    public class Books
    {
        public string Id { get; set; }

        [Required]
        [StringLength(80)]
        [Display(Name ="Title")]
        public string Title { get; set; }

        [StringLength(50)]
        [Required]
		[Display(Name = "Author")]
		public string Author { get; set; }

        public string Description { get; set; }
		[Display(Name = "Publisher")]
		public string Publisher { get; set; }
        [Required]
		[Display(Name = "ISBN")]
		public string ISBN { get; set;}

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DatePublished { get; set;}

        [Required]
        public double Price { get; set; }
		[Display(Name = "BookPictureURL")]
		public string BookPictureURL { get; set;}
    }
}
