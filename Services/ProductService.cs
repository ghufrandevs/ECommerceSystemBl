using ECommerceSystemBl.DTOs;
using ECommerceSystemBl.Models;
using ECommerceSystemBl.Repositories;

namespace ECommerceSystemBl.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public string AddProduct(ProductCreateDTO dto)
        {
            var product = new Product
            {
                ProductName = dto.ProductName,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Price = dto.Price,
                Stock = dto.Stock,
                CategoryId = dto.CategoryId
            };

            _productRepository.AddProduct(product);

            return "Product Added Successfully";
        }

        public List<ProductOutputDTO> GetAllProducts()
        {
            return _productRepository.GetAllProducts()
                .Select(p => new ProductOutputDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Stock = p.Stock,
                    CategoryId = p.CategoryId,
                    OverallRating = p.OverallRating
                })
                .ToList();
        }

        public ProductOutputDTO? GetProductById(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
                return null;

            return new ProductOutputDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                OverallRating = product.OverallRating
            };
        }

        public string UpdateProduct(int id, ProductUpdateDTO dto)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
                return "Product Not Found";

            product.ProductName = dto.ProductName;
            product.Description = dto.Description;
            product.ImageUrl = dto.ImageUrl;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.CategoryId = dto.CategoryId;

            _productRepository.UpdateProduct(product);

            return "Product Updated Successfully";
        }

        public string DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
                return "Product Not Found";

            if (_productRepository.HasOrders(id))
                return "Cannot delete this product because it has existing orders.";

            _productRepository.DeleteProduct(product);

            return "Product Deleted Successfully";
        }
    }
}