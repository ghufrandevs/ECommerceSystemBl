using ECommerceSystemBl.DTOs;
using ECommerceSystemBl.Models;
using ECommerceSystemBl.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSystemBl.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;
        private readonly AppDbContext _context;

        public OrderService(
            OrderRepository orderRepository,
            AppDbContext context)
        {
            _orderRepository = orderRepository;
            _context = context;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order? GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public List<Order> ViewMyOrders(int userId)
        {
            return _orderRepository.GetUserOrders(userId);
        }

        public object GetOrderDetails(int orderId, int userId)
        {
            var order = _orderRepository.GetById(orderId);

            if (order == null)
                return "Order Not Found";

            if (order.UserId != userId)
                return "Forbidden";

            var details = _orderRepository.GetOrderDetails(orderId);

            if (!details.Any())
                return "No Order Details Found";

            return details;
        }

        // ============================
        // PLACE ORDER
        // ============================

        public object PlaceOrder(
            PlaceOrderDTO dto,
            int userId)
        {
            var user = _context.Users.Find(userId);

            if (user == null)
            {
                return "User Not Found";
            }

            var duplicateProducts = dto.Items
                .GroupBy(i => i.ProductId)
                .Any(g => g.Count() > 1);

            if (duplicateProducts)
            {
                return "Duplicate products are not allowed in the same order";
            }

            decimal totalAmount = 0;

            using var transaction =
                _context.Database.BeginTransaction();

            try
            {
                // Validation Phase
                foreach (var item in dto.Items)
                {
                    var product = _context.Products.Find(item.ProductId);

                    if (product == null)
                    {
                        transaction.Rollback();
                        return "Product Not Found";
                    }

                    if (product.Stock < item.Quantity)
                    {
                        transaction.Rollback();

                        return $"Insufficient stock for product {product.ProductName}";
                    }
                }

                // Create Order
                Order order = new()
                {
                    UserId = userId,
                    OrderDate = DateTime.Now
                };

                _context.Orders.Add(order);
                _context.SaveChanges();

                // Execute Order
                foreach (var item in dto.Items)
                {
                    var product = _context.Products.Find(item.ProductId)!;

                    totalAmount += product.Price * item.Quantity;

                    product.Stock -= item.Quantity;

                    OrderProducts orderProduct = new()
                    {
                        OrderId = order.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    };

                    _context.OrderProductss.Add(orderProduct);
                }

                order.TotalAmount = totalAmount;

                _context.SaveChanges();

                transaction.Commit();

                return new
                {
                    Message = "Order Placed Successfully",
                    OrderId = order.OrderId,
                    TotalAmount = order.TotalAmount
                };
            }
            catch
            {
                transaction.Rollback();
                throw;
            }

        }
    }
}
