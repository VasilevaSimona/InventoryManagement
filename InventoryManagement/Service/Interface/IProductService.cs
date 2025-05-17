using InventoryManagement.DTOs;
using InventoryManagement.Models;

namespace InventoryManagement.Service.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO?> GetProductByIdAsync(int id);
        Task<ProductDTO> AddProductAsync(ProductDTO product);
        Task<ProductDTO?> UpdateProductAsync(int id, ProductDTO product);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<ProductDTO>> SearchProductsAsync(string? name, string? category);
    }
}
