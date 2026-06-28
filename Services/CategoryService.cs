using ECommerceSystemBl.Common;
using ECommerceSystemBl.DTOs.Category;
using ECommerceSystemBl.Models;
using ECommerceSystemBl.Repositories;

namespace ECommerceSystemBl.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _repository;

        public CategoryService(CategoryRepository repository)
        {
            _repository = repository;
        }

        public List<CategoryOutputDTO> GetAll()
        {
            return _repository.GetAllCategories()
                .Select(c => new CategoryOutputDTO
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Description = c.Description
                }).ToList();
        }

        public CategoryOutputDTO? GetById(int id)
        {
            var category = _repository.GetById(id);

            if (category == null)
                return null;

            return new CategoryOutputDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description
            };
        }

        public OperationResult Add(CategoryCreateDTO dto)
        {
            var existingCategory = _repository.GetByName(dto.CategoryName);

            if (existingCategory != null)
                return OperationResult.FailureResult(Messages.CategoryExists);

            var category = new Category
            {
                CategoryName = dto.CategoryName,
                Description = dto.Description
            };

            _repository.AddCategory(category);

            return OperationResult.SuccessResult(Messages.CategoryAdded);
        }

        public OperationResult Update(CategoryUpdateDTO dto)
        {
            var category = _repository.GetById(dto.CategoryId);

            if (category == null)
                return OperationResult.FailureResult(Messages.CategoryNotFound);

            var existingCategory = _repository.GetByName(dto.CategoryName);

            if (existingCategory != null &&
                existingCategory.CategoryId != dto.CategoryId)
            {
                return OperationResult.FailureResult(Messages.CategoryExists);
            }

            category.CategoryName = dto.CategoryName;
            category.Description = dto.Description;

            _repository.UpdateCategory(category);

            return OperationResult.SuccessResult(Messages.CategoryUpdated);
        }

        public OperationResult Delete(int categoryId)
        {
            var category = _repository.GetById(categoryId);

            if (category == null)
                return OperationResult.FailureResult(Messages.CategoryNotFound);

            if (_repository.HasProducts(categoryId))
                return OperationResult.FailureResult(Messages.CategoryHasProducts);

            _repository.DeleteCategory(category);

            return OperationResult.SuccessResult(Messages.CategoryDeleted);
        }
    }
}