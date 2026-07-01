using ECommerceSystemBl.DTOs.Cart;

namespace ECommerceSystemBl.Services
{
    public class CartService
    {
        public event Action? OnCartChanged;
        private readonly Dictionary<int, List<CartItemDTO>> carts = new();

        public void AddToCart(int userId, CartItemDTO item)
        {
            if (!carts.ContainsKey(userId))
            {
                carts[userId] = new List<CartItemDTO>();
            }

            var cart = carts[userId];

            var existingItem =
                cart.FirstOrDefault(x => x.ProductId == item.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
                OnCartChanged?.Invoke();
            }
            else
            {
                cart.Add(item);
                OnCartChanged?.Invoke();
            }
        }

        public List<CartItemDTO> GetCartItems(int userId)
        {
            if (!carts.ContainsKey(userId))
                return new List<CartItemDTO>();

            return carts[userId];
        }

        public void ClearCart(int userId)
        {
            if (carts.ContainsKey(userId))
            {
                carts[userId].Clear();
                OnCartChanged?.Invoke();
            }
        }
        public void IncreaseQuantity(int userId, int productId)
        {
            if (!carts.ContainsKey(userId))
                return;

            var item = carts[userId]
                .FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                item.Quantity++;
                OnCartChanged?.Invoke();
            }
        }
        public void DecreaseQuantity(int userId, int productId)
        {
            if (!carts.ContainsKey(userId))
                return;

            var item = carts[userId]
                .FirstOrDefault(x => x.ProductId == productId);

            if (item == null)
                return;

            item.Quantity--;

            if (item.Quantity <= 0)
            {
                carts[userId].Remove(item);
            }
            OnCartChanged?.Invoke();

        }
        public void RemoveItem(int userId, int productId)
        {
            if (!carts.ContainsKey(userId))
                return;

            var item = carts[userId]
                .FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                carts[userId].Remove(item);
                OnCartChanged?.Invoke();
            }
        }
        public int GetCartCount(int userId)
        {
            if (!carts.ContainsKey(userId))
                return 0;

            return carts[userId].Sum(x => x.Quantity);
        }
    }
}