using ECommerceSystemBl.Models;

namespace ECommerceSystemBl.Repositories
{
    public class CategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category? GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public Category? GetByName(string categoryName)
        {
            return _context.Categories
                .FirstOrDefault(c => c.CategoryName == categoryName);
        }

        public bool HasProducts(int categoryId)
        {
            return _context.Products
                .Any(p => p.CategoryId == categoryId);
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}