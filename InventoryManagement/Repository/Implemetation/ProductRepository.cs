using InventoryManagement.Data;
using InventoryManagement.Models;
using InventoryManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Repository.Implemetation
{
    public class ProductRepository:IProductRepository
    {
        private readonly InventoryDbContext _context;
        public ProductRepository(InventoryDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            product.Id = 0;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product?> UpdateProductAsync(Product product)
        {
            var existing = await _context.Products.FindAsync(product.Id);
            if (existing == null) return null;

            existing.Name = product.Name;
            existing.Description = product.Description;
            existing.Price = product.Price;
            existing.QuantityInStock = product.QuantityInStock;
            existing.Category = product.Category;
            existing.ImageBase64 = product.ImageBase64;

            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Product>> SearchProductsAsync(string? name, string? category)
        {
            var query = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category.Contains(category));
            }
            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetPaginatedProductsAsync(int page, int pageSize)
        {
            return await _context.Products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
