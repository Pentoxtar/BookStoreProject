using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BookstoreProject.Models
{
    public class Books
    {
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set;}
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DatePublished { get; set;}
        public double Price { get; set; }
        public string BookPictureURL { get; set;}
    }
}
