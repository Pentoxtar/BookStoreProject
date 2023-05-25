namespace BookstoreProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Books> BooksCheckedOut { get; set; }
    }
}
