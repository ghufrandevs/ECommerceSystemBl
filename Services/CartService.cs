using ECommerceSystemBl.DTOs;

namespace ECommerceSystemBl.Services
{
    public class CartService
    {
        private readonly List<CartItemDTO> _cart = new();

        public List<CartItemDTO> GetCartItems()
        {
            return _cart;
        }

        public void AddToCart(CartItemDTO item)
        {
            var existingItem = _cart.FirstOrDefault(x =>
                x.ProductId == item.ProductId);

            if (existingItem == null)
            {
                _cart.Add(item);
            }
            else
            {
                existingItem.Quantity++;
            }
        }

        public void RemoveFromCart(int productId)
        {
            var item = _cart.FirstOrDefault(x =>
                x.ProductId == productId);

            if (item != null)
            {
                _cart.Remove(item);
            }
        }

        public void ClearCart()
        {
            _cart.Clear();
        }

        public decimal GetTotalPrice()
        {
            return _cart.Sum(x => x.Total);
        }

        public int GetItemsCount()
        {
            return _cart.Sum(x => x.Quantity);
        }
    }
}