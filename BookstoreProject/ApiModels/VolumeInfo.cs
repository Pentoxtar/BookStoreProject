namespace BookstoreProject.ApiModels
{
    public class VolumeInfo
    {
        public string title { get; set; }
        public List<string> authors { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string description { get; set; }
		public ImageLinks imageLinks { get; set; }
		public SaleInfo saleInfo { get; set; }

		
	}
}
