﻿using InventoryManagement.Models;

namespace InventoryManagement.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task<Product?> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<Product>> SearchProductsAsync(string? name, string? category);
        Task<IEnumerable<Product>> GetPaginatedProductsAsync(int page, int pageSize);
    }
}
