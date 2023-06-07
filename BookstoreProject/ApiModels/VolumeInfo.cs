namespace BookstoreProject.ApiModels
{
    public class VolumeInfo 
    {
        
        public string Id { get; set; }
        public string title { get; set; }
        public List<string> authors { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string description { get; set; }
		public ImageLinks? imageLinks { get; set; }
		public SaleInfo saleInfo { get; set; }
        public PriceInfo? priceInfo { get; set; }
		public List<IndustryIdentifier> industryIdentifiers { get; set; }
        public int Quantity { get; set; }

	}
}
