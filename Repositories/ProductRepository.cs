using ECommerceSystemBl.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSystemBl.Repositories
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products
                .Include(p => p.Category)
                .ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public IQueryable<Product> GetProductsQuery()
        {
            return _context.Products;
        }

        public Product? GetByName(string productName)
        {
            return _context.Products
                .FirstOrDefault(p => p.ProductName == productName);
        }

        public bool HasOrders(int productId)
        {
            return _context.OrderProductss
                .Any(op => op.ProductId == productId);
        }
    }
}