using BookstoreProject.Models;

namespace BookstoreProject.Services.Contracts
{
    public interface ICartService
    {
        public void AddToCart(string id);
        public void RemoveFromCart(string id);
        public void ClearCart();
        public Cart GetCart();

        public void SaveCart(Cart cart);

        public Cart ViewCart();
    }
}
