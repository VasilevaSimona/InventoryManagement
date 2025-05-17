using AutoMapper;
using InventoryManagement.DTOs;
using InventoryManagement.Models;
using InventoryManagement.Repository.Interface;
using InventoryManagement.Service.Interface;

namespace InventoryManagement.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        public async Task<ProductDTO?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }
        public async Task<ProductDTO> AddProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var createdProduct = await _productRepository.AddProductAsync(product);
            return _mapper.Map<ProductDTO>(createdProduct);
        }
        public async Task<ProductDTO?> UpdateProductAsync(int id, ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var updated = await _productRepository.UpdateProductAsync(product);
            return _mapper.Map<ProductDTO>(updated);
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }
        public async Task<IEnumerable<ProductDTO>> SearchProductsAsync(string? name, string? category)
        {
            var products = await _productRepository.SearchProductsAsync(name, category);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        public async Task<IEnumerable<ProductDTO>> GetPaginatedProductsAsync(int page, int pageSize)
        {
            var products = await _productRepository.GetPaginatedProductsAsync(page, pageSize);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);

        }
    }
}
