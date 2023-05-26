namespace BookstoreProject.ApiModels
{
    public class Root
    {
        public string kind { get; set; }
        public int totalItems { get; set; }
        public List<Item> items { get; set; }
    }
}
